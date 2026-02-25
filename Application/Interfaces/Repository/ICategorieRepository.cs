using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ICategorieRepository
    {
        public Task<List<Categorie>> SelectAsync();
    }
}
