// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.KomponentaList
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Models;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
  public class KomponentaList : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dgvRiverList;
    private DataGridViewTextBoxColumn clmRaqam;
    private DataGridViewTextBoxColumn clmName;

    public KomponentaList(KompanentaClass[] list)
    {
      this.InitializeComponent();
      for (int index = 0; index < list.Length; ++index)
        this.dgvRiverList.Rows.Add((object) (index + 1), (object) list[index].Display);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      this.dgvRiverList = new DataGridView();
      this.clmRaqam = new DataGridViewTextBoxColumn();
      this.clmName = new DataGridViewTextBoxColumn();
      ((ISupportInitialize) this.dgvRiverList).BeginInit();
      this.SuspendLayout();
      this.dgvRiverList.AllowUserToAddRows = false;
      this.dgvRiverList.AllowUserToDeleteRows = false;
      this.dgvRiverList.AllowUserToOrderColumns = true;
      this.dgvRiverList.AllowUserToResizeColumns = false;
      this.dgvRiverList.AllowUserToResizeRows = false;
      this.dgvRiverList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvRiverList.BackgroundColor = Color.White;
      this.dgvRiverList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvRiverList.Columns.AddRange((DataGridViewColumn) this.clmRaqam, (DataGridViewColumn) this.clmName);
      this.dgvRiverList.Location = new Point(12, 12);
      this.dgvRiverList.MultiSelect = false;
      this.dgvRiverList.Name = "dgvRiverList";
      this.dgvRiverList.ReadOnly = true;
      this.dgvRiverList.RowHeadersVisible = false;
      this.dgvRiverList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvRiverList.Size = new Size(402, 357);
      this.dgvRiverList.TabIndex = 2;
      gridViewCellStyle1.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.clmRaqam.DefaultCellStyle = gridViewCellStyle1;
      this.clmRaqam.HeaderText = "№";
      this.clmRaqam.Name = "clmRaqam";
      this.clmRaqam.ReadOnly = true;
      this.clmRaqam.Width = 50;
      gridViewCellStyle2.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      this.clmName.DefaultCellStyle = gridViewCellStyle2;
      this.clmName.HeaderText = "Наиминование";
      this.clmName.Name = "clmName";
      this.clmName.ReadOnly = true;
      this.clmName.Width = 400;
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(426, 381);
      this.Controls.Add((Control) this.dgvRiverList);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4, 4, 4, 4);
      this.Name = nameof (KomponentaList);
      this.Text = "Список компонент";
      ((ISupportInitialize) this.dgvRiverList).EndInit();
      this.ResumeLayout(false);
    }
  }
}
