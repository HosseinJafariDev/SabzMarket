using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.UseCases.SignUp
{
    public class SignUpInputDTO
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password1 { get; set; }
        public string? Password2 { get; set; }
    }
}
