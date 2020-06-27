// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.NewRiverForm
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
  public class NewRiverForm : Form
  {
    private byte key = 0;
    private IContainer components = (IContainer) null;
    private int Id;
    private Button btnCancel;
    private Button btnSave;
    private TextBox tbName;
    private TextBox tbKey;
    private Label label1;
    private Label label2;

    public RiverClass river { get; private set; }

    public event EventHandler GetRiver;

    public NewRiverForm()
    {
      this.InitializeComponent();
      this.river = (RiverClass) null;
    }

    public NewRiverForm(RiverClass river)
    {
      this.InitializeComponent();
      this.river = river;
      this.Id = river.Id;
      this.key = (byte) 1;
      this.tbName.Text = river.Name;
      this.tbKey.Text = river.Number.ToString();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.river = new RiverClass();
      if (this.tbName.Text == "" || this.tbName.Text == null)
      {
        int num1 = (int) MessageBox.Show("Наеминование не заполнение");
      }
      else
      {
        int result = 0;
        if (!int.TryParse(this.tbKey.Text, out result))
        {
          int num2 = (int) MessageBox.Show("Код должно целое число");
        }
        else
        {
          this.river.Name = this.tbName.Text;
          this.river.Number = result;
          if ((int) this.key == 0)
          {
            this.river.Status = (byte) 0;
          }
          else
          {
            this.river.Status = (byte) 1;
            this.river.Id = this.Id;
          }
          // ISSUE: reference to a compiler-generated field
          if (this.GetRiver != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.GetRiver((object) this, e);
          }
          this.Close();
        }
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
      this.btnCancel = new Button();
      this.btnSave = new Button();
      this.tbName = new TextBox();
      this.tbKey = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.SuspendLayout();
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new Point(24, 224);
      this.btnCancel.Margin = new Padding(4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(112, 34);
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new Point(440, 224);
      this.btnSave.Margin = new Padding(4);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(112, 34);
      this.btnSave.TabIndex = 1;
      this.btnSave.Text = "Сохраныть";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      this.tbName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.tbName.Location = new Point(134, 13);
      this.tbName.Margin = new Padding(4);
      this.tbName.Multiline = true;
      this.tbName.Name = "tbName";
      this.tbName.Size = new Size(418, 156);
      this.tbName.TabIndex = 2;
      this.tbKey.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.tbKey.Location = new Point(134, 177);
      this.tbKey.Margin = new Padding(4);
      this.tbKey.Name = "tbKey";
      this.tbKey.Size = new Size(418, 26);
      this.tbKey.TabIndex = 3;
      this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 18);
      this.label1.Name = "label1";
      this.label1.Size = new Size(110, 19);
      this.label1.TabIndex = 4;
      this.label1.Text = "Наеминование";
      this.label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(20, 180);
      this.label2.Name = "label2";
      this.label2.Size = new Size(35, 19);
      this.label2.TabIndex = 5;
      this.label2.Text = "Код";
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(565, 283);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.tbKey);
      this.Controls.Add((Control) this.tbName);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.btnCancel);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4);
      this.MaximumSize = new Size(581, 322);
      this.MinimumSize = new Size(581, 322);
      this.Name = nameof (NewRiverForm);
      this.Text = "Новая река";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
