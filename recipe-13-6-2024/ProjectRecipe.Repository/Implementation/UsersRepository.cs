using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRecipe.Model;

namespace ProjectRecipe.Repository
{
    public class UsersRepository : IUsers
    {
        private readonly string _connectionString = DBConnection.Open();

        private readonly string _tableName = "Users";

        public int Add(Users usuarios)
        {
            /*INSERT INTO Users(Name, Email, Phone, Password, UserType, DateRegister)
            VALUES('Daniela', 'danielatavaresd@gmail.com', '123456', '147258', 1, '1982-01-20');*/

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                DateTime dataAtual = usuarios.DateRegister;
                //string dataSQL = dataAtual.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime dataSQL = dataAtual;

                string insertDados = $"INSERT INTO {_tableName} (Name, Email, Phone, Password, UserType, DateRegister) VALUES(@Name, @Email, @Phone, @Password, @UserType, @dataSQL); SELECT SCOPE_IDENTITY();";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@Name", usuarios.Name);
                comandoBD.Parameters.AddWithValue("@Email", usuarios.Email);
                comandoBD.Parameters.AddWithValue("@Phone", usuarios.Phone);
                comandoBD.Parameters.AddWithValue("@Password", usuarios.Password);
                comandoBD.Parameters.AddWithValue("@UserType",usuarios.UserType);
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

        public Users Get(int id)
        {
            //SELECT* FROM Users WHERE Id = 8;

            Users dados = new Users();

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
                    dados.Name = (string)lista["Name"];
                    dados.Email = (string)lista["Email"];
                    dados.Password = (string)lista["Password"];
                    dados.Phone = (string)lista["Phone"];
                    // dados.UserType = (UserTypeEnum)lista[4];

                }

            }

            return dados;
        }

        public List<Users> GetAll()
        {
            //SELECT * FROM Users;

            List<Users> listReturn = new List<Users>();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName}; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    Users dados = new Users();
                    dados.Id = (int)lista["Id"];
                    dados.Name = (string)lista["Name"];
                    dados.Email = (string)lista["Email"];
                    dados.Password = (string)lista["Password"];
                    dados.Phone = (string)lista["Phone"];
                    // dados.UserType = (UserTypeEnum)lista[4];

                    listReturn.Add(dados);
                }

                conexaoBD.Close();

            }

            return listReturn;
        }

        public bool LoginEmail(string email)
        {
            Users dados = new Users();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName} WHERE Email = @idEmail; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idEmail", email);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    return false;
                }
            }

            return true;
        }

        public Users LoginEmailUsers(string email)
        {
            Users dados = new Users();
            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName} WHERE Email = @idEmail; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idEmail", email);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    dados.Id = (int)lista["Id"];
                    dados.Name = (string)lista["Name"];
                    dados.Email = (string)lista["Email"];
                    dados.Password = (string)lista["Password"];
                    dados.Phone = (string)lista["Phone"];
                    dados.UserType = (UserTypeEnum)lista["UserType"];
                    return dados;
                }
            }
            return dados;
        }

        public Users LoginUser(string email, string senha)
        {
            Users dados = new Users();

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"SELECT * FROM {_tableName} WHERE Email = @idEmail; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@idEmail", email);

                SqlDataReader lista = comandoBD.ExecuteReader();

                while (lista.Read())
                {
                    dados.Id = (int)lista["Id"];
                    dados.Name = (string)lista["Name"];
                    dados.Email = (string)lista["Email"];
                    dados.Password = (string)lista["Password"];
                    dados.Phone = (string)lista["Phone"];
                    dados.UserType = (UserTypeEnum)lista["UserType"];

                    if (dados.Password.Equals(senha))
                    {
                        return dados;
                    }
                } 

            }

            return null;
        }

        public Users Update(Users usuarios)
        {

            /*UPDATE Users
            SET Name = 'Rui', Email = 'bela@user.com', Phone = '3333', Password = 'senha123', UserType = 2
             WHERE Id = 7*/

            using (SqlConnection conexaoBD = new SqlConnection(_connectionString))
            {
                conexaoBD.Open();

                string insertDados = $"UPDATE {_tableName} SET Name = @name, Email = @email, Phone = @phone, Password = @password, UserType = @usertype WHERE id = @idAlterar; ";

                SqlCommand comandoBD = new SqlCommand(insertDados, conexaoBD);

                comandoBD.Parameters.AddWithValue("@name", usuarios.Name);
                comandoBD.Parameters.AddWithValue("@email", usuarios.Email);
                comandoBD.Parameters.AddWithValue("@phone", usuarios.Phone);
                comandoBD.Parameters.AddWithValue("@password", usuarios.Password);
                comandoBD.Parameters.AddWithValue("@usertype", usuarios.UserType);
                comandoBD.Parameters.AddWithValue("@idAlterar", usuarios.Id);


                int affectedRows2 = comandoBD.ExecuteNonQuery();

                conexaoBD.Close();

                if (affectedRows2 > 0)
                {
                    return usuarios;
                }

                return null;
            }
        }


        /*
        Users IUsers.Get(int id)
        {
            throw new NotImplementedException();
        }
        */
    }
}
