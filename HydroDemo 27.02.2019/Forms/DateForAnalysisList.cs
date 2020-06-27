// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.DateForAnalysisList
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
  public class DateForAnalysisList : Form
  {
    private IContainer components = (IContainer) null;
    public static DateTime dat1;
    public static DateTime dat2;
    private DateTimePicker dtpDateGacha;
    private DateTimePicker dtpDateDan;
    private Label label5;
    private Label label4;
    private Button button1;

    public DateForAnalysisList(DateTime dat1, DateTime dat2)
    {
      this.InitializeComponent();
      this.dtpDateDan.Value = dat1;
      this.dtpDateGacha.Value = dat2;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      DateForAnalysisList.dat1 = this.dtpDateDan.Value;
      DateForAnalysisList.dat2 = this.dtpDateGacha.Value;
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dtpDateGacha = new DateTimePicker();
      this.dtpDateDan = new DateTimePicker();
      this.label5 = new Label();
      this.label4 = new Label();
      this.button1 = new Button();
      this.SuspendLayout();
      this.dtpDateGacha.Format = DateTimePickerFormat.Custom;
      this.dtpDateGacha.Location = new Point(76, 62);
      this.dtpDateGacha.Margin = new Padding(4);
      this.dtpDateGacha.Name = "dtpDateGacha";
      this.dtpDateGacha.Size = new Size(156, 26);
      this.dtpDateGacha.TabIndex = 12;
      this.dtpDateDan.Format = DateTimePickerFormat.Custom;
      this.dtpDateDan.Location = new Point(77, 13);
      this.dtpDateDan.Margin = new Padding(4);
      this.dtpDateDan.Name = "dtpDateDan";
      this.dtpDateDan.Size = new Size(155, 26);
      this.dtpDateDan.TabIndex = 11;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(7, 62);
      this.label5.Margin = new Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(61, 19);
      this.label5.TabIndex = 10;
      this.label5.Text = "Дата до";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(8, 13);
      this.label4.Margin = new Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(60, 19);
      this.label4.TabIndex = 9;
      this.label4.Text = "Дата от";
      this.button1.Location = new Point(89, 99);
      this.button1.Name = "button1";
      this.button1.Size = new Size(91, 29);
      this.button1.TabIndex = 13;
      this.button1.Text = "Ок";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(245, 140);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.dtpDateGacha);
      this.Controls.Add((Control) this.dtpDateDan);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4);
      this.Name = nameof (DateForAnalysisList);
      this.Text = "Выбрети дату";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
