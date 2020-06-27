// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.YearEnterForm
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
  public class YearEnterForm : Form
  {
    private IContainer components = (IContainer) null;
    private Label label1;
    private DateTimePicker dateTimePicker1;
    private Button button1;

    public static int Year { get; set; }

    public YearEnterForm()
    {
      this.InitializeComponent();
      YearEnterForm.Year = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      YearEnterForm.Year = this.dateTimePicker1.Value.Year;
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
      this.label1 = new Label();
      this.dateTimePicker1 = new DateTimePicker();
      this.button1 = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(4, 35);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(33, 19);
      this.label1.TabIndex = 0;
      this.label1.Text = "Дата";
      this.dateTimePicker1.Location = new Point(44, 35);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(200, 26);
      this.dateTimePicker1.TabIndex = 1;
      this.button1.Location = new Point(78, 92);
      this.button1.Name = "button1";
      this.button1.Size = new Size(85, 36);
      this.button1.TabIndex = 2;
      this.button1.Text = "Начать";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(273, 158);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.dateTimePicker1);
      this.Controls.Add((Control) this.label1);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximumSize = new Size(289, 197);
      this.MinimumSize = new Size(289, 197);
      this.Name = nameof (YearEnterForm);
      this.Text = "Укажите дату";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
