using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HydroDemo.Models;

namespace HydroDemo.Forms
{
    public partial class YearFormForPDK : Form
    {
        private KompanentaClass[] kompanentaClasses;
        public bool[] t;
        public int Year;
        public bool LastYear = false;
        public YearFormForPDK(KompanentaClass []kompanentaClasses)
        {
            InitializeComponent();
            this.kompanentaClasses = kompanentaClasses;
            t = new bool[kompanentaClasses.Length];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = false;
            }
            // Kelishuv bo'yicha qiymat
            t[11] = true; t[44] = true; t[12] = true; t[19] = true;
            t[42] = true; t[43] = true; t[37] = true; t[39] = true;
            t[38] = true; t[34] = true; t[31] = true; t[48] = true;
            t[33] = true; t[41] = true; t[18] = true; t[20] = true;
            t[17] = true; t[10] = true; t[32] = true; t[9] = true;
            t[40] = true; t[29] = true; t[35] = true; t[24] = true;
            t[26] = true; t[25] = true; t[54] = true; t[23] = true;
            t[8] = true; t[55] = true; t[16] = true; t[56] = true;
            t[51] = true; t[53] = true; t[13] = true; t[4] = true;
            t[0] = true; t[21] = true; t[46] = true; t[5] = true;
            t[47] = true; t[15] = true; t[7] = true; t[45] = true;
            t[28] = true; t[22] = true; t[14] = true; t[6] = true;
            t[30] = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Year = dtpYear.Value.Year;
                LastYear = chbLastYear.Checked;
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnKomponent_Click(object sender, EventArgs e)
        {

        }

        private void GetBool(object sender, EventArgs e)
        {
            t = (sender as KoponenteCheckedListForm).t;
        }

        private void btnKomponent_Click_1(object sender, EventArgs e)
        {
            KoponenteCheckedListForm koponenteCheckedListForm = new KoponenteCheckedListForm(this.kompanentaClasses, this.t);
            koponenteCheckedListForm.GetBool += new EventHandler(this.GetBool);
            koponenteCheckedListForm.ShowDialog();
        }

        private void chbLastYear_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = false;
            }
            if (chbLastYear.Checked)
            {
                // Kelishuv bo'yicha qiymat
                t[25] = true; t[10] = true; t[23] = true; t[33] = true;
                t[22] = true; t[24] = true; t[26] = true; t[34] = true;
                t[35] = true; t[45] = true; t[46] = true; t[47] = true;
                t[8] = true; t[53] = true; t[54] = true; t[55] = true;
                t[38] = true; t[48] = true; t[44] = true; t[21] = true;
            }
            else
            {
                // Kelishuv bo'yicha qiymat
                t[11] = true; t[44] = true; t[12] = true; t[19] = true;
                t[42] = true; t[43] = true; t[37] = true; t[39] = true;
                t[38] = true; t[34] = true; t[31] = true; t[48] = true;
                t[33] = true; t[41] = true; t[18] = true; t[20] = true;
                t[17] = true; t[10] = true; t[32] = true; t[9] = true;
                t[40] = true; t[29] = true; t[35] = true; t[24] = true;
                t[26] = true; t[25] = true; t[54] = true; t[23] = true;
                t[8] = true;  t[55] = true; t[16] = true; t[56] = true;
                t[51] = true; t[53] = true; t[13] = true; t[4] = true;
                t[0] = true;  t[21] = true; t[46] = true; t[5] = true;
                t[47] = true; t[15] = true; t[7] = true; t[45] = true;
                t[28] = true; t[22] = true; t[14] = true; t[6] = true;
                t[30] = true;
            }
        }
    }
}
