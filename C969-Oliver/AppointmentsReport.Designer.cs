namespace C969_Oliver
{
    partial class AppointmentsReport
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
            this.apptReportLabel = new System.Windows.Forms.Label();
            this.apptReportDataGrid = new System.Windows.Forms.DataGridView();
            this.rdbtnWeekly = new System.Windows.Forms.RadioButton();
            this.rdbtnMonthly = new System.Windows.Forms.RadioButton();
            this.rdbtnAllAppts = new System.Windows.Forms.RadioButton();
            this.btnCloseApptReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.apptReportDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // apptReportLabel
            // 
            this.apptReportLabel.AutoSize = true;
            this.apptReportLabel.BackColor = System.Drawing.Color.Transparent;
            this.apptReportLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptReportLabel.Location = new System.Drawing.Point(332, 9);
            this.apptReportLabel.Name = "apptReportLabel";
            this.apptReportLabel.Size = new System.Drawing.Size(162, 28);
            this.apptReportLabel.TabIndex = 0;
            this.apptReportLabel.Text = "Calendar View";
            // 
            // apptReportDataGrid
            // 
            this.apptReportDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.apptReportDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apptReportDataGrid.Location = new System.Drawing.Point(18, 45);
            this.apptReportDataGrid.Name = "apptReportDataGrid";
            this.apptReportDataGrid.Size = new System.Drawing.Size(809, 238);
            this.apptReportDataGrid.TabIndex = 1;
            // 
            // rdbtnWeekly
            // 
            this.rdbtnWeekly.AutoSize = true;
            this.rdbtnWeekly.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnWeekly.Location = new System.Drawing.Point(18, 312);
            this.rdbtnWeekly.Name = "rdbtnWeekly";
            this.rdbtnWeekly.Size = new System.Drawing.Size(196, 25);
            this.rdbtnWeekly.TabIndex = 2;
            this.rdbtnWeekly.TabStop = true;
            this.rdbtnWeekly.Text = "Weekly Appointments";
            this.rdbtnWeekly.UseVisualStyleBackColor = true;
            // 
            // rdbtnMonthly
            // 
            this.rdbtnMonthly.AutoSize = true;
            this.rdbtnMonthly.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnMonthly.Location = new System.Drawing.Point(237, 312);
            this.rdbtnMonthly.Name = "rdbtnMonthly";
            this.rdbtnMonthly.Size = new System.Drawing.Size(205, 25);
            this.rdbtnMonthly.TabIndex = 3;
            this.rdbtnMonthly.TabStop = true;
            this.rdbtnMonthly.Text = "Monthly Appointments";
            this.rdbtnMonthly.UseVisualStyleBackColor = true;
            // 
            // rdbtnAllAppts
            // 
            this.rdbtnAllAppts.AutoSize = true;
            this.rdbtnAllAppts.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnAllAppts.Location = new System.Drawing.Point(475, 312);
            this.rdbtnAllAppts.Name = "rdbtnAllAppts";
            this.rdbtnAllAppts.Size = new System.Drawing.Size(160, 25);
            this.rdbtnAllAppts.TabIndex = 4;
            this.rdbtnAllAppts.TabStop = true;
            this.rdbtnAllAppts.Text = "All Appointments";
            this.rdbtnAllAppts.UseVisualStyleBackColor = true;
            // 
            // btnCloseApptReport
            // 
            this.btnCloseApptReport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCloseApptReport.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseApptReport.Location = new System.Drawing.Point(685, 307);
            this.btnCloseApptReport.Name = "btnCloseApptReport";
            this.btnCloseApptReport.Size = new System.Drawing.Size(128, 36);
            this.btnCloseApptReport.TabIndex = 5;
            this.btnCloseApptReport.Text = "Close";
            this.btnCloseApptReport.UseVisualStyleBackColor = false;
            this.btnCloseApptReport.Click += new System.EventHandler(this.btnCloseApptReport_Click);
            // 
            // AppointmentsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(841, 379);
            this.Controls.Add(this.btnCloseApptReport);
            this.Controls.Add(this.rdbtnAllAppts);
            this.Controls.Add(this.rdbtnMonthly);
            this.Controls.Add(this.rdbtnWeekly);
            this.Controls.Add(this.apptReportDataGrid);
            this.Controls.Add(this.apptReportLabel);
            this.Name = "AppointmentsReport";
            this.Text = "AppointmentsReport";
            ((System.ComponentModel.ISupportInitialize)(this.apptReportDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label apptReportLabel;
        public System.Windows.Forms.DataGridView apptReportDataGrid;
        private System.Windows.Forms.RadioButton rdbtnWeekly;
        private System.Windows.Forms.RadioButton rdbtnMonthly;
        private System.Windows.Forms.RadioButton rdbtnAllAppts;
        private System.Windows.Forms.Button btnCloseApptReport;
    }
}