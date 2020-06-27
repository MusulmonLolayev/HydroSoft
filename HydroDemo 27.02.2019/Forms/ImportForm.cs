// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.ImportForm
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
    public class ImportForm : Form
    {
        private IContainer components = (IContainer)null;
        private List<PostClass> posts;
        private Label label1;
        private TextBox tbFileName;
        private Button btnFile;
        private Label label2;
        private Label label3;
        private ComboBox cbRiverList;
        private ComboBox cbPostList;
        private Button btnStart;

        public event EventHandler GetFileName;

        public string filename { get; private set; }

        public int Post_Id { get; private set; }

        public ImportForm(List<RiverClass> rivers, List<PostClass> posts)
        {
            this.InitializeComponent();
            this.posts = posts;
            this.cbRiverList.DataSource = (object)rivers.OrderBy<RiverClass, string>((Func<RiverClass, string>)(x => x.Name)).ToList<RiverClass>();
            this.cbRiverList.DisplayMember = "Name";
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|XLS files (*.xls, *.xlt)|*.xls;*.xlt";
            openFileDialog.Title = "Укажите Excel документ";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.tbFileName.Text = openFileDialog.FileName;
        }

        private void cbRiverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int River_Id = (this.cbRiverList.SelectedItem as RiverClass).Id;
                this.cbPostList.DataSource = (object)null;
                this.cbPostList.DataSource = (object)this.posts.Where<PostClass>((Func<PostClass, bool>)(x => x.River_Id == River_Id)).OrderBy<PostClass, string>((Func<PostClass, string>)(x => x.NameObserve)).ToList<PostClass>();
                this.cbPostList.DisplayMember = "NameObserve";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.tbFileName.Text == "" || this.cbPostList.SelectedItem == null)
            {
                int num = (int)MessageBox.Show("Ошибка");
            }
            else
            {
                this.filename = this.tbFileName.Text;
                this.Post_Id = (this.cbPostList.SelectedItem as PostClass).Id;
                // ISSUE: reference to a compiler-generated field
                if (this.GetFileName != null)
                {
                    // ISSUE: reference to a compiler-generated field
                    this.GetFileName((object)this, e);
                }
                this.Close();
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
            this.label1 = new Label();
            this.tbFileName = new TextBox();
            this.btnFile = new Button();
            this.label2 = new Label();
            this.label3 = new Label();
            this.cbRiverList = new ComboBox();
            this.cbPostList = new ComboBox();
            this.btnStart = new Button();
            this.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файл";
            this.tbFileName.Enabled = false;
            this.tbFileName.Location = new Point(63, 20);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.RightToLeft = RightToLeft.Yes;
            this.tbFileName.Size = new Size(274, 26);
            this.tbFileName.TabIndex = 1;
            this.tbFileName.TextAlign = HorizontalAlignment.Right;
            this.btnFile.Location = new Point(343, 20);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new Size(75, 31);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "Обзор";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new EventHandler(this.btnFile_Click);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new Size(39, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Река";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new Size(42, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пост";
            this.cbRiverList.FormattingEnabled = true;
            this.cbRiverList.Location = new Point(63, 69);
            this.cbRiverList.Name = "cbRiverList";
            this.cbRiverList.Size = new Size(274, 27);
            this.cbRiverList.TabIndex = 5;
            this.cbRiverList.SelectedIndexChanged += new EventHandler(this.cbRiverList_SelectedIndexChanged);
            this.cbPostList.FormattingEnabled = true;
            this.cbPostList.Location = new Point(63, 107);
            this.cbPostList.Name = "cbPostList";
            this.cbPostList.Size = new Size(274, 27);
            this.cbPostList.TabIndex = 6;
            this.btnStart.Location = new Point(163, 144);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new Size(75, 38);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new EventHandler(this.btnStart_Click);
            this.AutoScaleDimensions = new SizeF(9f, 19f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(437, 194);
            this.Controls.Add((Control)this.btnStart);
            this.Controls.Add((Control)this.cbPostList);
            this.Controls.Add((Control)this.cbRiverList);
            this.Controls.Add((Control)this.label3);
            this.Controls.Add((Control)this.label2);
            this.Controls.Add((Control)this.btnFile);
            this.Controls.Add((Control)this.tbFileName);
            this.Controls.Add((Control)this.label1);
            this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.Margin = new Padding(4, 4, 4, 4);
            this.MaximumSize = new Size(453, 233);
            this.MinimumSize = new Size(453, 233);
            this.Name = nameof(ImportForm);
            this.Text = "Импорт базы с Excel";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
