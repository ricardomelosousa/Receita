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

namespace Fiap.Project.Recipes.Web.Views.Category
{
    public class EditarModel : PageModel
    {
        [BindProperty()]
        public Fiap.Project.Recipes.Domain.Models.Category Categor { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44320/api/");

                using var httpResponse =
                    await client.GetAsync($"/Categorys/Get?id={id}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                    Categor = await JsonSerializer.DeserializeAsync<Domain.Models.Category>(responseStream);
                    return RedirectToPage("./Index");
                }
            }

            if (Categor == null)
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
                                      JsonSerializer.Serialize(Categor),
                                      Encoding.UTF8,
                                      "application/json");
                using var httpResponse =
                    await client.PostAsync("/Categorys/Update", Category);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
            }

            return RedirectToPage("./Index");
        }
    }
}

