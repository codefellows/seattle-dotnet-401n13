using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmailDemo.Services.Email.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailDemo.Pages
{
  public class IndexModel : PageModel
  {
    [BindProperty]
    public Player player { get; set; }

    [BindProperty]
    public string Message { get; set; }

    public IEmailSender emailService { get; set; }

    public IndexModel(IEmailSender service)
    {
      emailService = service;
    }

    public void OnGet()
    {
    }

    public async Task OnPost()
    {

      if (ModelState.IsValid)
      {

        await emailService.SendEmailAsync(player.Email, $"Welcome to the team, {player.Name}!", $"<p>We can't wait to see you wearing {player.Number} while playing {player.Position} </p>");

        Message = "Email Sent!";

        player.Name = string.Empty;
        player.Email = string.Empty;
        player.Position = string.Empty;
        player.Number = null;

      }

    }

    public class Player
    {
      [Required]
      public string Name { get; set; }
      [Required]
      public string Email { get; set; }
      [Required]
      public string Position { get; set; }
      [Required]
      public int? Number { get; set; }
    }
  }
}
