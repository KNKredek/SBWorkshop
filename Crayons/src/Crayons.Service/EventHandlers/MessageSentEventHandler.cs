using System;
using System.Threading.Tasks;
using Crayons.Communication.Events;
using Crayons.Service.EventHandlers.Interfaces;

namespace Crayons.Service.EventHandlers
{
    public class MessageSentEventHandler : IEventHandler<MessageSentEvent>
    {
        public Task Handle(MessageSentEvent @event)
        {
            System.Console.WriteLine("There was a message!");
            System.Console.WriteLine($"Body:{@event.Message}");
            System.Console.WriteLine($"SendDate:{@event.SendDate}");
            System.Console.WriteLine($"HandleDate:{DateTime.Now}");
            System.Console.WriteLine("");
            return Task.CompletedTask;
        }
    }
}