
using ProjectRecipeBack.Domain;
using ProjectRecipeBack.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipeBack.Repository.Repository
{
    public class DifficultiesRepository : IDifficulties
    {

        private readonly string _connectionString = DBConnection.Open();

        private readonly string _tableName = "Difficulties";

        public int Add(Difficulties dificuldades)
        {
            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();


                DateTime dataAtual = dificuldades.DateRegister;
                //string dataSQL = dataAtual.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime dataSQL = dataAtual;

                string insertDados = $"INSERT INTO {_tableName} (Description, DateRegister) VALUES(@Description, @dataSQL); SELECT SCOPE_IDENTITY();";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@Description", dificuldades.Description);
                comandoBD.Parameters.AddWithValue("@dataSQL", dataSQL);

                int idInserido = Convert.ToInt32(comandoBD.ExecuteScalar());

                conexaoBD.Close();
                return idInserido;
            }
        }

        public bool Delete(int id)
        {

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

        public Difficulties Get(int id)
        {

            Difficulties listReturn = new Difficulties();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string inserirDados = $"SELECT * FROM {_tableName} WHERE Id = @idPesquisa; ";

                SqlCommand comandoBD = new SqlCommand(inserirDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idPesquisa", id);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Recipes dados = new Recipes();
                    listReturn.Id = (int)lista[0];
                    listReturn.Description = (string)lista[1];

                }

            }


            return listReturn;
        }

        public List<Difficulties> GetAll()
        {
            //SELECT * FROM Difficulties;

            List<Difficulties> listReturn = new List<Difficulties>();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName}; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Difficulties dados = new Difficulties();
                    dados.Id = (int)lista[0];
                    dados.Description = (string)lista[1];

                    listReturn.Add(dados);
                }

                conexaoBD.Close();

            }


            return listReturn;
        }

        public Difficulties Update(Difficulties dificuldades)
        {

            //UPDATE Difficulties
            //SET Description = 'ABOBRINHA'
            //WHERE id = 8;

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"UPDATE {_tableName} SET Description = @novaDifficulties WHERE id = @idAlterar; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@novaDifficulties", dificuldades.Description); 
                comandoBD.Parameters.AddWithValue("@idAlterar", dificuldades.Id);

                int affectedRows2 = comandoBD.ExecuteNonQuery();

                conexaoBD.Close();

                if (affectedRows2 > 0)
                {
                    return dificuldades;
                }

                return null;
            }
        }

    }
}
