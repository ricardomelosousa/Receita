using Fiap.Project.Recipes.Web.Helpers;
using Fiap.Project.Recipes.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Web.Views.Category
{
    public class DeleteModel : PageModel
    {
       
        [BindProperty()]
        public Domain.Models.Category Category { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (Category == null)
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
                var token = ((ClaimsPrincipal)HttpContext.User.Identity).FindFirst("AcessToken").Value;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44320/api/");
                    client.DefaultRequestHeaders.Authorization =
                              new AuthenticationHeaderValue("Bearer", token);
                    var Category = new StringContent(
                                      JsonSerializer.Serialize(id),
                                      Encoding.UTF8,
                                      "application/json");
                    using var httpResponse =
                        await client.PostAsync("/Recipes/Insert?id", Category);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        return RedirectToPage("./Index");
                    }
                }
            }

            return RedirectToPage("./Error");
        }
    }
}
