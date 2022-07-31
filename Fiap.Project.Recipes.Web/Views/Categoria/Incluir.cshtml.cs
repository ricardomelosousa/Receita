using Fiap.Project.Recipes.Web.Helpers;
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
    public class InsertModel : PageModel
    {      
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty()]
        public Domain.Models.Category Categor { get; set; }

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
                var Category = new StringContent(
                                      JsonSerializer.Serialize(Categor),
                                      Encoding.UTF8,
                                      "application/json");
                using var httpResponse =
                    await client.PostAsync("/Categorys/Insert", Category);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
            }
            return RedirectToPage("./Erro");
        }
    }
}
