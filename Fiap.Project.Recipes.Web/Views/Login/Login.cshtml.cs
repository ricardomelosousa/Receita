using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Project.Recipes.Web.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Recipes.Web.Views.Login
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public LoginViewModel Login { get; set; }
        public IActionResult OnGet()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToPage("/Home/Index");
            }
            return this.Page();
        }

        public async Task<IActionResult> OnPostLogIn()
        {

            // Verification.  
            if (ModelState.IsValid)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44320/api/");
                    var login = new StringContent(
                                          JsonSerializer.Serialize(Login),
                                          Encoding.UTF8,
                                          "application/json");
                    using var httpResponse =
                        await client.PostAsync("/Users/authenticate", login);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                        var autheticationResponse = await JsonSerializer.DeserializeAsync<AuthenticateResponse>(responseStream);
                        await SignInUser(autheticationResponse, true);
                      
                        return this.RedirectToPage("/Home/Index", autheticationResponse);
                    }
                }
                return null;
            }
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return this.Page();

        }


        private async Task SignInUser(AuthenticateResponse authenticateResponse, bool isPersistent)
        {
            // Initialization.  
            var claims = new List<Claim>();

            try
            {
               
                   
                   
                
                // Setting  
                claims.Add(new Claim(ClaimTypes.Name, authenticateResponse.Name));
                claims.Add(new Claim("AcessToken", string.Format("{0}", authenticateResponse.Token)));               
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

               


                // Sign In.  
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }


    }
}
