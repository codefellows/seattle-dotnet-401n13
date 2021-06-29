using EmailDemo.Services.Email.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailDemo.Services.Email
{
  public class SendGridEmailer : IEmailSender
  {

    private IConfiguration Configuration { get; set; }

    public SendGridEmailer(IConfiguration config)
    {
      Configuration = config;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
      SendGridClient client = new SendGridClient(Configuration["SendGrid:Key"]);
      SendGridMessage msg = new SendGridMessage();
      msg.SetFrom(Configuration["SendGrid:DefaultFromAddress"], Configuration["SendGrid:DefaultFromName"]);
      msg.AddTo(email);
      msg.SetSubject(subject);
      msg.AddContent(MimeType.Html, htmlMessage);
      await client.SendEmailAsync(msg);
    }
  }
}
