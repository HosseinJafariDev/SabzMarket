using SabzMarket.Share.CustomeAttribute;
using SabzMarket.Share.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Share.ViewModels
{
    public class CreateFarmerInputViewModel : BaseValidatoin
    {
        [Required(ErrorMessage = Messages.enterTheAddress)]
        [StringLength(500, ErrorMessage = Messages.enterTheAddress)]
        public string? Address { get; set; }
        [Required(ErrorMessage = Messages.EnterDataBuilt)]
        [StringLength(10, ErrorMessage = Messages.EnterDataBuilt)]
        public string? DataBuilt { get; set; }
        [Required(ErrorMessage = Messages.EnterLandArea)]
        [Range(1, int.MaxValue, ErrorMessage = Messages.EnterLandArea)]
        public int LandArea { get; set; }
        [NationalCodeValidation]
        [Required(ErrorMessage = Messages.NotValidNationalCode)]
        public string? NationalCode { get; set; }
        [Required(ErrorMessage = Messages.EnterCodParvaneBHB)]
        [StringLength(14, ErrorMessage = Messages.EnterCodParvaneBHB, MinimumLength = 14)]
        public string? CodParvaneBHB { get; set; }
        [Required(ErrorMessage = Messages.photoNotSelected)]
        public string? ProfileImage { get; set; }
        [Required(ErrorMessage = Messages.EnterCodePosti)]
        [StringLength(10, ErrorMessage = Messages.EnterCodePosti, MinimumLength = 10)]
        public string? CodePosti { get; set; }
    }
}
