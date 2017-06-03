using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warsztaty.Messages.Events;

namespace Warsztaty.API.Handlers
{
    public class RecordCreatedHandler : IEventHandler<RecordCreated>
    {
        public async Task HandleAsync(RecordCreated @event)
        {
            Console.WriteLine($"Record: '{@event.Key}' was created.");
            await Task.CompletedTask;
        }
    }
}
