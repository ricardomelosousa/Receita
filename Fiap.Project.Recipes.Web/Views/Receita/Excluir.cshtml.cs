using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Fiap.Project.Recipes.Web.Helpers;
using Fiap.Project.Recipes.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiap.Project.Recipes.Web.Views.Recipe
{
    public class DeleteModel : PageModel
    {
         

        [BindProperty()]
        public Domain.Models.Recipe Recipe { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }        

            if (Recipe == null)
            {
                return NotFound();
            }

            return Page();
        }

        [Authorize]
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var token = ((ClaimsPrincipal)HttpContext.User.Identity).FindFirst("AcessToken").Value;
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44320/api/");
                client.DefaultRequestHeaders.Authorization =
                          new AuthenticationHeaderValue("Bearer", token);
                var recipe = new StringContent(
                                      JsonSerializer.Serialize(id),
                                      Encoding.UTF8,
                                      "application/json");
                using var httpResponse =
                    await client.PostAsync("/Recipes/delete", recipe);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
