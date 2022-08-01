using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Project.Recipes.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Recipes.Web.Views.Recipe
{
    public class IndexModel : PageModel
    {
       
        public IEnumerable<Domain.Models.Recipe> Recipes { get; private set; }

        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44320/api");               
                using var httpResponse =
                    await client.GetAsync("/Recipes/GetAll");
                if (httpResponse.IsSuccessStatusCode)
                {
                    using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                   Recipes = await JsonSerializer.DeserializeAsync<List<Domain.Models.Recipe>>(responseStream);                  
                }
            }
           
        }
    }
}
