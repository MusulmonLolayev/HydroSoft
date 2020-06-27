namespace HydroDemo.Forms
{
    partial class YearFormForPDK
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
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.chbLastYear = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnKomponent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpYear
            // 
            this.dtpYear.Location = new System.Drawing.Point(74, 22);
            this.dtpYear.Margin = new System.Windows.Forms.Padding(4);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpYear.Size = new System.Drawing.Size(298, 26);
            this.dtpYear.TabIndex = 0;
            // 
            // chbLastYear
            // 
            this.chbLastYear.AutoSize = true;
            this.chbLastYear.Location = new System.Drawing.Point(129, 64);
            this.chbLastYear.Name = "chbLastYear";
            this.chbLastYear.Size = new System.Drawing.Size(143, 23);
            this.chbLastYear.TabIndex = 1;
            this.chbLastYear.Text = "Предыдуший год";
            this.chbLastYear.UseVisualStyleBackColor = true;
            this.chbLastYear.CheckedChanged += new System.EventHandler(this.chbLastYear_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(154, 148);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(97, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnKomponent
            // 
            this.btnKomponent.Location = new System.Drawing.Point(145, 93);
            this.btnKomponent.Name = "btnKomponent";
            this.btnKomponent.Size = new System.Drawing.Size(127, 30);
            this.btnKomponent.TabIndex = 14;
            this.btnKomponent.Text = "Компоненты";
            this.btnKomponent.UseVisualStyleBackColor = true;
            this.btnKomponent.Click += new System.EventHandler(this.btnKomponent_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Дата";
            // 
            // YearFormForPDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 188);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKomponent);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chbLastYear);
            this.Controls.Add(this.dtpYear);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(443, 227);
            this.MinimumSize = new System.Drawing.Size(443, 227);
            this.Name = "YearFormForPDK";
            this.Text = "Укажите дату";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.CheckBox chbLastYear;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnKomponent;
        private System.Windows.Forms.Label label1;
    }
}