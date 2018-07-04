using System.Threading.Tasks;
using Crayons.Communication.Events.Interfaces;

namespace Crayons.Service.EventHandlers.Interfaces
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task Handle(T @event);
    }
}