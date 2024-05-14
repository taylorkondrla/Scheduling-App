namespace C969_Oliver
{
    partial class ConsultantReport
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
            this.consultantReportLabel = new System.Windows.Forms.Label();
            this.btnCloseConsultantReport = new System.Windows.Forms.Button();
            this.userReportDataGrid = new System.Windows.Forms.DataGridView();
            this.comboConsultant = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.userReportDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // consultantReportLabel
            // 
            this.consultantReportLabel.AutoSize = true;
            this.consultantReportLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.consultantReportLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultantReportLabel.Location = new System.Drawing.Point(292, 18);
            this.consultantReportLabel.Name = "consultantReportLabel";
            this.consultantReportLabel.Size = new System.Drawing.Size(207, 28);
            this.consultantReportLabel.TabIndex = 0;
            this.consultantReportLabel.Text = "Consultant Report";
            // 
            // btnCloseConsultantReport
            // 
            this.btnCloseConsultantReport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCloseConsultantReport.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseConsultantReport.Location = new System.Drawing.Point(671, 338);
            this.btnCloseConsultantReport.Name = "btnCloseConsultantReport";
            this.btnCloseConsultantReport.Size = new System.Drawing.Size(135, 39);
            this.btnCloseConsultantReport.TabIndex = 3;
            this.btnCloseConsultantReport.Text = "Close";
            this.btnCloseConsultantReport.UseVisualStyleBackColor = false;
            this.btnCloseConsultantReport.Click += new System.EventHandler(this.btnCloseConsultantReport_Click);
            // 
            // userReportDataGrid
            // 
            this.userReportDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.userReportDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userReportDataGrid.Location = new System.Drawing.Point(12, 77);
            this.userReportDataGrid.Name = "userReportDataGrid";
            this.userReportDataGrid.Size = new System.Drawing.Size(793, 216);
            this.userReportDataGrid.TabIndex = 4;
            // 
            // comboConsultant
            // 
            this.comboConsultant.FormattingEnabled = true;
            this.comboConsultant.Location = new System.Drawing.Point(272, 349);
            this.comboConsultant.Name = "comboConsultant";
            this.comboConsultant.Size = new System.Drawing.Size(257, 21);
            this.comboConsultant.TabIndex = 5;
            // 
            // ConsultantReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(828, 409);
            this.Controls.Add(this.comboConsultant);
            this.Controls.Add(this.userReportDataGrid);
            this.Controls.Add(this.btnCloseConsultantReport);
            this.Controls.Add(this.consultantReportLabel);
            this.Name = "ConsultantReport";
            this.Text = "ConsultantReport";
            ((System.ComponentModel.ISupportInitialize)(this.userReportDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label consultantReportLabel;
        private System.Windows.Forms.Button btnCloseConsultantReport;
        private System.Windows.Forms.DataGridView userReportDataGrid;
        private System.Windows.Forms.ComboBox comboConsultant;
    }
}