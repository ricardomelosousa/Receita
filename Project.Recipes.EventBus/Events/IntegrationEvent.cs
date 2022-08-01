using System.Text.Json.Serialization;

namespace Project.Recipes.EventBus.Events
{
    public record IntegrationEvent
    {
        public IntegrationEvent()
        {
            IntegrationId = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createDate)
        {
            IntegrationId = id;
            CreationDate = createDate;
        }

        [JsonInclude]
        public Guid IntegrationId { get; private init; }

        [JsonInclude]
        public DateTime CreationDate { get; private init; }
    }
}
