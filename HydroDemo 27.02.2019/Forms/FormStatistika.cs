// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.FormStatistika
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
  public class FormStatistika : Form
  {
    private IContainer components = (IContainer) null;
    private double[] aa;
    private DataGridView dgvResult;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem эксроптToolStripMenuItem;
    private DataGridViewTextBoxColumn clmRazrezX;
    private DataGridViewTextBoxColumn clmGlubinaX;
        private string format_text = "N2"; 
    public FormStatistika(double[] a)
    {
      this.InitializeComponent();
      this.aa = a;
      this.Hisob(a);
    }

    private void Hisob(double[] a)
    {
      double num1 = ((IEnumerable<double>) a).Sum() / (double) a.Length;
      this.dgvResult.Rows.Add((object) "Средний значение", num1.ToString(format_text));
      double num2 = 0.0;
      for (int index = 0; index < a.Length; ++index)
        num2 += (num1 - a[index]) * (num1 - a[index]);
      double num3 = Math.Sqrt(num2 / (double) a.Length);
      this.dgvResult.Rows.Add((object) "Средний квадратный сторонний значение", (object) ("±" + (object) num3.ToString(format_text)));
      this.dgvResult.Rows.Add((object) "Коэффицент вариации", (object) ("±" + (object) (100.0 * num3 / num1).ToString(format_text)));
      double num4 = Math.Sqrt((double) a.Length);
      double num5 = num3 / num4;
      this.dgvResult.Rows.Add((object) "Средний погрешностъ", (object) ("±" + (object) num5.ToString(format_text)));
      this.dgvResult.Rows.Add((object) "Аналитический показатель", (object) (100.0 * num5 / num1).ToString(format_text));
      this.dgvResult.Rows.Add((object) "Доверие уверенности", (object) (num1 / num5).ToString(format_text));
      this.dgvResult.Rows.Add((object) "Количество данных", (object) a.Length);
      this.dgvResult.Rows.Add((object) "Сумма данных", (object) ((IEnumerable<double>) a).Sum().ToString(format_text));
    }

    private void Hisob1(double[] a, double[] b)
    {
      if (a == null || b == null || a.Length == 0 || b.Length == 0)
      {
        int num = (int) MessageBox.Show("Ошибка данных");
        this.Close();
      }
      else
      {
        this.dgvResult.Rows.Add((object) "Статический корреляционный анализ: ", null);
        this.dgvResult.Rows[this.dgvResult.RowCount - 1].DefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 11f, FontStyle.Bold);
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        double num4 = ((IEnumerable<double>) a).Sum() / (double) a.Length;
        double num5 = ((IEnumerable<double>) b).Sum() / (double) b.Length;
        double[] numArray1 = new double[a.Length];
        double[] numArray2 = new double[a.Length];
        for (int index = 0; index < a.Length; ++index)
        {
          numArray1[index] = a[index] - num4;
          numArray2[index] = numArray1[index] * numArray1[index];
          num1 += numArray2[index];
        }
        this.dgvResult.Rows.Add((object) "Сумма ax квадрата", (object) num1.ToString(format_text));
        double[] numArray3 = new double[b.Length];
        double[] numArray4 = new double[b.Length];
        for (int index = 0; index < b.Length; ++index)
        {
          numArray3[index] = b[index] - num5;
          numArray4[index] = numArray3[index] * numArray3[index];
          num2 += numArray4[index];
        }
        this.dgvResult.Rows.Add((object) "Сумма bx квадрата", (object) num2.ToString(format_text));
        double[] numArray5 = new double[a.Length];
        for (int index = 0; index < a.Length; ++index)
        {
          numArray5[index] = numArray1[index] * numArray3[index];
          num3 += numArray5[index];
        }
        this.dgvResult.Rows.Add((object) "Сумма ax * bx квадрата", (object) num3.ToString(format_text));
        double num6 = num3 / Math.Sqrt(num1 * num2);
        this.dgvResult.Rows.Add((object) "Коэффциент корреляции ", (object) num6.ToString(format_text));
        double num7 = (1.0 - num6 * num6) / Math.Sqrt((double) a.Length);
        this.dgvResult.Rows.Add((object) "Погрешностъ коэффциента корреляции", (object) ("±" + (object) num7.ToString(format_text)));
        this.dgvResult.Rows.Add((object) "Уверенность показатели", (object) (num6 / num7).ToString(format_text));
        this.dgvResult.Rows.Add((object) "Обобщённый статический аналаиз для первого значение: ", null);
        this.dgvResult.Rows[this.dgvResult.RowCount - 1].DefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 11f, FontStyle.Bold);
        this.Hisob(a);
        this.dgvResult.Rows.Add((object) "Обобщённый статический аналаиз для второго значение: ", null);
        this.dgvResult.Rows[this.dgvResult.RowCount - 1].DefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 11f, FontStyle.Bold);
        this.Hisob(b);
      }
    }

    public FormStatistika(double[] a, double[] b)
    {
      this.InitializeComponent();
      this.Hisob1(a, b);
      this.dgvResult.Visible = true;
      this.Text = "Результат по корреляционную анализу";
    }

    private void meniItemExporttoExel_Click(object sender, EventArgs e)
    {
      try
      {
                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                application.Workbooks.Add((object)Missing.Value);
                _Worksheet worksheet = (_Worksheet)(application.Sheets.Add(System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing) as Worksheet);
                int num1 = 1;
                for (int index = 0; index < this.dgvResult.RowCount; ++index)
                {
                    if (this.dgvResult.Rows[index].Cells[1].Value == null)
                    {
                        worksheet.Cells[(object)num1, (object)1] = this.dgvResult.Rows[index].Cells[0].Value;
                        Range range = worksheet.get_Range((object)("A" + (object)num1), (object)("B" + (object)num1));
                        range.Merge(System.Type.Missing);
                        range.Font.Bold = (object)true;
                        ++num1;
                        worksheet.Cells[(object)num1, (object)1] = (object)"Наименование";
                        worksheet.Cells[(object)num1, (object)2] = (object)"Значение";
                    }
                    else
                    {
                        string str = this.dgvResult.Rows[index].Cells[1].Value.ToString();
                        worksheet.Cells[(object)num1, (object)1] = this.dgvResult.Rows[index].Cells[0].Value;
                        if (str.IndexOf(',') > 0 && str.IndexOf(',') + 3 < str.Length)
                            worksheet.Cells[(object)num1, (object)2] = str.Substring(0, str.IndexOf(',') + 3);
                        else
                            worksheet.Cells[(object)num1, (object)2] = str;
                        ++num1;
                    }
                }
                int num2 = num1 - 1;
                Range range1 = worksheet.get_Range((object)"A1", (object)("B" + (object)num2));
                range1.WrapText = (object)true;
                range1.Font.Size = (object)14;
                range1.VerticalAlignment = (object)XlVAlign.xlVAlignCenter;
                range1.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                range1.Borders.Weight = (object)2;
                range1.Font.Name = (object)"Times New Roman";
                range1.ColumnWidth = (object)35;
                range1.RowHeight = (object)18;
                application.Visible = true;
                application.UserControl = true;
            }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
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
      this.dgvResult = new DataGridView();
      this.menuStrip1 = new MenuStrip();
      this.файлToolStripMenuItem = new ToolStripMenuItem();
      this.эксроптToolStripMenuItem = new ToolStripMenuItem();
      this.clmRazrezX = new DataGridViewTextBoxColumn();
      this.clmGlubinaX = new DataGridViewTextBoxColumn();
      ((ISupportInitialize) this.dgvResult).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.dgvResult.AllowUserToAddRows = false;
      this.dgvResult.AllowUserToDeleteRows = false;
      this.dgvResult.AllowUserToResizeRows = false;
      this.dgvResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvResult.BackgroundColor = SystemColors.Window;
      this.dgvResult.BorderStyle = BorderStyle.None;
      this.dgvResult.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = Color.Honeydew;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvResult.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvResult.Columns.AddRange((DataGridViewColumn) this.clmRazrezX, (DataGridViewColumn) this.clmGlubinaX);
      this.dgvResult.Location = new System.Drawing.Point(12, 38);
      this.dgvResult.Name = "dgvResult";
      this.dgvResult.ReadOnly = true;
      this.dgvResult.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      this.dgvResult.RowHeadersVisible = false;
      this.dgvResult.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dgvResult.Size = new Size(1023, 343);
      this.dgvResult.TabIndex = 2;
      this.menuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.файлToolStripMenuItem
      });
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(1047, 24);
      this.menuStrip1.TabIndex = 3;
      this.menuStrip1.Text = "menuStrip1";
      this.файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.эксроптToolStripMenuItem
      });
      this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      this.файлToolStripMenuItem.Size = new Size(48, 20);
      this.файлToolStripMenuItem.Text = "Файл";
      this.эксроптToolStripMenuItem.Name = "эксроптToolStripMenuItem";
      this.эксроптToolStripMenuItem.Size = new Size(157, 22);
      this.эксроптToolStripMenuItem.Text = "Эксропт к Excel";
      this.эксроптToolStripMenuItem.Click += new EventHandler(this.meniItemExporttoExel_Click);
      this.clmRazrezX.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.clmRazrezX.DefaultCellStyle = gridViewCellStyle2;
      this.clmRazrezX.FillWeight = 5f;
      this.clmRazrezX.HeaderText = "Наименование";
      this.clmRazrezX.Name = "clmRazrezX";
      this.clmRazrezX.ReadOnly = true;
      this.clmRazrezX.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.clmGlubinaX.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.clmGlubinaX.DefaultCellStyle = gridViewCellStyle3;
      this.clmGlubinaX.FillWeight = 3f;
      this.clmGlubinaX.HeaderText = "Значение";
      this.clmGlubinaX.Name = "clmGlubinaX";
      this.clmGlubinaX.ReadOnly = true;
      this.clmGlubinaX.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1047, 393);
      this.Controls.Add((Control) this.dgvResult);
      this.Controls.Add((Control) this.menuStrip1);
      this.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new Padding(4);
      this.Name = nameof (FormStatistika);
      this.Text = "Результат по обобшёню статическую анализу";
      ((ISupportInitialize) this.dgvResult).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
