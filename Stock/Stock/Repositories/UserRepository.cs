using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Stock.Models;
using System;
using System.Threading.Tasks;
using BCrypt.Net;
namespace Stock.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddUser(UserModel user)
        {
            string query = "INSERT INTO [User] (Nom, Prenom, Mail, MotDePasse) VALUES (@Nom, @Prenom, @Mail, @MotDePasse)";

            try
            {
               
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.MotDePasse);

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", user.Nom);
                    cmd.Parameters.AddWithValue("@Prenom", user.Prenom);
                    cmd.Parameters.AddWithValue("@Mail", user.Mail);
                    cmd.Parameters.AddWithValue("@MotDePasse", hashedPassword);  

                    conn.Open();
                    await cmd.ExecuteNonQueryAsync();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur lors de l'ajout de l'utilisateur.", ex);
            }
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            string query = "SELECT Nom, Prenom, Mail, MotDePasse FROM [User] WHERE Mail = @Mail";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Mail", email);

                    conn.Open();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read()) 
                        {
                            return new UserModel
                            {
                                Nom = reader["Nom"].ToString(),
                                Prenom = reader["Prenom"].ToString(),
                                Mail = reader["Mail"].ToString(),
                                MotDePasse = reader["MotDePasse"].ToString()
                            };
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur lors de la récupération de l'utilisateur.", ex);
            }

            return null;
        }

    }
}
