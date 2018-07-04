using Crayons.Communication.Events.Interfaces;

namespace Crayons.Api.EventDispatchers.Interfaces
{
    public interface IEventDispatcher<T> where T : IEvent
    {
        void Dispatch(T @event);
    }
}