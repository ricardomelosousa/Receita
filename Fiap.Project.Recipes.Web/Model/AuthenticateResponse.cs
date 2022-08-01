namespace Project.Recipes.Web.Model
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }     
        public string Email { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }      
    }
}
