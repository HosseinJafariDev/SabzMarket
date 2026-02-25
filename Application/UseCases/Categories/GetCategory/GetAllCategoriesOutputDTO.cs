using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Categories.GetCategory
{
    public class GetAllCategoriesOutputDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}
