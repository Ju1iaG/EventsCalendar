using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class Monitor
    {
        public TimerNode SystemTimer { get; private set; }
        public TimerNode T1 { get; private set; }
        public TimerNode T2 { get; private set; }
        public double SystemTime { get; set; } = 0.0;
        
        public Dictionary<string, EventType> EventTypes = new Dictionary<string, EventType>(StringComparer.OrdinalIgnoreCase);

        public Monitor()
        {
            SystemTimer = new TimerNode("System", 0.0);
            T1 = new TimerNode("T1", 3.0); 
            T2 = new TimerNode("T2", -2.0);

            EventTypes["Звездопад"] = new EventType("Звездопад", 0.6, "..\\..\\Resources\\Zvezdopad.jpg");
            EventTypes["Затмение"] = new EventType("Затмение", 0.1, "..\\..\\Resources\\Zatmenie.jpg");
            EventTypes["Столкновение нейтронных звёзд"] = new EventType("Столкновение нейтронных звёзд", 0.05, "..\\..\\Resources\\StolknovenieNeitronnihZvezd.jpg");
            EventTypes["Образование пульсара"] = new EventType("Образование пульсара", 0.07, "..\\..\\Resources\\Pulsar.jpg");
            EventTypes["Полёт кометы"] = new EventType("Полёт кометы", 0.4, "..\\..\\Resources\\Kometa.jpg");
            EventTypes["Коллапс сверхновой звезды"] = new EventType("Коллапс сверхновой звезды", 0.09, "..\\..\\Resources\\KollapsSverhnovoi.jpg");
            EventTypes["Образование чёрной дыры"] = new EventType("Образование чёрной дыры", 0.03, "..\\..\\Resources\\BlackHole.jpg");

            foreach (var kv in EventTypes)
            {
                SystemTimer.EventImageMap[kv.Key] = kv.Value.ImagePath;
                T1.EventImageMap[kv.Key] = kv.Value.ImagePath;
                T2.EventImageMap[kv.Key] = kv.Value.ImagePath;
            }
        }

        public TimerNode[] GetAllTimers()
        {
            return new TimerNode[] { SystemTimer, T1, T2 };
        }

        public bool RegisterEventType(string name, double lambda, string imagePath)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (EventTypes.ContainsKey(name)) return false; 
            var et = new EventType(name, lambda, imagePath);
            EventTypes[name] = et;
            SystemTimer.EventImageMap[name] = imagePath;
            T1.EventImageMap[name] = imagePath;
            T2.EventImageMap[name] = imagePath;
            return true;
        }

        public void ScheduleFirstForTimer(string typeName, TimerNode timer)
        {
            if (!EventTypes.TryGetValue(typeName, out var et)) return;
            double localNow = timer.CurrentReading(SystemTime);
            double dt = et.NextInterval();
            double newTimerTime = localNow + dt;
            timer.AddEvent(typeName, newTimerTime);
        }

        public void ProduceNextOccurrence(EventNode ev, TimerNode timer)
        {
            if (!EventTypes.TryGetValue(ev.TypeName, out var et)) return;
            double dt = et.NextInterval();
            double nextTimerTime = ev.TimerTime + dt;
            timer.AddEvent(ev.TypeName, nextTimerTime);
        }

        public struct GlobalEventEntry { public string TimerName; public string TypeName; public double TimerTime; public double SystemTime; }

        public GlobalEventEntry[] BuildGlobalCalendarSnapshot()
        {
            TimerNode[] arr = GetAllTimers();
            int total = 0;
            for (int i = 0; i < arr.Length; i++) total += arr[i].CountEvents();
            if (total == 0) return new GlobalEventEntry[0];

            var outArr = new GlobalEventEntry[total];
            int idx = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var t = arr[i];
                EventNode cur = t.Head.Next;
                while (cur != t.Head)
                {
                    double sysAbs = cur.TimerTime - t.Offset; 

                    double sysDisplay = sysAbs % 24.0;
                    if (sysDisplay < 0) sysDisplay += 24.0;

                    double timerDisplay = cur.TimerTime % 24.0;
                    if (timerDisplay < 0) timerDisplay += 24.0;

                    outArr[idx++] = new GlobalEventEntry
                    {
                        TimerName = t.Name,
                        TypeName = cur.TypeName,
                        TimerTime = timerDisplay,  
                        SystemTime = sysDisplay    
                    };
                    cur = cur.Next;
                }
            }

            for (int i = 0; i < outArr.Length - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < outArr.Length; j++)
                {
                    if (outArr[j].SystemTime < outArr[minIdx].SystemTime) minIdx = j;
                }
                if (minIdx != i)
                {
                    var tmp = outArr[i];
                    outArr[i] = outArr[minIdx];
                    outArr[minIdx] = tmp;
                }
            }

            return outArr;
        }

        public bool TryPopNextGlobalEvent(out TimerNode timerOut, out EventNode eventOut)
        {
            timerOut = null;
            eventOut = null;

            double bestAdjSystemTime = double.PositiveInfinity;
            TimerNode bestTimer = null;
            EventNode bestNode = null;

            foreach (var t in GetAllTimers())
            {
                if (t == null || t.Head == null) continue;

                EventNode node = t.Head.Next;
                if (node == null || node == t.Head) continue;

                double rawSys = node.TimerTime - t.Offset;
                double adj = rawSys;
                if (adj < SystemTime)
                {
                    double shiftDays = Math.Ceiling((SystemTime - adj) / 24.0);
                    adj += shiftDays * 24.0;
                }

                if (adj < bestAdjSystemTime)
                {
                    bestAdjSystemTime = adj;
                    bestTimer = t;
                    bestNode = node;
                }
            }

            if (bestNode != null)
            {
                timerOut = bestTimer;
                eventOut = bestNode;
                return true;
            }

            return false;
        }

        public async Task ProcessEventsForSystemInterval(double deltaSystem, Func<TimerNode, EventNode, double, Task> onEventAsync)
        {
            if (deltaSystem <= 0) return;

            double endSystemTime = SystemTime + deltaSystem;

            while (true)
            {
                TimerNode timer; EventNode ev;
                if (!TryPopNextGlobalEvent(out timer, out ev)) break;

                double evSystemAbs = ev.TimerTime - timer.Offset;
                double k = Math.Ceiling((SystemTime - evSystemAbs) / 24.0);
                double evSystemAdj = evSystemAbs + k * 24.0;

                if (evSystemAbs < SystemTime)
                {
                    double shift = Math.Ceiling((SystemTime - evSystemAbs) / 24.0) * 24.0;
                    evSystemAbs += shift;
                }
                if (evSystemAdj > endSystemTime) break;

                timer.RemoveEvent(ev);

                if (onEventAsync != null)
                    await onEventAsync(timer, ev, evSystemAdj);

                ProduceNextOccurrence(ev, timer);
            }
            SystemTime = endSystemTime;
        }

        public double UserLocalToAbsolute(TimerNode timer, double userLocalTime)
        {
            double localNow = timer.CurrentReading(SystemTime); 
            double baseDay = Math.Floor(localNow / 24.0) * 24.0;
            double candidate = baseDay + userLocalTime;
            if (candidate <= localNow + 1e-9)
            {
                double k = Math.Ceiling((localNow + 1e-9 - candidate) / 24.0);
                candidate += k * 24.0;
            }
            if (candidate < 0)
            {
                double k2 = Math.Ceiling((-candidate) / 24.0);
                candidate += k2 * 24.0;
            }

            return candidate;
        }
        private double NormalizeTo24(double time)
        {
            double v = time % 24.0;
            if (v < 0) v += 24.0;
            return v;
        }
    }
}
