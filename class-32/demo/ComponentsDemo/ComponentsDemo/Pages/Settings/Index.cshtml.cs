using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ComponentsDemo.Pages.Settings
{
  public class IndexModel : PageModel
  {

    [BindProperty]
    public SettingsVM Settings { get; set; }
    public void OnGet()
    {
      string username = HttpContext.Request.Cookies["Username"] != null ? HttpContext.Request.Cookies["Username"] : "";
      string mode = HttpContext.Request.Cookies["Mode"] != null ? HttpContext.Request.Cookies["Mode"] : "light";

      DisplayMode displayMode = (DisplayMode)Enum.Parse(typeof(DisplayMode), mode);

      Settings = new SettingsVM()
      {
        Username = username,
        Mode = displayMode
      };

    }

    public void OnPost()
    {
      CookieOptions cookieOptions = new CookieOptions();
      cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
      HttpContext.Response.Cookies.Append("Username", Settings.Username, cookieOptions);
      HttpContext.Response.Cookies.Append("Mode", Settings.Mode.ToString(), cookieOptions);
    }

    public class SettingsVM
    {
      public string Username { get; set; }
      public DisplayMode Mode { get; set; }
    }

    public enum DisplayMode
    {
      light,
      dark
    }
  }
}
