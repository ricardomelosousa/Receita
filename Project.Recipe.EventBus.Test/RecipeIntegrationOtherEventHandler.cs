using Project.Recipes.EventBus.Base;
using System.Threading.Tasks;

namespace Project.Recipe.EventBus.Test
{
    public class RecipeIntegrationOtherEventHandler : IIntegrationEventHandler<RecipeIntegrationEvent>
    {
        public bool Handled { get; private set; }

        public RecipeIntegrationOtherEventHandler()
        {
            Handled = false;
        }

        public async Task Handle(RecipeIntegrationEvent @event)
        {
            Handled = true;
        }
    }
}
