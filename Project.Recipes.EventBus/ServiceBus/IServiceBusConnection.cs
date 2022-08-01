using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace Project.Recipes.EventBus.ServiceBus
{
    public interface IServiceBusConnection : IDisposable
    {
        ServiceBusClient QueueClient { get; }
        ServiceBusAdministrationClient AdministrationClient { get; }

    }
}
