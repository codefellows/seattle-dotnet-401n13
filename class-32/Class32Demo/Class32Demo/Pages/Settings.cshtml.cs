using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Class32Demo.Pages
{

    public class SettingsModel : PageModel
    {
        [BindProperty]
        public UserSettingsModel Input { get; set; }



        public void OnGet()
        {
            string username = HttpContext.Request.Cookies["username"] ?? "";
            string mode = HttpContext.Request.Cookies["mode"] ?? "light";

            Input = new UserSettingsModel();
            Input.UserName = username;
            Input.Mode = (ColorScheme)Enum.Parse(typeof(ColorScheme), mode);
        }

        public void OnPost()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("username", Input.UserName, cookieOptions);
            HttpContext.Response.Cookies.Append("mode", Input.Mode.ToString(), cookieOptions);
        }

        public class UserSettingsModel
        {
            public string UserName { get; set; }
            public ColorScheme Mode { get; set; }
        }

        public enum ColorScheme { light, dark }
    }
}
