using Microsoft.VisualBasic.FileIO;
using ProjectRecipe.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace ProjectRecipe.Repository
{
    public class CategoriesRepository : ICategories
    {
        private readonly string _connectionString = DBConnection.Open();

        private readonly string _tableName = "Categories";





        public int Add(Categories novaCategoria)
        {
            using (SqlConnection DataBaseConnection = new SqlConnection(_connectionString))
            {
                DataBaseConnection.Open();

                string InsertData = $"INSERT INTO {_tableName} (Category, DateRegister) VALUES(@Category, @DateRegister); SELECT SCOPE_IDENTITY();";

                using (SqlCommand sqlCommand = new SqlCommand(InsertData, DataBaseConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Category", novaCategoria.Category);
                    sqlCommand.Parameters.AddWithValue("@DateRegister", novaCategoria.DateRegister);

                    int idInserted = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    return idInserted;
                }
            }
        }



        /*
        public int Add(Categories novaCategoria)
        {   //Este método permite injeção de scripts maliciosos no Banco de Dados, não deve ser usado

            using SqlConnection DataBaseConection = new SqlConnection(_connectionString);
            DataBaseConection.Open();

            DateTime dataAtual = novaCategoria.DateRegister;
            //string dataSQL = dataAtual.ToString("yyyy-MM-dd HH:mm:ss");

            DateTime dataSQL = dataAtual;

            string InsertDados = @$"INSERT INTO {_tableName} (Category, DateRegister) 
                            VALUES('{novaCategoria.Category}','{dataSQL}');
                            SELECT @@IDENTITY;";


            int idInserido;
            using (SqlCommand comandoBD = DataBaseConection.CreateCommand())
            {
                comandoBD.CommandText = InsertDados;
                idInserido = Convert.ToInt32(comandoBD.ExecuteScalar());
            }


            //SqlCommand comandoBD = DataBaseConection.CreateCommand();
            
            //comandoBD.CommandText = InsertDados;
            //int idInserido = Convert.ToInt32(comandoBD.ExecuteScalar());
            //DataBaseConection.Close();

            return idInserido;
        }
        */

        public bool Delete(int id)
        {
            //DELETE FROM Categories WHERE id = 17;

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string inserirDados = $"DELETE FROM {_tableName} WHERE id = @idDeletar; ";

                SqlCommand comandoBD = new SqlCommand(inserirDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idDeletar", id);

                int affectedRows = comandoBD.ExecuteNonQuery();

                conexaoBD.Close();

                if(affectedRows > 0)
                {
                    return true;
                }

                return false;
            }

        }

        /*public bool DeleteId(int id)
        {
            return true;
        }*/

        public Categories Get(int id)
        {
           //SELECT* FROM Categories WHERE Id = 8;

            Categories listReturn = new Categories();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string inserirDados = $"SELECT * FROM {_tableName} WHERE Id = @idPesquisa; ";

                SqlCommand comandoBD = new SqlCommand(inserirDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idPesquisa", id);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Categories dados = new Categories();
                    listReturn.Id= (int)lista[0];
                    listReturn.Category = (string)lista[1];

                }

                conexaoBD.Close();

            }


            return listReturn;
        }

        public List<Categories> GetAll()
        {
            //SELECT * FROM Categories;

            List<Categories> listReturn = new List<Categories>(); 

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string inserirDados = $"SELECT * FROM {_tableName}; ";

                SqlCommand comandoBD = new SqlCommand(inserirDados, conexaoBD);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Categories dados = new Categories();
                    dados.Id = (int)lista[0];
                    dados.Category = (string)lista[1];

                    listReturn.Add(dados);
                }

                conexaoBD.Close();
              
            }


            return listReturn;
        }

        public Categories Update(Categories categoria)
        {

            //UPDATE Categories
            //SET Category = 'ABOBRINHA'
            //WHERE id = 8;

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string inserirDados = $"UPDATE {_tableName} SET Category = @novaCategory WHERE Id = @idAlterar; ";

                SqlCommand comandoBD = new SqlCommand(inserirDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@novaCategory", categoria.Category);
                comandoBD.Parameters.AddWithValue("@idAlterar", categoria.Id);

                int affectedRows2 = comandoBD.ExecuteNonQuery();

                conexaoBD.Close();

                if (affectedRows2 > 0)
                {
                    return categoria;
                }

                return null;
            }

            
        }
    }
}
