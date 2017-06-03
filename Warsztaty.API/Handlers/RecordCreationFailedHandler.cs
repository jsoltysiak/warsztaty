using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warsztaty.Messages.Events;

namespace Warsztaty.API.Handlers
{
    public class RecordCreationFailedHandler : IEventHandler<RecordCreationFailed>
    {
        public async Task HandleAsync(RecordCreationFailed @event)
        {
            Console.WriteLine($"Record: '{@event.Key}' was not created." + 
                $"Reason: {@event.Reason}");
            await Task.CompletedTask;
        }
    }
}
