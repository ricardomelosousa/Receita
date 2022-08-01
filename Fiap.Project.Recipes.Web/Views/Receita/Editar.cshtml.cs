using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Recipes.Web.Helpers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.Recipes.Web.Views.Recipe
{
    public class EditarModel : PageModel
    {
        [BindProperty()]
        public Project.Recipes.Domain.Models.Recipe Recipe { get; set; }
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
                                      JsonSerializer.Serialize(Recipe),
                                      Encoding.UTF8,
                                      "application/json");
                using var httpResponse =
                    await client.PostAsync("/Recipes/Insert", Category);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
            }
            return RedirectToPage("./Error");
        }
    }
}
