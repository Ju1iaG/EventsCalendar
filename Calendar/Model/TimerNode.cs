using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class TimerNode
    {
        public string Name { get; private set; }
        public double Offset { get; set; }
        public EventNode Head;
        public Dictionary<string, string> EventImageMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public HashSet<string> ActivatedTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);


        public TimerNode(string name, double offset = 0.0)
        {
            Name = name;
            Offset = offset;
            Head = new EventNode();
            Head.Next = Head;
            Head.Prev = Head;
        }

        public double CurrentReading(double systemTime) => systemTime + Offset;

        public void AddEvent(string typeName, double timerTime)
        {
            if (timerTime < 0)
            {
                double k = Math.Ceiling((-timerTime) / 24.0);
                timerTime += k * 24.0;
            }
            var node = new EventNode(typeName, timerTime);
            if (Head.Next == Head)
            {
                node.Next = Head;
                node.Prev = Head;
                Head.Next = node;
                Head.Prev = node;
                return;
            }
            EventNode cur = Head.Next;
            while (cur != Head && cur.TimerTime < timerTime) cur = cur.Next;
            node.Next = cur;
            node.Prev = cur.Prev;
            cur.Prev.Next = node;
            cur.Prev = node;
        }

        public void RemoveEvent(EventNode node)
        {
            if (node == null || node == Head) return;
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        public int CountEvents()
        {
            int c = 0;
            EventNode cur = Head.Next;
            while (cur != Head) { c++; cur = cur.Next; }
            return c;
        }

        public EventNode[] CollectEventsInLocalRange(double fromExclusive, double toInclusive)
        {
            int cnt = 0;
            EventNode cur = Head.Next;
            while (cur != Head)
            {
                if (cur.TimerTime > fromExclusive && cur.TimerTime <= toInclusive) cnt++;
                cur = cur.Next;
            }
            if (cnt == 0) return new EventNode[0];
            var arr = new EventNode[cnt];
            int i = 0;
            cur = Head.Next;
            while (cur != Head)
            {
                if (cur.TimerTime > fromExclusive && cur.TimerTime <= toInclusive)
                    arr[i++] = cur;
                cur = cur.Next;
            }
            return arr;
        }

        public string[] DumpLocalEvents()
        {
            int c = CountEvents();
            if (c == 0) return new string[0];
            string[] res = new string[c];
            int i = 0;
            EventNode cur = Head.Next;
            while (cur != Head)
            {
                res[i++] = $"{cur.TypeName} — {FormatTimerTime(cur.TimerTime)}";
                cur = cur.Next;
            }
            return res;
        }

        private string FormatTimerTime(double timerTime)
        {
            int hours = (int)Math.Floor(timerTime);
            hours = ((hours % 24) + 24) % 24;

            double frac = timerTime - Math.Floor(timerTime);
            int minutes = (int)Math.Round(frac * 60.0);

            if (minutes >= 60)
            {
                minutes -= 60;
                hours = (hours + 1) % 24;
            }

            return $"{hours:D2}:{minutes:D2}";
        }
    }
}
