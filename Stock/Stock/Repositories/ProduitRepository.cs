using Microsoft.Data.SqlClient;
using Stock.Models;
using Stock.Repositories.IRepositories;

namespace Stock.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly string _connectionString;

        public ProduitRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddProduit(ProduitModel produit)
        {
            string query = "INSERT INTO Produit (Nom, Marque, GTIN, Prix) VALUES (@Nom, @Marque, @GTIN, @Prix)";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", produit.Nom);
                    cmd.Parameters.AddWithValue("@Marque", produit.Marque);
                    cmd.Parameters.AddWithValue("@GTIN", produit.GTIN);
                    cmd.Parameters.AddWithValue("@Prix", produit.Prix);

                    conn.Open();
                    await cmd.ExecuteNonQueryAsync();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur lors de l'ajout du produit.", ex);
            }
        }
    }
}
