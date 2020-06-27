// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.QatlamForm
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
  public class QatlamForm : Form
  {
    private IContainer components = (IContainer) null;
    public static int i1;
    public static int i2;
    private Label label1;
    private ComboBox cbKompanentaList1;
    private ComboBox cbKompanentaList2;
    private Label label2;
    private Button btncalculator;

    public QatlamForm(KompanentaClass[] koms, byte key)
    {
      this.InitializeComponent();
      if ((int) key == 0)
      {
        this.label2.Visible = false;
        this.cbKompanentaList2.Visible = false;
        this.cbKompanentaList1.DataSource = (object) ((IEnumerable<KompanentaClass>) koms).ToList<KompanentaClass>();
        this.cbKompanentaList1.DisplayMember = "Display";
      }
      else
      {
        this.cbKompanentaList1.DataSource = (object) ((IEnumerable<KompanentaClass>) koms).ToList<KompanentaClass>();
        this.cbKompanentaList1.DisplayMember = "Display";
        this.cbKompanentaList2.DataSource = (object) ((IEnumerable<KompanentaClass>) koms).ToList<KompanentaClass>();
        this.cbKompanentaList2.DisplayMember = "Display";
      }
    }

    private void btncalculator_Click(object sender, EventArgs e)
    {
      QatlamForm.i1 = this.cbKompanentaList1.SelectedItem == null ? -1 : this.cbKompanentaList1.SelectedIndex;
      QatlamForm.i2 = this.cbKompanentaList2.SelectedItem == null ? -1 : this.cbKompanentaList2.SelectedIndex;
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
      this.cbKompanentaList1 = new ComboBox();
      this.cbKompanentaList2 = new ComboBox();
      this.label2 = new Label();
      this.btncalculator = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 18);
      this.label1.Name = "label1";
      this.label1.Size = new Size(92, 19);
      this.label1.TabIndex = 0;
      this.label1.Text = "Компанента";
      this.cbKompanentaList1.FormattingEnabled = true;
      this.cbKompanentaList1.Location = new Point(110, 18);
      this.cbKompanentaList1.Name = "cbKompanentaList1";
      this.cbKompanentaList1.Size = new Size(304, 27);
      this.cbKompanentaList1.TabIndex = 1;
      this.cbKompanentaList2.FormattingEnabled = true;
      this.cbKompanentaList2.Location = new Point(110, 63);
      this.cbKompanentaList2.Name = "cbKompanentaList2";
      this.cbKompanentaList2.Size = new Size(304, 27);
      this.cbKompanentaList2.TabIndex = 3;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(12, 63);
      this.label2.Name = "label2";
      this.label2.Size = new Size(92, 19);
      this.label2.TabIndex = 2;
      this.label2.Text = "Компанента";
      this.btncalculator.Location = new Point(154, 115);
      this.btncalculator.Name = "btncalculator";
      this.btncalculator.Size = new Size(179, 36);
      this.btncalculator.TabIndex = 4;
      this.btncalculator.Text = "Вычислить";
      this.btncalculator.UseVisualStyleBackColor = true;
      this.btncalculator.Click += new EventHandler(this.btncalculator_Click);
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(426, 163);
      this.Controls.Add((Control) this.btncalculator);
      this.Controls.Add((Control) this.cbKompanentaList2);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.cbKompanentaList1);
      this.Controls.Add((Control) this.label1);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximumSize = new Size(442, 202);
      this.MinimumSize = new Size(442, 202);
      this.Name = nameof (QatlamForm);
      this.Text = "Выбрите компаненту";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
