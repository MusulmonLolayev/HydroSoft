using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using HydroDemo.Forms;
using HydroDemo.Metods;
using HydroDemo.Models;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace HydroDemo
{
    public partial class Form1 : Form
    {
        private OleDbConnection connect;
        private OleDbCommand command;
        private OleDbDataAdapter adapter;
        //private OleDbTransaction transaction;
        private string strconnect;

        public static List<AnalysisClass> analysisForAnalysisList = new List<AnalysisClass>();
        private List<PostClass> posts;
        private List<RiverClass> rivers;
        private KompanentaClass[] koms;
        public bool[] t = new bool[61];

        public static int StaticId;

        public Form1()
        {
            InitializeComponent();
            LoginForm form = new LoginForm();
            form.GetBool += ChangeBase;
            form.ShowDialog();
            try
            {
                this.strconnect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Data\\Hydro.mdb;Persist Security Info=False;";
                try
                {
                    this.connect = new OleDbConnection(this.strconnect);
                }
                catch (OleDbException ex)
                {
                    int num = (int)MessageBox.Show(ex.Message + "\nError new connect key = 1");
                }
                this.command = new OleDbCommand("", this.connect);
                this.adapter = new OleDbDataAdapter(this.command);
                this.connect.Close();
                this.connect.Open();
                this.command.CommandText = "Select *From Post";
                this.adapter.InsertCommand = this.command;
                System.Data.DataTable dataTable1 = new System.Data.DataTable();
                this.adapter.Fill(dataTable1);
                this.posts = new List<PostClass>();
                int result1;
                double result2;
                for (int index = 0; index < dataTable1.Rows.Count; ++index)
                    this.posts.Add(new PostClass()
                    {
                        Id = int.TryParse(dataTable1.Rows[index].ItemArray[0].ToString(), out result1) ? result1 : 0,
                        NumberControl = int.TryParse(dataTable1.Rows[index].ItemArray[1].ToString(), out result1) ? result1 : 0,
                        NameObject = dataTable1.Rows[index].ItemArray[2] as string,
                        NameObserve = dataTable1.Rows[index].ItemArray[3] as string,
                        Distance = double.TryParse(dataTable1.Rows[index].ItemArray[4].ToString(), out result2) ? result2 : 0.0,
                        Administer = dataTable1.Rows[index].ItemArray[5] as string,
                        NumberFolds = int.TryParse(dataTable1.Rows[index].ItemArray[6].ToString(), out result1) ? result1 : 0,
                        LocationFold = dataTable1.Rows[index].ItemArray[7] as string,
                        Vertical = dataTable1.Rows[index].ItemArray[8] as string,
                        Horizantal = dataTable1.Rows[index].ItemArray[9] as string,
                        Date = int.TryParse(dataTable1.Rows[index].ItemArray[10].ToString(), out result1) ? result1 : 0,
                        River_Id = int.TryParse(dataTable1.Rows[index].ItemArray[11].ToString(), out result1) ? result1 : 0,
                        Status = (byte)4
                    });
                this.command.CommandText = "Select *From River";
                this.adapter.InsertCommand = this.command;
                System.Data.DataTable dataTable2 = new System.Data.DataTable();
                this.adapter.Fill(dataTable2);
                this.rivers = new List<RiverClass>();
                for (int index = 0; index < dataTable2.Rows.Count; ++index)
                    this.rivers.Add(new RiverClass()
                    {
                        Id = int.TryParse(dataTable2.Rows[index].ItemArray[0].ToString(), out result1) ? result1 : 0,
                        Name = dataTable2.Rows[index].ItemArray[1] as string,
                        Number = int.TryParse(dataTable2.Rows[index].ItemArray[2].ToString(), out result1) ? result1 : 0,
                        Status = (byte)4
                    });
                this.command.CommandText = "Select *From Kompanenta1";
                this.adapter.InsertCommand = this.command;
                System.Data.DataTable dataTable3 = new System.Data.DataTable();
                this.adapter.Fill(dataTable3);
                this.koms = new KompanentaClass[dataTable3.Rows.Count];
                for (int index = 0; index < dataTable3.Rows.Count; ++index)
                    this.koms[index] = new KompanentaClass()
                    {
                        Id = int.TryParse(dataTable3.Rows[index].ItemArray[0].ToString(), out result1) ? result1 : 0,
                        Display = (string)dataTable3.Rows[index].ItemArray[2],
                        Name = (string)dataTable3.Rows[index].ItemArray[1],
                        PDK = double.TryParse(dataTable3.Rows[index].ItemArray[3].ToString(), out result2) ? result2 : 0.0
                    };
                this.connect.Close();
                this.DBFill("Select Top 100 *From Analysis Order By Id");
                this.cbRiverList.DataSource = (object)this.rivers.OrderBy<RiverClass, string>((Func<RiverClass, string>)(x => x.Name)).ToList<RiverClass>();
                this.cbRiverList.DisplayMember = "Name";
                for (int index = 0; index < this.t.Length; ++index)
                    this.t[index] = true;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        private void ChangeBase(object sender, EventArgs e)
        {
            mnAnalysis.Visible = true;
            mnServis.Visible = true;
        }

        private void DBFill(string strquery)
        {
            try
            {
                this.connect.Close();
                this.connect.Open();
                this.command.CommandText = strquery;
                this.adapter.InsertCommand = this.command;
                this.adapter.Fill(new System.Data.DataTable());
                this.connect.Close();
                List<AnalysisClass> analysiss = this.GetAnalysisList(strquery);
                this.dgvAnalysis.Rows.Clear();
                int num;
                for (int i = 0; i < analysiss.Count; i = num + 1)
                {
                    string str1 = this.posts.Where<PostClass>((Func<PostClass, bool>)(x => x.Id == analysiss[i].Post_Id)).Select<PostClass, string>((Func<PostClass, string>)(x => x.NameObserve)).FirstOrDefault<string>();
                    string str2 = this.posts.Where<PostClass>((Func<PostClass, bool>)(x => x.Id == analysiss[i].Post_Id)).Select<PostClass, string>((Func<PostClass, string>)(x => x.NameObject)).FirstOrDefault<string>();
                    this.dgvAnalysis.Rows.Add((object)analysiss[i].Id, (object)(i + 1), (object)str2, (object)str1, (object)analysiss[i].Sana, (object)analysiss[i].Vaqt, (object)analysiss[i].Post_Id, (object)(analysiss[i].Sigm == -1.0 ? "-" : analysiss[i].Sigm.ToString()), (object)(analysiss[i].OqimTezligi == -1.0 ? "-" : analysiss[i].OqimTezligi.ToString()), (object)(analysiss[i].DaryoSarfi == -1.0 ? "-" : analysiss[i].DaryoSarfi.ToString()), (object)(analysiss[i].OqimSarfi == -1.0 ? "-" : analysiss[i].OqimSarfi.ToString()), (object)(analysiss[i].Namlik == -1.0 ? "-" : analysiss[i].Namlik.ToString()), (object)(analysiss[i].Tiniqlik == -1.0 ? "-" : analysiss[i].Tiniqlik.ToString()), (object)(analysiss[i].Rangi == -1.0 ? "-" : analysiss[i].Rangi.ToString()), (object)(analysiss[i].Harorat == -1.0 ? "-" : analysiss[i].Harorat.ToString()), (object)(analysiss[i].Suzuvchi == -1.0 ? "-" : analysiss[i].Suzuvchi.ToString()), (object)(analysiss[i].pH == -1.0 ? "-" : analysiss[i].pH.ToString()), (object)(analysiss[i].O2 == -1.0 ? "-" : analysiss[i].O2.ToString()), (object)(analysiss[i].Tuyingan == -1.0 ? "-" : analysiss[i].Tuyingan.ToString()), (object)(analysiss[i].CO2 == -1.0 ? "-" : analysiss[i].CO2.ToString()), (object)(analysiss[i].Qattiqlik == -1.0 ? "-" : analysiss[i].Qattiqlik.ToString()), (object)(analysiss[i].Xlorid == -1.0 ? "-" : analysiss[i].Xlorid.ToString()), (object)(analysiss[i].Sulfat == -1.0 ? "-" : analysiss[i].Sulfat.ToString()), (object)(analysiss[i].GidroKarbanat == -1.0 ? "-" : analysiss[i].GidroKarbanat.ToString()), (object)(analysiss[i].Na == -1.0 ? "-" : analysiss[i].Na.ToString()), (object)(analysiss[i].K == -1.0 ? "-" : analysiss[i].K.ToString()), (object)(analysiss[i].Ca == -1.0 ? "-" : analysiss[i].Ca.ToString()), (object)(analysiss[i].Mg == -1.0 ? "-" : analysiss[i].Mg.ToString()), (object)(analysiss[i].Mineral == -1.0 ? "-" : analysiss[i].Mineral.ToString()), (object)(analysiss[i].XPK == -1.0 ? "-" : analysiss[i].XPK.ToString()), (object)(analysiss[i].BPK == -1.0 ? "-" : analysiss[i].BPK.ToString()), (object)(analysiss[i].AzotAmonniy == -1.0 ? "-" : analysiss[i].AzotAmonniy.ToString()), (object)(analysiss[i].AzotNitritniy == -1.0 ? "-" : analysiss[i].AzotNitritniy.ToString()), (object)(analysiss[i].AzotNitratniy == -1.0 ? "-" : analysiss[i].AzotNitratniy.ToString()), (object)(analysiss[i].AzotSumma == -1.0 ? "-" : analysiss[i].AzotSumma.ToString()), (object)(analysiss[i].Fosfat == -1.0 ? "-" : analysiss[i].Fosfat.ToString()), (object)(analysiss[i].Si == -1.0 ? "-" : analysiss[i].Si.ToString()), (object)(analysiss[i].Elektr == -1.0 ? "-" : analysiss[i].Elektr.ToString()), (object)(analysiss[i].Eh_MB == -1.0 ? "-" : analysiss[i].Eh_MB.ToString()), (object)(analysiss[i].PUmumiy == -1.0 ? "-" : analysiss[i].PUmumiy.ToString()), (object)(analysiss[i].FeUmumiy == -1.0 ? "-" : analysiss[i].FeUmumiy.ToString()), (object)(analysiss[i].Ci == -1.0 ? "-" : analysiss[i].Ci.ToString()), (object)(analysiss[i].Zn == -1.0 ? "-" : analysiss[i].Zn.ToString()), (object)(analysiss[i].Ni == -1.0 ? "-" : analysiss[i].Ni.ToString()), (object)(analysiss[i].Cr == -1.0 ? "-" : analysiss[i].Cr.ToString()), (object)(analysiss[i].Cr_VI == -1.0 ? "-" : analysiss[i].Cr_VI.ToString()), (object)(analysiss[i].Cr_III == -1.0 ? "-" : analysiss[i].Cr_III.ToString()), (object)(analysiss[i].Pb == -1.0 ? "-" : analysiss[i].Pb.ToString()), (object)(analysiss[i].Hg == -1.0 ? "-" : analysiss[i].Hg.ToString()), (object)(analysiss[i].Cd == -1.0 ? "-" : analysiss[i].Cd.ToString()), (object)(analysiss[i].Mn == -1.0 ? "-" : analysiss[i].Mn.ToString()), (object)(analysiss[i].As == -1.0 ? "-" : analysiss[i].As.ToString()), (object)(analysiss[i].Fenollar == -1.0 ? "-" : analysiss[i].Fenollar.ToString()), (object)(analysiss[i].Neft == -1.0 ? "-" : analysiss[i].Neft.ToString()), (object)(analysiss[i].SPAB == -1.0 ? "-" : analysiss[i].SPAB.ToString()), (object)(analysiss[i].F == -1.0 ? "-" : analysiss[i].F.ToString()), (object)(analysiss[i].Sianidi == -1.0 ? "-" : analysiss[i].Sianidi.ToString()), (object)(analysiss[i].Proponil == -1.0 ? "-" : analysiss[i].Proponil.ToString()), (object)(analysiss[i].DDE == -1.0 ? "-" : analysiss[i].DDE.ToString()), (object)(analysiss[i].Rogor == -1.0 ? "-" : analysiss[i].Rogor.ToString()), (object)(analysiss[i].DDT == -1.0 ? "-" : analysiss[i].DDT.ToString()), (object)(analysiss[i].Geksaxloran == -1.0 ? "-" : analysiss[i].Geksaxloran.ToString()), (object)(analysiss[i].Lindan == -1.0 ? "-" : analysiss[i].Lindan.ToString()), (object)(analysiss[i].DDD == -1.0 ? "-" : analysiss[i].DDD.ToString()), (object)(analysiss[i].Metafos == -1.0 ? "-" : analysiss[i].Metafos.ToString()), (object)(analysiss[i].Butifos == -1.0 ? "-" : analysiss[i].Butifos.ToString()), (object)(analysiss[i].Dalapon == -1.0 ? "-" : analysiss[i].Dalapon.ToString()), (object)(analysiss[i].Karbofos == -1.0 ? "-" : analysiss[i].Karbofos.ToString()), (object)analysiss[i].Status);
                    num = i;
                }

                //dgvAnalysis.DataSource = analysiss;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        private List<AnalysisClass> GetAnalysisList(string query)
        {
            List<AnalysisClass> analysisClassList1 = new List<AnalysisClass>();
            try
            {
                this.connect.Close();
                this.connect.Open();
                System.Data.DataTable dataTable1 = new System.Data.DataTable();
                this.command.CommandText = query;
                this.adapter.InsertCommand = this.command;
                System.Data.DataTable dataTable2 = new System.Data.DataTable();
                this.adapter.Fill(dataTable2);
                for (int index = 0; index < dataTable2.Rows.Count; ++index)
                {
                    List<AnalysisClass> analysisClassList2 = analysisClassList1;
                    AnalysisClass analysisClass1 = new AnalysisClass();
                    int result1;
                    analysisClass1.Id = int.TryParse(dataTable2.Rows[index].ItemArray[0].ToString(), out result1) ? result1 : 0;
                    analysisClass1.Post_Id = int.TryParse(dataTable2.Rows[index].ItemArray[1].ToString(), out result1) ? result1 : 0;
                    AnalysisClass analysisClass2 = analysisClass1;
                    DateTime dateTime = DateTime.Parse(dataTable2.Rows[index].ItemArray[2].ToString());
                    string shortDateString = dateTime.ToShortDateString();
                    analysisClass2.Sana = shortDateString;
                    AnalysisClass analysisClass3 = analysisClass1;
                    dateTime = DateTime.Parse(dataTable2.Rows[index].ItemArray[3].ToString());
                    string shortTimeString = dateTime.ToShortTimeString();
                    analysisClass3.Vaqt = shortTimeString;
                    double result2;
                    analysisClass1.Sigm = double.TryParse(dataTable2.Rows[index].ItemArray[4].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.OqimTezligi = double.TryParse(dataTable2.Rows[index].ItemArray[5].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.DaryoSarfi = double.TryParse(dataTable2.Rows[index].ItemArray[6].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.OqimSarfi = double.TryParse(dataTable2.Rows[index].ItemArray[7].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Namlik = double.TryParse(dataTable2.Rows[index].ItemArray[8].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Tiniqlik = double.TryParse(dataTable2.Rows[index].ItemArray[9].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Rangi = double.TryParse(dataTable2.Rows[index].ItemArray[10].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Harorat = double.TryParse(dataTable2.Rows[index].ItemArray[11].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Suzuvchi = double.TryParse(dataTable2.Rows[index].ItemArray[12].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.pH = double.TryParse(dataTable2.Rows[index].ItemArray[13].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.O2 = double.TryParse(dataTable2.Rows[index].ItemArray[14].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Tuyingan = double.TryParse(dataTable2.Rows[index].ItemArray[15].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.CO2 = double.TryParse(dataTable2.Rows[index].ItemArray[16].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Qattiqlik = double.TryParse(dataTable2.Rows[index].ItemArray[17].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Xlorid = double.TryParse(dataTable2.Rows[index].ItemArray[18].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Sulfat = double.TryParse(dataTable2.Rows[index].ItemArray[19].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.GidroKarbanat = double.TryParse(dataTable2.Rows[index].ItemArray[20].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Na = double.TryParse(dataTable2.Rows[index].ItemArray[21].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.K = double.TryParse(dataTable2.Rows[index].ItemArray[22].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Ca = double.TryParse(dataTable2.Rows[index].ItemArray[23].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Mg = double.TryParse(dataTable2.Rows[index].ItemArray[24].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Mineral = double.TryParse(dataTable2.Rows[index].ItemArray[25].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.XPK = double.TryParse(dataTable2.Rows[index].ItemArray[26].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.BPK = double.TryParse(dataTable2.Rows[index].ItemArray[27].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.AzotAmonniy = double.TryParse(dataTable2.Rows[index].ItemArray[28].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.AzotNitritniy = double.TryParse(dataTable2.Rows[index].ItemArray[29].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.AzotNitratniy = double.TryParse(dataTable2.Rows[index].ItemArray[30].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.AzotSumma = double.TryParse(dataTable2.Rows[index].ItemArray[31].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Fosfat = double.TryParse(dataTable2.Rows[index].ItemArray[32].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Si = double.TryParse(dataTable2.Rows[index].ItemArray[33].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Elektr = double.TryParse(dataTable2.Rows[index].ItemArray[34].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Eh_MB = double.TryParse(dataTable2.Rows[index].ItemArray[35].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.PUmumiy = double.TryParse(dataTable2.Rows[index].ItemArray[36].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.FeUmumiy = double.TryParse(dataTable2.Rows[index].ItemArray[37].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Ci = double.TryParse(dataTable2.Rows[index].ItemArray[38].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Zn = double.TryParse(dataTable2.Rows[index].ItemArray[39].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Ni = double.TryParse(dataTable2.Rows[index].ItemArray[40].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Cr = double.TryParse(dataTable2.Rows[index].ItemArray[41].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Cr_VI = double.TryParse(dataTable2.Rows[index].ItemArray[42].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Cr_III = double.TryParse(dataTable2.Rows[index].ItemArray[43].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Pb = double.TryParse(dataTable2.Rows[index].ItemArray[44].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Hg = double.TryParse(dataTable2.Rows[index].ItemArray[45].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Cd = double.TryParse(dataTable2.Rows[index].ItemArray[46].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Mn = double.TryParse(dataTable2.Rows[index].ItemArray[47].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.As = double.TryParse(dataTable2.Rows[index].ItemArray[48].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Fenollar = double.TryParse(dataTable2.Rows[index].ItemArray[49].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Neft = double.TryParse(dataTable2.Rows[index].ItemArray[50].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.SPAB = double.TryParse(dataTable2.Rows[index].ItemArray[51].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.F = double.TryParse(dataTable2.Rows[index].ItemArray[52].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Sianidi = double.TryParse(dataTable2.Rows[index].ItemArray[53].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Proponil = double.TryParse(dataTable2.Rows[index].ItemArray[54].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.DDE = double.TryParse(dataTable2.Rows[index].ItemArray[55].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Rogor = double.TryParse(dataTable2.Rows[index].ItemArray[56].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.DDT = double.TryParse(dataTable2.Rows[index].ItemArray[57].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Geksaxloran = double.TryParse(dataTable2.Rows[index].ItemArray[58].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Lindan = double.TryParse(dataTable2.Rows[index].ItemArray[59].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.DDD = double.TryParse(dataTable2.Rows[index].ItemArray[60].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Metafos = double.TryParse(dataTable2.Rows[index].ItemArray[61].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Butifos = double.TryParse(dataTable2.Rows[index].ItemArray[62].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Dalapon = double.TryParse(dataTable2.Rows[index].ItemArray[63].ToString(), out result2) ? result2 : -1.0;
                    analysisClass1.Karbofos = double.TryParse(dataTable2.Rows[index].ItemArray[64].ToString(), out result2) ? result2 : -1.0;
                    AnalysisClass analysisClass4 = analysisClass1;
                    analysisClassList2.Add(analysisClass4);
                }
                this.connect.Close();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
            return analysisClassList1;
        }


        #region Analysis change Click
        private void mnuAnalysisItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.connect.Close();
                this.connect.Open();
                this.command.CommandText = "Select *From Post";
                this.adapter.InsertCommand = this.command;
                System.Data.DataTable dataTable1 = new System.Data.DataTable();
                this.adapter.Fill(dataTable1);
                PostClass[] postClassArray = new PostClass[dataTable1.Rows.Count];
                for (int index = 0; index < dataTable1.Rows.Count; ++index)
                {
                    int result1;
                    double result2;
                    postClassArray[index] = new PostClass()
                    {
                        Id = int.TryParse(dataTable1.Rows[index].ItemArray[0].ToString(), out result1) ? result1 : 0,
                        NumberControl = int.TryParse(dataTable1.Rows[index].ItemArray[1].ToString(), out result1) ? result1 : 0,
                        NameObject = dataTable1.Rows[index].ItemArray[2] as string,
                        NameObserve = dataTable1.Rows[index].ItemArray[3] as string,
                        Distance = double.TryParse(dataTable1.Rows[index].ItemArray[4].ToString(), out result2) ? result2 : 0.0,
                        Administer = dataTable1.Rows[index].ItemArray[5] as string,
                        NumberFolds = int.TryParse(dataTable1.Rows[index].ItemArray[6].ToString(), out result1) ? result1 : 0,
                        LocationFold = dataTable1.Rows[index].ItemArray[7] as string,
                        Vertical = dataTable1.Rows[index].ItemArray[8] as string,
                        Horizantal = dataTable1.Rows[index].ItemArray[9] as string,
                        Date = int.TryParse(dataTable1.Rows[index].ItemArray[10].ToString(), out result1) ? result1 : 0,
                        River_Id = int.TryParse(dataTable1.Rows[index].ItemArray[11].ToString(), out result1) ? result1 : 0,
                        Status = (byte)4
                    };
                }
                this.command.CommandText = "Select *From River";
                this.adapter.InsertCommand = this.command;
                System.Data.DataTable dataTable2 = new System.Data.DataTable();
                this.adapter.Fill(dataTable2);
                RiverClass[] riverClassArray = new RiverClass[dataTable2.Rows.Count];
                for (int index = 0; index < dataTable2.Rows.Count; ++index)
                {
                    riverClassArray[index] = new RiverClass();
                    riverClassArray[index].Id = (int)dataTable2.Rows[index].ItemArray[0];
                    riverClassArray[index].Name = dataTable2.Rows[index].ItemArray[1] as string;
                    riverClassArray[index].Number = (int)dataTable2.Rows[index].ItemArray[2];
                    riverClassArray[index].Status = (byte)4;
                }
                this.connect.Close();
                RiverClass[] array1 = ((IEnumerable<RiverClass>)riverClassArray).OrderBy<RiverClass, string>((Func<RiverClass, string>)(x => x.Name)).ToArray<RiverClass>();
                PostClass[] array2 = ((IEnumerable<PostClass>)postClassArray).OrderBy<PostClass, string>((Func<PostClass, string>)(x => x.NameObserve)).ToArray<PostClass>();
                Form1.analysisForAnalysisList = this.GetAnalysisList("Select Top 100 *From Analysis Order By Id");
                AnalysisListForm analysisListForm = new AnalysisListForm(array1, array2);
                analysisListForm.GetChangeAnalysis += new EventHandler(this.GetChangAnalysis);
                analysisListForm.SetQueryAnalysis += new EventHandler(this.SetQueryAnalysis);
                int num = (int)analysisListForm.ShowDialog();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        private void SetQueryAnalysis(object sender, EventArgs e)
        {
            analysisForAnalysisList = GetAnalysisList(AnalysisListForm.strquery);
        }

        private void GetChangAnalysis(object sender, EventArgs e)
        {
            try
            {
                AnalysisClass analysis = (sender as AnalysisListForm).analysis;
                if (analysis == null)
                    return;
                Form1.StaticId = -1;
                this.connect.Close();
                this.connect.Open();
                if ((int)analysis.Status == 0)
                {
                    OleDbCommand command = this.command;
                    object[] objArray = new object[129];
                    objArray[0] = (object)"Insert Into [Analysis]([Post_Id], [Sana], [Vaqt], [Sigm], [OqimTezligi], [DaryoSarfi],[OqimSarfi], [Namlik], [Tiniqlik], [Rangi], [Harorat], [Suzuvchi], [pH], [O2], [Tuyingan], [CO2], [Qattiqlik], [Xlorid], [Sulfat], [GidroKarbanat], [Na], [K], [Ca], [Mg], [Mineral], [XPK], [BPK], [AzotAmonniy], [AzotNitritniy], [AzotNitratniy],[AzotSumma], [Fosfat], [Si], [Elektr], [Eh_MB], [PUmumiy],[FeUmumiy], [Ci], [Zn], [Ni], [Cr], [Cr_VI],[Cr_III], [Pb], [Hg], [Cd], [Mn], [As],[Fenollar], [Neft], [SPAB], [F], [Sianidi], [Proponil],[DDE], [Rogor], [DDT], [Geksaxloran], [Lindan], [DDD],[Metafos], [Butifos], [Dalapon], [Karbofos]) Values (";
                    objArray[1] = (object)analysis.Post_Id;
                    objArray[2] = (object)", '";
                    objArray[3] = (object)analysis.Sana;
                    objArray[4] = (object)"', '";
                    objArray[5] = (object)analysis.Vaqt;
                    objArray[6] = (object)"', ";
                    objArray[7] = (object)analysis.Sigm.ToString().Replace(",", ".");
                    objArray[8] = (object)", ";
                    int index1 = 9;
                    double num = analysis.OqimTezligi;
                    string str1 = num.ToString().Replace(",", ".");
                    objArray[index1] = (object)str1;
                    int index2 = 10;
                    string str2 = ", ";
                    objArray[index2] = (object)str2;
                    int index3 = 11;
                    num = analysis.DaryoSarfi;
                    string str3 = num.ToString().Replace(",", ".");
                    objArray[index3] = (object)str3;
                    int index4 = 12;
                    string str4 = ", ";
                    objArray[index4] = (object)str4;
                    int index5 = 13;
                    num = analysis.OqimSarfi;
                    string str5 = num.ToString().Replace(",", ".");
                    objArray[index5] = (object)str5;
                    int index6 = 14;
                    string str6 = ", ";
                    objArray[index6] = (object)str6;
                    int index7 = 15;
                    num = analysis.Namlik;
                    string str7 = num.ToString().Replace(",", ".");
                    objArray[index7] = (object)str7;
                    int index8 = 16;
                    string str8 = ", ";
                    objArray[index8] = (object)str8;
                    int index9 = 17;
                    num = analysis.Tiniqlik;
                    string str9 = num.ToString().Replace(",", ".");
                    objArray[index9] = (object)str9;
                    int index10 = 18;
                    string str10 = ", ";
                    objArray[index10] = (object)str10;
                    int index11 = 19;
                    num = analysis.Rangi;
                    string str11 = num.ToString().Replace(",", ".");
                    objArray[index11] = (object)str11;
                    int index12 = 20;
                    string str12 = ", ";
                    objArray[index12] = (object)str12;
                    int index13 = 21;
                    num = analysis.Harorat;
                    string str13 = num.ToString().Replace(",", ".");
                    objArray[index13] = (object)str13;
                    int index14 = 22;
                    string str14 = ", ";
                    objArray[index14] = (object)str14;
                    int index15 = 23;
                    num = analysis.Suzuvchi;
                    string str15 = num.ToString().Replace(",", ".");
                    objArray[index15] = (object)str15;
                    int index16 = 24;
                    string str16 = ", ";
                    objArray[index16] = (object)str16;
                    int index17 = 25;
                    num = analysis.pH;
                    string str17 = num.ToString().Replace(",", ".");
                    objArray[index17] = (object)str17;
                    int index18 = 26;
                    string str18 = ", ";
                    objArray[index18] = (object)str18;
                    int index19 = 27;
                    num = analysis.O2;
                    string str19 = num.ToString().Replace(",", ".");
                    objArray[index19] = (object)str19;
                    int index20 = 28;
                    string str20 = ", ";
                    objArray[index20] = (object)str20;
                    int index21 = 29;
                    num = analysis.Tuyingan;
                    string str21 = num.ToString().Replace(",", ".");
                    objArray[index21] = (object)str21;
                    int index22 = 30;
                    string str22 = ", ";
                    objArray[index22] = (object)str22;
                    int index23 = 31;
                    num = analysis.CO2;
                    string str23 = num.ToString().Replace(",", ".");
                    objArray[index23] = (object)str23;
                    int index24 = 32;
                    string str24 = ", ";
                    objArray[index24] = (object)str24;
                    int index25 = 33;
                    num = analysis.Qattiqlik;
                    string str25 = num.ToString().Replace(",", ".");
                    objArray[index25] = (object)str25;
                    int index26 = 34;
                    string str26 = ", ";
                    objArray[index26] = (object)str26;
                    int index27 = 35;
                    num = analysis.Xlorid;
                    string str27 = num.ToString().Replace(",", ".");
                    objArray[index27] = (object)str27;
                    int index28 = 36;
                    string str28 = ", ";
                    objArray[index28] = (object)str28;
                    int index29 = 37;
                    num = analysis.Sulfat;
                    string str29 = num.ToString().Replace(",", ".");
                    objArray[index29] = (object)str29;
                    int index30 = 38;
                    string str30 = ", ";
                    objArray[index30] = (object)str30;
                    int index31 = 39;
                    num = analysis.GidroKarbanat;
                    string str31 = num.ToString().Replace(",", ".");
                    objArray[index31] = (object)str31;
                    int index32 = 40;
                    string str32 = ", ";
                    objArray[index32] = (object)str32;
                    int index33 = 41;
                    num = analysis.Na;
                    string str33 = num.ToString().Replace(",", ".");
                    objArray[index33] = (object)str33;
                    int index34 = 42;
                    string str34 = ", ";
                    objArray[index34] = (object)str34;
                    int index35 = 43;
                    num = analysis.K;
                    string str35 = num.ToString().Replace(",", ".");
                    objArray[index35] = (object)str35;
                    int index36 = 44;
                    string str36 = ", ";
                    objArray[index36] = (object)str36;
                    int index37 = 45;
                    num = analysis.Ca;
                    string str37 = num.ToString().Replace(",", ".");
                    objArray[index37] = (object)str37;
                    int index38 = 46;
                    string str38 = ", ";
                    objArray[index38] = (object)str38;
                    int index39 = 47;
                    num = analysis.Mg;
                    string str39 = num.ToString().Replace(",", ".");
                    objArray[index39] = (object)str39;
                    int index40 = 48;
                    string str40 = ", ";
                    objArray[index40] = (object)str40;
                    int index41 = 49;
                    num = analysis.Mineral;
                    string str41 = num.ToString().Replace(",", ".");
                    objArray[index41] = (object)str41;
                    int index42 = 50;
                    string str42 = ", ";
                    objArray[index42] = (object)str42;
                    int index43 = 51;
                    num = analysis.XPK;
                    string str43 = num.ToString().Replace(",", ".");
                    objArray[index43] = (object)str43;
                    int index44 = 52;
                    string str44 = ", ";
                    objArray[index44] = (object)str44;
                    int index45 = 53;
                    num = analysis.BPK;
                    string str45 = num.ToString().Replace(",", ".");
                    objArray[index45] = (object)str45;
                    int index46 = 54;
                    string str46 = ", ";
                    objArray[index46] = (object)str46;
                    int index47 = 55;
                    num = analysis.AzotAmonniy;
                    string str47 = num.ToString().Replace(",", ".");
                    objArray[index47] = (object)str47;
                    int index48 = 56;
                    string str48 = ", ";
                    objArray[index48] = (object)str48;
                    int index49 = 57;
                    num = analysis.AzotNitritniy;
                    string str49 = num.ToString().Replace(",", ".");
                    objArray[index49] = (object)str49;
                    int index50 = 58;
                    string str50 = ", ";
                    objArray[index50] = (object)str50;
                    int index51 = 59;
                    num = analysis.AzotNitratniy;
                    string str51 = num.ToString().Replace(",", ".");
                    objArray[index51] = (object)str51;
                    int index52 = 60;
                    string str52 = ", ";
                    objArray[index52] = (object)str52;
                    int index53 = 61;
                    num = analysis.AzotSumma;
                    string str53 = num.ToString().Replace(",", ".");
                    objArray[index53] = (object)str53;
                    int index54 = 62;
                    string str54 = ", ";
                    objArray[index54] = (object)str54;
                    int index55 = 63;
                    num = analysis.Fosfat;
                    string str55 = num.ToString().Replace(",", ".");
                    objArray[index55] = (object)str55;
                    int index56 = 64;
                    string str56 = ", ";
                    objArray[index56] = (object)str56;
                    int index57 = 65;
                    num = analysis.Si;
                    string str57 = num.ToString().Replace(",", ".");
                    objArray[index57] = (object)str57;
                    int index58 = 66;
                    string str58 = ", ";
                    objArray[index58] = (object)str58;
                    int index59 = 67;
                    num = analysis.Elektr;
                    string str59 = num.ToString().Replace(",", ".");
                    objArray[index59] = (object)str59;
                    int index60 = 68;
                    string str60 = ", ";
                    objArray[index60] = (object)str60;
                    int index61 = 69;
                    num = analysis.Eh_MB;
                    string str61 = num.ToString().Replace(",", ".");
                    objArray[index61] = (object)str61;
                    int index62 = 70;
                    string str62 = ", ";
                    objArray[index62] = (object)str62;
                    int index63 = 71;
                    num = analysis.PUmumiy;
                    string str63 = num.ToString().Replace(",", ".");
                    objArray[index63] = (object)str63;
                    int index64 = 72;
                    string str64 = ", ";
                    objArray[index64] = (object)str64;
                    int index65 = 73;
                    num = analysis.FeUmumiy;
                    string str65 = num.ToString().Replace(",", ".");
                    objArray[index65] = (object)str65;
                    int index66 = 74;
                    string str66 = ", ";
                    objArray[index66] = (object)str66;
                    int index67 = 75;
                    num = analysis.Ci;
                    string str67 = num.ToString().Replace(",", ".");
                    objArray[index67] = (object)str67;
                    int index68 = 76;
                    string str68 = ", ";
                    objArray[index68] = (object)str68;
                    int index69 = 77;
                    num = analysis.Zn;
                    string str69 = num.ToString().Replace(",", ".");
                    objArray[index69] = (object)str69;
                    int index70 = 78;
                    string str70 = ", ";
                    objArray[index70] = (object)str70;
                    int index71 = 79;
                    num = analysis.Ni;
                    string str71 = num.ToString().Replace(",", ".");
                    objArray[index71] = (object)str71;
                    int index72 = 80;
                    string str72 = ", ";
                    objArray[index72] = (object)str72;
                    int index73 = 81;
                    num = analysis.Cr;
                    string str73 = num.ToString().Replace(",", ".");
                    objArray[index73] = (object)str73;
                    int index74 = 82;
                    string str74 = ", ";
                    objArray[index74] = (object)str74;
                    int index75 = 83;
                    num = analysis.Cr_VI;
                    string str75 = num.ToString().Replace(",", ".");
                    objArray[index75] = (object)str75;
                    int index76 = 84;
                    string str76 = ", ";
                    objArray[index76] = (object)str76;
                    int index77 = 85;
                    num = analysis.Cr_III;
                    string str77 = num.ToString().Replace(",", ".");
                    objArray[index77] = (object)str77;
                    int index78 = 86;
                    string str78 = ", ";
                    objArray[index78] = (object)str78;
                    int index79 = 87;
                    num = analysis.Pb;
                    string str79 = num.ToString().Replace(",", ".");
                    objArray[index79] = (object)str79;
                    int index80 = 88;
                    string str80 = ", ";
                    objArray[index80] = (object)str80;
                    int index81 = 89;
                    num = analysis.Hg;
                    string str81 = num.ToString().Replace(",", ".");
                    objArray[index81] = (object)str81;
                    int index82 = 90;
                    string str82 = ", ";
                    objArray[index82] = (object)str82;
                    int index83 = 91;
                    num = analysis.Cd;
                    string str83 = num.ToString().Replace(",", ".");
                    objArray[index83] = (object)str83;
                    int index84 = 92;
                    string str84 = ", ";
                    objArray[index84] = (object)str84;
                    int index85 = 93;
                    num = analysis.Mn;
                    string str85 = num.ToString().Replace(",", ".");
                    objArray[index85] = (object)str85;
                    int index86 = 94;
                    string str86 = ", ";
                    objArray[index86] = (object)str86;
                    int index87 = 95;
                    num = analysis.As;
                    string str87 = num.ToString().Replace(",", ".");
                    objArray[index87] = (object)str87;
                    int index88 = 96;
                    string str88 = ", ";
                    objArray[index88] = (object)str88;
                    int index89 = 97;
                    num = analysis.Fenollar;
                    string str89 = num.ToString().Replace(",", ".");
                    objArray[index89] = (object)str89;
                    int index90 = 98;
                    string str90 = ", ";
                    objArray[index90] = (object)str90;
                    int index91 = 99;
                    num = analysis.Neft;
                    string str91 = num.ToString().Replace(",", ".");
                    objArray[index91] = (object)str91;
                    int index92 = 100;
                    string str92 = ", ";
                    objArray[index92] = (object)str92;
                    int index93 = 101;
                    num = analysis.SPAB;
                    string str93 = num.ToString().Replace(",", ".");
                    objArray[index93] = (object)str93;
                    int index94 = 102;
                    string str94 = ", ";
                    objArray[index94] = (object)str94;
                    int index95 = 103;
                    num = analysis.F;
                    string str95 = num.ToString().Replace(",", ".");
                    objArray[index95] = (object)str95;
                    int index96 = 104;
                    string str96 = ", ";
                    objArray[index96] = (object)str96;
                    int index97 = 105;
                    num = analysis.Sianidi;
                    string str97 = num.ToString().Replace(",", ".");
                    objArray[index97] = (object)str97;
                    int index98 = 106;
                    string str98 = ", ";
                    objArray[index98] = (object)str98;
                    int index99 = 107;
                    num = analysis.Proponil;
                    string str99 = num.ToString().Replace(",", ".");
                    objArray[index99] = (object)str99;
                    int index100 = 108;
                    string str100 = ", ";
                    objArray[index100] = (object)str100;
                    int index101 = 109;
                    num = analysis.DDE;
                    string str101 = num.ToString().Replace(",", ".");
                    objArray[index101] = (object)str101;
                    int index102 = 110;
                    string str102 = ", ";
                    objArray[index102] = (object)str102;
                    int index103 = 111;
                    num = analysis.Rogor;
                    string str103 = num.ToString().Replace(",", ".");
                    objArray[index103] = (object)str103;
                    int index104 = 112;
                    string str104 = ", ";
                    objArray[index104] = (object)str104;
                    int index105 = 113;
                    num = analysis.DDT;
                    string str105 = num.ToString().Replace(",", ".");
                    objArray[index105] = (object)str105;
                    int index106 = 114;
                    string str106 = ", ";
                    objArray[index106] = (object)str106;
                    int index107 = 115;
                    num = analysis.Geksaxloran;
                    string str107 = num.ToString().Replace(",", ".");
                    objArray[index107] = (object)str107;
                    int index108 = 116;
                    string str108 = ", ";
                    objArray[index108] = (object)str108;
                    int index109 = 117;
                    num = analysis.Lindan;
                    string str109 = num.ToString().Replace(",", ".");
                    objArray[index109] = (object)str109;
                    int index110 = 118;
                    string str110 = ", ";
                    objArray[index110] = (object)str110;
                    int index111 = 119;
                    num = analysis.DDD;
                    string str111 = num.ToString().Replace(",", ".");
                    objArray[index111] = (object)str111;
                    int index112 = 120;
                    string str112 = ", ";
                    objArray[index112] = (object)str112;
                    int index113 = 121;
                    num = analysis.Metafos;
                    string str113 = num.ToString().Replace(",", ".");
                    objArray[index113] = (object)str113;
                    int index114 = 122;
                    string str114 = ", ";
                    objArray[index114] = (object)str114;
                    int index115 = 123;
                    num = analysis.Butifos;
                    string str115 = num.ToString().Replace(",", ".");
                    objArray[index115] = (object)str115;
                    int index116 = 124;
                    string str116 = ", ";
                    objArray[index116] = (object)str116;
                    int index117 = 125;
                    num = analysis.Dalapon;
                    string str117 = num.ToString().Replace(",", ".");
                    objArray[index117] = (object)str117;
                    int index118 = 126;
                    string str118 = ", ";
                    objArray[index118] = (object)str118;
                    int maxValue = (int)sbyte.MaxValue;
                    num = analysis.Karbofos;
                    string str119 = num.ToString().Replace(",", ".");
                    objArray[maxValue] = (object)str119;
                    int index119 = 128;
                    string str120 = ")";
                    objArray[index119] = (object)str120;
                    string str121 = string.Concat(objArray);
                    command.CommandText = str121;
                    this.command.ExecuteNonQuery();
                    this.command.CommandText = "Select Max(Id) From Analysis";
                    Form1.StaticId = (int)this.command.ExecuteScalar();
                }
                else if ((int)analysis.Status == 1)
                {
                    OleDbCommand command = this.command;
                    string[] strArray = new string[130];
                    strArray[0] = "Update [Analysis] Set [Post_Id]=";
                    int index1 = 1;
                    int num1 = analysis.Post_Id;
                    string str1 = num1.ToString().Replace(",", ".");
                    strArray[index1] = str1;
                    int index2 = 2;
                    string str2 = ", [Sana]='";
                    strArray[index2] = str2;
                    int index3 = 3;
                    string sana = analysis.Sana;
                    strArray[index3] = sana;
                    int index4 = 4;
                    string str3 = "', [Vaqt]='";
                    strArray[index4] = str3;
                    int index5 = 5;
                    string vaqt = analysis.Vaqt;
                    strArray[index5] = vaqt;
                    int index6 = 6;
                    string str4 = "', [Sigm]=";
                    strArray[index6] = str4;
                    int index7 = 7;
                    string str5 = analysis.Sigm.ToString().Replace(",", ".");
                    strArray[index7] = str5;
                    int index8 = 8;
                    string str6 = ",[OqimTezligi]=";
                    strArray[index8] = str6;
                    int index9 = 9;
                    double num2 = analysis.OqimTezligi;
                    string str7 = num2.ToString().Replace(",", ".");
                    strArray[index9] = str7;
                    int index10 = 10;
                    string str8 = ",[DaryoSarfi]=";
                    strArray[index10] = str8;
                    int index11 = 11;
                    num2 = analysis.DaryoSarfi;
                    string str9 = num2.ToString().Replace(",", ".");
                    strArray[index11] = str9;
                    int index12 = 12;
                    string str10 = ", [OqimSarfi]=";
                    strArray[index12] = str10;
                    int index13 = 13;
                    num2 = analysis.OqimSarfi;
                    string str11 = num2.ToString().Replace(",", ".");
                    strArray[index13] = str11;
                    int index14 = 14;
                    string str12 = ",[Namlik]=";
                    strArray[index14] = str12;
                    int index15 = 15;
                    num2 = analysis.Namlik;
                    string str13 = num2.ToString().Replace(",", ".");
                    strArray[index15] = str13;
                    int index16 = 16;
                    string str14 = ",[Tiniqlik]=";
                    strArray[index16] = str14;
                    int index17 = 17;
                    num2 = analysis.Tiniqlik;
                    string str15 = num2.ToString().Replace(",", ".");
                    strArray[index17] = str15;
                    int index18 = 18;
                    string str16 = ", [Rangi]=";
                    strArray[index18] = str16;
                    int index19 = 19;
                    num2 = analysis.Rangi;
                    string str17 = num2.ToString().Replace(",", ".");
                    strArray[index19] = str17;
                    int index20 = 20;
                    string str18 = ",[Harorat]=";
                    strArray[index20] = str18;
                    int index21 = 21;
                    num2 = analysis.Harorat;
                    string str19 = num2.ToString().Replace(",", ".");
                    strArray[index21] = str19;
                    int index22 = 22;
                    string str20 = ",[Suzuvchi]=";
                    strArray[index22] = str20;
                    int index23 = 23;
                    num2 = analysis.Suzuvchi;
                    string str21 = num2.ToString().Replace(",", ".");
                    strArray[index23] = str21;
                    int index24 = 24;
                    string str22 = ", [pH]=";
                    strArray[index24] = str22;
                    int index25 = 25;
                    num2 = analysis.pH;
                    string str23 = num2.ToString().Replace(",", ".");
                    strArray[index25] = str23;
                    int index26 = 26;
                    string str24 = ",[O2]=";
                    strArray[index26] = str24;
                    int index27 = 27;
                    num2 = analysis.O2;
                    string str25 = num2.ToString().Replace(",", ".");
                    strArray[index27] = str25;
                    int index28 = 28;
                    string str26 = ",[Tuyingan]=";
                    strArray[index28] = str26;
                    int index29 = 29;
                    num2 = analysis.Tuyingan;
                    string str27 = num2.ToString().Replace(",", ".");
                    strArray[index29] = str27;
                    int index30 = 30;
                    string str28 = ", [CO2]=";
                    strArray[index30] = str28;
                    int index31 = 31;
                    num2 = analysis.CO2;
                    string str29 = num2.ToString().Replace(",", ".");
                    strArray[index31] = str29;
                    int index32 = 32;
                    string str30 = ",[Qattiqlik]=";
                    strArray[index32] = str30;
                    int index33 = 33;
                    num2 = analysis.Qattiqlik;
                    string str31 = num2.ToString().Replace(",", ".");
                    strArray[index33] = str31;
                    int index34 = 34;
                    string str32 = ",[Xlorid]=";
                    strArray[index34] = str32;
                    int index35 = 35;
                    num2 = analysis.Xlorid;
                    string str33 = num2.ToString().Replace(",", ".");
                    strArray[index35] = str33;
                    int index36 = 36;
                    string str34 = ", [Sulfat]=";
                    strArray[index36] = str34;
                    int index37 = 37;
                    num2 = analysis.Sulfat;
                    string str35 = num2.ToString().Replace(",", ".");
                    strArray[index37] = str35;
                    int index38 = 38;
                    string str36 = ",[GidroKarbanat]=";
                    strArray[index38] = str36;
                    int index39 = 39;
                    num2 = analysis.GidroKarbanat;
                    string str37 = num2.ToString().Replace(",", ".");
                    strArray[index39] = str37;
                    int index40 = 40;
                    string str38 = ",[Na]=";
                    strArray[index40] = str38;
                    int index41 = 41;
                    num2 = analysis.Na;
                    string str39 = num2.ToString().Replace(",", ".");
                    strArray[index41] = str39;
                    int index42 = 42;
                    string str40 = ", [K]=";
                    strArray[index42] = str40;
                    int index43 = 43;
                    num2 = analysis.K;
                    string str41 = num2.ToString().Replace(",", ".");
                    strArray[index43] = str41;
                    int index44 = 44;
                    string str42 = ",[Ca]=";
                    strArray[index44] = str42;
                    int index45 = 45;
                    num2 = analysis.Ca;
                    string str43 = num2.ToString().Replace(",", ".");
                    strArray[index45] = str43;
                    int index46 = 46;
                    string str44 = ",[Mg]=";
                    strArray[index46] = str44;
                    int index47 = 47;
                    num2 = analysis.Mg;
                    string str45 = num2.ToString().Replace(",", ".");
                    strArray[index47] = str45;
                    int index48 = 48;
                    string str46 = ", [Mineral]=";
                    strArray[index48] = str46;
                    int index49 = 49;
                    num2 = analysis.Mineral;
                    string str47 = num2.ToString().Replace(",", ".");
                    strArray[index49] = str47;
                    int index50 = 50;
                    string str48 = ",[XPK]=";
                    strArray[index50] = str48;
                    int index51 = 51;
                    num2 = analysis.XPK;
                    string str49 = num2.ToString().Replace(",", ".");
                    strArray[index51] = str49;
                    int index52 = 52;
                    string str50 = ",[BPK]=";
                    strArray[index52] = str50;
                    int index53 = 53;
                    num2 = analysis.BPK;
                    string str51 = num2.ToString().Replace(",", ".");
                    strArray[index53] = str51;
                    int index54 = 54;
                    string str52 = ", [AzotAmonniy]=";
                    strArray[index54] = str52;
                    int index55 = 55;
                    num2 = analysis.AzotAmonniy;
                    string str53 = num2.ToString().Replace(",", ".");
                    strArray[index55] = str53;
                    int index56 = 56;
                    string str54 = ",[AzotNitritniy]=";
                    strArray[index56] = str54;
                    int index57 = 57;
                    num2 = analysis.AzotNitritniy;
                    string str55 = num2.ToString().Replace(",", ".");
                    strArray[index57] = str55;
                    int index58 = 58;
                    string str56 = ",[AzotNitratniy]=";
                    strArray[index58] = str56;
                    int index59 = 59;
                    num2 = analysis.AzotNitratniy;
                    string str57 = num2.ToString().Replace(",", ".");
                    strArray[index59] = str57;
                    int index60 = 60;
                    string str58 = ", [AzotSumma]=";
                    strArray[index60] = str58;
                    int index61 = 61;
                    num2 = analysis.AzotSumma;
                    string str59 = num2.ToString().Replace(",", ".");
                    strArray[index61] = str59;
                    int index62 = 62;
                    string str60 = ",[Fosfat]=";
                    strArray[index62] = str60;
                    int index63 = 63;
                    num2 = analysis.Fosfat;
                    string str61 = num2.ToString().Replace(",", ".");
                    strArray[index63] = str61;
                    int index64 = 64;
                    string str62 = ",[Si]=";
                    strArray[index64] = str62;
                    int index65 = 65;
                    num2 = analysis.Si;
                    string str63 = num2.ToString().Replace(",", ".");
                    strArray[index65] = str63;
                    int index66 = 66;
                    string str64 = ", [Elektr]=";
                    strArray[index66] = str64;
                    int index67 = 67;
                    num2 = analysis.Elektr;
                    string str65 = num2.ToString().Replace(",", ".");
                    strArray[index67] = str65;
                    int index68 = 68;
                    string str66 = ",[Eh_MB]=";
                    strArray[index68] = str66;
                    int index69 = 69;
                    num2 = analysis.Eh_MB;
                    string str67 = num2.ToString().Replace(",", ".");
                    strArray[index69] = str67;
                    int index70 = 70;
                    string str68 = ",[PUmumiy]=";
                    strArray[index70] = str68;
                    int index71 = 71;
                    num2 = analysis.PUmumiy;
                    string str69 = num2.ToString().Replace(",", ".");
                    strArray[index71] = str69;
                    int index72 = 72;
                    string str70 = ", [FeUmumiy]=";
                    strArray[index72] = str70;
                    int index73 = 73;
                    num2 = analysis.FeUmumiy;
                    string str71 = num2.ToString().Replace(",", ".");
                    strArray[index73] = str71;
                    int index74 = 74;
                    string str72 = ",[Ci]=";
                    strArray[index74] = str72;
                    int index75 = 75;
                    num2 = analysis.Ci;
                    string str73 = num2.ToString().Replace(",", ".");
                    strArray[index75] = str73;
                    int index76 = 76;
                    string str74 = ",[Zn]=";
                    strArray[index76] = str74;
                    int index77 = 77;
                    num2 = analysis.Zn;
                    string str75 = num2.ToString().Replace(",", ".");
                    strArray[index77] = str75;
                    int index78 = 78;
                    string str76 = ", [Ni]=";
                    strArray[index78] = str76;
                    int index79 = 79;
                    num2 = analysis.Ni;
                    string str77 = num2.ToString().Replace(",", ".");
                    strArray[index79] = str77;
                    int index80 = 80;
                    string str78 = ",[Cr]=";
                    strArray[index80] = str78;
                    int index81 = 81;
                    num2 = analysis.Cr;
                    string str79 = num2.ToString().Replace(",", ".");
                    strArray[index81] = str79;
                    int index82 = 82;
                    string str80 = ",[Cr_VI]=";
                    strArray[index82] = str80;
                    int index83 = 83;
                    num2 = analysis.Cr_VI;
                    string str81 = num2.ToString().Replace(",", ".");
                    strArray[index83] = str81;
                    int index84 = 84;
                    string str82 = ", [Cr_III]=";
                    strArray[index84] = str82;
                    int index85 = 85;
                    num2 = analysis.Cr_III;
                    string str83 = num2.ToString().Replace(",", ".");
                    strArray[index85] = str83;
                    int index86 = 86;
                    string str84 = ",[Pb]=";
                    strArray[index86] = str84;
                    int index87 = 87;
                    num2 = analysis.Pb;
                    string str85 = num2.ToString().Replace(",", ".");
                    strArray[index87] = str85;
                    int index88 = 88;
                    string str86 = ",[Hg]=";
                    strArray[index88] = str86;
                    int index89 = 89;
                    num2 = analysis.Hg;
                    string str87 = num2.ToString().Replace(",", ".");
                    strArray[index89] = str87;
                    int index90 = 90;
                    string str88 = ", [Cd]=";
                    strArray[index90] = str88;
                    int index91 = 91;
                    num2 = analysis.Cd;
                    string str89 = num2.ToString().Replace(",", ".");
                    strArray[index91] = str89;
                    int index92 = 92;
                    string str90 = ",[Mn]=";
                    strArray[index92] = str90;
                    int index93 = 93;
                    num2 = analysis.Mn;
                    string str91 = num2.ToString().Replace(",", ".");
                    strArray[index93] = str91;
                    int index94 = 94;
                    string str92 = ",[As]=";
                    strArray[index94] = str92;
                    int index95 = 95;
                    num2 = analysis.As;
                    string str93 = num2.ToString().Replace(",", ".");
                    strArray[index95] = str93;
                    int index96 = 96;
                    string str94 = ", [Fenollar]=";
                    strArray[index96] = str94;
                    int index97 = 97;
                    num2 = analysis.Fenollar;
                    string str95 = num2.ToString().Replace(",", ".");
                    strArray[index97] = str95;
                    int index98 = 98;
                    string str96 = ",[Neft]=";
                    strArray[index98] = str96;
                    int index99 = 99;
                    num2 = analysis.Neft;
                    string str97 = num2.ToString().Replace(",", ".");
                    strArray[index99] = str97;
                    int index100 = 100;
                    string str98 = ",[SPAB]=";
                    strArray[index100] = str98;
                    int index101 = 101;
                    num2 = analysis.SPAB;
                    string str99 = num2.ToString().Replace(",", ".");
                    strArray[index101] = str99;
                    int index102 = 102;
                    string str100 = ", [F]=";
                    strArray[index102] = str100;
                    int index103 = 103;
                    num2 = analysis.F;
                    string str101 = num2.ToString().Replace(",", ".");
                    strArray[index103] = str101;
                    int index104 = 104;
                    string str102 = ",[Sianidi]=";
                    strArray[index104] = str102;
                    int index105 = 105;
                    num2 = analysis.Sianidi;
                    string str103 = num2.ToString().Replace(",", ".");
                    strArray[index105] = str103;
                    int index106 = 106;
                    string str104 = ",[Proponil]=";
                    strArray[index106] = str104;
                    int index107 = 107;
                    num2 = analysis.Proponil;
                    string str105 = num2.ToString().Replace(",", ".");
                    strArray[index107] = str105;
                    int index108 = 108;
                    string str106 = ", [DDE]=";
                    strArray[index108] = str106;
                    int index109 = 109;
                    num2 = analysis.DDE;
                    string str107 = num2.ToString().Replace(",", ".");
                    strArray[index109] = str107;
                    int index110 = 110;
                    string str108 = ",[Rogor]=";
                    strArray[index110] = str108;
                    int index111 = 111;
                    num2 = analysis.Rogor;
                    string str109 = num2.ToString().Replace(",", ".");
                    strArray[index111] = str109;
                    int index112 = 112;
                    string str110 = ",[DDT]=";
                    strArray[index112] = str110;
                    int index113 = 113;
                    num2 = analysis.DDT;
                    string str111 = num2.ToString().Replace(",", ".");
                    strArray[index113] = str111;
                    int index114 = 114;
                    string str112 = ", [Geksaxloran]=";
                    strArray[index114] = str112;
                    int index115 = 115;
                    num2 = analysis.Geksaxloran;
                    string str113 = num2.ToString().Replace(",", ".");
                    strArray[index115] = str113;
                    int index116 = 116;
                    string str114 = ",[Lindan]=";
                    strArray[index116] = str114;
                    int index117 = 117;
                    num2 = analysis.Lindan;
                    string str115 = num2.ToString().Replace(",", ".");
                    strArray[index117] = str115;
                    int index118 = 118;
                    string str116 = ",[DDD]=";
                    strArray[index118] = str116;
                    int index119 = 119;
                    num2 = analysis.DDD;
                    string str117 = num2.ToString().Replace(",", ".");
                    strArray[index119] = str117;
                    int index120 = 120;
                    string str118 = ", [Metafos]=";
                    strArray[index120] = str118;
                    int index121 = 121;
                    num2 = analysis.Metafos;
                    string str119 = num2.ToString().Replace(",", ".");
                    strArray[index121] = str119;
                    int index122 = 122;
                    string str120 = ",[Butifos]=";
                    strArray[index122] = str120;
                    int index123 = 123;
                    num2 = analysis.Butifos;
                    string str121 = num2.ToString().Replace(",", ".");
                    strArray[index123] = str121;
                    int index124 = 124;
                    string str122 = ",[Dalapon]=";
                    strArray[index124] = str122;
                    int index125 = 125;
                    num2 = analysis.Dalapon;
                    string str123 = num2.ToString().Replace(",", ".");
                    strArray[index125] = str123;
                    int index126 = 126;
                    string str124 = ", [Karbofos]=";
                    strArray[index126] = str124;
                    int maxValue = (int)sbyte.MaxValue;
                    num2 = analysis.Karbofos;
                    string str125 = num2.ToString().Replace(",", ".");
                    strArray[maxValue] = str125;
                    int index127 = 128;
                    string str126 = " Where Id=";
                    strArray[index127] = str126;
                    int index128 = 129;
                    num1 = analysis.Id;
                    string str127 = num1.ToString().Replace(",", ".");
                    strArray[index128] = str127;
                    string str128 = string.Concat(strArray);
                    command.CommandText = str128;
                    this.command.ExecuteNonQuery();
                    Form1.StaticId = analysis.Id;
                }
                else
                {
                    this.command.CommandText = "Delete From Analysis Where Id=" + analysis.Id.ToString();
                    this.command.ExecuteNonQuery();
                }
                this.connect.Close();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region River change Click

        private void mnServisItemRiver_Click(object sender, EventArgs e)
        {
            try
            {
                this.connect.Close();
                this.connect.Open();
                this.command.CommandText = "Select *From River";
                this.adapter.InsertCommand = this.command;
                System.Data.DataTable dataTable = new System.Data.DataTable();
                this.adapter.Fill(dataTable);
                this.connect.Close();
                RiverClass[] riverClassArray = new RiverClass[dataTable.Rows.Count];
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    riverClassArray[index] = new RiverClass();
                    riverClassArray[index].Id = (int)dataTable.Rows[index].ItemArray[0];
                    riverClassArray[index].Name = (string)dataTable.Rows[index].ItemArray[1];
                    riverClassArray[index].Number = (int)dataTable.Rows[index].ItemArray[2];
                    riverClassArray[index].Status = (byte)4;
                }
                RiverListForm riverListForm = new RiverListForm(((IEnumerable<RiverClass>)riverClassArray).ToList<RiverClass>());
                riverListForm.GetChangeRiver += new EventHandler(this.GetChangeRiver);
                int num = (int)riverListForm.ShowDialog();
            }
            catch (OleDbException ex)
            {
                int num = (int)MessageBox.Show(ex.Message + "\nError key = 1");
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message + "\nError key = 2");
            }
        }

        private void GetChangeRiver(object sender, EventArgs e)
        {
            try
            {
                RiverClass river = (sender as RiverListForm).river;
                if (river == null)
                    return;
                Form1.StaticId = -1;
                this.connect.Close();
                this.connect.Open();
                if ((int)river.Status == 0)
                {
                    this.command.CommandText = "Insert Into [River]([Name], [Number], [Status]) Values ('" + river.Name.Replace("'", "''") + "', " + (object)river.Number + ", true)";
                    this.command.ExecuteNonQuery();
                    this.command.CommandText = "Select Max(Id) From River";
                    Form1.StaticId = (int)this.command.ExecuteScalar();
                }
                else if ((int)river.Status == 1)
                {
                    this.command.CommandText = "Update [River] Set [Name]='" + river.Name + "', [Number]=" + (object)river.Number + " Where [Id]=" + river.Id.ToString();
                    this.command.ExecuteNonQuery();
                    Form1.StaticId = river.Id;
                }
                else
                {
                    this.command.CommandText = "Delete From River Where Id=" + river.Id.ToString();
                    this.command.ExecuteNonQuery();
                    this.command.CommandText = "Select Id From Post Where River_Id=" + (object)river.Id;
                    this.adapter.InsertCommand = this.command;
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    this.adapter.Fill(dataTable);
                    for (int index = 0; index < dataTable.Rows.Count; ++index)
                        this.DeleteAnaliz((int)dataTable.Rows[index].ItemArray[0]);
                    this.command.CommandText = "Delete From Post Where River_Id=" + river.Id.ToString();
                    this.command.ExecuteNonQuery();
                }
                this.connect.Close();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        private void DeleteAnaliz(int PostId)
        {
            try
            {
                this.connect.Close();
                this.connect.Open();
                this.command.CommandText = "Delete From Analysis Where Post_Id=" + PostId.ToString();
                this.command.ExecuteNonQuery();
                this.connect.Close();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Post change Click

        private void mnServisItemPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.connect.Close();
                this.connect.Open();
                this.command.CommandText = "Select *From Post";
                this.adapter.InsertCommand = this.command;
                System.Data.DataTable dataTable1 = new System.Data.DataTable();
                this.adapter.Fill(dataTable1);
                PostClass[] postClassArray = new PostClass[dataTable1.Rows.Count];
                for (int index = 0; index < dataTable1.Rows.Count; ++index)
                {
                    int result1;
                    double result2;
                    postClassArray[index] = new PostClass()
                    {
                        Id = int.TryParse(dataTable1.Rows[index].ItemArray[0].ToString(), out result1) ? result1 : 0,
                        NumberControl = int.TryParse(dataTable1.Rows[index].ItemArray[1].ToString(), out result1) ? result1 : 0,
                        NameObject = dataTable1.Rows[index].ItemArray[2] as string,
                        NameObserve = dataTable1.Rows[index].ItemArray[3] as string,
                        Distance = double.TryParse(dataTable1.Rows[index].ItemArray[4].ToString(), out result2) ? result2 : 0.0,
                        Administer = dataTable1.Rows[index].ItemArray[5] as string,
                        NumberFolds = int.TryParse(dataTable1.Rows[index].ItemArray[6].ToString(), out result1) ? result1 : 0,
                        LocationFold = dataTable1.Rows[index].ItemArray[7] as string,
                        Vertical = dataTable1.Rows[index].ItemArray[8] as string,
                        Horizantal = dataTable1.Rows[index].ItemArray[9] as string,
                        Date = int.TryParse(dataTable1.Rows[index].ItemArray[10].ToString(), out result1) ? result1 : 0,
                        River_Id = int.TryParse(dataTable1.Rows[index].ItemArray[11].ToString(), out result1) ? result1 : 0,
                        Status = (byte)4
                    };
                }
                this.command.CommandText = "Select *From River";
                this.adapter.InsertCommand = this.command;
                System.Data.DataTable dataTable2 = new System.Data.DataTable();
                this.adapter.Fill(dataTable2);
                RiverClass[] riverClassArray = new RiverClass[dataTable2.Rows.Count];
                for (int index = 0; index < dataTable2.Rows.Count; ++index)
                {
                    riverClassArray[index] = new RiverClass();
                    riverClassArray[index].Id = (int)dataTable2.Rows[index].ItemArray[0];
                    riverClassArray[index].Name = dataTable2.Rows[index].ItemArray[1] as string;
                    riverClassArray[index].Number = (int)dataTable2.Rows[index].ItemArray[2];
                    riverClassArray[index].Status = (byte)4;
                }
                this.connect.Close();
                PostListForm postListForm = new PostListForm(((IEnumerable<PostClass>)postClassArray).ToList<PostClass>(), ((IEnumerable<RiverClass>)riverClassArray).ToList<RiverClass>());
                postListForm.GetChangePost += new EventHandler(this.GetChangePost);
                int num = (int)postListForm.ShowDialog();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
        }

        private void GetChangePost(object sender, EventArgs e)
        {
            try
            {
                PostClass post = (sender as PostListForm).post;
                if (post == null)
                    return;
                Form1.StaticId = -1;
                this.connect.Close();
                this.connect.Open();
                
                if ((int)post.Status == 0)
                {
                    this.command.CommandText = "Insert Into [Post]([NumberControl], [NameObject], [NameObserve], [Distance], [Administer], [NumberFolds], [LocationFold], [Vertical], [Horizantal], [Date], [River_Id])  Values (" + (object)post.NumberControl + ", '" + post.NameObject + "', '" + post.NameObserve + "', " + post.Distance.ToString().Replace(',', '.') + ", '" + post.Administer + "', " + (object)post.NumberFolds + ", '" + post.LocationFold + "', '" + post.Vertical + "', '" + post.Horizantal + "', " + (object)post.Date + ", " + (object)post.River_Id + ")";
                    //MessageBox.Show(this.command.CommandText);
                    this.command.ExecuteNonQuery();
                    this.command.CommandText = "Select Max(Id) From Post";
                    Form1.StaticId = (int)this.command.ExecuteScalar();
                }
                else if ((int)post.Status == 1)
                {
                    this.command.CommandText = "Update [Post] Set [NumberControl]=" + (object)post.NumberControl + ", [NameObject]='" + post.NameObject + "', [NameObserve]='" + post.NameObserve + "', [Distance]=" + post.Distance.ToString().Replace(',', '.') + ", [Administer]='" + post.Administer + "', [NumberFolds]=" + (object)post.NumberFolds + ", [LocationFold]='" + post.LocationFold + "', [Vertical]='" + post.Vertical + "', [Horizantal]='" + post.Horizantal + "', [Date]=" + (object)post.Date + ", [River_Id]=" + (object)post.River_Id + " Where Id=" + post.Id.ToString();
                    //MessageBox.Show(this.command.CommandText);
                    this.command.ExecuteNonQuery();
                    Form1.StaticId = post.Id;
                }
                else
                {
                    this.command.CommandText = "Delete From Post Where Id=" + post.Id.ToString();
                    this.command.ExecuteNonQuery();
                    this.DeleteAnaliz(post.Id);
                }
                this.connect.Close();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Other Click menuItem
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Search  Click

        private void cbRiverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int River_Id = (this.cbRiverList.SelectedItem as RiverClass).Id;
            this.cbPost.DataSource = (object)null;
            this.cbPost.DataSource = (object)this.posts.Where<PostClass>((Func<PostClass, bool>)(x => x.River_Id == River_Id)).OrderBy<PostClass, string>((Func<PostClass, string>)(x => x.NameObserve)).ToList<PostClass>();
            this.cbPost.DisplayMember = "NameObserve";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            for (int index = 7; index < this.dgvAnalysis.ColumnCount - 1; ++index)
                this.dgvAnalysis.Columns[index].Visible = true;
            string strquery = "Select *From Analysis ";
            bool flag = false;
            if (this.chbPost.Checked && this.cbPost.SelectedItem != null)
            {
                strquery = strquery + " Where Post_Id=" + (this.cbPost.SelectedItem as PostClass).Id.ToString() + " ";
                flag = true;
            }
            if (this.chbDate.Checked)
                strquery = (!flag ? strquery + " Where " : strquery + " And ") + " Sana>=#" + this.dtpFrom.Value.ToShortDateString().Replace(".", "/") + "# And Sana<=#" + this.dtpTo.Value.ToShortDateString().Replace(".", "/") + "# ";

            if (this.chbPost.Checked == false && this.chbDate.Checked == false)
                strquery = "Select Top 100 *From Analysis Order By Id";
            this.DBFill(strquery);
        }

        private void btnKomponent_Click(object sender, EventArgs e)
        {
            KoponenteCheckedListForm koponenteCheckedListForm = new KoponenteCheckedListForm(this.koms, this.t);
            koponenteCheckedListForm.GetBool += new EventHandler(this.GetBool);
            int num = (int)koponenteCheckedListForm.ShowDialog();
        }

        private void GetBool(object sender, EventArgs e)
        {
            this.t = (sender as KoponenteCheckedListForm).t;
            this.btnSearch_Click(sender, e);
        }

        #endregion

        #region Click Menu File

        private void mnmainItemImport_Click(object sender, EventArgs e)
        {
            try
            {
                ImportForm importForm = new ImportForm(this.rivers, this.posts);
                importForm.GetFileName += new EventHandler(this.ImportExel);
                importForm.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void ImportExel(object sender, EventArgs e)
        {
            OleDbTransaction oleDbTransaction = (OleDbTransaction)null;
            try
            {
                int postId = (sender as ImportForm).Post_Id;
                Worksheet worksheet = (new Microsoft.Office.Interop.Excel.Application()).Workbooks.Open((sender as ImportForm).filename, (object)0, (object)true, (object)5, (object)"", (object)"", (object)true, (object)XlPlatform.xlWindows, (object)"\t", (object)false, (object)false, (object)0, (object)true, System.Type.Missing, System.Type.Missing).Worksheets.get_Item((object)1) as Worksheet;
                this.connect.Close();
                this.connect.Open();
                oleDbTransaction = this.connect.BeginTransaction();
                this.command.Transaction = oleDbTransaction;
                AnalysisClass analysisClass = new AnalysisClass();
                analysisClass.Post_Id = postId;
                for (int index1 = 2; index1 <= worksheet.UsedRange.Columns.Count; ++index1)
                {
                    DateTime dateTime1 = DateTime.Parse((worksheet.Cells[(object)2, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString());
                    analysisClass.Sana = dateTime1.ToShortDateString();
                    double result = double.Parse((worksheet.Cells[(object)3, (object)index1] as Microsoft.Office.Interop.Excel.Range).Value2.ToString());
                    DateTime dateTime2 = DateTime.FromOADate(result);
                    analysisClass.Vaqt = dateTime2.ToShortTimeString();
                    analysisClass.Sigm = double.TryParse((worksheet.Cells[(object)4, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.OqimTezligi = double.TryParse((worksheet.Cells[(object)5, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.DaryoSarfi = double.TryParse((worksheet.Cells[(object)6, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.OqimSarfi = double.TryParse((worksheet.Cells[(object)7, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Namlik = double.TryParse((worksheet.Cells[(object)8, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Tiniqlik = double.TryParse((worksheet.Cells[(object)9, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Rangi = double.TryParse((worksheet.Cells[(object)10, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Harorat = double.TryParse((worksheet.Cells[(object)11, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Suzuvchi = double.TryParse((worksheet.Cells[(object)12, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.pH = double.TryParse((worksheet.Cells[(object)13, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.O2 = double.TryParse((worksheet.Cells[(object)14, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Tuyingan = double.TryParse((worksheet.Cells[(object)15, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.CO2 = double.TryParse((worksheet.Cells[(object)16, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Qattiqlik = double.TryParse((worksheet.Cells[(object)17, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Xlorid = double.TryParse((worksheet.Cells[(object)18, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Sulfat = double.TryParse((worksheet.Cells[(object)19, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.GidroKarbanat = double.TryParse((worksheet.Cells[(object)20, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Na = double.TryParse((worksheet.Cells[(object)21, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.K = double.TryParse((worksheet.Cells[(object)22, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Ca = double.TryParse((worksheet.Cells[(object)23, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Mg = double.TryParse((worksheet.Cells[(object)24, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Mineral = double.TryParse((worksheet.Cells[(object)25, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.XPK = double.TryParse((worksheet.Cells[(object)26, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.BPK = double.TryParse((worksheet.Cells[(object)27, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.AzotAmonniy = double.TryParse((worksheet.Cells[(object)28, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.AzotNitritniy = double.TryParse((worksheet.Cells[(object)29, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.AzotNitratniy = double.TryParse((worksheet.Cells[(object)30, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.AzotSumma = double.TryParse((worksheet.Cells[(object)31, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Fosfat = double.TryParse((worksheet.Cells[(object)32, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Si = double.TryParse((worksheet.Cells[(object)33, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Elektr = double.TryParse((worksheet.Cells[(object)34, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Eh_MB = double.TryParse((worksheet.Cells[(object)35, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.PUmumiy = double.TryParse((worksheet.Cells[(object)36, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.FeUmumiy = double.TryParse((worksheet.Cells[(object)37, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Ci = double.TryParse((worksheet.Cells[(object)38, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Zn = double.TryParse((worksheet.Cells[(object)39, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Ni = double.TryParse((worksheet.Cells[(object)40, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Cr = double.TryParse((worksheet.Cells[(object)41, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Cr_VI = double.TryParse((worksheet.Cells[(object)42, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Cr_III = double.TryParse((worksheet.Cells[(object)43, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Pb = double.TryParse((worksheet.Cells[(object)44, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Hg = double.TryParse((worksheet.Cells[(object)45, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Cd = double.TryParse((worksheet.Cells[(object)46, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Mn = double.TryParse((worksheet.Cells[(object)47, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.As = double.TryParse((worksheet.Cells[(object)48, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Fenollar = double.TryParse((worksheet.Cells[(object)49, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Neft = double.TryParse((worksheet.Cells[(object)50, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.SPAB = double.TryParse((worksheet.Cells[(object)51, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.F = double.TryParse((worksheet.Cells[(object)52, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Sianidi = double.TryParse((worksheet.Cells[(object)53, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Proponil = double.TryParse((worksheet.Cells[(object)54, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.DDE = double.TryParse((worksheet.Cells[(object)55, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Rogor = double.TryParse((worksheet.Cells[(object)56, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.DDT = double.TryParse((worksheet.Cells[(object)57, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Geksaxloran = double.TryParse((worksheet.Cells[(object)58, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Lindan = double.TryParse((worksheet.Cells[(object)59, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.DDD = double.TryParse((worksheet.Cells[(object)60, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Metafos = double.TryParse((worksheet.Cells[(object)61, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Butifos = double.TryParse((worksheet.Cells[(object)62, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Dalapon = double.TryParse((worksheet.Cells[(object)63, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    analysisClass.Karbofos = double.TryParse((worksheet.Cells[(object)64, (object)index1] as Microsoft.Office.Interop.Excel.Range).get_Value(System.Type.Missing).ToString(), out result) ? result : -1.0;
                    OleDbCommand command = this.command;
                    object[] objArray = new object[129];
                    objArray[0] = (object)"Insert Into [Analysis]([Post_Id], [Sana], [Vaqt], [Sigm], [OqimTezligi], [DaryoSarfi],[OqimSarfi], [Namlik], [Tiniqlik], [Rangi], [Harorat], [Suzuvchi], [pH], [O2], [Tuyingan], [CO2], [Qattiqlik], [Xlorid], [Sulfat], [GidroKarbanat], [Na], [K], [Ca], [Mg], [Mineral], [XPK], [BPK], [AzotAmonniy], [AzotNitritniy], [AzotNitratniy],[AzotSumma], [Fosfat], [Si], [Elektr], [Eh_MB], [PUmumiy],[FeUmumiy], [Ci], [Zn], [Ni], [Cr], [Cr_VI],[Cr_III], [Pb], [Hg], [Cd], [Mn], [As],[Fenollar], [Neft], [SPAB], [F], [Sianidi], [Proponil],[DDE], [Rogor], [DDT], [Geksaxloran], [Lindan], [DDD],[Metafos], [Butifos], [Dalapon], [Karbofos]) Values (";
                    objArray[1] = (object)analysisClass.Post_Id;
                    objArray[2] = (object)", '";
                    objArray[3] = (object)analysisClass.Sana;
                    objArray[4] = (object)"', '";
                    objArray[5] = (object)analysisClass.Vaqt;
                    objArray[6] = (object)"', ";
                    int index2 = 7;
                    double num = analysisClass.Sigm;
                    string str1 = num.ToString().Replace(",", ".");
                    objArray[index2] = (object)str1;
                    int index3 = 8;
                    string str2 = ", ";
                    objArray[index3] = (object)str2;
                    int index4 = 9;
                    num = analysisClass.OqimTezligi;
                    string str3 = num.ToString().Replace(",", ".");
                    objArray[index4] = (object)str3;
                    int index5 = 10;
                    string str4 = ", ";
                    objArray[index5] = (object)str4;
                    int index6 = 11;
                    num = analysisClass.DaryoSarfi;
                    string str5 = num.ToString().Replace(",", ".");
                    objArray[index6] = (object)str5;
                    int index7 = 12;
                    string str6 = ", ";
                    objArray[index7] = (object)str6;
                    int index8 = 13;
                    num = analysisClass.OqimSarfi;
                    string str7 = num.ToString().Replace(",", ".");
                    objArray[index8] = (object)str7;
                    int index9 = 14;
                    string str8 = ", ";
                    objArray[index9] = (object)str8;
                    int index10 = 15;
                    num = analysisClass.Namlik;
                    string str9 = num.ToString().Replace(",", ".");
                    objArray[index10] = (object)str9;
                    int index11 = 16;
                    string str10 = ", ";
                    objArray[index11] = (object)str10;
                    int index12 = 17;
                    num = analysisClass.Tiniqlik;
                    string str11 = num.ToString().Replace(",", ".");
                    objArray[index12] = (object)str11;
                    int index13 = 18;
                    string str12 = ", ";
                    objArray[index13] = (object)str12;
                    int index14 = 19;
                    num = analysisClass.Rangi;
                    string str13 = num.ToString().Replace(",", ".");
                    objArray[index14] = (object)str13;
                    int index15 = 20;
                    string str14 = ", ";
                    objArray[index15] = (object)str14;
                    int index16 = 21;
                    num = analysisClass.Harorat;
                    string str15 = num.ToString().Replace(",", ".");
                    objArray[index16] = (object)str15;
                    int index17 = 22;
                    string str16 = ", ";
                    objArray[index17] = (object)str16;
                    int index18 = 23;
                    num = analysisClass.Suzuvchi;
                    string str17 = num.ToString().Replace(",", ".");
                    objArray[index18] = (object)str17;
                    int index19 = 24;
                    string str18 = ", ";
                    objArray[index19] = (object)str18;
                    int index20 = 25;
                    num = analysisClass.pH;
                    string str19 = num.ToString().Replace(",", ".");
                    objArray[index20] = (object)str19;
                    int index21 = 26;
                    string str20 = ", ";
                    objArray[index21] = (object)str20;
                    int index22 = 27;
                    num = analysisClass.O2;
                    string str21 = num.ToString().Replace(",", ".");
                    objArray[index22] = (object)str21;
                    int index23 = 28;
                    string str22 = ", ";
                    objArray[index23] = (object)str22;
                    int index24 = 29;
                    num = analysisClass.Tuyingan;
                    string str23 = num.ToString().Replace(",", ".");
                    objArray[index24] = (object)str23;
                    int index25 = 30;
                    string str24 = ", ";
                    objArray[index25] = (object)str24;
                    int index26 = 31;
                    num = analysisClass.CO2;
                    string str25 = num.ToString().Replace(",", ".");
                    objArray[index26] = (object)str25;
                    int index27 = 32;
                    string str26 = ", ";
                    objArray[index27] = (object)str26;
                    int index28 = 33;
                    num = analysisClass.Qattiqlik;
                    string str27 = num.ToString().Replace(",", ".");
                    objArray[index28] = (object)str27;
                    int index29 = 34;
                    string str28 = ", ";
                    objArray[index29] = (object)str28;
                    int index30 = 35;
                    num = analysisClass.Xlorid;
                    string str29 = num.ToString().Replace(",", ".");
                    objArray[index30] = (object)str29;
                    int index31 = 36;
                    string str30 = ", ";
                    objArray[index31] = (object)str30;
                    int index32 = 37;
                    num = analysisClass.Sulfat;
                    string str31 = num.ToString().Replace(",", ".");
                    objArray[index32] = (object)str31;
                    int index33 = 38;
                    string str32 = ", ";
                    objArray[index33] = (object)str32;
                    int index34 = 39;
                    num = analysisClass.GidroKarbanat;
                    string str33 = num.ToString().Replace(",", ".");
                    objArray[index34] = (object)str33;
                    int index35 = 40;
                    string str34 = ", ";
                    objArray[index35] = (object)str34;
                    int index36 = 41;
                    num = analysisClass.Na;
                    string str35 = num.ToString().Replace(",", ".");
                    objArray[index36] = (object)str35;
                    int index37 = 42;
                    string str36 = ", ";
                    objArray[index37] = (object)str36;
                    int index38 = 43;
                    num = analysisClass.K;
                    string str37 = num.ToString().Replace(",", ".");
                    objArray[index38] = (object)str37;
                    int index39 = 44;
                    string str38 = ", ";
                    objArray[index39] = (object)str38;
                    int index40 = 45;
                    num = analysisClass.Ca;
                    string str39 = num.ToString().Replace(",", ".");
                    objArray[index40] = (object)str39;
                    int index41 = 46;
                    string str40 = ", ";
                    objArray[index41] = (object)str40;
                    int index42 = 47;
                    num = analysisClass.Mg;
                    string str41 = num.ToString().Replace(",", ".");
                    objArray[index42] = (object)str41;
                    int index43 = 48;
                    string str42 = ", ";
                    objArray[index43] = (object)str42;
                    int index44 = 49;
                    num = analysisClass.Mineral;
                    string str43 = num.ToString().Replace(",", ".");
                    objArray[index44] = (object)str43;
                    int index45 = 50;
                    string str44 = ", ";
                    objArray[index45] = (object)str44;
                    int index46 = 51;
                    num = analysisClass.XPK;
                    string str45 = num.ToString().Replace(",", ".");
                    objArray[index46] = (object)str45;
                    int index47 = 52;
                    string str46 = ", ";
                    objArray[index47] = (object)str46;
                    int index48 = 53;
                    num = analysisClass.BPK;
                    string str47 = num.ToString().Replace(",", ".");
                    objArray[index48] = (object)str47;
                    int index49 = 54;
                    string str48 = ", ";
                    objArray[index49] = (object)str48;
                    int index50 = 55;
                    num = analysisClass.AzotAmonniy;
                    string str49 = num.ToString().Replace(",", ".");
                    objArray[index50] = (object)str49;
                    int index51 = 56;
                    string str50 = ", ";
                    objArray[index51] = (object)str50;
                    int index52 = 57;
                    num = analysisClass.AzotNitritniy;
                    string str51 = num.ToString().Replace(",", ".");
                    objArray[index52] = (object)str51;
                    int index53 = 58;
                    string str52 = ", ";
                    objArray[index53] = (object)str52;
                    int index54 = 59;
                    num = analysisClass.AzotNitratniy;
                    string str53 = num.ToString().Replace(",", ".");
                    objArray[index54] = (object)str53;
                    int index55 = 60;
                    string str54 = ", ";
                    objArray[index55] = (object)str54;
                    int index56 = 61;
                    num = analysisClass.AzotSumma;
                    string str55 = num.ToString().Replace(",", ".");
                    objArray[index56] = (object)str55;
                    int index57 = 62;
                    string str56 = ", ";
                    objArray[index57] = (object)str56;
                    int index58 = 63;
                    num = analysisClass.Fosfat;
                    string str57 = num.ToString().Replace(",", ".");
                    objArray[index58] = (object)str57;
                    int index59 = 64;
                    string str58 = ", ";
                    objArray[index59] = (object)str58;
                    int index60 = 65;
                    num = analysisClass.Si;
                    string str59 = num.ToString().Replace(",", ".");
                    objArray[index60] = (object)str59;
                    int index61 = 66;
                    string str60 = ", ";
                    objArray[index61] = (object)str60;
                    int index62 = 67;
                    num = analysisClass.Elektr;
                    string str61 = num.ToString().Replace(",", ".");
                    objArray[index62] = (object)str61;
                    int index63 = 68;
                    string str62 = ", ";
                    objArray[index63] = (object)str62;
                    int index64 = 69;
                    num = analysisClass.Eh_MB;
                    string str63 = num.ToString().Replace(",", ".");
                    objArray[index64] = (object)str63;
                    int index65 = 70;
                    string str64 = ", ";
                    objArray[index65] = (object)str64;
                    int index66 = 71;
                    num = analysisClass.PUmumiy;
                    string str65 = num.ToString().Replace(",", ".");
                    objArray[index66] = (object)str65;
                    int index67 = 72;
                    string str66 = ", ";
                    objArray[index67] = (object)str66;
                    int index68 = 73;
                    num = analysisClass.FeUmumiy;
                    string str67 = num.ToString().Replace(",", ".");
                    objArray[index68] = (object)str67;
                    int index69 = 74;
                    string str68 = ", ";
                    objArray[index69] = (object)str68;
                    int index70 = 75;
                    num = analysisClass.Ci;
                    string str69 = num.ToString().Replace(",", ".");
                    objArray[index70] = (object)str69;
                    int index71 = 76;
                    string str70 = ", ";
                    objArray[index71] = (object)str70;
                    int index72 = 77;
                    num = analysisClass.Zn;
                    string str71 = num.ToString().Replace(",", ".");
                    objArray[index72] = (object)str71;
                    int index73 = 78;
                    string str72 = ", ";
                    objArray[index73] = (object)str72;
                    int index74 = 79;
                    num = analysisClass.Ni;
                    string str73 = num.ToString().Replace(",", ".");
                    objArray[index74] = (object)str73;
                    int index75 = 80;
                    string str74 = ", ";
                    objArray[index75] = (object)str74;
                    int index76 = 81;
                    num = analysisClass.Cr;
                    string str75 = num.ToString().Replace(",", ".");
                    objArray[index76] = (object)str75;
                    int index77 = 82;
                    string str76 = ", ";
                    objArray[index77] = (object)str76;
                    int index78 = 83;
                    num = analysisClass.Cr_VI;
                    string str77 = num.ToString().Replace(",", ".");
                    objArray[index78] = (object)str77;
                    int index79 = 84;
                    string str78 = ", ";
                    objArray[index79] = (object)str78;
                    int index80 = 85;
                    num = analysisClass.Cr_III;
                    string str79 = num.ToString().Replace(",", ".");
                    objArray[index80] = (object)str79;
                    int index81 = 86;
                    string str80 = ", ";
                    objArray[index81] = (object)str80;
                    int index82 = 87;
                    num = analysisClass.Pb;
                    string str81 = num.ToString().Replace(",", ".");
                    objArray[index82] = (object)str81;
                    int index83 = 88;
                    string str82 = ", ";
                    objArray[index83] = (object)str82;
                    int index84 = 89;
                    num = analysisClass.Hg;
                    string str83 = num.ToString().Replace(",", ".");
                    objArray[index84] = (object)str83;
                    int index85 = 90;
                    string str84 = ", ";
                    objArray[index85] = (object)str84;
                    int index86 = 91;
                    num = analysisClass.Cd;
                    string str85 = num.ToString().Replace(",", ".");
                    objArray[index86] = (object)str85;
                    int index87 = 92;
                    string str86 = ", ";
                    objArray[index87] = (object)str86;
                    int index88 = 93;
                    num = analysisClass.Mn;
                    string str87 = num.ToString().Replace(",", ".");
                    objArray[index88] = (object)str87;
                    int index89 = 94;
                    string str88 = ", ";
                    objArray[index89] = (object)str88;
                    int index90 = 95;
                    num = analysisClass.As;
                    string str89 = num.ToString().Replace(",", ".");
                    objArray[index90] = (object)str89;
                    int index91 = 96;
                    string str90 = ", ";
                    objArray[index91] = (object)str90;
                    int index92 = 97;
                    num = analysisClass.Fenollar;
                    string str91 = num.ToString().Replace(",", ".");
                    objArray[index92] = (object)str91;
                    int index93 = 98;
                    string str92 = ", ";
                    objArray[index93] = (object)str92;
                    int index94 = 99;
                    num = analysisClass.Neft;
                    string str93 = num.ToString().Replace(",", ".");
                    objArray[index94] = (object)str93;
                    int index95 = 100;
                    string str94 = ", ";
                    objArray[index95] = (object)str94;
                    int index96 = 101;
                    num = analysisClass.SPAB;
                    string str95 = num.ToString().Replace(",", ".");
                    objArray[index96] = (object)str95;
                    int index97 = 102;
                    string str96 = ", ";
                    objArray[index97] = (object)str96;
                    int index98 = 103;
                    num = analysisClass.F;
                    string str97 = num.ToString().Replace(",", ".");
                    objArray[index98] = (object)str97;
                    int index99 = 104;
                    string str98 = ", ";
                    objArray[index99] = (object)str98;
                    int index100 = 105;
                    num = analysisClass.Sianidi;
                    string str99 = num.ToString().Replace(",", ".");
                    objArray[index100] = (object)str99;
                    int index101 = 106;
                    string str100 = ", ";
                    objArray[index101] = (object)str100;
                    int index102 = 107;
                    num = analysisClass.Proponil;
                    string str101 = num.ToString().Replace(",", ".");
                    objArray[index102] = (object)str101;
                    int index103 = 108;
                    string str102 = ", ";
                    objArray[index103] = (object)str102;
                    int index104 = 109;
                    num = analysisClass.DDE;
                    string str103 = num.ToString().Replace(",", ".");
                    objArray[index104] = (object)str103;
                    int index105 = 110;
                    string str104 = ", ";
                    objArray[index105] = (object)str104;
                    int index106 = 111;
                    num = analysisClass.Rogor;
                    string str105 = num.ToString().Replace(",", ".");
                    objArray[index106] = (object)str105;
                    int index107 = 112;
                    string str106 = ", ";
                    objArray[index107] = (object)str106;
                    int index108 = 113;
                    num = analysisClass.DDT;
                    string str107 = num.ToString().Replace(",", ".");
                    objArray[index108] = (object)str107;
                    int index109 = 114;
                    string str108 = ", ";
                    objArray[index109] = (object)str108;
                    int index110 = 115;
                    num = analysisClass.Geksaxloran;
                    string str109 = num.ToString().Replace(",", ".");
                    objArray[index110] = (object)str109;
                    int index111 = 116;
                    string str110 = ", ";
                    objArray[index111] = (object)str110;
                    int index112 = 117;
                    num = analysisClass.Lindan;
                    string str111 = num.ToString().Replace(",", ".");
                    objArray[index112] = (object)str111;
                    int index113 = 118;
                    string str112 = ", ";
                    objArray[index113] = (object)str112;
                    int index114 = 119;
                    num = analysisClass.DDD;
                    string str113 = num.ToString().Replace(",", ".");
                    objArray[index114] = (object)str113;
                    int index115 = 120;
                    string str114 = ", ";
                    objArray[index115] = (object)str114;
                    int index116 = 121;
                    num = analysisClass.Metafos;
                    string str115 = num.ToString().Replace(",", ".");
                    objArray[index116] = (object)str115;
                    int index117 = 122;
                    string str116 = ", ";
                    objArray[index117] = (object)str116;
                    int index118 = 123;
                    num = analysisClass.Butifos;
                    string str117 = num.ToString().Replace(",", ".");
                    objArray[index118] = (object)str117;
                    int index119 = 124;
                    string str118 = ", ";
                    objArray[index119] = (object)str118;
                    int index120 = 125;
                    num = analysisClass.Dalapon;
                    string str119 = num.ToString().Replace(",", ".");
                    objArray[index120] = (object)str119;
                    int index121 = 126;
                    string str120 = ", ";
                    objArray[index121] = (object)str120;
                    int maxValue = (int)sbyte.MaxValue;
                    num = analysisClass.Karbofos;
                    string str121 = num.ToString().Replace(",", ".");
                    objArray[maxValue] = (object)str121;
                    int index122 = 128;
                    string str122 = ")";
                    objArray[index122] = (object)str122;
                    string str123 = string.Concat(objArray);
                    command.CommandText = str123;
                    this.command.ExecuteNonQuery();
                }
                oleDbTransaction.Commit();
                this.connect.Close();
                int num1 = (int)MessageBox.Show("Данные успешно загружены");
            }
            catch (Exception ex)
            {
                oleDbTransaction.Rollback();
                this.connect.Close();
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        private void mnmainItemExport_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                application.Workbooks.Add((object)Missing.Value);
                _Worksheet worksheet1 = (_Worksheet)(application.Sheets.Add(System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing) as Worksheet);
                this.Cursor = Cursors.WaitCursor;
                string query = "Select *From Analysis ";
                bool flag = false;
                if (this.chbPost.Checked)
                {
                    query = query + " Where Post_Id=" + (this.cbPost.SelectedItem as PostClass).Id.ToString() + " ";
                    flag = true;
                }
                if (this.chbDate.Checked)
                    query = (!flag ? query + " Where " : query + " And ") + " Sana>=#" + this.dtpFrom.Value.ToShortDateString().Replace(".", "/") + "# And Sana<=#" + this.dtpTo.Value.ToShortDateString().Replace(".", "/") + "# ";
                worksheet1.Cells[(object)1, (object)1] = (object)"Экспорт дание";
                Microsoft.Office.Interop.Excel.Range range1 = worksheet1.get_Range((object)"A1", (object)"K1");
                range1.Merge(System.Type.Missing);
                range1.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                range1.Font.Size = (object)14;
                int num1 = 3;
                List<AnalysisClass> analysisList = this.GetAnalysisList(query);
                List<AnalysisClass> analysisClassList = new List<AnalysisClass>();
                int num2 = 0;
                int num3;
                for (int i = 0; i < this.posts.Count; i = num3 + 1)
                {
                    List<AnalysisClass> list = analysisList.Where<AnalysisClass>((Func<AnalysisClass, bool>)(x => x.Post_Id == this.posts[i].Id)).ToList<AnalysisClass>();
                    if (list.Count > 0)
                    {
                        num3 = num2;
                        num2 = num3 + 1;
                        Microsoft.Office.Interop.Excel.Range range2 = worksheet1.get_Range((object)("A" + (object)num1), (object)("M" + (object)num1));
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
                        Microsoft.Office.Interop.Excel.Range range3 = worksheet2.get_Range((object)str1, (object)str4);
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
                        Microsoft.Office.Interop.Excel.Range range4 = worksheet1.get_Range((object)("A" + (object)num1), (object)("M" + (object)num1));
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
                        Microsoft.Office.Interop.Excel.Range range5 = worksheet3.get_Range((object)str5, (object)str8);
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
                            Microsoft.Office.Interop.Excel.Range cells1 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local1 = (System.ValueType)num6;
                            // ISSUE: variable of a boxed type
                            object local2 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells2 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local3 = (System.ValueType)num8;
                            // ISSUE: variable of a boxed type
                            object local4 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells3 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local5 = (System.ValueType)num9;
                            // ISSUE: variable of a boxed type
                            object local6 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells4 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local7 = (System.ValueType)num10;
                            // ISSUE: variable of a boxed type
                            object local8 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells5 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local9 = (System.ValueType)num11;
                            // ISSUE: variable of a boxed type
                            object local10 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells6 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local11 = (System.ValueType)num12;
                            // ISSUE: variable of a boxed type
                            object local12 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells7 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local13 = (System.ValueType)num13;
                            // ISSUE: variable of a boxed type
                            object local14 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells8 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local15 = (System.ValueType)num14;
                            // ISSUE: variable of a boxed type
                            object local16 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells9 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local17 = (System.ValueType)num15;
                            // ISSUE: variable of a boxed type
                            object local18 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells10 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local19 = (System.ValueType)num16;
                            // ISSUE: variable of a boxed type
                            object local20 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells11 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local21 = (System.ValueType)num17;
                            // ISSUE: variable of a boxed type
                            object local22 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells12 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local23 = (System.ValueType)num18;
                            // ISSUE: variable of a boxed type
                            object local24 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells13 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local25 = (System.ValueType)num19;
                            // ISSUE: variable of a boxed type
                            object local26 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells14 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local27 = (System.ValueType)num20;
                            // ISSUE: variable of a boxed type
                            object local28 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells15 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local29 = (System.ValueType)num21;
                            // ISSUE: variable of a boxed type
                            object local30 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells16 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local31 = (System.ValueType)num22;
                            // ISSUE: variable of a boxed type
                            object local32 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells17 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local33 = (System.ValueType)num23;
                            // ISSUE: variable of a boxed type
                            object local34 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells18 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local35 = (System.ValueType)num24;
                            // ISSUE: variable of a boxed type
                            object local36 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells19 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local37 = (System.ValueType)num25;
                            // ISSUE: variable of a boxed type
                            object local38 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells20 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local39 = (System.ValueType)num26;
                            // ISSUE: variable of a boxed type
                            object local40 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells21 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local41 = (System.ValueType)num27;
                            // ISSUE: variable of a boxed type
                            object local42 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells22 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local43 = (System.ValueType)num28;
                            // ISSUE: variable of a boxed type
                            object local44 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells23 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local45 = (System.ValueType)num29;
                            // ISSUE: variable of a boxed type
                            object local46 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells24 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local47 = (System.ValueType)num30;
                            // ISSUE: variable of a boxed type
                            object local48 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells25 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local49 = (System.ValueType)num31;
                            // ISSUE: variable of a boxed type
                            object local50 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells26 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local51 = (System.ValueType)num32;
                            // ISSUE: variable of a boxed type
                            object local52 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells27 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local53 = (System.ValueType)num33;
                            // ISSUE: variable of a boxed type
                            object local54 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells28 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local55 = (System.ValueType)num34;
                            // ISSUE: variable of a boxed type
                            object local56 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells29 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local57 = (System.ValueType)num35;
                            // ISSUE: variable of a boxed type
                            object local58 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells30 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local59 = (System.ValueType)num36;
                            // ISSUE: variable of a boxed type
                            object local60 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells31 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local61 = (System.ValueType)num37;
                            // ISSUE: variable of a boxed type
                            object local62 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells32 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local63 = (System.ValueType)num40;
                            // ISSUE: variable of a boxed type
                            object local64 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells33 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local65 = (System.ValueType)num41;
                            // ISSUE: variable of a boxed type
                            object local66 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells34 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local67 = (System.ValueType)num42;
                            // ISSUE: variable of a boxed type
                            object local68 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells35 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local69 = (System.ValueType)num43;
                            // ISSUE: variable of a boxed type
                            object local70 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells36 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local71 = (System.ValueType)num44;
                            // ISSUE: variable of a boxed type
                            object local72 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells37 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local73 = (System.ValueType)num45;
                            // ISSUE: variable of a boxed type
                            object local74 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells38 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local75 = (System.ValueType)num46;
                            // ISSUE: variable of a boxed type
                            object local76 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells39 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local77 = (System.ValueType)num47;
                            // ISSUE: variable of a boxed type
                            object local78 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells40 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local79 = (System.ValueType)num48;
                            // ISSUE: variable of a boxed type
                            object local80 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells41 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local81 = (System.ValueType)num49;
                            // ISSUE: variable of a boxed type
                            object local82 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells42 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local83 = (System.ValueType)num50;
                            // ISSUE: variable of a boxed type
                            object local84 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells43 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local85 = (System.ValueType)num51;
                            // ISSUE: variable of a boxed type
                            object local86 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells44 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local87 = (System.ValueType)num52;
                            // ISSUE: variable of a boxed type
                            object local88 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells45 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local89 = (System.ValueType)num53;
                            // ISSUE: variable of a boxed type
                            object local90 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells46 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local91 = (System.ValueType)num54;
                            // ISSUE: variable of a boxed type
                            object local92 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells47 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local93 = (System.ValueType)num55;
                            // ISSUE: variable of a boxed type
                            object local94 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells48 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local95 = (System.ValueType)num56;
                            // ISSUE: variable of a boxed type
                            object local96 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells49 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local97 = (System.ValueType)num57;
                            // ISSUE: variable of a boxed type
                            object local98 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells50 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local99 = (System.ValueType)num58;
                            // ISSUE: variable of a boxed type
                            object local100 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells51 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local101 = (System.ValueType)num59;
                            // ISSUE: variable of a boxed type
                            object local102 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells52 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local103 = (System.ValueType)num60;
                            // ISSUE: variable of a boxed type
                            object local104 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells53 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local105 = (System.ValueType)num61;
                            // ISSUE: variable of a boxed type
                            object local106 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells54 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local107 = (System.ValueType)num62;
                            // ISSUE: variable of a boxed type
                            object local108 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells55 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local109 = (System.ValueType)num63;
                            // ISSUE: variable of a boxed type
                            object local110 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells56 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local111 = (System.ValueType)num64;
                            // ISSUE: variable of a boxed type
                            object local112 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells57 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local113 = (System.ValueType)num65;
                            // ISSUE: variable of a boxed type
                            object local114 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells58 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local115 = (System.ValueType)num66;
                            // ISSUE: variable of a boxed type
                            object local116 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells59 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local117 = (System.ValueType)num67;
                            // ISSUE: variable of a boxed type
                            object local118 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells60 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local119 = (System.ValueType)num68;
                            // ISSUE: variable of a boxed type
                            object local120 = (System.ValueType)(index + 2);
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
                            Microsoft.Office.Interop.Excel.Range cells61 = worksheet1.Cells;
                            // ISSUE: variable of a boxed type
                            object local121 = (System.ValueType)num69;
                            // ISSUE: variable of a boxed type
                            object local122 = (System.ValueType)(index + 2);
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
                        Microsoft.Office.Interop.Excel.Range range6 = worksheet4.get_Range((object)str73, (object)str76);
                        range6.Borders.Weight = (object)2;
                        range6.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                        range6.ColumnWidth = (object)11;
                        _Worksheet worksheet5 = worksheet1;
                        string str77 = "A";
                        num3 = num1 - 31;
                        string str78 = num3.ToString();
                        string str79 = str77 + str78;
                        string str80 = str70 + num1.ToString();
                        Microsoft.Office.Interop.Excel.Range range7 = worksheet5.get_Range((object)str79, (object)str80);
                        range7.Borders.Weight = (object)2;
                        range7.HorizontalAlignment = (object)XlHAlign.xlHAlignCenter;
                        range7.ColumnWidth = (object)11;
                        num1 += 2;
                    }
                    Microsoft.Office.Interop.Excel.Range range8 = worksheet1.get_Range((object)"A5", (object)("A" + num1.ToString()));
                    range8.HorizontalAlignment = (object)XlHAlign.xlHAlignLeft;
                    range8.ColumnWidth = (object)30;
                    num3 = i;
                }
                worksheet1.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                application.UserControl = true;
                application.Visible = true;
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion

        #region Hisobotlar Click
        private void mnAccountItemEDK_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = (int)new YearEnterForm().ShowDialog();
                int year = YearEnterForm.Year;
                if ((uint)year <= 0U)
                    return;
                string[] strArray = new string[5]
                {
                    "Select *from Analysis Where Sana>#31/12/",
                    null,
                    null,
                    null,
                    null
                };
                int index1 = 1;
                int num2 = year - 1;
                string str1 = num2.ToString();
                strArray[index1] = str1;
                int index2 = 2;
                string str2 = "# And Sana<#01/01/";
                strArray[index2] = str2;
                int index3 = 3;
                num2 = year + 1;
                string str3 = num2.ToString();
                strArray[index3] = str3;
                int index4 = 4;
                string str4 = "#";
                strArray[index4] = str4;
                int num3 = (int)new HisobotFormEDK(this.GetAnalysisList(string.Concat(strArray)).ToArray(), this.posts, year).ShowDialog();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        private void mnAccoutItemIZV_Click(object sender, EventArgs e)
        {
            int num1 = (int)new YearEnterForm().ShowDialog();
            int year = YearEnterForm.Year;
            if ((uint)year <= 0U)
                return;
            string[] strArray = new string[5]
            {
                "Select *from Analysis Where Sana>#31/12/",
                null,
                null,
                null,
                null
            };
            int index1 = 1;
            int num2 = year - 1;
            string str1 = num2.ToString();
            strArray[index1] = str1;
            int index2 = 2;
            string str2 = "# And Sana<#01/01/";
            strArray[index2] = str2;
            int index3 = 3;
            num2 = year + 1;
            string str3 = num2.ToString();
            strArray[index3] = str3;
            int index4 = 4;
            string str4 = "#";
            strArray[index4] = str4;
            List<AnalysisClass> list = this.GetAnalysisList(string.Concat(strArray));
            List<AnalysisClass> result = new List<AnalysisClass>();
            posts.ForEach(p =>
            {
                List<AnalysisClass> help = list.Where(x => x.Post_Id == p.Id).ToList();
                if (help != null && help.Count > 0)
                {
                    AnalysisClass rr = new AnalysisClass()
                    {
                        Post_Id = p.Id,
                        OqimTezligi = help.Where(x => x.OqimTezligi != -1).Sum(x => x.OqimTezligi) / help.Count,
                        Sigm = help.Where(x => x.Sigm != -1).Sum(x => x.Sigm) / help.Count,
                        DaryoSarfi = help.Where(x => x.DaryoSarfi != -1).Sum(x => x.DaryoSarfi) / help.Count,
                        OqimSarfi = help.Where(x => x.OqimSarfi != -1).Sum(x => x.OqimSarfi) / help.Count,
                        Namlik = help.Where(x => x.Namlik != -1).Sum(x => x.Namlik) / help.Count,
                        Tiniqlik = help.Where(x => x.Tiniqlik != -1).Sum(x => x.Tiniqlik) / help.Count,
                        Rangi = help.Where(x => x.Rangi != -1).Sum(x => x.Rangi) / help.Count,
                        Harorat = help.Where(x => x.Harorat != -1).Sum(x => x.Harorat) / help.Count,
                        Suzuvchi = help.Where(x => x.Suzuvchi != -1).Sum(x => x.Suzuvchi) / help.Count,
                        pH = help.Where(x => x.pH != -1).Sum(x => x.pH) / help.Count,
                        O2 = help.Where(x => x.O2 != -1).Sum(x => x.O2) / help.Count,
                        Tuyingan = help.Where(x => x.Tuyingan != -1).Sum(x => x.Tuyingan) / help.Count,
                        CO2 = help.Where(x => x.CO2 != -1).Sum(x => x.CO2) / help.Count,
                        Qattiqlik = help.Where(x => x.Qattiqlik != -1).Sum(x => x.Qattiqlik) / help.Count,
                        Xlorid = help.Where(x => x.Xlorid != -1).Sum(x => x.Xlorid) / help.Count,
                        Sulfat = help.Where(x => x.Sulfat != -1).Sum(x => x.Sulfat) / help.Count,
                        GidroKarbanat = help.Where(x => x.GidroKarbanat != -1).Sum(x => x.GidroKarbanat) / help.Count,
                        Na = help.Where(x => x.Na != -1).Sum(x => x.Na) / help.Count,
                        K = help.Where(x => x.K != -1).Sum(x => x.K) / help.Count,
                        Ca = help.Where(x => x.Ca != -1).Sum(x => x.Ca) / help.Count,
                        Mg = help.Where(x => x.Mg != -1).Sum(x => x.Mg) / help.Count,
                        Mineral = help.Where(x => x.Mineral != -1).Sum(x => x.Mineral) / help.Count,
                        XPK = help.Where(x => x.XPK != -1).Sum(x => x.XPK) / help.Count,
                        BPK = help.Where(x => x.BPK != -1).Sum(x => x.BPK) / help.Count,
                        AzotAmonniy = help.Where(x => x.AzotAmonniy != -1).Sum(x => x.AzotAmonniy) / help.Count,
                        AzotNitritniy = help.Where(x => x.AzotNitritniy != -1).Sum(x => x.AzotNitritniy) / help.Count,
                        AzotNitratniy = help.Where(x => x.AzotNitratniy != -1).Sum(x => x.AzotNitratniy) / help.Count,
                        AzotSumma = help.Where(x => x.AzotSumma != -1).Sum(x => x.AzotSumma) / help.Count,
                        Fosfat = help.Where(x => x.Fosfat != -1).Sum(x => x.Fosfat) / help.Count,
                        Si = help.Where(x => x.Si != -1).Sum(x => x.Si) / help.Count,
                        Elektr = help.Where(x => x.Elektr != -1).Sum(x => x.Elektr) / help.Count,
                        Eh_MB = help.Where(x => x.Eh_MB != -1).Sum(x => x.Eh_MB) / help.Count,
                        PUmumiy = help.Where(x => x.PUmumiy != -1).Sum(x => x.PUmumiy) / help.Count,
                        FeUmumiy = help.Where(x => x.FeUmumiy != -1).Sum(x => x.FeUmumiy) / help.Count,
                        Ci = help.Where(x => x.Ci != -1).Sum(x => x.Ci) / help.Count,
                        Zn = help.Where(x => x.Zn != -1).Sum(x => x.Zn) / help.Count,
                        Ni = help.Where(x => x.Ni != -1).Sum(x => x.Ni) / help.Count,
                        Cr = help.Where(x => x.Cr != -1).Sum(x => x.Cr) / help.Count,
                        Cr_VI = help.Where(x => x.Cr_VI != -1).Sum(x => x.Cr_VI) / help.Count,
                        Cr_III = help.Where(x => x.Cr_III != -1).Sum(x => x.Cr_III) / help.Count,
                        Pb = help.Where(x => x.Pb != -1).Sum(x => x.Pb) / help.Count,
                        Hg = help.Where(x => x.Hg != -1).Sum(x => x.Hg) / help.Count,
                        Cd = help.Where(x => x.Cd != -1).Sum(x => x.Cd) / help.Count,
                        Mn = help.Where(x => x.Mn != -1).Sum(x => x.Mn) / help.Count,
                        As = help.Where(x => x.As != -1).Sum(x => x.As) / help.Count,
                        Fenollar = help.Where(x => x.Fenollar != -1).Sum(x => x.Fenollar) / help.Count,
                        Neft = help.Where(x => x.Neft != -1).Sum(x => x.Neft) / help.Count,
                        SPAB = help.Where(x => x.SPAB != -1).Sum(x => x.SPAB) / help.Count,
                        F = help.Where(x => x.F != -1).Sum(x => x.F) / help.Count,
                        Sianidi = help.Where(x => x.Sianidi != -1).Sum(x => x.Sianidi) / help.Count,
                        Proponil = help.Where(x => x.Proponil != -1).Sum(x => x.Proponil) / help.Count,
                        DDE = help.Where(x => x.DDE != -1).Sum(x => x.DDE) / help.Count,
                        Rogor = help.Where(x => x.Rogor != -1).Sum(x => x.Rogor) / help.Count,
                        DDT = help.Where(x => x.DDT != -1).Sum(x => x.DDT) / help.Count,
                        Geksaxloran = help.Where(x => x.Geksaxloran != -1).Sum(x => x.Geksaxloran) / help.Count,
                        Lindan = help.Where(x => x.Lindan != -1).Sum(x => x.Lindan) / help.Count,
                        DDD = help.Where(x => x.DDD != -1).Sum(x => x.DDD) / help.Count,
                        Metafos = help.Where(x => x.Metafos != -1).Sum(x => x.Metafos) / help.Count,
                        Butifos = help.Where(x => x.Butifos != -1).Sum(x => x.Butifos) / help.Count,
                        Dalapon = help.Where(x => x.Dalapon != -1).Sum(x => x.Dalapon) / help.Count,
                        Karbofos = help.Where(x => x.Karbofos != -1).Sum(x => x.Karbofos) / help.Count,
                    };
                    result.Add(rr);
                }
            });
            
            int num3 = (int)new HisobotFormIZV(result, this.koms, this.rivers, this.posts, year).ShowDialog();
        }

        private void mnAccountItemPDK_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] tfor_pdk;
                YearFormForPDK form = new YearFormForPDK(koms);
                form.ShowDialog();

                int Year = form.Year;
                if (Year <= 0)
                    return;
                tfor_pdk = form.t;
                bool LastYear = form.LastYear;

                string strquery = "Select *From Analysis Where Sana>#31/12/" + (Year - 1).ToString() + "# And Sana<#01/01/" + (Year + 1).ToString() + "#";
                List<AnalysisClass> list = GetAnalysisList(strquery);

                List<HisobotPostPDK> result = new List<HisobotPostPDK>();

                ////MessageBox.Show(list.Count.ToString());

                for (int i = 0; i < posts.Count; i++)
                {
                    List<AnalysisClass> yordamchi = list.Where(x => x.Post_Id == posts[i].Id).ToList();

                    HisobotPostPDK ob = new HisobotPostPDK(koms);
                    ob.post = posts[i].NameObserve + ", " + posts[i].NameObject;

                    if (yordamchi != null && yordamchi.Count > 0)
                    {
                        for (int j = 0; j < yordamchi.Count; j++)
                        {
                            if (tfor_pdk[0] && yordamchi[j].Sigm != -1)
                            {
                                ob.list[0].umumiy++;
                                ob.list[0].ortacha += yordamchi[j].Sigm;
                                if (yordamchi[j].Sigm < ob.list[0].min)
                                {
                                    ob.list[0].min = yordamchi[j].Sigm;
                                }
                                if (yordamchi[j].Sigm > ob.list[0].max)
                                {
                                    ob.list[0].max = yordamchi[j].Sigm;
                                }
                            }

                            if (tfor_pdk[1] && yordamchi[j].OqimTezligi != -1)
                            {
                                ob.list[1].umumiy++;
                                ob.list[1].ortacha += yordamchi[j].OqimTezligi;

                                if (yordamchi[j].OqimTezligi < ob.list[1].min)
                                {
                                    ob.list[1].min = yordamchi[j].OqimTezligi;
                                }
                                if (yordamchi[j].OqimTezligi > ob.list[1].max)
                                {
                                    ob.list[1].max = yordamchi[j].OqimTezligi;
                                }
                            }

                            if (tfor_pdk[2] && yordamchi[j].DaryoSarfi != -1)
                            {
                                ob.list[2].umumiy++;
                                ob.list[2].ortacha += yordamchi[j].DaryoSarfi;
                                if (yordamchi[j].DaryoSarfi < ob.list[2].min)
                                {
                                    ob.list[2].min = yordamchi[j].DaryoSarfi;
                                }
                                if (yordamchi[j].DaryoSarfi > ob.list[2].max)
                                {
                                    ob.list[2].max = yordamchi[j].DaryoSarfi;
                                }
                            }

                            if (tfor_pdk[3] && yordamchi[j].OqimSarfi != -1)
                            {
                                ob.list[3].umumiy++;
                                ob.list[3].ortacha += yordamchi[j].OqimSarfi;
                                if (yordamchi[j].OqimSarfi < ob.list[3].min)
                                {
                                    ob.list[3].min = yordamchi[j].OqimSarfi;
                                }
                                if (yordamchi[j].OqimSarfi > ob.list[3].max)
                                {
                                    ob.list[3].max = yordamchi[j].OqimSarfi;
                                }
                            }

                            if (tfor_pdk[4] && yordamchi[j].Namlik != -1)
                            {
                                ob.list[4].umumiy++;
                                ob.list[4].ortacha += yordamchi[j].Namlik;
                                if (yordamchi[j].Namlik < ob.list[4].min)
                                {
                                    ob.list[4].min = yordamchi[j].Namlik;
                                }
                                if (yordamchi[j].Namlik > ob.list[4].max)
                                {
                                    ob.list[4].max = yordamchi[j].Namlik;
                                }
                            }

                            if (tfor_pdk[5] && yordamchi[j].Tiniqlik != -1)
                            {
                                ob.list[5].umumiy++;
                                ob.list[5].ortacha += yordamchi[j].Tiniqlik;
                                if (yordamchi[j].OqimTezligi < ob.list[5].min)
                                {
                                    ob.list[5].min = yordamchi[j].OqimTezligi;
                                }
                                if (yordamchi[j].OqimTezligi > ob.list[5].max)
                                {
                                    ob.list[5].max = yordamchi[j].OqimTezligi;
                                }
                            }

                            if (tfor_pdk[6] && yordamchi[j].Rangi != -1)
                            {
                                ob.list[6].umumiy++;
                                ob.list[6].ortacha += yordamchi[j].Rangi;
                                if (yordamchi[j].Rangi < ob.list[6].min)
                                {
                                    ob.list[6].min = yordamchi[j].Rangi;
                                }
                                if (yordamchi[j].Rangi > ob.list[6].max)
                                {
                                    ob.list[6].max = yordamchi[j].Rangi;
                                }
                            }

                            if (tfor_pdk[7] && yordamchi[j].Harorat != -1)
                            {
                                ob.list[7].umumiy++;
                                ob.list[7].ortacha += yordamchi[j].Harorat;
                                if (yordamchi[j].Harorat < ob.list[7].min)
                                {
                                    ob.list[7].min = yordamchi[j].Harorat;
                                }
                                if (yordamchi[j].Harorat > ob.list[7].max)
                                {
                                    ob.list[7].max = yordamchi[j].Harorat;
                                }
                            }

                            if (tfor_pdk[8] && yordamchi[j].Suzuvchi != -1)
                            {
                                ob.list[8].umumiy++;
                                ob.list[8].ortacha += yordamchi[j].Suzuvchi;
                                if (yordamchi[j].Suzuvchi < ob.list[8].min)
                                {
                                    ob.list[8].min = yordamchi[j].Suzuvchi;
                                }
                                if (yordamchi[j].Suzuvchi > ob.list[8].max)
                                {
                                    ob.list[8].max = yordamchi[j].Suzuvchi;
                                }
                            }

                            if (tfor_pdk[9] && yordamchi[j].pH != -1)
                            {
                                ob.list[9].umumiy++;
                                ob.list[9].ortacha += yordamchi[j].pH;
                                if (yordamchi[j].pH < ob.list[9].min)
                                {
                                    ob.list[9].min = yordamchi[j].pH;
                                }
                                if (yordamchi[j].pH > ob.list[9].max)
                                {
                                    ob.list[9].max = yordamchi[j].pH;
                                }
                            }

                            if (tfor_pdk[10] && yordamchi[j].O2 != -1)
                            {
                                ob.list[10].umumiy++;
                                ob.list[10].ortacha += yordamchi[j].O2;
                                if (yordamchi[j].O2 < ob.list[10].min)
                                {
                                    ob.list[10].min = yordamchi[j].O2;
                                }
                                if (yordamchi[j].O2 > ob.list[10].max)
                                {
                                    ob.list[10].max = yordamchi[j].O2;
                                }
                            }

                            if (tfor_pdk[11] && yordamchi[j].Tuyingan != -1)
                            {
                                ob.list[11].umumiy++;
                                ob.list[11].ortacha += yordamchi[j].Tuyingan;
                                if (yordamchi[j].Tuyingan < ob.list[11].min)
                                {
                                    ob.list[11].min = yordamchi[j].Tuyingan;
                                }
                                if (yordamchi[j].Tuyingan > ob.list[11].max)
                                {
                                    ob.list[11].max = yordamchi[j].Tuyingan;
                                }
                            }

                            if (tfor_pdk[12] && yordamchi[j].CO2 != -1)
                            {
                                ob.list[12].umumiy++;
                                ob.list[12].ortacha += yordamchi[j].CO2;
                                if (yordamchi[j].CO2 < ob.list[12].min)
                                {
                                    ob.list[12].min = yordamchi[j].CO2;
                                }
                                if (yordamchi[j].CO2 > ob.list[12].max)
                                {
                                    ob.list[12].max = yordamchi[j].CO2;
                                }
                            }

                            if (tfor_pdk[13] && yordamchi[j].Qattiqlik != -1)
                            {
                                ob.list[13].umumiy++;
                                ob.list[13].ortacha += yordamchi[j].Qattiqlik;
                                if (yordamchi[j].Qattiqlik < ob.list[13].min)
                                {
                                    ob.list[13].min = yordamchi[j].Qattiqlik;
                                }
                                if (yordamchi[j].Qattiqlik > ob.list[13].max)
                                {
                                    ob.list[13].max = yordamchi[j].Qattiqlik;
                                }
                            }

                            if (tfor_pdk[14] && yordamchi[j].Xlorid != -1)
                            {
                                ob.list[14].umumiy++;
                                ob.list[14].ortacha += yordamchi[j].Xlorid;
                                if (yordamchi[j].Xlorid < ob.list[14].min)
                                {
                                    ob.list[14].min = yordamchi[j].Xlorid;
                                }
                                if (yordamchi[j].Xlorid > ob.list[14].max)
                                {
                                    ob.list[14].max = yordamchi[j].Xlorid;
                                }
                            }

                            if (tfor_pdk[15] && yordamchi[j].Sulfat != -1)
                            {
                                ob.list[15].umumiy++;
                                ob.list[15].ortacha += yordamchi[j].Sulfat;
                                if (yordamchi[j].Sulfat < ob.list[15].min)
                                {
                                    ob.list[15].min = yordamchi[j].Sulfat;
                                }
                                if (yordamchi[j].Sulfat > ob.list[15].max)
                                {
                                    ob.list[15].max = yordamchi[j].Sulfat;
                                }
                            }

                            if (tfor_pdk[16] && yordamchi[j].GidroKarbanat != -1)
                            {
                                ob.list[16].umumiy++;
                                ob.list[16].ortacha += yordamchi[j].GidroKarbanat;
                                if (yordamchi[j].GidroKarbanat < ob.list[16].min)
                                {
                                    ob.list[16].min = yordamchi[j].GidroKarbanat;
                                }
                                if (yordamchi[j].GidroKarbanat > ob.list[16].max)
                                {
                                    ob.list[16].max = yordamchi[j].GidroKarbanat;
                                }
                            }

                            if (tfor_pdk[17] && yordamchi[j].Na != -1)
                            {
                                ob.list[17].umumiy++;
                                ob.list[17].ortacha += yordamchi[j].Na;
                                if (yordamchi[j].Na < ob.list[17].min)
                                {
                                    ob.list[17].min = yordamchi[j].Na;
                                }
                                if (yordamchi[j].Na > ob.list[17].max)
                                {
                                    ob.list[17].max = yordamchi[j].Na;
                                }
                            }

                            if (tfor_pdk[18] && yordamchi[j].K != -1)
                            {
                                ob.list[18].umumiy++;
                                ob.list[18].ortacha += yordamchi[j].K;
                                if (yordamchi[j].K < ob.list[18].min)
                                {
                                    ob.list[18].min = yordamchi[j].K;
                                }
                                if (yordamchi[j].K > ob.list[18].max)
                                {
                                    ob.list[18].max = yordamchi[j].K;
                                }
                            }

                            if (tfor_pdk[19] && yordamchi[j].Ca != -1)
                            {
                                ob.list[19].umumiy++;
                                ob.list[19].ortacha += yordamchi[j].Ca;
                                if (yordamchi[j].Ca < ob.list[19].min)
                                {
                                    ob.list[19].min = yordamchi[j].Ca;
                                }
                                if (yordamchi[j].Ca > ob.list[19].max)
                                {
                                    ob.list[19].max = yordamchi[j].Ca;
                                }
                            }

                            if (tfor_pdk[20] && yordamchi[j].Mg != -1)
                            {
                                ob.list[20].umumiy++;
                                ob.list[20].ortacha += yordamchi[j].Mg;
                                if (yordamchi[j].Mg < ob.list[20].min)
                                {
                                    ob.list[20].min = yordamchi[j].Mg;
                                }
                                if (yordamchi[j].Mg > ob.list[20].max)
                                {
                                    ob.list[20].max = yordamchi[j].Mg;
                                }
                            }

                            if (tfor_pdk[21] && yordamchi[j].Mineral != -1)
                            {
                                ob.list[21].umumiy++;
                                ob.list[21].ortacha += yordamchi[j].Mineral;
                                if (yordamchi[j].Mineral < ob.list[21].min)
                                {
                                    ob.list[21].min = yordamchi[j].Mineral;
                                }
                                if (yordamchi[j].Mineral > ob.list[21].max)
                                {
                                    ob.list[21].max = yordamchi[j].Mineral;
                                }
                            }

                            if (tfor_pdk[22] && yordamchi[j].XPK != -1)
                            {
                                ob.list[22].umumiy++;
                                ob.list[22].ortacha += yordamchi[j].XPK;
                                if (yordamchi[j].XPK < ob.list[22].min)
                                {
                                    ob.list[22].min = yordamchi[j].XPK;
                                }
                                if (yordamchi[j].XPK > ob.list[22].max)
                                {
                                    ob.list[22].max = yordamchi[j].XPK;
                                }
                            }

                            if (tfor_pdk[23] && yordamchi[j].BPK != -1)
                            {
                                ob.list[23].umumiy++;
                                ob.list[23].ortacha += yordamchi[j].BPK;
                                if (yordamchi[j].BPK < ob.list[23].min)
                                {
                                    ob.list[23].min = yordamchi[j].BPK;
                                }
                                if (yordamchi[j].BPK > ob.list[23].max)
                                {
                                    ob.list[23].max = yordamchi[j].BPK;
                                }
                            }

                            if (tfor_pdk[24] && yordamchi[j].AzotAmonniy != -1)
                            {
                                ob.list[24].umumiy++;
                                ob.list[24].ortacha += yordamchi[j].AzotAmonniy;
                                if (yordamchi[j].AzotAmonniy < ob.list[24].min)
                                {
                                    ob.list[24].min = yordamchi[j].AzotAmonniy;
                                }
                                if (yordamchi[j].AzotAmonniy > ob.list[24].max)
                                {
                                    ob.list[24].max = yordamchi[j].AzotAmonniy;
                                }
                            }

                            if (tfor_pdk[25] && yordamchi[j].AzotNitritniy != -1)
                            {
                                ob.list[25].umumiy++;
                                ob.list[25].ortacha += yordamchi[j].AzotNitritniy;
                                if (yordamchi[j].AzotNitritniy < ob.list[25].min)
                                {
                                    ob.list[25].min = yordamchi[j].AzotNitritniy;
                                }
                                if (yordamchi[j].AzotNitritniy > ob.list[25].max)
                                {
                                    ob.list[25].max = yordamchi[j].AzotNitritniy;
                                }
                            }

                            if (tfor_pdk[26] && yordamchi[j].AzotNitratniy != -1)
                            {
                                ob.list[26].umumiy++;
                                ob.list[26].ortacha += yordamchi[j].AzotNitratniy;
                                if (yordamchi[j].AzotNitratniy < ob.list[26].min)
                                {
                                    ob.list[26].min = yordamchi[j].AzotNitratniy;
                                }
                                if (yordamchi[j].AzotNitratniy > ob.list[26].max)
                                {
                                    ob.list[26].max = yordamchi[j].AzotNitratniy;
                                }
                            }

                            if (tfor_pdk[27] && yordamchi[j].AzotSumma != -1)
                            {
                                ob.list[27].umumiy++;
                                ob.list[27].ortacha += yordamchi[j].AzotSumma;
                                if (yordamchi[j].AzotSumma < ob.list[27].min)
                                {
                                    ob.list[27].min = yordamchi[j].AzotSumma;
                                }
                                if (yordamchi[j].AzotSumma > ob.list[27].max)
                                {
                                    ob.list[27].max = yordamchi[j].AzotSumma;
                                }
                            }

                            if (tfor_pdk[28] && yordamchi[j].Fosfat != -1)
                            {
                                ob.list[28].umumiy++;
                                ob.list[28].ortacha += yordamchi[j].Fosfat;
                                if (yordamchi[j].Fosfat < ob.list[28].min)
                                {
                                    ob.list[28].min = yordamchi[j].Fosfat;
                                }
                                if (yordamchi[j].Fosfat > ob.list[28].max)
                                {
                                    ob.list[28].max = yordamchi[j].Fosfat;
                                }
                            }

                            if (tfor_pdk[29] && yordamchi[j].Si != -1)
                            {
                                ob.list[29].umumiy++;
                                ob.list[29].ortacha += yordamchi[j].Si;
                                if (yordamchi[j].Si < ob.list[29].min)
                                {
                                    ob.list[29].min = yordamchi[j].Si;
                                }
                                if (yordamchi[j].Si > ob.list[29].max)
                                {
                                    ob.list[29].max = yordamchi[j].Si;
                                }
                            }

                            if (tfor_pdk[30] && yordamchi[j].Elektr != -1)
                            {
                                ob.list[30].umumiy++;
                                ob.list[30].ortacha += yordamchi[j].Elektr;
                                if (yordamchi[j].Elektr < ob.list[30].min)
                                {
                                    ob.list[30].min = yordamchi[j].Elektr;
                                }
                                if (yordamchi[j].Elektr > ob.list[30].max)
                                {
                                    ob.list[30].max = yordamchi[j].Elektr;
                                }
                            }

                            if (tfor_pdk[31] && yordamchi[j].Eh_MB != -1)
                            {
                                ob.list[31].umumiy++;
                                ob.list[31].ortacha += yordamchi[j].Eh_MB;
                                if (yordamchi[j].Eh_MB < ob.list[32].min)
                                {
                                    ob.list[32].min = yordamchi[j].Eh_MB;
                                }
                                if (yordamchi[j].Eh_MB > ob.list[32].max)
                                {
                                    ob.list[32].max = yordamchi[j].Eh_MB;
                                }
                            }

                            if (tfor_pdk[32] && yordamchi[j].PUmumiy != -1)
                            {
                                ob.list[32].umumiy++;
                                ob.list[32].ortacha += yordamchi[j].PUmumiy;
                                if (yordamchi[j].PUmumiy < ob.list[32].min)
                                {
                                    ob.list[32].min = yordamchi[j].PUmumiy;
                                }
                                if (yordamchi[j].PUmumiy > ob.list[32].max)
                                {
                                    ob.list[32].max = yordamchi[j].PUmumiy;
                                }
                            }

                            if (tfor_pdk[33] && yordamchi[j].FeUmumiy != -1)
                            {
                                ob.list[33].umumiy++;
                                ob.list[33].ortacha += yordamchi[j].FeUmumiy;
                                if (yordamchi[j].FeUmumiy < ob.list[33].min)
                                {
                                    ob.list[33].min = yordamchi[j].FeUmumiy;
                                }
                                if (yordamchi[j].FeUmumiy > ob.list[1].max)
                                {
                                    ob.list[33].max = yordamchi[j].FeUmumiy;
                                }
                            }

                            if (tfor_pdk[34] && yordamchi[j].Ci != -1)
                            {
                                ob.list[34].umumiy++;
                                ob.list[34].ortacha += yordamchi[j].Ci;
                                if (yordamchi[j].Ci < ob.list[34].min)
                                {
                                    ob.list[34].min = yordamchi[j].Ci;
                                }
                                if (yordamchi[j].Ci > ob.list[34].max)
                                {
                                    ob.list[34].max = yordamchi[j].Ci;
                                }
                            }

                            if (tfor_pdk[35] && yordamchi[j].Zn != -1)
                            {
                                ob.list[35].umumiy++;
                                ob.list[35].ortacha += yordamchi[j].Zn;
                                if (yordamchi[j].Zn < ob.list[35].min)
                                {
                                    ob.list[35].min = yordamchi[j].Zn;
                                }
                                if (yordamchi[j].Zn > ob.list[35].max)
                                {
                                    ob.list[35].max = yordamchi[j].Zn;
                                }
                            }

                            if (tfor_pdk[36] && yordamchi[j].Ni != -1)
                            {
                                ob.list[36].umumiy++;
                                ob.list[36].ortacha += yordamchi[j].Ni;
                                if (yordamchi[j].Ni < ob.list[36].min)
                                {
                                    ob.list[36].min = yordamchi[j].Ni;
                                }
                                if (yordamchi[j].Ni > ob.list[36].max)
                                {
                                    ob.list[36].max = yordamchi[j].Ni;
                                }
                            }

                            if (tfor_pdk[37] && yordamchi[j].Cr != -1)
                            {
                                ob.list[37].umumiy++;
                                ob.list[37].ortacha += yordamchi[j].Cr;
                                if (yordamchi[j].Cr < ob.list[37].min)
                                {
                                    ob.list[37].min = yordamchi[j].Cr;
                                }
                                if (yordamchi[j].Cr > ob.list[37].max)
                                {
                                    ob.list[1].max = yordamchi[j].Cr;
                                }
                            }

                            if (tfor_pdk[38] && yordamchi[j].Cr_VI != -1)
                            {
                                ob.list[38].umumiy++;
                                ob.list[38].ortacha += yordamchi[j].Cr_VI;
                                if (yordamchi[j].Cr_VI < ob.list[38].min)
                                {
                                    ob.list[38].min = yordamchi[j].Cr_VI;
                                }
                                if (yordamchi[j].Cr_VI > ob.list[38].max)
                                {
                                    ob.list[38].max = yordamchi[j].Cr_VI;
                                }
                            }

                            if (tfor_pdk[39] && yordamchi[j].Cr_III != -1)
                            {
                                ob.list[39].umumiy++;
                                ob.list[39].ortacha += yordamchi[j].Cr_III;
                                if (yordamchi[j].Cr_III < ob.list[39].min)
                                {
                                    ob.list[39].min = yordamchi[j].Cr_III;
                                }
                                if (yordamchi[j].Cr_III > ob.list[39].max)
                                {
                                    ob.list[39].max = yordamchi[j].Cr_III;
                                }
                            }

                            if (tfor_pdk[40] && yordamchi[j].Pb != -1)
                            {
                                ob.list[40].umumiy++;
                                ob.list[40].ortacha += yordamchi[j].Pb;
                                if (yordamchi[j].Pb < ob.list[40].min)
                                {
                                    ob.list[40].min = yordamchi[j].Pb;
                                }
                                if (yordamchi[j].Pb > ob.list[40].max)
                                {
                                    ob.list[40].max = yordamchi[j].Pb;
                                }
                            }

                            if (tfor_pdk[41] && yordamchi[j].Hg != -1)
                            {
                                ob.list[41].umumiy++;
                                ob.list[41].ortacha += yordamchi[j].Hg;
                                if (yordamchi[j].Hg < ob.list[41].min)
                                {
                                    ob.list[41].min = yordamchi[j].Hg;
                                }
                                if (yordamchi[j].Hg > ob.list[41].max)
                                {
                                    ob.list[41].max = yordamchi[j].Hg;
                                }
                            }

                            if (tfor_pdk[42] && yordamchi[j].Cd != -1)
                            {
                                ob.list[42].umumiy++;
                                ob.list[42].ortacha += yordamchi[j].Cd;
                                if (yordamchi[j].Cd < ob.list[42].min)
                                {
                                    ob.list[42].min = yordamchi[j].Cd;
                                }
                                if (yordamchi[j].Cd > ob.list[42].max)
                                {
                                    ob.list[42].max = yordamchi[j].Cd;
                                }
                            }

                            if (tfor_pdk[43] && yordamchi[j].Mn != -1)
                            {
                                ob.list[43].umumiy++;
                                ob.list[43].ortacha += yordamchi[j].Mn;
                                if (yordamchi[j].Mn < ob.list[43].min)
                                {
                                    ob.list[43].min = yordamchi[j].Mn;
                                }
                                if (yordamchi[j].Mn > ob.list[43].max)
                                {
                                    ob.list[43].max = yordamchi[j].Mn;
                                }
                            }

                            if (tfor_pdk[44] && yordamchi[j].As != -1)
                            {
                                ob.list[44].umumiy++;
                                ob.list[44].ortacha += yordamchi[j].As;
                                if (yordamchi[j].As < ob.list[44].min)
                                {
                                    ob.list[44].min = yordamchi[j].As;
                                }
                                if (yordamchi[j].As > ob.list[44].max)
                                {
                                    ob.list[44].max = yordamchi[j].As;
                                }
                            }

                            if (tfor_pdk[45] && yordamchi[j].Fenollar != -1)
                            {
                                ob.list[45].umumiy++;
                                ob.list[45].ortacha += yordamchi[j].Fenollar;
                                if (yordamchi[j].Fenollar < ob.list[45].min)
                                {
                                    ob.list[45].min = yordamchi[j].Fenollar;
                                }
                                if (yordamchi[j].Fenollar > ob.list[45].max)
                                {
                                    ob.list[45].max = yordamchi[j].Fenollar;
                                }
                            }

                            if (tfor_pdk[46] && yordamchi[j].Neft != -1)
                            {
                                ob.list[46].umumiy++;
                                ob.list[46].ortacha += yordamchi[j].Neft;
                                if (yordamchi[j].Neft < ob.list[46].min)
                                {
                                    ob.list[46].min = yordamchi[j].Neft;
                                }
                                if (yordamchi[j].Neft > ob.list[46].max)
                                {
                                    ob.list[46].max = yordamchi[j].Neft;
                                }
                            }

                            if (tfor_pdk[47] && yordamchi[j].SPAB != -1)
                            {
                                ob.list[47].umumiy++;
                                ob.list[47].ortacha += yordamchi[j].SPAB;
                                if (yordamchi[j].SPAB < ob.list[47].min)
                                {
                                    ob.list[47].min = yordamchi[j].SPAB;
                                }
                                if (yordamchi[j].SPAB > ob.list[47].max)
                                {
                                    ob.list[47].max = yordamchi[j].SPAB;
                                }
                            }

                            if (tfor_pdk[48] && yordamchi[j].F != -1)
                            {
                                ob.list[48].umumiy++;
                                ob.list[48].ortacha += yordamchi[j].F;
                                if (yordamchi[j].F < ob.list[48].min)
                                {
                                    ob.list[48].min = yordamchi[j].F;
                                }
                                if (yordamchi[j].F > ob.list[48].max)
                                {
                                    ob.list[48].max = yordamchi[j].F;
                                }
                            }

                            if (tfor_pdk[49] && yordamchi[j].Sianidi != -1)
                            {
                                ob.list[49].umumiy++;
                                ob.list[49].ortacha += yordamchi[j].Sianidi;
                                if (yordamchi[j].Sianidi < ob.list[49].min)
                                {
                                    ob.list[49].min = yordamchi[j].Sianidi;
                                }
                                if (yordamchi[j].Sianidi > ob.list[49].max)
                                {
                                    ob.list[49].max = yordamchi[j].Sianidi;
                                }
                            }

                            if (tfor_pdk[50] && yordamchi[j].Proponil != -1)
                            {
                                ob.list[50].umumiy++;
                                ob.list[50].ortacha += yordamchi[j].Proponil;
                                if (yordamchi[j].Proponil < ob.list[50].min)
                                {
                                    ob.list[50].min = yordamchi[j].Proponil;
                                }
                                if (yordamchi[j].Proponil > ob.list[50].max)
                                {
                                    ob.list[50].max = yordamchi[j].Proponil;
                                }
                            }

                            if (tfor_pdk[51] && yordamchi[j].DDE != -1)
                            {
                                ob.list[51].umumiy++;
                                ob.list[51].ortacha += yordamchi[j].DDE;
                                if (yordamchi[j].DDE < ob.list[51].min)
                                {
                                    ob.list[51].min = yordamchi[j].DDE;
                                }
                                if (yordamchi[j].DDE > ob.list[51].max)
                                {
                                    ob.list[51].max = yordamchi[j].DDE;
                                }
                            }

                            if (tfor_pdk[52] && yordamchi[j].Rogor != -1)
                            {
                                ob.list[52].umumiy++;
                                ob.list[52].ortacha += yordamchi[j].Rogor;
                                if (yordamchi[j].Rogor < ob.list[52].min)
                                {
                                    ob.list[52].min = yordamchi[j].Rogor;
                                }
                                if (yordamchi[j].Rogor > ob.list[52].max)
                                {
                                    ob.list[52].max = yordamchi[j].Rogor;
                                }
                            }

                            if (tfor_pdk[53] && yordamchi[j].DDT != -1)
                            {
                                ob.list[53].umumiy++;
                                ob.list[53].ortacha += yordamchi[j].DDT;
                                if (yordamchi[j].DDT < ob.list[53].min)
                                {
                                    ob.list[53].min = yordamchi[j].DDT;
                                }
                                if (yordamchi[j].DDT > ob.list[53].max)
                                {
                                    ob.list[53].max = yordamchi[j].DDT;
                                }
                            }

                            if (tfor_pdk[54] && yordamchi[j].Geksaxloran != -1)
                            {
                                ob.list[54].umumiy++;
                                ob.list[54].ortacha += yordamchi[j].Geksaxloran;
                                if (yordamchi[j].Geksaxloran < ob.list[54].min)
                                {
                                    ob.list[54].min = yordamchi[j].Geksaxloran;
                                }
                                if (yordamchi[j].Geksaxloran > ob.list[54].max)
                                {
                                    ob.list[54].max = yordamchi[j].Geksaxloran;
                                }
                            }

                            if (tfor_pdk[55] && yordamchi[j].Lindan != -1)
                            {
                                ob.list[55].umumiy++;
                                ob.list[55].ortacha += yordamchi[j].Lindan;
                                if (yordamchi[j].Lindan < ob.list[55].min)
                                {
                                    ob.list[55].min = yordamchi[j].Lindan;
                                }
                                if (yordamchi[j].Lindan > ob.list[55].max)
                                {
                                    ob.list[55].max = yordamchi[j].Lindan;
                                }
                            }

                            if (tfor_pdk[56] && yordamchi[j].DDD != -1)
                            {
                                ob.list[56].umumiy++;
                                ob.list[56].ortacha += yordamchi[j].DDD;
                                if (yordamchi[j].DDD < ob.list[56].min)
                                {
                                    ob.list[56].min = yordamchi[j].DDD;
                                }
                                if (yordamchi[j].DDD > ob.list[56].max)
                                {
                                    ob.list[56].max = yordamchi[j].DDD;
                                }
                            }

                            if (tfor_pdk[57] && yordamchi[j].Metafos != -1)
                            {
                                ob.list[57].umumiy++;
                                ob.list[57].ortacha += yordamchi[j].Metafos;
                                if (yordamchi[j].Metafos < ob.list[57].min)
                                {
                                    ob.list[57].min = yordamchi[j].Metafos;
                                }
                                if (yordamchi[j].Metafos > ob.list[57].max)
                                {
                                    ob.list[57].max = yordamchi[j].Metafos;
                                }
                            }

                            if (tfor_pdk[58] && yordamchi[j].Butifos != -1)
                            {
                                ob.list[58].umumiy++;
                                ob.list[58].ortacha += yordamchi[j].Butifos;
                                if (yordamchi[j].Butifos < ob.list[1].min)
                                {
                                    ob.list[58].min = yordamchi[j].Butifos;
                                }
                                if (yordamchi[j].Butifos > ob.list[1].max)
                                {
                                    ob.list[58].max = yordamchi[j].Butifos;
                                }
                            }

                            if (tfor_pdk[59] && yordamchi[j].Dalapon != -1)
                            {
                                ob.list[59].umumiy++;
                                ob.list[59].ortacha += yordamchi[j].Dalapon;
                                if (yordamchi[j].Dalapon < ob.list[59].min)
                                {
                                    ob.list[59].min = yordamchi[j].Dalapon;
                                }
                                if (yordamchi[j].Dalapon > ob.list[59].max)
                                {
                                    ob.list[59].max = yordamchi[j].Dalapon;
                                }
                            }

                            if (tfor_pdk[60] && yordamchi[j].Karbofos != -1)
                            {
                                ob.list[60].umumiy++;
                                ob.list[60].ortacha += yordamchi[j].Karbofos;
                                if (yordamchi[j].Karbofos < ob.list[60].min)
                                {
                                    ob.list[60].min = yordamchi[j].Karbofos;
                                }
                                if (yordamchi[j].Karbofos > ob.list[60].max)
                                {
                                    ob.list[60].max = yordamchi[j].Karbofos;
                                }
                            }
                        }
                    }

                    result.Add(ob);
                }

                if (LastYear)
                {
                    strquery = "Select *From Analysis Where Sana>#31/12/" + (Year - 2).ToString() +
                               "# And Sana<#01/01/" + Year.ToString() + "#";
                    list = GetAnalysisList(strquery);

                    List<HisobotPostPDK> result1 = new List<HisobotPostPDK>();

                    for (int i = 0; i < posts.Count; i++)
                    {
                        List<AnalysisClass> yordamchi = list.Where(x => x.Post_Id == posts[i].Id).ToList();

                        HisobotPostPDK ob = new HisobotPostPDK(koms);
                        ob.post = posts[i].NameObserve + ", " + posts[i].NameObject;

                        if (yordamchi != null && yordamchi.Count > 0)
                        {

                            for (int j = 0; j < yordamchi.Count; j++)
                            {
                                if (tfor_pdk[0] && yordamchi[j].Sigm != -1)
                                {
                                    ob.list[0].umumiy++;
                                    ob.list[0].ortacha += yordamchi[j].Sigm;

                                    if (yordamchi[j].Sigm < ob.list[0].min)
                                    {
                                        ob.list[0].min = yordamchi[j].Sigm;
                                    }
                                    if (yordamchi[j].Sigm > ob.list[0].max)
                                    {
                                        ob.list[0].max = yordamchi[j].Sigm;
                                    }
                                }

                                if (tfor_pdk[1] && yordamchi[j].OqimTezligi != -1)
                                {
                                    ob.list[1].umumiy++;
                                    ob.list[1].ortacha += yordamchi[j].OqimTezligi;

                                    if (yordamchi[j].OqimTezligi < ob.list[1].min)
                                    {
                                        ob.list[1].min = yordamchi[j].OqimTezligi;
                                    }
                                    if (yordamchi[j].OqimTezligi > ob.list[1].max)
                                    {
                                        ob.list[1].max = yordamchi[j].OqimTezligi;
                                    }
                                }

                                if (tfor_pdk[2] && yordamchi[j].DaryoSarfi != -1)
                                {
                                    ob.list[2].umumiy++;
                                    ob.list[2].ortacha += yordamchi[j].DaryoSarfi;
                                    if (yordamchi[j].DaryoSarfi < ob.list[2].min)
                                    {
                                        ob.list[2].min = yordamchi[j].DaryoSarfi;
                                    }
                                    if (yordamchi[j].DaryoSarfi > ob.list[2].max)
                                    {
                                        ob.list[2].max = yordamchi[j].DaryoSarfi;
                                    }
                                }

                                if (tfor_pdk[3] && yordamchi[j].OqimSarfi != -1)
                                {
                                    ob.list[3].umumiy++;
                                    ob.list[3].ortacha += yordamchi[j].OqimSarfi;
                                    if (yordamchi[j].OqimSarfi < ob.list[3].min)
                                    {
                                        ob.list[3].min = yordamchi[j].OqimSarfi;
                                    }
                                    if (yordamchi[j].OqimSarfi > ob.list[3].max)
                                    {
                                        ob.list[3].max = yordamchi[j].OqimSarfi;
                                    }
                                }

                                if (tfor_pdk[4] && yordamchi[j].Namlik != -1)
                                {
                                    ob.list[4].umumiy++;
                                    ob.list[4].ortacha += yordamchi[j].Namlik;
                                    if (yordamchi[j].Namlik < ob.list[4].min)
                                    {
                                        ob.list[4].min = yordamchi[j].Namlik;
                                    }
                                    if (yordamchi[j].Namlik > ob.list[4].max)
                                    {
                                        ob.list[4].max = yordamchi[j].Namlik;
                                    }
                                }

                                if (tfor_pdk[5] && yordamchi[j].Tiniqlik != -1)
                                {
                                    ob.list[5].umumiy++;
                                    ob.list[5].ortacha += yordamchi[j].Tiniqlik;
                                    if (yordamchi[j].OqimTezligi < ob.list[5].min)
                                    {
                                        ob.list[5].min = yordamchi[j].OqimTezligi;
                                    }
                                    if (yordamchi[j].OqimTezligi > ob.list[5].max)
                                    {
                                        ob.list[5].max = yordamchi[j].OqimTezligi;
                                    }
                                }

                                if (tfor_pdk[6] && yordamchi[j].Rangi != -1)
                                {
                                    ob.list[6].umumiy++;
                                    ob.list[6].ortacha += yordamchi[j].Rangi;
                                    if (yordamchi[j].Rangi < ob.list[6].min)
                                    {
                                        ob.list[6].min = yordamchi[j].Rangi;
                                    }
                                    if (yordamchi[j].Rangi > ob.list[6].max)
                                    {
                                        ob.list[6].max = yordamchi[j].Rangi;
                                    }
                                }

                                if (tfor_pdk[7] && yordamchi[j].Harorat != -1)
                                {
                                    ob.list[7].umumiy++;
                                    ob.list[7].ortacha += yordamchi[j].Harorat;
                                    if (yordamchi[j].Harorat < ob.list[7].min)
                                    {
                                        ob.list[7].min = yordamchi[j].Harorat;
                                    }
                                    if (yordamchi[j].Harorat > ob.list[7].max)
                                    {
                                        ob.list[7].max = yordamchi[j].Harorat;
                                    }
                                }

                                if (tfor_pdk[8] && yordamchi[j].Suzuvchi != -1)
                                {
                                    ob.list[8].umumiy++;
                                    ob.list[8].ortacha += yordamchi[j].Suzuvchi;
                                    if (yordamchi[j].Suzuvchi < ob.list[8].min)
                                    {
                                        ob.list[8].min = yordamchi[j].Suzuvchi;
                                    }
                                    if (yordamchi[j].Suzuvchi > ob.list[8].max)
                                    {
                                        ob.list[8].max = yordamchi[j].Suzuvchi;
                                    }
                                }

                                if (tfor_pdk[9] && yordamchi[j].pH != -1)
                                {
                                    ob.list[9].umumiy++;
                                    ob.list[9].ortacha += yordamchi[j].pH;
                                    if (yordamchi[j].pH < ob.list[9].min)
                                    {
                                        ob.list[9].min = yordamchi[j].pH;
                                    }
                                    if (yordamchi[j].pH > ob.list[9].max)
                                    {
                                        ob.list[9].max = yordamchi[j].pH;
                                    }
                                }

                                if (tfor_pdk[10] && yordamchi[j].O2 != -1)
                                {
                                    ob.list[10].umumiy++;
                                    ob.list[10].ortacha += yordamchi[j].O2;
                                    if (yordamchi[j].O2 < ob.list[10].min)
                                    {
                                        ob.list[10].min = yordamchi[j].O2;
                                    }
                                    if (yordamchi[j].O2 > ob.list[10].max)
                                    {
                                        ob.list[10].max = yordamchi[j].O2;
                                    }
                                }

                                if (tfor_pdk[11] && yordamchi[j].Tuyingan != -1)
                                {
                                    ob.list[11].umumiy++;
                                    ob.list[11].ortacha += yordamchi[j].Tuyingan;
                                    if (yordamchi[j].Tuyingan < ob.list[11].min)
                                    {
                                        ob.list[11].min = yordamchi[j].Tuyingan;
                                    }
                                    if (yordamchi[j].Tuyingan > ob.list[11].max)
                                    {
                                        ob.list[11].max = yordamchi[j].Tuyingan;
                                    }
                                }

                                if (tfor_pdk[12] && yordamchi[j].CO2 != -1)
                                {
                                    ob.list[12].umumiy++;
                                    ob.list[12].ortacha += yordamchi[j].CO2;
                                    if (yordamchi[j].CO2 < ob.list[12].min)
                                    {
                                        ob.list[12].min = yordamchi[j].CO2;
                                    }
                                    if (yordamchi[j].CO2 > ob.list[12].max)
                                    {
                                        ob.list[12].max = yordamchi[j].CO2;
                                    }
                                }

                                if (tfor_pdk[13] && yordamchi[j].Qattiqlik != -1)
                                {
                                    ob.list[13].umumiy++;
                                    ob.list[13].ortacha += yordamchi[j].Qattiqlik;
                                    if (yordamchi[j].Qattiqlik < ob.list[13].min)
                                    {
                                        ob.list[13].min = yordamchi[j].Qattiqlik;
                                    }
                                    if (yordamchi[j].Qattiqlik > ob.list[13].max)
                                    {
                                        ob.list[13].max = yordamchi[j].Qattiqlik;
                                    }
                                }

                                if (tfor_pdk[14] && yordamchi[j].Xlorid != -1)
                                {
                                    ob.list[14].umumiy++;
                                    ob.list[14].ortacha += yordamchi[j].Xlorid;
                                    if (yordamchi[j].Xlorid < ob.list[14].min)
                                    {
                                        ob.list[14].min = yordamchi[j].Xlorid;
                                    }
                                    if (yordamchi[j].Xlorid > ob.list[14].max)
                                    {
                                        ob.list[14].max = yordamchi[j].Xlorid;
                                    }
                                }

                                if (tfor_pdk[15] && yordamchi[j].Sulfat != -1)
                                {
                                    ob.list[15].umumiy++;
                                    ob.list[15].ortacha += yordamchi[j].Sulfat;
                                    if (yordamchi[j].Sulfat < ob.list[15].min)
                                    {
                                        ob.list[15].min = yordamchi[j].Sulfat;
                                    }
                                    if (yordamchi[j].Sulfat > ob.list[15].max)
                                    {
                                        ob.list[15].max = yordamchi[j].Sulfat;
                                    }
                                }

                                if (tfor_pdk[16] && yordamchi[j].GidroKarbanat != -1)
                                {
                                    ob.list[16].umumiy++;
                                    ob.list[16].ortacha += yordamchi[j].GidroKarbanat;
                                    if (yordamchi[j].GidroKarbanat < ob.list[16].min)
                                    {
                                        ob.list[16].min = yordamchi[j].GidroKarbanat;
                                    }
                                    if (yordamchi[j].GidroKarbanat > ob.list[16].max)
                                    {
                                        ob.list[16].max = yordamchi[j].GidroKarbanat;
                                    }
                                }

                                if (tfor_pdk[17] && yordamchi[j].Na != -1)
                                {
                                    ob.list[17].umumiy++;
                                    ob.list[17].ortacha += yordamchi[j].Na;
                                    if (yordamchi[j].Na < ob.list[17].min)
                                    {
                                        ob.list[17].min = yordamchi[j].Na;
                                    }
                                    if (yordamchi[j].Na > ob.list[17].max)
                                    {
                                        ob.list[17].max = yordamchi[j].Na;
                                    }
                                }

                                if (tfor_pdk[18] && yordamchi[j].K != -1)
                                {
                                    ob.list[18].umumiy++;
                                    ob.list[18].ortacha += yordamchi[j].K;
                                    if (yordamchi[j].K < ob.list[18].min)
                                    {
                                        ob.list[18].min = yordamchi[j].K;
                                    }
                                    if (yordamchi[j].K > ob.list[18].max)
                                    {
                                        ob.list[18].max = yordamchi[j].K;
                                    }
                                }

                                if (tfor_pdk[19] && yordamchi[j].Ca != -1)
                                {
                                    ob.list[19].umumiy++;
                                    ob.list[19].ortacha += yordamchi[j].Ca;
                                    if (yordamchi[j].Ca < ob.list[19].min)
                                    {
                                        ob.list[19].min = yordamchi[j].Ca;
                                    }
                                    if (yordamchi[j].Ca > ob.list[19].max)
                                    {
                                        ob.list[19].max = yordamchi[j].Ca;
                                    }
                                }

                                if (tfor_pdk[20] && yordamchi[j].Mg != -1)
                                {
                                    ob.list[20].umumiy++;
                                    ob.list[20].ortacha += yordamchi[j].Mg;
                                    if (yordamchi[j].Mg < ob.list[20].min)
                                    {
                                        ob.list[20].min = yordamchi[j].Mg;
                                    }
                                    if (yordamchi[j].Mg > ob.list[20].max)
                                    {
                                        ob.list[20].max = yordamchi[j].Mg;
                                    }
                                }

                                if (tfor_pdk[21] && yordamchi[j].Mineral != -1)
                                {
                                    ob.list[21].umumiy++;
                                    ob.list[21].ortacha += yordamchi[j].Mineral;
                                    if (yordamchi[j].Mineral < ob.list[21].min)
                                    {
                                        ob.list[21].min = yordamchi[j].Mineral;
                                    }
                                    if (yordamchi[j].Mineral > ob.list[21].max)
                                    {
                                        ob.list[21].max = yordamchi[j].Mineral;
                                    }
                                }

                                if (tfor_pdk[22] && yordamchi[j].XPK != -1)
                                {
                                    ob.list[22].umumiy++;
                                    ob.list[22].ortacha += yordamchi[j].XPK;
                                    if (yordamchi[j].XPK < ob.list[22].min)
                                    {
                                        ob.list[22].min = yordamchi[j].XPK;
                                    }
                                    if (yordamchi[j].XPK > ob.list[22].max)
                                    {
                                        ob.list[22].max = yordamchi[j].XPK;
                                    }
                                }

                                if (tfor_pdk[23] && yordamchi[j].BPK != -1)
                                {
                                    ob.list[23].umumiy++;
                                    ob.list[23].ortacha += yordamchi[j].BPK;
                                    if (yordamchi[j].BPK < ob.list[23].min)
                                    {
                                        ob.list[23].min = yordamchi[j].BPK;
                                    }
                                    if (yordamchi[j].BPK > ob.list[23].max)
                                    {
                                        ob.list[23].max = yordamchi[j].BPK;
                                    }
                                }

                                if (tfor_pdk[24] && yordamchi[j].AzotAmonniy != -1)
                                {
                                    ob.list[24].umumiy++;
                                    ob.list[24].ortacha += yordamchi[j].AzotAmonniy;
                                    if (yordamchi[j].AzotAmonniy < ob.list[24].min)
                                    {
                                        ob.list[24].min = yordamchi[j].AzotAmonniy;
                                    }
                                    if (yordamchi[j].AzotAmonniy > ob.list[24].max)
                                    {
                                        ob.list[24].max = yordamchi[j].AzotAmonniy;
                                    }
                                }

                                if (tfor_pdk[25] && yordamchi[j].AzotNitritniy != -1)
                                {
                                    ob.list[25].umumiy++;
                                    ob.list[25].ortacha += yordamchi[j].AzotNitritniy;
                                    if (yordamchi[j].AzotNitritniy < ob.list[25].min)
                                    {
                                        ob.list[25].min = yordamchi[j].AzotNitritniy;
                                    }
                                    if (yordamchi[j].AzotNitritniy > ob.list[25].max)
                                    {
                                        ob.list[25].max = yordamchi[j].AzotNitritniy;
                                    }
                                }

                                if (tfor_pdk[26] && yordamchi[j].AzotNitratniy != -1)
                                {
                                    ob.list[26].umumiy++;
                                    ob.list[26].ortacha += yordamchi[j].AzotNitratniy;
                                    if (yordamchi[j].AzotNitratniy < ob.list[26].min)
                                    {
                                        ob.list[26].min = yordamchi[j].AzotNitratniy;
                                    }
                                    if (yordamchi[j].AzotNitratniy > ob.list[26].max)
                                    {
                                        ob.list[26].max = yordamchi[j].AzotNitratniy;
                                    }
                                }

                                if (tfor_pdk[27] && yordamchi[j].AzotSumma != -1)
                                {
                                    ob.list[27].umumiy++;
                                    ob.list[27].ortacha += yordamchi[j].AzotSumma;
                                    if (yordamchi[j].AzotSumma < ob.list[27].min)
                                    {
                                        ob.list[27].min = yordamchi[j].AzotSumma;
                                    }
                                    if (yordamchi[j].AzotSumma > ob.list[27].max)
                                    {
                                        ob.list[27].max = yordamchi[j].AzotSumma;
                                    }
                                }

                                if (tfor_pdk[28] && yordamchi[j].Fosfat != -1)
                                {
                                    ob.list[28].umumiy++;
                                    ob.list[28].ortacha += yordamchi[j].Fosfat;
                                    if (yordamchi[j].Fosfat < ob.list[28].min)
                                    {
                                        ob.list[28].min = yordamchi[j].Fosfat;
                                    }
                                    if (yordamchi[j].Fosfat > ob.list[28].max)
                                    {
                                        ob.list[28].max = yordamchi[j].Fosfat;
                                    }
                                }

                                if (tfor_pdk[29] && yordamchi[j].Si != -1)
                                {
                                    ob.list[29].umumiy++;
                                    ob.list[29].ortacha += yordamchi[j].Si;
                                    if (yordamchi[j].Si < ob.list[29].min)
                                    {
                                        ob.list[29].min = yordamchi[j].Si;
                                    }
                                    if (yordamchi[j].Si > ob.list[29].max)
                                    {
                                        ob.list[29].max = yordamchi[j].Si;
                                    }
                                }

                                if (tfor_pdk[30] && yordamchi[j].Elektr != -1)
                                {
                                    ob.list[30].umumiy++;
                                    ob.list[30].ortacha += yordamchi[j].Elektr;
                                    if (yordamchi[j].Elektr < ob.list[30].min)
                                    {
                                        ob.list[30].min = yordamchi[j].Elektr;
                                    }
                                    if (yordamchi[j].Elektr > ob.list[30].max)
                                    {
                                        ob.list[30].max = yordamchi[j].Elektr;
                                    }
                                }

                                if (tfor_pdk[31] && yordamchi[j].Eh_MB != -1)
                                {
                                    ob.list[31].umumiy++;
                                    ob.list[31].ortacha += yordamchi[j].Eh_MB;
                                    if (yordamchi[j].Eh_MB < ob.list[32].min)
                                    {
                                        ob.list[32].min = yordamchi[j].Eh_MB;
                                    }
                                    if (yordamchi[j].Eh_MB > ob.list[32].max)
                                    {
                                        ob.list[32].max = yordamchi[j].Eh_MB;
                                    }
                                }

                                if (tfor_pdk[32] && yordamchi[j].PUmumiy != -1)
                                {
                                    ob.list[32].umumiy++;
                                    ob.list[32].ortacha += yordamchi[j].PUmumiy;
                                    if (yordamchi[j].PUmumiy < ob.list[32].min)
                                    {
                                        ob.list[32].min = yordamchi[j].PUmumiy;
                                    }
                                    if (yordamchi[j].PUmumiy > ob.list[32].max)
                                    {
                                        ob.list[32].max = yordamchi[j].PUmumiy;
                                    }
                                }

                                if (tfor_pdk[33] && yordamchi[j].FeUmumiy != -1)
                                {
                                    ob.list[33].umumiy++;
                                    ob.list[33].ortacha += yordamchi[j].FeUmumiy;
                                    if (yordamchi[j].FeUmumiy < ob.list[33].min)
                                    {
                                        ob.list[33].min = yordamchi[j].FeUmumiy;
                                    }
                                    if (yordamchi[j].FeUmumiy > ob.list[1].max)
                                    {
                                        ob.list[33].max = yordamchi[j].FeUmumiy;
                                    }
                                }

                                if (tfor_pdk[34] && yordamchi[j].Ci != -1)
                                {
                                    ob.list[34].umumiy++;
                                    ob.list[34].ortacha += yordamchi[j].Ci;
                                    if (yordamchi[j].Ci < ob.list[34].min)
                                    {
                                        ob.list[34].min = yordamchi[j].Ci;
                                    }
                                    if (yordamchi[j].Ci > ob.list[34].max)
                                    {
                                        ob.list[34].max = yordamchi[j].Ci;
                                    }
                                }

                                if (tfor_pdk[35] && yordamchi[j].Zn != -1)
                                {
                                    ob.list[35].umumiy++;
                                    ob.list[35].ortacha += yordamchi[j].Zn;
                                    if (yordamchi[j].Zn < ob.list[35].min)
                                    {
                                        ob.list[35].min = yordamchi[j].Zn;
                                    }
                                    if (yordamchi[j].Zn > ob.list[35].max)
                                    {
                                        ob.list[35].max = yordamchi[j].Zn;
                                    }
                                }

                                if (tfor_pdk[36] && yordamchi[j].Ni != -1)
                                {
                                    ob.list[36].umumiy++;
                                    ob.list[36].ortacha += yordamchi[j].Ni;
                                    if (yordamchi[j].Ni < ob.list[36].min)
                                    {
                                        ob.list[36].min = yordamchi[j].Ni;
                                    }
                                    if (yordamchi[j].Ni > ob.list[36].max)
                                    {
                                        ob.list[36].max = yordamchi[j].Ni;
                                    }
                                }

                                if (tfor_pdk[37] && yordamchi[j].Cr != -1)
                                {
                                    ob.list[37].umumiy++;
                                    ob.list[37].ortacha += yordamchi[j].Cr;
                                    if (yordamchi[j].Cr < ob.list[37].min)
                                    {
                                        ob.list[37].min = yordamchi[j].Cr;
                                    }
                                    if (yordamchi[j].Cr > ob.list[37].max)
                                    {
                                        ob.list[1].max = yordamchi[j].Cr;
                                    }
                                }

                                if (tfor_pdk[38] && yordamchi[j].Cr_VI != -1)
                                {
                                    ob.list[38].umumiy++;
                                    ob.list[38].ortacha += yordamchi[j].Cr_VI;
                                    if (yordamchi[j].Cr_VI < ob.list[38].min)
                                    {
                                        ob.list[38].min = yordamchi[j].Cr_VI;
                                    }
                                    if (yordamchi[j].Cr_VI > ob.list[38].max)
                                    {
                                        ob.list[38].max = yordamchi[j].Cr_VI;
                                    }
                                }

                                if (tfor_pdk[39] && yordamchi[j].Cr_III != -1)
                                {
                                    ob.list[39].umumiy++;
                                    ob.list[39].ortacha += yordamchi[j].Cr_III;
                                    if (yordamchi[j].Cr_III < ob.list[39].min)
                                    {
                                        ob.list[39].min = yordamchi[j].Cr_III;
                                    }
                                    if (yordamchi[j].Cr_III > ob.list[39].max)
                                    {
                                        ob.list[39].max = yordamchi[j].Cr_III;
                                    }
                                }

                                if (tfor_pdk[40] && yordamchi[j].Pb != -1)
                                {
                                    ob.list[40].umumiy++;
                                    ob.list[40].ortacha += yordamchi[j].Pb;
                                    if (yordamchi[j].Pb < ob.list[40].min)
                                    {
                                        ob.list[40].min = yordamchi[j].Pb;
                                    }
                                    if (yordamchi[j].Pb > ob.list[40].max)
                                    {
                                        ob.list[40].max = yordamchi[j].Pb;
                                    }
                                }

                                if (tfor_pdk[41] && yordamchi[j].Hg != -1)
                                {
                                    ob.list[41].umumiy++;
                                    ob.list[41].ortacha += yordamchi[j].Hg;
                                    if (yordamchi[j].Hg < ob.list[41].min)
                                    {
                                        ob.list[41].min = yordamchi[j].Hg;
                                    }
                                    if (yordamchi[j].Hg > ob.list[41].max)
                                    {
                                        ob.list[41].max = yordamchi[j].Hg;
                                    }
                                }

                                if (tfor_pdk[42] && yordamchi[j].Cd != -1)
                                {
                                    ob.list[42].umumiy++;
                                    ob.list[42].ortacha += yordamchi[j].Cd;
                                    if (yordamchi[j].Cd < ob.list[42].min)
                                    {
                                        ob.list[42].min = yordamchi[j].Cd;
                                    }
                                    if (yordamchi[j].Cd > ob.list[42].max)
                                    {
                                        ob.list[42].max = yordamchi[j].Cd;
                                    }
                                }

                                if (tfor_pdk[43] && yordamchi[j].Mn != -1)
                                {
                                    ob.list[43].umumiy++;
                                    ob.list[43].ortacha += yordamchi[j].Mn;
                                    if (yordamchi[j].Mn < ob.list[43].min)
                                    {
                                        ob.list[43].min = yordamchi[j].Mn;
                                    }
                                    if (yordamchi[j].Mn > ob.list[43].max)
                                    {
                                        ob.list[43].max = yordamchi[j].Mn;
                                    }
                                }

                                if (tfor_pdk[44] && yordamchi[j].As != -1)
                                {
                                    ob.list[44].umumiy++;
                                    ob.list[44].ortacha += yordamchi[j].As;
                                    if (yordamchi[j].As < ob.list[44].min)
                                    {
                                        ob.list[44].min = yordamchi[j].As;
                                    }
                                    if (yordamchi[j].As > ob.list[44].max)
                                    {
                                        ob.list[44].max = yordamchi[j].As;
                                    }
                                }

                                if (tfor_pdk[45] && yordamchi[j].Fenollar != -1)
                                {
                                    ob.list[45].umumiy++;
                                    ob.list[45].ortacha += yordamchi[j].Fenollar;
                                    if (yordamchi[j].Fenollar < ob.list[45].min)
                                    {
                                        ob.list[45].min = yordamchi[j].Fenollar;
                                    }
                                    if (yordamchi[j].Fenollar > ob.list[45].max)
                                    {
                                        ob.list[45].max = yordamchi[j].Fenollar;
                                    }
                                }

                                if (tfor_pdk[46] && yordamchi[j].Neft != -1)
                                {
                                    ob.list[46].umumiy++;
                                    ob.list[46].ortacha += yordamchi[j].Neft;
                                    if (yordamchi[j].Neft < ob.list[46].min)
                                    {
                                        ob.list[46].min = yordamchi[j].Neft;
                                    }
                                    if (yordamchi[j].Neft > ob.list[46].max)
                                    {
                                        ob.list[46].max = yordamchi[j].Neft;
                                    }
                                }

                                if (tfor_pdk[47] && yordamchi[j].SPAB != -1)
                                {
                                    ob.list[47].umumiy++;
                                    ob.list[47].ortacha += yordamchi[j].SPAB;
                                    if (yordamchi[j].SPAB < ob.list[47].min)
                                    {
                                        ob.list[47].min = yordamchi[j].SPAB;
                                    }
                                    if (yordamchi[j].SPAB > ob.list[47].max)
                                    {
                                        ob.list[47].max = yordamchi[j].SPAB;
                                    }
                                }

                                if (tfor_pdk[48] && yordamchi[j].F != -1)
                                {
                                    ob.list[48].umumiy++;
                                    ob.list[48].ortacha += yordamchi[j].F;
                                    if (yordamchi[j].F < ob.list[48].min)
                                    {
                                        ob.list[48].min = yordamchi[j].F;
                                    }
                                    if (yordamchi[j].F > ob.list[48].max)
                                    {
                                        ob.list[48].max = yordamchi[j].F;
                                    }
                                }

                                if (tfor_pdk[49] && yordamchi[j].Sianidi != -1)
                                {
                                    ob.list[49].umumiy++;
                                    ob.list[49].ortacha += yordamchi[j].Sianidi;
                                    if (yordamchi[j].Sianidi < ob.list[49].min)
                                    {
                                        ob.list[49].min = yordamchi[j].Sianidi;
                                    }
                                    if (yordamchi[j].Sianidi > ob.list[49].max)
                                    {
                                        ob.list[49].max = yordamchi[j].Sianidi;
                                    }
                                }

                                if (tfor_pdk[50] && yordamchi[j].Proponil != -1)
                                {
                                    ob.list[50].umumiy++;
                                    ob.list[50].ortacha += yordamchi[j].Proponil;
                                    if (yordamchi[j].Proponil < ob.list[50].min)
                                    {
                                        ob.list[50].min = yordamchi[j].Proponil;
                                    }
                                    if (yordamchi[j].Proponil > ob.list[50].max)
                                    {
                                        ob.list[50].max = yordamchi[j].Proponil;
                                    }
                                }

                                if (tfor_pdk[51] && yordamchi[j].DDE != -1)
                                {
                                    ob.list[51].umumiy++;
                                    ob.list[51].ortacha += yordamchi[j].DDE;
                                    if (yordamchi[j].DDE < ob.list[51].min)
                                    {
                                        ob.list[51].min = yordamchi[j].DDE;
                                    }
                                    if (yordamchi[j].DDE > ob.list[51].max)
                                    {
                                        ob.list[51].max = yordamchi[j].DDE;
                                    }
                                }

                                if (tfor_pdk[52] && yordamchi[j].Rogor != -1)
                                {
                                    ob.list[52].umumiy++;
                                    ob.list[52].ortacha += yordamchi[j].Rogor;
                                    if (yordamchi[j].Rogor < ob.list[52].min)
                                    {
                                        ob.list[52].min = yordamchi[j].Rogor;
                                    }
                                    if (yordamchi[j].Rogor > ob.list[52].max)
                                    {
                                        ob.list[52].max = yordamchi[j].Rogor;
                                    }
                                }

                                if (tfor_pdk[53] && yordamchi[j].DDT != -1)
                                {
                                    ob.list[53].umumiy++;
                                    ob.list[53].ortacha += yordamchi[j].DDT;
                                    if (yordamchi[j].DDT < ob.list[53].min)
                                    {
                                        ob.list[53].min = yordamchi[j].DDT;
                                    }
                                    if (yordamchi[j].DDT > ob.list[53].max)
                                    {
                                        ob.list[53].max = yordamchi[j].DDT;
                                    }
                                }

                                if (tfor_pdk[54] && yordamchi[j].Geksaxloran != -1)
                                {
                                    ob.list[54].umumiy++;
                                    ob.list[54].ortacha += yordamchi[j].Geksaxloran;
                                    if (yordamchi[j].Geksaxloran < ob.list[54].min)
                                    {
                                        ob.list[54].min = yordamchi[j].Geksaxloran;
                                    }
                                    if (yordamchi[j].Geksaxloran > ob.list[54].max)
                                    {
                                        ob.list[54].max = yordamchi[j].Geksaxloran;
                                    }
                                }

                                if (tfor_pdk[55] && yordamchi[j].Lindan != -1)
                                {
                                    ob.list[55].umumiy++;
                                    ob.list[55].ortacha += yordamchi[j].Lindan;
                                    if (yordamchi[j].Lindan < ob.list[55].min)
                                    {
                                        ob.list[55].min = yordamchi[j].Lindan;
                                    }
                                    if (yordamchi[j].Lindan > ob.list[55].max)
                                    {
                                        ob.list[55].max = yordamchi[j].Lindan;
                                    }
                                }

                                if (tfor_pdk[56] && yordamchi[j].DDD != -1)
                                {
                                    ob.list[56].umumiy++;
                                    ob.list[56].ortacha += yordamchi[j].DDD;
                                    if (yordamchi[j].DDD < ob.list[56].min)
                                    {
                                        ob.list[56].min = yordamchi[j].DDD;
                                    }
                                    if (yordamchi[j].DDD > ob.list[56].max)
                                    {
                                        ob.list[56].max = yordamchi[j].DDD;
                                    }
                                }

                                if (tfor_pdk[57] && yordamchi[j].Metafos != -1)
                                {
                                    ob.list[57].umumiy++;
                                    ob.list[57].ortacha += yordamchi[j].Metafos;
                                    if (yordamchi[j].Metafos < ob.list[57].min)
                                    {
                                        ob.list[57].min = yordamchi[j].Metafos;
                                    }
                                    if (yordamchi[j].Metafos > ob.list[57].max)
                                    {
                                        ob.list[57].max = yordamchi[j].Metafos;
                                    }
                                }

                                if (tfor_pdk[58] && yordamchi[j].Butifos != -1)
                                {
                                    ob.list[58].umumiy++;
                                    ob.list[58].ortacha += yordamchi[j].Butifos;
                                    if (yordamchi[j].Butifos < ob.list[1].min)
                                    {
                                        ob.list[58].min = yordamchi[j].Butifos;
                                    }
                                    if (yordamchi[j].Butifos > ob.list[1].max)
                                    {
                                        ob.list[58].max = yordamchi[j].Butifos;
                                    }
                                }

                                if (tfor_pdk[59] && yordamchi[j].Dalapon != -1)
                                {
                                    ob.list[59].umumiy++;
                                    ob.list[59].ortacha += yordamchi[j].Dalapon;
                                    if (yordamchi[j].Dalapon < ob.list[59].min)
                                    {
                                        ob.list[59].min = yordamchi[j].Dalapon;
                                    }
                                    if (yordamchi[j].Dalapon > ob.list[59].max)
                                    {
                                        ob.list[59].max = yordamchi[j].Dalapon;
                                    }
                                }

                                if (tfor_pdk[60] && yordamchi[j].Karbofos != -1)
                                {
                                    ob.list[60].umumiy++;
                                    ob.list[60].ortacha += yordamchi[j].Karbofos;
                                    if (yordamchi[j].Karbofos < ob.list[60].min)
                                    {
                                        ob.list[60].min = yordamchi[j].Karbofos;
                                    }
                                    if (yordamchi[j].Karbofos > ob.list[60].max)
                                    {
                                        ob.list[60].max = yordamchi[j].Karbofos;
                                    }
                                }
                            }
                        }

                        result1.Add(ob);
                    }

                    HisobotPDKForm form1 = new HisobotPDKForm(result1, result, koms, tfor_pdk, Year, 0);
                    form1.ShowDialog();
                }
                else
                {
                    HisobotPDKForm form1 = new HisobotPDKForm(result, koms, tfor_pdk, Year, 0);
                    form1.ShowDialog();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void mnItemHisobotPDKDolyax_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] tfor_pdk;
                YearFormForPDK form = new YearFormForPDK(koms);
                form.ShowDialog();

                int Year = form.Year;
                if (Year <= 0)
                    return;
                tfor_pdk = form.t;
                bool LastYear = form.LastYear;

                string strquery = "Select *From Analysis Where Sana>#31/12/" + (Year - 1).ToString() + "# And Sana<#01/01/" + (Year + 1).ToString() + "#";
                List<AnalysisClass> list = GetAnalysisList(strquery);
                List<HisobotPostPDK> result = new List<HisobotPostPDK>();
                
                for (int i = 0; i < posts.Count; i++)
                {
                    List<AnalysisClass> yordamchi = list.Where(x => x.Post_Id == posts[i].Id).ToList();
                    HisobotPostPDK ob = new HisobotPostPDK(koms);
                    ob.post = posts[i].NameObserve + ", " + posts[i].NameObject;

                    if (yordamchi != null && yordamchi.Count > 0)
                    {
                        for (int j = 0; j < yordamchi.Count; j++)
                        {
                            if (tfor_pdk[0] && yordamchi[j].Sigm != -1)
                            {
                                ob.list[0].umumiy++;
                                ob.list[0].ortacha += yordamchi[j].Sigm;
                                if (yordamchi[j].Sigm < ob.list[0].min)
                                {
                                    ob.list[0].min = yordamchi[j].Sigm;
                                }
                                if (yordamchi[j].Sigm > ob.list[0].max)
                                {
                                    ob.list[0].max = yordamchi[j].Sigm;
                                }
                            }

                            if (tfor_pdk[1] && yordamchi[j].OqimTezligi != -1)
                            {
                                ob.list[1].umumiy++;
                                ob.list[1].ortacha += yordamchi[j].OqimTezligi;

                                if (yordamchi[j].OqimTezligi < ob.list[1].min)
                                {
                                    ob.list[1].min = yordamchi[j].OqimTezligi;
                                }
                                if (yordamchi[j].OqimTezligi > ob.list[1].max)
                                {
                                    ob.list[1].max = yordamchi[j].OqimTezligi;
                                }
                            }

                            if (tfor_pdk[2] && yordamchi[j].DaryoSarfi != -1)
                            {
                                ob.list[2].umumiy++;
                                ob.list[2].ortacha += yordamchi[j].DaryoSarfi;
                                if (yordamchi[j].DaryoSarfi < ob.list[2].min)
                                {
                                    ob.list[2].min = yordamchi[j].DaryoSarfi;
                                }
                                if (yordamchi[j].DaryoSarfi > ob.list[2].max)
                                {
                                    ob.list[2].max = yordamchi[j].DaryoSarfi;
                                }
                            }

                            if (tfor_pdk[3] && yordamchi[j].OqimSarfi != -1)
                            {
                                ob.list[3].umumiy++;
                                ob.list[3].ortacha += yordamchi[j].OqimSarfi;
                                if (yordamchi[j].OqimSarfi < ob.list[3].min)
                                {
                                    ob.list[3].min = yordamchi[j].OqimSarfi;
                                }
                                if (yordamchi[j].OqimSarfi > ob.list[3].max)
                                {
                                    ob.list[3].max = yordamchi[j].OqimSarfi;
                                }
                            }

                            if (tfor_pdk[4] && yordamchi[j].Namlik != -1)
                            {
                                ob.list[4].umumiy++;
                                ob.list[4].ortacha += yordamchi[j].Namlik;
                                if (yordamchi[j].Namlik < ob.list[4].min)
                                {
                                    ob.list[4].min = yordamchi[j].Namlik;
                                }
                                if (yordamchi[j].Namlik > ob.list[4].max)
                                {
                                    ob.list[4].max = yordamchi[j].Namlik;
                                }
                            }

                            if (tfor_pdk[5] && yordamchi[j].Tiniqlik != -1)
                            {
                                ob.list[5].umumiy++;
                                ob.list[5].ortacha += yordamchi[j].Tiniqlik;
                                if (yordamchi[j].OqimTezligi < ob.list[5].min)
                                {
                                    ob.list[5].min = yordamchi[j].OqimTezligi;
                                }
                                if (yordamchi[j].OqimTezligi > ob.list[5].max)
                                {
                                    ob.list[5].max = yordamchi[j].OqimTezligi;
                                }
                            }

                            if (tfor_pdk[6] && yordamchi[j].Rangi != -1)
                            {
                                ob.list[6].umumiy++;
                                ob.list[6].ortacha += yordamchi[j].Rangi;
                                if (yordamchi[j].Rangi < ob.list[6].min)
                                {
                                    ob.list[6].min = yordamchi[j].Rangi;
                                }
                                if (yordamchi[j].Rangi > ob.list[6].max)
                                {
                                    ob.list[6].max = yordamchi[j].Rangi;
                                }
                            }

                            if (tfor_pdk[7] && yordamchi[j].Harorat != -1)
                            {
                                ob.list[7].umumiy++;
                                ob.list[7].ortacha += yordamchi[j].Harorat;
                                if (yordamchi[j].Harorat < ob.list[7].min)
                                {
                                    ob.list[7].min = yordamchi[j].Harorat;
                                }
                                if (yordamchi[j].Harorat > ob.list[7].max)
                                {
                                    ob.list[7].max = yordamchi[j].Harorat;
                                }
                            }

                            if (tfor_pdk[8] && yordamchi[j].Suzuvchi != -1)
                            {
                                ob.list[8].umumiy++;
                                ob.list[8].ortacha += yordamchi[j].Suzuvchi;
                                if (yordamchi[j].Suzuvchi < ob.list[8].min)
                                {
                                    ob.list[8].min = yordamchi[j].Suzuvchi;
                                }
                                if (yordamchi[j].Suzuvchi > ob.list[8].max)
                                {
                                    ob.list[8].max = yordamchi[j].Suzuvchi;
                                }
                            }

                            if (tfor_pdk[9] && yordamchi[j].pH != -1)
                            {
                                ob.list[9].umumiy++;
                                yordamchi[j].pH /= koms[9].PDK;
                                ob.list[9].ortacha += yordamchi[j].pH;
                                if (yordamchi[j].pH < ob.list[9].min)
                                {
                                    ob.list[9].min = yordamchi[j].pH;
                                }
                                if (yordamchi[j].pH > ob.list[9].max)
                                {
                                    ob.list[9].max = yordamchi[j].pH;
                                }
                            }

                            if (tfor_pdk[10] && yordamchi[j].O2 != -1)
                            {
                                ob.list[10].umumiy++;
                                yordamchi[j].O2 /= koms[10].PDK;
                                ob.list[10].ortacha += yordamchi[j].O2;
                                if (yordamchi[j].O2 < ob.list[10].min)
                                {
                                    ob.list[10].min = yordamchi[j].O2;
                                }
                                if (yordamchi[j].O2 > ob.list[10].max)
                                {
                                    ob.list[10].max = yordamchi[j].O2;
                                }
                            }

                            if (tfor_pdk[11] && yordamchi[j].Tuyingan != -1)
                            {
                                ob.list[11].umumiy++;
                                ob.list[11].ortacha += yordamchi[j].Tuyingan;
                                if (yordamchi[j].Tuyingan < ob.list[11].min)
                                {
                                    ob.list[11].min = yordamchi[j].Tuyingan;
                                }
                                if (yordamchi[j].Tuyingan > ob.list[11].max)
                                {
                                    ob.list[11].max = yordamchi[j].Tuyingan;
                                }
                            }

                            if (tfor_pdk[12] && yordamchi[j].CO2 != -1)
                            {
                                ob.list[12].umumiy++;
                                ob.list[12].ortacha += yordamchi[j].CO2;
                                if (yordamchi[j].CO2 < ob.list[12].min)
                                {
                                    ob.list[12].min = yordamchi[j].CO2;
                                }
                                if (yordamchi[j].CO2 > ob.list[12].max)
                                {
                                    ob.list[12].max = yordamchi[j].CO2;
                                }
                            }

                            if (tfor_pdk[13] && yordamchi[j].Qattiqlik != -1)
                            {
                                ob.list[13].umumiy++;
                                yordamchi[j].Qattiqlik /= koms[13].PDK;
                                ob.list[13].ortacha += yordamchi[j].Qattiqlik;
                                if (yordamchi[j].Qattiqlik < ob.list[13].min)
                                {
                                    ob.list[13].min = yordamchi[j].Qattiqlik;
                                }
                                if (yordamchi[j].Qattiqlik > ob.list[13].max)
                                {
                                    ob.list[13].max = yordamchi[j].Qattiqlik;
                                }
                            }

                            if (tfor_pdk[14] && yordamchi[j].Xlorid != -1)
                            {
                                ob.list[14].umumiy++;
                                yordamchi[j].Xlorid /= koms[14].PDK;
                                ob.list[14].ortacha += yordamchi[j].Xlorid;
                                if (yordamchi[j].Xlorid < ob.list[14].min)
                                {
                                    ob.list[14].min = yordamchi[j].Xlorid;
                                }
                                if (yordamchi[j].Xlorid > ob.list[14].max)
                                {
                                    ob.list[14].max = yordamchi[j].Xlorid;
                                }
                            }

                            if (tfor_pdk[15] && yordamchi[j].Sulfat != -1)
                            {
                                ob.list[15].umumiy++;
                                yordamchi[j].Sulfat /= koms[15].PDK;
                                ob.list[15].ortacha += yordamchi[j].Sulfat;
                                if (yordamchi[j].Sulfat < ob.list[15].min)
                                {
                                    ob.list[15].min = yordamchi[j].Sulfat;
                                }
                                if (yordamchi[j].Sulfat > ob.list[15].max)
                                {
                                    ob.list[15].max = yordamchi[j].Sulfat;
                                }
                            }

                            if (tfor_pdk[16] && yordamchi[j].GidroKarbanat != -1)
                            {
                                ob.list[16].umumiy++;
                                ob.list[16].ortacha += yordamchi[j].GidroKarbanat;
                                if (yordamchi[j].GidroKarbanat < ob.list[16].min)
                                {
                                    ob.list[16].min = yordamchi[j].GidroKarbanat;
                                }
                                if (yordamchi[j].GidroKarbanat > ob.list[16].max)
                                {
                                    ob.list[16].max = yordamchi[j].GidroKarbanat;
                                }
                            }

                            if (tfor_pdk[17] && yordamchi[j].Na != -1)
                            {
                                ob.list[17].umumiy++;
                                yordamchi[j].Na /= koms[17].PDK;
                                ob.list[17].ortacha += yordamchi[j].Na;
                                if (yordamchi[j].Na < ob.list[17].min)
                                {
                                    ob.list[17].min = yordamchi[j].Na;
                                }
                                if (yordamchi[j].Na > ob.list[17].max)
                                {
                                    ob.list[17].max = yordamchi[j].Na;
                                }
                            }

                            if (tfor_pdk[18] && yordamchi[j].K != -1)
                            {
                                ob.list[18].umumiy++;
                                yordamchi[j].K /= koms[18].PDK;
                                ob.list[18].ortacha += yordamchi[j].K;
                                if (yordamchi[j].K < ob.list[18].min)
                                {
                                    ob.list[18].min = yordamchi[j].K;
                                }
                                if (yordamchi[j].K > ob.list[18].max)
                                {
                                    ob.list[18].max = yordamchi[j].K;
                                }
                            }

                            if (tfor_pdk[19] && yordamchi[j].Ca != -1)
                            {
                                ob.list[19].umumiy++;
                                yordamchi[j].Ca /= koms[19].PDK;
                                ob.list[19].ortacha += yordamchi[j].Ca;
                                if (yordamchi[j].Ca < ob.list[19].min)
                                {
                                    ob.list[19].min = yordamchi[j].Ca;
                                }
                                if (yordamchi[j].Ca > ob.list[19].max)
                                {
                                    ob.list[19].max = yordamchi[j].Ca;
                                }
                            }

                            if (tfor_pdk[20] && yordamchi[j].Mg != -1)
                            {
                                ob.list[20].umumiy++;
                                yordamchi[j].Mg /= koms[20].PDK;
                                ob.list[20].ortacha += yordamchi[j].Mg;
                                if (yordamchi[j].Mg < ob.list[20].min)
                                {
                                    ob.list[20].min = yordamchi[j].Mg;
                                }
                                if (yordamchi[j].Mg > ob.list[20].max)
                                {
                                    ob.list[20].max = yordamchi[j].Mg;
                                }
                            }

                            if (tfor_pdk[21] && yordamchi[j].Mineral != -1)
                            {
                                ob.list[21].umumiy++;
                                yordamchi[j].Mineral /= koms[21].PDK;
                                ob.list[21].ortacha += yordamchi[j].Mineral;
                                if (yordamchi[j].Mineral < ob.list[21].min)
                                {
                                    ob.list[21].min = yordamchi[j].Mineral;
                                }
                                if (yordamchi[j].Mineral > ob.list[21].max)
                                {
                                    ob.list[21].max = yordamchi[j].Mineral;
                                }
                            }

                            if (tfor_pdk[22] && yordamchi[j].XPK != -1)
                            {
                                ob.list[22].umumiy++;
                                ob.list[22].ortacha += yordamchi[j].XPK;
                                if (yordamchi[j].XPK < ob.list[22].min)
                                {
                                    ob.list[22].min = yordamchi[j].XPK;
                                }
                                if (yordamchi[j].XPK > ob.list[22].max)
                                {
                                    ob.list[22].max = yordamchi[j].XPK;
                                }
                            }

                            if (tfor_pdk[23] && yordamchi[j].BPK != -1)
                            {
                                ob.list[23].umumiy++;
                                yordamchi[j].BPK /= koms[23].PDK;
                                ob.list[23].ortacha += yordamchi[j].BPK;
                                if (yordamchi[j].BPK < ob.list[23].min)
                                {
                                    ob.list[23].min = yordamchi[j].BPK;
                                }
                                if (yordamchi[j].BPK > ob.list[23].max)
                                {
                                    ob.list[23].max = yordamchi[j].BPK;
                                }
                            }

                            if (tfor_pdk[24] && yordamchi[j].AzotAmonniy != -1)
                            {
                                ob.list[24].umumiy++;
                                yordamchi[j].AzotAmonniy /= koms[24].PDK;
                                ob.list[24].ortacha += yordamchi[j].AzotAmonniy;
                                if (yordamchi[j].AzotAmonniy < ob.list[24].min)
                                {
                                    ob.list[24].min = yordamchi[j].AzotAmonniy;
                                }
                                if (yordamchi[j].AzotAmonniy > ob.list[24].max)
                                {
                                    ob.list[24].max = yordamchi[j].AzotAmonniy;
                                }
                            }

                            if (tfor_pdk[25] && yordamchi[j].AzotNitritniy != -1)
                            {
                                ob.list[25].umumiy++;
                                yordamchi[j].AzotNitritniy /= koms[25].PDK;
                                ob.list[25].ortacha += yordamchi[j].AzotNitritniy;
                                if (yordamchi[j].AzotNitritniy < ob.list[25].min)
                                {
                                    ob.list[25].min = yordamchi[j].AzotNitritniy;
                                }
                                if (yordamchi[j].AzotNitritniy > ob.list[25].max)
                                {
                                    ob.list[25].max = yordamchi[j].AzotNitritniy;
                                }
                            }

                            if (tfor_pdk[26] && yordamchi[j].AzotNitratniy != -1)
                            {
                                ob.list[26].umumiy++;
                                yordamchi[j].AzotNitratniy /= koms[26].PDK;
                                ob.list[26].ortacha += yordamchi[j].AzotNitratniy;
                                if (yordamchi[j].AzotNitratniy < ob.list[26].min)
                                {
                                    ob.list[26].min = yordamchi[j].AzotNitratniy;
                                }
                                if (yordamchi[j].AzotNitratniy > ob.list[26].max)
                                {
                                    ob.list[26].max = yordamchi[j].AzotNitratniy;
                                }
                            }

                            if (tfor_pdk[27] && yordamchi[j].AzotSumma != -1)
                            {
                                ob.list[27].umumiy++;
                                ob.list[27].ortacha += yordamchi[j].AzotSumma;
                                if (yordamchi[j].AzotSumma < ob.list[27].min)
                                {
                                    ob.list[27].min = yordamchi[j].AzotSumma;
                                }
                                if (yordamchi[j].AzotSumma > ob.list[27].max)
                                {
                                    ob.list[27].max = yordamchi[j].AzotSumma;
                                }
                            }

                            if (tfor_pdk[28] && yordamchi[j].Fosfat != -1)
                            {
                                ob.list[28].umumiy++;
                                yordamchi[j].Fosfat /= koms[28].PDK;
                                ob.list[28].ortacha += yordamchi[j].Fosfat;
                                if (yordamchi[j].Fosfat < ob.list[28].min)
                                {
                                    ob.list[28].min = yordamchi[j].Fosfat;
                                }
                                if (yordamchi[j].Fosfat > ob.list[28].max)
                                {
                                    ob.list[28].max = yordamchi[j].Fosfat;
                                }
                            }

                            if (tfor_pdk[29] && yordamchi[j].Si != -1)
                            {
                                ob.list[29].umumiy++;
                                ob.list[29].ortacha += yordamchi[j].Si;
                                if (yordamchi[j].Si < ob.list[29].min)
                                {
                                    ob.list[29].min = yordamchi[j].Si;
                                }
                                if (yordamchi[j].Si > ob.list[29].max)
                                {
                                    ob.list[29].max = yordamchi[j].Si;
                                }
                            }

                            if (tfor_pdk[30] && yordamchi[j].Elektr != -1)
                            {
                                ob.list[30].umumiy++;
                                ob.list[30].ortacha += yordamchi[j].Elektr;
                                if (yordamchi[j].Elektr < ob.list[30].min)
                                {
                                    ob.list[30].min = yordamchi[j].Elektr;
                                }
                                if (yordamchi[j].Elektr > ob.list[30].max)
                                {
                                    ob.list[30].max = yordamchi[j].Elektr;
                                }
                            }

                            if (tfor_pdk[31] && yordamchi[j].Eh_MB != -1)
                            {
                                ob.list[31].umumiy++;
                                ob.list[31].ortacha += yordamchi[j].Eh_MB;
                                if (yordamchi[j].Eh_MB < ob.list[32].min)
                                {
                                    ob.list[32].min = yordamchi[j].Eh_MB;
                                }
                                if (yordamchi[j].Eh_MB > ob.list[32].max)
                                {
                                    ob.list[32].max = yordamchi[j].Eh_MB;
                                }
                            }

                            if (tfor_pdk[32] && yordamchi[j].PUmumiy != -1)
                            {
                                ob.list[32].umumiy++;
                                yordamchi[j].PUmumiy /= koms[32].PDK;
                                ob.list[32].ortacha += yordamchi[j].PUmumiy;
                                if (yordamchi[j].PUmumiy < ob.list[32].min)
                                {
                                    ob.list[32].min = yordamchi[j].PUmumiy;
                                }
                                if (yordamchi[j].PUmumiy > ob.list[32].max)
                                {
                                    ob.list[32].max = yordamchi[j].PUmumiy;
                                }
                            }

                            if (tfor_pdk[33] && yordamchi[j].FeUmumiy != -1)
                            {
                                ob.list[33].umumiy++;
                                yordamchi[j].FeUmumiy /= koms[33].PDK;
                                ob.list[33].ortacha += yordamchi[j].FeUmumiy;
                                if (yordamchi[j].FeUmumiy < ob.list[33].min)
                                {
                                    ob.list[33].min = yordamchi[j].FeUmumiy;
                                }
                                if (yordamchi[j].FeUmumiy > ob.list[1].max)
                                {
                                    ob.list[33].max = yordamchi[j].FeUmumiy;
                                }
                            }

                            if (tfor_pdk[34] && yordamchi[j].Ci != -1)
                            {
                                ob.list[34].umumiy++;
                                yordamchi[j].Ci /= koms[34].PDK;
                                ob.list[34].ortacha += yordamchi[j].Ci;
                                if (yordamchi[j].Ci < ob.list[34].min)
                                {
                                    ob.list[34].min = yordamchi[j].Ci;
                                }
                                if (yordamchi[j].Ci > ob.list[34].max)
                                {
                                    ob.list[34].max = yordamchi[j].Ci;
                                }
                            }

                            if (tfor_pdk[35] && yordamchi[j].Zn != -1)
                            {
                                ob.list[35].umumiy++;
                                yordamchi[j].Zn /= koms[35].PDK;
                                ob.list[35].ortacha += yordamchi[j].Zn;
                                if (yordamchi[j].Zn < ob.list[35].min)
                                {
                                    ob.list[35].min = yordamchi[j].Zn;
                                }
                                if (yordamchi[j].Zn > ob.list[35].max)
                                {
                                    ob.list[35].max = yordamchi[j].Zn;
                                }
                            }

                            if (tfor_pdk[36] && yordamchi[j].Ni != -1)
                            {
                                ob.list[36].umumiy++;
                                yordamchi[j].Ni /= koms[36].PDK;
                                ob.list[36].ortacha += yordamchi[j].Ni;
                                if (yordamchi[j].Ni < ob.list[36].min)
                                {
                                    ob.list[36].min = yordamchi[j].Ni;
                                }
                                if (yordamchi[j].Ni > ob.list[36].max)
                                {
                                    ob.list[36].max = yordamchi[j].Ni;
                                }
                            }

                            if (tfor_pdk[37] && yordamchi[j].Cr != -1)
                            {
                                ob.list[37].umumiy++;
                                ob.list[37].ortacha += yordamchi[j].Cr;
                                if (yordamchi[j].Cr < ob.list[37].min)
                                {
                                    ob.list[37].min = yordamchi[j].Cr;
                                }
                                if (yordamchi[j].Cr > ob.list[37].max)
                                {
                                    ob.list[1].max = yordamchi[j].Cr;
                                }
                            }

                            if (tfor_pdk[38] && yordamchi[j].Cr_VI != -1)
                            {
                                ob.list[38].umumiy++;
                                yordamchi[j].Cr_VI /= koms[38].PDK;
                                ob.list[38].ortacha += yordamchi[j].Cr_VI;
                                if (yordamchi[j].Cr_VI < ob.list[38].min)
                                {
                                    ob.list[38].min = yordamchi[j].Cr_VI;
                                }
                                if (yordamchi[j].Cr_VI > ob.list[38].max)
                                {
                                    ob.list[38].max = yordamchi[j].Cr_VI;
                                }
                            }

                            if (tfor_pdk[39] && yordamchi[j].Cr_III != -1)
                            {
                                ob.list[39].umumiy++;
                                ob.list[39].ortacha += yordamchi[j].Cr_III;
                                if (yordamchi[j].Cr_III < ob.list[39].min)
                                {
                                    ob.list[39].min = yordamchi[j].Cr_III;
                                }
                                if (yordamchi[j].Cr_III > ob.list[39].max)
                                {
                                    ob.list[39].max = yordamchi[j].Cr_III;
                                }
                            }

                            if (tfor_pdk[40] && yordamchi[j].Pb != -1)
                            {
                                ob.list[40].umumiy++;
                                yordamchi[j].Pb /= koms[40].PDK;
                                ob.list[40].ortacha += yordamchi[j].Pb;
                                if (yordamchi[j].Pb < ob.list[40].min)
                                {
                                    ob.list[40].min = yordamchi[j].Pb;
                                }
                                if (yordamchi[j].Pb > ob.list[40].max)
                                {
                                    ob.list[40].max = yordamchi[j].Pb;
                                }
                            }

                            if (tfor_pdk[41] && yordamchi[j].Hg != -1)
                            {
                                ob.list[41].umumiy++;
                                yordamchi[j].Hg /= koms[41].PDK;
                                ob.list[41].ortacha += yordamchi[j].Hg;
                                if (yordamchi[j].Hg < ob.list[41].min)
                                {
                                    ob.list[41].min = yordamchi[j].Hg;
                                }
                                if (yordamchi[j].Hg > ob.list[41].max)
                                {
                                    ob.list[41].max = yordamchi[j].Hg;
                                }
                            }

                            if (tfor_pdk[42] && yordamchi[j].Cd != -1)
                            {
                                ob.list[42].umumiy++;
                                yordamchi[j].Cd /= koms[42].PDK;
                                ob.list[42].ortacha += yordamchi[j].Cd;
                                if (yordamchi[j].Cd < ob.list[42].min)
                                {
                                    ob.list[42].min = yordamchi[j].Cd;
                                }
                                if (yordamchi[j].Cd > ob.list[42].max)
                                {
                                    ob.list[42].max = yordamchi[j].Cd;
                                }
                            }

                            if (tfor_pdk[43] && yordamchi[j].Mn != -1)
                            {
                                ob.list[43].umumiy++;
                                ob.list[43].ortacha += yordamchi[j].Mn;
                                if (yordamchi[j].Mn < ob.list[43].min)
                                {
                                    ob.list[43].min = yordamchi[j].Mn;
                                }
                                if (yordamchi[j].Mn > ob.list[43].max)
                                {
                                    ob.list[43].max = yordamchi[j].Mn;
                                }
                            }

                            if (tfor_pdk[44] && yordamchi[j].As != -1)
                            {
                                ob.list[44].umumiy++;
                                yordamchi[j].As /= koms[44].PDK;
                                ob.list[44].ortacha += yordamchi[j].As;
                                if (yordamchi[j].As < ob.list[44].min)
                                {
                                    ob.list[44].min = yordamchi[j].As;
                                }
                                if (yordamchi[j].As > ob.list[44].max)
                                {
                                    ob.list[44].max = yordamchi[j].As;
                                }
                            }

                            if (tfor_pdk[45] && yordamchi[j].Fenollar != -1)
                            {
                                ob.list[45].umumiy++;
                                yordamchi[j].Fenollar /= koms[45].PDK;
                                ob.list[45].ortacha += yordamchi[j].Fenollar;
                                if (yordamchi[j].Fenollar < ob.list[45].min)
                                {
                                    ob.list[45].min = yordamchi[j].Fenollar;
                                }
                                if (yordamchi[j].Fenollar > ob.list[45].max)
                                {
                                    ob.list[45].max = yordamchi[j].Fenollar;
                                }
                            }

                            if (tfor_pdk[46] && yordamchi[j].Neft != -1)
                            {
                                ob.list[46].umumiy++;
                                yordamchi[j].Neft /= koms[46].PDK;
                                ob.list[46].ortacha += yordamchi[j].Neft;
                                if (yordamchi[j].Neft < ob.list[46].min)
                                {
                                    ob.list[46].min = yordamchi[j].Neft;
                                }
                                if (yordamchi[j].Neft > ob.list[46].max)
                                {
                                    ob.list[46].max = yordamchi[j].Neft;
                                }
                            }

                            if (tfor_pdk[47] && yordamchi[j].SPAB != -1)
                            {
                                ob.list[47].umumiy++;
                                yordamchi[j].SPAB /= koms[47].PDK;
                                ob.list[47].ortacha += yordamchi[j].SPAB;
                                if (yordamchi[j].SPAB < ob.list[47].min)
                                {
                                    ob.list[47].min = yordamchi[j].SPAB;
                                }
                                if (yordamchi[j].SPAB > ob.list[47].max)
                                {
                                    ob.list[47].max = yordamchi[j].SPAB;
                                }
                            }

                            if (tfor_pdk[48] && yordamchi[j].F != -1)
                            {
                                ob.list[48].umumiy++;
                                yordamchi[j].F /= koms[48].PDK;
                                ob.list[48].ortacha += yordamchi[j].F;
                                if (yordamchi[j].F < ob.list[48].min)
                                {
                                    ob.list[48].min = yordamchi[j].F;
                                }
                                if (yordamchi[j].F > ob.list[48].max)
                                {
                                    ob.list[48].max = yordamchi[j].F;
                                }
                            }

                            if (tfor_pdk[49] && yordamchi[j].Sianidi != -1)
                            {
                                ob.list[49].umumiy++;
                                yordamchi[j].Sianidi /= koms[49].PDK;
                                ob.list[49].ortacha += yordamchi[j].Sianidi;
                                if (yordamchi[j].Sianidi < ob.list[49].min)
                                {
                                    ob.list[49].min = yordamchi[j].Sianidi;
                                }
                                if (yordamchi[j].Sianidi > ob.list[49].max)
                                {
                                    ob.list[49].max = yordamchi[j].Sianidi;
                                }
                            }

                            if (tfor_pdk[50] && yordamchi[j].Proponil != -1)
                            {
                                ob.list[50].umumiy++;
                                ob.list[50].ortacha += yordamchi[j].Proponil;
                                if (yordamchi[j].Proponil < ob.list[50].min)
                                {
                                    ob.list[50].min = yordamchi[j].Proponil;
                                }
                                if (yordamchi[j].Proponil > ob.list[50].max)
                                {
                                    ob.list[50].max = yordamchi[j].Proponil;
                                }
                            }

                            if (tfor_pdk[51] && yordamchi[j].DDE != -1)
                            {
                                ob.list[51].umumiy++;
                                ob.list[51].ortacha += yordamchi[j].DDE;
                                if (yordamchi[j].DDE < ob.list[51].min)
                                {
                                    ob.list[51].min = yordamchi[j].DDE;
                                }
                                if (yordamchi[j].DDE > ob.list[51].max)
                                {
                                    ob.list[51].max = yordamchi[j].DDE;
                                }
                            }

                            if (tfor_pdk[52] && yordamchi[j].Rogor != -1)
                            {
                                ob.list[52].umumiy++;
                                ob.list[52].ortacha += yordamchi[j].Rogor;
                                if (yordamchi[j].Rogor < ob.list[52].min)
                                {
                                    ob.list[52].min = yordamchi[j].Rogor;
                                }
                                if (yordamchi[j].Rogor > ob.list[52].max)
                                {
                                    ob.list[52].max = yordamchi[j].Rogor;
                                }
                            }

                            if (tfor_pdk[53] && yordamchi[j].DDT != -1)
                            {
                                ob.list[53].umumiy++;
                                yordamchi[j].DDT /= koms[53].PDK;
                                ob.list[53].ortacha += yordamchi[j].DDT;
                                if (yordamchi[j].DDT < ob.list[53].min)
                                {
                                    ob.list[53].min = yordamchi[j].DDT;
                                }
                                if (yordamchi[j].DDT > ob.list[53].max)
                                {
                                    ob.list[53].max = yordamchi[j].DDT;
                                }
                            }

                            if (tfor_pdk[54] && yordamchi[j].Geksaxloran != -1)
                            {
                                ob.list[54].umumiy++;
                                yordamchi[j].Geksaxloran /= koms[54].PDK;
                                ob.list[54].ortacha += yordamchi[j].Geksaxloran;
                                if (yordamchi[j].Geksaxloran < ob.list[54].min)
                                {
                                    ob.list[54].min = yordamchi[j].Geksaxloran;
                                }
                                if (yordamchi[j].Geksaxloran > ob.list[54].max)
                                {
                                    ob.list[54].max = yordamchi[j].Geksaxloran;
                                }
                            }

                            if (tfor_pdk[55] && yordamchi[j].Lindan != -1)
                            {
                                ob.list[55].umumiy++;
                                yordamchi[j].Lindan /= koms[55].PDK;
                                ob.list[55].ortacha += yordamchi[j].Lindan;
                                if (yordamchi[j].Lindan < ob.list[55].min)
                                {
                                    ob.list[55].min = yordamchi[j].Lindan;
                                }
                                if (yordamchi[j].Lindan > ob.list[55].max)
                                {
                                    ob.list[55].max = yordamchi[j].Lindan;
                                }
                            }

                            if (tfor_pdk[56] && yordamchi[j].DDD != -1)
                            {
                                ob.list[56].umumiy++;
                                ob.list[56].ortacha += yordamchi[j].DDD;
                                if (yordamchi[j].DDD < ob.list[56].min)
                                {
                                    ob.list[56].min = yordamchi[j].DDD;
                                }
                                if (yordamchi[j].DDD > ob.list[56].max)
                                {
                                    ob.list[56].max = yordamchi[j].DDD;
                                }
                            }

                            if (tfor_pdk[57] && yordamchi[j].Metafos != -1)
                            {
                                ob.list[57].umumiy++;
                                ob.list[57].ortacha += yordamchi[j].Metafos;
                                if (yordamchi[j].Metafos < ob.list[57].min)
                                {
                                    ob.list[57].min = yordamchi[j].Metafos;
                                }
                                if (yordamchi[j].Metafos > ob.list[57].max)
                                {
                                    ob.list[57].max = yordamchi[j].Metafos;
                                }
                            }

                            if (tfor_pdk[58] && yordamchi[j].Butifos != -1)
                            {
                                ob.list[58].umumiy++;
                                ob.list[58].ortacha += yordamchi[j].Butifos;
                                if (yordamchi[j].Butifos < ob.list[1].min)
                                {
                                    ob.list[58].min = yordamchi[j].Butifos;
                                }
                                if (yordamchi[j].Butifos > ob.list[1].max)
                                {
                                    ob.list[58].max = yordamchi[j].Butifos;
                                }
                            }

                            if (tfor_pdk[59] && yordamchi[j].Dalapon != -1)
                            {
                                ob.list[59].umumiy++;
                                ob.list[59].ortacha += yordamchi[j].Dalapon;
                                if (yordamchi[j].Dalapon < ob.list[59].min)
                                {
                                    ob.list[59].min = yordamchi[j].Dalapon;
                                }
                                if (yordamchi[j].Dalapon > ob.list[59].max)
                                {
                                    ob.list[59].max = yordamchi[j].Dalapon;
                                }
                            }

                            if (tfor_pdk[60] && yordamchi[j].Karbofos != -1)
                            {
                                ob.list[60].umumiy++;
                                ob.list[60].ortacha += yordamchi[j].Karbofos;
                                if (yordamchi[j].Karbofos < ob.list[60].min)
                                {
                                    ob.list[60].min = yordamchi[j].Karbofos;
                                }
                                if (yordamchi[j].Karbofos > ob.list[60].max)
                                {
                                    ob.list[60].max = yordamchi[j].Karbofos;
                                }
                            }
                        }
                    }

                    result.Add(ob);
                }

                if (LastYear)
                {
                    strquery = "Select *From Analysis Where Sana>#31/12/" + (Year - 2).ToString() +
                               "# And Sana<#01/01/" + Year.ToString() + "#";
                    list = GetAnalysisList(strquery);

                    List<HisobotPostPDK> result1 = new List<HisobotPostPDK>();
                    
                    for (int i = 0; i < posts.Count; i++)
                    {
                        List<AnalysisClass> yordamchi = list.Where(x => x.Post_Id == posts[i].Id).ToList();

                        HisobotPostPDK ob = new HisobotPostPDK(koms);
                        ob.post = posts[i].NameObserve + ", " + posts[i].NameObject;
                        if (yordamchi != null && yordamchi.Count > 0)
                        {
                            for (int j = 0; j < yordamchi.Count; j++)
                            {
                                if (tfor_pdk[0] && yordamchi[j].Sigm != -1)
                                {
                                    ob.list[0].umumiy++;
                                    ob.list[0].ortacha += yordamchi[j].Sigm;
                                    if (yordamchi[j].Sigm < ob.list[0].min)
                                    {
                                        ob.list[0].min = yordamchi[j].Sigm;
                                    }
                                    if (yordamchi[j].Sigm > ob.list[0].max)
                                    {
                                        ob.list[0].max = yordamchi[j].Sigm;
                                    }
                                }

                                if (tfor_pdk[1] && yordamchi[j].OqimTezligi != -1)
                                {
                                    ob.list[1].umumiy++;
                                    ob.list[1].ortacha += yordamchi[j].OqimTezligi;

                                    if (yordamchi[j].OqimTezligi < ob.list[1].min)
                                    {
                                        ob.list[1].min = yordamchi[j].OqimTezligi;
                                    }
                                    if (yordamchi[j].OqimTezligi > ob.list[1].max)
                                    {
                                        ob.list[1].max = yordamchi[j].OqimTezligi;
                                    }
                                }

                                if (tfor_pdk[2] && yordamchi[j].DaryoSarfi != -1)
                                {
                                    ob.list[2].umumiy++;
                                    ob.list[2].ortacha += yordamchi[j].DaryoSarfi;
                                    if (yordamchi[j].DaryoSarfi < ob.list[2].min)
                                    {
                                        ob.list[2].min = yordamchi[j].DaryoSarfi;
                                    }
                                    if (yordamchi[j].DaryoSarfi > ob.list[2].max)
                                    {
                                        ob.list[2].max = yordamchi[j].DaryoSarfi;
                                    }
                                }

                                if (tfor_pdk[3] && yordamchi[j].OqimSarfi != -1)
                                {
                                    ob.list[3].umumiy++;
                                    ob.list[3].ortacha += yordamchi[j].OqimSarfi;
                                    if (yordamchi[j].OqimSarfi < ob.list[3].min)
                                    {
                                        ob.list[3].min = yordamchi[j].OqimSarfi;
                                    }
                                    if (yordamchi[j].OqimSarfi > ob.list[3].max)
                                    {
                                        ob.list[3].max = yordamchi[j].OqimSarfi;
                                    }
                                }

                                if (tfor_pdk[4] && yordamchi[j].Namlik != -1)
                                {
                                    ob.list[4].umumiy++;
                                    ob.list[4].ortacha += yordamchi[j].Namlik;
                                    if (yordamchi[j].Namlik < ob.list[4].min)
                                    {
                                        ob.list[4].min = yordamchi[j].Namlik;
                                    }
                                    if (yordamchi[j].Namlik > ob.list[4].max)
                                    {
                                        ob.list[4].max = yordamchi[j].Namlik;
                                    }
                                }

                                if (tfor_pdk[5] && yordamchi[j].Tiniqlik != -1)
                                {
                                    ob.list[5].umumiy++;
                                    ob.list[5].ortacha += yordamchi[j].Tiniqlik;
                                    if (yordamchi[j].OqimTezligi < ob.list[5].min)
                                    {
                                        ob.list[5].min = yordamchi[j].OqimTezligi;
                                    }
                                    if (yordamchi[j].OqimTezligi > ob.list[5].max)
                                    {
                                        ob.list[5].max = yordamchi[j].OqimTezligi;
                                    }
                                }

                                if (tfor_pdk[6] && yordamchi[j].Rangi != -1)
                                {
                                    ob.list[6].umumiy++;
                                    ob.list[6].ortacha += yordamchi[j].Rangi;
                                    if (yordamchi[j].Rangi < ob.list[6].min)
                                    {
                                        ob.list[6].min = yordamchi[j].Rangi;
                                    }
                                    if (yordamchi[j].Rangi > ob.list[6].max)
                                    {
                                        ob.list[6].max = yordamchi[j].Rangi;
                                    }
                                }

                                if (tfor_pdk[7] && yordamchi[j].Harorat != -1)
                                {
                                    ob.list[7].umumiy++;
                                    ob.list[7].ortacha += yordamchi[j].Harorat;
                                    if (yordamchi[j].Harorat < ob.list[7].min)
                                    {
                                        ob.list[7].min = yordamchi[j].Harorat;
                                    }
                                    if (yordamchi[j].Harorat > ob.list[7].max)
                                    {
                                        ob.list[7].max = yordamchi[j].Harorat;
                                    }
                                }

                                if (tfor_pdk[8] && yordamchi[j].Suzuvchi != -1)
                                {
                                    ob.list[8].umumiy++;
                                    ob.list[8].ortacha += yordamchi[j].Suzuvchi;
                                    if (yordamchi[j].Suzuvchi < ob.list[8].min)
                                    {
                                        ob.list[8].min = yordamchi[j].Suzuvchi;
                                    }
                                    if (yordamchi[j].Suzuvchi > ob.list[8].max)
                                    {
                                        ob.list[8].max = yordamchi[j].Suzuvchi;
                                    }
                                }

                                if (tfor_pdk[9] && yordamchi[j].pH != -1)
                                {
                                    ob.list[9].umumiy++;
                                    yordamchi[j].pH /= koms[9].PDK;
                                    ob.list[9].ortacha += yordamchi[j].pH;
                                    if (yordamchi[j].pH < ob.list[9].min)
                                    {
                                        ob.list[9].min = yordamchi[j].pH;
                                    }
                                    if (yordamchi[j].pH > ob.list[9].max)
                                    {
                                        ob.list[9].max = yordamchi[j].pH;
                                    }
                                }

                                if (tfor_pdk[10] && yordamchi[j].O2 != -1)
                                {
                                    ob.list[10].umumiy++;
                                    yordamchi[j].O2 /= koms[10].PDK;
                                    ob.list[10].ortacha += yordamchi[j].O2;
                                    if (yordamchi[j].O2 < ob.list[10].min)
                                    {
                                        ob.list[10].min = yordamchi[j].O2;
                                    }
                                    if (yordamchi[j].O2 > ob.list[10].max)
                                    {
                                        ob.list[10].max = yordamchi[j].O2;
                                    }
                                }

                                if (tfor_pdk[11] && yordamchi[j].Tuyingan != -1)
                                {
                                    ob.list[11].umumiy++;
                                    ob.list[11].ortacha += yordamchi[j].Tuyingan;
                                    if (yordamchi[j].Tuyingan < ob.list[11].min)
                                    {
                                        ob.list[11].min = yordamchi[j].Tuyingan;
                                    }
                                    if (yordamchi[j].Tuyingan > ob.list[11].max)
                                    {
                                        ob.list[11].max = yordamchi[j].Tuyingan;
                                    }
                                }

                                if (tfor_pdk[12] && yordamchi[j].CO2 != -1)
                                {
                                    ob.list[12].umumiy++;
                                    ob.list[12].ortacha += yordamchi[j].CO2;
                                    if (yordamchi[j].CO2 < ob.list[12].min)
                                    {
                                        ob.list[12].min = yordamchi[j].CO2;
                                    }
                                    if (yordamchi[j].CO2 > ob.list[12].max)
                                    {
                                        ob.list[12].max = yordamchi[j].CO2;
                                    }
                                }

                                if (tfor_pdk[13] && yordamchi[j].Qattiqlik != -1)
                                {
                                    ob.list[13].umumiy++;
                                    yordamchi[j].Qattiqlik /= koms[13].PDK;
                                    ob.list[13].ortacha += yordamchi[j].Qattiqlik;
                                    if (yordamchi[j].Qattiqlik < ob.list[13].min)
                                    {
                                        ob.list[13].min = yordamchi[j].Qattiqlik;
                                    }
                                    if (yordamchi[j].Qattiqlik > ob.list[13].max)
                                    {
                                        ob.list[13].max = yordamchi[j].Qattiqlik;
                                    }
                                }

                                if (tfor_pdk[14] && yordamchi[j].Xlorid != -1)
                                {
                                    ob.list[14].umumiy++;
                                    yordamchi[j].Xlorid /= koms[14].PDK;
                                    ob.list[14].ortacha += yordamchi[j].Xlorid;
                                    if (yordamchi[j].Xlorid < ob.list[14].min)
                                    {
                                        ob.list[14].min = yordamchi[j].Xlorid;
                                    }
                                    if (yordamchi[j].Xlorid > ob.list[14].max)
                                    {
                                        ob.list[14].max = yordamchi[j].Xlorid;
                                    }
                                }

                                if (tfor_pdk[15] && yordamchi[j].Sulfat != -1)
                                {
                                    ob.list[15].umumiy++;
                                    yordamchi[j].Sulfat /= koms[15].PDK;
                                    ob.list[15].ortacha += yordamchi[j].Sulfat;
                                    if (yordamchi[j].Sulfat < ob.list[15].min)
                                    {
                                        ob.list[15].min = yordamchi[j].Sulfat;
                                    }
                                    if (yordamchi[j].Sulfat > ob.list[15].max)
                                    {
                                        ob.list[15].max = yordamchi[j].Sulfat;
                                    }
                                }

                                if (tfor_pdk[16] && yordamchi[j].GidroKarbanat != -1)
                                {
                                    ob.list[16].umumiy++;
                                    ob.list[16].ortacha += yordamchi[j].GidroKarbanat;
                                    if (yordamchi[j].GidroKarbanat < ob.list[16].min)
                                    {
                                        ob.list[16].min = yordamchi[j].GidroKarbanat;
                                    }
                                    if (yordamchi[j].GidroKarbanat > ob.list[16].max)
                                    {
                                        ob.list[16].max = yordamchi[j].GidroKarbanat;
                                    }
                                }

                                if (tfor_pdk[17] && yordamchi[j].Na != -1)
                                {
                                    ob.list[17].umumiy++;
                                    yordamchi[j].Na /= koms[17].PDK;
                                    ob.list[17].ortacha += yordamchi[j].Na;
                                    if (yordamchi[j].Na < ob.list[17].min)
                                    {
                                        ob.list[17].min = yordamchi[j].Na;
                                    }
                                    if (yordamchi[j].Na > ob.list[17].max)
                                    {
                                        ob.list[17].max = yordamchi[j].Na;
                                    }
                                }

                                if (tfor_pdk[18] && yordamchi[j].K != -1)
                                {
                                    ob.list[18].umumiy++;
                                    yordamchi[j].K /= koms[18].PDK;
                                    ob.list[18].ortacha += yordamchi[j].K;
                                    if (yordamchi[j].K < ob.list[18].min)
                                    {
                                        ob.list[18].min = yordamchi[j].K;
                                    }
                                    if (yordamchi[j].K > ob.list[18].max)
                                    {
                                        ob.list[18].max = yordamchi[j].K;
                                    }
                                }

                                if (tfor_pdk[19] && yordamchi[j].Ca != -1)
                                {
                                    ob.list[19].umumiy++;
                                    yordamchi[j].Ca /= koms[19].PDK;
                                    ob.list[19].ortacha += yordamchi[j].Ca;
                                    if (yordamchi[j].Ca < ob.list[19].min)
                                    {
                                        ob.list[19].min = yordamchi[j].Ca;
                                    }
                                    if (yordamchi[j].Ca > ob.list[19].max)
                                    {
                                        ob.list[19].max = yordamchi[j].Ca;
                                    }
                                }

                                if (tfor_pdk[20] && yordamchi[j].Mg != -1)
                                {
                                    ob.list[20].umumiy++;
                                    yordamchi[j].Mg /= koms[21].PDK;
                                    ob.list[20].ortacha += yordamchi[j].Mg;
                                    if (yordamchi[j].Mg < ob.list[20].min)
                                    {
                                        ob.list[20].min = yordamchi[j].Mg;
                                    }
                                    if (yordamchi[j].Mg > ob.list[20].max)
                                    {
                                        ob.list[20].max = yordamchi[j].Mg;
                                    }
                                }

                                if (tfor_pdk[21] && yordamchi[j].Mineral != -1)
                                {
                                    ob.list[21].umumiy++;
                                    yordamchi[j].Mineral /= koms[21].PDK;
                                    ob.list[21].ortacha += yordamchi[j].Mineral;
                                    if (yordamchi[j].Mineral < ob.list[21].min)
                                    {
                                        ob.list[21].min = yordamchi[j].Mineral;
                                    }
                                    if (yordamchi[j].Mineral > ob.list[21].max)
                                    {
                                        ob.list[21].max = yordamchi[j].Mineral;
                                    }
                                }

                                if (tfor_pdk[22] && yordamchi[j].XPK != -1)
                                {
                                    ob.list[22].umumiy++;
                                    ob.list[22].ortacha += yordamchi[j].XPK;
                                    if (yordamchi[j].XPK < ob.list[22].min)
                                    {
                                        ob.list[22].min = yordamchi[j].XPK;
                                    }
                                    if (yordamchi[j].XPK > ob.list[22].max)
                                    {
                                        ob.list[22].max = yordamchi[j].XPK;
                                    }
                                }

                                if (tfor_pdk[23] && yordamchi[j].BPK != -1)
                                {
                                    ob.list[23].umumiy++;
                                    yordamchi[j].BPK /= koms[23].PDK;
                                    ob.list[23].ortacha += yordamchi[j].BPK;
                                    if (yordamchi[j].BPK < ob.list[23].min)
                                    {
                                        ob.list[23].min = yordamchi[j].BPK;
                                    }
                                    if (yordamchi[j].BPK > ob.list[23].max)
                                    {
                                        ob.list[23].max = yordamchi[j].BPK;
                                    }
                                }

                                if (tfor_pdk[24] && yordamchi[j].AzotAmonniy != -1)
                                {
                                    ob.list[24].umumiy++;
                                    yordamchi[j].AzotAmonniy /= koms[24].PDK;
                                    ob.list[24].ortacha += yordamchi[j].AzotAmonniy;
                                    if (yordamchi[j].AzotAmonniy < ob.list[24].min)
                                    {
                                        ob.list[24].min = yordamchi[j].AzotAmonniy;
                                    }
                                    if (yordamchi[j].AzotAmonniy > ob.list[24].max)
                                    {
                                        ob.list[24].max = yordamchi[j].AzotAmonniy;
                                    }
                                }

                                if (tfor_pdk[25] && yordamchi[j].AzotNitritniy != -1)
                                {
                                    ob.list[25].umumiy++;
                                    yordamchi[j].AzotNitritniy /= koms[25].PDK;
                                    ob.list[25].ortacha += yordamchi[j].AzotNitritniy;
                                    if (yordamchi[j].AzotNitritniy < ob.list[25].min)
                                    {
                                        ob.list[25].min = yordamchi[j].AzotNitritniy;
                                    }
                                    if (yordamchi[j].AzotNitritniy > ob.list[25].max)
                                    {
                                        ob.list[25].max = yordamchi[j].AzotNitritniy;
                                    }
                                }

                                if (tfor_pdk[26] && yordamchi[j].AzotNitratniy != -1)
                                {
                                    ob.list[26].umumiy++;
                                    yordamchi[j].AzotNitratniy /= koms[26].PDK;
                                    ob.list[26].ortacha += yordamchi[j].AzotNitratniy;
                                    if (yordamchi[j].AzotNitratniy < ob.list[26].min)
                                    {
                                        ob.list[26].min = yordamchi[j].AzotNitratniy;
                                    }
                                    if (yordamchi[j].AzotNitratniy > ob.list[26].max)
                                    {
                                        ob.list[26].max = yordamchi[j].AzotNitratniy;
                                    }
                                }

                                if (tfor_pdk[27] && yordamchi[j].AzotSumma != -1)
                                {
                                    ob.list[27].umumiy++;
                                    ob.list[27].ortacha += yordamchi[j].AzotSumma;
                                    if (yordamchi[j].AzotSumma < ob.list[27].min)
                                    {
                                        ob.list[27].min = yordamchi[j].AzotSumma;
                                    }
                                    if (yordamchi[j].AzotSumma > ob.list[27].max)
                                    {
                                        ob.list[27].max = yordamchi[j].AzotSumma;
                                    }
                                }

                                if (tfor_pdk[28] && yordamchi[j].Fosfat != -1)
                                {
                                    ob.list[28].umumiy++;
                                    yordamchi[j].Fosfat /= koms[28].PDK;
                                    ob.list[28].ortacha += yordamchi[j].Fosfat;
                                    if (yordamchi[j].Fosfat < ob.list[28].min)
                                    {
                                        ob.list[28].min = yordamchi[j].Fosfat;
                                    }
                                    if (yordamchi[j].Fosfat > ob.list[28].max)
                                    {
                                        ob.list[28].max = yordamchi[j].Fosfat;
                                    }
                                }

                                if (tfor_pdk[29] && yordamchi[j].Si != -1)
                                {
                                    ob.list[29].umumiy++;
                                    ob.list[29].ortacha += yordamchi[j].Si;
                                    if (yordamchi[j].Si < ob.list[29].min)
                                    {
                                        ob.list[29].min = yordamchi[j].Si;
                                    }
                                    if (yordamchi[j].Si > ob.list[29].max)
                                    {
                                        ob.list[29].max = yordamchi[j].Si;
                                    }
                                }

                                if (tfor_pdk[30] && yordamchi[j].Elektr != -1)
                                {
                                    ob.list[30].umumiy++;
                                    ob.list[30].ortacha += yordamchi[j].Elektr;
                                    if (yordamchi[j].Elektr < ob.list[30].min)
                                    {
                                        ob.list[30].min = yordamchi[j].Elektr;
                                    }
                                    if (yordamchi[j].Elektr > ob.list[30].max)
                                    {
                                        ob.list[30].max = yordamchi[j].Elektr;
                                    }
                                }

                                if (tfor_pdk[31] && yordamchi[j].Eh_MB != -1)
                                {
                                    ob.list[31].umumiy++;
                                    ob.list[31].ortacha += yordamchi[j].Eh_MB;
                                    if (yordamchi[j].Eh_MB < ob.list[32].min)
                                    {
                                        ob.list[32].min = yordamchi[j].Eh_MB;
                                    }
                                    if (yordamchi[j].Eh_MB > ob.list[32].max)
                                    {
                                        ob.list[32].max = yordamchi[j].Eh_MB;
                                    }
                                }

                                if (tfor_pdk[32] && yordamchi[j].PUmumiy != -1)
                                {
                                    ob.list[32].umumiy++;
                                    yordamchi[j].PUmumiy /= koms[32].PDK;
                                    ob.list[32].ortacha += yordamchi[j].PUmumiy;
                                    if (yordamchi[j].PUmumiy < ob.list[32].min)
                                    {
                                        ob.list[32].min = yordamchi[j].PUmumiy;
                                    }
                                    if (yordamchi[j].PUmumiy > ob.list[32].max)
                                    {
                                        ob.list[32].max = yordamchi[j].PUmumiy;
                                    }
                                }

                                if (tfor_pdk[33] && yordamchi[j].FeUmumiy != -1)
                                {
                                    ob.list[33].umumiy++;
                                    yordamchi[j].FeUmumiy /= koms[33].PDK;
                                    ob.list[33].ortacha += yordamchi[j].FeUmumiy;
                                    if (yordamchi[j].FeUmumiy < ob.list[33].min)
                                    {
                                        ob.list[33].min = yordamchi[j].FeUmumiy;
                                    }
                                    if (yordamchi[j].FeUmumiy > ob.list[1].max)
                                    {
                                        ob.list[33].max = yordamchi[j].FeUmumiy;
                                    }
                                }

                                if (tfor_pdk[34] && yordamchi[j].Ci != -1)
                                {
                                    ob.list[34].umumiy++;
                                    yordamchi[j].Ci /= koms[34].PDK;
                                    ob.list[34].ortacha += yordamchi[j].Ci;
                                    if (yordamchi[j].Ci < ob.list[34].min)
                                    {
                                        ob.list[34].min = yordamchi[j].Ci;
                                    }
                                    if (yordamchi[j].Ci > ob.list[34].max)
                                    {
                                        ob.list[34].max = yordamchi[j].Ci;
                                    }
                                }

                                if (tfor_pdk[35] && yordamchi[j].Zn != -1)
                                {
                                    ob.list[35].umumiy++;
                                    yordamchi[j].Zn /= koms[35].PDK;
                                    ob.list[35].ortacha += yordamchi[j].Zn;
                                    if (yordamchi[j].Zn < ob.list[35].min)
                                    {
                                        ob.list[35].min = yordamchi[j].Zn;
                                    }
                                    if (yordamchi[j].Zn > ob.list[35].max)
                                    {
                                        ob.list[35].max = yordamchi[j].Zn;
                                    }
                                }

                                if (tfor_pdk[36] && yordamchi[j].Ni != -1)
                                {
                                    ob.list[36].umumiy++;
                                    yordamchi[j].Ni /= koms[36].PDK;
                                    ob.list[36].ortacha += yordamchi[j].Ni;
                                    if (yordamchi[j].Ni < ob.list[36].min)
                                    {
                                        ob.list[36].min = yordamchi[j].Ni;
                                    }
                                    if (yordamchi[j].Ni > ob.list[36].max)
                                    {
                                        ob.list[36].max = yordamchi[j].Ni;
                                    }
                                }

                                if (tfor_pdk[37] && yordamchi[j].Cr != -1)
                                {
                                    ob.list[37].umumiy++;
                                    ob.list[37].ortacha += yordamchi[j].Cr;
                                    if (yordamchi[j].Cr < ob.list[37].min)
                                    {
                                        ob.list[37].min = yordamchi[j].Cr;
                                    }
                                    if (yordamchi[j].Cr > ob.list[37].max)
                                    {
                                        ob.list[1].max = yordamchi[j].Cr;
                                    }
                                }

                                if (tfor_pdk[38] && yordamchi[j].Cr_VI != -1)
                                {
                                    ob.list[38].umumiy++;
                                    yordamchi[j].Cr_VI /= koms[38].PDK;
                                    ob.list[38].ortacha += yordamchi[j].Cr_VI;
                                    if (yordamchi[j].Cr_VI < ob.list[38].min)
                                    {
                                        ob.list[38].min = yordamchi[j].Cr_VI;
                                    }
                                    if (yordamchi[j].Cr_VI > ob.list[38].max)
                                    {
                                        ob.list[38].max = yordamchi[j].Cr_VI;
                                    }
                                }

                                if (tfor_pdk[39] && yordamchi[j].Cr_III != -1)
                                {
                                    ob.list[39].umumiy++;
                                    ob.list[39].ortacha += yordamchi[j].Cr_III;
                                    if (yordamchi[j].Cr_III < ob.list[39].min)
                                    {
                                        ob.list[39].min = yordamchi[j].Cr_III;
                                    }
                                    if (yordamchi[j].Cr_III > ob.list[39].max)
                                    {
                                        ob.list[39].max = yordamchi[j].Cr_III;
                                    }
                                }

                                if (tfor_pdk[40] && yordamchi[j].Pb != -1)
                                {
                                    ob.list[40].umumiy++;
                                    yordamchi[j].Pb /= koms[40].PDK;
                                    ob.list[40].ortacha += yordamchi[j].Pb;
                                    if (yordamchi[j].Pb < ob.list[40].min)
                                    {
                                        ob.list[40].min = yordamchi[j].Pb;
                                    }
                                    if (yordamchi[j].Pb > ob.list[40].max)
                                    {
                                        ob.list[40].max = yordamchi[j].Pb;
                                    }
                                }

                                if (tfor_pdk[41] && yordamchi[j].Hg != -1)
                                {
                                    ob.list[41].umumiy++;
                                    yordamchi[j].Hg /= koms[41].PDK;
                                    ob.list[41].ortacha += yordamchi[j].Hg;
                                    if (yordamchi[j].Hg < ob.list[41].min)
                                    {
                                        ob.list[41].min = yordamchi[j].Hg;
                                    }
                                    if (yordamchi[j].Hg > ob.list[41].max)
                                    {
                                        ob.list[41].max = yordamchi[j].Hg;
                                    }
                                }

                                if (tfor_pdk[42] && yordamchi[j].Cd != -1)
                                {
                                    ob.list[42].umumiy++;
                                    yordamchi[j].Cd /= koms[42].PDK;
                                    ob.list[42].ortacha += yordamchi[j].Cd;
                                    if (yordamchi[j].Cd < ob.list[42].min)
                                    {
                                        ob.list[42].min = yordamchi[j].Cd;
                                    }
                                    if (yordamchi[j].Cd > ob.list[42].max)
                                    {
                                        ob.list[42].max = yordamchi[j].Cd;
                                    }
                                }

                                if (tfor_pdk[43] && yordamchi[j].Mn != -1)
                                {
                                    ob.list[43].umumiy++;
                                    ob.list[43].ortacha += yordamchi[j].Mn;
                                    if (yordamchi[j].Mn < ob.list[43].min)
                                    {
                                        ob.list[43].min = yordamchi[j].Mn;
                                    }
                                    if (yordamchi[j].Mn > ob.list[43].max)
                                    {
                                        ob.list[43].max = yordamchi[j].Mn;
                                    }
                                }

                                if (tfor_pdk[44] && yordamchi[j].As != -1)
                                {
                                    ob.list[44].umumiy++;
                                    yordamchi[j].As /= koms[44].PDK;
                                    ob.list[44].ortacha += yordamchi[j].As;
                                    if (yordamchi[j].As < ob.list[44].min)
                                    {
                                        ob.list[44].min = yordamchi[j].As;
                                    }
                                    if (yordamchi[j].As > ob.list[44].max)
                                    {
                                        ob.list[44].max = yordamchi[j].As;
                                    }
                                }

                                if (tfor_pdk[45] && yordamchi[j].Fenollar != -1)
                                {
                                    ob.list[45].umumiy++;
                                    yordamchi[j].Fenollar /= koms[45].PDK;
                                    ob.list[45].ortacha += yordamchi[j].Fenollar;
                                    if (yordamchi[j].Fenollar < ob.list[45].min)
                                    {
                                        ob.list[45].min = yordamchi[j].Fenollar;
                                    }
                                    if (yordamchi[j].Fenollar > ob.list[45].max)
                                    {
                                        ob.list[45].max = yordamchi[j].Fenollar;
                                    }
                                }

                                if (tfor_pdk[46] && yordamchi[j].Neft != -1)
                                {
                                    ob.list[46].umumiy++;
                                    yordamchi[j].Neft /= koms[46].PDK;
                                    ob.list[46].ortacha += yordamchi[j].Neft;
                                    if (yordamchi[j].Neft < ob.list[46].min)
                                    {
                                        ob.list[46].min = yordamchi[j].Neft;
                                    }
                                    if (yordamchi[j].Neft > ob.list[46].max)
                                    {
                                        ob.list[46].max = yordamchi[j].Neft;
                                    }
                                }

                                if (tfor_pdk[47] && yordamchi[j].SPAB != -1)
                                {
                                    ob.list[47].umumiy++;
                                    yordamchi[j].SPAB /= koms[47].PDK;
                                    ob.list[47].ortacha += yordamchi[j].SPAB;
                                    if (yordamchi[j].SPAB < ob.list[47].min)
                                    {
                                        ob.list[47].min = yordamchi[j].SPAB;
                                    }
                                    if (yordamchi[j].SPAB > ob.list[47].max)
                                    {
                                        ob.list[47].max = yordamchi[j].SPAB;
                                    }
                                }

                                if (tfor_pdk[48] && yordamchi[j].F != -1)
                                {
                                    ob.list[48].umumiy++;
                                    yordamchi[j].F /= koms[48].PDK;
                                    ob.list[48].ortacha += yordamchi[j].F;
                                    if (yordamchi[j].F < ob.list[48].min)
                                    {
                                        ob.list[48].min = yordamchi[j].F;
                                    }
                                    if (yordamchi[j].F > ob.list[48].max)
                                    {
                                        ob.list[48].max = yordamchi[j].F;
                                    }
                                }

                                if (tfor_pdk[49] && yordamchi[j].Sianidi != -1)
                                {
                                    ob.list[49].umumiy++;
                                    yordamchi[j].Sianidi /= koms[49].PDK;
                                    ob.list[49].ortacha += yordamchi[j].Sianidi;
                                    if (yordamchi[j].Sianidi < ob.list[49].min)
                                    {
                                        ob.list[49].min = yordamchi[j].Sianidi;
                                    }
                                    if (yordamchi[j].Sianidi > ob.list[49].max)
                                    {
                                        ob.list[49].max = yordamchi[j].Sianidi;
                                    }
                                }

                                if (tfor_pdk[50] && yordamchi[j].Proponil != -1)
                                {
                                    ob.list[50].umumiy++;
                                    ob.list[50].ortacha += yordamchi[j].Proponil;
                                    if (yordamchi[j].Proponil < ob.list[50].min)
                                    {
                                        ob.list[50].min = yordamchi[j].Proponil;
                                    }
                                    if (yordamchi[j].Proponil > ob.list[50].max)
                                    {
                                        ob.list[50].max = yordamchi[j].Proponil;
                                    }
                                }

                                if (tfor_pdk[51] && yordamchi[j].DDE != -1)
                                {
                                    ob.list[51].umumiy++;
                                    ob.list[51].ortacha += yordamchi[j].DDE;
                                    if (yordamchi[j].DDE < ob.list[51].min)
                                    {
                                        ob.list[51].min = yordamchi[j].DDE;
                                    }
                                    if (yordamchi[j].DDE > ob.list[51].max)
                                    {
                                        ob.list[51].max = yordamchi[j].DDE;
                                    }
                                }

                                if (tfor_pdk[52] && yordamchi[j].Rogor != -1)
                                {
                                    ob.list[52].umumiy++;
                                    ob.list[52].ortacha += yordamchi[j].Rogor;
                                    if (yordamchi[j].Rogor < ob.list[52].min)
                                    {
                                        ob.list[52].min = yordamchi[j].Rogor;
                                    }
                                    if (yordamchi[j].Rogor > ob.list[52].max)
                                    {
                                        ob.list[52].max = yordamchi[j].Rogor;
                                    }
                                }

                                if (tfor_pdk[53] && yordamchi[j].DDT != -1)
                                {
                                    ob.list[53].umumiy++;
                                    yordamchi[j].DDT /= koms[53].PDK;
                                    ob.list[53].ortacha += yordamchi[j].DDT;
                                    if (yordamchi[j].DDT < ob.list[53].min)
                                    {
                                        ob.list[53].min = yordamchi[j].DDT;
                                    }
                                    if (yordamchi[j].DDT > ob.list[53].max)
                                    {
                                        ob.list[53].max = yordamchi[j].DDT;
                                    }
                                }

                                if (tfor_pdk[54] && yordamchi[j].Geksaxloran != -1)
                                {
                                    ob.list[54].umumiy++;
                                    yordamchi[j].Geksaxloran /= koms[54].PDK;
                                    ob.list[54].ortacha += yordamchi[j].Geksaxloran;
                                    if (yordamchi[j].Geksaxloran < ob.list[54].min)
                                    {
                                        ob.list[54].min = yordamchi[j].Geksaxloran;
                                    }
                                    if (yordamchi[j].Geksaxloran > ob.list[54].max)
                                    {
                                        ob.list[54].max = yordamchi[j].Geksaxloran;
                                    }
                                }

                                if (tfor_pdk[55] && yordamchi[j].Lindan != -1)
                                {
                                    ob.list[55].umumiy++;
                                    yordamchi[j].Lindan /= koms[55].PDK;
                                    ob.list[55].ortacha += yordamchi[j].Lindan;
                                    if (yordamchi[j].Lindan < ob.list[55].min)
                                    {
                                        ob.list[55].min = yordamchi[j].Lindan;
                                    }
                                    if (yordamchi[j].Lindan > ob.list[55].max)
                                    {
                                        ob.list[55].max = yordamchi[j].Lindan;
                                    }
                                }

                                if (tfor_pdk[56] && yordamchi[j].DDD != -1)
                                {
                                    ob.list[56].umumiy++;
                                    ob.list[56].ortacha += yordamchi[j].DDD;
                                    if (yordamchi[j].DDD < ob.list[56].min)
                                    {
                                        ob.list[56].min = yordamchi[j].DDD;
                                    }
                                    if (yordamchi[j].DDD > ob.list[56].max)
                                    {
                                        ob.list[56].max = yordamchi[j].DDD;
                                    }
                                }

                                if (tfor_pdk[57] && yordamchi[j].Metafos != -1)
                                {
                                    ob.list[57].umumiy++;
                                    ob.list[57].ortacha += yordamchi[j].Metafos;
                                    if (yordamchi[j].Metafos < ob.list[57].min)
                                    {
                                        ob.list[57].min = yordamchi[j].Metafos;
                                    }
                                    if (yordamchi[j].Metafos > ob.list[57].max)
                                    {
                                        ob.list[57].max = yordamchi[j].Metafos;
                                    }
                                }

                                if (tfor_pdk[58] && yordamchi[j].Butifos != -1)
                                {
                                    ob.list[58].umumiy++;
                                    ob.list[58].ortacha += yordamchi[j].Butifos;
                                    if (yordamchi[j].Butifos < ob.list[1].min)
                                    {
                                        ob.list[58].min = yordamchi[j].Butifos;
                                    }
                                    if (yordamchi[j].Butifos > ob.list[1].max)
                                    {
                                        ob.list[58].max = yordamchi[j].Butifos;
                                    }
                                }

                                if (tfor_pdk[59] && yordamchi[j].Dalapon != -1)
                                {
                                    ob.list[59].umumiy++;
                                    ob.list[59].ortacha += yordamchi[j].Dalapon;
                                    if (yordamchi[j].Dalapon < ob.list[59].min)
                                    {
                                        ob.list[59].min = yordamchi[j].Dalapon;
                                    }
                                    if (yordamchi[j].Dalapon > ob.list[59].max)
                                    {
                                        ob.list[59].max = yordamchi[j].Dalapon;
                                    }
                                }

                                if (tfor_pdk[60] && yordamchi[j].Karbofos != -1)
                                {
                                    ob.list[60].umumiy++;
                                    ob.list[60].ortacha += yordamchi[j].Karbofos;
                                    if (yordamchi[j].Karbofos < ob.list[60].min)
                                    {
                                        ob.list[60].min = yordamchi[j].Karbofos;
                                    }
                                    if (yordamchi[j].Karbofos > ob.list[60].max)
                                    {
                                        ob.list[60].max = yordamchi[j].Karbofos;
                                    }
                                }
                            }
                        }

                        result1.Add(ob);
                    }

                    HisobotPDKForm form1 = new HisobotPDKForm(result1, result, koms, tfor_pdk, Year, 1);
                    form1.ShowDialog();
                }
                else
                {
                    HisobotPDKForm form1 = new HisobotPDKForm(result, koms, tfor_pdk, Year, 1);
                    form1.ShowDialog();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void mnItemHisobotPDKBasyn_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] tfor_pdk;
                YearFormForPDK form = new YearFormForPDK(koms);
                form.ShowDialog();

                int Year = form.Year;
                if (Year <= 0)
                    return;
                tfor_pdk = form.t;
                bool LastYear = form.LastYear;

                string strquery = "Select *From Analysis Where Sana>#31/12/" + (Year - 1).ToString() + "# And Sana<#01/01/" + (Year + 1).ToString() + "#";
                List<AnalysisClass> list = GetAnalysisList(strquery);
                List<HisobotPostPDK> result = new List<HisobotPostPDK>();
                for (int k = 0; k < rivers.Count; k++)
                {
                    List<PostClass> postyordam = posts.Where(x => x.River_Id == rivers[k].Id).ToList();
                    List<AnalysisClass> yordamchi = new List<AnalysisClass>();

                    for (int i = 0; i < postyordam.Count; i++)
                    {
                        yordamchi.AddRange(list.Where(x => x.Post_Id == postyordam[i].Id));
                    }

                    HisobotPostPDK ob = new HisobotPostPDK(koms);
                    ob.post = rivers[k].Name;

                    if (yordamchi.Count > 0)
                    {
                        for (int j = 0; j < yordamchi.Count; j++)
                        {
                            if (tfor_pdk[0] && yordamchi[j].Sigm != -1)
                            {
                                ob.list[0].umumiy++;
                                ob.list[0].ortacha += yordamchi[j].Sigm;
                                if (yordamchi[j].Sigm < ob.list[0].min)
                                {
                                    ob.list[0].min = yordamchi[j].Sigm;
                                }
                                if (yordamchi[j].Sigm > ob.list[0].max)
                                {
                                    ob.list[0].max = yordamchi[j].Sigm;
                                }
                            }

                            if (tfor_pdk[1] && yordamchi[j].OqimTezligi != -1)
                            {
                                ob.list[1].umumiy++;
                                ob.list[1].ortacha += yordamchi[j].OqimTezligi;

                                if (yordamchi[j].OqimTezligi < ob.list[1].min)
                                {
                                    ob.list[1].min = yordamchi[j].OqimTezligi;
                                }
                                if (yordamchi[j].OqimTezligi > ob.list[1].max)
                                {
                                    ob.list[1].max = yordamchi[j].OqimTezligi;
                                }
                            }

                            if (tfor_pdk[2] && yordamchi[j].DaryoSarfi != -1)
                            {
                                ob.list[2].umumiy++;
                                ob.list[2].ortacha += yordamchi[j].DaryoSarfi;
                                if (yordamchi[j].DaryoSarfi < ob.list[2].min)
                                {
                                    ob.list[2].min = yordamchi[j].DaryoSarfi;
                                }
                                if (yordamchi[j].DaryoSarfi > ob.list[2].max)
                                {
                                    ob.list[2].max = yordamchi[j].DaryoSarfi;
                                }
                            }

                            if (tfor_pdk[3] && yordamchi[j].OqimSarfi != -1)
                            {
                                ob.list[3].umumiy++;
                                ob.list[3].ortacha += yordamchi[j].OqimSarfi;
                                if (yordamchi[j].OqimSarfi < ob.list[3].min)
                                {
                                    ob.list[3].min = yordamchi[j].OqimSarfi;
                                }
                                if (yordamchi[j].OqimSarfi > ob.list[3].max)
                                {
                                    ob.list[3].max = yordamchi[j].OqimSarfi;
                                }
                            }

                            if (tfor_pdk[4] && yordamchi[j].Namlik != -1)
                            {
                                ob.list[4].umumiy++;
                                ob.list[4].ortacha += yordamchi[j].Namlik;
                                if (yordamchi[j].Namlik < ob.list[4].min)
                                {
                                    ob.list[4].min = yordamchi[j].Namlik;
                                }
                                if (yordamchi[j].Namlik > ob.list[4].max)
                                {
                                    ob.list[4].max = yordamchi[j].Namlik;
                                }
                            }

                            if (tfor_pdk[5] && yordamchi[j].Tiniqlik != -1)
                            {
                                ob.list[5].umumiy++;
                                ob.list[5].ortacha += yordamchi[j].Tiniqlik;
                                if (yordamchi[j].OqimTezligi < ob.list[5].min)
                                {
                                    ob.list[5].min = yordamchi[j].OqimTezligi;
                                }
                                if (yordamchi[j].OqimTezligi > ob.list[5].max)
                                {
                                    ob.list[5].max = yordamchi[j].OqimTezligi;
                                }
                            }

                            if (tfor_pdk[6] && yordamchi[j].Rangi != -1)
                            {
                                ob.list[6].umumiy++;
                                ob.list[6].ortacha += yordamchi[j].Rangi;
                                if (yordamchi[j].Rangi < ob.list[6].min)
                                {
                                    ob.list[6].min = yordamchi[j].Rangi;
                                }
                                if (yordamchi[j].Rangi > ob.list[6].max)
                                {
                                    ob.list[6].max = yordamchi[j].Rangi;
                                }
                            }

                            if (tfor_pdk[7] && yordamchi[j].Harorat != -1)
                            {
                                ob.list[7].umumiy++;
                                ob.list[7].ortacha += yordamchi[j].Harorat;
                                if (yordamchi[j].Harorat < ob.list[7].min)
                                {
                                    ob.list[7].min = yordamchi[j].Harorat;
                                }
                                if (yordamchi[j].Harorat > ob.list[7].max)
                                {
                                    ob.list[7].max = yordamchi[j].Harorat;
                                }
                            }

                            if (tfor_pdk[8] && yordamchi[j].Suzuvchi != -1)
                            {
                                ob.list[8].umumiy++;
                                ob.list[8].ortacha += yordamchi[j].Suzuvchi;
                                if (yordamchi[j].Suzuvchi < ob.list[8].min)
                                {
                                    ob.list[8].min = yordamchi[j].Suzuvchi;
                                }
                                if (yordamchi[j].Suzuvchi > ob.list[8].max)
                                {
                                    ob.list[8].max = yordamchi[j].Suzuvchi;
                                }
                            }

                            if (tfor_pdk[9] && yordamchi[j].pH != -1)
                            {
                                ob.list[9].umumiy++;
                                yordamchi[j].pH /= koms[9].PDK;
                                ob.list[9].ortacha += yordamchi[j].pH;
                                if (yordamchi[j].pH < ob.list[9].min)
                                {
                                    ob.list[9].min = yordamchi[j].pH;
                                }
                                if (yordamchi[j].pH > ob.list[9].max)
                                {
                                    ob.list[9].max = yordamchi[j].pH;
                                }
                            }

                            if (tfor_pdk[10] && yordamchi[j].O2 != -1)
                            {
                                ob.list[10].umumiy++;
                                yordamchi[j].O2 /= koms[10].PDK;
                                ob.list[10].ortacha += yordamchi[j].O2;
                                if (yordamchi[j].O2 < ob.list[10].min)
                                {
                                    ob.list[10].min = yordamchi[j].O2;
                                }
                                if (yordamchi[j].O2 > ob.list[10].max)
                                {
                                    ob.list[10].max = yordamchi[j].O2;
                                }
                            }

                            if (tfor_pdk[11] && yordamchi[j].Tuyingan != -1)
                            {
                                ob.list[11].umumiy++;
                                ob.list[11].ortacha += yordamchi[j].Tuyingan;
                                if (yordamchi[j].Tuyingan < ob.list[11].min)
                                {
                                    ob.list[11].min = yordamchi[j].Tuyingan;
                                }
                                if (yordamchi[j].Tuyingan > ob.list[11].max)
                                {
                                    ob.list[11].max = yordamchi[j].Tuyingan;
                                }
                            }

                            if (tfor_pdk[12] && yordamchi[j].CO2 != -1)
                            {
                                ob.list[12].umumiy++;
                                ob.list[12].ortacha += yordamchi[j].CO2;
                                if (yordamchi[j].CO2 < ob.list[12].min)
                                {
                                    ob.list[12].min = yordamchi[j].CO2;
                                }
                                if (yordamchi[j].CO2 > ob.list[12].max)
                                {
                                    ob.list[12].max = yordamchi[j].CO2;
                                }
                            }

                            if (tfor_pdk[13] && yordamchi[j].Qattiqlik != -1)
                            {
                                ob.list[13].umumiy++;
                                yordamchi[j].Qattiqlik /= koms[13].PDK;
                                ob.list[13].ortacha += yordamchi[j].Qattiqlik;
                                if (yordamchi[j].Qattiqlik < ob.list[13].min)
                                {
                                    ob.list[13].min = yordamchi[j].Qattiqlik;
                                }
                                if (yordamchi[j].Qattiqlik > ob.list[13].max)
                                {
                                    ob.list[13].max = yordamchi[j].Qattiqlik;
                                }
                            }

                            if (tfor_pdk[14] && yordamchi[j].Xlorid != -1)
                            {
                                ob.list[14].umumiy++;
                                yordamchi[j].Xlorid /= koms[14].PDK;
                                ob.list[14].ortacha += yordamchi[j].Xlorid;
                                if (yordamchi[j].Xlorid < ob.list[14].min)
                                {
                                    ob.list[14].min = yordamchi[j].Xlorid;
                                }
                                if (yordamchi[j].Xlorid > ob.list[14].max)
                                {
                                    ob.list[14].max = yordamchi[j].Xlorid;
                                }
                            }

                            if (tfor_pdk[15] && yordamchi[j].Sulfat != -1)
                            {
                                ob.list[15].umumiy++;
                                yordamchi[j].Sulfat /= koms[15].PDK;
                                ob.list[15].ortacha += yordamchi[j].Sulfat;
                                if (yordamchi[j].Sulfat < ob.list[15].min)
                                {
                                    ob.list[15].min = yordamchi[j].Sulfat;
                                }
                                if (yordamchi[j].Sulfat > ob.list[15].max)
                                {
                                    ob.list[15].max = yordamchi[j].Sulfat;
                                }
                            }

                            if (tfor_pdk[16] && yordamchi[j].GidroKarbanat != -1)
                            {
                                ob.list[16].umumiy++;
                                ob.list[16].ortacha += yordamchi[j].GidroKarbanat;
                                if (yordamchi[j].GidroKarbanat < ob.list[16].min)
                                {
                                    ob.list[16].min = yordamchi[j].GidroKarbanat;
                                }
                                if (yordamchi[j].GidroKarbanat > ob.list[16].max)
                                {
                                    ob.list[16].max = yordamchi[j].GidroKarbanat;
                                }
                            }

                            if (tfor_pdk[17] && yordamchi[j].Na != -1)
                            {
                                ob.list[17].umumiy++;
                                yordamchi[j].Na /= koms[17].PDK;
                                ob.list[17].ortacha += yordamchi[j].Na;
                                if (yordamchi[j].Na < ob.list[17].min)
                                {
                                    ob.list[17].min = yordamchi[j].Na;
                                }
                                if (yordamchi[j].Na > ob.list[17].max)
                                {
                                    ob.list[17].max = yordamchi[j].Na;
                                }
                            }

                            if (tfor_pdk[18] && yordamchi[j].K != -1)
                            {
                                ob.list[18].umumiy++;
                                yordamchi[j].K /= koms[18].PDK;
                                ob.list[18].ortacha += yordamchi[j].K;
                                if (yordamchi[j].K < ob.list[18].min)
                                {
                                    ob.list[18].min = yordamchi[j].K;
                                }
                                if (yordamchi[j].K > ob.list[18].max)
                                {
                                    ob.list[18].max = yordamchi[j].K;
                                }
                            }

                            if (tfor_pdk[19] && yordamchi[j].Ca != -1)
                            {
                                ob.list[19].umumiy++;
                                yordamchi[j].Ca /= koms[19].PDK;
                                ob.list[19].ortacha += yordamchi[j].Ca;
                                if (yordamchi[j].Ca < ob.list[19].min)
                                {
                                    ob.list[19].min = yordamchi[j].Ca;
                                }
                                if (yordamchi[j].Ca > ob.list[19].max)
                                {
                                    ob.list[19].max = yordamchi[j].Ca;
                                }
                            }

                            if (tfor_pdk[20] && yordamchi[j].Mg != -1)
                            {
                                ob.list[20].umumiy++;
                                yordamchi[j].Mg /= koms[20].PDK;
                                ob.list[20].ortacha += yordamchi[j].Mg;
                                if (yordamchi[j].Mg < ob.list[20].min)
                                {
                                    ob.list[20].min = yordamchi[j].Mg;
                                }
                                if (yordamchi[j].Mg > ob.list[20].max)
                                {
                                    ob.list[20].max = yordamchi[j].Mg;
                                }
                            }

                            if (tfor_pdk[21] && yordamchi[j].Mineral != -1)
                            {
                                ob.list[21].umumiy++;
                                yordamchi[j].Mineral /= koms[21].PDK;
                                ob.list[21].ortacha += yordamchi[j].Mineral;
                                if (yordamchi[j].Mineral < ob.list[21].min)
                                {
                                    ob.list[21].min = yordamchi[j].Mineral;
                                }
                                if (yordamchi[j].Mineral > ob.list[21].max)
                                {
                                    ob.list[21].max = yordamchi[j].Mineral;
                                }
                            }

                            if (tfor_pdk[22] && yordamchi[j].XPK != -1)
                            {
                                ob.list[22].umumiy++;
                                ob.list[22].ortacha += yordamchi[j].XPK;
                                if (yordamchi[j].XPK < ob.list[22].min)
                                {
                                    ob.list[22].min = yordamchi[j].XPK;
                                }
                                if (yordamchi[j].XPK > ob.list[22].max)
                                {
                                    ob.list[22].max = yordamchi[j].XPK;
                                }
                            }

                            if (tfor_pdk[23] && yordamchi[j].BPK != -1)
                            {
                                ob.list[23].umumiy++;
                                yordamchi[j].BPK /= koms[23].PDK;
                                ob.list[23].ortacha += yordamchi[j].BPK;
                                if (yordamchi[j].BPK < ob.list[23].min)
                                {
                                    ob.list[23].min = yordamchi[j].BPK;
                                }
                                if (yordamchi[j].BPK > ob.list[23].max)
                                {
                                    ob.list[23].max = yordamchi[j].BPK;
                                }
                            }

                            if (tfor_pdk[24] && yordamchi[j].AzotAmonniy != -1)
                            {
                                ob.list[24].umumiy++;
                                yordamchi[j].AzotAmonniy /= koms[24].PDK;
                                ob.list[24].ortacha += yordamchi[j].AzotAmonniy;
                                if (yordamchi[j].AzotAmonniy < ob.list[24].min)
                                {
                                    ob.list[24].min = yordamchi[j].AzotAmonniy;
                                }
                                if (yordamchi[j].AzotAmonniy > ob.list[24].max)
                                {
                                    ob.list[24].max = yordamchi[j].AzotAmonniy;
                                }
                            }

                            if (tfor_pdk[25] && yordamchi[j].AzotNitritniy != -1)
                            {
                                ob.list[25].umumiy++;
                                yordamchi[j].AzotNitritniy /= koms[25].PDK;
                                ob.list[25].ortacha += yordamchi[j].AzotNitritniy;
                                if (yordamchi[j].AzotNitritniy < ob.list[25].min)
                                {
                                    ob.list[25].min = yordamchi[j].AzotNitritniy;
                                }
                                if (yordamchi[j].AzotNitritniy > ob.list[25].max)
                                {
                                    ob.list[25].max = yordamchi[j].AzotNitritniy;
                                }
                            }

                            if (tfor_pdk[26] && yordamchi[j].AzotNitratniy != -1)
                            {
                                ob.list[26].umumiy++;
                                yordamchi[j].AzotNitratniy /= koms[26].PDK;
                                ob.list[26].ortacha += yordamchi[j].AzotNitratniy;
                                if (yordamchi[j].AzotNitratniy < ob.list[26].min)
                                {
                                    ob.list[26].min = yordamchi[j].AzotNitratniy;
                                }
                                if (yordamchi[j].AzotNitratniy > ob.list[26].max)
                                {
                                    ob.list[26].max = yordamchi[j].AzotNitratniy;
                                }
                            }

                            if (tfor_pdk[27] && yordamchi[j].AzotSumma != -1)
                            {
                                ob.list[27].umumiy++;
                                ob.list[27].ortacha += yordamchi[j].AzotSumma;
                                if (yordamchi[j].AzotSumma < ob.list[27].min)
                                {
                                    ob.list[27].min = yordamchi[j].AzotSumma;
                                }
                                if (yordamchi[j].AzotSumma > ob.list[27].max)
                                {
                                    ob.list[27].max = yordamchi[j].AzotSumma;
                                }
                            }

                            if (tfor_pdk[28] && yordamchi[j].Fosfat != -1)
                            {
                                ob.list[28].umumiy++;
                                yordamchi[j].Fosfat /= koms[28].PDK;
                                ob.list[28].ortacha += yordamchi[j].Fosfat;
                                if (yordamchi[j].Fosfat < ob.list[28].min)
                                {
                                    ob.list[28].min = yordamchi[j].Fosfat;
                                }
                                if (yordamchi[j].Fosfat > ob.list[28].max)
                                {
                                    ob.list[28].max = yordamchi[j].Fosfat;
                                }
                            }

                            if (tfor_pdk[29] && yordamchi[j].Si != -1)
                            {
                                ob.list[29].umumiy++;
                                ob.list[29].ortacha += yordamchi[j].Si;
                                if (yordamchi[j].Si < ob.list[29].min)
                                {
                                    ob.list[29].min = yordamchi[j].Si;
                                }
                                if (yordamchi[j].Si > ob.list[29].max)
                                {
                                    ob.list[29].max = yordamchi[j].Si;
                                }
                            }

                            if (tfor_pdk[30] && yordamchi[j].Elektr != -1)
                            {
                                ob.list[30].umumiy++;
                                ob.list[30].ortacha += yordamchi[j].Elektr;
                                if (yordamchi[j].Elektr < ob.list[30].min)
                                {
                                    ob.list[30].min = yordamchi[j].Elektr;
                                }
                                if (yordamchi[j].Elektr > ob.list[30].max)
                                {
                                    ob.list[30].max = yordamchi[j].Elektr;
                                }
                            }

                            if (tfor_pdk[31] && yordamchi[j].Eh_MB != -1)
                            {
                                ob.list[31].umumiy++;
                                ob.list[31].ortacha += yordamchi[j].Eh_MB;
                                if (yordamchi[j].Eh_MB < ob.list[32].min)
                                {
                                    ob.list[32].min = yordamchi[j].Eh_MB;
                                }
                                if (yordamchi[j].Eh_MB > ob.list[32].max)
                                {
                                    ob.list[32].max = yordamchi[j].Eh_MB;
                                }
                            }

                            if (tfor_pdk[32] && yordamchi[j].PUmumiy != -1)
                            {
                                ob.list[32].umumiy++;
                                yordamchi[j].PUmumiy /= koms[32].PDK;
                                ob.list[32].ortacha += yordamchi[j].PUmumiy;
                                if (yordamchi[j].PUmumiy < ob.list[32].min)
                                {
                                    ob.list[32].min = yordamchi[j].PUmumiy;
                                }
                                if (yordamchi[j].PUmumiy > ob.list[32].max)
                                {
                                    ob.list[32].max = yordamchi[j].PUmumiy;
                                }
                            }

                            if (tfor_pdk[33] && yordamchi[j].FeUmumiy != -1)
                            {
                                ob.list[33].umumiy++;
                                yordamchi[j].FeUmumiy /= koms[33].PDK;
                                ob.list[33].ortacha += yordamchi[j].FeUmumiy;
                                if (yordamchi[j].FeUmumiy < ob.list[33].min)
                                {
                                    ob.list[33].min = yordamchi[j].FeUmumiy;
                                }
                                if (yordamchi[j].FeUmumiy > ob.list[1].max)
                                {
                                    ob.list[33].max = yordamchi[j].FeUmumiy;
                                }
                            }

                            if (tfor_pdk[34] && yordamchi[j].Ci != -1)
                            {
                                ob.list[34].umumiy++;
                                yordamchi[j].Ci /= koms[34].PDK;
                                ob.list[34].ortacha += yordamchi[j].Ci;
                                if (yordamchi[j].Ci < ob.list[34].min)
                                {
                                    ob.list[34].min = yordamchi[j].Ci;
                                }
                                if (yordamchi[j].Ci > ob.list[34].max)
                                {
                                    ob.list[34].max = yordamchi[j].Ci;
                                }
                            }

                            if (tfor_pdk[35] && yordamchi[j].Zn != -1)
                            {
                                ob.list[35].umumiy++;
                                yordamchi[j].Zn /= koms[35].PDK;
                                ob.list[35].ortacha += yordamchi[j].Zn;
                                if (yordamchi[j].Zn < ob.list[35].min)
                                {
                                    ob.list[35].min = yordamchi[j].Zn;
                                }
                                if (yordamchi[j].Zn > ob.list[35].max)
                                {
                                    ob.list[35].max = yordamchi[j].Zn;
                                }
                            }

                            if (tfor_pdk[36] && yordamchi[j].Ni != -1)
                            {
                                ob.list[36].umumiy++;
                                yordamchi[j].Ni /= koms[36].PDK;
                                ob.list[36].ortacha += yordamchi[j].Ni;
                                if (yordamchi[j].Ni < ob.list[36].min)
                                {
                                    ob.list[36].min = yordamchi[j].Ni;
                                }
                                if (yordamchi[j].Ni > ob.list[36].max)
                                {
                                    ob.list[36].max = yordamchi[j].Ni;
                                }
                            }

                            if (tfor_pdk[37] && yordamchi[j].Cr != -1)
                            {
                                ob.list[37].umumiy++;
                                ob.list[37].ortacha += yordamchi[j].Cr;
                                if (yordamchi[j].Cr < ob.list[37].min)
                                {
                                    ob.list[37].min = yordamchi[j].Cr;
                                }
                                if (yordamchi[j].Cr > ob.list[37].max)
                                {
                                    ob.list[1].max = yordamchi[j].Cr;
                                }
                            }

                            if (tfor_pdk[38] && yordamchi[j].Cr_VI != -1)
                            {
                                ob.list[38].umumiy++;
                                yordamchi[j].Cr_VI /= koms[38].PDK;
                                ob.list[38].ortacha += yordamchi[j].Cr_VI;
                                if (yordamchi[j].Cr_VI < ob.list[38].min)
                                {
                                    ob.list[38].min = yordamchi[j].Cr_VI;
                                }
                                if (yordamchi[j].Cr_VI > ob.list[38].max)
                                {
                                    ob.list[38].max = yordamchi[j].Cr_VI;
                                }
                            }

                            if (tfor_pdk[39] && yordamchi[j].Cr_III != -1)
                            {
                                ob.list[39].umumiy++;
                                ob.list[39].ortacha += yordamchi[j].Cr_III;
                                if (yordamchi[j].Cr_III < ob.list[39].min)
                                {
                                    ob.list[39].min = yordamchi[j].Cr_III;
                                }
                                if (yordamchi[j].Cr_III > ob.list[39].max)
                                {
                                    ob.list[39].max = yordamchi[j].Cr_III;
                                }
                            }

                            if (tfor_pdk[40] && yordamchi[j].Pb != -1)
                            {
                                ob.list[40].umumiy++;
                                yordamchi[j].Pb /= koms[40].PDK;
                                ob.list[40].ortacha += yordamchi[j].Pb;
                                if (yordamchi[j].Pb < ob.list[40].min)
                                {
                                    ob.list[40].min = yordamchi[j].Pb;
                                }
                                if (yordamchi[j].Pb > ob.list[40].max)
                                {
                                    ob.list[40].max = yordamchi[j].Pb;
                                }
                            }

                            if (tfor_pdk[41] && yordamchi[j].Hg != -1)
                            {
                                ob.list[41].umumiy++;
                                yordamchi[j].Hg /= koms[41].PDK;
                                ob.list[41].ortacha += yordamchi[j].Hg;
                                if (yordamchi[j].Hg < ob.list[41].min)
                                {
                                    ob.list[41].min = yordamchi[j].Hg;
                                }
                                if (yordamchi[j].Hg > ob.list[41].max)
                                {
                                    ob.list[41].max = yordamchi[j].Hg;
                                }
                            }

                            if (tfor_pdk[42] && yordamchi[j].Cd != -1)
                            {
                                ob.list[42].umumiy++;
                                yordamchi[j].Cd /= koms[42].PDK;
                                ob.list[42].ortacha += yordamchi[j].Cd;
                                if (yordamchi[j].Cd < ob.list[42].min)
                                {
                                    ob.list[42].min = yordamchi[j].Cd;
                                }
                                if (yordamchi[j].Cd > ob.list[42].max)
                                {
                                    ob.list[42].max = yordamchi[j].Cd;
                                }
                            }

                            if (tfor_pdk[43] && yordamchi[j].Mn != -1)
                            {
                                ob.list[43].umumiy++;
                                ob.list[43].ortacha += yordamchi[j].Mn;
                                if (yordamchi[j].Mn < ob.list[43].min)
                                {
                                    ob.list[43].min = yordamchi[j].Mn;
                                }
                                if (yordamchi[j].Mn > ob.list[43].max)
                                {
                                    ob.list[43].max = yordamchi[j].Mn;
                                }
                            }

                            if (tfor_pdk[44] && yordamchi[j].As != -1)
                            {
                                ob.list[44].umumiy++;
                                yordamchi[j].As /= koms[44].PDK;
                                ob.list[44].ortacha += yordamchi[j].As;
                                if (yordamchi[j].As < ob.list[44].min)
                                {
                                    ob.list[44].min = yordamchi[j].As;
                                }
                                if (yordamchi[j].As > ob.list[44].max)
                                {
                                    ob.list[44].max = yordamchi[j].As;
                                }
                            }

                            if (tfor_pdk[45] && yordamchi[j].Fenollar != -1)
                            {
                                ob.list[45].umumiy++;
                                yordamchi[j].Fenollar /= koms[45].PDK;
                                ob.list[45].ortacha += yordamchi[j].Fenollar;
                                if (yordamchi[j].Fenollar < ob.list[45].min)
                                {
                                    ob.list[45].min = yordamchi[j].Fenollar;
                                }
                                if (yordamchi[j].Fenollar > ob.list[45].max)
                                {
                                    ob.list[45].max = yordamchi[j].Fenollar;
                                }
                            }

                            if (tfor_pdk[46] && yordamchi[j].Neft != -1)
                            {
                                ob.list[46].umumiy++;
                                yordamchi[j].Neft /= koms[46].PDK;
                                ob.list[46].ortacha += yordamchi[j].Neft;
                                if (yordamchi[j].Neft < ob.list[46].min)
                                {
                                    ob.list[46].min = yordamchi[j].Neft;
                                }
                                if (yordamchi[j].Neft > ob.list[46].max)
                                {
                                    ob.list[46].max = yordamchi[j].Neft;
                                }
                            }

                            if (tfor_pdk[47] && yordamchi[j].SPAB != -1)
                            {
                                ob.list[47].umumiy++;
                                yordamchi[j].SPAB /= koms[47].PDK;
                                ob.list[47].ortacha += yordamchi[j].SPAB;
                                if (yordamchi[j].SPAB < ob.list[47].min)
                                {
                                    ob.list[47].min = yordamchi[j].SPAB;
                                }
                                if (yordamchi[j].SPAB > ob.list[47].max)
                                {
                                    ob.list[47].max = yordamchi[j].SPAB;
                                }
                            }

                            if (tfor_pdk[48] && yordamchi[j].F != -1)
                            {
                                ob.list[48].umumiy++;
                                yordamchi[j].F /= koms[48].PDK;
                                ob.list[48].ortacha += yordamchi[j].F;
                                if (yordamchi[j].F < ob.list[48].min)
                                {
                                    ob.list[48].min = yordamchi[j].F;
                                }
                                if (yordamchi[j].F > ob.list[48].max)
                                {
                                    ob.list[48].max = yordamchi[j].F;
                                }
                            }

                            if (tfor_pdk[49] && yordamchi[j].Sianidi != -1)
                            {
                                ob.list[49].umumiy++;
                                yordamchi[j].Sianidi /= koms[49].PDK;
                                ob.list[49].ortacha += yordamchi[j].Sianidi;
                                if (yordamchi[j].Sianidi < ob.list[49].min)
                                {
                                    ob.list[49].min = yordamchi[j].Sianidi;
                                }
                                if (yordamchi[j].Sianidi > ob.list[49].max)
                                {
                                    ob.list[49].max = yordamchi[j].Sianidi;
                                }
                            }

                            if (tfor_pdk[50] && yordamchi[j].Proponil != -1)
                            {
                                ob.list[50].umumiy++;
                                ob.list[50].ortacha += yordamchi[j].Proponil;
                                if (yordamchi[j].Proponil < ob.list[50].min)
                                {
                                    ob.list[50].min = yordamchi[j].Proponil;
                                }
                                if (yordamchi[j].Proponil > ob.list[50].max)
                                {
                                    ob.list[50].max = yordamchi[j].Proponil;
                                }
                            }

                            if (tfor_pdk[51] && yordamchi[j].DDE != -1)
                            {
                                ob.list[51].umumiy++;
                                ob.list[51].ortacha += yordamchi[j].DDE;
                                if (yordamchi[j].DDE < ob.list[51].min)
                                {
                                    ob.list[51].min = yordamchi[j].DDE;
                                }
                                if (yordamchi[j].DDE > ob.list[51].max)
                                {
                                    ob.list[51].max = yordamchi[j].DDE;
                                }
                            }

                            if (tfor_pdk[52] && yordamchi[j].Rogor != -1)
                            {
                                ob.list[52].umumiy++;
                                ob.list[52].ortacha += yordamchi[j].Rogor;
                                if (yordamchi[j].Rogor < ob.list[52].min)
                                {
                                    ob.list[52].min = yordamchi[j].Rogor;
                                }
                                if (yordamchi[j].Rogor > ob.list[52].max)
                                {
                                    ob.list[52].max = yordamchi[j].Rogor;
                                }
                            }

                            if (tfor_pdk[53] && yordamchi[j].DDT != -1)
                            {
                                ob.list[53].umumiy++;
                                yordamchi[j].DDT /= koms[53].PDK;
                                ob.list[53].ortacha += yordamchi[j].DDT;
                                if (yordamchi[j].DDT < ob.list[53].min)
                                {
                                    ob.list[53].min = yordamchi[j].DDT;
                                }
                                if (yordamchi[j].DDT > ob.list[53].max)
                                {
                                    ob.list[53].max = yordamchi[j].DDT;
                                }
                            }

                            if (tfor_pdk[54] && yordamchi[j].Geksaxloran != -1)
                            {
                                ob.list[54].umumiy++;
                                yordamchi[j].Geksaxloran /= koms[54].PDK;
                                ob.list[54].ortacha += yordamchi[j].Geksaxloran;
                                if (yordamchi[j].Geksaxloran < ob.list[54].min)
                                {
                                    ob.list[54].min = yordamchi[j].Geksaxloran;
                                }
                                if (yordamchi[j].Geksaxloran > ob.list[54].max)
                                {
                                    ob.list[54].max = yordamchi[j].Geksaxloran;
                                }
                            }

                            if (tfor_pdk[55] && yordamchi[j].Lindan != -1)
                            {
                                ob.list[55].umumiy++;
                                yordamchi[j].Lindan /= koms[55].PDK;
                                ob.list[55].ortacha += yordamchi[j].Lindan;
                                if (yordamchi[j].Lindan < ob.list[55].min)
                                {
                                    ob.list[55].min = yordamchi[j].Lindan;
                                }
                                if (yordamchi[j].Lindan > ob.list[55].max)
                                {
                                    ob.list[55].max = yordamchi[j].Lindan;
                                }
                            }

                            if (tfor_pdk[56] && yordamchi[j].DDD != -1)
                            {
                                ob.list[56].umumiy++;
                                ob.list[56].ortacha += yordamchi[j].DDD;
                                if (yordamchi[j].DDD < ob.list[56].min)
                                {
                                    ob.list[56].min = yordamchi[j].DDD;
                                }
                                if (yordamchi[j].DDD > ob.list[56].max)
                                {
                                    ob.list[56].max = yordamchi[j].DDD;
                                }
                            }

                            if (tfor_pdk[57] && yordamchi[j].Metafos != -1)
                            {
                                ob.list[57].umumiy++;
                                ob.list[57].ortacha += yordamchi[j].Metafos;
                                if (yordamchi[j].Metafos < ob.list[57].min)
                                {
                                    ob.list[57].min = yordamchi[j].Metafos;
                                }
                                if (yordamchi[j].Metafos > ob.list[57].max)
                                {
                                    ob.list[57].max = yordamchi[j].Metafos;
                                }
                            }

                            if (tfor_pdk[58] && yordamchi[j].Butifos != -1)
                            {
                                ob.list[58].umumiy++;
                                ob.list[58].ortacha += yordamchi[j].Butifos;
                                if (yordamchi[j].Butifos < ob.list[1].min)
                                {
                                    ob.list[58].min = yordamchi[j].Butifos;
                                }
                                if (yordamchi[j].Butifos > ob.list[1].max)
                                {
                                    ob.list[58].max = yordamchi[j].Butifos;
                                }
                            }

                            if (tfor_pdk[59] && yordamchi[j].Dalapon != -1)
                            {
                                ob.list[59].umumiy++;
                                ob.list[59].ortacha += yordamchi[j].Dalapon;
                                if (yordamchi[j].Dalapon < ob.list[59].min)
                                {
                                    ob.list[59].min = yordamchi[j].Dalapon;
                                }
                                if (yordamchi[j].Dalapon > ob.list[59].max)
                                {
                                    ob.list[59].max = yordamchi[j].Dalapon;
                                }
                            }

                            if (tfor_pdk[60] && yordamchi[j].Karbofos != -1)
                            {
                                ob.list[60].umumiy++;
                                ob.list[60].ortacha += yordamchi[j].Karbofos;
                                if (yordamchi[j].Karbofos < ob.list[60].min)
                                {
                                    ob.list[60].min = yordamchi[j].Karbofos;
                                }
                                if (yordamchi[j].Karbofos > ob.list[60].max)
                                {
                                    ob.list[60].max = yordamchi[j].Karbofos;
                                }
                            }
                        }
                    }

                    result.Add(ob);
                }

                if (LastYear)
                {
                    strquery = "Select *From Analysis Where Sana>#31/12/" + (Year - 2).ToString() +
                               "# And Sana<#01/01/" + Year.ToString() + "#";
                    list = GetAnalysisList(strquery);

                    List<HisobotPostPDK> result1 = new List<HisobotPostPDK>();

                    for (int k = 0; k < rivers.Count; k++)
                    {
                        List<PostClass> postyordam = posts.Where(x => x.River_Id == rivers[k].Id).ToList();
                        List<AnalysisClass> yordamchi = new List<AnalysisClass>();

                        for (int i = 0; i < postyordam.Count; i++)
                        {
                            yordamchi.AddRange(list.Where(x => x.Post_Id == postyordam[i].Id));
                        }

                        HisobotPostPDK ob = new HisobotPostPDK(koms);
                        ob.post = rivers[k].Name;

                        if (yordamchi.Count > 0)
                        {
                            for (int j = 0; j < yordamchi.Count; j++)
                            {
                                if (tfor_pdk[0] && yordamchi[j].Sigm != -1)
                                {
                                    ob.list[0].umumiy++;
                                    ob.list[0].ortacha += yordamchi[j].Sigm;
                                    if (yordamchi[j].Sigm < ob.list[0].min)
                                    {
                                        ob.list[0].min = yordamchi[j].Sigm;
                                    }
                                    if (yordamchi[j].Sigm > ob.list[0].max)
                                    {
                                        ob.list[0].max = yordamchi[j].Sigm;
                                    }
                                }

                                if (tfor_pdk[1] && yordamchi[j].OqimTezligi != -1)
                                {
                                    ob.list[1].umumiy++;
                                    ob.list[1].ortacha += yordamchi[j].OqimTezligi;

                                    if (yordamchi[j].OqimTezligi < ob.list[1].min)
                                    {
                                        ob.list[1].min = yordamchi[j].OqimTezligi;
                                    }
                                    if (yordamchi[j].OqimTezligi > ob.list[1].max)
                                    {
                                        ob.list[1].max = yordamchi[j].OqimTezligi;
                                    }
                                }

                                if (tfor_pdk[2] && yordamchi[j].DaryoSarfi != -1)
                                {
                                    ob.list[2].umumiy++;
                                    ob.list[2].ortacha += yordamchi[j].DaryoSarfi;
                                    if (yordamchi[j].DaryoSarfi < ob.list[2].min)
                                    {
                                        ob.list[2].min = yordamchi[j].DaryoSarfi;
                                    }
                                    if (yordamchi[j].DaryoSarfi > ob.list[2].max)
                                    {
                                        ob.list[2].max = yordamchi[j].DaryoSarfi;
                                    }
                                }

                                if (tfor_pdk[3] && yordamchi[j].OqimSarfi != -1)
                                {
                                    ob.list[3].umumiy++;
                                    ob.list[3].ortacha += yordamchi[j].OqimSarfi;
                                    if (yordamchi[j].OqimSarfi < ob.list[3].min)
                                    {
                                        ob.list[3].min = yordamchi[j].OqimSarfi;
                                    }
                                    if (yordamchi[j].OqimSarfi > ob.list[3].max)
                                    {
                                        ob.list[3].max = yordamchi[j].OqimSarfi;
                                    }
                                }

                                if (tfor_pdk[4] && yordamchi[j].Namlik != -1)
                                {
                                    ob.list[4].umumiy++;
                                    ob.list[4].ortacha += yordamchi[j].Namlik;
                                    if (yordamchi[j].Namlik < ob.list[4].min)
                                    {
                                        ob.list[4].min = yordamchi[j].Namlik;
                                    }
                                    if (yordamchi[j].Namlik > ob.list[4].max)
                                    {
                                        ob.list[4].max = yordamchi[j].Namlik;
                                    }
                                }

                                if (tfor_pdk[5] && yordamchi[j].Tiniqlik != -1)
                                {
                                    ob.list[5].umumiy++;
                                    ob.list[5].ortacha += yordamchi[j].Tiniqlik;
                                    if (yordamchi[j].OqimTezligi < ob.list[5].min)
                                    {
                                        ob.list[5].min = yordamchi[j].OqimTezligi;
                                    }
                                    if (yordamchi[j].OqimTezligi > ob.list[5].max)
                                    {
                                        ob.list[5].max = yordamchi[j].OqimTezligi;
                                    }
                                }

                                if (tfor_pdk[6] && yordamchi[j].Rangi != -1)
                                {
                                    ob.list[6].umumiy++;
                                    ob.list[6].ortacha += yordamchi[j].Rangi;
                                    if (yordamchi[j].Rangi < ob.list[6].min)
                                    {
                                        ob.list[6].min = yordamchi[j].Rangi;
                                    }
                                    if (yordamchi[j].Rangi > ob.list[6].max)
                                    {
                                        ob.list[6].max = yordamchi[j].Rangi;
                                    }
                                }

                                if (tfor_pdk[7] && yordamchi[j].Harorat != -1)
                                {
                                    ob.list[7].umumiy++;
                                    ob.list[7].ortacha += yordamchi[j].Harorat;
                                    if (yordamchi[j].Harorat < ob.list[7].min)
                                    {
                                        ob.list[7].min = yordamchi[j].Harorat;
                                    }
                                    if (yordamchi[j].Harorat > ob.list[7].max)
                                    {
                                        ob.list[7].max = yordamchi[j].Harorat;
                                    }
                                }

                                if (tfor_pdk[8] && yordamchi[j].Suzuvchi != -1)
                                {
                                    ob.list[8].umumiy++;
                                    ob.list[8].ortacha += yordamchi[j].Suzuvchi;
                                    if (yordamchi[j].Suzuvchi < ob.list[8].min)
                                    {
                                        ob.list[8].min = yordamchi[j].Suzuvchi;
                                    }
                                    if (yordamchi[j].Suzuvchi > ob.list[8].max)
                                    {
                                        ob.list[8].max = yordamchi[j].Suzuvchi;
                                    }
                                }

                                if (tfor_pdk[9] && yordamchi[j].pH != -1)
                                {
                                    ob.list[9].umumiy++;
                                    yordamchi[j].pH /= koms[9].PDK;
                                    ob.list[9].ortacha += yordamchi[j].pH;
                                    if (yordamchi[j].pH < ob.list[9].min)
                                    {
                                        ob.list[9].min = yordamchi[j].pH;
                                    }
                                    if (yordamchi[j].pH > ob.list[9].max)
                                    {
                                        ob.list[9].max = yordamchi[j].pH;
                                    }
                                }

                                if (tfor_pdk[10] && yordamchi[j].O2 != -1)
                                {
                                    ob.list[10].umumiy++;
                                    yordamchi[j].O2 /= koms[10].PDK;
                                    ob.list[10].ortacha += yordamchi[j].O2;
                                    if (yordamchi[j].O2 < ob.list[10].min)
                                    {
                                        ob.list[10].min = yordamchi[j].O2;
                                    }
                                    if (yordamchi[j].O2 > ob.list[10].max)
                                    {
                                        ob.list[10].max = yordamchi[j].O2;
                                    }
                                }

                                if (tfor_pdk[11] && yordamchi[j].Tuyingan != -1)
                                {
                                    ob.list[11].umumiy++;
                                    ob.list[11].ortacha += yordamchi[j].Tuyingan;
                                    if (yordamchi[j].Tuyingan < ob.list[11].min)
                                    {
                                        ob.list[11].min = yordamchi[j].Tuyingan;
                                    }
                                    if (yordamchi[j].Tuyingan > ob.list[11].max)
                                    {
                                        ob.list[11].max = yordamchi[j].Tuyingan;
                                    }
                                }

                                if (tfor_pdk[12] && yordamchi[j].CO2 != -1)
                                {
                                    ob.list[12].umumiy++;
                                    ob.list[12].ortacha += yordamchi[j].CO2;
                                    if (yordamchi[j].CO2 < ob.list[12].min)
                                    {
                                        ob.list[12].min = yordamchi[j].CO2;
                                    }
                                    if (yordamchi[j].CO2 > ob.list[12].max)
                                    {
                                        ob.list[12].max = yordamchi[j].CO2;
                                    }
                                }

                                if (tfor_pdk[13] && yordamchi[j].Qattiqlik != -1)
                                {
                                    ob.list[13].umumiy++;
                                    yordamchi[j].Qattiqlik /= koms[13].PDK;
                                    ob.list[13].ortacha += yordamchi[j].Qattiqlik;
                                    if (yordamchi[j].Qattiqlik < ob.list[13].min)
                                    {
                                        ob.list[13].min = yordamchi[j].Qattiqlik;
                                    }
                                    if (yordamchi[j].Qattiqlik > ob.list[13].max)
                                    {
                                        ob.list[13].max = yordamchi[j].Qattiqlik;
                                    }
                                }

                                if (tfor_pdk[14] && yordamchi[j].Xlorid != -1)
                                {
                                    ob.list[14].umumiy++;
                                    yordamchi[j].Xlorid /= koms[14].PDK;
                                    ob.list[14].ortacha += yordamchi[j].Xlorid;
                                    if (yordamchi[j].Xlorid < ob.list[14].min)
                                    {
                                        ob.list[14].min = yordamchi[j].Xlorid;
                                    }
                                    if (yordamchi[j].Xlorid > ob.list[14].max)
                                    {
                                        ob.list[14].max = yordamchi[j].Xlorid;
                                    }
                                }

                                if (tfor_pdk[15] && yordamchi[j].Sulfat != -1)
                                {
                                    ob.list[15].umumiy++;
                                    yordamchi[j].Sulfat /= koms[15].PDK;
                                    ob.list[15].ortacha += yordamchi[j].Sulfat;
                                    if (yordamchi[j].Sulfat < ob.list[15].min)
                                    {
                                        ob.list[15].min = yordamchi[j].Sulfat;
                                    }
                                    if (yordamchi[j].Sulfat > ob.list[15].max)
                                    {
                                        ob.list[15].max = yordamchi[j].Sulfat;
                                    }
                                }

                                if (tfor_pdk[16] && yordamchi[j].GidroKarbanat != -1)
                                {
                                    ob.list[16].umumiy++;
                                    ob.list[16].ortacha += yordamchi[j].GidroKarbanat;
                                    if (yordamchi[j].GidroKarbanat < ob.list[16].min)
                                    {
                                        ob.list[16].min = yordamchi[j].GidroKarbanat;
                                    }
                                    if (yordamchi[j].GidroKarbanat > ob.list[16].max)
                                    {
                                        ob.list[16].max = yordamchi[j].GidroKarbanat;
                                    }
                                }

                                if (tfor_pdk[17] && yordamchi[j].Na != -1)
                                {
                                    ob.list[17].umumiy++;
                                    yordamchi[j].Na /= koms[17].PDK;
                                    ob.list[17].ortacha += yordamchi[j].Na;
                                    if (yordamchi[j].Na < ob.list[17].min)
                                    {
                                        ob.list[17].min = yordamchi[j].Na;
                                    }
                                    if (yordamchi[j].Na > ob.list[17].max)
                                    {
                                        ob.list[17].max = yordamchi[j].Na;
                                    }
                                }

                                if (tfor_pdk[18] && yordamchi[j].K != -1)
                                {
                                    ob.list[18].umumiy++;
                                    yordamchi[j].K /= koms[18].PDK;
                                    ob.list[18].ortacha += yordamchi[j].K;
                                    if (yordamchi[j].K < ob.list[18].min)
                                    {
                                        ob.list[18].min = yordamchi[j].K;
                                    }
                                    if (yordamchi[j].K > ob.list[18].max)
                                    {
                                        ob.list[18].max = yordamchi[j].K;
                                    }
                                }

                                if (tfor_pdk[19] && yordamchi[j].Ca != -1)
                                {
                                    ob.list[19].umumiy++;
                                    yordamchi[j].Ca /= koms[19].PDK;
                                    ob.list[19].ortacha += yordamchi[j].Ca;
                                    if (yordamchi[j].Ca < ob.list[19].min)
                                    {
                                        ob.list[19].min = yordamchi[j].Ca;
                                    }
                                    if (yordamchi[j].Ca > ob.list[19].max)
                                    {
                                        ob.list[19].max = yordamchi[j].Ca;
                                    }
                                }

                                if (tfor_pdk[20] && yordamchi[j].Mg != -1)
                                {
                                    ob.list[20].umumiy++;
                                    yordamchi[j].Mg /= koms[20].PDK;
                                    ob.list[20].ortacha += yordamchi[j].Mg;
                                    if (yordamchi[j].Mg < ob.list[20].min)
                                    {
                                        ob.list[20].min = yordamchi[j].Mg;
                                    }
                                    if (yordamchi[j].Mg > ob.list[20].max)
                                    {
                                        ob.list[20].max = yordamchi[j].Mg;
                                    }
                                }

                                if (tfor_pdk[21] && yordamchi[j].Mineral != -1)
                                {
                                    ob.list[21].umumiy++;
                                    yordamchi[j].Mineral /= koms[21].PDK;
                                    ob.list[21].ortacha += yordamchi[j].Mineral;
                                    if (yordamchi[j].Mineral < ob.list[21].min)
                                    {
                                        ob.list[21].min = yordamchi[j].Mineral;
                                    }
                                    if (yordamchi[j].Mineral > ob.list[21].max)
                                    {
                                        ob.list[21].max = yordamchi[j].Mineral;
                                    }
                                }

                                if (tfor_pdk[22] && yordamchi[j].XPK != -1)
                                {
                                    ob.list[22].umumiy++;
                                    ob.list[22].ortacha += yordamchi[j].XPK;
                                    if (yordamchi[j].XPK < ob.list[22].min)
                                    {
                                        ob.list[22].min = yordamchi[j].XPK;
                                    }
                                    if (yordamchi[j].XPK > ob.list[22].max)
                                    {
                                        ob.list[22].max = yordamchi[j].XPK;
                                    }
                                }

                                if (tfor_pdk[23] && yordamchi[j].BPK != -1)
                                {
                                    ob.list[23].umumiy++;
                                    yordamchi[j].BPK /= koms[23].PDK;
                                    ob.list[23].ortacha += yordamchi[j].BPK;
                                    if (yordamchi[j].BPK < ob.list[23].min)
                                    {
                                        ob.list[23].min = yordamchi[j].BPK;
                                    }
                                    if (yordamchi[j].BPK > ob.list[23].max)
                                    {
                                        ob.list[23].max = yordamchi[j].BPK;
                                    }
                                }

                                if (tfor_pdk[24] && yordamchi[j].AzotAmonniy != -1)
                                {
                                    ob.list[24].umumiy++;
                                    yordamchi[j].AzotAmonniy /= koms[24].PDK;
                                    ob.list[24].ortacha += yordamchi[j].AzotAmonniy;
                                    if (yordamchi[j].AzotAmonniy < ob.list[24].min)
                                    {
                                        ob.list[24].min = yordamchi[j].AzotAmonniy;
                                    }
                                    if (yordamchi[j].AzotAmonniy > ob.list[24].max)
                                    {
                                        ob.list[24].max = yordamchi[j].AzotAmonniy;
                                    }
                                }

                                if (tfor_pdk[25] && yordamchi[j].AzotNitritniy != -1)
                                {
                                    ob.list[25].umumiy++;
                                    yordamchi[j].AzotNitritniy /= koms[25].PDK;
                                    ob.list[25].ortacha += yordamchi[j].AzotNitritniy;
                                    if (yordamchi[j].AzotNitritniy < ob.list[25].min)
                                    {
                                        ob.list[25].min = yordamchi[j].AzotNitritniy;
                                    }
                                    if (yordamchi[j].AzotNitritniy > ob.list[25].max)
                                    {
                                        ob.list[25].max = yordamchi[j].AzotNitritniy;
                                    }
                                }

                                if (tfor_pdk[26] && yordamchi[j].AzotNitratniy != -1)
                                {
                                    ob.list[26].umumiy++;
                                    yordamchi[j].AzotNitratniy /= koms[26].PDK;
                                    ob.list[26].ortacha += yordamchi[j].AzotNitratniy;
                                    if (yordamchi[j].AzotNitratniy < ob.list[26].min)
                                    {
                                        ob.list[26].min = yordamchi[j].AzotNitratniy;
                                    }
                                    if (yordamchi[j].AzotNitratniy > ob.list[26].max)
                                    {
                                        ob.list[26].max = yordamchi[j].AzotNitratniy;
                                    }
                                }

                                if (tfor_pdk[27] && yordamchi[j].AzotSumma != -1)
                                {
                                    ob.list[27].umumiy++;
                                    ob.list[27].ortacha += yordamchi[j].AzotSumma;
                                    if (yordamchi[j].AzotSumma < ob.list[27].min)
                                    {
                                        ob.list[27].min = yordamchi[j].AzotSumma;
                                    }
                                    if (yordamchi[j].AzotSumma > ob.list[27].max)
                                    {
                                        ob.list[27].max = yordamchi[j].AzotSumma;
                                    }
                                }

                                if (tfor_pdk[28] && yordamchi[j].Fosfat != -1)
                                {
                                    ob.list[28].umumiy++;
                                    yordamchi[j].Fosfat /= koms[28].PDK;
                                    ob.list[28].ortacha += yordamchi[j].Fosfat;
                                    if (yordamchi[j].Fosfat < ob.list[28].min)
                                    {
                                        ob.list[28].min = yordamchi[j].Fosfat;
                                    }
                                    if (yordamchi[j].Fosfat > ob.list[28].max)
                                    {
                                        ob.list[28].max = yordamchi[j].Fosfat;
                                    }
                                }

                                if (tfor_pdk[29] && yordamchi[j].Si != -1)
                                {
                                    ob.list[29].umumiy++;
                                    ob.list[29].ortacha += yordamchi[j].Si;
                                    if (yordamchi[j].Si < ob.list[29].min)
                                    {
                                        ob.list[29].min = yordamchi[j].Si;
                                    }
                                    if (yordamchi[j].Si > ob.list[29].max)
                                    {
                                        ob.list[29].max = yordamchi[j].Si;
                                    }
                                }

                                if (tfor_pdk[30] && yordamchi[j].Elektr != -1)
                                {
                                    ob.list[30].umumiy++;
                                    ob.list[30].ortacha += yordamchi[j].Elektr;
                                    if (yordamchi[j].Elektr < ob.list[30].min)
                                    {
                                        ob.list[30].min = yordamchi[j].Elektr;
                                    }
                                    if (yordamchi[j].Elektr > ob.list[30].max)
                                    {
                                        ob.list[30].max = yordamchi[j].Elektr;
                                    }
                                }

                                if (tfor_pdk[31] && yordamchi[j].Eh_MB != -1)
                                {
                                    ob.list[31].umumiy++;
                                    ob.list[31].ortacha += yordamchi[j].Eh_MB;
                                    if (yordamchi[j].Eh_MB < ob.list[32].min)
                                    {
                                        ob.list[32].min = yordamchi[j].Eh_MB;
                                    }
                                    if (yordamchi[j].Eh_MB > ob.list[32].max)
                                    {
                                        ob.list[32].max = yordamchi[j].Eh_MB;
                                    }
                                }

                                if (tfor_pdk[32] && yordamchi[j].PUmumiy != -1)
                                {
                                    ob.list[32].umumiy++;
                                    yordamchi[j].PUmumiy /= koms[32].PDK;
                                    ob.list[32].ortacha += yordamchi[j].PUmumiy;
                                    if (yordamchi[j].PUmumiy < ob.list[32].min)
                                    {
                                        ob.list[32].min = yordamchi[j].PUmumiy;
                                    }
                                    if (yordamchi[j].PUmumiy > ob.list[32].max)
                                    {
                                        ob.list[32].max = yordamchi[j].PUmumiy;
                                    }
                                }

                                if (tfor_pdk[33] && yordamchi[j].FeUmumiy != -1)
                                {
                                    ob.list[33].umumiy++;
                                    yordamchi[j].FeUmumiy /= koms[33].PDK;
                                    ob.list[33].ortacha += yordamchi[j].FeUmumiy;
                                    if (yordamchi[j].FeUmumiy < ob.list[33].min)
                                    {
                                        ob.list[33].min = yordamchi[j].FeUmumiy;
                                    }
                                    if (yordamchi[j].FeUmumiy > ob.list[1].max)
                                    {
                                        ob.list[33].max = yordamchi[j].FeUmumiy;
                                    }
                                }

                                if (tfor_pdk[34] && yordamchi[j].Ci != -1)
                                {
                                    ob.list[34].umumiy++;
                                    yordamchi[j].Ci /= koms[34].PDK;
                                    ob.list[34].ortacha += yordamchi[j].Ci;
                                    if (yordamchi[j].Ci < ob.list[34].min)
                                    {
                                        ob.list[34].min = yordamchi[j].Ci;
                                    }
                                    if (yordamchi[j].Ci > ob.list[34].max)
                                    {
                                        ob.list[34].max = yordamchi[j].Ci;
                                    }
                                }

                                if (tfor_pdk[35] && yordamchi[j].Zn != -1)
                                {
                                    ob.list[35].umumiy++;
                                    yordamchi[j].Zn /= koms[35].PDK;
                                    ob.list[35].ortacha += yordamchi[j].Zn;
                                    if (yordamchi[j].Zn < ob.list[35].min)
                                    {
                                        ob.list[35].min = yordamchi[j].Zn;
                                    }
                                    if (yordamchi[j].Zn > ob.list[35].max)
                                    {
                                        ob.list[35].max = yordamchi[j].Zn;
                                    }
                                }

                                if (tfor_pdk[36] && yordamchi[j].Ni != -1)
                                {
                                    ob.list[36].umumiy++;
                                    yordamchi[j].Ni /= koms[36].PDK;
                                    ob.list[36].ortacha += yordamchi[j].Ni;
                                    if (yordamchi[j].Ni < ob.list[36].min)
                                    {
                                        ob.list[36].min = yordamchi[j].Ni;
                                    }
                                    if (yordamchi[j].Ni > ob.list[36].max)
                                    {
                                        ob.list[36].max = yordamchi[j].Ni;
                                    }
                                }

                                if (tfor_pdk[37] && yordamchi[j].Cr != -1)
                                {
                                    ob.list[37].umumiy++;
                                    ob.list[37].ortacha += yordamchi[j].Cr;
                                    if (yordamchi[j].Cr < ob.list[37].min)
                                    {
                                        ob.list[37].min = yordamchi[j].Cr;
                                    }
                                    if (yordamchi[j].Cr > ob.list[37].max)
                                    {
                                        ob.list[1].max = yordamchi[j].Cr;
                                    }
                                }

                                if (tfor_pdk[38] && yordamchi[j].Cr_VI != -1)
                                {
                                    ob.list[38].umumiy++;
                                    yordamchi[j].Cr_VI /= koms[38].PDK;
                                    ob.list[38].ortacha += yordamchi[j].Cr_VI;
                                    if (yordamchi[j].Cr_VI < ob.list[38].min)
                                    {
                                        ob.list[38].min = yordamchi[j].Cr_VI;
                                    }
                                    if (yordamchi[j].Cr_VI > ob.list[38].max)
                                    {
                                        ob.list[38].max = yordamchi[j].Cr_VI;
                                    }
                                }

                                if (tfor_pdk[39] && yordamchi[j].Cr_III != -1)
                                {
                                    ob.list[39].umumiy++;
                                    ob.list[39].ortacha += yordamchi[j].Cr_III;
                                    if (yordamchi[j].Cr_III < ob.list[39].min)
                                    {
                                        ob.list[39].min = yordamchi[j].Cr_III;
                                    }
                                    if (yordamchi[j].Cr_III > ob.list[39].max)
                                    {
                                        ob.list[39].max = yordamchi[j].Cr_III;
                                    }
                                }

                                if (tfor_pdk[40] && yordamchi[j].Pb != -1)
                                {
                                    ob.list[40].umumiy++;
                                    yordamchi[j].Pb /= koms[40].PDK;
                                    ob.list[40].ortacha += yordamchi[j].Pb;
                                    if (yordamchi[j].Pb < ob.list[40].min)
                                    {
                                        ob.list[40].min = yordamchi[j].Pb;
                                    }
                                    if (yordamchi[j].Pb > ob.list[40].max)
                                    {
                                        ob.list[40].max = yordamchi[j].Pb;
                                    }
                                }

                                if (tfor_pdk[41] && yordamchi[j].Hg != -1)
                                {
                                    ob.list[41].umumiy++;
                                    yordamchi[j].Hg /= koms[41].PDK;
                                    ob.list[41].ortacha += yordamchi[j].Hg;
                                    if (yordamchi[j].Hg < ob.list[41].min)
                                    {
                                        ob.list[41].min = yordamchi[j].Hg;
                                    }
                                    if (yordamchi[j].Hg > ob.list[41].max)
                                    {
                                        ob.list[41].max = yordamchi[j].Hg;
                                    }
                                }

                                if (tfor_pdk[42] && yordamchi[j].Cd != -1)
                                {
                                    ob.list[42].umumiy++;
                                    yordamchi[j].Cd /= koms[42].PDK;
                                    ob.list[42].ortacha += yordamchi[j].Cd;
                                    if (yordamchi[j].Cd < ob.list[42].min)
                                    {
                                        ob.list[42].min = yordamchi[j].Cd;
                                    }
                                    if (yordamchi[j].Cd > ob.list[42].max)
                                    {
                                        ob.list[42].max = yordamchi[j].Cd;
                                    }
                                }

                                if (tfor_pdk[43] && yordamchi[j].Mn != -1)
                                {
                                    ob.list[43].umumiy++;
                                    ob.list[43].ortacha += yordamchi[j].Mn;
                                    if (yordamchi[j].Mn < ob.list[43].min)
                                    {
                                        ob.list[43].min = yordamchi[j].Mn;
                                    }
                                    if (yordamchi[j].Mn > ob.list[43].max)
                                    {
                                        ob.list[43].max = yordamchi[j].Mn;
                                    }
                                }

                                if (tfor_pdk[44] && yordamchi[j].As != -1)
                                {
                                    ob.list[44].umumiy++;
                                    yordamchi[j].As /= koms[44].PDK;
                                    ob.list[44].ortacha += yordamchi[j].As;
                                    if (yordamchi[j].As < ob.list[44].min)
                                    {
                                        ob.list[44].min = yordamchi[j].As;
                                    }
                                    if (yordamchi[j].As > ob.list[44].max)
                                    {
                                        ob.list[44].max = yordamchi[j].As;
                                    }
                                }

                                if (tfor_pdk[45] && yordamchi[j].Fenollar != -1)
                                {
                                    ob.list[45].umumiy++;
                                    yordamchi[j].Fenollar /= koms[45].PDK;
                                    ob.list[45].ortacha += yordamchi[j].Fenollar;
                                    if (yordamchi[j].Fenollar < ob.list[45].min)
                                    {
                                        ob.list[45].min = yordamchi[j].Fenollar;
                                    }
                                    if (yordamchi[j].Fenollar > ob.list[45].max)
                                    {
                                        ob.list[45].max = yordamchi[j].Fenollar;
                                    }
                                }

                                if (tfor_pdk[46] && yordamchi[j].Neft != -1)
                                {
                                    ob.list[46].umumiy++;
                                    yordamchi[j].Neft /= koms[46].PDK;
                                    ob.list[46].ortacha += yordamchi[j].Neft;
                                    if (yordamchi[j].Neft < ob.list[46].min)
                                    {
                                        ob.list[46].min = yordamchi[j].Neft;
                                    }
                                    if (yordamchi[j].Neft > ob.list[46].max)
                                    {
                                        ob.list[46].max = yordamchi[j].Neft;
                                    }
                                }

                                if (tfor_pdk[47] && yordamchi[j].SPAB != -1)
                                {
                                    ob.list[47].umumiy++;
                                    yordamchi[j].SPAB /= koms[47].PDK;
                                    ob.list[47].ortacha += yordamchi[j].SPAB;
                                    if (yordamchi[j].SPAB < ob.list[47].min)
                                    {
                                        ob.list[47].min = yordamchi[j].SPAB;
                                    }
                                    if (yordamchi[j].SPAB > ob.list[47].max)
                                    {
                                        ob.list[47].max = yordamchi[j].SPAB;
                                    }
                                }

                                if (tfor_pdk[48] && yordamchi[j].F != -1)
                                {
                                    ob.list[48].umumiy++;
                                    yordamchi[j].F /= koms[48].PDK;
                                    ob.list[48].ortacha += yordamchi[j].F;
                                    if (yordamchi[j].F < ob.list[48].min)
                                    {
                                        ob.list[48].min = yordamchi[j].F;
                                    }
                                    if (yordamchi[j].F > ob.list[48].max)
                                    {
                                        ob.list[48].max = yordamchi[j].F;
                                    }
                                }

                                if (tfor_pdk[49] && yordamchi[j].Sianidi != -1)
                                {
                                    ob.list[49].umumiy++;
                                    yordamchi[j].Sianidi /= koms[49].PDK;
                                    ob.list[49].ortacha += yordamchi[j].Sianidi;
                                    if (yordamchi[j].Sianidi < ob.list[49].min)
                                    {
                                        ob.list[49].min = yordamchi[j].Sianidi;
                                    }
                                    if (yordamchi[j].Sianidi > ob.list[49].max)
                                    {
                                        ob.list[49].max = yordamchi[j].Sianidi;
                                    }
                                }

                                if (tfor_pdk[50] && yordamchi[j].Proponil != -1)
                                {
                                    ob.list[50].umumiy++;
                                    ob.list[50].ortacha += yordamchi[j].Proponil;
                                    if (yordamchi[j].Proponil < ob.list[50].min)
                                    {
                                        ob.list[50].min = yordamchi[j].Proponil;
                                    }
                                    if (yordamchi[j].Proponil > ob.list[50].max)
                                    {
                                        ob.list[50].max = yordamchi[j].Proponil;
                                    }
                                }

                                if (tfor_pdk[51] && yordamchi[j].DDE != -1)
                                {
                                    ob.list[51].umumiy++;
                                    ob.list[51].ortacha += yordamchi[j].DDE;
                                    if (yordamchi[j].DDE < ob.list[51].min)
                                    {
                                        ob.list[51].min = yordamchi[j].DDE;
                                    }
                                    if (yordamchi[j].DDE > ob.list[51].max)
                                    {
                                        ob.list[51].max = yordamchi[j].DDE;
                                    }
                                }

                                if (tfor_pdk[52] && yordamchi[j].Rogor != -1)
                                {
                                    ob.list[52].umumiy++;
                                    ob.list[52].ortacha += yordamchi[j].Rogor;
                                    if (yordamchi[j].Rogor < ob.list[52].min)
                                    {
                                        ob.list[52].min = yordamchi[j].Rogor;
                                    }
                                    if (yordamchi[j].Rogor > ob.list[52].max)
                                    {
                                        ob.list[52].max = yordamchi[j].Rogor;
                                    }
                                }

                                if (tfor_pdk[53] && yordamchi[j].DDT != -1)
                                {
                                    ob.list[53].umumiy++;
                                    yordamchi[j].DDT /= koms[53].PDK;
                                    ob.list[53].ortacha += yordamchi[j].DDT;
                                    if (yordamchi[j].DDT < ob.list[53].min)
                                    {
                                        ob.list[53].min = yordamchi[j].DDT;
                                    }
                                    if (yordamchi[j].DDT > ob.list[53].max)
                                    {
                                        ob.list[53].max = yordamchi[j].DDT;
                                    }
                                }

                                if (tfor_pdk[54] && yordamchi[j].Geksaxloran != -1)
                                {
                                    ob.list[54].umumiy++;
                                    yordamchi[j].Geksaxloran /= koms[54].PDK;
                                    ob.list[54].ortacha += yordamchi[j].Geksaxloran;
                                    if (yordamchi[j].Geksaxloran < ob.list[54].min)
                                    {
                                        ob.list[54].min = yordamchi[j].Geksaxloran;
                                    }
                                    if (yordamchi[j].Geksaxloran > ob.list[54].max)
                                    {
                                        ob.list[54].max = yordamchi[j].Geksaxloran;
                                    }
                                }

                                if (tfor_pdk[55] && yordamchi[j].Lindan != -1)
                                {
                                    ob.list[55].umumiy++;
                                    yordamchi[j].Lindan /= koms[55].PDK;
                                    ob.list[55].ortacha += yordamchi[j].Lindan;
                                    if (yordamchi[j].Lindan < ob.list[55].min)
                                    {
                                        ob.list[55].min = yordamchi[j].Lindan;
                                    }
                                    if (yordamchi[j].Lindan > ob.list[55].max)
                                    {
                                        ob.list[55].max = yordamchi[j].Lindan;
                                    }
                                }

                                if (tfor_pdk[56] && yordamchi[j].DDD != -1)
                                {
                                    ob.list[56].umumiy++;
                                    ob.list[56].ortacha += yordamchi[j].DDD;
                                    if (yordamchi[j].DDD < ob.list[56].min)
                                    {
                                        ob.list[56].min = yordamchi[j].DDD;
                                    }
                                    if (yordamchi[j].DDD > ob.list[56].max)
                                    {
                                        ob.list[56].max = yordamchi[j].DDD;
                                    }
                                }

                                if (tfor_pdk[57] && yordamchi[j].Metafos != -1)
                                {
                                    ob.list[57].umumiy++;
                                    ob.list[57].ortacha += yordamchi[j].Metafos;
                                    if (yordamchi[j].Metafos < ob.list[57].min)
                                    {
                                        ob.list[57].min = yordamchi[j].Metafos;
                                    }
                                    if (yordamchi[j].Metafos > ob.list[57].max)
                                    {
                                        ob.list[57].max = yordamchi[j].Metafos;
                                    }
                                }

                                if (tfor_pdk[58] && yordamchi[j].Butifos != -1)
                                {
                                    ob.list[58].umumiy++;
                                    ob.list[58].ortacha += yordamchi[j].Butifos;
                                    if (yordamchi[j].Butifos < ob.list[1].min)
                                    {
                                        ob.list[58].min = yordamchi[j].Butifos;
                                    }
                                    if (yordamchi[j].Butifos > ob.list[1].max)
                                    {
                                        ob.list[58].max = yordamchi[j].Butifos;
                                    }
                                }

                                if (tfor_pdk[59] && yordamchi[j].Dalapon != -1)
                                {
                                    ob.list[59].umumiy++;
                                    ob.list[59].ortacha += yordamchi[j].Dalapon;
                                    if (yordamchi[j].Dalapon < ob.list[59].min)
                                    {
                                        ob.list[59].min = yordamchi[j].Dalapon;
                                    }
                                    if (yordamchi[j].Dalapon > ob.list[59].max)
                                    {
                                        ob.list[59].max = yordamchi[j].Dalapon;
                                    }
                                }

                                if (tfor_pdk[60] && yordamchi[j].Karbofos != -1)
                                {
                                    ob.list[60].umumiy++;
                                    ob.list[60].ortacha += yordamchi[j].Karbofos;
                                    if (yordamchi[j].Karbofos < ob.list[60].min)
                                    {
                                        ob.list[60].min = yordamchi[j].Karbofos;
                                    }
                                    if (yordamchi[j].Karbofos > ob.list[60].max)
                                    {
                                        ob.list[60].max = yordamchi[j].Karbofos;
                                    }
                                }
                            }
                        }

                        result1.Add(ob);
                    }

                    HisobotPDKForm form1 = new HisobotPDKForm(result1, result, koms, tfor_pdk, Year, 2);
                    form1.ShowDialog();
                }
                else
                {
                    HisobotPDKForm form1 = new HisobotPDKForm(result, koms, tfor_pdk, Year, 2);
                    form1.ShowDialog();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void пДКпоБассейнамРекВДоляхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] tfor_pdk;
                YearFormForPDK form = new YearFormForPDK(koms);
                form.ShowDialog();

                int Year = form.Year;
                if (Year <= 0)
                    return;
                tfor_pdk = form.t;
                bool LastYear = form.LastYear;

                string strquery = "Select *From Analysis Where Sana>#31/12/" + (Year - 1).ToString() + "# And Sana<#01/01/" + (Year + 1).ToString() + "#";
                List<AnalysisClass> list = GetAnalysisList(strquery);
                List<HisobotPostPDK> result = new List<HisobotPostPDK>();
                for (int k = 0; k < rivers.Count; k++)
                {
                    List<PostClass> postyordam = posts.Where(x => x.River_Id == rivers[k].Id).ToList();
                    List<AnalysisClass> yordamchi = new List<AnalysisClass>();

                    for (int i = 0; i < postyordam.Count; i++)
                    {
                        yordamchi.AddRange(list.Where(x => x.Post_Id == postyordam[i].Id));
                    }

                    HisobotPostPDK ob = new HisobotPostPDK(koms);
                    ob.post = rivers[k].Name;

                    if (yordamchi.Count > 0)
                    {
                        for (int j = 0; j < yordamchi.Count; j++)
                        {
                            if (tfor_pdk[0] && yordamchi[j].Sigm != -1)
                            {
                                ob.list[0].umumiy++;
                                ob.list[0].ortacha += yordamchi[j].Sigm;
                                if (yordamchi[j].Sigm < ob.list[0].min)
                                {
                                    ob.list[0].min = yordamchi[j].Sigm;
                                }
                                if (yordamchi[j].Sigm > ob.list[0].max)
                                {
                                    ob.list[0].max = yordamchi[j].Sigm;
                                }
                            }

                            if (tfor_pdk[1] && yordamchi[j].OqimTezligi != -1)
                            {
                                ob.list[1].umumiy++;
                                ob.list[1].ortacha += yordamchi[j].OqimTezligi;

                                if (yordamchi[j].OqimTezligi < ob.list[1].min)
                                {
                                    ob.list[1].min = yordamchi[j].OqimTezligi;
                                }
                                if (yordamchi[j].OqimTezligi > ob.list[1].max)
                                {
                                    ob.list[1].max = yordamchi[j].OqimTezligi;
                                }
                            }

                            if (tfor_pdk[2] && yordamchi[j].DaryoSarfi != -1)
                            {
                                ob.list[2].umumiy++;
                                ob.list[2].ortacha += yordamchi[j].DaryoSarfi;
                                if (yordamchi[j].DaryoSarfi < ob.list[2].min)
                                {
                                    ob.list[2].min = yordamchi[j].DaryoSarfi;
                                }
                                if (yordamchi[j].DaryoSarfi > ob.list[2].max)
                                {
                                    ob.list[2].max = yordamchi[j].DaryoSarfi;
                                }
                            }

                            if (tfor_pdk[3] && yordamchi[j].OqimSarfi != -1)
                            {
                                ob.list[3].umumiy++;
                                ob.list[3].ortacha += yordamchi[j].OqimSarfi;
                                if (yordamchi[j].OqimSarfi < ob.list[3].min)
                                {
                                    ob.list[3].min = yordamchi[j].OqimSarfi;
                                }
                                if (yordamchi[j].OqimSarfi > ob.list[3].max)
                                {
                                    ob.list[3].max = yordamchi[j].OqimSarfi;
                                }
                            }

                            if (tfor_pdk[4] && yordamchi[j].Namlik != -1)
                            {
                                ob.list[4].umumiy++;
                                ob.list[4].ortacha += yordamchi[j].Namlik;
                                if (yordamchi[j].Namlik < ob.list[4].min)
                                {
                                    ob.list[4].min = yordamchi[j].Namlik;
                                }
                                if (yordamchi[j].Namlik > ob.list[4].max)
                                {
                                    ob.list[4].max = yordamchi[j].Namlik;
                                }
                            }

                            if (tfor_pdk[5] && yordamchi[j].Tiniqlik != -1)
                            {
                                ob.list[5].umumiy++;
                                ob.list[5].ortacha += yordamchi[j].Tiniqlik;
                                if (yordamchi[j].OqimTezligi < ob.list[5].min)
                                {
                                    ob.list[5].min = yordamchi[j].OqimTezligi;
                                }
                                if (yordamchi[j].OqimTezligi > ob.list[5].max)
                                {
                                    ob.list[5].max = yordamchi[j].OqimTezligi;
                                }
                            }

                            if (tfor_pdk[6] && yordamchi[j].Rangi != -1)
                            {
                                ob.list[6].umumiy++;
                                ob.list[6].ortacha += yordamchi[j].Rangi;
                                if (yordamchi[j].Rangi < ob.list[6].min)
                                {
                                    ob.list[6].min = yordamchi[j].Rangi;
                                }
                                if (yordamchi[j].Rangi > ob.list[6].max)
                                {
                                    ob.list[6].max = yordamchi[j].Rangi;
                                }
                            }

                            if (tfor_pdk[7] && yordamchi[j].Harorat != -1)
                            {
                                ob.list[7].umumiy++;
                                ob.list[7].ortacha += yordamchi[j].Harorat;
                                if (yordamchi[j].Harorat < ob.list[7].min)
                                {
                                    ob.list[7].min = yordamchi[j].Harorat;
                                }
                                if (yordamchi[j].Harorat > ob.list[7].max)
                                {
                                    ob.list[7].max = yordamchi[j].Harorat;
                                }
                            }

                            if (tfor_pdk[8] && yordamchi[j].Suzuvchi != -1)
                            {
                                ob.list[8].umumiy++;
                                ob.list[8].ortacha += yordamchi[j].Suzuvchi;
                                if (yordamchi[j].Suzuvchi < ob.list[8].min)
                                {
                                    ob.list[8].min = yordamchi[j].Suzuvchi;
                                }
                                if (yordamchi[j].Suzuvchi > ob.list[8].max)
                                {
                                    ob.list[8].max = yordamchi[j].Suzuvchi;
                                }
                            }

                            if (tfor_pdk[9] && yordamchi[j].pH != -1)
                            {
                                ob.list[9].umumiy++;
                                //yordamchi[j].pH /= koms[9].PDK;
                                ob.list[9].ortacha += yordamchi[j].pH;
                                if (yordamchi[j].pH < ob.list[9].min)
                                {
                                    ob.list[9].min = yordamchi[j].pH;
                                }
                                if (yordamchi[j].pH > ob.list[9].max)
                                {
                                    ob.list[9].max = yordamchi[j].pH;
                                }
                            }

                            if (tfor_pdk[10] && yordamchi[j].O2 != -1)
                            {
                                ob.list[10].umumiy++;
                                //yordamchi[j].O2 /= koms[10].PDK;
                                ob.list[10].ortacha += yordamchi[j].O2;
                                if (yordamchi[j].O2 < ob.list[10].min)
                                {
                                    ob.list[10].min = yordamchi[j].O2;
                                }
                                if (yordamchi[j].O2 > ob.list[10].max)
                                {
                                    ob.list[10].max = yordamchi[j].O2;
                                }
                            }

                            if (tfor_pdk[11] && yordamchi[j].Tuyingan != -1)
                            {
                                ob.list[11].umumiy++;
                                ob.list[11].ortacha += yordamchi[j].Tuyingan;
                                if (yordamchi[j].Tuyingan < ob.list[11].min)
                                {
                                    ob.list[11].min = yordamchi[j].Tuyingan;
                                }
                                if (yordamchi[j].Tuyingan > ob.list[11].max)
                                {
                                    ob.list[11].max = yordamchi[j].Tuyingan;
                                }
                            }

                            if (tfor_pdk[12] && yordamchi[j].CO2 != -1)
                            {
                                ob.list[12].umumiy++;
                                ob.list[12].ortacha += yordamchi[j].CO2;
                                if (yordamchi[j].CO2 < ob.list[12].min)
                                {
                                    ob.list[12].min = yordamchi[j].CO2;
                                }
                                if (yordamchi[j].CO2 > ob.list[12].max)
                                {
                                    ob.list[12].max = yordamchi[j].CO2;
                                }
                            }

                            if (tfor_pdk[13] && yordamchi[j].Qattiqlik != -1)
                            {
                                ob.list[13].umumiy++;
                                //yordamchi[j].Qattiqlik /= koms[13].PDK;
                                ob.list[13].ortacha += yordamchi[j].Qattiqlik;
                                if (yordamchi[j].Qattiqlik < ob.list[13].min)
                                {
                                    ob.list[13].min = yordamchi[j].Qattiqlik;
                                }
                                if (yordamchi[j].Qattiqlik > ob.list[13].max)
                                {
                                    ob.list[13].max = yordamchi[j].Qattiqlik;
                                }
                            }

                            if (tfor_pdk[14] && yordamchi[j].Xlorid != -1)
                            {
                                ob.list[14].umumiy++;
                                //yordamchi[j].Xlorid /= koms[14].PDK;
                                ob.list[14].ortacha += yordamchi[j].Xlorid;
                                if (yordamchi[j].Xlorid < ob.list[14].min)
                                {
                                    ob.list[14].min = yordamchi[j].Xlorid;
                                }
                                if (yordamchi[j].Xlorid > ob.list[14].max)
                                {
                                    ob.list[14].max = yordamchi[j].Xlorid;
                                }
                            }

                            if (tfor_pdk[15] && yordamchi[j].Sulfat != -1)
                            {
                                ob.list[15].umumiy++;
                                //yordamchi[j].Sulfat /= koms[15].PDK;
                                ob.list[15].ortacha += yordamchi[j].Sulfat;
                                if (yordamchi[j].Sulfat < ob.list[15].min)
                                {
                                    ob.list[15].min = yordamchi[j].Sulfat;
                                }
                                if (yordamchi[j].Sulfat > ob.list[15].max)
                                {
                                    ob.list[15].max = yordamchi[j].Sulfat;
                                }
                            }

                            if (tfor_pdk[16] && yordamchi[j].GidroKarbanat != -1)
                            {
                                ob.list[16].umumiy++;
                                ob.list[16].ortacha += yordamchi[j].GidroKarbanat;
                                if (yordamchi[j].GidroKarbanat < ob.list[16].min)
                                {
                                    ob.list[16].min = yordamchi[j].GidroKarbanat;
                                }
                                if (yordamchi[j].GidroKarbanat > ob.list[16].max)
                                {
                                    ob.list[16].max = yordamchi[j].GidroKarbanat;
                                }
                            }

                            if (tfor_pdk[17] && yordamchi[j].Na != -1)
                            {
                                ob.list[17].umumiy++;
                                //yordamchi[j].Na /= koms[17].PDK;
                                ob.list[17].ortacha += yordamchi[j].Na;
                                if (yordamchi[j].Na < ob.list[17].min)
                                {
                                    ob.list[17].min = yordamchi[j].Na;
                                }
                                if (yordamchi[j].Na > ob.list[17].max)
                                {
                                    ob.list[17].max = yordamchi[j].Na;
                                }
                            }

                            if (tfor_pdk[18] && yordamchi[j].K != -1)
                            {
                                ob.list[18].umumiy++;
                                //yordamchi[j].K /= koms[18].PDK;
                                ob.list[18].ortacha += yordamchi[j].K;
                                if (yordamchi[j].K < ob.list[18].min)
                                {
                                    ob.list[18].min = yordamchi[j].K;
                                }
                                if (yordamchi[j].K > ob.list[18].max)
                                {
                                    ob.list[18].max = yordamchi[j].K;
                                }
                            }

                            if (tfor_pdk[19] && yordamchi[j].Ca != -1)
                            {
                                ob.list[19].umumiy++;
                                //yordamchi[j].Ca /= koms[19].PDK;
                                ob.list[19].ortacha += yordamchi[j].Ca;
                                if (yordamchi[j].Ca < ob.list[19].min)
                                {
                                    ob.list[19].min = yordamchi[j].Ca;
                                }
                                if (yordamchi[j].Ca > ob.list[19].max)
                                {
                                    ob.list[19].max = yordamchi[j].Ca;
                                }
                            }

                            if (tfor_pdk[20] && yordamchi[j].Mg != -1)
                            {
                                ob.list[20].umumiy++;
                                yordamchi[j].Mg /= koms[20].PDK;
                                //ob.list[20].ortacha += yordamchi[j].Mg;
                                if (yordamchi[j].Mg < ob.list[20].min)
                                {
                                    ob.list[20].min = yordamchi[j].Mg;
                                }
                                if (yordamchi[j].Mg > ob.list[20].max)
                                {
                                    ob.list[20].max = yordamchi[j].Mg;
                                }
                            }

                            if (tfor_pdk[21] && yordamchi[j].Mineral != -1)
                            {
                                ob.list[21].umumiy++;
                                //yordamchi[j].Mineral /= koms[21].PDK;
                                ob.list[21].ortacha += yordamchi[j].Mineral;
                                if (yordamchi[j].Mineral < ob.list[21].min)
                                {
                                    ob.list[21].min = yordamchi[j].Mineral;
                                }
                                if (yordamchi[j].Mineral > ob.list[21].max)
                                {
                                    ob.list[21].max = yordamchi[j].Mineral;
                                }
                            }

                            if (tfor_pdk[22] && yordamchi[j].XPK != -1)
                            {
                                ob.list[22].umumiy++;
                                ob.list[22].ortacha += yordamchi[j].XPK;
                                if (yordamchi[j].XPK < ob.list[22].min)
                                {
                                    ob.list[22].min = yordamchi[j].XPK;
                                }
                                if (yordamchi[j].XPK > ob.list[22].max)
                                {
                                    ob.list[22].max = yordamchi[j].XPK;
                                }
                            }

                            if (tfor_pdk[23] && yordamchi[j].BPK != -1)
                            {
                                ob.list[23].umumiy++;
                                //yordamchi[j].BPK /= koms[23].PDK;
                                ob.list[23].ortacha += yordamchi[j].BPK;
                                if (yordamchi[j].BPK < ob.list[23].min)
                                {
                                    ob.list[23].min = yordamchi[j].BPK;
                                }
                                if (yordamchi[j].BPK > ob.list[23].max)
                                {
                                    ob.list[23].max = yordamchi[j].BPK;
                                }
                            }

                            if (tfor_pdk[24] && yordamchi[j].AzotAmonniy != -1)
                            {
                                ob.list[24].umumiy++;
                                //yordamchi[j].AzotAmonniy /= koms[24].PDK;
                                ob.list[24].ortacha += yordamchi[j].AzotAmonniy;
                                if (yordamchi[j].AzotAmonniy < ob.list[24].min)
                                {
                                    ob.list[24].min = yordamchi[j].AzotAmonniy;
                                }
                                if (yordamchi[j].AzotAmonniy > ob.list[24].max)
                                {
                                    ob.list[24].max = yordamchi[j].AzotAmonniy;
                                }
                            }

                            if (tfor_pdk[25] && yordamchi[j].AzotNitritniy != -1)
                            {
                                ob.list[25].umumiy++;
                                //yordamchi[j].AzotNitritniy /= koms[25].PDK;
                                ob.list[25].ortacha += yordamchi[j].AzotNitritniy;
                                if (yordamchi[j].AzotNitritniy < ob.list[25].min)
                                {
                                    ob.list[25].min = yordamchi[j].AzotNitritniy;
                                }
                                if (yordamchi[j].AzotNitritniy > ob.list[25].max)
                                {
                                    ob.list[25].max = yordamchi[j].AzotNitritniy;
                                }
                            }

                            if (tfor_pdk[26] && yordamchi[j].AzotNitratniy != -1)
                            {
                                ob.list[26].umumiy++;
                                //yordamchi[j].AzotNitratniy /= koms[26].PDK;
                                ob.list[26].ortacha += yordamchi[j].AzotNitratniy;
                                if (yordamchi[j].AzotNitratniy < ob.list[26].min)
                                {
                                    ob.list[26].min = yordamchi[j].AzotNitratniy;
                                }
                                if (yordamchi[j].AzotNitratniy > ob.list[26].max)
                                {
                                    ob.list[26].max = yordamchi[j].AzotNitratniy;
                                }
                            }

                            if (tfor_pdk[27] && yordamchi[j].AzotSumma != -1)
                            {
                                ob.list[27].umumiy++;
                                ob.list[27].ortacha += yordamchi[j].AzotSumma;
                                if (yordamchi[j].AzotSumma < ob.list[27].min)
                                {
                                    ob.list[27].min = yordamchi[j].AzotSumma;
                                }
                                if (yordamchi[j].AzotSumma > ob.list[27].max)
                                {
                                    ob.list[27].max = yordamchi[j].AzotSumma;
                                }
                            }

                            if (tfor_pdk[28] && yordamchi[j].Fosfat != -1)
                            {
                                ob.list[28].umumiy++;
                                //yordamchi[j].Fosfat /= koms[28].PDK;
                                ob.list[28].ortacha += yordamchi[j].Fosfat;
                                if (yordamchi[j].Fosfat < ob.list[28].min)
                                {
                                    ob.list[28].min = yordamchi[j].Fosfat;
                                }
                                if (yordamchi[j].Fosfat > ob.list[28].max)
                                {
                                    ob.list[28].max = yordamchi[j].Fosfat;
                                }
                            }

                            if (tfor_pdk[29] && yordamchi[j].Si != -1)
                            {
                                ob.list[29].umumiy++;
                                ob.list[29].ortacha += yordamchi[j].Si;
                                if (yordamchi[j].Si < ob.list[29].min)
                                {
                                    ob.list[29].min = yordamchi[j].Si;
                                }
                                if (yordamchi[j].Si > ob.list[29].max)
                                {
                                    ob.list[29].max = yordamchi[j].Si;
                                }
                            }

                            if (tfor_pdk[30] && yordamchi[j].Elektr != -1)
                            {
                                ob.list[30].umumiy++;
                                ob.list[30].ortacha += yordamchi[j].Elektr;
                                if (yordamchi[j].Elektr < ob.list[30].min)
                                {
                                    ob.list[30].min = yordamchi[j].Elektr;
                                }
                                if (yordamchi[j].Elektr > ob.list[30].max)
                                {
                                    ob.list[30].max = yordamchi[j].Elektr;
                                }
                            }

                            if (tfor_pdk[31] && yordamchi[j].Eh_MB != -1)
                            {
                                ob.list[31].umumiy++;
                                ob.list[31].ortacha += yordamchi[j].Eh_MB;
                                if (yordamchi[j].Eh_MB < ob.list[32].min)
                                {
                                    ob.list[32].min = yordamchi[j].Eh_MB;
                                }
                                if (yordamchi[j].Eh_MB > ob.list[32].max)
                                {
                                    ob.list[32].max = yordamchi[j].Eh_MB;
                                }
                            }

                            if (tfor_pdk[32] && yordamchi[j].PUmumiy != -1)
                            {
                                ob.list[32].umumiy++;
                                //yordamchi[j].PUmumiy /= koms[32].PDK;
                                ob.list[32].ortacha += yordamchi[j].PUmumiy;
                                if (yordamchi[j].PUmumiy < ob.list[32].min)
                                {
                                    ob.list[32].min = yordamchi[j].PUmumiy;
                                }
                                if (yordamchi[j].PUmumiy > ob.list[32].max)
                                {
                                    ob.list[32].max = yordamchi[j].PUmumiy;
                                }
                            }

                            if (tfor_pdk[33] && yordamchi[j].FeUmumiy != -1)
                            {
                                ob.list[33].umumiy++;
                                //yordamchi[j].FeUmumiy /= koms[33].PDK;
                                ob.list[33].ortacha += yordamchi[j].FeUmumiy;
                                if (yordamchi[j].FeUmumiy < ob.list[33].min)
                                {
                                    ob.list[33].min = yordamchi[j].FeUmumiy;
                                }
                                if (yordamchi[j].FeUmumiy > ob.list[1].max)
                                {
                                    ob.list[33].max = yordamchi[j].FeUmumiy;
                                }
                            }

                            if (tfor_pdk[34] && yordamchi[j].Ci != -1)
                            {
                                ob.list[34].umumiy++;
                                //yordamchi[j].Ci /= koms[34].PDK;
                                ob.list[34].ortacha += yordamchi[j].Ci;
                                if (yordamchi[j].Ci < ob.list[34].min)
                                {
                                    ob.list[34].min = yordamchi[j].Ci;
                                }
                                if (yordamchi[j].Ci > ob.list[34].max)
                                {
                                    ob.list[34].max = yordamchi[j].Ci;
                                }
                            }

                            if (tfor_pdk[35] && yordamchi[j].Zn != -1)
                            {
                                ob.list[35].umumiy++;
                                //yordamchi[j].Zn /= koms[35].PDK;
                                ob.list[35].ortacha += yordamchi[j].Zn;
                                if (yordamchi[j].Zn < ob.list[35].min)
                                {
                                    ob.list[35].min = yordamchi[j].Zn;
                                }
                                if (yordamchi[j].Zn > ob.list[35].max)
                                {
                                    ob.list[35].max = yordamchi[j].Zn;
                                }
                            }

                            if (tfor_pdk[36] && yordamchi[j].Ni != -1)
                            {
                                ob.list[36].umumiy++;
                                //yordamchi[j].Ni /= koms[36].PDK;
                                ob.list[36].ortacha += yordamchi[j].Ni;
                                if (yordamchi[j].Ni < ob.list[36].min)
                                {
                                    ob.list[36].min = yordamchi[j].Ni;
                                }
                                if (yordamchi[j].Ni > ob.list[36].max)
                                {
                                    ob.list[36].max = yordamchi[j].Ni;
                                }
                            }

                            if (tfor_pdk[37] && yordamchi[j].Cr != -1)
                            {
                                ob.list[37].umumiy++;
                                ob.list[37].ortacha += yordamchi[j].Cr;
                                if (yordamchi[j].Cr < ob.list[37].min)
                                {
                                    ob.list[37].min = yordamchi[j].Cr;
                                }
                                if (yordamchi[j].Cr > ob.list[37].max)
                                {
                                    ob.list[1].max = yordamchi[j].Cr;
                                }
                            }

                            if (tfor_pdk[38] && yordamchi[j].Cr_VI != -1)
                            {
                                ob.list[38].umumiy++;
                                //yordamchi[j].Cr_VI /= koms[38].PDK;
                                ob.list[38].ortacha += yordamchi[j].Cr_VI;
                                if (yordamchi[j].Cr_VI < ob.list[38].min)
                                {
                                    ob.list[38].min = yordamchi[j].Cr_VI;
                                }
                                if (yordamchi[j].Cr_VI > ob.list[38].max)
                                {
                                    ob.list[38].max = yordamchi[j].Cr_VI;
                                }
                            }

                            if (tfor_pdk[39] && yordamchi[j].Cr_III != -1)
                            {
                                ob.list[39].umumiy++;
                                ob.list[39].ortacha += yordamchi[j].Cr_III;
                                if (yordamchi[j].Cr_III < ob.list[39].min)
                                {
                                    ob.list[39].min = yordamchi[j].Cr_III;
                                }
                                if (yordamchi[j].Cr_III > ob.list[39].max)
                                {
                                    ob.list[39].max = yordamchi[j].Cr_III;
                                }
                            }

                            if (tfor_pdk[40] && yordamchi[j].Pb != -1)
                            {
                                ob.list[40].umumiy++;
                                //yordamchi[j].Pb /= koms[40].PDK;
                                ob.list[40].ortacha += yordamchi[j].Pb;
                                if (yordamchi[j].Pb < ob.list[40].min)
                                {
                                    ob.list[40].min = yordamchi[j].Pb;
                                }
                                if (yordamchi[j].Pb > ob.list[40].max)
                                {
                                    ob.list[40].max = yordamchi[j].Pb;
                                }
                            }

                            if (tfor_pdk[41] && yordamchi[j].Hg != -1)
                            {
                                ob.list[41].umumiy++;
                                //yordamchi[j].Hg /= koms[41].PDK;
                                ob.list[41].ortacha += yordamchi[j].Hg;
                                if (yordamchi[j].Hg < ob.list[41].min)
                                {
                                    ob.list[41].min = yordamchi[j].Hg;
                                }
                                if (yordamchi[j].Hg > ob.list[41].max)
                                {
                                    ob.list[41].max = yordamchi[j].Hg;
                                }
                            }

                            if (tfor_pdk[42] && yordamchi[j].Cd != -1)
                            {
                                ob.list[42].umumiy++;
                                //yordamchi[j].Cd /= koms[42].PDK;
                                ob.list[42].ortacha += yordamchi[j].Cd;
                                if (yordamchi[j].Cd < ob.list[42].min)
                                {
                                    ob.list[42].min = yordamchi[j].Cd;
                                }
                                if (yordamchi[j].Cd > ob.list[42].max)
                                {
                                    ob.list[42].max = yordamchi[j].Cd;
                                }
                            }

                            if (tfor_pdk[43] && yordamchi[j].Mn != -1)
                            {
                                ob.list[43].umumiy++;
                                ob.list[43].ortacha += yordamchi[j].Mn;
                                if (yordamchi[j].Mn < ob.list[43].min)
                                {
                                    ob.list[43].min = yordamchi[j].Mn;
                                }
                                if (yordamchi[j].Mn > ob.list[43].max)
                                {
                                    ob.list[43].max = yordamchi[j].Mn;
                                }
                            }

                            if (tfor_pdk[44] && yordamchi[j].As != -1)
                            {
                                ob.list[44].umumiy++;
                                //yordamchi[j].As /= koms[44].PDK;
                                ob.list[44].ortacha += yordamchi[j].As;
                                if (yordamchi[j].As < ob.list[44].min)
                                {
                                    ob.list[44].min = yordamchi[j].As;
                                }
                                if (yordamchi[j].As > ob.list[44].max)
                                {
                                    ob.list[44].max = yordamchi[j].As;
                                }
                            }

                            if (tfor_pdk[45] && yordamchi[j].Fenollar != -1)
                            {
                                ob.list[45].umumiy++;
                                //yordamchi[j].Fenollar /= koms[45].PDK;
                                ob.list[45].ortacha += yordamchi[j].Fenollar;
                                if (yordamchi[j].Fenollar < ob.list[45].min)
                                {
                                    ob.list[45].min = yordamchi[j].Fenollar;
                                }
                                if (yordamchi[j].Fenollar > ob.list[45].max)
                                {
                                    ob.list[45].max = yordamchi[j].Fenollar;
                                }
                            }

                            if (tfor_pdk[46] && yordamchi[j].Neft != -1)
                            {
                                ob.list[46].umumiy++;
                                //yordamchi[j].Neft /= koms[46].PDK;
                                ob.list[46].ortacha += yordamchi[j].Neft;
                                if (yordamchi[j].Neft < ob.list[46].min)
                                {
                                    ob.list[46].min = yordamchi[j].Neft;
                                }
                                if (yordamchi[j].Neft > ob.list[46].max)
                                {
                                    ob.list[46].max = yordamchi[j].Neft;
                                }
                            }

                            if (tfor_pdk[47] && yordamchi[j].SPAB != -1)
                            {
                                ob.list[47].umumiy++;
                                //yordamchi[j].SPAB /= koms[47].PDK;
                                ob.list[47].ortacha += yordamchi[j].SPAB;
                                if (yordamchi[j].SPAB < ob.list[47].min)
                                {
                                    ob.list[47].min = yordamchi[j].SPAB;
                                }
                                if (yordamchi[j].SPAB > ob.list[47].max)
                                {
                                    ob.list[47].max = yordamchi[j].SPAB;
                                }
                            }

                            if (tfor_pdk[48] && yordamchi[j].F != -1)
                            {
                                ob.list[48].umumiy++;
                                //yordamchi[j].F /= koms[48].PDK;
                                ob.list[48].ortacha += yordamchi[j].F;
                                if (yordamchi[j].F < ob.list[48].min)
                                {
                                    ob.list[48].min = yordamchi[j].F;
                                }
                                if (yordamchi[j].F > ob.list[48].max)
                                {
                                    ob.list[48].max = yordamchi[j].F;
                                }
                            }

                            if (tfor_pdk[49] && yordamchi[j].Sianidi != -1)
                            {
                                ob.list[49].umumiy++;
                                //yordamchi[j].Sianidi /= koms[49].PDK;
                                ob.list[49].ortacha += yordamchi[j].Sianidi;
                                if (yordamchi[j].Sianidi < ob.list[49].min)
                                {
                                    ob.list[49].min = yordamchi[j].Sianidi;
                                }
                                if (yordamchi[j].Sianidi > ob.list[49].max)
                                {
                                    ob.list[49].max = yordamchi[j].Sianidi;
                                }
                            }

                            if (tfor_pdk[50] && yordamchi[j].Proponil != -1)
                            {
                                ob.list[50].umumiy++;
                                ob.list[50].ortacha += yordamchi[j].Proponil;
                                if (yordamchi[j].Proponil < ob.list[50].min)
                                {
                                    ob.list[50].min = yordamchi[j].Proponil;
                                }
                                if (yordamchi[j].Proponil > ob.list[50].max)
                                {
                                    ob.list[50].max = yordamchi[j].Proponil;
                                }
                            }

                            if (tfor_pdk[51] && yordamchi[j].DDE != -1)
                            {
                                ob.list[51].umumiy++;
                                ob.list[51].ortacha += yordamchi[j].DDE;
                                if (yordamchi[j].DDE < ob.list[51].min)
                                {
                                    ob.list[51].min = yordamchi[j].DDE;
                                }
                                if (yordamchi[j].DDE > ob.list[51].max)
                                {
                                    ob.list[51].max = yordamchi[j].DDE;
                                }
                            }

                            if (tfor_pdk[52] && yordamchi[j].Rogor != -1)
                            {
                                ob.list[52].umumiy++;
                                ob.list[52].ortacha += yordamchi[j].Rogor;
                                if (yordamchi[j].Rogor < ob.list[52].min)
                                {
                                    ob.list[52].min = yordamchi[j].Rogor;
                                }
                                if (yordamchi[j].Rogor > ob.list[52].max)
                                {
                                    ob.list[52].max = yordamchi[j].Rogor;
                                }
                            }

                            if (tfor_pdk[53] && yordamchi[j].DDT != -1)
                            {
                                ob.list[53].umumiy++;
                                //yordamchi[j].DDT /= koms[53].PDK;
                                ob.list[53].ortacha += yordamchi[j].DDT;
                                if (yordamchi[j].DDT < ob.list[53].min)
                                {
                                    ob.list[53].min = yordamchi[j].DDT;
                                }
                                if (yordamchi[j].DDT > ob.list[53].max)
                                {
                                    ob.list[53].max = yordamchi[j].DDT;
                                }
                            }

                            if (tfor_pdk[54] && yordamchi[j].Geksaxloran != -1)
                            {
                                ob.list[54].umumiy++;
                                //yordamchi[j].Geksaxloran /= koms[54].PDK;
                                ob.list[54].ortacha += yordamchi[j].Geksaxloran;
                                if (yordamchi[j].Geksaxloran < ob.list[54].min)
                                {
                                    ob.list[54].min = yordamchi[j].Geksaxloran;
                                }
                                if (yordamchi[j].Geksaxloran > ob.list[54].max)
                                {
                                    ob.list[54].max = yordamchi[j].Geksaxloran;
                                }
                            }

                            if (tfor_pdk[55] && yordamchi[j].Lindan != -1)
                            {
                                ob.list[55].umumiy++;
                                //yordamchi[j].Lindan /= koms[55].PDK;
                                ob.list[55].ortacha += yordamchi[j].Lindan;
                                if (yordamchi[j].Lindan < ob.list[55].min)
                                {
                                    ob.list[55].min = yordamchi[j].Lindan;
                                }
                                if (yordamchi[j].Lindan > ob.list[55].max)
                                {
                                    ob.list[55].max = yordamchi[j].Lindan;
                                }
                            }

                            if (tfor_pdk[56] && yordamchi[j].DDD != -1)
                            {
                                ob.list[56].umumiy++;
                                ob.list[56].ortacha += yordamchi[j].DDD;
                                if (yordamchi[j].DDD < ob.list[56].min)
                                {
                                    ob.list[56].min = yordamchi[j].DDD;
                                }
                                if (yordamchi[j].DDD > ob.list[56].max)
                                {
                                    ob.list[56].max = yordamchi[j].DDD;
                                }
                            }

                            if (tfor_pdk[57] && yordamchi[j].Metafos != -1)
                            {
                                ob.list[57].umumiy++;
                                ob.list[57].ortacha += yordamchi[j].Metafos;
                                if (yordamchi[j].Metafos < ob.list[57].min)
                                {
                                    ob.list[57].min = yordamchi[j].Metafos;
                                }
                                if (yordamchi[j].Metafos > ob.list[57].max)
                                {
                                    ob.list[57].max = yordamchi[j].Metafos;
                                }
                            }

                            if (tfor_pdk[58] && yordamchi[j].Butifos != -1)
                            {
                                ob.list[58].umumiy++;
                                ob.list[58].ortacha += yordamchi[j].Butifos;
                                if (yordamchi[j].Butifos < ob.list[1].min)
                                {
                                    ob.list[58].min = yordamchi[j].Butifos;
                                }
                                if (yordamchi[j].Butifos > ob.list[1].max)
                                {
                                    ob.list[58].max = yordamchi[j].Butifos;
                                }
                            }

                            if (tfor_pdk[59] && yordamchi[j].Dalapon != -1)
                            {
                                ob.list[59].umumiy++;
                                ob.list[59].ortacha += yordamchi[j].Dalapon;
                                if (yordamchi[j].Dalapon < ob.list[59].min)
                                {
                                    ob.list[59].min = yordamchi[j].Dalapon;
                                }
                                if (yordamchi[j].Dalapon > ob.list[59].max)
                                {
                                    ob.list[59].max = yordamchi[j].Dalapon;
                                }
                            }

                            if (tfor_pdk[60] && yordamchi[j].Karbofos != -1)
                            {
                                ob.list[60].umumiy++;
                                ob.list[60].ortacha += yordamchi[j].Karbofos;
                                if (yordamchi[j].Karbofos < ob.list[60].min)
                                {
                                    ob.list[60].min = yordamchi[j].Karbofos;
                                }
                                if (yordamchi[j].Karbofos > ob.list[60].max)
                                {
                                    ob.list[60].max = yordamchi[j].Karbofos;
                                }
                            }
                        }
                    }

                    result.Add(ob);
                }

                if (LastYear)
                {
                    strquery = "Select *From Analysis Where Sana>#31/12/" + (Year - 2).ToString() +
                               "# And Sana<#01/01/" + Year.ToString() + "#";
                    list = GetAnalysisList(strquery);

                    List<HisobotPostPDK> result1 = new List<HisobotPostPDK>();

                    for (int k = 0; k < rivers.Count; k++)
                    {
                        List<PostClass> postyordam = posts.Where(x => x.River_Id == rivers[k].Id).ToList();
                        List<AnalysisClass> yordamchi = new List<AnalysisClass>();

                        for (int i = 0; i < postyordam.Count; i++)
                        {
                            yordamchi.AddRange(list.Where(x => x.Post_Id == postyordam[i].Id));
                        }

                        HisobotPostPDK ob = new HisobotPostPDK(koms);
                        ob.post = rivers[k].Name;

                        if (yordamchi.Count > 0)
                        {
                            for (int j = 0; j < yordamchi.Count; j++)
                            {
                                if (tfor_pdk[0] && yordamchi[j].Sigm != -1)
                                {
                                    ob.list[0].umumiy++;
                                    ob.list[0].ortacha += yordamchi[j].Sigm;
                                    if (yordamchi[j].Sigm < ob.list[0].min)
                                    {
                                        ob.list[0].min = yordamchi[j].Sigm;
                                    }
                                    if (yordamchi[j].Sigm > ob.list[0].max)
                                    {
                                        ob.list[0].max = yordamchi[j].Sigm;
                                    }
                                }

                                if (tfor_pdk[1] && yordamchi[j].OqimTezligi != -1)
                                {
                                    ob.list[1].umumiy++;
                                    ob.list[1].ortacha += yordamchi[j].OqimTezligi;

                                    if (yordamchi[j].OqimTezligi < ob.list[1].min)
                                    {
                                        ob.list[1].min = yordamchi[j].OqimTezligi;
                                    }
                                    if (yordamchi[j].OqimTezligi > ob.list[1].max)
                                    {
                                        ob.list[1].max = yordamchi[j].OqimTezligi;
                                    }
                                }

                                if (tfor_pdk[2] && yordamchi[j].DaryoSarfi != -1)
                                {
                                    ob.list[2].umumiy++;
                                    ob.list[2].ortacha += yordamchi[j].DaryoSarfi;
                                    if (yordamchi[j].DaryoSarfi < ob.list[2].min)
                                    {
                                        ob.list[2].min = yordamchi[j].DaryoSarfi;
                                    }
                                    if (yordamchi[j].DaryoSarfi > ob.list[2].max)
                                    {
                                        ob.list[2].max = yordamchi[j].DaryoSarfi;
                                    }
                                }

                                if (tfor_pdk[3] && yordamchi[j].OqimSarfi != -1)
                                {
                                    ob.list[3].umumiy++;
                                    ob.list[3].ortacha += yordamchi[j].OqimSarfi;
                                    if (yordamchi[j].OqimSarfi < ob.list[3].min)
                                    {
                                        ob.list[3].min = yordamchi[j].OqimSarfi;
                                    }
                                    if (yordamchi[j].OqimSarfi > ob.list[3].max)
                                    {
                                        ob.list[3].max = yordamchi[j].OqimSarfi;
                                    }
                                }

                                if (tfor_pdk[4] && yordamchi[j].Namlik != -1)
                                {
                                    ob.list[4].umumiy++;
                                    ob.list[4].ortacha += yordamchi[j].Namlik;
                                    if (yordamchi[j].Namlik < ob.list[4].min)
                                    {
                                        ob.list[4].min = yordamchi[j].Namlik;
                                    }
                                    if (yordamchi[j].Namlik > ob.list[4].max)
                                    {
                                        ob.list[4].max = yordamchi[j].Namlik;
                                    }
                                }

                                if (tfor_pdk[5] && yordamchi[j].Tiniqlik != -1)
                                {
                                    ob.list[5].umumiy++;
                                    ob.list[5].ortacha += yordamchi[j].Tiniqlik;
                                    if (yordamchi[j].OqimTezligi < ob.list[5].min)
                                    {
                                        ob.list[5].min = yordamchi[j].OqimTezligi;
                                    }
                                    if (yordamchi[j].OqimTezligi > ob.list[5].max)
                                    {
                                        ob.list[5].max = yordamchi[j].OqimTezligi;
                                    }
                                }

                                if (tfor_pdk[6] && yordamchi[j].Rangi != -1)
                                {
                                    ob.list[6].umumiy++;
                                    ob.list[6].ortacha += yordamchi[j].Rangi;
                                    if (yordamchi[j].Rangi < ob.list[6].min)
                                    {
                                        ob.list[6].min = yordamchi[j].Rangi;
                                    }
                                    if (yordamchi[j].Rangi > ob.list[6].max)
                                    {
                                        ob.list[6].max = yordamchi[j].Rangi;
                                    }
                                }

                                if (tfor_pdk[7] && yordamchi[j].Harorat != -1)
                                {
                                    ob.list[7].umumiy++;
                                    ob.list[7].ortacha += yordamchi[j].Harorat;
                                    if (yordamchi[j].Harorat < ob.list[7].min)
                                    {
                                        ob.list[7].min = yordamchi[j].Harorat;
                                    }
                                    if (yordamchi[j].Harorat > ob.list[7].max)
                                    {
                                        ob.list[7].max = yordamchi[j].Harorat;
                                    }
                                }

                                if (tfor_pdk[8] && yordamchi[j].Suzuvchi != -1)
                                {
                                    ob.list[8].umumiy++;
                                    ob.list[8].ortacha += yordamchi[j].Suzuvchi;
                                    if (yordamchi[j].Suzuvchi < ob.list[8].min)
                                    {
                                        ob.list[8].min = yordamchi[j].Suzuvchi;
                                    }
                                    if (yordamchi[j].Suzuvchi > ob.list[8].max)
                                    {
                                        ob.list[8].max = yordamchi[j].Suzuvchi;
                                    }
                                }

                                if (tfor_pdk[9] && yordamchi[j].pH != -1)
                                {
                                    ob.list[9].umumiy++;
                                    //yordamchi[j].pH /= koms[9].PDK;
                                    ob.list[9].ortacha += yordamchi[j].pH;
                                    if (yordamchi[j].pH < ob.list[9].min)
                                    {
                                        ob.list[9].min = yordamchi[j].pH;
                                    }
                                    if (yordamchi[j].pH > ob.list[9].max)
                                    {
                                        ob.list[9].max = yordamchi[j].pH;
                                    }
                                }

                                if (tfor_pdk[10] && yordamchi[j].O2 != -1)
                                {
                                    ob.list[10].umumiy++;
                                    //yordamchi[j].O2 /= koms[10].PDK;
                                    ob.list[10].ortacha += yordamchi[j].O2;
                                    if (yordamchi[j].O2 < ob.list[10].min)
                                    {
                                        ob.list[10].min = yordamchi[j].O2;
                                    }
                                    if (yordamchi[j].O2 > ob.list[10].max)
                                    {
                                        ob.list[10].max = yordamchi[j].O2;
                                    }
                                }

                                if (tfor_pdk[11] && yordamchi[j].Tuyingan != -1)
                                {
                                    ob.list[11].umumiy++;
                                    ob.list[11].ortacha += yordamchi[j].Tuyingan;
                                    if (yordamchi[j].Tuyingan < ob.list[11].min)
                                    {
                                        ob.list[11].min = yordamchi[j].Tuyingan;
                                    }
                                    if (yordamchi[j].Tuyingan > ob.list[11].max)
                                    {
                                        ob.list[11].max = yordamchi[j].Tuyingan;
                                    }
                                }

                                if (tfor_pdk[12] && yordamchi[j].CO2 != -1)
                                {
                                    ob.list[12].umumiy++;
                                    ob.list[12].ortacha += yordamchi[j].CO2;
                                    if (yordamchi[j].CO2 < ob.list[12].min)
                                    {
                                        ob.list[12].min = yordamchi[j].CO2;
                                    }
                                    if (yordamchi[j].CO2 > ob.list[12].max)
                                    {
                                        ob.list[12].max = yordamchi[j].CO2;
                                    }
                                }

                                if (tfor_pdk[13] && yordamchi[j].Qattiqlik != -1)
                                {
                                    ob.list[13].umumiy++;
                                    //yordamchi[j].Qattiqlik /= koms[13].PDK;
                                    ob.list[13].ortacha += yordamchi[j].Qattiqlik;
                                    if (yordamchi[j].Qattiqlik < ob.list[13].min)
                                    {
                                        ob.list[13].min = yordamchi[j].Qattiqlik;
                                    }
                                    if (yordamchi[j].Qattiqlik > ob.list[13].max)
                                    {
                                        ob.list[13].max = yordamchi[j].Qattiqlik;
                                    }
                                }

                                if (tfor_pdk[14] && yordamchi[j].Xlorid != -1)
                                {
                                    ob.list[14].umumiy++;
                                    //yordamchi[j].Xlorid /= koms[14].PDK;
                                    ob.list[14].ortacha += yordamchi[j].Xlorid;
                                    if (yordamchi[j].Xlorid < ob.list[14].min)
                                    {
                                        ob.list[14].min = yordamchi[j].Xlorid;
                                    }
                                    if (yordamchi[j].Xlorid > ob.list[14].max)
                                    {
                                        ob.list[14].max = yordamchi[j].Xlorid;
                                    }
                                }

                                if (tfor_pdk[15] && yordamchi[j].Sulfat != -1)
                                {
                                    ob.list[15].umumiy++;
                                    //yordamchi[j].Sulfat /= koms[15].PDK;
                                    ob.list[15].ortacha += yordamchi[j].Sulfat;
                                    if (yordamchi[j].Sulfat < ob.list[15].min)
                                    {
                                        ob.list[15].min = yordamchi[j].Sulfat;
                                    }
                                    if (yordamchi[j].Sulfat > ob.list[15].max)
                                    {
                                        ob.list[15].max = yordamchi[j].Sulfat;
                                    }
                                }

                                if (tfor_pdk[16] && yordamchi[j].GidroKarbanat != -1)
                                {
                                    ob.list[16].umumiy++;
                                    ob.list[16].ortacha += yordamchi[j].GidroKarbanat;
                                    if (yordamchi[j].GidroKarbanat < ob.list[16].min)
                                    {
                                        ob.list[16].min = yordamchi[j].GidroKarbanat;
                                    }
                                    if (yordamchi[j].GidroKarbanat > ob.list[16].max)
                                    {
                                        ob.list[16].max = yordamchi[j].GidroKarbanat;
                                    }
                                }

                                if (tfor_pdk[17] && yordamchi[j].Na != -1)
                                {
                                    ob.list[17].umumiy++;
                                    //yordamchi[j].Na /= koms[17].PDK;
                                    ob.list[17].ortacha += yordamchi[j].Na;
                                    if (yordamchi[j].Na < ob.list[17].min)
                                    {
                                        ob.list[17].min = yordamchi[j].Na;
                                    }
                                    if (yordamchi[j].Na > ob.list[17].max)
                                    {
                                        ob.list[17].max = yordamchi[j].Na;
                                    }
                                }

                                if (tfor_pdk[18] && yordamchi[j].K != -1)
                                {
                                    ob.list[18].umumiy++;
                                    //yordamchi[j].K /= koms[18].PDK;
                                    ob.list[18].ortacha += yordamchi[j].K;
                                    if (yordamchi[j].K < ob.list[18].min)
                                    {
                                        ob.list[18].min = yordamchi[j].K;
                                    }
                                    if (yordamchi[j].K > ob.list[18].max)
                                    {
                                        ob.list[18].max = yordamchi[j].K;
                                    }
                                }

                                if (tfor_pdk[19] && yordamchi[j].Ca != -1)
                                {
                                    ob.list[19].umumiy++;
                                    //yordamchi[j].Ca /= koms[19].PDK;
                                    ob.list[19].ortacha += yordamchi[j].Ca;
                                    if (yordamchi[j].Ca < ob.list[19].min)
                                    {
                                        ob.list[19].min = yordamchi[j].Ca;
                                    }
                                    if (yordamchi[j].Ca > ob.list[19].max)
                                    {
                                        ob.list[19].max = yordamchi[j].Ca;
                                    }
                                }

                                if (tfor_pdk[20] && yordamchi[j].Mg != -1)
                                {
                                    ob.list[20].umumiy++;
                                    //yordamchi[j].Mg /= koms[20].PDK;
                                    ob.list[20].ortacha += yordamchi[j].Mg;
                                    if (yordamchi[j].Mg < ob.list[20].min)
                                    {
                                        ob.list[20].min = yordamchi[j].Mg;
                                    }
                                    if (yordamchi[j].Mg > ob.list[20].max)
                                    {
                                        ob.list[20].max = yordamchi[j].Mg;
                                    }
                                }

                                if (tfor_pdk[21] && yordamchi[j].Mineral != -1)
                                {
                                    ob.list[21].umumiy++;
                                    //yordamchi[j].Mineral /= koms[21].PDK;
                                    ob.list[21].ortacha += yordamchi[j].Mineral;
                                    if (yordamchi[j].Mineral < ob.list[21].min)
                                    {
                                        ob.list[21].min = yordamchi[j].Mineral;
                                    }
                                    if (yordamchi[j].Mineral > ob.list[21].max)
                                    {
                                        ob.list[21].max = yordamchi[j].Mineral;
                                    }
                                }

                                if (tfor_pdk[22] && yordamchi[j].XPK != -1)
                                {
                                    ob.list[22].umumiy++;
                                    ob.list[22].ortacha += yordamchi[j].XPK;
                                    if (yordamchi[j].XPK < ob.list[22].min)
                                    {
                                        ob.list[22].min = yordamchi[j].XPK;
                                    }
                                    if (yordamchi[j].XPK > ob.list[22].max)
                                    {
                                        ob.list[22].max = yordamchi[j].XPK;
                                    }
                                }

                                if (tfor_pdk[23] && yordamchi[j].BPK != -1)
                                {
                                    ob.list[23].umumiy++;
                                    //yordamchi[j].BPK /= koms[23].PDK;
                                    ob.list[23].ortacha += yordamchi[j].BPK;
                                    if (yordamchi[j].BPK < ob.list[23].min)
                                    {
                                        ob.list[23].min = yordamchi[j].BPK;
                                    }
                                    if (yordamchi[j].BPK > ob.list[23].max)
                                    {
                                        ob.list[23].max = yordamchi[j].BPK;
                                    }
                                }

                                if (tfor_pdk[24] && yordamchi[j].AzotAmonniy != -1)
                                {
                                    ob.list[24].umumiy++;
                                    //yordamchi[j].AzotAmonniy /= koms[24].PDK;
                                    ob.list[24].ortacha += yordamchi[j].AzotAmonniy;
                                    if (yordamchi[j].AzotAmonniy < ob.list[24].min)
                                    {
                                        ob.list[24].min = yordamchi[j].AzotAmonniy;
                                    }
                                    if (yordamchi[j].AzotAmonniy > ob.list[24].max)
                                    {
                                        ob.list[24].max = yordamchi[j].AzotAmonniy;
                                    }
                                }

                                if (tfor_pdk[25] && yordamchi[j].AzotNitritniy != -1)
                                {
                                    ob.list[25].umumiy++;
                                    //yordamchi[j].AzotNitritniy /= koms[25].PDK;
                                    ob.list[25].ortacha += yordamchi[j].AzotNitritniy;
                                    if (yordamchi[j].AzotNitritniy < ob.list[25].min)
                                    {
                                        ob.list[25].min = yordamchi[j].AzotNitritniy;
                                    }
                                    if (yordamchi[j].AzotNitritniy > ob.list[25].max)
                                    {
                                        ob.list[25].max = yordamchi[j].AzotNitritniy;
                                    }
                                }

                                if (tfor_pdk[26] && yordamchi[j].AzotNitratniy != -1)
                                {
                                    ob.list[26].umumiy++;
                                    //yordamchi[j].AzotNitratniy /= koms[26].PDK;
                                    ob.list[26].ortacha += yordamchi[j].AzotNitratniy;
                                    if (yordamchi[j].AzotNitratniy < ob.list[26].min)
                                    {
                                        ob.list[26].min = yordamchi[j].AzotNitratniy;
                                    }
                                    if (yordamchi[j].AzotNitratniy > ob.list[26].max)
                                    {
                                        ob.list[26].max = yordamchi[j].AzotNitratniy;
                                    }
                                }

                                if (tfor_pdk[27] && yordamchi[j].AzotSumma != -1)
                                {
                                    ob.list[27].umumiy++;
                                    ob.list[27].ortacha += yordamchi[j].AzotSumma;
                                    if (yordamchi[j].AzotSumma < ob.list[27].min)
                                    {
                                        ob.list[27].min = yordamchi[j].AzotSumma;
                                    }
                                    if (yordamchi[j].AzotSumma > ob.list[27].max)
                                    {
                                        ob.list[27].max = yordamchi[j].AzotSumma;
                                    }
                                }

                                if (tfor_pdk[28] && yordamchi[j].Fosfat != -1)
                                {
                                    ob.list[28].umumiy++;
                                    //yordamchi[j].Fosfat /= koms[28].PDK;
                                    ob.list[28].ortacha += yordamchi[j].Fosfat;
                                    if (yordamchi[j].Fosfat < ob.list[28].min)
                                    {
                                        ob.list[28].min = yordamchi[j].Fosfat;
                                    }
                                    if (yordamchi[j].Fosfat > ob.list[28].max)
                                    {
                                        ob.list[28].max = yordamchi[j].Fosfat;
                                    }
                                }

                                if (tfor_pdk[29] && yordamchi[j].Si != -1)
                                {
                                    ob.list[29].umumiy++;
                                    ob.list[29].ortacha += yordamchi[j].Si;
                                    if (yordamchi[j].Si < ob.list[29].min)
                                    {
                                        ob.list[29].min = yordamchi[j].Si;
                                    }
                                    if (yordamchi[j].Si > ob.list[29].max)
                                    {
                                        ob.list[29].max = yordamchi[j].Si;
                                    }
                                }

                                if (tfor_pdk[30] && yordamchi[j].Elektr != -1)
                                {
                                    ob.list[30].umumiy++;
                                    ob.list[30].ortacha += yordamchi[j].Elektr;
                                    if (yordamchi[j].Elektr < ob.list[30].min)
                                    {
                                        ob.list[30].min = yordamchi[j].Elektr;
                                    }
                                    if (yordamchi[j].Elektr > ob.list[30].max)
                                    {
                                        ob.list[30].max = yordamchi[j].Elektr;
                                    }
                                }

                                if (tfor_pdk[31] && yordamchi[j].Eh_MB != -1)
                                {
                                    ob.list[31].umumiy++;
                                    ob.list[31].ortacha += yordamchi[j].Eh_MB;
                                    if (yordamchi[j].Eh_MB < ob.list[32].min)
                                    {
                                        ob.list[32].min = yordamchi[j].Eh_MB;
                                    }
                                    if (yordamchi[j].Eh_MB > ob.list[32].max)
                                    {
                                        ob.list[32].max = yordamchi[j].Eh_MB;
                                    }
                                }

                                if (tfor_pdk[32] && yordamchi[j].PUmumiy != -1)
                                {
                                    ob.list[32].umumiy++;
                                    //yordamchi[j].PUmumiy /= koms[32].PDK;
                                    ob.list[32].ortacha += yordamchi[j].PUmumiy;
                                    if (yordamchi[j].PUmumiy < ob.list[32].min)
                                    {
                                        ob.list[32].min = yordamchi[j].PUmumiy;
                                    }
                                    if (yordamchi[j].PUmumiy > ob.list[32].max)
                                    {
                                        ob.list[32].max = yordamchi[j].PUmumiy;
                                    }
                                }

                                if (tfor_pdk[33] && yordamchi[j].FeUmumiy != -1)
                                {
                                    ob.list[33].umumiy++;
                                    //yordamchi[j].FeUmumiy /= koms[33].PDK;
                                    ob.list[33].ortacha += yordamchi[j].FeUmumiy;
                                    if (yordamchi[j].FeUmumiy < ob.list[33].min)
                                    {
                                        ob.list[33].min = yordamchi[j].FeUmumiy;
                                    }
                                    if (yordamchi[j].FeUmumiy > ob.list[1].max)
                                    {
                                        ob.list[33].max = yordamchi[j].FeUmumiy;
                                    }
                                }

                                if (tfor_pdk[34] && yordamchi[j].Ci != -1)
                                {
                                    ob.list[34].umumiy++;
                                    //yordamchi[j].Ci /= koms[34].PDK;
                                    ob.list[34].ortacha += yordamchi[j].Ci;
                                    if (yordamchi[j].Ci < ob.list[34].min)
                                    {
                                        ob.list[34].min = yordamchi[j].Ci;
                                    }
                                    if (yordamchi[j].Ci > ob.list[34].max)
                                    {
                                        ob.list[34].max = yordamchi[j].Ci;
                                    }
                                }

                                if (tfor_pdk[35] && yordamchi[j].Zn != -1)
                                {
                                    ob.list[35].umumiy++;
                                    //yordamchi[j].Zn /= koms[35].PDK;
                                    ob.list[35].ortacha += yordamchi[j].Zn;
                                    if (yordamchi[j].Zn < ob.list[35].min)
                                    {
                                        ob.list[35].min = yordamchi[j].Zn;
                                    }
                                    if (yordamchi[j].Zn > ob.list[35].max)
                                    {
                                        ob.list[35].max = yordamchi[j].Zn;
                                    }
                                }

                                if (tfor_pdk[36] && yordamchi[j].Ni != -1)
                                {
                                    ob.list[36].umumiy++;
                                    //yordamchi[j].Ni /= koms[36].PDK;
                                    ob.list[36].ortacha += yordamchi[j].Ni;
                                    if (yordamchi[j].Ni < ob.list[36].min)
                                    {
                                        ob.list[36].min = yordamchi[j].Ni;
                                    }
                                    if (yordamchi[j].Ni > ob.list[36].max)
                                    {
                                        ob.list[36].max = yordamchi[j].Ni;
                                    }
                                }

                                if (tfor_pdk[37] && yordamchi[j].Cr != -1)
                                {
                                    ob.list[37].umumiy++;
                                    ob.list[37].ortacha += yordamchi[j].Cr;
                                    if (yordamchi[j].Cr < ob.list[37].min)
                                    {
                                        ob.list[37].min = yordamchi[j].Cr;
                                    }
                                    if (yordamchi[j].Cr > ob.list[37].max)
                                    {
                                        ob.list[1].max = yordamchi[j].Cr;
                                    }
                                }

                                if (tfor_pdk[38] && yordamchi[j].Cr_VI != -1)
                                {
                                    ob.list[38].umumiy++;
                                    //yordamchi[j].Cr_VI /= koms[38].PDK;
                                    ob.list[38].ortacha += yordamchi[j].Cr_VI;
                                    if (yordamchi[j].Cr_VI < ob.list[38].min)
                                    {
                                        ob.list[38].min = yordamchi[j].Cr_VI;
                                    }
                                    if (yordamchi[j].Cr_VI > ob.list[38].max)
                                    {
                                        ob.list[38].max = yordamchi[j].Cr_VI;
                                    }
                                }

                                if (tfor_pdk[39] && yordamchi[j].Cr_III != -1)
                                {
                                    ob.list[39].umumiy++;
                                    ob.list[39].ortacha += yordamchi[j].Cr_III;
                                    if (yordamchi[j].Cr_III < ob.list[39].min)
                                    {
                                        ob.list[39].min = yordamchi[j].Cr_III;
                                    }
                                    if (yordamchi[j].Cr_III > ob.list[39].max)
                                    {
                                        ob.list[39].max = yordamchi[j].Cr_III;
                                    }
                                }

                                if (tfor_pdk[40] && yordamchi[j].Pb != -1)
                                {
                                    ob.list[40].umumiy++;
                                    //yordamchi[j].Pb /= koms[40].PDK;
                                    ob.list[40].ortacha += yordamchi[j].Pb;
                                    if (yordamchi[j].Pb < ob.list[40].min)
                                    {
                                        ob.list[40].min = yordamchi[j].Pb;
                                    }
                                    if (yordamchi[j].Pb > ob.list[40].max)
                                    {
                                        ob.list[40].max = yordamchi[j].Pb;
                                    }
                                }

                                if (tfor_pdk[41] && yordamchi[j].Hg != -1)
                                {
                                    ob.list[41].umumiy++;
                                    //yordamchi[j].Hg /= koms[41].PDK;
                                    ob.list[41].ortacha += yordamchi[j].Hg;
                                    if (yordamchi[j].Hg < ob.list[41].min)
                                    {
                                        ob.list[41].min = yordamchi[j].Hg;
                                    }
                                    if (yordamchi[j].Hg > ob.list[41].max)
                                    {
                                        ob.list[41].max = yordamchi[j].Hg;
                                    }
                                }

                                if (tfor_pdk[42] && yordamchi[j].Cd != -1)
                                {
                                    ob.list[42].umumiy++;
                                    //yordamchi[j].Cd /= koms[42].PDK;
                                    ob.list[42].ortacha += yordamchi[j].Cd;
                                    if (yordamchi[j].Cd < ob.list[42].min)
                                    {
                                        ob.list[42].min = yordamchi[j].Cd;
                                    }
                                    if (yordamchi[j].Cd > ob.list[42].max)
                                    {
                                        ob.list[42].max = yordamchi[j].Cd;
                                    }
                                }

                                if (tfor_pdk[43] && yordamchi[j].Mn != -1)
                                {
                                    ob.list[43].umumiy++;
                                    ob.list[43].ortacha += yordamchi[j].Mn;
                                    if (yordamchi[j].Mn < ob.list[43].min)
                                    {
                                        ob.list[43].min = yordamchi[j].Mn;
                                    }
                                    if (yordamchi[j].Mn > ob.list[43].max)
                                    {
                                        ob.list[43].max = yordamchi[j].Mn;
                                    }
                                }

                                if (tfor_pdk[44] && yordamchi[j].As != -1)
                                {
                                    ob.list[44].umumiy++;
                                    //yordamchi[j].As /= koms[44].PDK;
                                    ob.list[44].ortacha += yordamchi[j].As;
                                    if (yordamchi[j].As < ob.list[44].min)
                                    {
                                        ob.list[44].min = yordamchi[j].As;
                                    }
                                    if (yordamchi[j].As > ob.list[44].max)
                                    {
                                        ob.list[44].max = yordamchi[j].As;
                                    }
                                }

                                if (tfor_pdk[45] && yordamchi[j].Fenollar != -1)
                                {
                                    ob.list[45].umumiy++;
                                    //yordamchi[j].Fenollar /= koms[45].PDK;
                                    ob.list[45].ortacha += yordamchi[j].Fenollar;
                                    if (yordamchi[j].Fenollar < ob.list[45].min)
                                    {
                                        ob.list[45].min = yordamchi[j].Fenollar;
                                    }
                                    if (yordamchi[j].Fenollar > ob.list[45].max)
                                    {
                                        ob.list[45].max = yordamchi[j].Fenollar;
                                    }
                                }

                                if (tfor_pdk[46] && yordamchi[j].Neft != -1)
                                {
                                    ob.list[46].umumiy++;
                                    //yordamchi[j].Neft /= koms[46].PDK;
                                    ob.list[46].ortacha += yordamchi[j].Neft;
                                    if (yordamchi[j].Neft < ob.list[46].min)
                                    {
                                        ob.list[46].min = yordamchi[j].Neft;
                                    }
                                    if (yordamchi[j].Neft > ob.list[46].max)
                                    {
                                        ob.list[46].max = yordamchi[j].Neft;
                                    }
                                }

                                if (tfor_pdk[47] && yordamchi[j].SPAB != -1)
                                {
                                    ob.list[47].umumiy++;
                                    //yordamchi[j].SPAB /= koms[47].PDK;
                                    ob.list[47].ortacha += yordamchi[j].SPAB;
                                    if (yordamchi[j].SPAB < ob.list[47].min)
                                    {
                                        ob.list[47].min = yordamchi[j].SPAB;
                                    }
                                    if (yordamchi[j].SPAB > ob.list[47].max)
                                    {
                                        ob.list[47].max = yordamchi[j].SPAB;
                                    }
                                }

                                if (tfor_pdk[48] && yordamchi[j].F != -1)
                                {
                                    ob.list[48].umumiy++;
                                    //yordamchi[j].F /= koms[48].PDK;
                                    ob.list[48].ortacha += yordamchi[j].F;
                                    if (yordamchi[j].F < ob.list[48].min)
                                    {
                                        ob.list[48].min = yordamchi[j].F;
                                    }
                                    if (yordamchi[j].F > ob.list[48].max)
                                    {
                                        ob.list[48].max = yordamchi[j].F;
                                    }
                                }

                                if (tfor_pdk[49] && yordamchi[j].Sianidi != -1)
                                {
                                    ob.list[49].umumiy++;
                                    //yordamchi[j].Sianidi /= koms[49].PDK;
                                    ob.list[49].ortacha += yordamchi[j].Sianidi;
                                    if (yordamchi[j].Sianidi < ob.list[49].min)
                                    {
                                        ob.list[49].min = yordamchi[j].Sianidi;
                                    }
                                    if (yordamchi[j].Sianidi > ob.list[49].max)
                                    {
                                        ob.list[49].max = yordamchi[j].Sianidi;
                                    }
                                }

                                if (tfor_pdk[50] && yordamchi[j].Proponil != -1)
                                {
                                    ob.list[50].umumiy++;
                                    ob.list[50].ortacha += yordamchi[j].Proponil;
                                    if (yordamchi[j].Proponil < ob.list[50].min)
                                    {
                                        ob.list[50].min = yordamchi[j].Proponil;
                                    }
                                    if (yordamchi[j].Proponil > ob.list[50].max)
                                    {
                                        ob.list[50].max = yordamchi[j].Proponil;
                                    }
                                }

                                if (tfor_pdk[51] && yordamchi[j].DDE != -1)
                                {
                                    ob.list[51].umumiy++;
                                    ob.list[51].ortacha += yordamchi[j].DDE;
                                    if (yordamchi[j].DDE < ob.list[51].min)
                                    {
                                        ob.list[51].min = yordamchi[j].DDE;
                                    }
                                    if (yordamchi[j].DDE > ob.list[51].max)
                                    {
                                        ob.list[51].max = yordamchi[j].DDE;
                                    }
                                }

                                if (tfor_pdk[52] && yordamchi[j].Rogor != -1)
                                {
                                    ob.list[52].umumiy++;
                                    ob.list[52].ortacha += yordamchi[j].Rogor;
                                    if (yordamchi[j].Rogor < ob.list[52].min)
                                    {
                                        ob.list[52].min = yordamchi[j].Rogor;
                                    }
                                    if (yordamchi[j].Rogor > ob.list[52].max)
                                    {
                                        ob.list[52].max = yordamchi[j].Rogor;
                                    }
                                }

                                if (tfor_pdk[53] && yordamchi[j].DDT != -1)
                                {
                                    ob.list[53].umumiy++;
                                    //yordamchi[j].DDT /= koms[53].PDK;
                                    ob.list[53].ortacha += yordamchi[j].DDT;
                                    if (yordamchi[j].DDT < ob.list[53].min)
                                    {
                                        ob.list[53].min = yordamchi[j].DDT;
                                    }
                                    if (yordamchi[j].DDT > ob.list[53].max)
                                    {
                                        ob.list[53].max = yordamchi[j].DDT;
                                    }
                                }

                                if (tfor_pdk[54] && yordamchi[j].Geksaxloran != -1)
                                {
                                    ob.list[54].umumiy++;
                                    //yordamchi[j].Geksaxloran /= koms[54].PDK;
                                    ob.list[54].ortacha += yordamchi[j].Geksaxloran;
                                    if (yordamchi[j].Geksaxloran < ob.list[54].min)
                                    {
                                        ob.list[54].min = yordamchi[j].Geksaxloran;
                                    }
                                    if (yordamchi[j].Geksaxloran > ob.list[54].max)
                                    {
                                        ob.list[54].max = yordamchi[j].Geksaxloran;
                                    }
                                }

                                if (tfor_pdk[55] && yordamchi[j].Lindan != -1)
                                {
                                    ob.list[55].umumiy++;
                                    //yordamchi[j].Lindan /= koms[55].PDK;
                                    ob.list[55].ortacha += yordamchi[j].Lindan;
                                    if (yordamchi[j].Lindan < ob.list[55].min)
                                    {
                                        ob.list[55].min = yordamchi[j].Lindan;
                                    }
                                    if (yordamchi[j].Lindan > ob.list[55].max)
                                    {
                                        ob.list[55].max = yordamchi[j].Lindan;
                                    }
                                }

                                if (tfor_pdk[56] && yordamchi[j].DDD != -1)
                                {
                                    ob.list[56].umumiy++;
                                    ob.list[56].ortacha += yordamchi[j].DDD;
                                    if (yordamchi[j].DDD < ob.list[56].min)
                                    {
                                        ob.list[56].min = yordamchi[j].DDD;
                                    }
                                    if (yordamchi[j].DDD > ob.list[56].max)
                                    {
                                        ob.list[56].max = yordamchi[j].DDD;
                                    }
                                }

                                if (tfor_pdk[57] && yordamchi[j].Metafos != -1)
                                {
                                    ob.list[57].umumiy++;
                                    ob.list[57].ortacha += yordamchi[j].Metafos;
                                    if (yordamchi[j].Metafos < ob.list[57].min)
                                    {
                                        ob.list[57].min = yordamchi[j].Metafos;
                                    }
                                    if (yordamchi[j].Metafos > ob.list[57].max)
                                    {
                                        ob.list[57].max = yordamchi[j].Metafos;
                                    }
                                }

                                if (tfor_pdk[58] && yordamchi[j].Butifos != -1)
                                {
                                    ob.list[58].umumiy++;
                                    ob.list[58].ortacha += yordamchi[j].Butifos;
                                    if (yordamchi[j].Butifos < ob.list[1].min)
                                    {
                                        ob.list[58].min = yordamchi[j].Butifos;
                                    }
                                    if (yordamchi[j].Butifos > ob.list[1].max)
                                    {
                                        ob.list[58].max = yordamchi[j].Butifos;
                                    }
                                }

                                if (tfor_pdk[59] && yordamchi[j].Dalapon != -1)
                                {
                                    ob.list[59].umumiy++;
                                    ob.list[59].ortacha += yordamchi[j].Dalapon;
                                    if (yordamchi[j].Dalapon < ob.list[59].min)
                                    {
                                        ob.list[59].min = yordamchi[j].Dalapon;
                                    }
                                    if (yordamchi[j].Dalapon > ob.list[59].max)
                                    {
                                        ob.list[59].max = yordamchi[j].Dalapon;
                                    }
                                }

                                if (tfor_pdk[60] && yordamchi[j].Karbofos != -1)
                                {
                                    ob.list[60].umumiy++;
                                    ob.list[60].ortacha += yordamchi[j].Karbofos;
                                    if (yordamchi[j].Karbofos < ob.list[60].min)
                                    {
                                        ob.list[60].min = yordamchi[j].Karbofos;
                                    }
                                    if (yordamchi[j].Karbofos > ob.list[60].max)
                                    {
                                        ob.list[60].max = yordamchi[j].Karbofos;
                                    }
                                }
                            }
                        }

                        result1.Add(ob);
                    }

                    HisobotPDKForm form1 = new HisobotPDKForm(result1, result, koms, tfor_pdk, Year, 3);
                    form1.ShowDialog();
                }
                else
                {
                    HisobotPDKForm form1 = new HisobotPDKForm(result, koms, tfor_pdk, Year, 2);
                    form1.ShowDialog();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
        #endregion

        #region Server menu Click
        private void mnServesItemCopyDb_Click(object sender, EventArgs e)
        {
            int num = (int)new NewCopyDbForm().ShowDialog();
        }

        private void mnServisItemRestory_Click(object sender, EventArgs e)
        {
            CopyDBFormList copyDbFormList = new CopyDBFormList();
            copyDbFormList.GetCopyDb += new EventHandler(this.GetCopyDb);
            int num = (int)copyDbFormList.ShowDialog();
        }

        private void GetCopyDb(object sender, EventArgs e)
        {
            try
            {
                CopyDBClass copy = (sender as CopyDBFormList).copy;
                if (copy == null)
                    return;
                this.connect.Close();
                string str1 = Environment.CurrentDirectory + "\\Data\\Savat\\" + (object)copy.Id + copy.Display + copy.Vaqt.ToShortDateString() + ".mdb";
                string str2 = Environment.CurrentDirectory + "\\Data\\Hydro.mdb";
                if (!File.Exists(str1))
                    return;
                if (MessageBox.Show("Вы хотите резервировать это данных", "Резервное копирование баз данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int num = (int)new NewCopyDbForm().ShowDialog();
                }
                File.Delete(str2);
                File.Copy(str1, str2);
                File.Delete(str1);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
        }

        private void tmnuServesChangePassword_Click(object sender, EventArgs e)
        {
            ChangeLogin form = new ChangeLogin();
            form.ShowDialog();
        }
        #endregion

        #region Statistika menu Click
        private void mnStatisticItemCommon_Click(object sender, EventArgs e)
        {
            int num1 = (int)new QatlamForm(this.koms, (byte)0).ShowDialog();
            int i1 = QatlamForm.i1;
            if (i1 == -1)
                return;
            double[] a = new double[this.dgvAnalysis.RowCount];
            for (int index = 0; index < a.Length; ++index)
            {
                double result;
                a[index] = double.TryParse(this.dgvAnalysis.Rows[index].Cells[i1 + 7].Value.ToString(), out result) ? result : 0.0;
            }
            int num2 = (int)new FormStatistika(a).ShowDialog();
        }

        private void mnStatisticItemKorrelyatsion_Click(object sender, EventArgs e)
        {
            int num1 = (int)new QatlamForm(this.koms, (byte)1).ShowDialog();
            int i1 = QatlamForm.i1;
            if (i1 == -1)
                return;
            int i2 = QatlamForm.i2;
            if (i2 == -1)
                return;
            double[] a = new double[this.dgvAnalysis.RowCount];
            double[] b = new double[this.dgvAnalysis.RowCount];
            for (int index = 0; index < a.Length; ++index)
            {
                double result;
                a[index] = double.TryParse(this.dgvAnalysis.Rows[index].Cells[i1 + 7].Value.ToString(), out result) ? result : 0.0;
                b[index] = double.TryParse(this.dgvAnalysis.Rows[index].Cells[i2 + 7].Value.ToString(), out result) ? result : 0.0;
            }
            int num2 = (int)new FormStatistika(a, b).ShowDialog();
        }

        #endregion

        #region
        private void mnHandbookItemPost_Click(object sender, EventArgs e)
        {
            new PostListForm(this.posts, this.rivers, (byte)0).Show();
        }

        private void mnHandbookItemRiver_Click(object sender, EventArgs e)
        {
            new RiverListForm(this.rivers, (byte)0).Show();
        }

        private void mnHandbookItemKompanenta_Click(object sender, EventArgs e)
        {
            new KomponentaList(this.koms).Show();
        }



        #endregion

        private void mnHelpRefrences_Click(object sender, EventArgs e)
        {
            
        }

        private void chbKompanenta_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbKompanenta.Checked)
            {
                for (int index = 7; index < this.dgvAnalysis.ColumnCount - 1; ++index)
                    this.dgvAnalysis.Columns[index].Visible = this.t[index - 7];
            }
        }

        private void отчётПоКомпанентамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                ReportByComponent report = new ReportByComponent(koms, rivers, posts);
                report.ShowDialog();

                string str = "SELECT " +
                    "Analysis." + koms[report.sel_com_index].Name +
                    ", Analysis.Sana " +
                    "FROM Analysis " +
                    "WHERE Analysis.Sana >=#01/01/" +
                    report.dt1 +
                    "# and " +
                    "Analysis.Sana<=#31/12/" +
                    report.dt2 +
                    "#;";
                connect.Open();
                command.CommandText = str;
                adapter.InsertCommand = command;
                System.Data.DataTable dataTable1 = new System.Data.DataTable();
                this.adapter.Fill(dataTable1);
                connect.Close();

                List<Pair> pairlist = new List<Pair>();
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    pairlist.Add(new Pair(dataTable1.Rows[i].ItemArray[0].ToString(), 
                        dataTable1.Rows[i].ItemArray[1].ToString()));
                }

                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                application.Workbooks.Add((object)Missing.Value);
                _Worksheet worksheet1 = (_Worksheet)(application.Sheets.Add(System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing) as Worksheet);
                this.Cursor = Cursors.WaitCursor;

                for (int i = 1; i < 13; i++)
                {
                    worksheet1.Cells[1, i + 1] = i;
                }

                List<System.Windows.Forms.DataVisualization.Charting.Series> seriess = 
                    new List<System.Windows.Forms.DataVisualization.Charting.Series>();

                int row = 2;
                for (int i = report.dt1; i <= report.dt2; i++, row++)
                {
                    System.Windows.Forms.DataVisualization.Charting.Series current = new System.Windows.Forms.DataVisualization.Charting.Series();
                    current.LegendText = i.ToString();
                    current.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    List<Pair> help = pairlist.Where(x => x.dt.Year == i).ToList();
                    worksheet1.Cells[row, 1] = i;
                    for (int j = 1; j < 13; j++)
                    {
                        Pair pair = help.Where(x => x.dt.Month == j).FirstOrDefault();
                        if (pair != null)
                        {
                            //MessageBox.Show(pair.koef.ToString());
                            if (pair.koef != -1)
                                worksheet1.Cells[row, j + 1] = pair.koef;
                            else
                                worksheet1.Cells[row, j + 1] = "-";
                            current.Points.AddY(pair.koef);
                        }
                        else
                        {
                            worksheet1.Cells[row, j + 1] = "-";
                            current.Points.AddY(0);
                        }
                    }
                    seriess.Add(current);
                    //MessageBox.Show(row.ToString());
                }
                application.UserControl = true;
                application.Visible = true;
                this.Cursor = Cursors.Arrow;

                HydroSoft.Forms.Graphic graphic = new HydroSoft.Forms.Graphic(seriess);
                graphic.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                this.Cursor = Cursors.Arrow;
            }
        }
    }

    class Pair
    {
        public double koef { get; set; }
        public DateTime dt { get; set; }

        public Pair(string koef, string date)
        {
            this.koef = double.Parse(koef);
            dt = DateTime.Parse(date);
        }
    }
}
