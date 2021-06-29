using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailDemo.Services.Email.Interfaces
{
  public interface IEmailSender
  {
    // Nice, simple interface: to email, subject of message, body of message
    // We can use any number of email providers so long as they can grok this!
    Task SendEmailAsync(string email, string subject, string htmlMessage);
  }
}
