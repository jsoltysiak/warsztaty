using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warsztaty.API.Storage;
using Warsztaty.Messages.Events;

namespace Warsztaty.API.Handlers
{
    public class RecordCreatedHandler : IEventHandler<RecordCreated>
    {
        private readonly IStorage storage;

        public RecordCreatedHandler(IStorage storage)
        {
            this.storage = storage;
        }

        public async Task HandleAsync(RecordCreated @event)
        {
            Console.WriteLine($"Record: '{@event.Key}' was created.");
            storage.Add(@event.Key);
            await Task.CompletedTask;
        }
    }
}
