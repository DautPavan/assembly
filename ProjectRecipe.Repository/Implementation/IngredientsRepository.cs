using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRecipe.Model;

namespace ProjectRecipe.Repository
{
    public class IngredientsRepository : IIngredients     
    {
        private readonly string _connectionString = DBConnection.Open();

        private readonly string _tableName = "Ingredients";

        public int Add(Ingredients ingrediente)
        {
            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                DateTime dataAtual = ingrediente.DateRegister;
                //string dataSQL = dataAtual.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime dataSQL = dataAtual;

                string insertDados = $"INSERT INTO {_tableName} (Description, Quantity, idRecipe, DateRegister) VALUES(@description, @quantity, @idRecipe, @dataSQL); SELECT SCOPE_IDENTITY();";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@description", ingrediente.Description);
                comandoBD.Parameters.AddWithValue("@quantity", ingrediente.Quantity);
                comandoBD.Parameters.AddWithValue("@idRecipe", ingrediente.IdRecipe);
                comandoBD.Parameters.AddWithValue("@dataSQL", dataSQL);

                int idInserido = Convert.ToInt32(comandoBD.ExecuteScalar());

                conexaoBD.Close();

                return idInserido;
            }
        }

        public bool Delete(int id)
        {
            //..DELETE FROM Ingredients WHERE id = 1;

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"DELETE FROM {_tableName} WHERE id = @idDeletar; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

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

        public Ingredients Get(int id)
        {
            //SELECT* FROM Ingredients WHERE Id = 8;

            Ingredients dados = new Ingredients();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName} WHERE Id = @idPesquisa; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idPesquisa", id);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    dados.Id = (int)lista["Id"];
                    dados.Description = (string)lista["Description"];
                    dados.Quantity = (string)lista["Quantity"];
                    dados.IdRecipe = (int)lista["IdRecipe"];
                }

                conexaoBD.Close();
            }

            return dados;
        }

        public List<Ingredients> GetAll()
        {
            //SELECT * FROM Ingredients;

            List<Ingredients> listReturn = new List<Ingredients>();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName}; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Ingredients dados = new Ingredients();
                    dados.Id = (int)lista["Id"];
                    dados.Description = (string)lista["Description"];
                    dados.Quantity = (string)lista["Quantity"];
                    dados.IdRecipe = (int)lista["IdRecipe"];

                    listReturn.Add(dados);
                }

                conexaoBD.Close();

            }

            return listReturn;
        }

        public List<Ingredients> GetAllIdRecipe(int IdRecipe)
        {
            List<Ingredients> listReturn = new List<Ingredients>();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName} WHERE IdRecipe = @IdPesquisa; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idPesquisa", IdRecipe);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Ingredients dados = new Ingredients();
                    dados.Id = (int)lista["Id"];
                    dados.Description = (string)lista["Description"];
                    dados.Quantity = (string)lista["Quantity"];
                    dados.IdRecipe = (int)lista["IdRecipe"];

                    listReturn.Add(dados);
                }

            }

            return listReturn;
        }

        public Ingredients Update(Ingredients ingrediente)
        {
            //UPDATE Ingredients
            //SET Description = 'ABOBRINHA'
            //WHERE id = 8;

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"UPDATE {_tableName} SET Description = @Description, Quantity = @Quantity, idRecipe = @idRecipe  WHERE Id = @idAlterar; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@Description", ingrediente.Description);
                comandoBD.Parameters.AddWithValue("@Quantity", ingrediente.Quantity);
                comandoBD.Parameters.AddWithValue("@idRecipe", ingrediente.IdRecipe);
                comandoBD.Parameters.AddWithValue("@idAlterar", ingrediente.Id);
                


                int affectedRows2 = comandoBD.ExecuteNonQuery();

                conexaoBD.Close();

                if (affectedRows2 > 0)
                {
                    return ingrediente;
                }

                return null;
            }
        }

        /*Ingredients IIngredients.Get(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}


