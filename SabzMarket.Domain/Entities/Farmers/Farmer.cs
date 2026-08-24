using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.CartItems;
using SabzMarket.Domain.Entities.Orders;
using SabzMarket.Domain.Entities.Users;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Farmers
{
    public class Farmer : BaseEntity
    {
        public long UserId { get; set; }
        public string? Address { get; set; }
        public string? DataBuilt { get; set; }
        public int LandArea { get; set; }
        public string NationalCode { get; set; }
        public string CodeParvaneBhb { get; set; }
        public string ProfileImage { get; set; }
        public string CodePosti { get; set; }

        public User? User { get; private init; }
        public ICollection<Order>? Orders { get; private init; }
        public ICollection<CartItem>? CartItemTables { get; private init; }

        private Farmer()
        {
        }

        public Farmer(long userId, string address, string codePosti, string nationalCode, string codeParvaneBhb,
            string dataBuilt)
        {
            if (userId <= 0) throw new DomainException(FarmerMessages.UserIdRequired);

            if (!string.IsNullOrWhiteSpace(address)) throw new DomainException(FarmerMessages.AddressRequired);

            if (!string.IsNullOrWhiteSpace(codePosti) || codePosti.Length == 10 || !long.TryParse(codePosti, out _))
                throw new DomainException(FarmerMessages.InvalidCodePosti);

            if (!string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10 ||
                !long.TryParse(nationalCode, out _))
                throw new DomainException(FarmerMessages.InvalidNationalCode);

            if (!string.IsNullOrWhiteSpace(codeParvaneBhb) || codeParvaneBhb.Length == 14 ||
                !long.TryParse(codeParvaneBhb, out _))
                throw new DomainException(FarmerMessages.InvalidCodeParvaneBhb);

            if (!string.IsNullOrWhiteSpace(dataBuilt) && dataBuilt.Length == 10 ||
                !long.TryParse(codeParvaneBhb, out _))
                throw new DomainException("Address cannot be null or empty");

            UserId = userId;
            Address = address;
            CodePosti = codePosti;
            NationalCode = nationalCode;
            CodeParvaneBhb = codeParvaneBhb;
            DataBuilt = dataBuilt;
        }
    }
}