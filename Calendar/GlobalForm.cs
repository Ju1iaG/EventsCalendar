using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar.Model;

namespace Calendar
{
    public partial class GlobalForm : Form
    {
        private Monitor monitor;
        public GlobalForm(Monitor mon)
        {
            InitializeComponent();
            monitor = mon;
            btnRefreshGlobal.Click += btnRefreshGlobal_Click;
            RefreshGrid();
        }
        private void btnRefreshGlobal_Click(object sender, EventArgs e) => RefreshGrid();

        private void RefreshGrid()
        {
            dgvGlobal.Rows.Clear();
            var snap = monitor.BuildGlobalCalendarSnapshot();
            for (int i = 0; i < snap.Length; i++)
            {
                var eN = snap[i];
                dgvGlobal.Rows.Add(i, eN.TimerName, eN.TypeName, eN.TimerTime.ToString("0.###"), eN.SystemTime.ToString("0.###"));
            }
        }
    }
}
