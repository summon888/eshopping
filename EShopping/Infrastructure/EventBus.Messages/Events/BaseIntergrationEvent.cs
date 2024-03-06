using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class BaseIntergrationEvent
    {
        //CO-Relation Id
        public Guid Id { get; set; }
        public DateTime CreationDate { get; private set; }

        public BaseIntergrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public BaseIntergrationEvent(Guid id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;
        }


    }
}
