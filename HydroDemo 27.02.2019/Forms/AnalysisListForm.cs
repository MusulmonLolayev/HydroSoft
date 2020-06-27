// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.AnalysisListForm
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
  public class AnalysisListForm : Form
  {
    private byte key = 0;
    private IContainer components = (IContainer) null;
    private PostClass[] posts;
    private RiverClass[] rivers;
    private List<AnalysisClass> analysiss;
    private int row_Index;
    private ToolStrip toolStrip1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton tSBNewRiver;
    private ToolStripButton tSBEditing;
    private ToolStripButton tSBDelete;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripLabel toolStripLabel1;
    private ToolStripComboBox tcbRiverList;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripLabel toolStripLabel2;
    private ToolStripComboBox tcbPostList;
    private DataGridView dgvPostList;
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
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripButton tsbDate;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripButton tsbSearch;

    public event EventHandler GetChangeAnalysis;

    public event EventHandler SetQueryAnalysis;

    public AnalysisClass analysis { get; private set; }

    public static string strquery { get; private set; }

    private DateTime date1 { get; set; }

    private DateTime date2 { get; set; }

    public AnalysisListForm(RiverClass[] rivers, PostClass[] posts)
    {
      this.InitializeComponent();
      this.posts = posts;
      this.rivers = rivers;
      this.tcbRiverList.ComboBox.DataSource = (object) ((IEnumerable<RiverClass>) rivers).OrderBy<RiverClass, string>((Func<RiverClass, string>) (x => x.Name)).ToList<RiverClass>();
      this.tcbRiverList.ComboBox.DisplayMember = "Name";
      this.tcbPostList.ComboBox.DataSource = (object) posts;
      this.tcbPostList.ComboBox.DisplayMember = "NameObserve";
      this.analysiss = Form1.analysisForAnalysisList;
      this.DBFill();
      this.date1 = DateTime.Now;
      this.date2 = DateTime.Now;
    }

    private void DBFill()
    {
      try
      {
        this.dgvPostList.Rows.Clear();
        int num;
        for (int i = 0; i < this.analysiss.Count; i = num + 1)
        {
          string str1 = ((IEnumerable<PostClass>) this.posts).Where<PostClass>((Func<PostClass, bool>) (x => x.Id == this.analysiss[i].Post_Id)).Select<PostClass, string>((Func<PostClass, string>) (x => x.NameObserve)).FirstOrDefault<string>();
          string str2 = ((IEnumerable<PostClass>) this.posts).Where<PostClass>((Func<PostClass, bool>) (x => x.Id == this.analysiss[i].Post_Id)).Select<PostClass, string>((Func<PostClass, string>) (x => x.NameObject)).FirstOrDefault<string>();
          this.dgvPostList.Rows.Add((object) this.analysiss[i].Id, (object) (i + 1), (object) str2, (object) str1, (object) this.analysiss[i].Sana, (object) this.analysiss[i].Vaqt, (object) this.analysiss[i].Post_Id, (object) (this.analysiss[i].Sigm == -1.0 ? "-" : this.analysiss[i].Sigm.ToString()), (object) (this.analysiss[i].OqimTezligi == -1.0 ? "-" : this.analysiss[i].OqimTezligi.ToString()), (object) (this.analysiss[i].DaryoSarfi == -1.0 ? "-" : this.analysiss[i].DaryoSarfi.ToString()), (object) (this.analysiss[i].OqimSarfi == -1.0 ? "-" : this.analysiss[i].OqimSarfi.ToString()), (object) (this.analysiss[i].Namlik == -1.0 ? "-" : this.analysiss[i].Namlik.ToString()), (object) (this.analysiss[i].Tiniqlik == -1.0 ? "-" : this.analysiss[i].Tiniqlik.ToString()), (object) (this.analysiss[i].Rangi == -1.0 ? "-" : this.analysiss[i].Rangi.ToString()), (object) (this.analysiss[i].Harorat == -1.0 ? "-" : this.analysiss[i].Harorat.ToString()), (object) (this.analysiss[i].Suzuvchi == -1.0 ? "-" : this.analysiss[i].Suzuvchi.ToString()), (object) (this.analysiss[i].pH == -1.0 ? "-" : this.analysiss[i].pH.ToString()), (object) (this.analysiss[i].O2 == -1.0 ? "-" : this.analysiss[i].O2.ToString()), (object) (this.analysiss[i].Tuyingan == -1.0 ? "-" : this.analysiss[i].Tuyingan.ToString()), (object) (this.analysiss[i].CO2 == -1.0 ? "-" : this.analysiss[i].CO2.ToString()), (object) (this.analysiss[i].Qattiqlik == -1.0 ? "-" : this.analysiss[i].Qattiqlik.ToString()), (object) (this.analysiss[i].Xlorid == -1.0 ? "-" : this.analysiss[i].Xlorid.ToString()), (object) (this.analysiss[i].Sulfat == -1.0 ? "-" : this.analysiss[i].Sulfat.ToString()), (object) (this.analysiss[i].GidroKarbanat == -1.0 ? "-" : this.analysiss[i].GidroKarbanat.ToString()), (object) (this.analysiss[i].Na == -1.0 ? "-" : this.analysiss[i].Na.ToString()), (object) (this.analysiss[i].K == -1.0 ? "-" : this.analysiss[i].K.ToString()), (object) (this.analysiss[i].Ca == -1.0 ? "-" : this.analysiss[i].Ca.ToString()), (object) (this.analysiss[i].Mg == -1.0 ? "-" : this.analysiss[i].Mg.ToString()), (object) (this.analysiss[i].Mineral == -1.0 ? "-" : this.analysiss[i].Mineral.ToString()), (object) (this.analysiss[i].XPK == -1.0 ? "-" : this.analysiss[i].XPK.ToString()), (object) (this.analysiss[i].BPK == -1.0 ? "-" : this.analysiss[i].BPK.ToString()), (object) (this.analysiss[i].AzotAmonniy == -1.0 ? "-" : this.analysiss[i].AzotAmonniy.ToString()), (object) (this.analysiss[i].AzotNitritniy == -1.0 ? "-" : this.analysiss[i].AzotNitritniy.ToString()), (object) (this.analysiss[i].AzotNitratniy == -1.0 ? "-" : this.analysiss[i].AzotNitratniy.ToString()), (object) (this.analysiss[i].AzotSumma == -1.0 ? "-" : this.analysiss[i].AzotSumma.ToString()), (object) (this.analysiss[i].Fosfat == -1.0 ? "-" : this.analysiss[i].Fosfat.ToString()), (object) (this.analysiss[i].Si == -1.0 ? "-" : this.analysiss[i].Si.ToString()), (object) (this.analysiss[i].Elektr == -1.0 ? "-" : this.analysiss[i].Elektr.ToString()), (object) (this.analysiss[i].Eh_MB == -1.0 ? "-" : this.analysiss[i].Eh_MB.ToString()), (object) (this.analysiss[i].PUmumiy == -1.0 ? "-" : this.analysiss[i].PUmumiy.ToString()), (object) (this.analysiss[i].FeUmumiy == -1.0 ? "-" : this.analysiss[i].FeUmumiy.ToString()), (object) (this.analysiss[i].Ci == -1.0 ? "-" : this.analysiss[i].Ci.ToString()), (object) (this.analysiss[i].Zn == -1.0 ? "-" : this.analysiss[i].Zn.ToString()), (object) (this.analysiss[i].Ni == -1.0 ? "-" : this.analysiss[i].Ni.ToString()), (object) (this.analysiss[i].Cr == -1.0 ? "-" : this.analysiss[i].Cr.ToString()), (object) (this.analysiss[i].Cr_VI == -1.0 ? "-" : this.analysiss[i].Cr_VI.ToString()), (object) (this.analysiss[i].Cr_III == -1.0 ? "-" : this.analysiss[i].Cr_III.ToString()), (object) (this.analysiss[i].Pb == -1.0 ? "-" : this.analysiss[i].Pb.ToString()), (object) (this.analysiss[i].Hg == -1.0 ? "-" : this.analysiss[i].Hg.ToString()), (object) (this.analysiss[i].Cd == -1.0 ? "-" : this.analysiss[i].Cd.ToString()), (object) (this.analysiss[i].Mn == -1.0 ? "-" : this.analysiss[i].Mn.ToString()), (object) (this.analysiss[i].As == -1.0 ? "-" : this.analysiss[i].As.ToString()), (object) (this.analysiss[i].Fenollar == -1.0 ? "-" : this.analysiss[i].Fenollar.ToString()), (object) (this.analysiss[i].Neft == -1.0 ? "-" : this.analysiss[i].Neft.ToString()), (object) (this.analysiss[i].SPAB == -1.0 ? "-" : this.analysiss[i].SPAB.ToString()), (object) (this.analysiss[i].F == -1.0 ? "-" : this.analysiss[i].F.ToString()), (object) (this.analysiss[i].Sianidi == -1.0 ? "-" : this.analysiss[i].Sianidi.ToString()), (object) (this.analysiss[i].Proponil == -1.0 ? "-" : this.analysiss[i].Proponil.ToString()), (object) (this.analysiss[i].DDE == -1.0 ? "-" : this.analysiss[i].DDE.ToString()), (object) (this.analysiss[i].Rogor == -1.0 ? "-" : this.analysiss[i].Rogor.ToString()), (object) (this.analysiss[i].DDT == -1.0 ? "-" : this.analysiss[i].DDT.ToString()), (object) (this.analysiss[i].Geksaxloran == -1.0 ? "-" : this.analysiss[i].Geksaxloran.ToString()), (object) (this.analysiss[i].Lindan == -1.0 ? "-" : this.analysiss[i].Lindan.ToString()), (object) (this.analysiss[i].DDD == -1.0 ? "-" : this.analysiss[i].DDD.ToString()), (object) (this.analysiss[i].Metafos == -1.0 ? "-" : this.analysiss[i].Metafos.ToString()), (object) (this.analysiss[i].Butifos == -1.0 ? "-" : this.analysiss[i].Butifos.ToString()), (object) (this.analysiss[i].Dalapon == -1.0 ? "-" : this.analysiss[i].Dalapon.ToString()), (object) (this.analysiss[i].Karbofos == -1.0 ? "-" : this.analysiss[i].Karbofos.ToString()), (object) this.analysiss[i].Status);
          num = i;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void tSBNewRiver_Click(object sender, EventArgs e)
    {
      NewAnalysisForm newAnalysisForm = new NewAnalysisForm(((IEnumerable<RiverClass>) this.rivers).ToList<RiverClass>(), ((IEnumerable<PostClass>) this.posts).ToList<PostClass>());
      newAnalysisForm.GetAnalysis += new EventHandler(this.GetAnalysis);
      int num = (int) newAnalysisForm.ShowDialog();
    }

    private void GetAnalysis(object sender, EventArgs e)
    {
      this.analysis = (sender as NewAnalysisForm).analysis;
      if (this.analysis == null)
        return;
      // ISSUE: reference to a compiler-generated field
      if (this.GetChangeAnalysis != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.GetChangeAnalysis((object) this, e);
      }
      string str1 = ((IEnumerable<PostClass>) this.posts).Where<PostClass>((Func<PostClass, bool>) (x => x.Id == this.analysis.Post_Id)).Select<PostClass, string>((Func<PostClass, string>) (x => x.NameObserve)).FirstOrDefault<string>();
      string str2 = ((IEnumerable<PostClass>) this.posts).Where<PostClass>((Func<PostClass, bool>) (x => x.Id == this.analysis.Post_Id)).Select<PostClass, string>((Func<PostClass, string>) (x => x.NameObject)).FirstOrDefault<string>();
      if ((int) this.analysis.Status == 0)
      {
        //this.analysis.Id = Form1.StaticId;
        this.dgvPostList.Rows.Add((object) this.analysis.Id, (object) (this.dgvPostList.RowCount + 1), (object) str2, (object) str1, (object) this.analysis.Sana, (object) this.analysis.Vaqt, (object) this.analysis.Post_Id, (object) (this.analysis.Sigm == -1.0 ? "-" : this.analysis.Sigm.ToString()), (object) (this.analysis.OqimTezligi == -1.0 ? "-" : this.analysis.OqimTezligi.ToString()), (object) (this.analysis.DaryoSarfi == -1.0 ? "-" : this.analysis.DaryoSarfi.ToString()), (object) (this.analysis.OqimSarfi == -1.0 ? "-" : this.analysis.OqimSarfi.ToString()), (object) (this.analysis.Namlik == -1.0 ? "-" : this.analysis.Namlik.ToString()), (object) (this.analysis.Tiniqlik == -1.0 ? "-" : this.analysis.Tiniqlik.ToString()), (object) (this.analysis.Rangi == -1.0 ? "-" : this.analysis.Rangi.ToString()), (object) (this.analysis.Harorat == -1.0 ? "-" : this.analysis.Harorat.ToString()), (object) (this.analysis.Suzuvchi == -1.0 ? "-" : this.analysis.Suzuvchi.ToString()), (object) (this.analysis.pH == -1.0 ? "-" : this.analysis.pH.ToString()), (object) (this.analysis.O2 == -1.0 ? "-" : this.analysis.O2.ToString()), (object) (this.analysis.Tuyingan == -1.0 ? "-" : this.analysis.Tuyingan.ToString()), (object) (this.analysis.CO2 == -1.0 ? "-" : this.analysis.CO2.ToString()), (object) (this.analysis.Qattiqlik == -1.0 ? "-" : this.analysis.Qattiqlik.ToString()), (object) (this.analysis.Xlorid == -1.0 ? "-" : this.analysis.Xlorid.ToString()), (object) (this.analysis.Sulfat == -1.0 ? "-" : this.analysis.Sulfat.ToString()), (object) (this.analysis.GidroKarbanat == -1.0 ? "-" : this.analysis.GidroKarbanat.ToString()), (object) (this.analysis.Na == -1.0 ? "-" : this.analysis.Na.ToString()), (object) (this.analysis.K == -1.0 ? "-" : this.analysis.K.ToString()), (object) (this.analysis.Ca == -1.0 ? "-" : this.analysis.Ca.ToString()), (object) (this.analysis.Mg == -1.0 ? "-" : this.analysis.Mg.ToString()), (object) (this.analysis.Mineral == -1.0 ? "-" : this.analysis.Mineral.ToString()), (object) (this.analysis.XPK == -1.0 ? "-" : this.analysis.XPK.ToString()), (object) (this.analysis.BPK == -1.0 ? "-" : this.analysis.BPK.ToString()), (object) (this.analysis.AzotAmonniy == -1.0 ? "-" : this.analysis.AzotAmonniy.ToString()), (object) (this.analysis.AzotNitritniy == -1.0 ? "-" : this.analysis.AzotNitritniy.ToString()), (object) (this.analysis.AzotNitratniy == -1.0 ? "-" : this.analysis.AzotNitratniy.ToString()), (object) (this.analysis.AzotSumma == -1.0 ? "-" : this.analysis.AzotSumma.ToString()), (object) (this.analysis.Fosfat == -1.0 ? "-" : this.analysis.Fosfat.ToString()), (object) (this.analysis.Si == -1.0 ? "-" : this.analysis.Si.ToString()), (object) (this.analysis.Elektr == -1.0 ? "-" : this.analysis.Elektr.ToString()), (object) (this.analysis.Eh_MB == -1.0 ? "-" : this.analysis.Eh_MB.ToString()), (object) (this.analysis.PUmumiy == -1.0 ? "-" : this.analysis.PUmumiy.ToString()), (object) (this.analysis.FeUmumiy == -1.0 ? "-" : this.analysis.FeUmumiy.ToString()), (object) (this.analysis.Ci == -1.0 ? "-" : this.analysis.Ci.ToString()), (object) (this.analysis.Zn == -1.0 ? "-" : this.analysis.Zn.ToString()), (object) (this.analysis.Ni == -1.0 ? "-" : this.analysis.Ni.ToString()), (object) (this.analysis.Cr == -1.0 ? "-" : this.analysis.Cr.ToString()), (object) (this.analysis.Cr_VI == -1.0 ? "-" : this.analysis.Cr_VI.ToString()), (object) (this.analysis.Cr_III == -1.0 ? "-" : this.analysis.Cr_III.ToString()), (object) (this.analysis.Pb == -1.0 ? "-" : this.analysis.Pb.ToString()), (object) (this.analysis.Hg == -1.0 ? "-" : this.analysis.Hg.ToString()), (object) (this.analysis.Cd == -1.0 ? "-" : this.analysis.Cd.ToString()), (object) (this.analysis.Mn == -1.0 ? "-" : this.analysis.Mn.ToString()), (object) (this.analysis.As == -1.0 ? "-" : this.analysis.As.ToString()), (object) (this.analysis.Fenollar == -1.0 ? "-" : this.analysis.Fenollar.ToString()), (object) (this.analysis.Neft == -1.0 ? "-" : this.analysis.Neft.ToString()), (object) (this.analysis.SPAB == -1.0 ? "-" : this.analysis.SPAB.ToString()), (object) (this.analysis.F == -1.0 ? "-" : this.analysis.F.ToString()), (object) (this.analysis.Sianidi == -1.0 ? "-" : this.analysis.Sianidi.ToString()), (object) (this.analysis.Proponil == -1.0 ? "-" : this.analysis.Proponil.ToString()), (object) (this.analysis.DDE == -1.0 ? "-" : this.analysis.DDE.ToString()), (object) (this.analysis.Rogor == -1.0 ? "-" : this.analysis.Rogor.ToString()), (object) (this.analysis.DDT == -1.0 ? "-" : this.analysis.DDT.ToString()), (object) (this.analysis.Geksaxloran == -1.0 ? "-" : this.analysis.Geksaxloran.ToString()), (object) (this.analysis.Lindan == -1.0 ? "-" : this.analysis.Lindan.ToString()), (object) (this.analysis.DDD == -1.0 ? "-" : this.analysis.DDD.ToString()), (object) (this.analysis.Metafos == -1.0 ? "-" : this.analysis.Metafos.ToString()), (object) (this.analysis.Butifos == -1.0 ? "-" : this.analysis.Butifos.ToString()), (object) (this.analysis.Dalapon == -1.0 ? "-" : this.analysis.Dalapon.ToString()), (object) (this.analysis.Karbofos == -1.0 ? "-" : this.analysis.Karbofos.ToString()), (object) this.analysis.Status);
        this.analysiss.Add(this.analysis);
      }
      else
      {
        this.dgvPostList.Rows.RemoveAt(this.row_Index);
        this.dgvPostList.Rows.Insert(this.row_Index, (object) this.analysis.Id, (object) (this.dgvPostList.RowCount + 1), (object) str2, (object) str1, (object) this.analysis.Sana, (object) this.analysis.Vaqt, (object) this.analysis.Post_Id, (object) (this.analysis.Sigm == -1.0 ? "-" : this.analysis.Sigm.ToString()), (object) (this.analysis.OqimTezligi == -1.0 ? "-" : this.analysis.OqimTezligi.ToString()), (object) (this.analysis.DaryoSarfi == -1.0 ? "-" : this.analysis.DaryoSarfi.ToString()), (object) (this.analysis.OqimSarfi == -1.0 ? "-" : this.analysis.OqimSarfi.ToString()), (object) (this.analysis.Namlik == -1.0 ? "-" : this.analysis.Namlik.ToString()), (object) (this.analysis.Tiniqlik == -1.0 ? "-" : this.analysis.Tiniqlik.ToString()), (object) (this.analysis.Rangi == -1.0 ? "-" : this.analysis.Rangi.ToString()), (object) (this.analysis.Harorat == -1.0 ? "-" : this.analysis.Harorat.ToString()), (object) (this.analysis.Suzuvchi == -1.0 ? "-" : this.analysis.Suzuvchi.ToString()), (object) (this.analysis.pH == -1.0 ? "-" : this.analysis.pH.ToString()), (object) (this.analysis.O2 == -1.0 ? "-" : this.analysis.O2.ToString()), (object) (this.analysis.Tuyingan == -1.0 ? "-" : this.analysis.Tuyingan.ToString()), (object) (this.analysis.CO2 == -1.0 ? "-" : this.analysis.CO2.ToString()), (object) (this.analysis.Qattiqlik == -1.0 ? "-" : this.analysis.Qattiqlik.ToString()), (object) (this.analysis.Xlorid == -1.0 ? "-" : this.analysis.Xlorid.ToString()), (object) (this.analysis.Sulfat == -1.0 ? "-" : this.analysis.Sulfat.ToString()), (object) (this.analysis.GidroKarbanat == -1.0 ? "-" : this.analysis.GidroKarbanat.ToString()), (object) (this.analysis.Na == -1.0 ? "-" : this.analysis.Na.ToString()), (object) (this.analysis.K == -1.0 ? "-" : this.analysis.K.ToString()), (object) (this.analysis.Ca == -1.0 ? "-" : this.analysis.Ca.ToString()), (object) (this.analysis.Mg == -1.0 ? "-" : this.analysis.Mg.ToString()), (object) (this.analysis.Mineral == -1.0 ? "-" : this.analysis.Mineral.ToString()), (object) (this.analysis.XPK == -1.0 ? "-" : this.analysis.XPK.ToString()), (object) (this.analysis.BPK == -1.0 ? "-" : this.analysis.BPK.ToString()), (object) (this.analysis.AzotAmonniy == -1.0 ? "-" : this.analysis.AzotAmonniy.ToString()), (object) (this.analysis.AzotNitritniy == -1.0 ? "-" : this.analysis.AzotNitritniy.ToString()), (object) (this.analysis.AzotNitratniy == -1.0 ? "-" : this.analysis.AzotNitratniy.ToString()), (object) (this.analysis.AzotSumma == -1.0 ? "-" : this.analysis.AzotSumma.ToString()), (object) (this.analysis.Fosfat == -1.0 ? "-" : this.analysis.Fosfat.ToString()), (object) (this.analysis.Si == -1.0 ? "-" : this.analysis.Si.ToString()), (object) (this.analysis.Elektr == -1.0 ? "-" : this.analysis.Elektr.ToString()), (object) (this.analysis.Eh_MB == -1.0 ? "-" : this.analysis.Eh_MB.ToString()), (object) (this.analysis.PUmumiy == -1.0 ? "-" : this.analysis.PUmumiy.ToString()), (object) (this.analysis.FeUmumiy == -1.0 ? "-" : this.analysis.FeUmumiy.ToString()), (object) (this.analysis.Ci == -1.0 ? "-" : this.analysis.Ci.ToString()), (object) (this.analysis.Zn == -1.0 ? "-" : this.analysis.Zn.ToString()), (object) (this.analysis.Ni == -1.0 ? "-" : this.analysis.Ni.ToString()), (object) (this.analysis.Cr == -1.0 ? "-" : this.analysis.Cr.ToString()), (object) (this.analysis.Cr_VI == -1.0 ? "-" : this.analysis.Cr_VI.ToString()), (object) (this.analysis.Cr_III == -1.0 ? "-" : this.analysis.Cr_III.ToString()), (object) (this.analysis.Pb == -1.0 ? "-" : this.analysis.Pb.ToString()), (object) (this.analysis.Hg == -1.0 ? "-" : this.analysis.Hg.ToString()), (object) (this.analysis.Cd == -1.0 ? "-" : this.analysis.Cd.ToString()), (object) (this.analysis.Mn == -1.0 ? "-" : this.analysis.Mn.ToString()), (object) (this.analysis.As == -1.0 ? "-" : this.analysis.As.ToString()), (object) (this.analysis.Fenollar == -1.0 ? "-" : this.analysis.Fenollar.ToString()), (object) (this.analysis.Neft == -1.0 ? "-" : this.analysis.Neft.ToString()), (object) (this.analysis.SPAB == -1.0 ? "-" : this.analysis.SPAB.ToString()), (object) (this.analysis.F == -1.0 ? "-" : this.analysis.F.ToString()), (object) (this.analysis.Sianidi == -1.0 ? "-" : this.analysis.Sianidi.ToString()), (object) (this.analysis.Proponil == -1.0 ? "-" : this.analysis.Proponil.ToString()), (object) (this.analysis.DDE == -1.0 ? "-" : this.analysis.DDE.ToString()), (object) (this.analysis.Rogor == -1.0 ? "-" : this.analysis.Rogor.ToString()), (object) (this.analysis.DDT == -1.0 ? "-" : this.analysis.DDT.ToString()), (object) (this.analysis.Geksaxloran == -1.0 ? "-" : this.analysis.Geksaxloran.ToString()), (object) (this.analysis.Lindan == -1.0 ? "-" : this.analysis.Lindan.ToString()), (object) (this.analysis.DDD == -1.0 ? "-" : this.analysis.DDD.ToString()), (object) (this.analysis.Metafos == -1.0 ? "-" : this.analysis.Metafos.ToString()), (object) (this.analysis.Butifos == -1.0 ? "-" : this.analysis.Butifos.ToString()), (object) (this.analysis.Dalapon == -1.0 ? "-" : this.analysis.Dalapon.ToString()), (object) (this.analysis.Karbofos == -1.0 ? "-" : this.analysis.Karbofos.ToString()), (object) this.analysis.Status);
        this.analysiss[this.row_Index] = this.analysis;
      }
      this.analysis = (AnalysisClass) null;
    }

    private void tSBEditing_Click(object sender, EventArgs e)
    {
      try
      {
        this.analysis = this.analysiss[this.dgvPostList.SelectedRows[0].Index];
        this.row_Index = this.dgvPostList.SelectedRows[0].Index;
        NewAnalysisForm newAnalysisForm = new NewAnalysisForm(((IEnumerable<RiverClass>) this.rivers).ToList<RiverClass>(), ((IEnumerable<PostClass>) this.posts).ToList<PostClass>(), this.analysis);
        newAnalysisForm.GetAnalysis += new EventHandler(this.GetAnalysis);
        int num = (int) newAnalysisForm.ShowDialog();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void tSBDelete_Click(object sender, EventArgs e)
    {
      this.analysis = this.analysiss[this.dgvPostList.SelectedRows[0].Index];
      this.analysis.Status = (byte) 2;
      // ISSUE: reference to a compiler-generated field
      if (this.GetChangeAnalysis != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.GetChangeAnalysis((object) this, e);
      }
      this.dgvPostList.Rows.RemoveAt(this.dgvPostList.SelectedRows[0].Index);
      this.analysis = (AnalysisClass) null;
    }

    private void tsbDate_Click(object sender, EventArgs e)
    {
      int num = (int) new DateForAnalysisList(this.date1, this.date2).ShowDialog();
      this.date1 = DateForAnalysisList.dat1;
      this.date2 = DateForAnalysisList.dat2;
    }

    private void tsbSearch_Click(object sender, EventArgs e)
    {
      try
      {
                
        AnalysisListForm.strquery = "Select *From Analysis ";
        bool flag = false;
        if (this.tcbPostList.SelectedItem != null)
        {
          AnalysisListForm.strquery = AnalysisListForm.strquery + " Where Post_Id=" + (this.tcbPostList.SelectedItem as PostClass).Id.ToString() + " ";
          flag = true;
        }
        if (this.date1 != this.date2)
        {
          AnalysisListForm.strquery = !flag ? AnalysisListForm.strquery + " Where " : AnalysisListForm.strquery + " And ";
          string[] strArray = new string[6]
          {
            AnalysisListForm.strquery,
            " Sana>=#",
            null,
            null,
            null,
            null
          };
          int index1 = 2;
          DateTime dateTime = this.date1;
          string str1 = dateTime.ToShortDateString().Replace(".", "/");
          strArray[index1] = str1;
          int index2 = 3;
          string str2 = "# And Sana<=#";
          strArray[index2] = str2;
          int index3 = 4;
          dateTime = this.date2;
          string str3 = dateTime.ToShortDateString().Replace(".", "/");
          strArray[index3] = str3;
          int index4 = 5;
          string str4 = "# ";
          strArray[index4] = str4;
          AnalysisListForm.strquery = string.Concat(strArray);
        }
        // ISSUE: reference to a compiler-generated field
        if (this.SetQueryAnalysis != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.SetQueryAnalysis((object) this, e);
                    analysiss = Form1.analysisForAnalysisList;
        }
        //this.analysiss = Form1.analysisForAnalysisList;
        this.DBFill();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void tcbRiverList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tcbRiverList.SelectedItem == null)
        return;
      List<PostClass> list = ((IEnumerable<PostClass>) this.posts).Where<PostClass>((Func<PostClass, bool>) (x => x.River_Id == (this.tcbRiverList.SelectedItem as RiverClass).Id)).ToList<PostClass>();
      if (list != null && list.Count > 0)
      {
        this.tcbPostList.ComboBox.DataSource = (object) list;
        this.tcbPostList.ComboBox.DisplayMember = "NameObserve";
      }
      else
        this.tcbPostList.ComboBox.DataSource = (object) null;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AnalysisListForm));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      this.toolStrip1 = new ToolStrip();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.tSBNewRiver = new ToolStripButton();
      this.tSBEditing = new ToolStripButton();
      this.tSBDelete = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripLabel1 = new ToolStripLabel();
      this.tcbRiverList = new ToolStripComboBox();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripLabel2 = new ToolStripLabel();
      this.tcbPostList = new ToolStripComboBox();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.tsbDate = new ToolStripButton();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.tsbSearch = new ToolStripButton();
      this.dgvPostList = new DataGridView();
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
      this.toolStrip1.SuspendLayout();
      ((ISupportInitialize) this.dgvPostList).BeginInit();
      this.SuspendLayout();
      this.toolStrip1.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.toolStrip1.Items.AddRange(new ToolStripItem[14]
      {
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.tSBNewRiver,
        (ToolStripItem) this.tSBEditing,
        (ToolStripItem) this.tSBDelete,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripLabel1,
        (ToolStripItem) this.tcbRiverList,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripLabel2,
        (ToolStripItem) this.tcbPostList,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.tsbDate,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.tsbSearch
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(1230, 26);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 26);
      this.tSBNewRiver.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.tSBNewRiver.Image = (Image) componentResourceManager.GetObject("tSBNewRiver.Image");
      this.tSBNewRiver.ImageTransparentColor = Color.Magenta;
      this.tSBNewRiver.Name = "tSBNewRiver";
      this.tSBNewRiver.Size = new Size(126, 23);
      this.tSBNewRiver.Text = "Новый анализ";
      this.tSBNewRiver.ToolTipText = "Добавить анализ";
      this.tSBNewRiver.Click += new EventHandler(this.tSBNewRiver_Click);
      this.tSBEditing.Image = (Image) componentResourceManager.GetObject("tSBEditing.Image");
      this.tSBEditing.ImageTransparentColor = Color.Magenta;
      this.tSBEditing.Name = "tSBEditing";
      this.tSBEditing.Size = new Size(128, 23);
      this.tSBEditing.Text = "Редактировать";
      this.tSBEditing.ToolTipText = "Редактировать анализ";
      this.tSBEditing.Click += new EventHandler(this.tSBEditing_Click);
      this.tSBDelete.Image = (Image) componentResourceManager.GetObject("tSBDelete.Image");
      this.tSBDelete.ImageTransparentColor = Color.Magenta;
      this.tSBDelete.Name = "tSBDelete";
      this.tSBDelete.Size = new Size(84, 23);
      this.tSBDelete.Text = "Удалить";
      this.tSBDelete.ToolTipText = "Удалить анализ";
      this.tSBDelete.Click += new EventHandler(this.tSBDelete_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 26);
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new Size(39, 23);
      this.toolStripLabel1.Text = "Река";
      this.tcbRiverList.Name = "tcbRiverList";
      this.tcbRiverList.Size = new Size(200, 26);
      this.tcbRiverList.SelectedIndexChanged += new EventHandler(this.tcbRiverList_SelectedIndexChanged);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 26);
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new Size(42, 23);
      this.toolStripLabel2.Text = "Пост";
      this.tcbPostList.Name = "tcbPostList";
      this.tcbPostList.Size = new Size(200, 26);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(6, 26);
      this.tsbDate.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.tsbDate.Image = (Image) componentResourceManager.GetObject("tsbDate.Image");
      this.tsbDate.ImageTransparentColor = Color.Magenta;
      this.tsbDate.Name = "tsbDate";
      this.tsbDate.Size = new Size(45, 23);
      this.tsbDate.Text = "Дата";
      this.tsbDate.Click += new EventHandler(this.tsbDate_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(6, 26);
      this.tsbSearch.Image = (Image) componentResourceManager.GetObject("tsbSearch.Image");
      this.tsbSearch.ImageTransparentColor = Color.Magenta;
      this.tsbSearch.Name = "tsbSearch";
      this.tsbSearch.Size = new Size(71, 23);
      this.tsbSearch.Text = "Поиск";
      this.tsbSearch.Click += new EventHandler(this.tsbSearch_Click);
      this.dgvPostList.AllowUserToAddRows = false;
      this.dgvPostList.AllowUserToDeleteRows = false;
      this.dgvPostList.AllowUserToOrderColumns = true;
      this.dgvPostList.AllowUserToResizeColumns = false;
      this.dgvPostList.AllowUserToResizeRows = false;
      this.dgvPostList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvPostList.BackgroundColor = Color.White;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvPostList.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvPostList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPostList.Columns.AddRange((DataGridViewColumn) this.clmId, (DataGridViewColumn) this.clmRaqam, (DataGridViewColumn) this.clmRiver, (DataGridViewColumn) this.clmPost, (DataGridViewColumn) this.clmSana, (DataGridViewColumn) this.clmVaqt, (DataGridViewColumn) this.clmPost_Id, (DataGridViewColumn) this.clmSigm, (DataGridViewColumn) this.clmOqimTezligi, (DataGridViewColumn) this.clmDaryoSarfi, (DataGridViewColumn) this.clmOqimSarfi, (DataGridViewColumn) this.clmNamlik, (DataGridViewColumn) this.clmTiniqlik, (DataGridViewColumn) this.clmRangi, (DataGridViewColumn) this.clmHarorat, (DataGridViewColumn) this.clmSuzuvchi, (DataGridViewColumn) this.clmpH, (DataGridViewColumn) this.clmO2, (DataGridViewColumn) this.clmTuyingan, (DataGridViewColumn) this.clmCO2, (DataGridViewColumn) this.clmQattiqlik, (DataGridViewColumn) this.clmXlorid, (DataGridViewColumn) this.clmSulfat, (DataGridViewColumn) this.clmGidroKarbanat, (DataGridViewColumn) this.clmNa, (DataGridViewColumn) this.clmK, (DataGridViewColumn) this.clmCa, (DataGridViewColumn) this.clmMg, (DataGridViewColumn) this.clmMineral, (DataGridViewColumn) this.clmXPK, (DataGridViewColumn) this.clmBPK, (DataGridViewColumn) this.clmAzotAmonniy, (DataGridViewColumn) this.clmAzotNitritniy, (DataGridViewColumn) this.clmAzotNitratniy, (DataGridViewColumn) this.clmAzotSumma, (DataGridViewColumn) this.clmFosfat, (DataGridViewColumn) this.clmSi, (DataGridViewColumn) this.clmElektr, (DataGridViewColumn) this.clmEh_MB, (DataGridViewColumn) this.clmPumumiy, (DataGridViewColumn) this.clmFeUmumiy, (DataGridViewColumn) this.clmCi, (DataGridViewColumn) this.clmZn, (DataGridViewColumn) this.clmNi, (DataGridViewColumn) this.clmCr, (DataGridViewColumn) this.clmCr_VI, (DataGridViewColumn) this.clmCr_III, (DataGridViewColumn) this.clmPb, (DataGridViewColumn) this.clmHg, (DataGridViewColumn) this.clmCd, (DataGridViewColumn) this.clmMn, (DataGridViewColumn) this.clmAs, (DataGridViewColumn) this.clmFenollar, (DataGridViewColumn) this.clmNeft, (DataGridViewColumn) this.clmSPAB, (DataGridViewColumn) this.clmF, (DataGridViewColumn) this.clmSianidi, (DataGridViewColumn) this.clmProponil, (DataGridViewColumn) this.clmDDE, (DataGridViewColumn) this.clmRogor, (DataGridViewColumn) this.clmDDT, (DataGridViewColumn) this.clmGeksaxloran, (DataGridViewColumn) this.clmLindan, (DataGridViewColumn) this.clmDDD, (DataGridViewColumn) this.clmMetafos, (DataGridViewColumn) this.clmButifos, (DataGridViewColumn) this.clmDalapon, (DataGridViewColumn) this.clmKarbofos, (DataGridViewColumn) this.clmStatus);
      this.dgvPostList.Location = new Point(2, 29);
      this.dgvPostList.MultiSelect = false;
      this.dgvPostList.Name = "dgvPostList";
      this.dgvPostList.ReadOnly = true;
      this.dgvPostList.RowHeadersVisible = false;
      this.dgvPostList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvPostList.Size = new Size(1226, 374);
      this.dgvPostList.TabIndex = 3;
      this.clmId.HeaderText = "Id";
      this.clmId.Name = "clmId";
      this.clmId.ReadOnly = true;
      this.clmId.Visible = false;
      gridViewCellStyle2.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
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
      this.clmVaqt.HeaderText = "Времья";
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
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1230, 415);
      this.Controls.Add((Control) this.dgvPostList);
      this.Controls.Add((Control) this.toolStrip1);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4);
      this.Name = nameof (AnalysisListForm);
      this.Text = "Список анализов";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((ISupportInitialize) this.dgvPostList).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
