namespace Project.Recipes.EventBus.Events.EventHandling
{
    public class RecipeEventHandler : IIntegrationEventHandler<RecipeIntegrationEvent>
    {
        private readonly ILogger<RecipeEventHandler> _logger;

        private readonly IServiceProvider _serviceProvider;
        public RecipeEventHandler(ILogger<RecipeEventHandler> logger, IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task Handle(RecipeIntegrationEvent intEvent)
        {
            //using (var scope = _serviceProvider.CreateScope())
            //{
            //    var recipeAppService = scope.ServiceProvider.GetRequiredService<RecipeAppService>();
            //    //recipeAppService.Add(intEvent);
            //}       
            //_logger.LogInformation("----- Handling integration event: {receita} - ({@IntegrationEvent})", intEvent.Id, intEvent);
            await Task.CompletedTask;
        }
       
    }
}
