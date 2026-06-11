namespace Calendar
{
    partial class GlobalForm
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
            this.dgvGlobal = new System.Windows.Forms.DataGridView();
            this.btnRefreshGlobal = new System.Windows.Forms.Button();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimerTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SystemTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlobal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGlobal
            // 
            this.dgvGlobal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGlobal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.Timer,
            this.Type,
            this.TimerTime,
            this.SystemTime});
            this.dgvGlobal.Location = new System.Drawing.Point(12, 12);
            this.dgvGlobal.Name = "dgvGlobal";
            this.dgvGlobal.RowHeadersWidth = 62;
            this.dgvGlobal.RowTemplate.Height = 28;
            this.dgvGlobal.Size = new System.Drawing.Size(1141, 569);
            this.dgvGlobal.TabIndex = 0;
            // 
            // btnRefreshGlobal
            // 
            this.btnRefreshGlobal.Location = new System.Drawing.Point(12, 587);
            this.btnRefreshGlobal.Name = "btnRefreshGlobal";
            this.btnRefreshGlobal.Size = new System.Drawing.Size(130, 46);
            this.btnRefreshGlobal.TabIndex = 1;
            this.btnRefreshGlobal.Text = "Обновить";
            this.btnRefreshGlobal.UseVisualStyleBackColor = true;
            this.btnRefreshGlobal.Click += new System.EventHandler(this.btnRefreshGlobal_Click);
            // 
            // number
            // 
            this.number.HeaderText = "№";
            this.number.MinimumWidth = 8;
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 70;
            // 
            // Timer
            // 
            this.Timer.HeaderText = "Timer";
            this.Timer.MinimumWidth = 8;
            this.Timer.Name = "Timer";
            this.Timer.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 8;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 300;
            // 
            // TimerTime
            // 
            this.TimerTime.HeaderText = "TimerTime";
            this.TimerTime.MinimumWidth = 8;
            this.TimerTime.Name = "TimerTime";
            this.TimerTime.ReadOnly = true;
            this.TimerTime.Width = 90;
            // 
            // SystemTime
            // 
            this.SystemTime.HeaderText = "SystemTime";
            this.SystemTime.MinimumWidth = 8;
            this.SystemTime.Name = "SystemTime";
            this.SystemTime.ReadOnly = true;
            this.SystemTime.Width = 90;
            // 
            // GlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 645);
            this.Controls.Add(this.btnRefreshGlobal);
            this.Controls.Add(this.dgvGlobal);
            this.Name = "GlobalForm";
            this.Text = "GlobalForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlobal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGlobal;
        private System.Windows.Forms.Button btnRefreshGlobal;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimerTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SystemTime;
    }
}