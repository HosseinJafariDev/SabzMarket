using SabzMarket.Share.CustomeAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Share.ViewModels
{
    public class CreateProductInputViewModel
    {
        public long SellerId { get; set; }
        [Required(ErrorMessage = Messages.ProductCategory)]
        public long CategoryId { get; set; }
        [Required(ErrorMessage = Messages.ProductName)]
        public string? Name { get; set; }
        [Required(ErrorMessage = Messages.ProductDescription)]
        [StringLength(500, ErrorMessage = Messages.ProductDescriptionLength)]
        public string? Description { get; set; }
        [PriceValidation]
        public int Price { get; set; }
        [ProductNumberValidation]
        public int Number { get; set; }
        [Required(ErrorMessage = Messages.ProductPhoto)]
        public string? ImageProduct { get; set; }
    }
}
