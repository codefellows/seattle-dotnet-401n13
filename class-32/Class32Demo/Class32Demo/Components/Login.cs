using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class32Demo.Components
{
    public class Login : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //TODO Identity
            string username = HttpContext.Request.Cookies["username"] ?? "";
            ViewModel user = new ViewModel()
            {
                Username = username
            };
            return View(user);
        }

        public class ViewModel
        {
            public string Username { get; set; }
        }
    }
}
