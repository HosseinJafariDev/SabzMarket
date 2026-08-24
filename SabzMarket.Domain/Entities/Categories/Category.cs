using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.Products;

namespace SabzMarket.Domain.Entities.Categories
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; private init; }
    }
}