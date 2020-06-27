// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.RiverListForm
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
  public class RiverListForm : Form
  {
    private IContainer components = (IContainer) null;
    private ToolStrip toolStrip1;
    private ToolStripButton tSBNewRiver;
    private ToolStripButton tSBEditing;
    private ToolStripButton tSBDelete;
    private DataGridView dgvRiverList;
    private DataGridViewTextBoxColumn clmId;
    private DataGridViewTextBoxColumn clmRaqam;
    private DataGridViewTextBoxColumn clmName;
    private DataGridViewTextBoxColumn clmNuber;
    private DataGridViewTextBoxColumn clmStatus;
    private List<RiverClass> rivers;
    private int v;

    public RiverClass river { get; private set; }

    public event EventHandler GetChangeRiver;

    public RiverListForm(List<RiverClass> rivers)
    {
      this.InitializeComponent();
      for (int index = 0; index < rivers.Count; ++index)
        this.dgvRiverList.Rows.Add((object) rivers[index].Id, (object) (index + 1), (object) rivers[index].Name, (object) rivers[index].Number, (object) rivers[index].Status);
    }

    public RiverListForm(List<RiverClass> rivers, byte key)
    {
      this.InitializeComponent();
      for (int index = 0; index < rivers.Count; ++index)
        this.dgvRiverList.Rows.Add((object) rivers[index].Id, (object) (index + 1), (object) rivers[index].Name, (object) rivers[index].Number, (object) rivers[index].Status);
      this.toolStrip1.Visible = false;
    }

    private void tSBNewRiver_Click(object sender, EventArgs e)
    {
      NewRiverForm newRiverForm = new NewRiverForm();
      newRiverForm.GetRiver += new EventHandler(this.GetRiver);
      int num = (int) newRiverForm.ShowDialog();
    }

    private void GetRiver(object sender, EventArgs e)
    {
      this.river = (sender as NewRiverForm).river;
      if (this.river == null)
        return;
      if ((int) this.river.Status == 0)
      {
        // ISSUE: reference to a compiler-generated field
        if (this.GetChangeRiver != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.GetChangeRiver((object) this, e);
        }
        this.river.Id = Form1.StaticId;
        if (this.river.Id < 0)
          return;
        this.river.Status = (byte) 4;
        this.dgvRiverList.Rows.Add((object) this.river.Id, (object) (this.dgvRiverList.RowCount + 1), (object) this.river.Name, (object) this.river.Number, (object) this.river.Status);
      }
      else
      {
        this.river.Status = (byte) 1;
        // ISSUE: reference to a compiler-generated field
        if (this.GetChangeRiver != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.GetChangeRiver((object) this, e);
        }
        this.river.Status = (byte) 4;
        if (Form1.StaticId < 0)
          return;
        this.dgvRiverList.SelectedRows[0].Cells[0].Value = (object) this.river.Id;
        this.dgvRiverList.SelectedRows[0].Cells[2].Value = (object) this.river.Name;
        this.dgvRiverList.SelectedRows[0].Cells[3].Value = (object) this.river.Number;
        this.dgvRiverList.SelectedRows[0].Cells[4].Value = (object) this.river.Status;
      }
    }

    private void tSBEditing_Click(object sender, EventArgs e)
    {
      if (this.dgvRiverList.SelectedRows.Count < 1)
        return;
      try
      {
        this.river = new RiverClass()
        {
          Id = (int) this.dgvRiverList.SelectedRows[0].Cells[0].Value,
          Name = (string) this.dgvRiverList.SelectedRows[0].Cells[2].Value,
          Number = (int) this.dgvRiverList.SelectedRows[0].Cells[3].Value,
          Status = (byte) this.dgvRiverList.SelectedRows[0].Cells[4].Value
        };
        NewRiverForm newRiverForm = new NewRiverForm(this.river);
        newRiverForm.GetRiver += new EventHandler(this.GetRiver);
        int num = (int) newRiverForm.ShowDialog();
        this.river = (RiverClass) null;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void tSBDelete_Click(object sender, EventArgs e)
    {
      if (this.dgvRiverList.SelectedRows.Count < 1)
        return;
      try
      {
        this.river = new RiverClass()
        {
          Id = (int) this.dgvRiverList.SelectedRows[0].Cells[0].Value,
          Name = (string) this.dgvRiverList.SelectedRows[0].Cells[2].Value,
          Number = (int) this.dgvRiverList.SelectedRows[0].Cells[3].Value,
          Status = (byte) 2
        };
        this.dgvRiverList.Rows.RemoveAt(this.dgvRiverList.SelectedRows[0].Index);
        // ISSUE: reference to a compiler-generated field
        if (this.GetChangeRiver != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.GetChangeRiver((object) this, e);
        }
        this.river = (RiverClass) null;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (RiverListForm));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      this.toolStrip1 = new ToolStrip();
      this.tSBNewRiver = new ToolStripButton();
      this.tSBEditing = new ToolStripButton();
      this.tSBDelete = new ToolStripButton();
      this.dgvRiverList = new DataGridView();
      this.clmId = new DataGridViewTextBoxColumn();
      this.clmRaqam = new DataGridViewTextBoxColumn();
      this.clmName = new DataGridViewTextBoxColumn();
      this.clmNuber = new DataGridViewTextBoxColumn();
      this.clmStatus = new DataGridViewTextBoxColumn();
      this.toolStrip1.SuspendLayout();
      ((ISupportInitialize) this.dgvRiverList).BeginInit();
      this.SuspendLayout();
      this.toolStrip1.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.toolStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.tSBNewRiver,
        (ToolStripItem) this.tSBEditing,
        (ToolStripItem) this.tSBDelete
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.RenderMode = ToolStripRenderMode.Professional;
      this.toolStrip1.Size = new Size(1029, 26);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      this.tSBNewRiver.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.tSBNewRiver.Image = (Image) componentResourceManager.GetObject("tSBNewRiver.Image");
      this.tSBNewRiver.ImageTransparentColor = Color.Magenta;
      this.tSBNewRiver.Name = "tSBNewRiver";
      this.tSBNewRiver.Size = new Size(103, 23);
      this.tSBNewRiver.Text = "Новая река";
      this.tSBNewRiver.ToolTipText = "Добавыть Новую реку";
      this.tSBNewRiver.Click += new EventHandler(this.tSBNewRiver_Click);
      this.tSBEditing.Image = (Image) componentResourceManager.GetObject("tSBEditing.Image");
      this.tSBEditing.ImageTransparentColor = Color.Magenta;
      this.tSBEditing.Name = "tSBEditing";
      this.tSBEditing.Size = new Size(128, 23);
      this.tSBEditing.Text = "Редактировать";
      this.tSBEditing.ToolTipText = "Редактировать реку";
      this.tSBEditing.Click += new EventHandler(this.tSBEditing_Click);
      this.tSBDelete.Image = (Image) componentResourceManager.GetObject("tSBDelete.Image");
      this.tSBDelete.ImageTransparentColor = Color.Magenta;
      this.tSBDelete.Name = "tSBDelete";
      this.tSBDelete.Size = new Size(84, 23);
      this.tSBDelete.Text = "Удалить";
      this.tSBDelete.ToolTipText = "Удалить реку";
      this.tSBDelete.Click += new EventHandler(this.tSBDelete_Click);
      this.dgvRiverList.AllowUserToAddRows = false;
      this.dgvRiverList.AllowUserToDeleteRows = false;
      this.dgvRiverList.AllowUserToOrderColumns = true;
      this.dgvRiverList.AllowUserToResizeColumns = false;
      this.dgvRiverList.AllowUserToResizeRows = false;
      this.dgvRiverList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvRiverList.BackgroundColor = Color.White;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvRiverList.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvRiverList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvRiverList.Columns.AddRange((DataGridViewColumn) this.clmId, (DataGridViewColumn) this.clmRaqam, (DataGridViewColumn) this.clmName, (DataGridViewColumn) this.clmNuber, (DataGridViewColumn) this.clmStatus);
      this.dgvRiverList.Location = new Point(12, 43);
      this.dgvRiverList.MultiSelect = false;
      this.dgvRiverList.Name = "dgvRiverList";
      this.dgvRiverList.ReadOnly = true;
      this.dgvRiverList.RowHeadersVisible = false;
      this.dgvRiverList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvRiverList.Size = new Size(1005, 331);
      this.dgvRiverList.TabIndex = 1;
      this.clmId.HeaderText = "Id";
      this.clmId.Name = "clmId";
      this.clmId.ReadOnly = true;
      this.clmId.Visible = false;
      gridViewCellStyle2.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.clmRaqam.DefaultCellStyle = gridViewCellStyle2;
      this.clmRaqam.HeaderText = "№";
      this.clmRaqam.Name = "clmRaqam";
      this.clmRaqam.ReadOnly = true;
      this.clmRaqam.Width = 50;
      gridViewCellStyle3.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.clmName.DefaultCellStyle = gridViewCellStyle3;
      this.clmName.HeaderText = "Наиминование";
      this.clmName.Name = "clmName";
      this.clmName.ReadOnly = true;
      this.clmName.Width = 400;
      gridViewCellStyle4.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      this.clmNuber.DefaultCellStyle = gridViewCellStyle4;
      this.clmNuber.HeaderText = "Код";
      this.clmNuber.Name = "clmNuber";
      this.clmNuber.ReadOnly = true;
      this.clmNuber.Width = 200;
      this.clmStatus.HeaderText = "Status";
      this.clmStatus.Name = "clmStatus";
      this.clmStatus.ReadOnly = true;
      this.clmStatus.Visible = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1029, 386);
      this.Controls.Add((Control) this.dgvRiverList);
      this.Controls.Add((Control) this.toolStrip1);
      this.Name = nameof (RiverListForm);
      this.Text = "Список рек";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((ISupportInitialize) this.dgvRiverList).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
