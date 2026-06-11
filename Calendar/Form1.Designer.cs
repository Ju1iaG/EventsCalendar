namespace Calendar
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbClockT2 = new System.Windows.Forms.PictureBox();
            this.pbClockSystem = new System.Windows.Forms.PictureBox();
            this.pbClockT1 = new System.Windows.Forms.PictureBox();
            this.btnDigit = new System.Windows.Forms.Button();
            this.btnOpenT2 = new System.Windows.Forms.Button();
            this.btnOpenT0 = new System.Windows.Forms.Button();
            this.btnOpenT1 = new System.Windows.Forms.Button();
            this.btnRunInterval = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIntHour = new System.Windows.Forms.TextBox();
            this.picStateT2 = new System.Windows.Forms.PictureBox();
            this.picStateSystem = new System.Windows.Forms.PictureBox();
            this.picStateT1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGlobal = new System.Windows.Forms.Button();
            this.uiTimer = new System.Windows.Forms.Timer(this.components);
            this.lblSystemTime = new System.Windows.Forms.Label();
            this.lblT1 = new System.Windows.Forms.Label();
            this.lblT2 = new System.Windows.Forms.Label();
            this.txtIntMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbClockT2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClockSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClockT1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStateT2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStateSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStateT1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbClockT2
            // 
            this.pbClockT2.Location = new System.Drawing.Point(834, 322);
            this.pbClockT2.Name = "pbClockT2";
            this.pbClockT2.Size = new System.Drawing.Size(237, 199);
            this.pbClockT2.TabIndex = 33;
            this.pbClockT2.TabStop = false;
            // 
            // pbClockSystem
            // 
            this.pbClockSystem.Location = new System.Drawing.Point(475, 322);
            this.pbClockSystem.Name = "pbClockSystem";
            this.pbClockSystem.Size = new System.Drawing.Size(237, 199);
            this.pbClockSystem.TabIndex = 32;
            this.pbClockSystem.TabStop = false;
            // 
            // pbClockT1
            // 
            this.pbClockT1.Location = new System.Drawing.Point(128, 322);
            this.pbClockT1.Name = "pbClockT1";
            this.pbClockT1.Size = new System.Drawing.Size(237, 199);
            this.pbClockT1.TabIndex = 31;
            this.pbClockT1.TabStop = false;
            // 
            // btnDigit
            // 
            this.btnDigit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDigit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDigit.ForeColor = System.Drawing.Color.Cyan;
            this.btnDigit.Location = new System.Drawing.Point(475, 12);
            this.btnDigit.Name = "btnDigit";
            this.btnDigit.Size = new System.Drawing.Size(237, 40);
            this.btnDigit.TabIndex = 30;
            this.btnDigit.Text = "Оцифровать";
            this.btnDigit.UseVisualStyleBackColor = false;
            this.btnDigit.Click += new System.EventHandler(this.btnDigit_Click);
            // 
            // btnOpenT2
            // 
            this.btnOpenT2.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnOpenT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenT2.ForeColor = System.Drawing.Color.Cyan;
            this.btnOpenT2.Location = new System.Drawing.Point(834, 527);
            this.btnOpenT2.Name = "btnOpenT2";
            this.btnOpenT2.Size = new System.Drawing.Size(237, 42);
            this.btnOpenT2.TabIndex = 29;
            this.btnOpenT2.Text = "Галактика Живописец";
            this.btnOpenT2.UseVisualStyleBackColor = false;
            this.btnOpenT2.Click += new System.EventHandler(this.btnOpenT2_Click);
            // 
            // btnOpenT0
            // 
            this.btnOpenT0.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnOpenT0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenT0.ForeColor = System.Drawing.Color.Cyan;
            this.btnOpenT0.Location = new System.Drawing.Point(475, 527);
            this.btnOpenT0.Name = "btnOpenT0";
            this.btnOpenT0.Size = new System.Drawing.Size(237, 42);
            this.btnOpenT0.TabIndex = 28;
            this.btnOpenT0.Text = "Галактика Чёрный Глаз";
            this.btnOpenT0.UseVisualStyleBackColor = false;
            this.btnOpenT0.Click += new System.EventHandler(this.btnOpenT0_Click);
            // 
            // btnOpenT1
            // 
            this.btnOpenT1.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnOpenT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenT1.ForeColor = System.Drawing.Color.Cyan;
            this.btnOpenT1.Location = new System.Drawing.Point(128, 527);
            this.btnOpenT1.Name = "btnOpenT1";
            this.btnOpenT1.Size = new System.Drawing.Size(237, 42);
            this.btnOpenT1.TabIndex = 27;
            this.btnOpenT1.Text = "Галактика Кондор";
            this.btnOpenT1.UseVisualStyleBackColor = false;
            this.btnOpenT1.Click += new System.EventHandler(this.btnOpenT1_Click);
            // 
            // btnRunInterval
            // 
            this.btnRunInterval.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRunInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRunInterval.ForeColor = System.Drawing.Color.Cyan;
            this.btnRunInterval.Location = new System.Drawing.Point(475, 642);
            this.btnRunInterval.Name = "btnRunInterval";
            this.btnRunInterval.Size = new System.Drawing.Size(237, 42);
            this.btnRunInterval.TabIndex = 26;
            this.btnRunInterval.Text = "Запустить";
            this.btnRunInterval.UseVisualStyleBackColor = false;
            this.btnRunInterval.Click += new System.EventHandler(this.btnRunInterval_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 596);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Задать интервал";
            // 
            // txtIntHour
            // 
            this.txtIntHour.Location = new System.Drawing.Point(590, 593);
            this.txtIntHour.Name = "txtIntHour";
            this.txtIntHour.Size = new System.Drawing.Size(70, 26);
            this.txtIntHour.TabIndex = 24;
            // 
            // picStateT2
            // 
            this.picStateT2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picStateT2.Location = new System.Drawing.Point(834, 76);
            this.picStateT2.Name = "picStateT2";
            this.picStateT2.Size = new System.Drawing.Size(237, 199);
            this.picStateT2.TabIndex = 23;
            this.picStateT2.TabStop = false;
            // 
            // picStateSystem
            // 
            this.picStateSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picStateSystem.Location = new System.Drawing.Point(475, 76);
            this.picStateSystem.Name = "picStateSystem";
            this.picStateSystem.Size = new System.Drawing.Size(237, 199);
            this.picStateSystem.TabIndex = 22;
            this.picStateSystem.TabStop = false;
            // 
            // picStateT1
            // 
            this.picStateT1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picStateT1.Location = new System.Drawing.Point(128, 76);
            this.picStateT1.Name = "picStateT1";
            this.picStateT1.Size = new System.Drawing.Size(237, 199);
            this.picStateT1.TabIndex = 21;
            this.picStateT1.TabStop = false;
            this.picStateT1.WaitOnLoad = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Gold;
            this.button1.Location = new System.Drawing.Point(2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 20;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnGlobal
            // 
            this.btnGlobal.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGlobal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGlobal.ForeColor = System.Drawing.Color.Cyan;
            this.btnGlobal.Location = new System.Drawing.Point(834, 12);
            this.btnGlobal.Name = "btnGlobal";
            this.btnGlobal.Size = new System.Drawing.Size(346, 40);
            this.btnGlobal.TabIndex = 34;
            this.btnGlobal.Text = "Посмотреть глобальный календарь";
            this.btnGlobal.UseVisualStyleBackColor = false;
            this.btnGlobal.Click += new System.EventHandler(this.btnGlobal_Click);
            // 
            // uiTimer
            // 
            this.uiTimer.Enabled = true;
            this.uiTimer.Interval = 300;
            this.uiTimer.Tick += new System.EventHandler(this.uiTimer_Tick);
            // 
            // lblSystemTime
            // 
            this.lblSystemTime.AutoSize = true;
            this.lblSystemTime.Location = new System.Drawing.Point(471, 299);
            this.lblSystemTime.Name = "lblSystemTime";
            this.lblSystemTime.Size = new System.Drawing.Size(58, 20);
            this.lblSystemTime.TabIndex = 35;
            this.lblSystemTime.Text = "Время";
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Location = new System.Drawing.Point(124, 299);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(58, 20);
            this.lblT1.TabIndex = 36;
            this.lblT1.Text = "Время";
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.Location = new System.Drawing.Point(830, 299);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(58, 20);
            this.lblT2.TabIndex = 37;
            this.lblT2.Text = "Время";
            // 
            // txtIntMin
            // 
            this.txtIntMin.Location = new System.Drawing.Point(686, 593);
            this.txtIntMin.Name = "txtIntMin";
            this.txtIntMin.Size = new System.Drawing.Size(69, 26);
            this.txtIntMin.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Wide Latin", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(666, 596);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 19);
            this.label2.TabIndex = 39;
            this.label2.Text = ":";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1184, 706);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIntMin);
            this.Controls.Add(this.lblT2);
            this.Controls.Add(this.lblT1);
            this.Controls.Add(this.lblSystemTime);
            this.Controls.Add(this.btnGlobal);
            this.Controls.Add(this.pbClockT2);
            this.Controls.Add(this.pbClockSystem);
            this.Controls.Add(this.pbClockT1);
            this.Controls.Add(this.btnDigit);
            this.Controls.Add(this.btnOpenT2);
            this.Controls.Add(this.btnOpenT0);
            this.Controls.Add(this.btnOpenT1);
            this.Controls.Add(this.btnRunInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIntHour);
            this.Controls.Add(this.picStateT2);
            this.Controls.Add(this.picStateSystem);
            this.Controls.Add(this.picStateT1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Императивное управление";
            ((System.ComponentModel.ISupportInitialize)(this.pbClockT2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClockSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClockT1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStateT2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStateSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStateT1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbClockT2;
        private System.Windows.Forms.PictureBox pbClockSystem;
        private System.Windows.Forms.PictureBox pbClockT1;
        private System.Windows.Forms.Button btnDigit;
        private System.Windows.Forms.Button btnOpenT2;
        private System.Windows.Forms.Button btnOpenT0;
        private System.Windows.Forms.Button btnOpenT1;
        private System.Windows.Forms.Button btnRunInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIntHour;
        private System.Windows.Forms.PictureBox picStateT2;
        private System.Windows.Forms.PictureBox picStateSystem;
        private System.Windows.Forms.PictureBox picStateT1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGlobal;
        private System.Windows.Forms.Timer uiTimer;
        private System.Windows.Forms.Label lblSystemTime;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.TextBox txtIntMin;
        private System.Windows.Forms.Label label2;
    }
}

