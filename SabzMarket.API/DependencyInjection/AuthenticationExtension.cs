using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SabzMarket.Infrastructure.Configuration.JwtToken;

namespace SabzMarket.API.DependencyInjection;

public static class AuthenticationExtension
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
        JwtConfiguration configuration)
    {
        services
            .AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        RequireSignedTokens = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(
                                    configuration.SecretKey!)),

                        RequireExpirationTime = true,
                        ValidateLifetime = true,

                        ValidateAudience = true,
                        ValidAudience = configuration.Audience,

                        ValidateIssuer = true,
                        ValidIssuer = configuration.Issuer,
                    };
            });

        return services;
    }
}