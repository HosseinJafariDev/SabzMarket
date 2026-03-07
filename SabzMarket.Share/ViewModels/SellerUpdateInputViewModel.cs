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
    public class SellerUpdateInputViewModel : BaseValidatoin
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [MaxLength(50, ErrorMessage = Messages.firstNameInvalid2)]
        [MinLength(3, ErrorMessage = Messages.firstNameInvalid1)]
        public string? FirstName { get; set; }
        [MaxLength(50, ErrorMessage = Messages.lastNameInvalid2)]
        [MinLength(2, ErrorMessage = Messages.lastNameInvalid1)]
        public string? LastName { get; set; }
        [OptionalEmailAddress]
        public string? Email { get; set; }
        [NumberValidation]
        public string? Phone { get; set; }
        public string? CurrentUsername { get; set; }
        [Required(ErrorMessage = Messages.Mandatory)]
        public string? NewUsername { get; set; }
        [Required(ErrorMessage = Messages.EnterPassword)]
        public string? Password { get; set; }
        [StringLength(500, ErrorMessage = Messages.enterTheAddress)]
        public string? Address { get; set; }
        [Required(ErrorMessage = Messages.photoNotSelected)]
        public string? ProfileImage { get; set; }
        [MaxLength(3, ErrorMessage = Messages.enterTheWorkHistory)]
        [MinLength(1, ErrorMessage = Messages.enterTheWorkHistory)]
        public string? WorkHistory { get; set; }
    }
}
