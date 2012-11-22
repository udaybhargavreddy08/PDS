using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDS.DomainModel
{
    public class QueueSnapshot
    {
        public List<PDSQueue> Queues { get; set; }

        public List<Fill> SelectedQueueFills { get; set; }
    }
}
