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
            this.consultantReportDataGrid = new System.Windows.Forms.DataGridView();
            this.consultantDropDown = new System.Windows.Forms.ComboBox();
            this.btnCloseConsultantReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.consultantReportDataGrid)).BeginInit();
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
            // consultantReportDataGrid
            // 
            this.consultantReportDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.consultantReportDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consultantReportDataGrid.Location = new System.Drawing.Point(31, 67);
            this.consultantReportDataGrid.Name = "consultantReportDataGrid";
            this.consultantReportDataGrid.Size = new System.Drawing.Size(775, 250);
            this.consultantReportDataGrid.TabIndex = 1;
            // 
            // consultantDropDown
            // 
            this.consultantDropDown.AllowDrop = true;
            this.consultantDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.consultantDropDown.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultantDropDown.FormattingEnabled = true;
            this.consultantDropDown.Location = new System.Drawing.Point(274, 338);
            this.consultantDropDown.Name = "consultantDropDown";
            this.consultantDropDown.Size = new System.Drawing.Size(256, 27);
            this.consultantDropDown.TabIndex = 2;
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
            // ConsultantReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(828, 409);
            this.Controls.Add(this.btnCloseConsultantReport);
            this.Controls.Add(this.consultantDropDown);
            this.Controls.Add(this.consultantReportDataGrid);
            this.Controls.Add(this.consultantReportLabel);
            this.Name = "ConsultantReport";
            this.Text = "ConsultantReport";
            ((System.ComponentModel.ISupportInitialize)(this.consultantReportDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label consultantReportLabel;
        public System.Windows.Forms.DataGridView consultantReportDataGrid;
        private System.Windows.Forms.ComboBox consultantDropDown;
        private System.Windows.Forms.Button btnCloseConsultantReport;
    }
}