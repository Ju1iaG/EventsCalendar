namespace Calendar
{
    partial class TimerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbEventTypes = new System.Windows.Forms.ComboBox();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.nudEventTime = new System.Windows.Forms.NumericUpDown();
            this.lstLocalEvents = new System.Windows.Forms.ListBox();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudEventTime)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEventTypes
            // 
            this.cmbEventTypes.FormattingEnabled = true;
            this.cmbEventTypes.Location = new System.Drawing.Point(12, 12);
            this.cmbEventTypes.Name = "cmbEventTypes";
            this.cmbEventTypes.Size = new System.Drawing.Size(608, 28);
            this.cmbEventTypes.TabIndex = 0;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(862, 9);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(198, 35);
            this.btnAddEvent.TabIndex = 1;
            this.btnAddEvent.Text = "Добавить событие";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // nudEventTime
            // 
            this.nudEventTime.Location = new System.Drawing.Point(683, 14);
            this.nudEventTime.Name = "nudEventTime";
            this.nudEventTime.Size = new System.Drawing.Size(120, 26);
            this.nudEventTime.TabIndex = 2;
            // 
            // lstLocalEvents
            // 
            this.lstLocalEvents.FormattingEnabled = true;
            this.lstLocalEvents.ItemHeight = 20;
            this.lstLocalEvents.Location = new System.Drawing.Point(12, 85);
            this.lstLocalEvents.Name = "lstLocalEvents";
            this.lstLocalEvents.Size = new System.Drawing.Size(1131, 364);
            this.lstLocalEvents.TabIndex = 3;
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Location = new System.Drawing.Point(27, 527);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(243, 36);
            this.btnDeleteEvent.TabIndex = 4;
            this.btnDeleteEvent.Text = "Удалить событие";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 676);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.lstLocalEvents);
            this.Controls.Add(this.nudEventTime);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.cmbEventTypes);
            this.Name = "TimerForm";
            this.Text = "Таймер";
            ((System.ComponentModel.ISupportInitialize)(this.nudEventTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEventTypes;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.NumericUpDown nudEventTime;
        private System.Windows.Forms.ListBox lstLocalEvents;
        private System.Windows.Forms.Button btnDeleteEvent;
    }
}