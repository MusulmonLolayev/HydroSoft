// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.NewCopyDbForm
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Metods;
using HydroDemo.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
  public class NewCopyDbForm : Form
  {
    private IContainer components = (IContainer) null;
    private Label label1;
    private TextBox textBox1;
    private Button btnCopy;
    private Button btnCancel;

    public NewCopyDbForm()
    {
      this.InitializeComponent();
    }

    private void btnCopy_Click(object sender, EventArgs e)
    {
      try
      {
        string str = Environment.CurrentDirectory + "\\Data\\Hydro.mdb";
        CopyDBClass newElement = new CopyDBClass();
        newElement.Display = this.textBox1.Text;
        newElement.Vaqt = DateTime.Now;
        if (!File.Exists(str))
          return;
        int num1 = (int) WriteXml.InsertCopyDBClass(newElement);
        File.Copy(str, Environment.CurrentDirectory + "\\Data\\Savat\\" + newElement.Id.ToString() + newElement.Display + newElement.Vaqt.ToShortDateString() + ".mdb");
        int num2 = (int) MessageBox.Show("Резервное копирование баз данных завершена");
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
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
      this.textBox1 = new TextBox();
      this.btnCopy = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 19);
      this.label1.Name = "label1";
      this.label1.Size = new Size(112, 19);
      this.label1.TabIndex = 0;
      this.label1.Text = "Наиминование";
      this.textBox1.Location = new Point(130, 19);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(261, 104);
      this.textBox1.TabIndex = 1;
      this.btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCopy.Location = new Point(268, 138);
      this.btnCopy.Name = "btnCopy";
      this.btnCopy.Size = new Size(113, 33);
      this.btnCopy.TabIndex = 2;
      this.btnCopy.Text = "Копировать";
      this.btnCopy.UseVisualStyleBackColor = true;
      this.btnCopy.Click += new EventHandler(this.btnCopy_Click);
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new Point(16, 139);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(113, 33);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(403, 184);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnCopy);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label1);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4, 4, 4, 4);
      this.Name = nameof (NewCopyDbForm);
      this.Text = "Резервное копирование баз данных";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
