using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Project.Recipes.Web.Helpers;
using Project.Recipes.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Recipes.Web.Views.Recipe
{
    public class InsertModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty()]
        public Domain.Models.Recipe Recipe { get; set; }
        [Authorize]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var token = ((ClaimsPrincipal)HttpContext.User.Identity).FindFirst("AcessToken").Value;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44320/api/");
                client.DefaultRequestHeaders.Authorization =
                          new AuthenticationHeaderValue("Bearer", token);
                var recipe = new StringContent(
                                      JsonSerializer.Serialize(Recipe),
                                      Encoding.UTF8,
                                      "application/json");
                using var httpResponse =
                    await client.PostAsync("/Recipes/Insert", recipe);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
            }



            return RedirectToPage("./Error");
        }
    }
}
