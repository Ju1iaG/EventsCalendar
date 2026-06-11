using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class EventNode
    {
        public string TypeName;
        public double TimerTime;
        public EventNode Next;
        public EventNode Prev;

        public EventNode() { } 
        public EventNode(string typeName, double timerTime)
        {
            TypeName = typeName;
            TimerTime = timerTime;
        }
    }
}
