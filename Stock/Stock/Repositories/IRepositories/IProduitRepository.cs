using Stock.Models;

namespace Stock.Repositories.IRepositories
{
    public interface IProduitRepository
    {
        Task AddProduit(ProduitModel produit);
    }
}
