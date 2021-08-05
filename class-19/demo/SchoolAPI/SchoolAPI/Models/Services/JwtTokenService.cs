using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Services
{
  public class JwtTokenService
  {
    private IConfiguration configuration;
    private SignInManager<ApplicationUser> signInManager;

    public JwtTokenService(IConfiguration config, SignInManager<ApplicationUser> manager)
    {
      configuration = config;
      signInManager = manager;
    }

    public async Task<string> GetTokenAsync(ApplicationUser user, TimeSpan expiresIn)
    {

      var principal = await signInManager.CreateUserPrincipalAsync(user);
      if (principal == null) { return null; }

      var signingKey = GetSecurityKey(configuration);
      var token = new JwtSecurityToken(
        expires: DateTime.UtcNow + expiresIn,
        signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
        claims: principal.Claims
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static TokenValidationParameters GetValidationParameters(IConfiguration configuration)
    {
      return new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        // This Is Our main goal: Make sure the security key, which comes from configuration is valid
        IssuerSigningKey = GetSecurityKey(configuration),

        // For simplifying testing
        ValidateIssuer = false,
        ValidateAudience = false,
      };
    }

    private static SecurityKey GetSecurityKey(IConfiguration configuration)
    {
      var secret = configuration["JWT:Secret"];
      if(secret == null) { throw new InvalidOperationException("JWT: No Secret");  }
      var secretBytes = Encoding.UTF8.GetBytes(secret); // askf =>[ 64 25 87]
      return new SymmetricSecurityKey(secretBytes);
    }

  }
}
