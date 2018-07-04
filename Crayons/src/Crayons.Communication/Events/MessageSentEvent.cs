using System;
using Crayons.Communication.Events.Interfaces;

namespace Crayons.Communication.Events
{
    public class MessageSentEvent : IEvent
    {
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}