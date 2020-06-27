// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.HisobotFormIZV
// Assembly: HydroDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E6B423-C642-4D32-8211-26843BE94D82
// Assembly location: D:\Programmes\Projects\C#\HydroDemo\Debug — копия\HydroDemo.exe

using HydroDemo.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace HydroDemo.Forms
{
    public class HisobotFormIZV : Form
    {
        private IContainer components = (IContainer)null;
        private KompanentaClass[] koms;
        private int Year;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem tsmnuExport;
        private ToolStripMenuItem tsmnuBoyash;
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
        private DataGridViewTextBoxColumn clm;
        private DataGridViewTextBoxColumn clmIZV;
        private DataGridViewTextBoxColumn clmClass;
        private DataGridViewTextBoxColumn clmStatus;

        public HisobotFormIZV(List<AnalysisClass> analysiss, KompanentaClass[] komps, List<RiverClass> rivers, List<PostClass> posts, int Year)
        {
            this.InitializeComponent();
            
            this.koms = komps;
            for (int index = 0; index < komps.Length; ++index)
            {
                if (komps[index].PDK == 0.0 || index == 9 || index == 13 || index == 14 || index == 17 || index == 18 || index == 19 || index == 20 || index == 28 || index == 32 || index == 36 || index == 40 || index == 41 || index == 42 || index == 15 || index > 47)
                    this.dgvAnalysis.Columns[index + 7].Visible = false;
            }
            double izv = 0.0;
            string izvclass = "VI";
            string izvName = "dd";
            int num;
            for (int i = 0; i < analysiss.Count; i = num + 1)
            {
                //analysiss[i] = this.ToMili(analysiss[i]);
                ToPDK(analysiss[i]);
                this.AnalysisIZV(analysiss[i], out izv, out izvclass, out izvName);
                string str1 = posts.Where<PostClass>((Func<PostClass, bool>)(x => x.Id == analysiss[i].Post_Id)).Select<PostClass, string>((Func<PostClass, string>)(x => x.NameObserve)).FirstOrDefault<string>();
                string str2 = posts.Where<PostClass>((Func<PostClass, bool>)(x => x.Id == analysiss[i].Post_Id)).Select<PostClass, string>((Func<PostClass, string>)(x => x.NameObject)).FirstOrDefault<string>();
                this.dgvAnalysis.Rows.Add((object)analysiss[i].Id, 
                    (object)(i + 1), (object)str2, (object)str1, (object)analysiss[i].Sana, 
                    (object)analysiss[i].Vaqt, (object)analysiss[i].Post_Id, (object)(analysiss[i].Sigm < 0 ? "-" : ToString(analysiss[i].Sigm)), 
                    (object)(analysiss[i].OqimTezligi < 0 ? "-" : ToString(analysiss[i].OqimTezligi)), 
                    (object)(analysiss[i].DaryoSarfi < 0 ? "-" : ToString(analysiss[i].DaryoSarfi)), 
                    (object)(analysiss[i].OqimSarfi < 0 ? "-" : ToString(analysiss[i].OqimSarfi)), 
                    (object)(analysiss[i].Namlik < 0 ? "-" : ToString(analysiss[i].Namlik)), 
                    (object)(analysiss[i].Tiniqlik < 0 ? "-" : ToString(analysiss[i].Tiniqlik)), 
                    (object)(analysiss[i].Rangi < 0 ? "-" : ToString(analysiss[i].Rangi)), 
                    (object)(analysiss[i].Harorat < 0 ? "-" : ToString(analysiss[i].Harorat)), 
                    (object)(analysiss[i].Suzuvchi < 0 ? "-" : ToString(analysiss[i].Suzuvchi)), 
                    (object)(analysiss[i].pH < 0 ? "-" : ToString(analysiss[i].pH)), 
                    (object)(analysiss[i].O2 < 0 ? "-" : ToString(analysiss[i].O2)),
                    (object)(analysiss[i].Tuyingan < 0 ? "-" : ToString(analysiss[i].Tuyingan)), 
                    (object)(analysiss[i].CO2 < 0 ? "-" : ToString(analysiss[i].CO2)), 
                    (object)(analysiss[i].Qattiqlik < 0 ? "-" : ToString(analysiss[i].Qattiqlik)), 
                    (object)(analysiss[i].Xlorid < 0 ? "-" : ToString(analysiss[i].Xlorid)), 
                    (object)(analysiss[i].Sulfat < 0 ? "-" : ToString(analysiss[i].Sulfat)), 
                    (object)(analysiss[i].GidroKarbanat < 0 ? "-" : ToString(analysiss[i].GidroKarbanat)), 
                    (object)(analysiss[i].Na < 0 ? "-" : ToString(analysiss[i].Na)), 
                    (object)(analysiss[i].K < 0 ? "-" : ToString(analysiss[i].K)), 
                    (object)(analysiss[i].Ca < 0 ? "-" : ToString(analysiss[i].Ca)), 
                    (object)(analysiss[i].Mg < 0 ? "-" : ToString(analysiss[i].Mg)), 
                    (object)(analysiss[i].Mineral < 0 ? "-" : ToString(analysiss[i].Mineral)), 
                    (object)(analysiss[i].XPK < 0 ? "-" : ToString(analysiss[i].XPK)), 
                    (object)(analysiss[i].BPK < 0 ? "-" : ToString(analysiss[i].BPK)), 
                    (object)(analysiss[i].AzotAmonniy < 0 ? "-" : ToString(analysiss[i].AzotAmonniy)),
                    (object)(analysiss[i].AzotNitritniy < 0 ? "-" : ToString(analysiss[i].AzotNitritniy)),
                    (object)(analysiss[i].AzotNitratniy < 0 ? "-" : ToString(analysiss[i].AzotNitratniy)),
                    (object)(analysiss[i].AzotSumma < 0 ? "-" : ToString(analysiss[i].AzotSumma)),
                    (object)(analysiss[i].Fosfat < 0 ? "-" : ToString(analysiss[i].Fosfat)), 
                    (object)(analysiss[i].Si < 0 ? "-" : ToString(analysiss[i].Si)), 
                    (object)(analysiss[i].Elektr < 0 ? "-" : ToString(analysiss[i].Elektr)),
                    (object)(analysiss[i].Eh_MB < 0 ? "-" : ToString(analysiss[i].Eh_MB)), 
                    (object)(analysiss[i].PUmumiy < 0 ? "-" : ToString(analysiss[i].PUmumiy)),
                    (object)(analysiss[i].FeUmumiy < 0 ? "-" : ToString(analysiss[i].FeUmumiy)),
                    (object)(analysiss[i].Ci < 0 ? "-" : ToString(analysiss[i].Ci)), 
                    (object)(analysiss[i].Zn < 0 ? "-" : ToString(analysiss[i].Zn)), 
                    (object)(analysiss[i].Ni < 0 ? "-" : ToString(analysiss[i].Ni)), 
                    (object)(analysiss[i].Cr < 0 ? "-" : ToString(analysiss[i].Cr)), 
                    (object)(analysiss[i].Cr_VI < 0 ? "-" : ToString(analysiss[i].Cr_VI)),
                    (object)(analysiss[i].Cr_III < 0 ? "-" : ToString(analysiss[i].Cr_III)), 
                    (object)(analysiss[i].Pb < 0 ? "-" : ToString(analysiss[i].Pb)),
                    (object)(analysiss[i].Hg < 0 ? "-" : ToString(analysiss[i].Hg)), 
                    (object)(analysiss[i].Cd < 0 ? "-" : ToString(analysiss[i].Cd)),
                    (object)(analysiss[i].Mn < 0 ? "-" : ToString(analysiss[i].Mn)), 
                    (object)(analysiss[i].As < 0 ? "-" : ToString(analysiss[i].As)), 
                    (object)(analysiss[i].Fenollar < 0 ? "-" : ToString(analysiss[i].Fenollar)),
                    (object)(analysiss[i].Neft < 0 ? "-" : ToString(analysiss[i].Neft)), 
                    (object)(analysiss[i].SPAB < 0 ? "-" : ToString(analysiss[i].SPAB)),
                    (object)(analysiss[i].F < 0 ? "-" : ToString(analysiss[i].F)),
                    (object)(analysiss[i].Sianidi < 0 ? "-" : ToString(analysiss[i].Sianidi)),
                    (object)(analysiss[i].Proponil < 0 ? "-" : ToString(analysiss[i].Proponil)),
                    (object)(analysiss[i].DDE < 0 ? "-" : ToString(analysiss[i].DDE)),
                    (object)(analysiss[i].Rogor < 0 ? "-" : ToString(analysiss[i].Rogor)),
                    (object)(analysiss[i].DDT < 0 ? "-" : ToString(analysiss[i].DDT)),
                    (object)(analysiss[i].Geksaxloran < 0 ? "-" : ToString(analysiss[i].Geksaxloran)), 
                    (object)(analysiss[i].Lindan < 0 ? "-" : ToString(analysiss[i].Lindan)), 
                    (object)(analysiss[i].DDD < 0 ? "-" : ToString(analysiss[i].DDD)), 
                    (object)(analysiss[i].Metafos < 0 ? "-" : ToString(analysiss[i].Metafos)),
                    (object)(analysiss[i].Butifos < 0 ? "-" : ToString(analysiss[i].Butifos)), 
                    (object)(analysiss[i].Dalapon < 0 ? "-" : ToString(analysiss[i].Dalapon)),
                    (object)(analysiss[i].Karbofos < 0 ? "-" : ToString(analysiss[i].Karbofos)),
                    (object)izvName, (object)izv, (object)izvclass, (object)analysiss[i].Status);
                num = i;
            }
            this.Year = Year;
        }

        private void ToPDK(AnalysisClass analysis)
        {
            analysis.pH /= koms[9].PDK;
            analysis.O2 = Kislorod(analysis.O2);
            analysis.Qattiqlik /= koms[13].PDK;
            analysis.Xlorid /= koms[14].PDK;
            analysis.Sulfat /= koms[15].PDK;
            analysis.Na /= koms[17].PDK;
            analysis.K /= koms[18].PDK;
            analysis.Ca /= koms[19].PDK;
            analysis.Mg /= koms[20].PDK;
            analysis.Mineral /= koms[21].PDK;
            analysis.XPK /= koms[22].PDK;
            analysis.BPK = BPK(analysis.BPK);
            analysis.AzotAmonniy /= koms[24].PDK;
            analysis.AzotNitritniy /= koms[25].PDK;
            analysis.AzotNitratniy /= koms[26].PDK;
            analysis.Fosfat /= koms[28].PDK;
            analysis.PUmumiy /= koms[32].PDK;
            analysis.FeUmumiy /= koms[33].PDK;
            analysis.Ci /= koms[34].PDK;
            analysis.Zn /= koms[35].PDK;
            analysis.Cr_VI /= koms[38].PDK;
            analysis.Pb /= koms[40].PDK;
            analysis.Hg /= koms[41].PDK;
            analysis.Cd /= koms[42].PDK;
            analysis.As /= koms[44].PDK;
            analysis.Fenollar /= koms[45].PDK;
            analysis.Neft /= koms[46].PDK;
            analysis.SPAB /= koms[47].PDK;
            analysis.F /= koms[48].PDK;
            analysis.Sianidi /= koms[49].PDK;
            analysis.DDT /= koms[53].PDK;
            analysis.Geksaxloran /= koms[54].PDK;
            analysis.Lindan /= koms[55].PDK;
        }

        private AnalysisClass ToMili(AnalysisClass analysis)
        {
            AnalysisClass analysisClass1 = analysis;
            analysisClass1.As = analysisClass1.As;
            AnalysisClass analysisClass2 = analysis;
            analysisClass2.Ci = analysisClass2.Ci;
            AnalysisClass analysisClass3 = analysis;
            analysisClass3.Zn = analysisClass3.Zn;
            AnalysisClass analysisClass4 = analysis;
            analysisClass4.Ni = analysisClass4.Ni;
            AnalysisClass analysisClass5 = analysis;
            analysisClass5.Cr_VI = analysisClass5.Cr_VI;
            AnalysisClass analysisClass6 = analysis;
            analysisClass6.Cr_III = analysisClass6.Cr_III;
            AnalysisClass analysisClass7 = analysis;
            analysisClass7.Hg = analysisClass7.Hg;
            AnalysisClass analysisClass8 = analysis;
            analysisClass8.Cd = analysisClass8.Cd;
            AnalysisClass analysisClass9 = analysis;
            analysisClass9.DDT = analysisClass9.DDT;
            AnalysisClass analysisClass10 = analysis;
            analysisClass10.Geksaxloran = analysisClass10.Geksaxloran;
            AnalysisClass analysisClass11 = analysis;
            analysisClass11.Pb = analysisClass11.Pb;
            return analysis;
        }

        private void AnalysisIZV(AnalysisClass analysis, out double izv, out string izvclass, out string izvName)
        {
            //StreamWriter streamWriter = new StreamWriter("base.txt");
            izvclass = "";
            izvName = "";
            double[] massiv = this.ToMassiv(analysis);
            double num1 = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            int index1 = 0;
            int index2 = 0;
            int index3 = 0;
            int index4 = 0;
            double num5 = massiv[10];
            double num6 = massiv[23];
            //MessageBox.Show(koms[21].PDK.ToString());
            for (int index5 = 0; index5 < massiv.Length; ++index5)
            {
                if (this.koms[index5].PDK != 0.0 && massiv[index5] > 0.0 &&
                    (
                    index5 == 22 || index5 == 24 || index5 == 25 ||
                    index5 == 26 || index5 == 33 || index5 == 34 ||
                    index5 == 35 || index5 == 38 || index5 == 44 ||
                    index5 == 45 || index5 == 46 || index5 == 47 ||
                    index5 == 21)) 
                {
                    if (num1 < massiv[index5])
                    {
                        num4 = num3;
                        index4 = index3;
                        num3 = num2;
                        index3 = index2;
                        num2 = num1;
                        index2 = index1;
                        num1 = massiv[index5];
                        index1 = index5;
                    }
                    else if (num2 < massiv[index5])
                    {
                        num4 = num3;
                        index4 = index3;
                        num3 = num2;
                        index3 = index2;
                        num2 = massiv[index5];
                        index2 = index5;
                    }
                    else if (num3 < massiv[index5])
                    {
                        num4 = num3;
                        index4 = index3;
                        num3 = massiv[index5];
                        index3 = index5;
                    }
                    else if (num4 < massiv[index5])
                    {
                        num4 = massiv[index5];
                        index4 = index5;
                    }
                    //streamWriter.WriteLine(string.Format("i = {0};\ta{1} = {2};\tkoms[{3}].PDK = {4};\tKop = {5}", (object)(index5 + 1), (object)(index5 + 1), (object)massiv[index5], (object)(index5 + 1), (object)this.koms[index5].PDK, (object)(massiv[index5] / this.koms[index5].PDK)));
                }
            }
            double num7 = massiv[index1];
            double num8 = massiv[index2];
            double num9 = massiv[index3];
            double num10 = massiv[index4];
            //MessageBox.Show(massiv[index1] + "\n" + massiv[index2] + "\n" + massiv[index3] + "\n" + massiv[index4]);
            //MessageBox.Show(index1 + "\n" + index2 + "\n" + index3 + "\n" + index4);
            //streamWriter.WriteLine(string.Format("a1 = {0};\ta2 = {1};\ta3 = {2};\ta4 = {3};\ta5 = {4};\ta6 = {5}", (object)num5, (object)num6, (object)num7, (object)num8, (object)num9, (object)num10));
            izv = (num5 + num6 + num7 + num8 + num9 + num10) / 6.0;
            if (izv < 0 || num5 < 0 || num6 < 0 || massiv[index1] < 0 || massiv[index3] < 0 || massiv[index4] < 0)
            {
                izvclass = "Ошибка";
                izvName = "Ошибка";
                izv = -1;
                return;
            }
            //streamWriter.WriteLine("izv = " + (object)izv);
            if (izv <= 0.2)
            {
                izvclass = "I";
                izvName = "Очень чистые";
            }
            else if (izv <= 1.0)
            {
                izvclass = "II";
                izvName = "Чистые";
            }
            else if (izv <= 2.0)
            {
                izvclass = "III";
                izvName = "Умеренно загрязненные";
            }
            else if (izv <= 4.0)
            {
                izvclass = "IV";
                izvName = "Загрязненные";
            }
            else if (izv <= 6.0)
            {
                izvclass = "V";
                izvName = "Грязные";
            }
            else if (izv <= 10.0)
            {
                izvclass = "VI";
                izvName = "Очень грязные";
            }
            else
            {
                izvclass = "VII";
                izvName = "Чрезвычайно грязные";
            }
            //streamWriter.Close();
        }

        private double Kislorod(double O)
        {
            double result = 0;
            if (O <= 5.0)
            {
                result = 20.0 / O;
            }
            else
            if (O <= 6.0)
            {
                result = 12.0 / O;
            }
            else
            {
                result = 6.0 / O;
            }
            return result;
        }

        private double BPK(double bpk)
        {
            double result = 0;
            if (bpk <= 3.0)
            {
                result = bpk / 3.0;
            }
            else
            if (bpk <= 15.0)
            {
                result = bpk / 2.0;
            }
            else
            {
                result = bpk;
            }
            return result;
        }

        private void tsmnuBoyash_Click(object sender, EventArgs e)
        {
            this.tsmnuBoyash.Checked = !this.tsmnuBoyash.Checked;
            if (this.tsmnuBoyash.Checked)
            {
                for (int index = 0; index < this.dgvAnalysis.Rows.Count; ++index)
                {
                    string s = this.dgvAnalysis.Rows[index].Cells[this.clmClass.Name].Value.ToString();

                    if (s == "IV")
                        this.dgvAnalysis.Rows[index].Cells[this.clmIZV.Name].Style.BackColor = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 0);
                    else if (s == "II")
                        this.dgvAnalysis.Rows[index].Cells[this.clmIZV.Name].Style.BackColor = Color.FromArgb(141, 180, 226);
                    else if (s == "VI")
                        this.dgvAnalysis.Rows[index].Cells[this.clmIZV.Name].Style.BackColor = Color.FromArgb((int)byte.MaxValue, 0, 0);
                    else
                    if (s == "V")
                        this.dgvAnalysis.Rows[index].Cells[this.clmIZV.Name].Style.BackColor = Color.FromArgb((int)byte.MaxValue, 192, 0);
                    else if (s == "I")
                        this.dgvAnalysis.Rows[index].Cells[this.clmIZV.Name].Style.BackColor = Color.FromArgb(83, 141, 213);
                    else
                    if (s == "VII")
                        this.dgvAnalysis.Rows[index].Cells[this.clmIZV.Name].Style.BackColor = Color.FromArgb(192, 0, 0);
                    else if (s == "III")
                        this.dgvAnalysis.Rows[index].Cells[this.clmIZV.Name].Style.BackColor = Color.FromArgb(146, 208, 80);

                }
            }
            else
            {
                for (int index = 0; index < this.dgvAnalysis.Rows.Count; ++index)
                    this.dgvAnalysis.Rows[index].Cells[this.clmIZV.Name].Style.BackColor = Color.White;
            }
        }

        private double[] ToMassiv(AnalysisClass analysis)
        {
            return new double[61]
            {
        analysis.Sigm,
        analysis.OqimTezligi,
        analysis.DaryoSarfi,
        analysis.OqimSarfi,
        analysis.Namlik,
        analysis.Tiniqlik,
        analysis.Rangi,
        analysis.Harorat,
        analysis.Suzuvchi,
        analysis.pH,
        analysis.O2,
        analysis.Tuyingan,
        analysis.CO2,
        analysis.Qattiqlik,
        analysis.Xlorid,
        analysis.Sulfat,
        analysis.GidroKarbanat,
        analysis.Na,
        analysis.K,
        analysis.Ca,
        analysis.Mg,
        analysis.Mineral,
        analysis.XPK,
        analysis.BPK,
        analysis.AzotAmonniy,
        analysis.AzotNitritniy,
        analysis.AzotNitratniy,
        analysis.AzotSumma,
        analysis.Fosfat,
        analysis.Si,
        analysis.Elektr,
        analysis.Eh_MB,
        analysis.PUmumiy,
        analysis.FeUmumiy,
        analysis.Ci,
        analysis.Zn,
        analysis.Ni,
        analysis.Cr,
        analysis.Cr_VI,
        analysis.Cr_III,
        analysis.Pb,
        analysis.Hg,
        analysis.Cd,
        analysis.Mn,
        analysis.As,
        analysis.Fenollar,
        analysis.Neft,
        analysis.SPAB,
        analysis.F,
        analysis.Sianidi,
        analysis.Proponil,
        analysis.DDE,
        analysis.Rogor,
        analysis.DDT,
        analysis.Geksaxloran,
        analysis.Lindan,
        analysis.DDD,
        analysis.Metafos,
        analysis.Butifos,
        analysis.Dalapon,
        analysis.Karbofos
            };
        }

        private void tsmnuExport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            application.Workbooks.Add((object)Missing.Value);
            _Worksheet worksheet = (_Worksheet)(application.Sheets.Add(System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing) as Worksheet);
            this.Cursor = Cursors.WaitCursor;
            worksheet.Cells[(object)1, (object)1] = (object)("Индексы загрязнения поверхностных вод по постам за " + (object)this.Year + " год");
            Range range1 = worksheet.get_Range((object)"A1", (object)"Q1");
            range1.Merge(System.Type.Missing);
            range1.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
            range1.Font.Size = (object)14;
            range1.Font.Name = (object)"Times New Roman";
            int num1 = 2;
            double result;
            for (int index1 = 0; index1 < this.dgvAnalysis.Rows.Count; ++index1)
            {
                if (index1 % 32 == 0)
                {
                    ++num1;
                    int num2 = 1;
                    worksheet.Cells[(object)num1, (object)num2] = (object)"Водный объект (пункт, категория, створ)";
                    for (int index2 = 6; index2 < this.dgvAnalysis.ColumnCount - 4; ++index2)
                    {
                        if (this.dgvAnalysis.Columns[index2].Visible)
                        {
                            ++num2;
                            worksheet.Cells[(object)num1, (object)num2] = (object)this.dgvAnalysis.Columns[index2].HeaderText;
                        }
                    }
                    ++num2;
                    worksheet.Cells[num1, num2] = "ИЗВ";
                    Range range2 = worksheet.get_Range((object)("A" + (object)num1), (object)("Q" + (object)num1));
                    range2.WrapText = (object)true;
                    range2.VerticalAlignment = (object)XlVAlign.xlVAlignCenter;
                    range2.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                    num1++;
                    
                    if (index1 == 0)
                    {
                        Range cells = worksheet.Cells;
                        num2 = num1 + 1;
                        num1 = num2;
                        // ISSUE: variable of a boxed type
                        object local1 = (ValueType)num2;
                        // ISSUE: variable of a boxed type
                        object local2 = (ValueType)1;
                        string str = this.dgvAnalysis.Rows[index1].Cells[2].Value.ToString() + "," + this.dgvAnalysis.Rows[index1].Cells[3].Value.ToString();
                        cells[(object)local1, (object)local2] = (object)str;
                        int num3 = 1;
                        
                        for (int index2 = 6; index2 < this.dgvAnalysis.ColumnCount - 4; ++index2)
                        {
                            if (this.dgvAnalysis.Columns[index2].Visible)
                            {
                                ++num3;
                                if (double.TryParse(this.dgvAnalysis.Rows[index1].Cells[index2].Value.ToString(), out result))
                                    worksheet.Cells[(object)num1, (object)num3] = (object)result;
                                else
                                    worksheet.Cells[(object)num1, (object)num3] = (object)"-";
                                //else
                                //    worksheet.Cells[(object)num1, (object)num3] = this.dgvAnalysis.Rows[index1].Cells[index2].Value;
                            }
                        }
                        num3++;
                        if (double.TryParse(this.dgvAnalysis.Rows[index1].Cells[this.dgvAnalysis.ColumnCount - 3].Value.ToString(), out result))
                            worksheet.Cells[(object)num1, (object)num3] = (object)result;
                        else
                            worksheet.Cells[(object)num1, (object)num3] = (object)"-";
                    }
                }
                else
                {
                    Range cells = worksheet.Cells;
                    int num2 = num1 + 1;
                    num1 = num2;
                    // ISSUE: variable of a boxed type
                    object local1 = (ValueType)num2;
                    // ISSUE: variable of a boxed type
                    object local2 = (ValueType)1;
                    string str = this.dgvAnalysis.Rows[index1].Cells[2].Value.ToString() + "," + this.dgvAnalysis.Rows[index1].Cells[3].Value.ToString();
                    cells[(object)local1, (object)local2] = (object)str;
                    int num3 = 1;
                    for (int index2 = 6; index2 < this.dgvAnalysis.ColumnCount; ++index2)
                    {
                        if (this.dgvAnalysis.Columns[index2].Visible)
                        {
                            ++num3;
                            if (num3 == 18)
                                num3--;
                            if (double.TryParse(this.dgvAnalysis.Rows[index1].Cells[index2].Value.ToString(), out result))
                                worksheet.Cells[(object)num1, (object)num3] = (object)result;
                            else
                                worksheet.Cells[(object)num1, (object)num3] = (object)"-";
                            //else
                            //    worksheet.Cells[(object)num1, (object)num3] = this.dgvAnalysis.Rows[index1].Cells[index2].Value;
                        }
                    }

                    if (double.TryParse(this.dgvAnalysis.Rows[index1].Cells[this.dgvAnalysis.ColumnCount - 3].Value.ToString(), out result) && result != -1)
                        worksheet.Cells[(object)num1, (object)num3] = (object)result;
                    else
                        worksheet.Cells[(object)num1, (object)num3] = (object)"-";
                }
                if (index1 + 1 < this.dgvAnalysis.Rows.Count && (index1 + 1) % 32 == 0)
                    ++num1;
            }
            Range range3 = worksheet.get_Range((object)"A3", (object)("Q" + (object)num1));
            range3.Borders.Weight = (object)2;
            range3.Font.Name = (object)"Times New Roman";
            range3.Font.Size = (object)10;
            range3.ColumnWidth = (object)8;
            range3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Range range4 = worksheet.get_Range((object)"A3", (object)("A" + (object)num1));
            range4.ColumnWidth = (object)30;
            range4.WrapText = (object)true;
            worksheet.get_Range((object) "Q3", (object) ("Q" + (object) num1)).NumberFormat = (object) "#,##0.00";
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            application.UserControl = true;
            application.Visible = true;
            this.Cursor = Cursors.Arrow;
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
            this.menuStrip1 = new MenuStrip();
            this.файлToolStripMenuItem = new ToolStripMenuItem();
            this.tsmnuExport = new ToolStripMenuItem();
            this.tsmnuBoyash = new ToolStripMenuItem();
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
            this.clm = new DataGridViewTextBoxColumn();
            this.clmIZV = new DataGridViewTextBoxColumn();
            this.clmClass = new DataGridViewTextBoxColumn();
            this.clmStatus = new DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((ISupportInitialize)this.dgvAnalysis).BeginInit();
            this.SuspendLayout();
            this.menuStrip1.Items.AddRange(new ToolStripItem[1]
            {
        (ToolStripItem) this.файлToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new Size(1197, 25);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
            {
        (ToolStripItem) this.tsmnuExport,
        (ToolStripItem) this.tsmnuBoyash
            });
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new Size(48, 19);
            this.файлToolStripMenuItem.Text = "Файл";
            this.tsmnuExport.Name = "tsmnuExport";
            this.tsmnuExport.Size = new Size(157, 22);
            this.tsmnuExport.Text = "Экспорт к Excel";
            this.tsmnuExport.Click += new EventHandler(this.tsmnuExport_Click);
            this.tsmnuBoyash.Name = "tsmnuBoyash";
            this.tsmnuBoyash.Size = new Size(157, 22);
            this.tsmnuBoyash.Text = "Краситъ";
            this.tsmnuBoyash.Click += new EventHandler(this.tsmnuBoyash_Click);
            this.dgvAnalysis.AllowUserToAddRows = false;
            this.dgvAnalysis.AllowUserToDeleteRows = false;
            this.dgvAnalysis.AllowUserToOrderColumns = true;
            this.dgvAnalysis.AllowUserToResizeColumns = false;
            this.dgvAnalysis.AllowUserToResizeRows = false;
            this.dgvAnalysis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvAnalysis.BackgroundColor = Color.White;
            gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridViewCellStyle1.BackColor = SystemColors.Control;
            gridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            gridViewCellStyle1.ForeColor = SystemColors.WindowText;
            gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            this.dgvAnalysis.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
            this.dgvAnalysis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalysis.Columns.AddRange((DataGridViewColumn)this.clmId, (DataGridViewColumn)this.clmRaqam, (DataGridViewColumn)this.clmRiver, (DataGridViewColumn)this.clmPost, (DataGridViewColumn)this.clmSana, (DataGridViewColumn)this.clmVaqt, (DataGridViewColumn)this.clmPost_Id, (DataGridViewColumn)this.clmSigm, (DataGridViewColumn)this.clmOqimTezligi, (DataGridViewColumn)this.clmDaryoSarfi, (DataGridViewColumn)this.clmOqimSarfi, (DataGridViewColumn)this.clmNamlik, (DataGridViewColumn)this.clmTiniqlik, (DataGridViewColumn)this.clmRangi, (DataGridViewColumn)this.clmHarorat, (DataGridViewColumn)this.clmSuzuvchi, (DataGridViewColumn)this.clmpH, (DataGridViewColumn)this.clmO2, (DataGridViewColumn)this.clmTuyingan, (DataGridViewColumn)this.clmCO2, (DataGridViewColumn)this.clmQattiqlik, (DataGridViewColumn)this.clmXlorid, (DataGridViewColumn)this.clmSulfat, (DataGridViewColumn)this.clmGidroKarbanat, (DataGridViewColumn)this.clmNa, (DataGridViewColumn)this.clmK, (DataGridViewColumn)this.clmCa, (DataGridViewColumn)this.clmMg, (DataGridViewColumn)this.clmMineral, (DataGridViewColumn)this.clmXPK, (DataGridViewColumn)this.clmBPK, (DataGridViewColumn)this.clmAzotAmonniy, (DataGridViewColumn)this.clmAzotNitritniy, (DataGridViewColumn)this.clmAzotNitratniy, (DataGridViewColumn)this.clmAzotSumma, (DataGridViewColumn)this.clmFosfat, (DataGridViewColumn)this.clmSi, (DataGridViewColumn)this.clmElektr, (DataGridViewColumn)this.clmEh_MB, (DataGridViewColumn)this.clmPumumiy, (DataGridViewColumn)this.clmFeUmumiy, (DataGridViewColumn)this.clmCi, (DataGridViewColumn)this.clmZn, (DataGridViewColumn)this.clmNi, (DataGridViewColumn)this.clmCr, (DataGridViewColumn)this.clmCr_VI, (DataGridViewColumn)this.clmCr_III, (DataGridViewColumn)this.clmPb, (DataGridViewColumn)this.clmHg, (DataGridViewColumn)this.clmCd, (DataGridViewColumn)this.clmMn, (DataGridViewColumn)this.clmAs, (DataGridViewColumn)this.clmFenollar, (DataGridViewColumn)this.clmNeft, (DataGridViewColumn)this.clmSPAB, (DataGridViewColumn)this.clmF, (DataGridViewColumn)this.clmSianidi, (DataGridViewColumn)this.clmProponil, (DataGridViewColumn)this.clmDDE, (DataGridViewColumn)this.clmRogor, (DataGridViewColumn)this.clmDDT, (DataGridViewColumn)this.clmGeksaxloran, (DataGridViewColumn)this.clmLindan, (DataGridViewColumn)this.clmDDD, (DataGridViewColumn)this.clmMetafos, (DataGridViewColumn)this.clmButifos, (DataGridViewColumn)this.clmDalapon, (DataGridViewColumn)this.clmKarbofos, (DataGridViewColumn)this.clm, (DataGridViewColumn)this.clmIZV, (DataGridViewColumn)this.clmClass, (DataGridViewColumn)this.clmStatus);
            this.dgvAnalysis.Location = new System.Drawing.Point(13, 29);
            this.dgvAnalysis.Margin = new Padding(4);
            this.dgvAnalysis.MultiSelect = false;
            this.dgvAnalysis.Name = "dgvAnalysis";
            this.dgvAnalysis.ReadOnly = true;
            this.dgvAnalysis.RowHeadersVisible = false;
            this.dgvAnalysis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnalysis.Size = new Size(1171, 298);
            this.dgvAnalysis.TabIndex = 10;
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            gridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
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
            this.clm.HeaderText = "Воды";
            this.clm.Name = "clm";
            this.clm.ReadOnly = true;
            this.clm.Width = 200;
            gridViewCellStyle3.Format = "N2";
            gridViewCellStyle3.NullValue = (object)null;
            this.clmIZV.DefaultCellStyle = gridViewCellStyle3;
            this.clmIZV.HeaderText = "ИЗВ";
            this.clmIZV.Name = "clmIZV";
            this.clmIZV.ReadOnly = true;
            this.clmClass.HeaderText = "Классы качества вод";
            this.clmClass.Name = "clmClass";
            this.clmClass.ReadOnly = true;
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Visible = false;
            this.AutoScaleDimensions = new SizeF(9f, 19f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1197, 355);
            this.Controls.Add((Control)this.dgvAnalysis);
            this.Controls.Add((Control)this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.Margin = new Padding(4);
            this.Name = nameof(HisobotFormIZV);
            this.Text = "Отчет ИЗВ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((ISupportInitialize)this.dgvAnalysis).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private string ToString(double d)
        {
            string str = d.ToString("N5");
            while (str.Last() == '0' && str[str.Length - 2] != ',')
                str = str.Substring(0, str.Length - 1);

            int i = 0;
            string res = "";
            for (;i < str.Length; i++)
            {
                res += str[i];
                if (str[i] == ',' && str[i + 1] != '0')
                    break;
            }
            i++;
            if (i < str.Length)
            {
                res += str[i];
                i++;
                if (i < str.Length)
                    res += str[i];
                i++;
                if (i < str.Length)
                    res += str[i];
            }
            return res;
        }
    }
}
