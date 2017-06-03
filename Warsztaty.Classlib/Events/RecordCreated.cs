using System;
using System.Collections.Generic;
using System.Text;

namespace Warsztaty.Messages.Events
{
    public class RecordCreated : IEvent
    {
        public string Key { get; }

        protected RecordCreated()
        {
        }

        public RecordCreated(string key)
        {
            Key = key;
        }
    }
}
