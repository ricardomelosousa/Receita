

namespace Project.Recipes.EventBus
{
    public record RecipeIntegrationEvent : IntegrationEvent
    {
        public int Id { get; set; }
      
        public string Titulo { get; set; }
        public string Descricao { get; set; }
       
        public string Ingredientes { get; set; }
       
        public string Preparo { get; set; }
        public string Imagem { get; set; }
        public string Tags { get; set; }
        public int CategoryId { get; set; }       
        public DateTime DataInclusao { get; set; }
    }

 
}
