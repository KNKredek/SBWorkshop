using Crayons.Api.EventDispatchers.Interfaces;
using Crayons.Communication.Events;
using RawRabbit;

namespace Crayons.Api.EventDispatchers
{
    public class MessageSentEventDispatcher : IEventDispatcher<MessageSentEvent>
    {
        private IBusClient _client;
        public MessageSentEventDispatcher(IBusClient client)
        {
            _client = client;
        }
        public void Dispatch(MessageSentEvent @event)
        {
            _client.PublishAsync(@event);
        }
    }
}