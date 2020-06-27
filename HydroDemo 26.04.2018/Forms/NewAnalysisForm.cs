// Decompiled with JetBrains decompiler
// Type: HydroDemo.Forms.NewAnalysisForm
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
  public class NewAnalysisForm : Form
  {
    private byte key = 0;
    private IContainer components = (IContainer) null;
    private List<RiverClass> rivers;
    private List<PostClass> posts;
    private Button btnSave;
    private Button btnCancel;
    private GroupBox groupBox1;
    private Label label1;
    private DataGridView dgvKompanenta;
    private DateTimePicker dtpVaqt;
    private DateTimePicker dtpSana;
    private ComboBox cbPostList;
    private ComboBox cbRiverList;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private DataGridViewTextBoxColumn clmHeader;
    private DataGridViewTextBoxColumn clmValue;
    private RiverClass[] rivers1;
    private PostClass[] posts1;

    public AnalysisClass analysis { get; private set; }

    public event EventHandler GetAnalysis;

    public NewAnalysisForm(List<RiverClass> rivers, List<PostClass> posts)
    {
      this.InitializeComponent();
      this.analysis = (AnalysisClass) null;
      this.rivers = rivers;
      this.posts = posts;
      this.fill();
    }

    public NewAnalysisForm(List<RiverClass> rivers, List<PostClass> posts, AnalysisClass analysis)
    {
      this.InitializeComponent();
      try
      {
        this.rivers = rivers;
        this.posts = posts;
        this.analysis = analysis;
        this.analysis.Status = (byte) 1;
        this.key = (byte) 1;
        this.dtpSana.Value = DateTime.Parse(analysis.Sana);
        this.dtpVaqt.Value = DateTime.Parse(analysis.Vaqt);
        this.fill();
        int Post_Id = posts.Where<PostClass>((Func<PostClass, bool>) (x => x.Id == analysis.Post_Id)).Select<PostClass, int>((Func<PostClass, int>) (x => x.Id)).FirstOrDefault<int>();
        int num = posts.Where<PostClass>((Func<PostClass, bool>) (x => x.Id == Post_Id)).Select<PostClass, int>((Func<PostClass, int>) (x => x.River_Id)).FirstOrDefault<int>();
        for (int index = 0; index < this.cbRiverList.Items.Count; ++index)
        {
          if ((this.cbRiverList.Items[index] as RiverClass).Id == num)
          {
            this.cbRiverList.SelectedIndex = index;
            break;
          }
        }
        for (int index = 0; index < this.cbPostList.Items.Count; ++index)
        {
          if ((this.cbPostList.Items[index] as PostClass).Id == Post_Id)
          {
            this.cbPostList.SelectedIndex = index;
            break;
          }
        }
        this.dgvKompanenta.Rows[0].Cells[1].Value = analysis.Sigm != -1.0 ? (object) analysis.Sigm.ToString() : (object) "-";
        this.dgvKompanenta.Rows[1].Cells[1].Value = analysis.OqimTezligi != -1.0 ? (object) analysis.OqimTezligi.ToString() : (object) "-";
        this.dgvKompanenta.Rows[2].Cells[1].Value = analysis.DaryoSarfi != -1.0 ? (object) analysis.DaryoSarfi.ToString() : (object) "-";
        this.dgvKompanenta.Rows[3].Cells[1].Value = analysis.OqimSarfi != -1.0 ? (object) analysis.OqimSarfi.ToString() : (object) "-";
        this.dgvKompanenta.Rows[4].Cells[1].Value = analysis.Namlik != -1.0 ? (object) analysis.Namlik.ToString() : (object) "-";
        this.dgvKompanenta.Rows[5].Cells[1].Value = analysis.Tiniqlik != -1.0 ? (object) analysis.Tiniqlik.ToString() : (object) "-";
        this.dgvKompanenta.Rows[6].Cells[1].Value = analysis.Rangi != -1.0 ? (object) analysis.Rangi.ToString() : (object) "-";
        this.dgvKompanenta.Rows[7].Cells[1].Value = analysis.Harorat != -1.0 ? (object) analysis.Harorat.ToString() : (object) "-";
        this.dgvKompanenta.Rows[8].Cells[1].Value = analysis.Suzuvchi != -1.0 ? (object) analysis.Suzuvchi.ToString() : (object) "-";
        this.dgvKompanenta.Rows[9].Cells[1].Value = analysis.pH != -1.0 ? (object) analysis.pH.ToString() : (object) "-";
        this.dgvKompanenta.Rows[10].Cells[1].Value = analysis.O2 != -1.0 ? (object) analysis.O2.ToString() : (object) "-";
        this.dgvKompanenta.Rows[11].Cells[1].Value = analysis.Tuyingan != -1.0 ? (object) analysis.Tuyingan.ToString() : (object) "-";
        this.dgvKompanenta.Rows[12].Cells[1].Value = analysis.CO2 != -1.0 ? (object) analysis.CO2.ToString() : (object) "-";
        this.dgvKompanenta.Rows[13].Cells[1].Value = analysis.Qattiqlik != -1.0 ? (object) analysis.Qattiqlik.ToString() : (object) "-";
        this.dgvKompanenta.Rows[14].Cells[1].Value = analysis.Xlorid != -1.0 ? (object) analysis.Xlorid.ToString() : (object) "-";
        this.dgvKompanenta.Rows[15].Cells[1].Value = analysis.Sulfat != -1.0 ? (object) analysis.Sulfat.ToString() : (object) "-";
        this.dgvKompanenta.Rows[16].Cells[1].Value = analysis.GidroKarbanat != -1.0 ? (object) analysis.GidroKarbanat.ToString() : (object) "-";
        this.dgvKompanenta.Rows[17].Cells[1].Value = analysis.Na != -1.0 ? (object) analysis.Na.ToString() : (object) "-";
        this.dgvKompanenta.Rows[18].Cells[1].Value = analysis.K != -1.0 ? (object) analysis.K.ToString() : (object) "-";
        this.dgvKompanenta.Rows[19].Cells[1].Value = analysis.Ca != -1.0 ? (object) analysis.Ca.ToString() : (object) "-";
        this.dgvKompanenta.Rows[20].Cells[1].Value = analysis.Mg != -1.0 ? (object) analysis.Mg.ToString() : (object) "-";
        this.dgvKompanenta.Rows[21].Cells[1].Value = analysis.Mineral != -1.0 ? (object) analysis.Mineral.ToString() : (object) "-";
        this.dgvKompanenta.Rows[22].Cells[1].Value = analysis.XPK != -1.0 ? (object) analysis.XPK.ToString() : (object) "-";
        this.dgvKompanenta.Rows[23].Cells[1].Value = analysis.BPK != -1.0 ? (object) analysis.BPK.ToString() : (object) "-";
        this.dgvKompanenta.Rows[24].Cells[1].Value = analysis.AzotAmonniy != -1.0 ? (object) analysis.AzotAmonniy.ToString() : (object) "-";
        this.dgvKompanenta.Rows[25].Cells[1].Value = analysis.AzotNitritniy != -1.0 ? (object) analysis.AzotNitritniy.ToString() : (object) "-";
        this.dgvKompanenta.Rows[26].Cells[1].Value = analysis.AzotNitratniy != -1.0 ? (object) analysis.AzotNitratniy.ToString() : (object) "-";
        this.dgvKompanenta.Rows[27].Cells[1].Value = analysis.AzotSumma != -1.0 ? (object) analysis.AzotSumma.ToString() : (object) "-";
        this.dgvKompanenta.Rows[28].Cells[1].Value = analysis.Fosfat != -1.0 ? (object) analysis.Fosfat.ToString() : (object) "-";
        this.dgvKompanenta.Rows[29].Cells[1].Value = analysis.Si != -1.0 ? (object) analysis.Si.ToString() : (object) "-";
        this.dgvKompanenta.Rows[30].Cells[1].Value = analysis.Elektr != -1.0 ? (object) analysis.Elektr.ToString() : (object) "-";
        this.dgvKompanenta.Rows[31].Cells[1].Value = analysis.Eh_MB != -1.0 ? (object) analysis.Eh_MB.ToString() : (object) "-";
        this.dgvKompanenta.Rows[32].Cells[1].Value = analysis.PUmumiy != -1.0 ? (object) analysis.PUmumiy.ToString() : (object) "-";
        this.dgvKompanenta.Rows[33].Cells[1].Value = analysis.FeUmumiy != -1.0 ? (object) analysis.FeUmumiy.ToString() : (object) "-";
        this.dgvKompanenta.Rows[34].Cells[1].Value = analysis.Ci != -1.0 ? (object) analysis.Ci.ToString() : (object) "-";
        this.dgvKompanenta.Rows[35].Cells[1].Value = analysis.Zn != -1.0 ? (object) analysis.Zn.ToString() : (object) "-";
        this.dgvKompanenta.Rows[36].Cells[1].Value = analysis.Ni != -1.0 ? (object) analysis.Ni.ToString() : (object) "-";
        this.dgvKompanenta.Rows[37].Cells[1].Value = analysis.Cr != -1.0 ? (object) analysis.Cr.ToString() : (object) "-";
        this.dgvKompanenta.Rows[38].Cells[1].Value = analysis.Cr_VI != -1.0 ? (object) analysis.Cr_VI.ToString() : (object) "-";
        this.dgvKompanenta.Rows[39].Cells[1].Value = analysis.Cr_III != -1.0 ? (object) analysis.Cr_III.ToString() : (object) "-";
        this.dgvKompanenta.Rows[40].Cells[1].Value = analysis.Pb != -1.0 ? (object) analysis.Pb.ToString() : (object) "-";
        this.dgvKompanenta.Rows[41].Cells[1].Value = analysis.Hg != -1.0 ? (object) analysis.Hg.ToString() : (object) "-";
        this.dgvKompanenta.Rows[42].Cells[1].Value = analysis.Cd != -1.0 ? (object) analysis.Cd.ToString() : (object) "-";
        this.dgvKompanenta.Rows[43].Cells[1].Value = analysis.Mn != -1.0 ? (object) analysis.Mn.ToString() : (object) "-";
        this.dgvKompanenta.Rows[44].Cells[1].Value = analysis.As != -1.0 ? (object) analysis.As.ToString() : (object) "-";
        this.dgvKompanenta.Rows[45].Cells[1].Value = analysis.Fenollar != -1.0 ? (object) analysis.Fenollar.ToString() : (object) "-";
        this.dgvKompanenta.Rows[46].Cells[1].Value = analysis.Neft != -1.0 ? (object) analysis.Neft.ToString() : (object) "-";
        this.dgvKompanenta.Rows[47].Cells[1].Value = analysis.SPAB != -1.0 ? (object) analysis.SPAB.ToString() : (object) "-";
        this.dgvKompanenta.Rows[48].Cells[1].Value = analysis.F != -1.0 ? (object) analysis.F.ToString() : (object) "-";
        this.dgvKompanenta.Rows[49].Cells[1].Value = analysis.Sianidi != -1.0 ? (object) analysis.Sianidi.ToString() : (object) "-";
        this.dgvKompanenta.Rows[50].Cells[1].Value = analysis.Proponil != -1.0 ? (object) analysis.Proponil.ToString() : (object) "-";
        this.dgvKompanenta.Rows[51].Cells[1].Value = analysis.DDE != -1.0 ? (object) analysis.DDE.ToString() : (object) "-";
        this.dgvKompanenta.Rows[52].Cells[1].Value = analysis.Rogor != -1.0 ? (object) analysis.Rogor.ToString() : (object) "-";
        this.dgvKompanenta.Rows[53].Cells[1].Value = analysis.DDT != -1.0 ? (object) analysis.DDT.ToString() : (object) "-";
        this.dgvKompanenta.Rows[54].Cells[1].Value = analysis.Geksaxloran != -1.0 ? (object) analysis.Geksaxloran.ToString() : (object) "-";
        this.dgvKompanenta.Rows[55].Cells[1].Value = analysis.Lindan != -1.0 ? (object) analysis.Lindan.ToString() : (object) "-";
        this.dgvKompanenta.Rows[56].Cells[1].Value = analysis.DDD != -1.0 ? (object) analysis.DDD.ToString() : (object) "-";
        this.dgvKompanenta.Rows[57].Cells[1].Value = analysis.Metafos != -1.0 ? (object) analysis.Metafos.ToString() : (object) "-";
        this.dgvKompanenta.Rows[58].Cells[1].Value = analysis.Butifos != -1.0 ? (object) analysis.Butifos.ToString() : (object) "-";
        this.dgvKompanenta.Rows[59].Cells[1].Value = analysis.Dalapon != -1.0 ? (object) analysis.Dalapon.ToString() : (object) "-";
        this.dgvKompanenta.Rows[60].Cells[1].Value = analysis.Karbofos != -1.0 ? (object) analysis.Karbofos.ToString() : (object) "-";
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void fill()
    {
      this.cbRiverList.DataSource = (object) this.rivers.OrderBy<RiverClass, string>((Func<RiverClass, string>) (x => x.Name)).ToList<RiverClass>();
      this.cbRiverList.DisplayMember = "Name";
      this.cbPostList.DataSource = (object) this.posts.OrderBy<PostClass, string>((Func<PostClass, string>) (x => x.NameObserve)).ToList<PostClass>();
      this.cbPostList.DisplayMember = "NameObserve";
      this.dgvKompanenta.Rows.Add((object) "К-во дней хранения(дни)", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Скорость течения, м3/сек", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Расход реки, м3/сек", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Расход сточных.вод, м3/сек", (object) "");
      this.dgvKompanenta.Rows.Add((object) "запах, балл", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Прозрачность, см", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Цветность, град", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Температура, оС", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Взвешенные вещества, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "рН", (object) "");
      this.dgvKompanenta.Rows.Add((object) "О2, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Насыщение О2, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "СО2, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Жесткость, мг-экв/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Хлориды, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Сульфаты, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Гидрокарбонаты, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Na, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "K, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Ca, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Mg, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Минерализация, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "ХПК, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "БПК5, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Азот аммонний, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Азот нитритный, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Азот нитратный, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Сумма азота, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Фосфат, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Si, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Электропроводность, мкСм/см", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Eh, MB", (object) "");
      this.dgvKompanenta.Rows.Add((object) "P общий, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Fe общий, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Сu, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Zn, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Ni, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Cr, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Cr-VI, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Cr-III, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Pb, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Hg, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Cd, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Mn, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "As, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Фенолы, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Нефтепродукты, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "СПАВ, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "F, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Цианиды, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Пропонил, мг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "ДДЕ, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Рогор, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "ДДТ, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Гексахлоран (α-ГХЦГ), мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Линдан (γ-ГХЦГ), мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "ДДД, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Метафос, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Бутифос, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Далапон, мкг/дм3", (object) "");
      this.dgvKompanenta.Rows.Add((object) "Карбофос, мкг/дм3", (object) "");
    }

    private void dgvKompanenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      string s = this.dgvKompanenta.CurrentCell.Value as string;
      double result;
      if (!(s != "-") || double.TryParse(s, out result))
        return;
      int num = (int) MessageBox.Show("Ошибка");
      this.dgvKompanenta.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (object) "";
    }

    private void cbRiverList_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.cbRiverList.SelectedIndex < 0)
          return;
        int Id = (this.cbRiverList.SelectedItem as RiverClass).Id;
        this.cbPostList.DataSource = (object) null;
        this.cbPostList.DataSource = (object) this.posts.Where<PostClass>((Func<PostClass, bool>) (x => x.River_Id == Id)).ToList<PostClass>();
        this.cbPostList.DisplayMember = "NameObserve";
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.analysis == null)
        {
          this.analysis = new AnalysisClass();
          this.analysis.Status = (byte) 0;
        }
        else
          this.analysis.Status = (byte) 1;
        if (this.cbPostList.SelectedItem == null)
        {
          int num = (int) MessageBox.Show("Выбрите пост");
        }
        else
        {
          this.analysis.Post_Id = (this.cbPostList.SelectedItem as PostClass).Id;
          this.analysis.Sana = this.dtpSana.Value.ToShortDateString();
          this.analysis.Vaqt = this.dtpVaqt.Value.ToShortTimeString();
          double result = 0.0;
          this.analysis.Sigm = double.TryParse(this.dgvKompanenta.Rows[0].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.OqimTezligi = double.TryParse(this.dgvKompanenta.Rows[1].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.DaryoSarfi = double.TryParse(this.dgvKompanenta.Rows[2].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.OqimSarfi = double.TryParse(this.dgvKompanenta.Rows[3].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Namlik = double.TryParse(this.dgvKompanenta.Rows[4].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Tiniqlik = double.TryParse(this.dgvKompanenta.Rows[5].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Rangi = double.TryParse(this.dgvKompanenta.Rows[6].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Harorat = double.TryParse(this.dgvKompanenta.Rows[7].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Suzuvchi = double.TryParse(this.dgvKompanenta.Rows[8].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.pH = double.TryParse(this.dgvKompanenta.Rows[9].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.O2 = double.TryParse(this.dgvKompanenta.Rows[10].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Tuyingan = double.TryParse(this.dgvKompanenta.Rows[11].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.CO2 = double.TryParse(this.dgvKompanenta.Rows[12].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Qattiqlik = double.TryParse(this.dgvKompanenta.Rows[13].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Xlorid = double.TryParse(this.dgvKompanenta.Rows[14].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Sulfat = double.TryParse(this.dgvKompanenta.Rows[15].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.GidroKarbanat = double.TryParse(this.dgvKompanenta.Rows[16].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Na = double.TryParse(this.dgvKompanenta.Rows[17].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.K = double.TryParse(this.dgvKompanenta.Rows[18].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Ca = double.TryParse(this.dgvKompanenta.Rows[19].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Mg = double.TryParse(this.dgvKompanenta.Rows[20].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Mineral = double.TryParse(this.dgvKompanenta.Rows[21].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.XPK = double.TryParse(this.dgvKompanenta.Rows[22].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.BPK = double.TryParse(this.dgvKompanenta.Rows[23].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.AzotAmonniy = double.TryParse(this.dgvKompanenta.Rows[24].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.AzotNitritniy = double.TryParse(this.dgvKompanenta.Rows[25].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.AzotNitratniy = double.TryParse(this.dgvKompanenta.Rows[26].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.AzotSumma = double.TryParse(this.dgvKompanenta.Rows[27].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Fosfat = double.TryParse(this.dgvKompanenta.Rows[28].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Si = double.TryParse(this.dgvKompanenta.Rows[29].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Elektr = double.TryParse(this.dgvKompanenta.Rows[30].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Eh_MB = double.TryParse(this.dgvKompanenta.Rows[31].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.PUmumiy = double.TryParse(this.dgvKompanenta.Rows[32].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.FeUmumiy = double.TryParse(this.dgvKompanenta.Rows[33].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Ci = double.TryParse(this.dgvKompanenta.Rows[34].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Zn = double.TryParse(this.dgvKompanenta.Rows[35].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Ni = double.TryParse(this.dgvKompanenta.Rows[36].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Cr = double.TryParse(this.dgvKompanenta.Rows[37].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Cr_VI = double.TryParse(this.dgvKompanenta.Rows[38].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Cr_III = double.TryParse(this.dgvKompanenta.Rows[39].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Pb = double.TryParse(this.dgvKompanenta.Rows[40].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Hg = double.TryParse(this.dgvKompanenta.Rows[41].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Cd = double.TryParse(this.dgvKompanenta.Rows[42].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Mn = double.TryParse(this.dgvKompanenta.Rows[43].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.As = double.TryParse(this.dgvKompanenta.Rows[44].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Fenollar = double.TryParse(this.dgvKompanenta.Rows[45].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Neft = double.TryParse(this.dgvKompanenta.Rows[46].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.SPAB = double.TryParse(this.dgvKompanenta.Rows[47].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.F = double.TryParse(this.dgvKompanenta.Rows[48].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Sianidi = double.TryParse(this.dgvKompanenta.Rows[49].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Proponil = double.TryParse(this.dgvKompanenta.Rows[50].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.DDE = double.TryParse(this.dgvKompanenta.Rows[51].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Rogor = double.TryParse(this.dgvKompanenta.Rows[52].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.DDT = double.TryParse(this.dgvKompanenta.Rows[53].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Geksaxloran = double.TryParse(this.dgvKompanenta.Rows[54].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Lindan = double.TryParse(this.dgvKompanenta.Rows[55].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.DDD = double.TryParse(this.dgvKompanenta.Rows[56].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Metafos = double.TryParse(this.dgvKompanenta.Rows[57].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Butifos = double.TryParse(this.dgvKompanenta.Rows[58].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Dalapon = double.TryParse(this.dgvKompanenta.Rows[59].Cells[1].Value.ToString(), out result) ? result : -1.0;
          this.analysis.Karbofos = double.TryParse(this.dgvKompanenta.Rows[60].Cells[1].Value.ToString(), out result) ? result : -1.0;
          // ISSUE: reference to a compiler-generated field
          if (this.GetAnalysis != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.GetAnalysis((object) this, e);
          }
          this.Close();
        }
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
      this.btnSave = new Button();
      this.btnCancel = new Button();
      this.groupBox1 = new GroupBox();
      this.dtpVaqt = new DateTimePicker();
      this.dtpSana = new DateTimePicker();
      this.cbPostList = new ComboBox();
      this.cbRiverList = new ComboBox();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.dgvKompanenta = new DataGridView();
      this.clmHeader = new DataGridViewTextBoxColumn();
      this.clmValue = new DataGridViewTextBoxColumn();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.dgvKompanenta).BeginInit();
      this.SuspendLayout();
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new Point(777, 368);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(92, 36);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Сохранить";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new Point(35, 368);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(92, 36);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.groupBox1.Controls.Add((Control) this.dtpVaqt);
      this.groupBox1.Controls.Add((Control) this.dtpSana);
      this.groupBox1.Controls.Add((Control) this.cbPostList);
      this.groupBox1.Controls.Add((Control) this.cbRiverList);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Location = new Point(22, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(369, 334);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "О анализе";
      this.dtpVaqt.Format = DateTimePickerFormat.Time;
      this.dtpVaqt.Location = new Point(73, 165);
      this.dtpVaqt.Name = "dtpVaqt";
      this.dtpVaqt.ShowUpDown = true;
      this.dtpVaqt.Size = new Size(290, 26);
      this.dtpVaqt.TabIndex = 7;
      this.dtpSana.Format = DateTimePickerFormat.Short;
      this.dtpSana.Location = new Point(73, 116);
      this.dtpSana.Name = "dtpSana";
      this.dtpSana.Size = new Size(290, 26);
      this.dtpSana.TabIndex = 6;
      this.cbPostList.FormattingEnabled = true;
      this.cbPostList.Location = new Point(73, 71);
      this.cbPostList.Name = "cbPostList";
      this.cbPostList.Size = new Size(290, 27);
      this.cbPostList.TabIndex = 5;
      this.cbRiverList.FormattingEnabled = true;
      this.cbRiverList.Location = new Point(73, 22);
      this.cbRiverList.Name = "cbRiverList";
      this.cbRiverList.Size = new Size(290, 27);
      this.cbRiverList.TabIndex = 4;
      this.cbRiverList.SelectedIndexChanged += new EventHandler(this.cbRiverList_SelectedIndexChanged);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(9, 165);
      this.label5.Name = "label5";
      this.label5.Size = new Size(58, 19);
      this.label5.TabIndex = 3;
      this.label5.Text = "Время";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(6, 116);
      this.label4.Name = "label4";
      this.label4.Size = new Size(41, 19);
      this.label4.TabIndex = 2;
      this.label4.Text = "Дата";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(6, 74);
      this.label3.Name = "label3";
      this.label3.Size = new Size(42, 19);
      this.label3.TabIndex = 1;
      this.label3.Text = "Пост";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(9, 22);
      this.label2.Name = "label2";
      this.label2.Size = new Size(39, 19);
      this.label2.TabIndex = 0;
      this.label2.Text = "Река";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(631, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(96, 19);
      this.label1.TabIndex = 3;
      this.label1.Text = "Компоненты";
      this.dgvKompanenta.AllowUserToAddRows = false;
      this.dgvKompanenta.AllowUserToDeleteRows = false;
      this.dgvKompanenta.AllowUserToOrderColumns = true;
      this.dgvKompanenta.AllowUserToResizeColumns = false;
      this.dgvKompanenta.AllowUserToResizeRows = false;
      this.dgvKompanenta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvKompanenta.BackgroundColor = SystemColors.ButtonHighlight;
      this.dgvKompanenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvKompanenta.Columns.AddRange((DataGridViewColumn) this.clmHeader, (DataGridViewColumn) this.clmValue);
      this.dgvKompanenta.Location = new Point(425, 22);
      this.dgvKompanenta.Name = "dgvKompanenta";
      this.dgvKompanenta.RowHeadersVisible = false;
      this.dgvKompanenta.Size = new Size(444, 324);
      this.dgvKompanenta.TabIndex = 4;
      this.dgvKompanenta.CellEndEdit += new DataGridViewCellEventHandler(this.dgvKompanenta_CellEndEdit);
      this.clmHeader.HeaderText = "Компоненты";
      this.clmHeader.Name = "clmHeader";
      this.clmHeader.ReadOnly = true;
      this.clmHeader.Width = 300;
      this.clmValue.HeaderText = "Значении";
      this.clmValue.Name = "clmValue";
      this.AutoScaleDimensions = new SizeF(9f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(888, 416);
      this.Controls.Add((Control) this.dgvKompanenta);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnSave);
      this.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.Margin = new Padding(4);
      this.Name = nameof (NewAnalysisForm);
      this.Text = "Новый анализ";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.dgvKompanenta).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
