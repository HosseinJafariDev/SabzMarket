using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Categorie;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ICategorieRepository : IRepository<Category, long>
    {
    }
}