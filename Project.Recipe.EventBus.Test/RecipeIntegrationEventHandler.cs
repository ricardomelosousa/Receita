using Project.Recipes.EventBus.Base;
using System.Threading.Tasks;

namespace Project.Recipe.EventBus.Test
{
    public class RecipeIntegrationEventHandler : IIntegrationEventHandler<RecipeIntegrationEvent>
    {
        public bool Handled { get; private set; }

        public RecipeIntegrationEventHandler()
        {
            Handled = false;
        }

        public async Task Handle(RecipeIntegrationEvent @event)
        {
            Handled = true;
        }
    }
}
