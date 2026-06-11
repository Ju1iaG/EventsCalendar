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
    public partial class DigitizeForm : Form
    {
        public DigitizeForm()
        {
            InitializeComponent();
            InitControls();
        }

        public double SelectedSystemTime { get; set; }
        public int SelectedOffsetT1 { get; set; }
        public int SelectedOffsetT2 { get; set; }

        public void InitControls()
        {
            nudSystemTime.Minimum = 0;
            nudSystemTime.Maximum = 23;
            nudSystemTime.DecimalPlaces = 0;
            nudSystemTime.Increment = 1;

            cmbOffsetT1.Items.Clear();
            cmbOffsetT2.Items.Clear();
            for (int h = -23; h <= 23; h++)
            {
                cmbOffsetT1.Items.Add(h.ToString());
                cmbOffsetT2.Items.Add(h.ToString());
            }
            cmbOffsetT1.SelectedItem = "0";
            cmbOffsetT2.SelectedItem = "0";

            btnOK.Click += BtnOK_Click;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        public void BtnOK_Click(object sender, EventArgs e)
        {
            SelectedSystemTime = Convert.ToDouble(nudSystemTime.Value);
            if (cmbOffsetT1.SelectedItem == null || cmbOffsetT2.SelectedItem == null)
            {
                MessageBox.Show("Выберите смещения для обоих таймеров.");
                return;
            }
            SelectedOffsetT1 = int.Parse(cmbOffsetT1.SelectedItem.ToString());
            SelectedOffsetT2 = int.Parse(cmbOffsetT2.SelectedItem.ToString());

            this.DialogResult = DialogResult.OK;
        }
    }

}
