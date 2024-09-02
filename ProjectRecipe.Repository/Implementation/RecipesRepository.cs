using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRecipe.Model;

namespace ProjectRecipe.Repository
{
    public class RecipesRepository : IRecipes
    {
        private readonly string _connectionString = DBConnection.Open();

        private readonly string _tableName = "Recipes";

        public int Add(Recipes receitas)
        {
            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();


                DateTime dataAtual = receitas.DateRegister;
                //string dataSQL = dataAtual.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime dataSQL = dataAtual;

                string insertDados = $"INSERT INTO {_tableName} (Title, Preparation, Classification, Time, Photo, Gastronomy, IdUser, IdDifficulty, IdCategory, Approval, Favorite, DateRegister) VALUES(@Title, @Preparation, @Classification, @Time, @Photo, @Gastronomy, @IdUser, @IdDifficulty, @IdCategory, @Approval, @Favorite, @dataSQL); SELECT SCOPE_IDENTITY();";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@Title", receitas.Title);
                comandoBD.Parameters.AddWithValue("@Preparation", receitas.Preparation);
                comandoBD.Parameters.AddWithValue("@Classification", receitas.Classification);
                comandoBD.Parameters.AddWithValue("@Time", receitas.Time);
                comandoBD.Parameters.AddWithValue("@Photo", receitas.Photo);
                comandoBD.Parameters.AddWithValue("@Gastronomy", receitas.Gastronomy);
                comandoBD.Parameters.AddWithValue("@IdUser", receitas.IdUser);
                comandoBD.Parameters.AddWithValue("@IdDifficulty", receitas.IdDifficulty);
                comandoBD.Parameters.AddWithValue("@IdCategory", receitas.IdCategory);
                comandoBD.Parameters.AddWithValue("@Approval", receitas.Approval);
                comandoBD.Parameters.AddWithValue("@Favorite", receitas.Favorite);
                comandoBD.Parameters.AddWithValue("@dataSQL", dataSQL);

                int idInserido = Convert.ToInt32(comandoBD.ExecuteScalar());

                conexaoBD.Close();
                return idInserido;
            }
        }

        public bool Delete(int id)
        {
            //..DELETE FROM Difficulties WHERE id = 1;

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string inserirDados = $"DELETE FROM {_tableName} WHERE id = @idDeletar; ";

                SqlCommand comandoBD = new SqlCommand(inserirDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idDeletar", id);

                int affectedRows = comandoBD.ExecuteNonQuery();

                conexaoBD.Close();

                if (affectedRows > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool DeleteId(int id)
        {
            return true;
        }

        public Recipes Get(int id)
        {

            Recipes listReturn = new Recipes();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string inserirDados = $"SELECT * FROM {_tableName} WHERE Id = @idPesquisa; ";

                SqlCommand comandoBD = new SqlCommand(inserirDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idPesquisa", id);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    listReturn.Id = (int)lista["Id"];
                    listReturn.Title = (string)lista["Title"];
                    listReturn.Preparation = (string)lista["Preparation"];
                    listReturn.Classification = (string)lista["Classification"];
                    listReturn.Time= (string)lista["Time"];
                    listReturn.Photo = (string)lista["Photo"];
                    listReturn.Gastronomy = (GastronomyEnum)lista["Gastronomy"];
                    listReturn.IdUser = (int)lista["IdUser"];
                    listReturn.IdDifficulty = (int)lista["IdDifficulty"];
                    listReturn.IdCategory = (int)lista["IdCategory"];
                    listReturn.Approval = (ApprovalEnum)lista["Approval"];
                    listReturn.Favorite = (FavoriteEnum)lista["Favorite"];
                    //listReturn.DateRegister = (DateTime)lista["DataRegister"];

                }

            }

            return listReturn;
        }

        public List<Recipes> GetAll()
        {

            List<Recipes> listReturn = new List<Recipes>();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName}; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Recipes dados = new Recipes();
                    dados.Id = (int)lista["Id"];
                    dados.Title = (string)lista["Title"];
                    dados.Preparation = (string)lista["Preparation"];
                    dados.Classification = (string)lista["Classification"];
                    dados.Time = (string)lista["Time"];
                    dados.Photo = (string)lista["Photo"];
                    dados.Gastronomy = (GastronomyEnum)lista["Gastronomy"];
                    dados.IdUser = (int)lista["IdUser"];
                    dados.IdDifficulty = (int)lista["IdDifficulty"];
                    dados.IdCategory = (int)lista["IdCategory"];
                    dados.Approval = (ApprovalEnum)lista["Approval"];
                    dados.Favorite = (FavoriteEnum)lista["Favorite"];

                    listReturn.Add(dados);
                }

            }

            return listReturn;
        }

        public Recipes Update(Recipes receitas)
        {

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"UPDATE {_tableName} SET Title = @Title, Preparation = @Preparation, Classification = @Classification," +
                    $" Time = @Time, Photo = @Photo, Gastronomy = @Gastronomy, IdUser = @IdUser, IdDifficulty = @IdDifficulty," +
                    $"IdCategory = @IdCategory, Approval = @Approval, Favorite = @Favorite WHERE id = @idAlterar; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@Title", receitas.Title);
                comandoBD.Parameters.AddWithValue("@Preparation", receitas.Preparation);
                comandoBD.Parameters.AddWithValue("@Classification", receitas.Classification);
                comandoBD.Parameters.AddWithValue("@Time", receitas.Time);
                comandoBD.Parameters.AddWithValue("@Photo", receitas.Photo);
                comandoBD.Parameters.AddWithValue("@Gastronomy", receitas.Gastronomy);
                comandoBD.Parameters.AddWithValue("@IdUser", receitas.IdUser);
                comandoBD.Parameters.AddWithValue("@IdDifficulty", receitas.IdDifficulty);
                comandoBD.Parameters.AddWithValue("@IdCategory", receitas.IdCategory);
                comandoBD.Parameters.AddWithValue("@Approval", receitas.Approval);
                comandoBD.Parameters.AddWithValue("@Favorite", receitas.Favorite);

                comandoBD.Parameters.AddWithValue("@idAlterar", receitas.Id);

                int affectedRows2 = comandoBD.ExecuteNonQuery();

                conexaoBD.Close();

                if (affectedRows2 > 0)
                {
                    return receitas;
                }

                return null;
            }
        }
    }
}
