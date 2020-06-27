// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.NewPostForm
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
  public class NewPostForm : Form
  {
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private TextBox tbNumberControl;
    private TextBox tbNameObject;
    private TextBox tbNameObserve;
    private TextBox tbDistance;
    private TextBox tbAdminister;
    private TextBox tbNumberFolds;
    private TextBox tbLocationFold;
    private TextBox tbVertical;
    private TextBox tbHorizantal;
    private TextBox tbDate;
    private Button button1;
    private Button button2;
    private Label label11;
    private ComboBox comboBox1;

    public PostClass post { get; private set; }

    public event EventHandler GetPost;

    public NewPostForm(RiverClass[] rivers)
    {
      this.InitializeComponent();
      this.post = (PostClass) null;
      this.comboBox1.DataSource = (object) ((IEnumerable<RiverClass>) rivers).OrderBy<RiverClass, string>((Func<RiverClass, string>) (x => x.Name)).ToList<RiverClass>();
      this.comboBox1.DisplayMember = "Name";
    }

    public NewPostForm(PostClass post, RiverClass[] rivers)
    {
      this.InitializeComponent();
      try
      {
        this.comboBox1.DataSource = (object) rivers;
        this.comboBox1.DisplayMember = "Name";
        this.post = post;
        TextBox tbNumberControl = this.tbNumberControl;
        int num = post.NumberControl;
        string str1 = num.ToString();
        tbNumberControl.Text = str1;
        this.tbNameObject.Text = post.NameObject;
        this.tbNameObserve.Text = post.NameObserve;
        this.tbDistance.Text = post.Distance.ToString();
        this.tbAdminister.Text = post.Administer;
        TextBox tbNumberFolds = this.tbNumberFolds;
        num = post.NumberFolds;
        string str2 = num.ToString();
        tbNumberFolds.Text = str2;
        this.tbLocationFold.Text = post.LocationFold;
        this.tbVertical.Text = post.Vertical;
        this.tbHorizantal.Text = post.Horizantal;
        TextBox tbDate = this.tbDate;
        num = post.Date;
        string str3 = num.ToString();
        tbDate.Text = str3;
        for (int index = 0; index < this.comboBox1.Items.Count; index = num + 1)
        {
          if ((this.comboBox1.Items[index] as RiverClass).Id == post.River_Id)
            this.comboBox1.SelectedIndex = index;
          num = index;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.post == null)
        {
          this.post = new PostClass();
          this.post.Id = -1;
        }
        int result1;
        if (!int.TryParse(this.tbNumberControl.Text, out result1))
        {
          int num1 = (int) MessageBox.Show("Номер пункта контроля должно целое число");
        }
        else
        {
          this.post.NumberControl = result1;
          if (this.tbNameObject.Text == "")
          {
            int num2 = (int) MessageBox.Show("Наименование водного объекта не заполнение");
          }
          else
          {
            this.post.NameObject = this.tbNameObject.Text;
            if (this.tbNameObserve.Text == "")
            {
              int num3 = (int) MessageBox.Show("Наименование пункта наблюдений не заполнение");
            }
            else
            {
              this.post.NameObserve = this.tbNameObserve.Text;
              double result2 = 0.0;
              if (!double.TryParse(this.tbDistance.Text, out result2))
              {
                int num4 = (int) MessageBox.Show("Расстояние от устья, км должно число");
              }
              else
              {
                this.post.Distance = result2;
                if (this.tbAdminister.Text == "")
                {
                  int num5 = (int) MessageBox.Show("Наименование водного объекта не заполнение");
                }
                else
                {
                  this.post.Administer = this.tbAdminister.Text;
                  if (!int.TryParse(this.tbNumberFolds.Text, out result1))
                  {
                    int num6 = (int) MessageBox.Show("Номер створы должно целое число");
                  }
                  else
                  {
                    this.post.NumberFolds = result1;
                    if (this.tbLocationFold.Text == "")
                    {
                      int num7 = (int) MessageBox.Show("Расположение створов не заполнение");
                    }
                    else
                    {
                      this.post.LocationFold = this.tbLocationFold.Text;
                      if (this.tbVertical.Text == "")
                      {
                        int num8 = (int) MessageBox.Show("Вертикали не заполнение");
                      }
                      else
                      {
                        this.post.Vertical = this.tbVertical.Text;
                        if (this.tbHorizantal.Text == "")
                        {
                          int num9 = (int) MessageBox.Show("Горизонты не заполнение");
                        }
                        else
                        {
                          this.post.Horizantal = this.tbHorizantal.Text;
                          if (!int.TryParse(this.tbDate.Text, out result1))
                          {
                            int num10 = (int) MessageBox.Show("Период должно целое число");
                          }
                          else
                          {
                            this.post.Date = result1;
                            this.post.River_Id = (this.comboBox1.SelectedItem as RiverClass).Id;
                            this.post.Status = this.post.Id >= 0 ? (byte) 1 : (byte) 0;
                            // ISSUE: reference to a compiler-generated field
                            if (this.GetPost != null)
                            {
                              // ISSUE: reference to a compiler-generated field
                              this.GetPost((object) this, e);
                            }
                            this.Close();
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void button1_Click(object sender, EventArgs e)
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
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.tbNumberControl = new TextBox();
      this.tbNameObject = new TextBox();
      this.tbNameObserve = new TextBox();
      this.tbDistance = new TextBox();
      this.tbAdminister = new TextBox();
      this.tbNumberFolds = new TextBox();
      this.tbLocationFold = new TextBox();
      this.tbVertical = new TextBox();
      this.tbHorizantal = new TextBox();
      this.tbDate = new TextBox();
      this.button1 = new Button();
      this.button2 = new Button();
      this.label11 = new Label();
      this.comboBox1 = new ComboBox();
      this.SuspendLayout();
      this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 19);
      this.label1.Name = "label1";
      this.label1.Size = new Size(168, 19);
      this.label1.TabIndex = 0;
      this.label1.Text = "Номер пункта контроля";
      this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(12, 57);
      this.label2.Name = "label2";
      this.label2.Size = new Size(225, 19);
      this.label2.TabIndex = 1;
      this.label2.Text = "Наименование водного объекта";
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(12, 92);
      this.label3.Name = "label3";
      this.label3.Size = new Size(249, 19);
      this.label3.TabIndex = 2;
      this.label3.Text = "Наименование пункта наблюдений";
      this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(12, 131);
      this.label4.Name = "label4";
      this.label4.Size = new Size(169, 19);
      this.label4.TabIndex = 3;
      this.label4.Text = "Расстояние от устья, км";
      this.label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(12, 168);
      this.label5.Name = "label5";
      this.label5.Size = new Size(259, 19);
      this.label5.TabIndex = 4;
      this.label5.Text = "Административная принадлежность";
      this.label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(12, 201);
      this.label6.Name = "label6";
      this.label6.Size = new Size(110, 19);
      this.label6.TabIndex = 5;
      this.label6.Text = "Номер створы.";
      this.label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(12, 231);
      this.label7.Name = "label7";
      this.label7.Size = new Size(166, 19);
      this.label7.TabIndex = 6;
      this.label7.Text = "Расположение створов";
      this.label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label8.AutoSize = true;
      this.label8.Location = new Point(12, 262);
      this.label8.Name = "label8";
      this.label8.Size = new Size(81, 19);
      this.label8.TabIndex = 7;
      this.label8.Text = "Вертикали";
      this.label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label9.AutoSize = true;
      this.label9.Location = new Point(12, 297);
      this.label9.Name = "label9";
      this.label9.Size = new Size(83, 19);
      this.label9.TabIndex = 8;
      this.label9.Text = "Горизонты";
      this.label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(12, 333);
      this.label10.Name = "label10";
      this.label10.Size = new Size(64, 19);
      this.label10.TabIndex = 9;
      this.label10.Text = "Период ";
      this.tbNumberControl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbNumberControl.Location = new Point(288, 19);
      this.tbNumberControl.Name = "tbNumberControl";
      this.tbNumberControl.Size = new Size(473, 26);
      this.tbNumberControl.TabIndex = 10;
      this.tbNameObject.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbNameObject.Location = new Point(288, 53);
      this.tbNameObject.Name = "tbNameObject";
      this.tbNameObject.Size = new Size(473, 26);
      this.tbNameObject.TabIndex = 11;
      this.tbNameObserve.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbNameObserve.Location = new Point(288, 92);
      this.tbNameObserve.Name = "tbNameObserve";
      this.tbNameObserve.Size = new Size(473, 26);
      this.tbNameObserve.TabIndex = 12;
      this.tbDistance.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbDistance.Location = new Point(288, 134);
      this.tbDistance.Name = "tbDistance";
      this.tbDistance.Size = new Size(473, 26);
      this.tbDistance.TabIndex = 13;
      this.tbAdminister.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbAdminister.Location = new Point(288, 166);
      this.tbAdminister.Name = "tbAdminister";
      this.tbAdminister.Size = new Size(473, 26);
      this.tbAdminister.TabIndex = 14;
      this.tbNumberFolds.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbNumberFolds.Location = new Point(288, 197);
      this.tbNumberFolds.Name = "tbNumberFolds";
      this.tbNumberFolds.Size = new Size(473, 26);
      this.tbNumberFolds.TabIndex = 15;
      this.tbLocationFold.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbLocationFold.Location = new Point(288, 231);
      this.tbLocationFold.Name = "tbLocationFold";
      this.tbLocationFold.Size = new Size(473, 26);
      this.tbLocationFold.TabIndex = 16;
      this.tbVertical.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbVertical.Location = new Point(288, 265);
      this.tbVertical.Name = "tbVertical";
      this.tbVertical.Size = new Size(473, 26);
      this.tbVertical.TabIndex = 17;
      this.tbHorizantal.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbHorizantal.Location = new Point(288, 297);
      this.tbHorizantal.Name = "tbHorizantal";
      this.tbHorizantal.Size = new Size(473, 26);
      this.tbHorizantal.TabIndex = 18;
      this.tbDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tbDate.Location = new Point(288, 329);
      this.tbDate.Name = "tbDate";
      this.tbDate.Size = new Size(473, 26);
      this.tbDate.TabIndex = 19;
      this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.button1.Location = new Point(20, 425);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 36);
      this.button1.TabIndex = 20;
      this.button1.Text = "Отмена";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.button2.Location = new Point(665, 423);
      this.button2.Name = "button2";
      this.button2.Size = new Size(96, 36);
      this.button2.TabIndex = 21;
      this.button2.Text = "Сохраныть";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.label11.AutoSize = true;
      this.label11.Location = new Point(16, 377);
      this.label11.Name = "label11";
      this.label11.Size = new Size(39, 19);
      this.label11.TabIndex = 22;
      this.label11.Text = "Река";
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(288, 369);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(473, 27);
      this.comboBox1.TabIndex = 23;
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(773, 473);
      this.Controls.Add((Control) this.comboBox1);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.tbDate);
      this.Controls.Add((Control) this.tbHorizantal);
      this.Controls.Add((Control) this.tbVertical);
      this.Controls.Add((Control) this.tbLocationFold);
      this.Controls.Add((Control) this.tbNumberFolds);
      this.Controls.Add((Control) this.tbAdminister);
      this.Controls.Add((Control) this.tbDistance);
      this.Controls.Add((Control) this.tbNameObserve);
      this.Controls.Add((Control) this.tbNameObject);
      this.Controls.Add((Control) this.tbNumberControl);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximumSize = new Size(789, 512);
      this.MinimumSize = new Size(789, 512);
      this.Name = nameof (NewPostForm);
      this.Text = "Новый пост";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
