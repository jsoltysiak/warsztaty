using System;
using System.Collections.Generic;
using System.Text;

namespace Warsztaty.Messages.Events
{
    class RecordCreationFailed : IEvent
    {
        public string Key { get; }
        public string Reason { get; }

        protected RecordCreationFailed()
        {
        }

        public RecordCreationFailed(string key, string reason)
        {
            Key = key;
            Reason = reason;
        }
    }
}
