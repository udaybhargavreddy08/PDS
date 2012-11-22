using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;
using PDS.DataLayer;

namespace PDS.BusinessLayer
{
    public class QueueManager
    {
        public QueueSnapshot GetQueueInformation(int QueueId)
        {
            return new FillRepository().GetQueueSnapShot(QueueId);

        }
    }
}
