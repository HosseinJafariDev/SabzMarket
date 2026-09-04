using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.SignUp
{
    public record SignUpInputDto(
        long Id,
        long OtpId,
        long Otp,
        string FirstName,
        string LastName,
        string Email,
        string Phone,
        string UserName,
        string Password,
        string ConfirmPassword
    );
}