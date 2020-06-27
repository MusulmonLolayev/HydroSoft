// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.KoponenteCheckedListForm
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
  public class KoponenteCheckedListForm : Form
  {
    public bool[] t = new bool[61];
    private byte key = 0;
    private IContainer components = (IContainer) null;
    private DataGridView dgvKompanenta;
    private DataGridViewTextBoxColumn clmHeader;
    private DataGridViewCheckBoxColumn clmValue;
    private Button btnSelectedAll;
    private Button btnSelectedFree;
    private Button btnClear;
    private Button btnOk;

    public event EventHandler GetBool;

    public KoponenteCheckedListForm(KompanentaClass[] koms, bool[] t)
    {
      this.InitializeComponent();
      for (int index = 0; index < koms.Length; ++index)
        this.dgvKompanenta.Rows.Add((object) koms[index].Display, (object) t[index]);
      this.t = t;
    }

    private void btnSelectedAll_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.dgvKompanenta.RowCount; ++index)
        this.dgvKompanenta.Rows[index].Cells[1].Value = (object) true;
    }

    private void btnSelectedFree_Click(object sender, EventArgs e)
    {
      if ((int) this.key == 0)
      {
        for (int index = 0; index < this.dgvKompanenta.RowCount; ++index)
          this.dgvKompanenta.Rows[index].Cells[1].Value = index % 2 != 0 ? (object) true : (object) false;
        this.key = (byte) 1;
      }
      else
      {
        for (int index = 0; index < this.dgvKompanenta.RowCount; ++index)
          this.dgvKompanenta.Rows[index].Cells[1].Value = (uint) (index % 2) <= 0U ? (object) true : (object) false;
        this.key = (byte) 0;
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.dgvKompanenta.RowCount; ++index)
        this.dgvKompanenta.Rows[index].Cells[1].Value = (object) false;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.dgvKompanenta.RowCount; ++index)
        this.t[index] = (bool) this.dgvKompanenta.Rows[index].Cells[1].Value;
      // ISSUE: reference to a compiler-generated field
      if (this.GetBool != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.GetBool((object) this, e);
      }
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
      this.dgvKompanenta = new DataGridView();
      this.clmHeader = new DataGridViewTextBoxColumn();
      this.clmValue = new DataGridViewCheckBoxColumn();
      this.btnSelectedAll = new Button();
      this.btnSelectedFree = new Button();
      this.btnClear = new Button();
      this.btnOk = new Button();
      ((ISupportInitialize) this.dgvKompanenta).BeginInit();
      this.SuspendLayout();
      this.dgvKompanenta.AllowUserToAddRows = false;
      this.dgvKompanenta.AllowUserToDeleteRows = false;
      this.dgvKompanenta.AllowUserToOrderColumns = true;
      this.dgvKompanenta.AllowUserToResizeColumns = false;
      this.dgvKompanenta.AllowUserToResizeRows = false;
      this.dgvKompanenta.BackgroundColor = SystemColors.ButtonHighlight;
      this.dgvKompanenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvKompanenta.Columns.AddRange((DataGridViewColumn) this.clmHeader, (DataGridViewColumn) this.clmValue);
      this.dgvKompanenta.Location = new Point(12, 12);
      this.dgvKompanenta.Name = "dgvKompanenta";
      this.dgvKompanenta.RowHeadersVisible = false;
      this.dgvKompanenta.Size = new Size(487, 324);
      this.dgvKompanenta.TabIndex = 5;
      this.clmHeader.HeaderText = "Компаненты";
      this.clmHeader.Name = "clmHeader";
      this.clmHeader.ReadOnly = true;
      this.clmHeader.Width = 300;
      this.clmValue.HeaderText = "Значение";
      this.clmValue.Name = "clmValue";
      this.clmValue.Resizable = DataGridViewTriState.True;
      this.clmValue.SortMode = DataGridViewColumnSortMode.Automatic;
      this.btnSelectedAll.Location = new Point(12, 354);
      this.btnSelectedAll.Name = "btnSelectedAll";
      this.btnSelectedAll.Size = new Size(114, 33);
      this.btnSelectedAll.TabIndex = 6;
      this.btnSelectedAll.Text = "Выделитъ все";
      this.btnSelectedAll.UseVisualStyleBackColor = true;
      this.btnSelectedAll.Click += new EventHandler(this.btnSelectedAll_Click);
      this.btnSelectedFree.Location = new Point(132, 354);
      this.btnSelectedFree.Name = "btnSelectedFree";
      this.btnSelectedFree.Size = new Size(132, 33);
      this.btnSelectedFree.TabIndex = 7;
      this.btnSelectedFree.Text = "Выделитъ через";
      this.btnSelectedFree.UseVisualStyleBackColor = true;
      this.btnSelectedFree.Click += new EventHandler(this.btnSelectedFree_Click);
      this.btnClear.Location = new Point(270, 354);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new Size(102, 33);
      this.btnClear.TabIndex = 8;
      this.btnClear.Text = "Убрать все";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new EventHandler(this.btnClear_Click);
      this.btnOk.Location = new Point(388, 354);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(102, 33);
      this.btnOk.TabIndex = 9;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new EventHandler(this.btnOk_Click);
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(511, 399);
      this.Controls.Add((Control) this.btnOk);
      this.Controls.Add((Control) this.btnClear);
      this.Controls.Add((Control) this.btnSelectedFree);
      this.Controls.Add((Control) this.btnSelectedAll);
      this.Controls.Add((Control) this.dgvKompanenta);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximumSize = new Size(527, 438);
      this.MinimumSize = new Size(527, 438);
      this.Name = nameof (KoponenteCheckedListForm);
      this.Text = "Список компоненты";
      ((ISupportInitialize) this.dgvKompanenta).EndInit();
      this.ResumeLayout(false);
    }
  }
}
