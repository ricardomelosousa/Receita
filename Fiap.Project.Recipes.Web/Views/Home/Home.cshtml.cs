using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Fiap.Project.Recipes.Web.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiap.Project.Recipes.Web.Views.Login
{
    public class HomeModel : PageModel
    {
       
        public IActionResult OnGet()
        {
            return this.Page();
        }
    }
}
