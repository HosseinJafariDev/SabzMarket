using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.UseCases.Login
{
    public class LoginInputDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
