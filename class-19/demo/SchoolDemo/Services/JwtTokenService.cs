using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDemo.Services
{
  public class JwtTokenService
  {
    private IConfiguration configuration;
    private SignInManager<ApplicationUser> signInManager;

    // SigninManager - Similar to the UserManager we got from Identity to handle logins
    public JwtTokenService(IConfiguration config, SignInManager<ApplicationUser> manager)
    {
      configuration = config;
      signInManager = manager;

    }

    // Validate that our "secrets" are actually secrets and that they match
    // This will be used by the validator
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
      if (secret == null) { throw new InvalidOperationException("JWT:Secret is midding"); }
      var secretBytes = Encoding.UTF8.GetBytes(secret);
      return new SymmetricSecurityKey(secretBytes);
    }

    public async Task<string> GetToken(ApplicationUser user, TimeSpan expiresIn)
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
  }
}
