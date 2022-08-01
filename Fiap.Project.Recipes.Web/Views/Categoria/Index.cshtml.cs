using Project.Recipes.Web.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.Recipes.Web.Views.Category
{
    public class IndexModel : PageModel
    {

        public IEnumerable<Domain.Models.Category> Categorys { get; private set; }

        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44320/api");
                using var httpResponse =
                    await client.GetAsync("/Categories/GetAll");
                if (httpResponse.IsSuccessStatusCode)
                {
                    using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                    Categorys = await JsonSerializer.DeserializeAsync<List<Domain.Models.Category>>(responseStream);
                }
            }
        }

    }
}
