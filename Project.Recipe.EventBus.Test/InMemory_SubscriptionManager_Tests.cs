using Project.Recipes.EventBus;
using System.Linq;
using Xunit;

namespace Project.Recipe.EventBus.Test
{
    public class InMemory_SubscriptionManager_Tests
    {
        [Fact]
        public void After_Creation_Should_Be_Empty()
        {
            var manager = new InMemoryEventBusSubscriptionsManager();
            Assert.True(manager.IsEmpty);
        }

        [Fact]
        public void After_One_Event_Subscription_Should_Contain_The_Event()
        {
            var manager = new InMemoryEventBusSubscriptionsManager();
            manager.AddSubscription<RecipeIntegrationEvent,RecipeIntegrationEventHandler>();
            Assert.True(manager.HasSubscriptionsForEvent<RecipeIntegrationEvent>());
        }

        [Fact]
        public void After_All_Subscriptions_Are_Deleted_Event_Should_No_Longer_Exists()
        {
            var manager = new InMemoryEventBusSubscriptionsManager();
            manager.AddSubscription<RecipeIntegrationEvent, RecipeIntegrationEventHandler>();
            manager.RemoveSubscription<RecipeIntegrationEvent, RecipeIntegrationEventHandler>();
            Assert.False(manager.HasSubscriptionsForEvent<RecipeIntegrationEvent>());
        }

        [Fact]
        public void Deleting_Last_Subscription_Should_Raise_On_Deleted_Event()
        {
            bool raised = false;
            var manager = new InMemoryEventBusSubscriptionsManager();
            manager.OnEventRemoved += (o, e) => raised = true;
            manager.AddSubscription<RecipeIntegrationEvent, RecipeIntegrationEventHandler>();
            manager.RemoveSubscription<RecipeIntegrationEvent, RecipeIntegrationEventHandler>();
            Assert.True(raised);
        }

        [Fact]
        public void Get_Handlers_For_Event_Should_Return_All_Handlers()
        {
            var manager = new InMemoryEventBusSubscriptionsManager();
            manager.AddSubscription<RecipeIntegrationEvent, RecipeIntegrationEventHandler>();
            manager.AddSubscription<RecipeIntegrationEvent, RecipeIntegrationOtherEventHandler>();
            var handlers = manager.GetHandlersForEvent<RecipeIntegrationEvent>();
            Assert.Equal(2, handlers.Count());
        }

    }
}
