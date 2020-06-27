// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.HisobotFormEDK
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Models;
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
  public class HisobotFormEDK : Form
  {
    private IContainer components = (IContainer) null;
    private AnalysisClass[] analysiss;
    private List<PostClass> posts;
    private int Year;
    private DataGridView dgvAnalysis;
    private DataGridViewTextBoxColumn clmId;
    private DataGridViewTextBoxColumn clmRaqam;
    private DataGridViewTextBoxColumn clmRiver;
    private DataGridViewTextBoxColumn clmPost;
    private DataGridViewTextBoxColumn clmSana;
    private DataGridViewTextBoxColumn clmVaqt;
    private DataGridViewTextBoxColumn clmPost_Id;
    private DataGridViewTextBoxColumn clmSigm;
    private DataGridViewTextBoxColumn clmOqimTezligi;
    private DataGridViewTextBoxColumn clmDaryoSarfi;
    private DataGridViewTextBoxColumn clmOqimSarfi;
    private DataGridViewTextBoxColumn clmNamlik;
    private DataGridViewTextBoxColumn clmTiniqlik;
    private DataGridViewTextBoxColumn clmRangi;
    private DataGridViewTextBoxColumn clmHarorat;
    private DataGridViewTextBoxColumn clmSuzuvchi;
    private DataGridViewTextBoxColumn clmpH;
    private DataGridViewTextBoxColumn clmO2;
    private DataGridViewTextBoxColumn clmTuyingan;
    private DataGridViewTextBoxColumn clmCO2;
    private DataGridViewTextBoxColumn clmQattiqlik;
    private DataGridViewTextBoxColumn clmXlorid;
    private DataGridViewTextBoxColumn clmSulfat;
    private DataGridViewTextBoxColumn clmGidroKarbanat;
    private DataGridViewTextBoxColumn clmNa;
    private DataGridViewTextBoxColumn clmK;
    private DataGridViewTextBoxColumn clmCa;
    private DataGridViewTextBoxColumn clmMg;
    private DataGridViewTextBoxColumn clmMineral;
    private DataGridViewTextBoxColumn clmXPK;
    private DataGridViewTextBoxColumn clmBPK;
    private DataGridViewTextBoxColumn clmAzotAmonniy;
    private DataGridViewTextBoxColumn clmAzotNitritniy;
    private DataGridViewTextBoxColumn clmAzotNitratniy;
    private DataGridViewTextBoxColumn clmAzotSumma;
    private DataGridViewTextBoxColumn clmFosfat;
    private DataGridViewTextBoxColumn clmSi;
    private DataGridViewTextBoxColumn clmElektr;
    private DataGridViewTextBoxColumn clmEh_MB;
    private DataGridViewTextBoxColumn clmPumumiy;
    private DataGridViewTextBoxColumn clmFeUmumiy;
    private DataGridViewTextBoxColumn clmCi;
    private DataGridViewTextBoxColumn clmZn;
    private DataGridViewTextBoxColumn clmNi;
    private DataGridViewTextBoxColumn clmCr;
    private DataGridViewTextBoxColumn clmCr_VI;
    private DataGridViewTextBoxColumn clmCr_III;
    private DataGridViewTextBoxColumn clmPb;
    private DataGridViewTextBoxColumn clmHg;
    private DataGridViewTextBoxColumn clmCd;
    private DataGridViewTextBoxColumn clmMn;
    private DataGridViewTextBoxColumn clmAs;
    private DataGridViewTextBoxColumn clmFenollar;
    private DataGridViewTextBoxColumn clmNeft;
    private DataGridViewTextBoxColumn clmSPAB;
    private DataGridViewTextBoxColumn clmF;
    private DataGridViewTextBoxColumn clmSianidi;
    private DataGridViewTextBoxColumn clmProponil;
    private DataGridViewTextBoxColumn clmDDE;
    private DataGridViewTextBoxColumn clmRogor;
    private DataGridViewTextBoxColumn clmDDT;
    private DataGridViewTextBoxColumn clmGeksaxloran;
    private DataGridViewTextBoxColumn clmLindan;
    private DataGridViewTextBoxColumn clmDDD;
    private DataGridViewTextBoxColumn clmMetafos;
    private DataGridViewTextBoxColumn clmButifos;
    private DataGridViewTextBoxColumn clmDalapon;
    private DataGridViewTextBoxColumn clmKarbofos;
    private DataGridViewTextBoxColumn clmStatus;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem экспортКExcelToolStripMenuItem;

    public HisobotFormEDK(AnalysisClass[] analysiss, List<PostClass> posts, int Year)
    {
      this.InitializeComponent();
      this.analysiss = analysiss;
      this.posts = posts;
      this.Year = Year;
      int num;
      for (int i = 0; i < analysiss.Length; i = num + 1)
      {
        string str1 = posts.Where<PostClass>((Func<PostClass, bool>) (x => x.Id == analysiss[i].Post_Id)).Select<PostClass, string>((Func<PostClass, string>) (x => x.NameObserve)).FirstOrDefault<string>();
        string str2 = posts.Where<PostClass>((Func<PostClass, bool>) (x => x.Id == analysiss[i].Post_Id)).Select<PostClass, string>((Func<PostClass, string>) (x => x.NameObject)).FirstOrDefault<string>();
        this.dgvAnalysis.Rows.Add((object) analysiss[i].Id, (object) (i + 1), (object) str2, (object) str1, (object) analysiss[i].Sana, (object) analysiss[i].Vaqt, (object) analysiss[i].Post_Id, (object) (analysiss[i].Sigm == -1.0 ? "-" : analysiss[i].Sigm.ToString()), (object) (analysiss[i].OqimTezligi == -1.0 ? "-" : analysiss[i].OqimTezligi.ToString()), (object) (analysiss[i].DaryoSarfi == -1.0 ? "-" : analysiss[i].DaryoSarfi.ToString()), (object) (analysiss[i].OqimSarfi == -1.0 ? "-" : analysiss[i].OqimSarfi.ToString()), (object) (analysiss[i].Namlik == -1.0 ? "-" : analysiss[i].Namlik.ToString()), (object) (analysiss[i].Tiniqlik == -1.0 ? "-" : analysiss[i].Tiniqlik.ToString()), (object) (analysiss[i].Rangi == -1.0 ? "-" : analysiss[i].Rangi.ToString()), (object) (analysiss[i].Harorat == -1.0 ? "-" : analysiss[i].Harorat.ToString()), (object) (analysiss[i].Suzuvchi == -1.0 ? "-" : analysiss[i].Suzuvchi.ToString()), (object) (analysiss[i].pH == -1.0 ? "-" : analysiss[i].pH.ToString()), (object) (analysiss[i].O2 == -1.0 ? "-" : analysiss[i].O2.ToString()), (object) (analysiss[i].Tuyingan == -1.0 ? "-" : analysiss[i].Tuyingan.ToString()), (object) (analysiss[i].CO2 == -1.0 ? "-" : analysiss[i].CO2.ToString()), (object) (analysiss[i].Qattiqlik == -1.0 ? "-" : analysiss[i].Qattiqlik.ToString()), (object) (analysiss[i].Xlorid == -1.0 ? "-" : analysiss[i].Xlorid.ToString()), (object) (analysiss[i].Sulfat == -1.0 ? "-" : analysiss[i].Sulfat.ToString()), (object) (analysiss[i].GidroKarbanat == -1.0 ? "-" : analysiss[i].GidroKarbanat.ToString()), (object) (analysiss[i].Na == -1.0 ? "-" : analysiss[i].Na.ToString()), (object) (analysiss[i].K == -1.0 ? "-" : analysiss[i].K.ToString()), (object) (analysiss[i].Ca == -1.0 ? "-" : analysiss[i].Ca.ToString()), (object) (analysiss[i].Mg == -1.0 ? "-" : analysiss[i].Mg.ToString()), (object) (analysiss[i].Mineral == -1.0 ? "-" : analysiss[i].Mineral.ToString()), (object) (analysiss[i].XPK == -1.0 ? "-" : analysiss[i].XPK.ToString()), (object) (analysiss[i].BPK == -1.0 ? "-" : analysiss[i].BPK.ToString()), (object) (analysiss[i].AzotAmonniy == -1.0 ? "-" : analysiss[i].AzotAmonniy.ToString()), (object) (analysiss[i].AzotNitritniy == -1.0 ? "-" : analysiss[i].AzotNitritniy.ToString()), (object) (analysiss[i].AzotNitratniy == -1.0 ? "-" : analysiss[i].AzotNitratniy.ToString()), (object) (analysiss[i].AzotSumma == -1.0 ? "-" : analysiss[i].AzotSumma.ToString()), (object) (analysiss[i].Fosfat == -1.0 ? "-" : analysiss[i].Fosfat.ToString()), (object) (analysiss[i].Si == -1.0 ? "-" : analysiss[i].Si.ToString()), (object) (analysiss[i].Elektr == -1.0 ? "-" : analysiss[i].Elektr.ToString()), (object) (analysiss[i].Eh_MB == -1.0 ? "-" : analysiss[i].Eh_MB.ToString()), (object) (analysiss[i].PUmumiy == -1.0 ? "-" : analysiss[i].PUmumiy.ToString()), (object) (analysiss[i].FeUmumiy == -1.0 ? "-" : analysiss[i].FeUmumiy.ToString()), (object) (analysiss[i].Ci == -1.0 ? "-" : analysiss[i].Ci.ToString()), (object) (analysiss[i].Zn == -1.0 ? "-" : analysiss[i].Zn.ToString()), (object) (analysiss[i].Ni == -1.0 ? "-" : analysiss[i].Ni.ToString()), (object) (analysiss[i].Cr == -1.0 ? "-" : analysiss[i].Cr.ToString()), (object) (analysiss[i].Cr_VI == -1.0 ? "-" : analysiss[i].Cr_VI.ToString()), (object) (analysiss[i].Cr_III == -1.0 ? "-" : analysiss[i].Cr_III.ToString()), (object) (analysiss[i].Pb == -1.0 ? "-" : analysiss[i].Pb.ToString()), (object) (analysiss[i].Hg == -1.0 ? "-" : analysiss[i].Hg.ToString()), (object) (analysiss[i].Cd == -1.0 ? "-" : analysiss[i].Cd.ToString()), (object) (analysiss[i].Mn == -1.0 ? "-" : analysiss[i].Mn.ToString()), (object) (analysiss[i].As == -1.0 ? "-" : analysiss[i].As.ToString()), (object) (analysiss[i].Fenollar == -1.0 ? "-" : analysiss[i].Fenollar.ToString()), (object) (analysiss[i].Neft == -1.0 ? "-" : analysiss[i].Neft.ToString()), (object) (analysiss[i].SPAB == -1.0 ? "-" : analysiss[i].SPAB.ToString()), (object) (analysiss[i].F == -1.0 ? "-" : analysiss[i].F.ToString()), (object) (analysiss[i].Sianidi == -1.0 ? "-" : analysiss[i].Sianidi.ToString()), (object) (analysiss[i].Proponil == -1.0 ? "-" : analysiss[i].Proponil.ToString()), (object) (analysiss[i].DDE == -1.0 ? "-" : analysiss[i].DDE.ToString()), (object) (analysiss[i].Rogor == -1.0 ? "-" : analysiss[i].Rogor.ToString()), (object) (analysiss[i].DDT == -1.0 ? "-" : analysiss[i].DDT.ToString()), (object) (analysiss[i].Geksaxloran == -1.0 ? "-" : analysiss[i].Geksaxloran.ToString()), (object) (analysiss[i].Lindan == -1.0 ? "-" : analysiss[i].Lindan.ToString()), (object) (analysiss[i].DDD == -1.0 ? "-" : analysiss[i].DDD.ToString()), (object) (analysiss[i].Metafos == -1.0 ? "-" : analysiss[i].Metafos.ToString()), (object) (analysiss[i].Butifos == -1.0 ? "-" : analysiss[i].Butifos.ToString()), (object) (analysiss[i].Dalapon == -1.0 ? "-" : analysiss[i].Dalapon.ToString()), (object) (analysiss[i].Karbofos == -1.0 ? "-" : analysiss[i].Karbofos.ToString()), (object) analysiss[i].Status);
        num = i;
      }
    }

    private void экспортКExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                application.Workbooks.Add((object)Missing.Value);
                _Worksheet worksheet1 = (_Worksheet)(application.Sheets.Add(System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing) as Worksheet);
                this.Cursor = Cursors.WaitCursor;
                worksheet1.Cells[(object)1, (object)1] = (object)("Таблицы ЕДК по постам за " + this.Year.ToString() + " год");
                Range range1 = worksheet1.get_Range((object)"A1", (object)"K1");
                range1.Merge(System.Type.Missing);
                range1.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                range1.Font.Size = (object)14;
                int num1 = 3;
                List<AnalysisClass> analysisClassList = new List<AnalysisClass>();
                int num2 = 0;
                int num3;
                for (int i = 0; i < this.posts.Count; i = num3 + 1)
                {
                    List<AnalysisClass> list = ((IEnumerable<AnalysisClass>)this.analysiss).Where<AnalysisClass>((Func<AnalysisClass, bool>)(x => x.Post_Id == this.posts[i].Id)).ToList<AnalysisClass>();
                    if (list.Count > 0)
                    {
                        num3 = num2;
                        num2 = num3 + 1;
                        Range range2 = worksheet1.get_Range((object)("A" + (object)num1), (object)("M" + (object)num1));
                        range2.Merge(System.Type.Missing);
                        range2.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                        worksheet1.Cells[(object)num1, (object)1] = (object)("Пост   " + (object)num2 + "  пункт-" + (object)this.posts[i].NumberControl + "        " + this.posts[i].NameObject + "    створ " + this.posts[i].NameObserve + "      ширина-" + this.posts[i].Horizantal.ToString() + " глубина отбора пробы-" + this.posts[i].Vertical.ToString());
                        num1 += 2;
                        _Worksheet worksheet2 = worksheet1;
                        string str1 = "A" + num1.ToString();
                        string str2 = "A";
                        num3 = num1 + 1;
                        string str3 = num3.ToString();
                        string str4 = str2 + str3;
                        Range range3 = worksheet2.get_Range((object)str1, (object)str4);
                        range3.Merge(System.Type.Missing);
                        range3.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                        range3.VerticalAlignment = (object)XlVAlign.xlVAlignCenter;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"П о к а з а т е л ь";
                        num1 += 2;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"К-во дней хранения(дни)";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Скорость течения, м3/сек";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Расход реки, м3/сек";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Расход сточных.вод, м3/сек";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"запах, балл";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Прозрачность, см";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Цветность, град";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Температура, оС";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Взвешенные вещества, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"рН";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"О2, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Насыщение О2, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"СО2, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Жесткость, мг-экв/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Хлориды, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Сульфаты, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Гидрокарбонаты, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Na, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"K, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Ca, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Mg, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Минерализация, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"ХПК, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"БПК5, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Азот аммонний, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Азот нитритный, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Азот нитратный, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Сумма азота, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Фосфат, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Si, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Электропроводность, мкСм/см";
                        num1 += 2;
                        Range range4 = worksheet1.get_Range((object)("A" + (object)num1), (object)("M" + (object)num1));
                        range4.Merge(System.Type.Missing);
                        range4.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                        worksheet1.Cells[(object)num1, (object)1] = (object)("Пост   " + (object)num2 + "  пункт-" + (object)this.posts[i].NumberControl + "        " + this.posts[i].NameObject + "    створ " + this.posts[i].NameObserve + "      ширина-" + this.posts[i].Horizantal.ToString() + " глубина отбора пробы-" + this.posts[i].Vertical.ToString());
                        num1 += 2;
                        _Worksheet worksheet3 = worksheet1;
                        string str5 = "A" + num1.ToString();
                        string str6 = "A";
                        num3 = num1 + 1;
                        string str7 = num3.ToString();
                        string str8 = str6 + str7;
                        Range range5 = worksheet3.get_Range((object)str5, (object)str8);
                        range5.Merge(System.Type.Missing);
                        range5.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                        range5.VerticalAlignment = (object)XlVAlign.xlVAlignCenter;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Показатель";
                        num1 += 2;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Eh, MB";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"P общий, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Fe общий, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Сu, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Zn, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Ni, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Cr, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Cr-VI, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Cr-III, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Pb, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Hg, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Cd, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Mn, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"As, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Фенолы, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Нефтепродукты, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"СПАВ, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"F, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Цианиды, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Пропонил, мг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"ДДЕ, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Рогор, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"ДДТ, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Гексахлоран (α-ГХЦГ), мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Линдан (γ-ГХЦГ), мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"ДДД, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Метафос, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Бутифос, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Далапон, мкг/дм3";
                        num3 = num1;
                        num1 = num3 + 1;
                        worksheet1.Cells[(object)num1, (object)1] = (object)"Карбофос, мкг/дм3";
                        for (int index = 0; index < list.Count; index = num3 + 1)
                        {
                            int num4 = num1 - 67;
                            worksheet1.Cells[(object)num4, (object)(index + 2)] = (object)list[index].Sana;
                            num3 = num4;
                            int num5 = num3 + 1;
                            worksheet1.Cells[(object)num5, (object)(index + 2)] = (object)list[index].Vaqt;
                            num3 = num5;
                            int num6 = num3 + 1;
                            Range cells1 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local1 = (ValueType)num6;
                            // ISSUE: variable of a boxed type
                            object local2 = (ValueType)(index + 2);
                            double num7;
                            string str9;
                            if (list[index].Sigm != -1.0)
                            {
                                num7 = list[index].Sigm;
                                str9 = num7.ToString();
                            }
                            else
                                str9 = "-";
                            cells1[(object)local1, (object)local2] = (object)str9;
                            num3 = num6;
                            int num8 = num3 + 1;
                            Range cells2 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local3 = (ValueType)num8;
                            // ISSUE: variable of a boxed type
                            object local4 = (ValueType)(index + 2);
                            string str10;
                            if (list[index].OqimTezligi != -1.0)
                            {
                                num7 = list[index].OqimTezligi;
                                str10 = num7.ToString();
                            }
                            else
                                str10 = "-";
                            cells2[(object)local3, (object)local4] = (object)str10;
                            num3 = num8;
                            int num9 = num3 + 1;
                            Range cells3 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local5 = (ValueType)num9;
                            // ISSUE: variable of a boxed type
                            object local6 = (ValueType)(index + 2);
                            string str11;
                            if (list[index].DaryoSarfi != -1.0)
                            {
                                num7 = list[index].DaryoSarfi;
                                str11 = num7.ToString();
                            }
                            else
                                str11 = "-";
                            cells3[(object)local5, (object)local6] = (object)str11;
                            num3 = num9;
                            int num10 = num3 + 1;
                            Range cells4 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local7 = (ValueType)num10;
                            // ISSUE: variable of a boxed type
                            object local8 = (ValueType)(index + 2);
                            string str12;
                            if (list[index].OqimSarfi != -1.0)
                            {
                                num7 = list[index].OqimSarfi;
                                str12 = num7.ToString();
                            }
                            else
                                str12 = "-";
                            cells4[(object)local7, (object)local8] = (object)str12;
                            num3 = num10;
                            int num11 = num3 + 1;
                            Range cells5 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local9 = (ValueType)num11;
                            // ISSUE: variable of a boxed type
                            object local10 = (ValueType)(index + 2);
                            string str13;
                            if (list[index].Namlik != -1.0)
                            {
                                num7 = list[index].Namlik;
                                str13 = num7.ToString();
                            }
                            else
                                str13 = "-";
                            cells5[(object)local9, (object)local10] = (object)str13;
                            num3 = num11;
                            int num12 = num3 + 1;
                            Range cells6 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local11 = (ValueType)num12;
                            // ISSUE: variable of a boxed type
                            object local12 = (ValueType)(index + 2);
                            string str14;
                            if (list[index].Tiniqlik != -1.0)
                            {
                                num7 = list[index].Tiniqlik;
                                str14 = num7.ToString();
                            }
                            else
                                str14 = "-";
                            cells6[(object)local11, (object)local12] = (object)str14;
                            num3 = num12;
                            int num13 = num3 + 1;
                            Range cells7 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local13 = (ValueType)num13;
                            // ISSUE: variable of a boxed type
                            object local14 = (ValueType)(index + 2);
                            string str15;
                            if (list[index].Rangi != -1.0)
                            {
                                num7 = list[index].Rangi;
                                str15 = num7.ToString();
                            }
                            else
                                str15 = "-";
                            cells7[(object)local13, (object)local14] = (object)str15;
                            num3 = num13;
                            int num14 = num3 + 1;
                            Range cells8 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local15 = (ValueType)num14;
                            // ISSUE: variable of a boxed type
                            object local16 = (ValueType)(index + 2);
                            string str16;
                            if (list[index].Harorat != -1.0)
                            {
                                num7 = list[index].Harorat;
                                str16 = num7.ToString();
                            }
                            else
                                str16 = "-";
                            cells8[(object)local15, (object)local16] = (object)str16;
                            num3 = num14;
                            int num15 = num3 + 1;
                            Range cells9 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local17 = (ValueType)num15;
                            // ISSUE: variable of a boxed type
                            object local18 = (ValueType)(index + 2);
                            string str17;
                            if (list[index].Suzuvchi != -1.0)
                            {
                                num7 = list[index].Suzuvchi;
                                str17 = num7.ToString();
                            }
                            else
                                str17 = "-";
                            cells9[(object)local17, (object)local18] = (object)str17;
                            num3 = num15;
                            int num16 = num3 + 1;
                            Range cells10 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local19 = (ValueType)num16;
                            // ISSUE: variable of a boxed type
                            object local20 = (ValueType)(index + 2);
                            string str18;
                            if (list[index].pH != -1.0)
                            {
                                num7 = list[index].pH;
                                str18 = num7.ToString();
                            }
                            else
                                str18 = "-";
                            cells10[(object)local19, (object)local20] = (object)str18;
                            num3 = num16;
                            int num17 = num3 + 1;
                            Range cells11 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local21 = (ValueType)num17;
                            // ISSUE: variable of a boxed type
                            object local22 = (ValueType)(index + 2);
                            string str19;
                            if (list[index].O2 != -1.0)
                            {
                                num7 = list[index].O2;
                                str19 = num7.ToString();
                            }
                            else
                                str19 = "-";
                            cells11[(object)local21, (object)local22] = (object)str19;
                            num3 = num17;
                            int num18 = num3 + 1;
                            Range cells12 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local23 = (ValueType)num18;
                            // ISSUE: variable of a boxed type
                            object local24 = (ValueType)(index + 2);
                            string str20;
                            if (list[index].Tuyingan != -1.0)
                            {
                                num7 = list[index].Tuyingan;
                                str20 = num7.ToString();
                            }
                            else
                                str20 = "-";
                            cells12[(object)local23, (object)local24] = (object)str20;
                            num3 = num18;
                            int num19 = num3 + 1;
                            Range cells13 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local25 = (ValueType)num19;
                            // ISSUE: variable of a boxed type
                            object local26 = (ValueType)(index + 2);
                            string str21;
                            if (list[index].CO2 != -1.0)
                            {
                                num7 = list[index].CO2;
                                str21 = num7.ToString();
                            }
                            else
                                str21 = "-";
                            cells13[(object)local25, (object)local26] = (object)str21;
                            num3 = num19;
                            int num20 = num3 + 1;
                            Range cells14 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local27 = (ValueType)num20;
                            // ISSUE: variable of a boxed type
                            object local28 = (ValueType)(index + 2);
                            string str22;
                            if (list[index].Qattiqlik != -1.0)
                            {
                                num7 = list[index].Qattiqlik;
                                str22 = num7.ToString();
                            }
                            else
                                str22 = "-";
                            cells14[(object)local27, (object)local28] = (object)str22;
                            num3 = num20;
                            int num21 = num3 + 1;
                            Range cells15 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local29 = (ValueType)num21;
                            // ISSUE: variable of a boxed type
                            object local30 = (ValueType)(index + 2);
                            string str23;
                            if (list[index].Xlorid != -1.0)
                            {
                                num7 = list[index].Xlorid;
                                str23 = num7.ToString();
                            }
                            else
                                str23 = "-";
                            cells15[(object)local29, (object)local30] = (object)str23;
                            num3 = num21;
                            int num22 = num3 + 1;
                            Range cells16 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local31 = (ValueType)num22;
                            // ISSUE: variable of a boxed type
                            object local32 = (ValueType)(index + 2);
                            string str24;
                            if (list[index].Sulfat != -1.0)
                            {
                                num7 = list[index].Sulfat;
                                str24 = num7.ToString();
                            }
                            else
                                str24 = "-";
                            cells16[(object)local31, (object)local32] = (object)str24;
                            num3 = num22;
                            int num23 = num3 + 1;
                            Range cells17 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local33 = (ValueType)num23;
                            // ISSUE: variable of a boxed type
                            object local34 = (ValueType)(index + 2);
                            string str25;
                            if (list[index].GidroKarbanat != -1.0)
                            {
                                num7 = list[index].GidroKarbanat;
                                str25 = num7.ToString();
                            }
                            else
                                str25 = "-";
                            cells17[(object)local33, (object)local34] = (object)str25;
                            num3 = num23;
                            int num24 = num3 + 1;
                            Range cells18 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local35 = (ValueType)num24;
                            // ISSUE: variable of a boxed type
                            object local36 = (ValueType)(index + 2);
                            string str26;
                            if (list[index].Na != -1.0)
                            {
                                num7 = list[index].Na;
                                str26 = num7.ToString();
                            }
                            else
                                str26 = "-";
                            cells18[(object)local35, (object)local36] = (object)str26;
                            num3 = num24;
                            int num25 = num3 + 1;
                            Range cells19 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local37 = (ValueType)num25;
                            // ISSUE: variable of a boxed type
                            object local38 = (ValueType)(index + 2);
                            string str27;
                            if (list[index].K != -1.0)
                            {
                                num7 = list[index].K;
                                str27 = num7.ToString();
                            }
                            else
                                str27 = "-";
                            cells19[(object)local37, (object)local38] = (object)str27;
                            num3 = num25;
                            int num26 = num3 + 1;
                            Range cells20 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local39 = (ValueType)num26;
                            // ISSUE: variable of a boxed type
                            object local40 = (ValueType)(index + 2);
                            string str28;
                            if (list[index].Ca != -1.0)
                            {
                                num7 = list[index].Ca;
                                str28 = num7.ToString();
                            }
                            else
                                str28 = "-";
                            cells20[(object)local39, (object)local40] = (object)str28;
                            num3 = num26;
                            int num27 = num3 + 1;
                            Range cells21 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local41 = (ValueType)num27;
                            // ISSUE: variable of a boxed type
                            object local42 = (ValueType)(index + 2);
                            string str29;
                            if (list[index].Mg != -1.0)
                            {
                                num7 = list[index].Mg;
                                str29 = num7.ToString();
                            }
                            else
                                str29 = "-";
                            cells21[(object)local41, (object)local42] = (object)str29;
                            num3 = num27;
                            int num28 = num3 + 1;
                            Range cells22 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local43 = (ValueType)num28;
                            // ISSUE: variable of a boxed type
                            object local44 = (ValueType)(index + 2);
                            string str30;
                            if (list[index].Mineral != -1.0)
                            {
                                num7 = list[index].Mineral;
                                str30 = num7.ToString();
                            }
                            else
                                str30 = "-";
                            cells22[(object)local43, (object)local44] = (object)str30;
                            num3 = num28;
                            int num29 = num3 + 1;
                            Range cells23 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local45 = (ValueType)num29;
                            // ISSUE: variable of a boxed type
                            object local46 = (ValueType)(index + 2);
                            string str31;
                            if (list[index].XPK != -1.0)
                            {
                                num7 = list[index].XPK;
                                str31 = num7.ToString();
                            }
                            else
                                str31 = "-";
                            cells23[(object)local45, (object)local46] = (object)str31;
                            num3 = num29;
                            int num30 = num3 + 1;
                            Range cells24 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local47 = (ValueType)num30;
                            // ISSUE: variable of a boxed type
                            object local48 = (ValueType)(index + 2);
                            string str32;
                            if (list[index].BPK != -1.0)
                            {
                                num7 = list[index].BPK;
                                str32 = num7.ToString();
                            }
                            else
                                str32 = "-";
                            cells24[(object)local47, (object)local48] = (object)str32;
                            num3 = num30;
                            int num31 = num3 + 1;
                            Range cells25 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local49 = (ValueType)num31;
                            // ISSUE: variable of a boxed type
                            object local50 = (ValueType)(index + 2);
                            string str33;
                            if (list[index].AzotAmonniy != -1.0)
                            {
                                num7 = list[index].AzotAmonniy;
                                str33 = num7.ToString();
                            }
                            else
                                str33 = "-";
                            cells25[(object)local49, (object)local50] = (object)str33;
                            num3 = num31;
                            int num32 = num3 + 1;
                            Range cells26 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local51 = (ValueType)num32;
                            // ISSUE: variable of a boxed type
                            object local52 = (ValueType)(index + 2);
                            string str34;
                            if (list[index].AzotNitritniy != -1.0)
                            {
                                num7 = list[index].AzotNitritniy;
                                str34 = num7.ToString();
                            }
                            else
                                str34 = "-";
                            cells26[(object)local51, (object)local52] = (object)str34;
                            num3 = num32;
                            int num33 = num3 + 1;
                            Range cells27 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local53 = (ValueType)num33;
                            // ISSUE: variable of a boxed type
                            object local54 = (ValueType)(index + 2);
                            string str35;
                            if (list[index].AzotNitratniy != -1.0)
                            {
                                num7 = list[index].AzotNitratniy;
                                str35 = num7.ToString();
                            }
                            else
                                str35 = "-";
                            cells27[(object)local53, (object)local54] = (object)str35;
                            num3 = num33;
                            int num34 = num3 + 1;
                            Range cells28 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local55 = (ValueType)num34;
                            // ISSUE: variable of a boxed type
                            object local56 = (ValueType)(index + 2);
                            string str36;
                            if (list[index].AzotSumma != -1.0)
                            {
                                num7 = list[index].AzotSumma;
                                str36 = num7.ToString();
                            }
                            else
                                str36 = "-";
                            cells28[(object)local55, (object)local56] = (object)str36;
                            num3 = num34;
                            int num35 = num3 + 1;
                            Range cells29 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local57 = (ValueType)num35;
                            // ISSUE: variable of a boxed type
                            object local58 = (ValueType)(index + 2);
                            string str37;
                            if (list[index].Fosfat != -1.0)
                            {
                                num7 = list[index].Fosfat;
                                str37 = num7.ToString();
                            }
                            else
                                str37 = "-";
                            cells29[(object)local57, (object)local58] = (object)str37;
                            num3 = num35;
                            int num36 = num3 + 1;
                            Range cells30 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local59 = (ValueType)num36;
                            // ISSUE: variable of a boxed type
                            object local60 = (ValueType)(index + 2);
                            string str38;
                            if (list[index].Si != -1.0)
                            {
                                num7 = list[index].Si;
                                str38 = num7.ToString();
                            }
                            else
                                str38 = "-";
                            cells30[(object)local59, (object)local60] = (object)str38;
                            num3 = num36;
                            int num37 = num3 + 1;
                            Range cells31 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local61 = (ValueType)num37;
                            // ISSUE: variable of a boxed type
                            object local62 = (ValueType)(index + 2);
                            string str39;
                            if (list[index].Elektr != -1.0)
                            {
                                num7 = list[index].Elektr;
                                str39 = num7.ToString();
                            }
                            else
                                str39 = "-";
                            cells31[(object)local61, (object)local62] = (object)str39;
                            int num38 = num37 + 4;
                            worksheet1.Cells[(object)num38, (object)(index + 2)] = (object)list[index].Sana;
                            num3 = num38;
                            int num39 = num3 + 1;
                            worksheet1.Cells[(object)num39, (object)(index + 2)] = (object)list[index].Vaqt;
                            num3 = num39;
                            int num40 = num3 + 1;
                            Range cells32 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local63 = (ValueType)num40;
                            // ISSUE: variable of a boxed type
                            object local64 = (ValueType)(index + 2);
                            string str40;
                            if (list[index].Eh_MB != -1.0)
                            {
                                num7 = list[index].Eh_MB;
                                str40 = num7.ToString();
                            }
                            else
                                str40 = "-";
                            cells32[(object)local63, (object)local64] = (object)str40;
                            num3 = num40;
                            int num41 = num3 + 1;
                            Range cells33 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local65 = (ValueType)num41;
                            // ISSUE: variable of a boxed type
                            object local66 = (ValueType)(index + 2);
                            string str41;
                            if (list[index].PUmumiy != -1.0)
                            {
                                num7 = list[index].PUmumiy;
                                str41 = num7.ToString();
                            }
                            else
                                str41 = "-";
                            cells33[(object)local65, (object)local66] = (object)str41;
                            num3 = num41;
                            int num42 = num3 + 1;
                            Range cells34 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local67 = (ValueType)num42;
                            // ISSUE: variable of a boxed type
                            object local68 = (ValueType)(index + 2);
                            string str42;
                            if (list[index].FeUmumiy != -1.0)
                            {
                                num7 = list[index].FeUmumiy;
                                str42 = num7.ToString();
                            }
                            else
                                str42 = "-";
                            cells34[(object)local67, (object)local68] = (object)str42;
                            num3 = num42;
                            int num43 = num3 + 1;
                            Range cells35 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local69 = (ValueType)num43;
                            // ISSUE: variable of a boxed type
                            object local70 = (ValueType)(index + 2);
                            string str43;
                            if (list[index].Ci != -1.0)
                            {
                                num7 = list[index].Ci;
                                str43 = num7.ToString();
                            }
                            else
                                str43 = "-";
                            cells35[(object)local69, (object)local70] = (object)str43;
                            num3 = num43;
                            int num44 = num3 + 1;
                            Range cells36 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local71 = (ValueType)num44;
                            // ISSUE: variable of a boxed type
                            object local72 = (ValueType)(index + 2);
                            string str44;
                            if (list[index].Zn != -1.0)
                            {
                                num7 = list[index].Zn;
                                str44 = num7.ToString();
                            }
                            else
                                str44 = "-";
                            cells36[(object)local71, (object)local72] = (object)str44;
                            num3 = num44;
                            int num45 = num3 + 1;
                            Range cells37 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local73 = (ValueType)num45;
                            // ISSUE: variable of a boxed type
                            object local74 = (ValueType)(index + 2);
                            string str45;
                            if (list[index].Ni != -1.0)
                            {
                                num7 = list[index].Ni;
                                str45 = num7.ToString();
                            }
                            else
                                str45 = "-";
                            cells37[(object)local73, (object)local74] = (object)str45;
                            num3 = num45;
                            int num46 = num3 + 1;
                            Range cells38 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local75 = (ValueType)num46;
                            // ISSUE: variable of a boxed type
                            object local76 = (ValueType)(index + 2);
                            string str46;
                            if (list[index].Cr != -1.0)
                            {
                                num7 = list[index].Cr;
                                str46 = num7.ToString();
                            }
                            else
                                str46 = "-";
                            cells38[(object)local75, (object)local76] = (object)str46;
                            num3 = num46;
                            int num47 = num3 + 1;
                            Range cells39 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local77 = (ValueType)num47;
                            // ISSUE: variable of a boxed type
                            object local78 = (ValueType)(index + 2);
                            string str47;
                            if (list[index].Cr_VI != -1.0)
                            {
                                num7 = list[index].Cr_VI;
                                str47 = num7.ToString();
                            }
                            else
                                str47 = "-";
                            cells39[(object)local77, (object)local78] = (object)str47;
                            num3 = num47;
                            int num48 = num3 + 1;
                            Range cells40 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local79 = (ValueType)num48;
                            // ISSUE: variable of a boxed type
                            object local80 = (ValueType)(index + 2);
                            string str48;
                            if (list[index].Cr_III != -1.0)
                            {
                                num7 = list[index].Cr_III;
                                str48 = num7.ToString();
                            }
                            else
                                str48 = "-";
                            cells40[(object)local79, (object)local80] = (object)str48;
                            num3 = num48;
                            int num49 = num3 + 1;
                            Range cells41 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local81 = (ValueType)num49;
                            // ISSUE: variable of a boxed type
                            object local82 = (ValueType)(index + 2);
                            string str49;
                            if (list[index].Pb != -1.0)
                            {
                                num7 = list[index].Pb;
                                str49 = num7.ToString();
                            }
                            else
                                str49 = "-";
                            cells41[(object)local81, (object)local82] = (object)str49;
                            num3 = num49;
                            int num50 = num3 + 1;
                            Range cells42 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local83 = (ValueType)num50;
                            // ISSUE: variable of a boxed type
                            object local84 = (ValueType)(index + 2);
                            string str50;
                            if (list[index].Hg != -1.0)
                            {
                                num7 = list[index].Hg;
                                str50 = num7.ToString();
                            }
                            else
                                str50 = "-";
                            cells42[(object)local83, (object)local84] = (object)str50;
                            num3 = num50;
                            int num51 = num3 + 1;
                            Range cells43 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local85 = (ValueType)num51;
                            // ISSUE: variable of a boxed type
                            object local86 = (ValueType)(index + 2);
                            string str51;
                            if (list[index].Cd != -1.0)
                            {
                                num7 = list[index].Cd;
                                str51 = num7.ToString();
                            }
                            else
                                str51 = "-";
                            cells43[(object)local85, (object)local86] = (object)str51;
                            num3 = num51;
                            int num52 = num3 + 1;
                            Range cells44 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local87 = (ValueType)num52;
                            // ISSUE: variable of a boxed type
                            object local88 = (ValueType)(index + 2);
                            string str52;
                            if (list[index].Mn != -1.0)
                            {
                                num7 = list[index].Mn;
                                str52 = num7.ToString();
                            }
                            else
                                str52 = "-";
                            cells44[(object)local87, (object)local88] = (object)str52;
                            num3 = num52;
                            int num53 = num3 + 1;
                            Range cells45 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local89 = (ValueType)num53;
                            // ISSUE: variable of a boxed type
                            object local90 = (ValueType)(index + 2);
                            string str53;
                            if (list[index].As != -1.0)
                            {
                                num7 = list[index].As;
                                str53 = num7.ToString();
                            }
                            else
                                str53 = "-";
                            cells45[(object)local89, (object)local90] = (object)str53;
                            num3 = num53;
                            int num54 = num3 + 1;
                            Range cells46 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local91 = (ValueType)num54;
                            // ISSUE: variable of a boxed type
                            object local92 = (ValueType)(index + 2);
                            string str54;
                            if (list[index].Fenollar != -1.0)
                            {
                                num7 = list[index].Fenollar;
                                str54 = num7.ToString();
                            }
                            else
                                str54 = "-";
                            cells46[(object)local91, (object)local92] = (object)str54;
                            num3 = num54;
                            int num55 = num3 + 1;
                            Range cells47 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local93 = (ValueType)num55;
                            // ISSUE: variable of a boxed type
                            object local94 = (ValueType)(index + 2);
                            string str55;
                            if (list[index].Neft != -1.0)
                            {
                                num7 = list[index].Neft;
                                str55 = num7.ToString();
                            }
                            else
                                str55 = "-";
                            cells47[(object)local93, (object)local94] = (object)str55;
                            num3 = num55;
                            int num56 = num3 + 1;
                            Range cells48 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local95 = (ValueType)num56;
                            // ISSUE: variable of a boxed type
                            object local96 = (ValueType)(index + 2);
                            string str56;
                            if (list[index].SPAB != -1.0)
                            {
                                num7 = list[index].SPAB;
                                str56 = num7.ToString();
                            }
                            else
                                str56 = "-";
                            cells48[(object)local95, (object)local96] = (object)str56;
                            num3 = num56;
                            int num57 = num3 + 1;
                            Range cells49 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local97 = (ValueType)num57;
                            // ISSUE: variable of a boxed type
                            object local98 = (ValueType)(index + 2);
                            string str57;
                            if (list[index].F != -1.0)
                            {
                                num7 = list[index].F;
                                str57 = num7.ToString();
                            }
                            else
                                str57 = "-";
                            cells49[(object)local97, (object)local98] = (object)str57;
                            num3 = num57;
                            int num58 = num3 + 1;
                            Range cells50 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local99 = (ValueType)num58;
                            // ISSUE: variable of a boxed type
                            object local100 = (ValueType)(index + 2);
                            string str58;
                            if (list[index].Sianidi != -1.0)
                            {
                                num7 = list[index].Sianidi;
                                str58 = num7.ToString();
                            }
                            else
                                str58 = "-";
                            cells50[(object)local99, (object)local100] = (object)str58;
                            num3 = num58;
                            int num59 = num3 + 1;
                            Range cells51 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local101 = (ValueType)num59;
                            // ISSUE: variable of a boxed type
                            object local102 = (ValueType)(index + 2);
                            string str59;
                            if (list[index].Proponil != -1.0)
                            {
                                num7 = list[index].Proponil;
                                str59 = num7.ToString();
                            }
                            else
                                str59 = "-";
                            cells51[(object)local101, (object)local102] = (object)str59;
                            num3 = num59;
                            int num60 = num3 + 1;
                            Range cells52 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local103 = (ValueType)num60;
                            // ISSUE: variable of a boxed type
                            object local104 = (ValueType)(index + 2);
                            string str60;
                            if (list[index].DDE != -1.0)
                            {
                                num7 = list[index].DDE;
                                str60 = num7.ToString();
                            }
                            else
                                str60 = "-";
                            cells52[(object)local103, (object)local104] = (object)str60;
                            num3 = num60;
                            int num61 = num3 + 1;
                            Range cells53 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local105 = (ValueType)num61;
                            // ISSUE: variable of a boxed type
                            object local106 = (ValueType)(index + 2);
                            string str61;
                            if (list[index].Rogor != -1.0)
                            {
                                num7 = list[index].Rogor;
                                str61 = num7.ToString();
                            }
                            else
                                str61 = "-";
                            cells53[(object)local105, (object)local106] = (object)str61;
                            num3 = num61;
                            int num62 = num3 + 1;
                            Range cells54 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local107 = (ValueType)num62;
                            // ISSUE: variable of a boxed type
                            object local108 = (ValueType)(index + 2);
                            string str62;
                            if (list[index].DDT != -1.0)
                            {
                                num7 = list[index].DDT;
                                str62 = num7.ToString();
                            }
                            else
                                str62 = "-";
                            cells54[(object)local107, (object)local108] = (object)str62;
                            num3 = num62;
                            int num63 = num3 + 1;
                            Range cells55 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local109 = (ValueType)num63;
                            // ISSUE: variable of a boxed type
                            object local110 = (ValueType)(index + 2);
                            string str63;
                            if (list[index].Geksaxloran != -1.0)
                            {
                                num7 = list[index].Geksaxloran;
                                str63 = num7.ToString();
                            }
                            else
                                str63 = "-";
                            cells55[(object)local109, (object)local110] = (object)str63;
                            num3 = num63;
                            int num64 = num3 + 1;
                            Range cells56 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local111 = (ValueType)num64;
                            // ISSUE: variable of a boxed type
                            object local112 = (ValueType)(index + 2);
                            string str64;
                            if (list[index].Lindan != -1.0)
                            {
                                num7 = list[index].Lindan;
                                str64 = num7.ToString();
                            }
                            else
                                str64 = "-";
                            cells56[(object)local111, (object)local112] = (object)str64;
                            num3 = num64;
                            int num65 = num3 + 1;
                            Range cells57 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local113 = (ValueType)num65;
                            // ISSUE: variable of a boxed type
                            object local114 = (ValueType)(index + 2);
                            string str65;
                            if (list[index].DDD != -1.0)
                            {
                                num7 = list[index].DDD;
                                str65 = num7.ToString();
                            }
                            else
                                str65 = "-";
                            cells57[(object)local113, (object)local114] = (object)str65;
                            num3 = num65;
                            int num66 = num3 + 1;
                            Range cells58 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local115 = (ValueType)num66;
                            // ISSUE: variable of a boxed type
                            object local116 = (ValueType)(index + 2);
                            string str66;
                            if (list[index].Metafos != -1.0)
                            {
                                num7 = list[index].Metafos;
                                str66 = num7.ToString();
                            }
                            else
                                str66 = "-";
                            cells58[(object)local115, (object)local116] = (object)str66;
                            num3 = num66;
                            int num67 = num3 + 1;
                            Range cells59 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local117 = (ValueType)num67;
                            // ISSUE: variable of a boxed type
                            object local118 = (ValueType)(index + 2);
                            string str67;
                            if (list[index].Butifos != -1.0)
                            {
                                num7 = list[index].Butifos;
                                str67 = num7.ToString();
                            }
                            else
                                str67 = "-";
                            cells59[(object)local117, (object)local118] = (object)str67;
                            num3 = num67;
                            int num68 = num3 + 1;
                            Range cells60 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local119 = (ValueType)num68;
                            // ISSUE: variable of a boxed type
                            object local120 = (ValueType)(index + 2);
                            string str68;
                            if (list[index].Dalapon != -1.0)
                            {
                                num7 = list[index].Dalapon;
                                str68 = num7.ToString();
                            }
                            else
                                str68 = "-";
                            cells60[(object)local119, (object)local120] = (object)str68;
                            num3 = num68;
                            int num69 = num3 + 1;
                            Range cells61 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local121 = (ValueType)num69;
                            // ISSUE: variable of a boxed type
                            object local122 = (ValueType)(index + 2);
                            string str69;
                            if (list[index].Karbofos != -1.0)
                            {
                                num7 = list[index].Karbofos;
                                str69 = num7.ToString();
                            }
                            else
                                str69 = "-";
                            cells61[(object)local121, (object)local122] = (object)str69;
                            num3 = index;
                        }
                        int count = list.Count;
                        string str70 = "";
                        while ((uint)count > 0U)
                        {
                            str70 += ((char)(count % 26 + 65)).ToString();
                            count /= 26;
                        }
                        _Worksheet worksheet4 = worksheet1;
                        string str71 = "A";
                        num3 = num1 - 67;
                        string str72 = num3.ToString();
                        string str73 = str71 + str72;
                        string str74 = str70;
                        num3 = num1 - 35;
                        string str75 = num3.ToString();
                        string str76 = str74 + str75;
                        Range range6 = worksheet4.get_Range((object)str73, (object)str76);
                        range6.Borders.Weight = (object)2;
                        range6.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                        range6.ColumnWidth = (object)11;
                        _Worksheet worksheet5 = worksheet1;
                        string str77 = "A";
                        num3 = num1 - 31;
                        string str78 = num3.ToString();
                        string str79 = str77 + str78;
                        string str80 = str70 + num1.ToString();
                        Range range7 = worksheet5.get_Range((object)str79, (object)str80);
                        range7.Borders.Weight = (object)2;
                        range7.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                        range7.ColumnWidth = (object)11;
                        num1 += 2;
                    }
                    Range range8 = worksheet1.get_Range((object)"A5", (object)("A" + num1.ToString()));
                    range8.HorizontalAlignment = (object)XlHAlign.xlHAlignLeft;
                    range8.ColumnWidth = (object)30;
                    num3 = i;
                }
                application.UserControl = true;
                application.Visible = true;
                this.Cursor = Cursors.Arrow;
            }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        this.Cursor = Cursors.Arrow;
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
      this.dgvAnalysis = new DataGridView();
      this.clmId = new DataGridViewTextBoxColumn();
      this.clmRaqam = new DataGridViewTextBoxColumn();
      this.clmRiver = new DataGridViewTextBoxColumn();
      this.clmPost = new DataGridViewTextBoxColumn();
      this.clmSana = new DataGridViewTextBoxColumn();
      this.clmVaqt = new DataGridViewTextBoxColumn();
      this.clmPost_Id = new DataGridViewTextBoxColumn();
      this.clmSigm = new DataGridViewTextBoxColumn();
      this.clmOqimTezligi = new DataGridViewTextBoxColumn();
      this.clmDaryoSarfi = new DataGridViewTextBoxColumn();
      this.clmOqimSarfi = new DataGridViewTextBoxColumn();
      this.clmNamlik = new DataGridViewTextBoxColumn();
      this.clmTiniqlik = new DataGridViewTextBoxColumn();
      this.clmRangi = new DataGridViewTextBoxColumn();
      this.clmHarorat = new DataGridViewTextBoxColumn();
      this.clmSuzuvchi = new DataGridViewTextBoxColumn();
      this.clmpH = new DataGridViewTextBoxColumn();
      this.clmO2 = new DataGridViewTextBoxColumn();
      this.clmTuyingan = new DataGridViewTextBoxColumn();
      this.clmCO2 = new DataGridViewTextBoxColumn();
      this.clmQattiqlik = new DataGridViewTextBoxColumn();
      this.clmXlorid = new DataGridViewTextBoxColumn();
      this.clmSulfat = new DataGridViewTextBoxColumn();
      this.clmGidroKarbanat = new DataGridViewTextBoxColumn();
      this.clmNa = new DataGridViewTextBoxColumn();
      this.clmK = new DataGridViewTextBoxColumn();
      this.clmCa = new DataGridViewTextBoxColumn();
      this.clmMg = new DataGridViewTextBoxColumn();
      this.clmMineral = new DataGridViewTextBoxColumn();
      this.clmXPK = new DataGridViewTextBoxColumn();
      this.clmBPK = new DataGridViewTextBoxColumn();
      this.clmAzotAmonniy = new DataGridViewTextBoxColumn();
      this.clmAzotNitritniy = new DataGridViewTextBoxColumn();
      this.clmAzotNitratniy = new DataGridViewTextBoxColumn();
      this.clmAzotSumma = new DataGridViewTextBoxColumn();
      this.clmFosfat = new DataGridViewTextBoxColumn();
      this.clmSi = new DataGridViewTextBoxColumn();
      this.clmElektr = new DataGridViewTextBoxColumn();
      this.clmEh_MB = new DataGridViewTextBoxColumn();
      this.clmPumumiy = new DataGridViewTextBoxColumn();
      this.clmFeUmumiy = new DataGridViewTextBoxColumn();
      this.clmCi = new DataGridViewTextBoxColumn();
      this.clmZn = new DataGridViewTextBoxColumn();
      this.clmNi = new DataGridViewTextBoxColumn();
      this.clmCr = new DataGridViewTextBoxColumn();
      this.clmCr_VI = new DataGridViewTextBoxColumn();
      this.clmCr_III = new DataGridViewTextBoxColumn();
      this.clmPb = new DataGridViewTextBoxColumn();
      this.clmHg = new DataGridViewTextBoxColumn();
      this.clmCd = new DataGridViewTextBoxColumn();
      this.clmMn = new DataGridViewTextBoxColumn();
      this.clmAs = new DataGridViewTextBoxColumn();
      this.clmFenollar = new DataGridViewTextBoxColumn();
      this.clmNeft = new DataGridViewTextBoxColumn();
      this.clmSPAB = new DataGridViewTextBoxColumn();
      this.clmF = new DataGridViewTextBoxColumn();
      this.clmSianidi = new DataGridViewTextBoxColumn();
      this.clmProponil = new DataGridViewTextBoxColumn();
      this.clmDDE = new DataGridViewTextBoxColumn();
      this.clmRogor = new DataGridViewTextBoxColumn();
      this.clmDDT = new DataGridViewTextBoxColumn();
      this.clmGeksaxloran = new DataGridViewTextBoxColumn();
      this.clmLindan = new DataGridViewTextBoxColumn();
      this.clmDDD = new DataGridViewTextBoxColumn();
      this.clmMetafos = new DataGridViewTextBoxColumn();
      this.clmButifos = new DataGridViewTextBoxColumn();
      this.clmDalapon = new DataGridViewTextBoxColumn();
      this.clmKarbofos = new DataGridViewTextBoxColumn();
      this.clmStatus = new DataGridViewTextBoxColumn();
      this.menuStrip1 = new MenuStrip();
      this.файлToolStripMenuItem = new ToolStripMenuItem();
      this.экспортКExcelToolStripMenuItem = new ToolStripMenuItem();
      ((ISupportInitialize) this.dgvAnalysis).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.dgvAnalysis.AllowUserToAddRows = false;
      this.dgvAnalysis.AllowUserToDeleteRows = false;
      this.dgvAnalysis.AllowUserToOrderColumns = true;
      this.dgvAnalysis.AllowUserToResizeColumns = false;
      this.dgvAnalysis.AllowUserToResizeRows = false;
      this.dgvAnalysis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvAnalysis.BackgroundColor = Color.White;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvAnalysis.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvAnalysis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvAnalysis.Columns.AddRange((DataGridViewColumn) this.clmId, (DataGridViewColumn) this.clmRaqam, (DataGridViewColumn) this.clmRiver, (DataGridViewColumn) this.clmPost, (DataGridViewColumn) this.clmSana, (DataGridViewColumn) this.clmVaqt, (DataGridViewColumn) this.clmPost_Id, (DataGridViewColumn) this.clmSigm, (DataGridViewColumn) this.clmOqimTezligi, (DataGridViewColumn) this.clmDaryoSarfi, (DataGridViewColumn) this.clmOqimSarfi, (DataGridViewColumn) this.clmNamlik, (DataGridViewColumn) this.clmTiniqlik, (DataGridViewColumn) this.clmRangi, (DataGridViewColumn) this.clmHarorat, (DataGridViewColumn) this.clmSuzuvchi, (DataGridViewColumn) this.clmpH, (DataGridViewColumn) this.clmO2, (DataGridViewColumn) this.clmTuyingan, (DataGridViewColumn) this.clmCO2, (DataGridViewColumn) this.clmQattiqlik, (DataGridViewColumn) this.clmXlorid, (DataGridViewColumn) this.clmSulfat, (DataGridViewColumn) this.clmGidroKarbanat, (DataGridViewColumn) this.clmNa, (DataGridViewColumn) this.clmK, (DataGridViewColumn) this.clmCa, (DataGridViewColumn) this.clmMg, (DataGridViewColumn) this.clmMineral, (DataGridViewColumn) this.clmXPK, (DataGridViewColumn) this.clmBPK, (DataGridViewColumn) this.clmAzotAmonniy, (DataGridViewColumn) this.clmAzotNitritniy, (DataGridViewColumn) this.clmAzotNitratniy, (DataGridViewColumn) this.clmAzotSumma, (DataGridViewColumn) this.clmFosfat, (DataGridViewColumn) this.clmSi, (DataGridViewColumn) this.clmElektr, (DataGridViewColumn) this.clmEh_MB, (DataGridViewColumn) this.clmPumumiy, (DataGridViewColumn) this.clmFeUmumiy, (DataGridViewColumn) this.clmCi, (DataGridViewColumn) this.clmZn, (DataGridViewColumn) this.clmNi, (DataGridViewColumn) this.clmCr, (DataGridViewColumn) this.clmCr_VI, (DataGridViewColumn) this.clmCr_III, (DataGridViewColumn) this.clmPb, (DataGridViewColumn) this.clmHg, (DataGridViewColumn) this.clmCd, (DataGridViewColumn) this.clmMn, (DataGridViewColumn) this.clmAs, (DataGridViewColumn) this.clmFenollar, (DataGridViewColumn) this.clmNeft, (DataGridViewColumn) this.clmSPAB, (DataGridViewColumn) this.clmF, (DataGridViewColumn) this.clmSianidi, (DataGridViewColumn) this.clmProponil, (DataGridViewColumn) this.clmDDE, (DataGridViewColumn) this.clmRogor, (DataGridViewColumn) this.clmDDT, (DataGridViewColumn) this.clmGeksaxloran, (DataGridViewColumn) this.clmLindan, (DataGridViewColumn) this.clmDDD, (DataGridViewColumn) this.clmMetafos, (DataGridViewColumn) this.clmButifos, (DataGridViewColumn) this.clmDalapon, (DataGridViewColumn) this.clmKarbofos, (DataGridViewColumn) this.clmStatus);
      this.dgvAnalysis.Location = new System.Drawing.Point(12, 27);
      this.dgvAnalysis.MultiSelect = false;
      this.dgvAnalysis.Name = "dgvAnalysis";
      this.dgvAnalysis.ReadOnly = true;
      this.dgvAnalysis.RowHeadersVisible = false;
      this.dgvAnalysis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvAnalysis.Size = new Size(1071, 342);
      this.dgvAnalysis.TabIndex = 7;
      this.clmId.HeaderText = "Id";
      this.clmId.Name = "clmId";
      this.clmId.ReadOnly = true;
      this.clmId.Visible = false;
      gridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.clmRaqam.DefaultCellStyle = gridViewCellStyle2;
      this.clmRaqam.HeaderText = "№";
      this.clmRaqam.Name = "clmRaqam";
      this.clmRaqam.ReadOnly = true;
      this.clmRaqam.Width = 80;
      this.clmRiver.HeaderText = "Река";
      this.clmRiver.Name = "clmRiver";
      this.clmRiver.ReadOnly = true;
      this.clmRiver.Width = 150;
      this.clmPost.HeaderText = "Пост";
      this.clmPost.Name = "clmPost";
      this.clmPost.ReadOnly = true;
      this.clmPost.Width = 150;
      this.clmSana.HeaderText = "Дата";
      this.clmSana.Name = "clmSana";
      this.clmSana.ReadOnly = true;
      this.clmVaqt.HeaderText = "Время";
      this.clmVaqt.Name = "clmVaqt";
      this.clmVaqt.ReadOnly = true;
      this.clmPost_Id.HeaderText = "Post Id";
      this.clmPost_Id.Name = "clmPost_Id";
      this.clmPost_Id.ReadOnly = true;
      this.clmPost_Id.Visible = false;
      this.clmPost_Id.Width = 10;
      this.clmSigm.HeaderText = "К-во дней хранения(дни)";
      this.clmSigm.Name = "clmSigm";
      this.clmSigm.ReadOnly = true;
      this.clmSigm.Width = 120;
      this.clmOqimTezligi.HeaderText = "Скорость течения, м3/сек";
      this.clmOqimTezligi.Name = "clmOqimTezligi";
      this.clmOqimTezligi.ReadOnly = true;
      this.clmOqimTezligi.Width = 120;
      this.clmDaryoSarfi.HeaderText = "Расход реки, м3/сек";
      this.clmDaryoSarfi.Name = "clmDaryoSarfi";
      this.clmDaryoSarfi.ReadOnly = true;
      this.clmOqimSarfi.HeaderText = "Расход сточных.вод, м3/сек";
      this.clmOqimSarfi.Name = "clmOqimSarfi";
      this.clmOqimSarfi.ReadOnly = true;
      this.clmOqimSarfi.Width = 120;
      this.clmNamlik.HeaderText = "запах, балл";
      this.clmNamlik.Name = "clmNamlik";
      this.clmNamlik.ReadOnly = true;
      this.clmTiniqlik.HeaderText = "Прозрачность, см";
      this.clmTiniqlik.Name = "clmTiniqlik";
      this.clmTiniqlik.ReadOnly = true;
      this.clmTiniqlik.Width = 120;
      this.clmRangi.HeaderText = "Цветность, град";
      this.clmRangi.Name = "clmRangi";
      this.clmRangi.ReadOnly = true;
      this.clmHarorat.HeaderText = "Температура, оС";
      this.clmHarorat.Name = "clmHarorat";
      this.clmHarorat.ReadOnly = true;
      this.clmSuzuvchi.HeaderText = "Взвешенные вещества, мг/дм3";
      this.clmSuzuvchi.Name = "clmSuzuvchi";
      this.clmSuzuvchi.ReadOnly = true;
      this.clmSuzuvchi.Width = 120;
      this.clmpH.HeaderText = "рН";
      this.clmpH.Name = "clmpH";
      this.clmpH.ReadOnly = true;
      this.clmO2.HeaderText = "О2, мг/дм3";
      this.clmO2.Name = "clmO2";
      this.clmO2.ReadOnly = true;
      this.clmTuyingan.HeaderText = "Насыщение О2, мг/дм3";
      this.clmTuyingan.Name = "clmTuyingan";
      this.clmTuyingan.ReadOnly = true;
      this.clmCO2.HeaderText = "СО2, мг/дм3";
      this.clmCO2.Name = "clmCO2";
      this.clmCO2.ReadOnly = true;
      this.clmQattiqlik.HeaderText = "Жесткость, мг-экв/дм3";
      this.clmQattiqlik.Name = "clmQattiqlik";
      this.clmQattiqlik.ReadOnly = true;
      this.clmXlorid.HeaderText = "Хлориды, мг/дм3";
      this.clmXlorid.Name = "clmXlorid";
      this.clmXlorid.ReadOnly = true;
      this.clmSulfat.HeaderText = "Сульфаты, мг/дм3";
      this.clmSulfat.Name = "clmSulfat";
      this.clmSulfat.ReadOnly = true;
      this.clmGidroKarbanat.HeaderText = "Гидрокарбонаты, мг/дм3";
      this.clmGidroKarbanat.Name = "clmGidroKarbanat";
      this.clmGidroKarbanat.ReadOnly = true;
      this.clmGidroKarbanat.Width = 130;
      this.clmNa.HeaderText = "Na, мг/дм3";
      this.clmNa.Name = "clmNa";
      this.clmNa.ReadOnly = true;
      this.clmK.HeaderText = "K, мг/дм3";
      this.clmK.Name = "clmK";
      this.clmK.ReadOnly = true;
      this.clmCa.HeaderText = "Ca, мг/дм3";
      this.clmCa.Name = "clmCa";
      this.clmCa.ReadOnly = true;
      this.clmMg.HeaderText = "Mg, мг/дм3";
      this.clmMg.Name = "clmMg";
      this.clmMg.ReadOnly = true;
      this.clmMineral.HeaderText = "Минерализация, мг/дм3";
      this.clmMineral.Name = "clmMineral";
      this.clmMineral.ReadOnly = true;
      this.clmMineral.Width = 120;
      this.clmXPK.HeaderText = "ХПК, мг/дм3";
      this.clmXPK.Name = "clmXPK";
      this.clmXPK.ReadOnly = true;
      this.clmBPK.HeaderText = "БПК5, мг/дм3";
      this.clmBPK.Name = "clmBPK";
      this.clmBPK.ReadOnly = true;
      this.clmAzotAmonniy.HeaderText = "Азот аммонний, мг/дм3";
      this.clmAzotAmonniy.Name = "clmAzotAmonniy";
      this.clmAzotAmonniy.ReadOnly = true;
      this.clmAzotAmonniy.Width = 120;
      this.clmAzotNitritniy.HeaderText = "Азот нитритный, мг/дм3";
      this.clmAzotNitritniy.Name = "clmAzotNitritniy";
      this.clmAzotNitritniy.ReadOnly = true;
      this.clmAzotNitritniy.Width = 120;
      this.clmAzotNitratniy.HeaderText = "Азот нитратный, мг/дм3";
      this.clmAzotNitratniy.Name = "clmAzotNitratniy";
      this.clmAzotNitratniy.ReadOnly = true;
      this.clmAzotSumma.HeaderText = "Сумма азота, мг/дм3";
      this.clmAzotSumma.Name = "clmAzotSumma";
      this.clmAzotSumma.ReadOnly = true;
      this.clmFosfat.HeaderText = "Фосфат, мг/дм3";
      this.clmFosfat.Name = "clmFosfat";
      this.clmFosfat.ReadOnly = true;
      this.clmSi.HeaderText = "Si, мг/дм3";
      this.clmSi.Name = "clmSi";
      this.clmSi.ReadOnly = true;
      this.clmElektr.HeaderText = "Электропроводность, мкСм/см";
      this.clmElektr.Name = "clmElektr";
      this.clmElektr.ReadOnly = true;
      this.clmElektr.Width = 160;
      this.clmEh_MB.HeaderText = "Eh, MB";
      this.clmEh_MB.Name = "clmEh_MB";
      this.clmEh_MB.ReadOnly = true;
      this.clmPumumiy.HeaderText = "P общий, мг/дм3";
      this.clmPumumiy.Name = "clmPumumiy";
      this.clmPumumiy.ReadOnly = true;
      this.clmFeUmumiy.HeaderText = "Fe общий, мг/дм3";
      this.clmFeUmumiy.Name = "clmFeUmumiy";
      this.clmFeUmumiy.ReadOnly = true;
      this.clmCi.HeaderText = "Сu, мкг/дм3";
      this.clmCi.Name = "clmCi";
      this.clmCi.ReadOnly = true;
      this.clmZn.HeaderText = "Zn, мкг/дм3";
      this.clmZn.Name = "clmZn";
      this.clmZn.ReadOnly = true;
      this.clmNi.HeaderText = "Ni, мкг/дм3";
      this.clmNi.Name = "clmNi";
      this.clmNi.ReadOnly = true;
      this.clmCr.HeaderText = "Cr, мкг/дм3";
      this.clmCr.Name = "clmCr";
      this.clmCr.ReadOnly = true;
      this.clmCr_VI.HeaderText = "Cr-VI, мкг/дм3";
      this.clmCr_VI.Name = "clmCr_VI";
      this.clmCr_VI.ReadOnly = true;
      this.clmCr_III.HeaderText = "Cr-III, мкг/дм3";
      this.clmCr_III.Name = "clmCr_III";
      this.clmCr_III.ReadOnly = true;
      this.clmPb.HeaderText = "Pb, мкг/дм3";
      this.clmPb.Name = "clmPb";
      this.clmPb.ReadOnly = true;
      this.clmHg.HeaderText = "Hg, мкг/дм3";
      this.clmHg.Name = "clmHg";
      this.clmHg.ReadOnly = true;
      this.clmCd.HeaderText = "Cd, мкг/дм3";
      this.clmCd.Name = "clmCd";
      this.clmCd.ReadOnly = true;
      this.clmMn.HeaderText = "Mn, мкг/дм3";
      this.clmMn.Name = "clmMn";
      this.clmMn.ReadOnly = true;
      this.clmAs.HeaderText = "As, мкг/дм3";
      this.clmAs.Name = "clmAs";
      this.clmAs.ReadOnly = true;
      this.clmFenollar.HeaderText = "Фенолы, мг/дм3";
      this.clmFenollar.Name = "clmFenollar";
      this.clmFenollar.ReadOnly = true;
      this.clmNeft.HeaderText = "Нефтепродукты, мг/дм3";
      this.clmNeft.Name = "clmNeft";
      this.clmNeft.ReadOnly = true;
      this.clmNeft.Width = 120;
      this.clmSPAB.HeaderText = "СПАВ, мг/дм3";
      this.clmSPAB.Name = "clmSPAB";
      this.clmSPAB.ReadOnly = true;
      this.clmF.HeaderText = "F, мг/дм3";
      this.clmF.Name = "clmF";
      this.clmF.ReadOnly = true;
      this.clmSianidi.HeaderText = "Цианиды, мг/дм3";
      this.clmSianidi.Name = "clmSianidi";
      this.clmSianidi.ReadOnly = true;
      this.clmProponil.HeaderText = "Пропонил, мг/дм3";
      this.clmProponil.Name = "clmProponil";
      this.clmProponil.ReadOnly = true;
      this.clmDDE.HeaderText = "ДДЕ, мкг/дм3";
      this.clmDDE.Name = "clmDDE";
      this.clmDDE.ReadOnly = true;
      this.clmRogor.HeaderText = "Рогор, мкг/дм3";
      this.clmRogor.Name = "clmRogor";
      this.clmRogor.ReadOnly = true;
      this.clmDDT.HeaderText = "ДДТ, мкг/дм3";
      this.clmDDT.Name = "clmDDT";
      this.clmDDT.ReadOnly = true;
      this.clmGeksaxloran.HeaderText = "Гексахлоран (α-ГХЦГ), мкг/дм3";
      this.clmGeksaxloran.Name = "clmGeksaxloran";
      this.clmGeksaxloran.ReadOnly = true;
      this.clmGeksaxloran.Width = 120;
      this.clmLindan.HeaderText = "Линдан (γ-ГХЦГ), мкг/дм3";
      this.clmLindan.Name = "clmLindan";
      this.clmLindan.ReadOnly = true;
      this.clmLindan.Width = 120;
      this.clmDDD.HeaderText = "ДДД, мкг/дм3";
      this.clmDDD.Name = "clmDDD";
      this.clmDDD.ReadOnly = true;
      this.clmMetafos.HeaderText = "Метафос, мкг/дм3";
      this.clmMetafos.Name = "clmMetafos";
      this.clmMetafos.ReadOnly = true;
      this.clmButifos.HeaderText = "Бутифос, мкг/дм3";
      this.clmButifos.Name = "clmButifos";
      this.clmButifos.ReadOnly = true;
      this.clmDalapon.HeaderText = "Далапон, мкг/дм3";
      this.clmDalapon.Name = "clmDalapon";
      this.clmDalapon.ReadOnly = true;
      this.clmKarbofos.HeaderText = "Карбофос, мкг/дм3";
      this.clmKarbofos.Name = "clmKarbofos";
      this.clmKarbofos.ReadOnly = true;
      this.clmStatus.HeaderText = "Status";
      this.clmStatus.Name = "clmStatus";
      this.clmStatus.ReadOnly = true;
      this.clmStatus.Visible = false;
      this.menuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.файлToolStripMenuItem
      });
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(1095, 24);
      this.menuStrip1.TabIndex = 8;
      this.menuStrip1.Text = "menuStrip1";
      this.файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.экспортКExcelToolStripMenuItem
      });
      this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      this.файлToolStripMenuItem.Size = new Size(48, 20);
      this.файлToolStripMenuItem.Text = "Файл";
      this.экспортКExcelToolStripMenuItem.Name = "экспортКExcelToolStripMenuItem";
      this.экспортКExcelToolStripMenuItem.Size = new Size(157, 22);
      this.экспортКExcelToolStripMenuItem.Text = "Экспорт к Excel";
      this.экспортКExcelToolStripMenuItem.Click += new EventHandler(this.экспортКExcelToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1095, 381);
      this.Controls.Add((Control) this.dgvAnalysis);
      this.Controls.Add((Control) this.menuStrip1);
      this.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new Padding(4, 4, 4, 4);
      this.Name = nameof (HisobotFormEDK);
      this.Text = "Отчет";
      ((ISupportInitialize) this.dgvAnalysis).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
