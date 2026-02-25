using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Infrastructure.Persistence;
using SabzMarket.Domain.Entities;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly SabzMarketDbContext _context;
        public CategorieRepository(SabzMarketDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categorie>> SelectAsync()
        {
            var result = await _context
                .Categories
                .AsNoTracking()
                .Select(x => new Categorie
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();
            return result;
        }
    }
}
