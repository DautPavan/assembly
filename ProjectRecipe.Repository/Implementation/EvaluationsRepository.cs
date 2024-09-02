using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ProjectRecipe.Model;

namespace ProjectRecipe.Repository
{
    public class EvaluationsRepository : IEvaluations
    {
        private readonly string _connectionString = DBConnection.Open();
        
        private readonly string _tableName = "Evaluations";

        //private readonly string _tableName = "Evaluation";

        public int Add(Evaluations avaliacao)
        {
            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                DateTime dataAtual = avaliacao.DateRegister;
               // string dataSQL = dataAtual.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime dataSQL = dataAtual;


                string insertDados = $"INSERT INTO {_tableName} (Name, Grade, IdRecipe, Approval, DateRegister) VALUES(@Name, @Grade, @IdRecipe, @Approval, @dataSQL); SELECT SCOPE_IDENTITY();";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@Name", avaliacao.Name);
                comandoBD.Parameters.AddWithValue("@Grade", avaliacao.Grade);
                comandoBD.Parameters.AddWithValue("@IdRecipe", avaliacao.IdRecipe);
                comandoBD.Parameters.AddWithValue("@Approval", avaliacao.Approval);
                comandoBD.Parameters.AddWithValue("@dataSQL", dataSQL);

                int idInserido = Convert.ToInt32(comandoBD.ExecuteScalar());    
                
                return idInserido;  
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"DELETE FROM {_tableName} WHERE id = @idDeletar; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idDeletar", id);

                int affectedRows = comandoBD.ExecuteNonQuery();

                conexaoBD.Close();

                if (affectedRows> 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool DeleteId(int id)
        {
            return Delete(id);
        }

        public Evaluations Get(int id)
        {
            Evaluations dados= new Evaluations();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString)) 
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName} WHERE id = @idPesquisa; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("idPesquisa", id);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    dados.Id = (int)lista["Id"];
                    dados.Name = (string)lista["Name"];
                    dados.Grade = (GradeEnum)lista["Grade"];
                    dados.IdRecipe = (int)lista["IdRecipe"];
                    dados.Approval = (ApprovalEnum)lista["Approval"];
                   
                }

            }

            return dados;
        }

        public List<Evaluations> GetAll()
        {
            List<Evaluations> listReturn = new List<Evaluations>();

            using (SqlConnection conexaoBD=new SqlConnection(_connectionString)) 
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName}; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Evaluations dados = new Evaluations();
     
                    dados.Id = (int)lista["Id"];
                    dados.Name = (string)lista["Name"];
                    dados.Grade = (GradeEnum)lista["Grade"];
                    dados.IdRecipe = (int)lista["IdRecipe"];
                    dados.Approval = (ApprovalEnum)lista["Approval"];

                    listReturn.Add(dados);
                }

                conexaoBD.Close();
            }

            return listReturn;
        }

        public List<Evaluations> GetAllRecipeApproved(int id)
        {
            List<Evaluations> listReturn = new List<Evaluations>();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName} WHERE idRecipe = @idPesquisa AND Approval = 1; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("idPesquisa", id);


                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Evaluations dados = new Evaluations();

                    dados.Id = (int)lista["Id"];
                    dados.Name = (string)lista["Name"];
                    dados.Grade = (GradeEnum)lista["Grade"];
                    dados.IdRecipe = (int)lista["IdRecipe"];
                    dados.Approval = (ApprovalEnum)lista["Approval"];

                    listReturn.Add(dados);
                }

                conexaoBD.Close();
            }

            return listReturn;
        }

        public Evaluations Update(Evaluations avaliacao)
        {
            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"UPDATE {_tableName} SET Name = @Name, Grade = @Grade, IdRecipe = @IdRecipe, Approval = @Approval WHERE Id = @idAlterar; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@Name", avaliacao.Name);
                comandoBD.Parameters.AddWithValue("@Grade", (int)avaliacao.Grade);
                comandoBD.Parameters.AddWithValue("@IdRecipe", avaliacao.IdRecipe);
                comandoBD.Parameters.AddWithValue("@Approval", (int)avaliacao.Approval);
                comandoBD.Parameters.AddWithValue("@idAlterar", avaliacao.Id);

                int affectedRows3 = comandoBD.ExecuteNonQuery();

                conexaoBD.Close();

                if (affectedRows3 > 0)
                {
                    return avaliacao;
                }

                return null;
            }
        }

        /*
        Evaluations IEvaluations.Get(int id)
        {
            throw new NotImplementedException();
        }
        */
    }

}
