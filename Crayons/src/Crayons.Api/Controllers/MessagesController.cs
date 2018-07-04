using System;
using Crayons.Api.EventDispatchers.Interfaces;
using Crayons.Api.Requests;
using Crayons.Communication.Events;
using Microsoft.AspNetCore.Mvc;

namespace Crayons.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private IEventDispatcher<MessageSentEvent> _messageSentEventDispatcher;
        public MessagesController(IEventDispatcher<MessageSentEvent> messageSentEventDispatcher)
        {
            _messageSentEventDispatcher = messageSentEventDispatcher;
        }

        [HttpPost]
        public IActionResult Post([FromBody]AddMessageRequest request)
        {
            var messageSentEvent = new MessageSentEvent()
            {
                Message = request.Message,
                SendDate = DateTime.Now
            };

            _messageSentEventDispatcher.Dispatch(messageSentEvent);

            return Ok();
        }
    }
}