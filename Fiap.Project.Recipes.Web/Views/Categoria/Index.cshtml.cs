using Fiap.Project.Recipes.Web.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fiap.Project.Recipes.Web.Views.Category
{
    public class IndexModel : PageModel
    {

       
            public readonly Database database;

            public IndexModel(Database database)
            {
                this.database = database;
            }

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
            Categorys = database.Categorys;
            }
        
    }
}
