using AuthDemo.Auth.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthDemo.Auth.Services.Interfaces
{
  public interface IUserService
  {
    public Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState);

    public Task<UserDto> Authenticate(string username, string password);

    public Task<UserDto> GetUser(ClaimsPrincipal user);

  }
}

