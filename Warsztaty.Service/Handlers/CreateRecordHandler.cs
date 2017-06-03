using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RawRabbit;
using Warsztaty.Messages.Commands;
using Warsztaty.Messages.Events;

namespace Warsztaty.Service.Handlers
{
    public class CreateRecordHandler : ICommandHandler<CreateRecord>
    {
        private readonly IBusClient _busClient;

        public CreateRecordHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(CreateRecord command)
        {
            Console.WriteLine($"Received create record: '{command.Key}'");

            if (string.IsNullOrWhiteSpace(command.Key))
            {
                await _busClient.PublishAsync(new RecordCreationFailed(command.Key, "Record key can not be empty"));
                return;
            }
            await _busClient.PublishAsync(new RecordCreated(command.Key));
        }
    }
}
