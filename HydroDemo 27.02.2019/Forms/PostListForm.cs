// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.PostListForm
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
  public class PostListForm : Form
  {
    private byte key = 0;
    private IContainer components = (IContainer) null;
    private List<RiverClass> rivers;
    private List<PostClass> posts;
    private ToolStrip toolStrip1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton tSBNewRiver;
    private ToolStripButton tSBEditing;
    private ToolStripButton tSBDelete;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripComboBox tcbRiverList;
    private DataGridView dgvPostList;
    private DataGridViewTextBoxColumn clmId;
    private DataGridViewTextBoxColumn clmRaqam;
    private DataGridViewTextBoxColumn clmNumberControl;
    private DataGridViewTextBoxColumn clmNameObject;
    private DataGridViewTextBoxColumn clmNameObserve;
    private DataGridViewTextBoxColumn clmDistance;
    private DataGridViewTextBoxColumn clmAdminister;
    private DataGridViewTextBoxColumn clmNumberFolds;
    private DataGridViewTextBoxColumn clmLocationFold;
    private DataGridViewTextBoxColumn clmVertical;
    private DataGridViewTextBoxColumn clmHorizantal;
    private DataGridViewTextBoxColumn clmDate;
    private DataGridViewTextBoxColumn clmStatus;
    private DataGridViewTextBoxColumn clmRiverId;

    public event EventHandler GetChangePost;

    public PostClass post { get; private set; }

    public PostListForm(List<PostClass> posts, List<RiverClass> rivers)
    {
      this.InitializeComponent();
      try
      {
        this.rivers = rivers;
        this.posts = posts;
        for (int index = 0; index < posts.Count; ++index)
          this.dgvPostList.Rows.Add((object) posts[index].Id, (object) (index + 1), (object) posts[index].NumberControl, (object) posts[index].NameObject, (object) posts[index].NameObserve, (object) posts[index].Distance, (object) posts[index].Administer, (object) posts[index].NumberFolds, (object) posts[index].LocationFold, (object) posts[index].Vertical, (object) posts[index].Horizantal, (object) posts[index].Date, (object) posts[index].Status, (object) posts[index].River_Id);
        this.tcbRiverList.ComboBox.DataSource = (object) rivers.OrderBy<RiverClass, string>((Func<RiverClass, string>) (x => x.Name)).ToList<RiverClass>();
        this.tcbRiverList.ComboBox.DisplayMember = "Name";
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public PostListForm(List<PostClass> posts, List<RiverClass> rivers, byte key)
    {
      this.InitializeComponent();
      try
      {
        this.rivers = rivers;
        this.posts = posts;
        for (int index = 0; index < posts.Count; ++index)
          this.dgvPostList.Rows.Add((object) posts[index].Id, (object) (index + 1), (object) posts[index].NumberControl, (object) posts[index].NameObject, (object) posts[index].NameObserve, (object) posts[index].Distance, (object) posts[index].Administer, (object) posts[index].NumberFolds, (object) posts[index].LocationFold, (object) posts[index].Vertical, (object) posts[index].Horizantal, (object) posts[index].Date, (object) posts[index].Status, (object) posts[index].River_Id);
        this.tcbRiverList.ComboBox.DataSource = (object) rivers.OrderBy<RiverClass, string>((Func<RiverClass, string>) (x => x.Name)).ToList<RiverClass>();
        this.tcbRiverList.ComboBox.DisplayMember = "Name";
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
      this.toolStrip1.Visible = false;
    }

    private void PostListForm_Load(object sender, EventArgs e)
    {
    }

    private void tSBNewRiver_Click(object sender, EventArgs e)
    {
      NewPostForm newPostForm = new NewPostForm(this.rivers.ToArray());
      newPostForm.GetPost += new EventHandler(this.GetPost);
      int num = (int) newPostForm.ShowDialog();
    }

    private void GetPost(object sender, EventArgs e)
    {
      try
      {
        this.post = (sender as NewPostForm).post;
        if (this.post == null)
          return;
        if ((int) this.post.Status == 0)
        {
          // ISSUE: reference to a compiler-generated field
          if (this.GetChangePost != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.GetChangePost((object) this, e);
          }
          //this.post.Id = Form1.StaticId;
          if (this.post.Id < 0)
            return;
          this.post.Status = (byte) 4;
          this.dgvPostList.Rows.Add((object) this.post.Id, (object) (this.dgvPostList.RowCount + 1), (object) this.post.NumberControl, (object) this.post.NameObject, (object) this.post.NameObserve, (object) this.post.Distance, (object) this.post.Administer, (object) this.post.NumberFolds, (object) this.post.LocationFold, (object) this.post.Vertical, (object) this.post.Horizantal, (object) this.post.Date, (object) this.post.Status, (object) this.post.River_Id);
        }
        else
        {
          this.post.Status = (byte) 1;
          // ISSUE: reference to a compiler-generated field
          if (this.GetChangePost != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.GetChangePost((object) this, e);
          }
          this.post.Status = (byte) 4;
          if (Form1.StaticId < 0)
            return;
          this.dgvPostList.SelectedRows[0].Cells[2].Value = (object) this.post.NumberControl;
          this.dgvPostList.SelectedRows[0].Cells[3].Value = (object) this.post.NameObject;
          this.dgvPostList.SelectedRows[0].Cells[4].Value = (object) this.post.NameObserve;
          this.dgvPostList.SelectedRows[0].Cells[5].Value = (object) this.post.Distance;
          this.dgvPostList.SelectedRows[0].Cells[6].Value = (object) this.post.Administer;
          this.dgvPostList.SelectedRows[0].Cells[7].Value = (object) this.post.NumberFolds;
          this.dgvPostList.SelectedRows[0].Cells[8].Value = (object) this.post.LocationFold;
          this.dgvPostList.SelectedRows[0].Cells[9].Value = (object) this.post.Vertical;
          this.dgvPostList.SelectedRows[0].Cells[10].Value = (object) this.post.Horizantal;
          this.dgvPostList.SelectedRows[0].Cells[11].Value = (object) this.post.Date;
          this.dgvPostList.SelectedRows[0].Cells[12].Value = (object) this.post.Status;
          this.dgvPostList.SelectedRows[0].Cells[13].Value = (object) this.post.River_Id;
        }
        this.post = (PostClass) null;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void tSBEditing_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dgvPostList.SelectedRows.Count < 1)
          return;
        this.post = new PostClass()
        {
          Id = (int) this.dgvPostList.SelectedRows[0].Cells[0].Value,
          NumberControl = (int) this.dgvPostList.SelectedRows[0].Cells[2].Value,
          NameObject = (string) this.dgvPostList.SelectedRows[0].Cells[3].Value,
          NameObserve = (string) this.dgvPostList.SelectedRows[0].Cells[4].Value,
          Distance = (double) this.dgvPostList.SelectedRows[0].Cells[5].Value,
          Administer = (string) this.dgvPostList.SelectedRows[0].Cells[6].Value,
          NumberFolds = (int) this.dgvPostList.SelectedRows[0].Cells[7].Value,
          LocationFold = (string) this.dgvPostList.SelectedRows[0].Cells[8].Value,
          Vertical = (string) this.dgvPostList.SelectedRows[0].Cells[9].Value,
          Horizantal = (string) this.dgvPostList.SelectedRows[0].Cells[10].Value,
          Date = (int) this.dgvPostList.SelectedRows[0].Cells[11].Value,
          Status = (byte) 1,
          River_Id = (int) this.dgvPostList.SelectedRows[0].Cells[13].Value
        };
        NewPostForm newPostForm = new NewPostForm(this.post, this.rivers.ToArray());
        newPostForm.GetPost += new EventHandler(this.GetPost);
        int num = (int) newPostForm.ShowDialog();
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
        if (this.dgvPostList.SelectedRows.Count < 1)
          return;
        this.post = new PostClass()
        {
          Id = (int) this.dgvPostList.SelectedRows[0].Cells[0].Value,
          Status = (byte) 2
        };
        this.dgvPostList.Rows.RemoveAt(this.dgvPostList.SelectedRows[0].Index);
        // ISSUE: reference to a compiler-generated field
        if (this.GetChangePost == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.GetChangePost((object) this, e);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void tcbRiverList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ((int) this.key == 0)
      {
        this.key = (byte) 1;
      }
      else
      {
        try
        {
          this.dgvPostList.Rows.Clear();
          int id = (this.tcbRiverList.ComboBox.SelectedItem as RiverClass).Id;
          for (int index = 0; index < this.posts.Count; ++index)
          {
            if (this.posts[index].River_Id == id)
              this.dgvPostList.Rows.Add((object) this.posts[index].Id, (object) (index + 1), (object) this.posts[index].NumberControl, (object) this.posts[index].NameObject, (object) this.posts[index].NameObserve, (object) this.posts[index].Distance, (object) this.posts[index].Administer, (object) this.posts[index].NumberFolds, (object) this.posts[index].LocationFold, (object) this.posts[index].Vertical, (object) this.posts[index].Horizantal, (object) this.posts[index].Date, (object) this.posts[index].Status, (object) this.posts[index].River_Id);
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.ToString());
        }
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (PostListForm));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
      this.toolStrip1 = new ToolStrip();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.tSBNewRiver = new ToolStripButton();
      this.tSBEditing = new ToolStripButton();
      this.tSBDelete = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.tcbRiverList = new ToolStripComboBox();
      this.dgvPostList = new DataGridView();
      this.clmId = new DataGridViewTextBoxColumn();
      this.clmRaqam = new DataGridViewTextBoxColumn();
      this.clmNumberControl = new DataGridViewTextBoxColumn();
      this.clmNameObject = new DataGridViewTextBoxColumn();
      this.clmNameObserve = new DataGridViewTextBoxColumn();
      this.clmDistance = new DataGridViewTextBoxColumn();
      this.clmAdminister = new DataGridViewTextBoxColumn();
      this.clmNumberFolds = new DataGridViewTextBoxColumn();
      this.clmLocationFold = new DataGridViewTextBoxColumn();
      this.clmVertical = new DataGridViewTextBoxColumn();
      this.clmHorizantal = new DataGridViewTextBoxColumn();
      this.clmDate = new DataGridViewTextBoxColumn();
      this.clmStatus = new DataGridViewTextBoxColumn();
      this.clmRiverId = new DataGridViewTextBoxColumn();
      this.toolStrip1.SuspendLayout();
      ((ISupportInitialize) this.dgvPostList).BeginInit();
      this.SuspendLayout();
      this.toolStrip1.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.toolStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.tSBNewRiver,
        (ToolStripItem) this.tSBEditing,
        (ToolStripItem) this.tSBDelete,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.tcbRiverList
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(1209, 26);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 26);
      this.tSBNewRiver.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.tSBNewRiver.Image = (Image) componentResourceManager.GetObject("tSBNewRiver.Image");
      this.tSBNewRiver.ImageTransparentColor = Color.Magenta;
      this.tSBNewRiver.Name = "tSBNewRiver";
      this.tSBNewRiver.Size = new Size(111, 23);
      this.tSBNewRiver.Text = "Новый пост";
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
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 26);
      this.tcbRiverList.Name = "tcbRiverList";
      this.tcbRiverList.Size = new Size(400, 26);
      this.tcbRiverList.SelectedIndexChanged += new EventHandler(this.tcbRiverList_SelectedIndexChanged);
      this.dgvPostList.AllowUserToAddRows = false;
      this.dgvPostList.AllowUserToDeleteRows = false;
      this.dgvPostList.AllowUserToOrderColumns = true;
      this.dgvPostList.AllowUserToResizeColumns = false;
      this.dgvPostList.AllowUserToResizeRows = false;
      this.dgvPostList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvPostList.BackgroundColor = Color.White;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvPostList.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvPostList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPostList.Columns.AddRange((DataGridViewColumn) this.clmId, (DataGridViewColumn) this.clmRaqam, (DataGridViewColumn) this.clmNumberControl, (DataGridViewColumn) this.clmNameObject, (DataGridViewColumn) this.clmNameObserve, (DataGridViewColumn) this.clmDistance, (DataGridViewColumn) this.clmAdminister, (DataGridViewColumn) this.clmNumberFolds, (DataGridViewColumn) this.clmLocationFold, (DataGridViewColumn) this.clmVertical, (DataGridViewColumn) this.clmHorizantal, (DataGridViewColumn) this.clmDate, (DataGridViewColumn) this.clmStatus, (DataGridViewColumn) this.clmRiverId);
      this.dgvPostList.Location = new Point(12, 41);
      this.dgvPostList.MultiSelect = false;
      this.dgvPostList.Name = "dgvPostList";
      this.dgvPostList.ReadOnly = true;
      this.dgvPostList.RowHeadersVisible = false;
      this.dgvPostList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvPostList.Size = new Size(1185, 347);
      this.dgvPostList.TabIndex = 2;
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
      this.clmNumberControl.DefaultCellStyle = gridViewCellStyle3;
      this.clmNumberControl.HeaderText = "Номер пункта контроля";
      this.clmNumberControl.Name = "clmNumberControl";
      this.clmNumberControl.ReadOnly = true;
      this.clmNumberControl.Width = 80;
      gridViewCellStyle4.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      this.clmNameObject.DefaultCellStyle = gridViewCellStyle4;
      this.clmNameObject.HeaderText = "Наименование водного объекта";
      this.clmNameObject.Name = "clmNameObject";
      this.clmNameObject.ReadOnly = true;
      this.clmNameObject.Width = 150;
      gridViewCellStyle5.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      gridViewCellStyle5.WrapMode = DataGridViewTriState.True;
      this.clmNameObserve.DefaultCellStyle = gridViewCellStyle5;
      this.clmNameObserve.HeaderText = "Наименование пункта наблюдений";
      this.clmNameObserve.Name = "clmNameObserve";
      this.clmNameObserve.ReadOnly = true;
      this.clmNameObserve.Width = 150;
      gridViewCellStyle6.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle6.WrapMode = DataGridViewTriState.True;
      this.clmDistance.DefaultCellStyle = gridViewCellStyle6;
      this.clmDistance.HeaderText = "Расстояние от устья, км";
      this.clmDistance.Name = "clmDistance";
      this.clmDistance.ReadOnly = true;
      gridViewCellStyle7.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle7.WrapMode = DataGridViewTriState.True;
      this.clmAdminister.DefaultCellStyle = gridViewCellStyle7;
      this.clmAdminister.HeaderText = "Административная принадлежность";
      this.clmAdminister.Name = "clmAdminister";
      this.clmAdminister.ReadOnly = true;
      this.clmAdminister.Width = 200;
      gridViewCellStyle8.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle8.WrapMode = DataGridViewTriState.True;
      this.clmNumberFolds.DefaultCellStyle = gridViewCellStyle8;
      this.clmNumberFolds.HeaderText = "Номер створы";
      this.clmNumberFolds.Name = "clmNumberFolds";
      this.clmNumberFolds.ReadOnly = true;
      this.clmNumberFolds.Width = 80;
      gridViewCellStyle9.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle9.WrapMode = DataGridViewTriState.True;
      this.clmLocationFold.DefaultCellStyle = gridViewCellStyle9;
      this.clmLocationFold.HeaderText = "Расположение створов";
      this.clmLocationFold.Name = "clmLocationFold";
      this.clmLocationFold.ReadOnly = true;
      this.clmLocationFold.Width = 200;
      gridViewCellStyle10.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle10.WrapMode = DataGridViewTriState.True;
      this.clmVertical.DefaultCellStyle = gridViewCellStyle10;
      this.clmVertical.HeaderText = "Вертикали";
      this.clmVertical.Name = "clmVertical";
      this.clmVertical.ReadOnly = true;
      this.clmVertical.Width = 80;
      gridViewCellStyle11.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle11.WrapMode = DataGridViewTriState.True;
      this.clmHorizantal.DefaultCellStyle = gridViewCellStyle11;
      this.clmHorizantal.HeaderText = "Горизонты";
      this.clmHorizantal.Name = "clmHorizantal";
      this.clmHorizantal.ReadOnly = true;
      this.clmHorizantal.Width = 80;
      gridViewCellStyle12.Font = new Font("Times New Roman", 12f);
      gridViewCellStyle12.WrapMode = DataGridViewTriState.True;
      this.clmDate.DefaultCellStyle = gridViewCellStyle12;
      this.clmDate.HeaderText = "Период ";
      this.clmDate.Name = "clmDate";
      this.clmDate.ReadOnly = true;
      this.clmDate.Width = 80;
      this.clmStatus.HeaderText = "Status";
      this.clmStatus.Name = "clmStatus";
      this.clmStatus.ReadOnly = true;
      this.clmStatus.Visible = false;
      this.clmStatus.Width = 10;
      this.clmRiverId.HeaderText = "River Id";
      this.clmRiverId.Name = "clmRiverId";
      this.clmRiverId.ReadOnly = true;
      this.clmRiverId.Visible = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ButtonHighlight;
      this.ClientSize = new Size(1209, 400);
      this.Controls.Add((Control) this.dgvPostList);
      this.Controls.Add((Control) this.toolStrip1);
      this.Name = nameof (PostListForm);
      this.Text = "Список постов";
      this.Load += new EventHandler(this.PostListForm_Load);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((ISupportInitialize) this.dgvPostList).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
