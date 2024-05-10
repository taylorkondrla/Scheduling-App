namespace C969_Oliver
{
    partial class MainForm
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
            this.mainScheduleLabel = new System.Windows.Forms.Label();
            this.mainAppointmentsLabel = new System.Windows.Forms.Label();
            this.mainApptDataGrid = new System.Windows.Forms.DataGridView();
            this.btnAddAppt = new System.Windows.Forms.Button();
            this.btnModifyAppt = new System.Windows.Forms.Button();
            this.btnDeleteAppt = new System.Windows.Forms.Button();
            this.mainCustomersLabel = new System.Windows.Forms.Label();
            this.mainControlsLabel = new System.Windows.Forms.Label();
            this.mainCustomersDataGrid = new System.Windows.Forms.DataGridView();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnModifyCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnViewAppts = new System.Windows.Forms.Button();
            this.btnConsultantReport = new System.Windows.Forms.Button();
            this.btnApptType = new System.Windows.Forms.Button();
            this.btnCustomerReport = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainApptDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainCustomersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // mainScheduleLabel
            // 
            this.mainScheduleLabel.AutoSize = true;
            this.mainScheduleLabel.Font = new System.Drawing.Font("Microsoft YaHei", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainScheduleLabel.Location = new System.Drawing.Point(337, 9);
            this.mainScheduleLabel.Name = "mainScheduleLabel";
            this.mainScheduleLabel.Size = new System.Drawing.Size(164, 42);
            this.mainScheduleLabel.TabIndex = 0;
            this.mainScheduleLabel.Text = "Schedule";
            // 
            // mainAppointmentsLabel
            // 
            this.mainAppointmentsLabel.AutoSize = true;
            this.mainAppointmentsLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainAppointmentsLabel.Location = new System.Drawing.Point(339, 68);
            this.mainAppointmentsLabel.Name = "mainAppointmentsLabel";
            this.mainAppointmentsLabel.Size = new System.Drawing.Size(156, 28);
            this.mainAppointmentsLabel.TabIndex = 1;
            this.mainAppointmentsLabel.Text = "Appointments";
            // 
            // mainApptDataGrid
            // 
            this.mainApptDataGrid.AllowUserToOrderColumns = true;
            this.mainApptDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.mainApptDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainApptDataGrid.Location = new System.Drawing.Point(21, 99);
            this.mainApptDataGrid.Name = "mainApptDataGrid";
            this.mainApptDataGrid.Size = new System.Drawing.Size(791, 152);
            this.mainApptDataGrid.TabIndex = 2;
            // 
            // btnAddAppt
            // 
            this.btnAddAppt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddAppt.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAppt.Location = new System.Drawing.Point(106, 257);
            this.btnAddAppt.Name = "btnAddAppt";
            this.btnAddAppt.Size = new System.Drawing.Size(139, 36);
            this.btnAddAppt.TabIndex = 3;
            this.btnAddAppt.Text = "Add";
            this.btnAddAppt.UseVisualStyleBackColor = false;
            this.btnAddAppt.Click += new System.EventHandler(this.btnAddAppt_Click);
            // 
            // btnModifyAppt
            // 
            this.btnModifyAppt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnModifyAppt.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyAppt.Location = new System.Drawing.Point(344, 257);
            this.btnModifyAppt.Name = "btnModifyAppt";
            this.btnModifyAppt.Size = new System.Drawing.Size(127, 36);
            this.btnModifyAppt.TabIndex = 4;
            this.btnModifyAppt.Text = "Modify";
            this.btnModifyAppt.UseVisualStyleBackColor = false;
            this.btnModifyAppt.Click += new System.EventHandler(this.btnModifyAppt_Click);
            // 
            // btnDeleteAppt
            // 
            this.btnDeleteAppt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteAppt.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAppt.Location = new System.Drawing.Point(587, 257);
            this.btnDeleteAppt.Name = "btnDeleteAppt";
            this.btnDeleteAppt.Size = new System.Drawing.Size(144, 36);
            this.btnDeleteAppt.TabIndex = 5;
            this.btnDeleteAppt.Text = "Delete";
            this.btnDeleteAppt.UseVisualStyleBackColor = false;
            this.btnDeleteAppt.Click += new System.EventHandler(this.btnDeleteAppt_Click);
            // 
            // mainCustomersLabel
            // 
            this.mainCustomersLabel.AutoSize = true;
            this.mainCustomersLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainCustomersLabel.Location = new System.Drawing.Point(199, 305);
            this.mainCustomersLabel.Name = "mainCustomersLabel";
            this.mainCustomersLabel.Size = new System.Drawing.Size(120, 28);
            this.mainCustomersLabel.TabIndex = 6;
            this.mainCustomersLabel.Text = "Customers";
            // 
            // mainControlsLabel
            // 
            this.mainControlsLabel.AutoSize = true;
            this.mainControlsLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainControlsLabel.Location = new System.Drawing.Point(658, 305);
            this.mainControlsLabel.Name = "mainControlsLabel";
            this.mainControlsLabel.Size = new System.Drawing.Size(97, 28);
            this.mainControlsLabel.TabIndex = 7;
            this.mainControlsLabel.Text = "Controls";
            // 
            // mainCustomersDataGrid
            // 
            this.mainCustomersDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.mainCustomersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainCustomersDataGrid.Location = new System.Drawing.Point(21, 336);
            this.mainCustomersDataGrid.Name = "mainCustomersDataGrid";
            this.mainCustomersDataGrid.Size = new System.Drawing.Size(521, 202);
            this.mainCustomersDataGrid.TabIndex = 8;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.Location = new System.Drawing.Point(30, 556);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(129, 33);
            this.btnAddCustomer.TabIndex = 9;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnModifyCustomer
            // 
            this.btnModifyCustomer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnModifyCustomer.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyCustomer.Location = new System.Drawing.Point(204, 556);
            this.btnModifyCustomer.Name = "btnModifyCustomer";
            this.btnModifyCustomer.Size = new System.Drawing.Size(137, 33);
            this.btnModifyCustomer.TabIndex = 10;
            this.btnModifyCustomer.Text = "Modify";
            this.btnModifyCustomer.UseVisualStyleBackColor = false;
            this.btnModifyCustomer.Click += new System.EventHandler(this.btnModifyCustomer_Click);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomer.Location = new System.Drawing.Point(401, 556);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(122, 33);
            this.btnDeleteCustomer.TabIndex = 11;
            this.btnDeleteCustomer.Text = "Delete";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnViewAppts
            // 
            this.btnViewAppts.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnViewAppts.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAppts.Location = new System.Drawing.Point(587, 336);
            this.btnViewAppts.Name = "btnViewAppts";
            this.btnViewAppts.Size = new System.Drawing.Size(224, 44);
            this.btnViewAppts.TabIndex = 12;
            this.btnViewAppts.Text = "Appointments Calendar";
            this.btnViewAppts.UseVisualStyleBackColor = false;
            this.btnViewAppts.Click += new System.EventHandler(this.btnViewAppts_Click);
            // 
            // btnConsultantReport
            // 
            this.btnConsultantReport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConsultantReport.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultantReport.Location = new System.Drawing.Point(585, 386);
            this.btnConsultantReport.Name = "btnConsultantReport";
            this.btnConsultantReport.Size = new System.Drawing.Size(225, 40);
            this.btnConsultantReport.TabIndex = 13;
            this.btnConsultantReport.Text = "Consultant Report";
            this.btnConsultantReport.UseVisualStyleBackColor = false;
            this.btnConsultantReport.Click += new System.EventHandler(this.btnConsultantReport_Click);
            // 
            // btnApptType
            // 
            this.btnApptType.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnApptType.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApptType.Location = new System.Drawing.Point(587, 432);
            this.btnApptType.Name = "btnApptType";
            this.btnApptType.Size = new System.Drawing.Size(223, 42);
            this.btnApptType.TabIndex = 14;
            this.btnApptType.Text = "Appointment Type";
            this.btnApptType.UseVisualStyleBackColor = false;
            this.btnApptType.Click += new System.EventHandler(this.btnApptType_Click);
            // 
            // btnCustomerReport
            // 
            this.btnCustomerReport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCustomerReport.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerReport.Location = new System.Drawing.Point(587, 480);
            this.btnCustomerReport.Name = "btnCustomerReport";
            this.btnCustomerReport.Size = new System.Drawing.Size(223, 44);
            this.btnCustomerReport.TabIndex = 15;
            this.btnCustomerReport.Text = "Customers Report";
            this.btnCustomerReport.UseVisualStyleBackColor = false;
            this.btnCustomerReport.Click += new System.EventHandler(this.btnCustomerReport_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(587, 530);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(223, 38);
            this.btnLogOut.TabIndex = 16;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(845, 600);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnCustomerReport);
            this.Controls.Add(this.btnApptType);
            this.Controls.Add(this.btnConsultantReport);
            this.Controls.Add(this.btnViewAppts);
            this.Controls.Add(this.btnDeleteCustomer);
            this.Controls.Add(this.btnModifyCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.mainCustomersDataGrid);
            this.Controls.Add(this.mainControlsLabel);
            this.Controls.Add(this.mainCustomersLabel);
            this.Controls.Add(this.btnDeleteAppt);
            this.Controls.Add(this.btnModifyAppt);
            this.Controls.Add(this.btnAddAppt);
            this.Controls.Add(this.mainApptDataGrid);
            this.Controls.Add(this.mainAppointmentsLabel);
            this.Controls.Add(this.mainScheduleLabel);
            this.Name = "MainForm";
            this.Text = "Schedule App";
            ((System.ComponentModel.ISupportInitialize)(this.mainApptDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainCustomersDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainScheduleLabel;
        private System.Windows.Forms.Label mainAppointmentsLabel;
        public System.Windows.Forms.DataGridView mainApptDataGrid;
        private System.Windows.Forms.Button btnAddAppt;
        private System.Windows.Forms.Button btnModifyAppt;
        private System.Windows.Forms.Button btnDeleteAppt;
        private System.Windows.Forms.Label mainCustomersLabel;
        private System.Windows.Forms.Label mainControlsLabel;
        private System.Windows.Forms.DataGridView mainCustomersDataGrid;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnModifyCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnViewAppts;
        private System.Windows.Forms.Button btnConsultantReport;
        private System.Windows.Forms.Button btnApptType;
        private System.Windows.Forms.Button btnCustomerReport;
        private System.Windows.Forms.Button btnLogOut;
    }
}

