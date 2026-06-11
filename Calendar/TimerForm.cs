using Calendar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class TimerForm : Form
    {
        public TimerForm()
        {
            InitializeComponent();
        }
        private TimerNode timer;
        private Monitor monitor;
        private Form1 mainForm;
        public HashSet<string> ActivatedTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public TimerForm(TimerNode t, Monitor mon, Form1 main)
        {
            InitializeComponent();
            timer = t;
            monitor = mon;
            mainForm = main;

            RefreshEventTypesList();

            RefreshLocalEventsList();
        }
        private void RefreshEventTypesList()
        {
            cmbEventTypes.Items.Clear();
            foreach (var kvp in monitor.EventTypes)
            {
                if (!timer.ActivatedTypes.Contains(kvp.Key))
                    cmbEventTypes.Items.Add(kvp.Key);
            }
            if (cmbEventTypes.Items.Count > 0) cmbEventTypes.SelectedIndex = 0;
        }

        private void RefreshLocalEventsList()
        {
            lstLocalEvents.Items.Clear();
            var arr = timer.DumpLocalEvents();
            for (int i = 0; i < arr.Length; i++)
                lstLocalEvents.Items.Add(arr[i]);
        }
        

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (cmbEventTypes.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип события.");
                return;
            }
            string typeName = cmbEventTypes.SelectedItem.ToString();

            double userTime = Convert.ToDouble(nudEventTime.Value);

            if (userTime < 0)
            {
                MessageBox.Show("Время не может быть отрицательным.");
                return;
            }

            double absTimerTime = monitor.UserLocalToAbsolute(timer, userTime);

            double localNow = timer.CurrentReading(monitor.SystemTime);

            double timerTimeForMessage = userTime;
            if (timerTimeForMessage <= localNow)
                timerTimeForMessage += 24.0;

            timer.AddEvent(typeName, absTimerTime);

            timer.ActivatedTypes.Add(typeName);

            RefreshEventTypesList();
            RefreshLocalEventsList();
            MessageBox.Show($"Запланировано: {FormatTimerTime(timerTimeForMessage)} — {typeName} (локальное время)");
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
        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            int idx = lstLocalEvents.SelectedIndex;
            if (idx < 0) return;

            int i = 0;
            var cur = timer.Head.Next;
            string removedType = null;
            while (cur != timer.Head)
            {
                if (i == idx)
                {
                    removedType = cur.TypeName;
                    timer.RemoveEvent(cur);
                    break;
                }
                i++; cur = cur.Next;
            }

            if (!string.IsNullOrEmpty(removedType))
            {
                bool stillExists = false;
                var scan = timer.Head.Next;
                while (scan != timer.Head)
                {
                    if (string.Equals(scan.TypeName, removedType, StringComparison.OrdinalIgnoreCase))
                    {
                        stillExists = true;
                        break;
                    }
                    scan = scan.Next;
                }
                if (!stillExists)
                    timer.ActivatedTypes.Remove(removedType);
            }

            RefreshEventTypesList();
            RefreshLocalEventsList();
        }

        private void TimerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.RefreshAllDisplays();
        }
    }
}
