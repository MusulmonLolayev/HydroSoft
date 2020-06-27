// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.CopyDBFormList
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Metods;
using HydroDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
  public class CopyDBFormList : Form
  {
    private IContainer components = (IContainer) null;
    private ToolStrip toolStrip1;
    private ToolStripButton tSBDelete;
    private DataGridView dgvCopyDbList;
    private DataGridViewTextBoxColumn clmId;
    private DataGridViewTextBoxColumn clmRaqam;
    private DataGridViewTextBoxColumn clmDisplay;
    private DataGridViewTextBoxColumn clmDateandTime;
    private ToolStripButton tSbtnRestore;
    private ToolStripSeparator toolStripSeparator1;

    public CopyDBClass copy { get; private set; }

    public event EventHandler GetCopyDb;

    public CopyDBFormList()
    {
      this.InitializeComponent();
      this.Fill_Dgv();
      this.copy = (CopyDBClass) null;
    }

    private void Fill_Dgv()
    {
            this.dgvCopyDbList.Rows.Clear();
            List<CopyDBClass> copyDbClassList = ReadXml.SelectCopyDBClass((string)null, (string)null);
            for (int index = 0; index < copyDbClassList.Count; ++index)
                this.dgvCopyDbList.Rows.Add((object)copyDbClassList[index].Id, (object)(index + 1), (object)copyDbClassList[index].Display, (object)copyDbClassList[index].Vaqt);
        }

    private void tSbtnRestore_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dgvCopyDbList.SelectedRows.Count < 1)
          return;
        this.copy = new CopyDBClass();
        this.copy.Id = (int) this.dgvCopyDbList.SelectedRows[0].Cells[0].Value;
        this.copy.Display = (string) this.dgvCopyDbList.SelectedRows[0].Cells[2].Value;
        this.copy.Vaqt = (DateTime) this.dgvCopyDbList.SelectedRows[0].Cells[3].Value;
        // ISSUE: reference to a compiler-generated field
        if (this.GetCopyDb != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.GetCopyDb((object) this, e);
        }
        WriteXml.DeleteCopyDBClass(this.copy.Id.ToString());
        this.Fill_Dgv();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void tSBDelete_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dgvCopyDbList.SelectedRows.Count < 1)
          return;
        WriteXml.DeleteCopyDBClass((string) this.dgvCopyDbList.SelectedRows[0].Cells[0].Value);
        this.Fill_Dgv();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
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
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CopyDBFormList));
      this.toolStrip1 = new ToolStrip();
      this.tSBDelete = new ToolStripButton();
      this.dgvCopyDbList = new DataGridView();
      this.clmId = new DataGridViewTextBoxColumn();
      this.clmRaqam = new DataGridViewTextBoxColumn();
      this.clmDisplay = new DataGridViewTextBoxColumn();
      this.clmDateandTime = new DataGridViewTextBoxColumn();
      this.tSbtnRestore = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStrip1.SuspendLayout();
      ((ISupportInitialize) this.dgvCopyDbList).BeginInit();
      this.SuspendLayout();
      this.toolStrip1.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.toolStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.tSbtnRestore,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.tSBDelete
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(845, 26);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      this.tSBDelete.Image = (Image) componentResourceManager.GetObject("tSBDelete.Image");
      this.tSBDelete.ImageTransparentColor = Color.Magenta;
      this.tSBDelete.Name = "tSBDelete";
      this.tSBDelete.Size = new Size(84, 23);
      this.tSBDelete.Text = "Удалить";
      this.tSBDelete.ToolTipText = "Удалить реку";
      this.tSBDelete.Click += new EventHandler(this.tSBDelete_Click);
      this.dgvCopyDbList.AllowUserToAddRows = false;
      this.dgvCopyDbList.AllowUserToDeleteRows = false;
      this.dgvCopyDbList.AllowUserToOrderColumns = true;
      this.dgvCopyDbList.AllowUserToResizeColumns = false;
      this.dgvCopyDbList.AllowUserToResizeRows = false;
      this.dgvCopyDbList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvCopyDbList.BackgroundColor = Color.White;
      this.dgvCopyDbList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvCopyDbList.Columns.AddRange((DataGridViewColumn) this.clmId, (DataGridViewColumn) this.clmRaqam, (DataGridViewColumn) this.clmDisplay, (DataGridViewColumn) this.clmDateandTime);
      this.dgvCopyDbList.Location = new Point(12, 40);
      this.dgvCopyDbList.MultiSelect = false;
      this.dgvCopyDbList.Name = "dgvCopyDbList";
      this.dgvCopyDbList.ReadOnly = true;
      this.dgvCopyDbList.RowHeadersVisible = false;
      this.dgvCopyDbList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvCopyDbList.Size = new Size(821, 336);
      this.dgvCopyDbList.TabIndex = 2;
      this.clmId.HeaderText = "Id";
      this.clmId.Name = "clmId";
      this.clmId.ReadOnly = true;
      this.clmId.Visible = false;
      gridViewCellStyle1.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.clmRaqam.DefaultCellStyle = gridViewCellStyle1;
      this.clmRaqam.HeaderText = "№";
      this.clmRaqam.Name = "clmRaqam";
      this.clmRaqam.ReadOnly = true;
      this.clmRaqam.Width = 50;
      gridViewCellStyle2.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      this.clmDisplay.DefaultCellStyle = gridViewCellStyle2;
      this.clmDisplay.HeaderText = "Наиминование";
      this.clmDisplay.Name = "clmDisplay";
      this.clmDisplay.ReadOnly = true;
      this.clmDisplay.Width = 400;
      gridViewCellStyle3.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.clmDateandTime.DefaultCellStyle = gridViewCellStyle3;
      this.clmDateandTime.HeaderText = "Дата и времья";
      this.clmDateandTime.Name = "clmDateandTime";
      this.clmDateandTime.ReadOnly = true;
      this.clmDateandTime.Width = 300;
      this.tSbtnRestore.Image = (Image) componentResourceManager.GetObject("tSbtnRestore.Image");
      this.tSbtnRestore.ImageTransparentColor = Color.Magenta;
      this.tSbtnRestore.Name = "tSbtnRestore";
      this.tSbtnRestore.Size = new Size(124, 23);
      this.tSbtnRestore.Text = "Восстановитъ";
      this.tSbtnRestore.Click += new EventHandler(this.tSbtnRestore_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 26);
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(845, 388);
      this.Controls.Add((Control) this.dgvCopyDbList);
      this.Controls.Add((Control) this.toolStrip1);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4, 4, 4, 4);
      this.Name = nameof (CopyDBFormList);
      this.Text = "Список резервное копирование баз данных";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((ISupportInitialize) this.dgvCopyDbList).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
