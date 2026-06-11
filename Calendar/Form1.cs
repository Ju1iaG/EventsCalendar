using Calendar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        private Monitor monitor;
        public Form1()
        {
            InitializeComponent();
            button1.MouseEnter += Button1_MouseEnter;
            button1.MouseLeave += Button1_MouseLeave;
            button1.Click += Button1_Click;
            monitor = new Monitor();

            pbClockSystem.Paint += pbClock_Paint;
            pbClockT1.Paint += pbClock_Paint;
            pbClockT2.Paint += pbClock_Paint;

            uiTimer.Start();
            RefreshAllDisplays();
        }

        ToolTip tip = new ToolTip();
        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            tip.Show("Аннотация", button1, 0, button1.Height, 2000);
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            tip.Hide(button1);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            int popupW = (int)(this.ClientSize.Width * 0.9);
            int popupH = (int)(this.ClientSize.Height * 0.9);

            Panel popupPanel = new Panel
            {
                Size = new Size(popupW, popupH),
                BorderStyle = BorderStyle.FixedSingle,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackgroundImage = Properties.Resources.fon_zvezdochki_lilovyy
            };

            Label title = new Label
            {
                Text = "Добро пожаловать в Симулятор Бога!",
                Font = new Font("Comic Sans MS", 20, FontStyle.Bold),
                ForeColor = Color.Gold,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 150,
                BackColor = Color.Transparent
            };
            popupPanel.Controls.Add(title);

            Label body = new Label
            {
                Text = "Управляйте событиями в трёх галактиках: выбирайте космические\nсобытия и наблюдайте, как оживает вселенная",
                Font = new Font("Comic Sans MS", 14, FontStyle.Regular),
                ForeColor = Color.LightGoldenrodYellow,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.Transparent
            };
            popupPanel.Controls.Add(body);

            FlowLayoutPanel bottom = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Bottom,
                Height = 48,
                Padding = new Padding(6),
                BackColor = Color.Transparent
            };

            Button btnClose = new Button { Text = "Закрыть", AutoSize = true };
            bottom.Controls.Add(btnClose);
            popupPanel.Controls.Add(bottom);

            ToolStripControlHost host = new ToolStripControlHost(popupPanel)
            {
                AutoSize = false,
                Size = popupPanel.Size,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            ToolStripDropDown drop = new ToolStripDropDown
            {
                Padding = Padding.Empty,
                AutoClose = true
            };
            drop.Items.Add(host);

            Point center = new Point(
                (this.ClientSize.Width - popupW) / 2,
                (this.ClientSize.Height - popupH) / 2
            );

            drop.Show(this, center, ToolStripDropDownDirection.BelowRight);

            btnClose.Click += (s, ev) => drop.Close();

            drop.Closed += (s, ev) =>
            {
                popupPanel.Dispose();
                host.Dispose();
            };
        }

        private void uiTimer_Tick(object sender, EventArgs e)
        {
            RefreshAllDisplays();
        }

        public void RefreshAllDisplays()
        {
            double displaySys = NormalizeTo24(monitor.SystemTimer.CurrentReading(monitor.SystemTime));
            lblSystemTime.Text = $"System: {FormatAsHHMM(displaySys)}";

            double displayT1 = NormalizeTo24(monitor.T1.CurrentReading(monitor.SystemTime));
            lblT1.Text = $"T1: {FormatAsHHMM(displayT1)}";

            double displayT2 = NormalizeTo24(monitor.T2.CurrentReading(monitor.SystemTime));
            lblT2.Text = $"T2: {FormatAsHHMM(displayT2)}";

            pbClockSystem.Invalidate();
            pbClockT1.Invalidate();
            pbClockT2.Invalidate();
        }
        private string FormatAsHHMM(double time)
        {
            int hours = (int)Math.Floor(time) % 24;
            if (hours < 0) hours += 24;
            double frac = time - Math.Floor(time);
            int minutes = (int)Math.Round(frac * 60.0);
            if (minutes >= 60) { minutes -= 60; hours = (hours + 1) % 24; }
            return $"{hours:D2}:{minutes:D2}";
        }
        private void pbClock_Paint(object sender, PaintEventArgs e)
        {
            var pb = sender as PictureBox;
            double timeValue = 0;
            if (pb == pbClockSystem) timeValue = monitor.SystemTimer.CurrentReading(monitor.SystemTime);
            else if (pb == pbClockT1) timeValue = monitor.T1.CurrentReading(monitor.SystemTime);
            else if (pb == pbClockT2) timeValue = monitor.T2.CurrentReading(monitor.SystemTime);

            DrawClock(e.Graphics, pb.ClientRectangle, timeValue);
        }

        private void DrawClock(Graphics g, Rectangle rect, double timeValue)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int cx = rect.Width / 2, cy = rect.Height / 2;
            int r = Math.Min(cx, cy) - 6;
            Rectangle circle = new Rectangle(rect.X + cx - r, rect.Y + cy - r, 2 * r, 2 * r);
            g.DrawEllipse(Pens.Black, circle);

            double display = NormalizeTo24(timeValue);

            int hoursRaw = (int)Math.Floor(display);
            int hours = ((hoursRaw % 12) + 12) % 12;
            double frac = display - Math.Floor(display);
            int minutes = (int)(frac * 60);

            double angleH = (hours + minutes / 60.0) * 30.0;
            double angleM = minutes * 6.0;

            DrawHand(g, cx + rect.X, cy + rect.Y, r * 0.5, angleH, 4);
            DrawHand(g, cx + rect.X, cy + rect.Y, r * 0.85, angleM, 2);

        }

        private void DrawHand(Graphics g, int cx, int cy, double length, double angleDeg, int thickness)
        {
            double rad = (Math.PI / 180.0) * (angleDeg - 90.0);
            int x = (int)(cx + length * Math.Cos(rad));
            int y = (int)(cy + length * Math.Sin(rad));
            using (var pen = new Pen(Color.Black, thickness)) g.DrawLine(pen, cx, cy, x, y);
        }

        private void btnOpenT0_Click(object sender, EventArgs e)
        {
            OpenTimerForm(monitor.SystemTimer);
        }

        private void btnOpenT1_Click(object sender, EventArgs e)
        {
            OpenTimerForm(monitor.T1);
        }

        private void btnOpenT2_Click(object sender, EventArgs e)
        {
            OpenTimerForm(monitor.T2);
        }
        private void OpenTimerForm(TimerNode t)
        {
            var tf = new TimerForm(t, monitor, this);
            tf.Show();
        }
        private void btnDigit_Click(object sender, EventArgs e)
        {
            using (var dlg = new DigitizeForm())
            {
                dlg.nudSystemTime.Value = (decimal)monitor.SystemTime;
                dlg.cmbOffsetT1.SelectedItem = ((int)Math.Round(monitor.T1.Offset)).ToString();
                dlg.cmbOffsetT2.SelectedItem = ((int)Math.Round(monitor.T2.Offset)).ToString();


                var res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    monitor.SystemTime = dlg.SelectedSystemTime;
                    monitor.T1.Offset = ((dlg.SelectedOffsetT1 % 24) + 24) % 24;
                    monitor.T2.Offset = ((dlg.SelectedOffsetT2 % 24) + 24) % 24;

                    RefreshAllDisplays();

                    MessageBox.Show($"Оцифровано: SystemTime={monitor.SystemTime}, T1.Offset={monitor.T1.Offset}, T2.Offset={monitor.T2.Offset}");
                }
            }
        }
        private void btnGlobal_Click(object sender, EventArgs e)
        {
            var gf = new GlobalForm(monitor);
            gf.Show();
        }

        private double NormalizeTo24(double time)
        {
            double v = time % 24.0;
            if (v < 0) v += 24.0;
            return v;
        }

        private async void btnRunInterval_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIntHour.Text, out int hours) || hours < 0)
            {
                MessageBox.Show("Введите корректные часы (0 или больше).");
                return;
            }

            if (!int.TryParse(txtIntMin.Text, out int minutes) || minutes < 0 || minutes > 59)
            {
                MessageBox.Show("Введите корректные минуты (0–59).");
                return;
            }
            double deltaLocal = hours + minutes / 60.0;

            await monitor.ProcessEventsForSystemInterval(deltaLocal, async (timer, ev, evSystemTime) =>
            {
                ShowImageForTimerEvent(timer, GetPictureBoxForTimer(timer), ev.TypeName);

                RefreshAllDisplays();

                await Task.Delay(600);
            });
            RefreshAllDisplays();
        }

        private PictureBox GetPictureBoxForTimer(TimerNode timer)
        {
            if (object.ReferenceEquals(timer, monitor.SystemTimer)) return picStateSystem;
            if (object.ReferenceEquals(timer, monitor.T1)) return picStateT1;
            return picStateT2;
        }

        private void ShowImageForTimerEvent(TimerNode timer, PictureBox pic, string typeName)
        {
            try
            {
                if (timer.EventImageMap != null && timer.EventImageMap.TryGetValue(typeName, out string path) && !string.IsNullOrWhiteSpace(path))
                {
                    var old = pic.Image;
                    using (var original = Image.FromFile(path))
                    {
                        pic.Image = SetImageFit(original, pic.Width, pic.Height);
                    }
                    old?.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Show image error: " + ex.Message);
            }
        }

        private Image SetImageFit(Image src, int boxWidth, int boxHeight)
        {
            if (src == null) return null;

            float scale = Math.Min((float)boxWidth / src.Width, (float)boxHeight / src.Height);

            int w = (int)(src.Width * scale);
            int h = (int)(src.Height * scale);

            Bitmap bmp = new Bitmap(boxWidth, boxHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                int x = (boxWidth - w) / 2;
                int y = (boxHeight - h) / 2;
                g.DrawImage(src, x, y, w, h);
            }

            return bmp;
        }


    }
}
