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
using Excel = Microsoft.Office.Interop.Excel;

namespace HydroDemo.Forms
{
    public partial class HisobotPDKForm : Form
    {
        int Year;
        public HisobotPDKForm(List<HisobotPostPDK> result, KompanentaClass[] koms, bool[] t, int Year, byte key)
        {
            InitializeComponent();
            double ortacha;
            this.Year = Year;
            if (key == 0)
                Text = "Характеристика загрязнения поверхностных вод по постам за " + Year.ToString() + " год";
            else
            if (key == 1)
                Text = "Характеристика загрязнения поверхностных вод по постам в долях за " + Year.ToString() + " год";
            else
            if (key == 2)
                Text = "Характеристика загрязнения поверхностных вод по бассейнам рек в долях за " + Year.ToString() + " год";
            else
                Text = "Характеристика загрязнения поверхностных вод по бассейнам рек за " + Year.ToString() + " год";
            bool tt;
            foreach (HisobotPostPDK ob in result)
            {
                tt = false;
                if (t[0])
                {
                    ortacha = ob.list[0].ortacha / ob.list[0].umumiy;
                    if (tt)
                        if (ob.list[0].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[0].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[0].Display, ob.list[0].umumiy, ortacha, ob.list[0].max, ob.list[0].min);
                    else
                        if (ob.list[0].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[0].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[0].Display, ob.list[0].umumiy, ortacha, ob.list[0].max, ob.list[0].min);
                    tt = true;
                }
                if (t[1])
                {
                    ortacha = ob.list[1].ortacha / ob.list[1].umumiy;
                    if (tt)
                        if (ob.list[1].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[1].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[1].Display, ob.list[1].umumiy, ortacha, ob.list[1].max, ob.list[1].min);
                    else
                        if (ob.list[1].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[1].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[1].Display, ob.list[1].umumiy, ortacha, ob.list[1].max, ob.list[1].min);
                    tt = true;
                }
                if (t[2])
                {
                    ortacha = ob.list[2].ortacha / ob.list[2].umumiy;
                    if (tt)
                        if (ob.list[2].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[2].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[2].Display, ob.list[2].umumiy, ortacha, ob.list[2].max, ob.list[2].min);
                    else
                        if (ob.list[2].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[2].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[2].Display, ob.list[2].umumiy, ortacha, ob.list[2].max, ob.list[2].min);
                    tt = true;
                }
                if (t[3])
                {
                    ortacha = ob.list[3].ortacha / ob.list[3].umumiy;
                    if (tt)
                        if (ob.list[3].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[3].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[3].Display, ob.list[3].umumiy, ortacha, ob.list[3].max, ob.list[3].min);
                    else
                        if (ob.list[3].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[3].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[3].Display, ob.list[3].umumiy, ortacha, ob.list[3].max, ob.list[3].min);
                    tt = true;
                }
                if (t[4])
                {
                    ortacha = ob.list[4].ortacha / ob.list[4].umumiy;
                    if (tt)
                        if (ob.list[4].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[4].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[4].Display, ob.list[4].umumiy, ortacha, ob.list[4].max, ob.list[4].min);
                    else
                        if (ob.list[4].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[4].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[4].Display, ob.list[4].umumiy, ortacha, ob.list[4].max, ob.list[4].min);
                    tt = true;
                }
                if (t[5])
                {
                    ortacha = ob.list[5].ortacha / ob.list[5].umumiy;
                    if (tt)
                        if (ob.list[5].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[5].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[5].Display, ob.list[5].umumiy, ortacha, ob.list[5].max, ob.list[5].min);
                    else
                        if (ob.list[5].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[5].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[5].Display, ob.list[5].umumiy, ortacha, ob.list[5].max, ob.list[5].min);
                    tt = true;
                }
                if (t[6])
                {
                    ortacha = ob.list[6].ortacha / ob.list[6].umumiy;
                    if (tt)
                        if (ob.list[6].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[6].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[6].Display, ob.list[6].umumiy, ortacha, ob.list[6].max, ob.list[6].min);
                    else
                        if (ob.list[6].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[6].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[6].Display, ob.list[6].umumiy, ortacha, ob.list[6].max, ob.list[6].min);
                    tt = true;
                }
                if (t[7])
                {
                    ortacha = ob.list[7].ortacha / ob.list[7].umumiy;
                    if (tt)
                        if (ob.list[7].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[7].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[7].Display, ob.list[7].umumiy, ortacha, ob.list[7].max, ob.list[7].min);
                    else
                        if (ob.list[7].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[7].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[7].Display, ob.list[7].umumiy, ortacha, ob.list[7].max, ob.list[7].min);
                    tt = true;
                }
                if (t[8])
                {
                    ortacha = ob.list[8].ortacha / ob.list[8].umumiy;
                    if (tt)
                        if (ob.list[8].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[8].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[8].Display, ob.list[8].umumiy, ortacha, ob.list[8].max, ob.list[8].min);
                    else
                        if (ob.list[8].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[8].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[8].Display, ob.list[8].umumiy, ortacha, ob.list[8].max, ob.list[8].min);
                    tt = true;
                }
                if (t[9])
                {
                    ortacha = ob.list[9].ortacha / ob.list[9].umumiy;
                    if (tt)
                        if (ob.list[9].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[9].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[9].Display, ob.list[9].umumiy, ortacha, ob.list[9].max, ob.list[9].min);
                    else
                        if (ob.list[9].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[9].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[9].Display, ob.list[9].umumiy, ortacha, ob.list[9].max, ob.list[9].min);
                    tt = true;
                }
                if (t[10])
                {
                    ortacha = ob.list[10].ortacha / ob.list[10].umumiy;
                    if (tt)
                        if (ob.list[10].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[10].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[10].Display, ob.list[10].umumiy, ortacha, ob.list[10].max, ob.list[10].min);
                    else
                        if (ob.list[10].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[10].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[10].Display, ob.list[10].umumiy, ortacha, ob.list[10].max, ob.list[10].min);
                    tt = true;
                }
                if (t[11])
                {
                    ortacha = ob.list[11].ortacha / ob.list[11].umumiy;
                    if (tt)
                        if (ob.list[11].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[11].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[11].Display, ob.list[11].umumiy, ortacha, ob.list[11].max, ob.list[11].min);
                    else
                        if (ob.list[11].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[11].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[11].Display, ob.list[11].umumiy, ortacha, ob.list[11].max, ob.list[11].min);
                    tt = true;
                }
                if (t[12])
                {
                    ortacha = ob.list[12].ortacha / ob.list[12].umumiy;
                    if (tt)
                        if (ob.list[12].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[12].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[12].Display, ob.list[12].umumiy, ortacha, ob.list[12].max, ob.list[12].min);
                    else
                        if (ob.list[12].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[12].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[12].Display, ob.list[12].umumiy, ortacha, ob.list[12].max, ob.list[12].min);
                    tt = true;
                }
                if (t[13])
                {
                    ortacha = ob.list[13].ortacha / ob.list[13].umumiy;
                    if (tt)
                        if (ob.list[13].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[13].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[13].Display, ob.list[13].umumiy, ortacha, ob.list[13].max, ob.list[13].min);
                    else
                        if (ob.list[13].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[13].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[13].Display, ob.list[13].umumiy, ortacha, ob.list[13].max, ob.list[13].min);
                    tt = true;
                }
                if (t[14])
                {
                    ortacha = ob.list[14].ortacha / ob.list[14].umumiy;
                    if (tt)
                        if (ob.list[14].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[14].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[14].Display, ob.list[14].umumiy, ortacha, ob.list[14].max, ob.list[14].min);
                    else
                        if (ob.list[14].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[14].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[14].Display, ob.list[14].umumiy, ortacha, ob.list[14].max, ob.list[14].min);
                    tt = true;
                }
                if (t[15])
                {
                    ortacha = ob.list[15].ortacha / ob.list[15].umumiy;
                    if (tt)
                        if (ob.list[15].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[15].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[15].Display, ob.list[15].umumiy, ortacha, ob.list[15].max, ob.list[15].min);
                    else
                        if (ob.list[15].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[15].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[15].Display, ob.list[15].umumiy, ortacha, ob.list[15].max, ob.list[15].min);
                    tt = true;
                }
                if (t[16])
                {
                    ortacha = ob.list[16].ortacha / ob.list[16].umumiy;
                    if (tt)
                        if (ob.list[16].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[16].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[16].Display, ob.list[16].umumiy, ortacha, ob.list[16].max, ob.list[16].min);
                    else
                        if (ob.list[16].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[16].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[16].Display, ob.list[16].umumiy, ortacha, ob.list[16].max, ob.list[16].min);
                    tt = true;
                }
                if (t[17])
                {
                    ortacha = ob.list[17].ortacha / ob.list[17].umumiy;
                    if (tt)
                        if (ob.list[17].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[17].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[17].Display, ob.list[17].umumiy, ortacha, ob.list[17].max, ob.list[17].min);
                    else
                        if (ob.list[17].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[17].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[17].Display, ob.list[17].umumiy, ortacha, ob.list[17].max, ob.list[17].min);
                    tt = true;
                }
                if (t[18])
                {
                    ortacha = ob.list[18].ortacha / ob.list[18].umumiy;
                    if (tt)
                        if (ob.list[18].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[18].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[18].Display, ob.list[18].umumiy, ortacha, ob.list[18].max, ob.list[18].min);
                    else
                        if (ob.list[18].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[18].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[18].Display, ob.list[18].umumiy, ortacha, ob.list[18].max, ob.list[18].min);
                    tt = true;
                }
                if (t[19])
                {
                    ortacha = ob.list[19].ortacha / ob.list[19].umumiy;
                    if (tt)
                        if (ob.list[19].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[19].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[19].Display, ob.list[19].umumiy, ortacha, ob.list[19].max, ob.list[19].min);
                    else
                        if (ob.list[19].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[19].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[19].Display, ob.list[19].umumiy, ortacha, ob.list[19].max, ob.list[19].min);
                    tt = true;
                }
                if (t[20])
                {
                    ortacha = ob.list[20].ortacha / ob.list[20].umumiy;
                    if (tt)
                        if (ob.list[20].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[20].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[20].Display, ob.list[20].umumiy, ortacha, ob.list[20].max, ob.list[20].min);
                    else
                        if (ob.list[20].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[20].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[20].Display, ob.list[20].umumiy, ortacha, ob.list[20].max, ob.list[20].min);
                    tt = true;
                }
                if (t[21])
                {
                    ortacha = ob.list[21].ortacha / ob.list[21].umumiy;
                    if (tt)
                        if (ob.list[21].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[21].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[21].Display, ob.list[21].umumiy, ortacha, ob.list[21].max, ob.list[21].min);
                    else
                        if (ob.list[21].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[21].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[21].Display, ob.list[21].umumiy, ortacha, ob.list[21].max, ob.list[21].min);
                    tt = true;
                }
                if (t[22])
                {
                    ortacha = ob.list[22].ortacha / ob.list[22].umumiy;
                    if (tt)
                        if (ob.list[22].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[22].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[22].Display, ob.list[22].umumiy, ortacha, ob.list[22].max, ob.list[22].min);
                    else
                        if (ob.list[22].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[22].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[22].Display, ob.list[22].umumiy, ortacha, ob.list[22].max, ob.list[22].min);
                    tt = true;
                }
                if (t[23])
                {
                    ortacha = ob.list[23].ortacha / ob.list[23].umumiy;
                    if (tt)
                        if (ob.list[23].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[23].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[23].Display, ob.list[23].umumiy, ortacha, ob.list[23].max, ob.list[23].min);
                    else
                        if (ob.list[23].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[23].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[23].Display, ob.list[23].umumiy, ortacha, ob.list[23].max, ob.list[23].min);
                    tt = true;
                }
                if (t[24])
                {
                    ortacha = ob.list[24].ortacha / ob.list[24].umumiy;
                    if (tt)
                        if (ob.list[24].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[24].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[24].Display, ob.list[24].umumiy, ortacha, ob.list[24].max, ob.list[24].min);
                    else
                        if (ob.list[24].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[24].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[24].Display, ob.list[24].umumiy, ortacha, ob.list[24].max, ob.list[24].min);
                    tt = true;
                }
                if (t[25])
                {
                    ortacha = ob.list[25].ortacha / ob.list[25].umumiy;
                    if (tt)
                        if (ob.list[25].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[25].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[25].Display, ob.list[25].umumiy, ortacha, ob.list[25].max, ob.list[25].min);
                    else
                        if (ob.list[25].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[25].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[25].Display, ob.list[25].umumiy, ortacha, ob.list[25].max, ob.list[25].min);
                    tt = true;
                }
                if (t[26])
                {
                    ortacha = ob.list[26].ortacha / ob.list[26].umumiy;
                    if (tt)
                        if (ob.list[26].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[26].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[26].Display, ob.list[26].umumiy, ortacha, ob.list[26].max, ob.list[26].min);
                    else
                        if (ob.list[26].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[26].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[26].Display, ob.list[26].umumiy, ortacha, ob.list[26].max, ob.list[26].min);
                    tt = true;
                }
                if (t[27])
                {
                    ortacha = ob.list[27].ortacha / ob.list[27].umumiy;
                    if (tt)
                        if (ob.list[27].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[27].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[27].Display, ob.list[27].umumiy, ortacha, ob.list[27].max, ob.list[27].min);
                    else
                        if (ob.list[27].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[27].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[27].Display, ob.list[27].umumiy, ortacha, ob.list[27].max, ob.list[27].min);
                    tt = true;
                }
                if (t[28])
                {
                    ortacha = ob.list[28].ortacha / ob.list[28].umumiy;
                    if (tt)
                        if (ob.list[28].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[28].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[28].Display, ob.list[28].umumiy, ortacha, ob.list[28].max, ob.list[28].min);
                    else
                        if (ob.list[28].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[28].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[28].Display, ob.list[28].umumiy, ortacha, ob.list[28].max, ob.list[28].min);
                    tt = true;
                }
                if (t[29])
                {
                    ortacha = ob.list[29].ortacha / ob.list[29].umumiy;
                    if (tt)
                        if (ob.list[29].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[29].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[29].Display, ob.list[29].umumiy, ortacha, ob.list[29].max, ob.list[29].min);
                    else
                        if (ob.list[29].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[29].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[29].Display, ob.list[29].umumiy, ortacha, ob.list[29].max, ob.list[29].min);
                    tt = true;
                }
                if (t[30])
                {
                    ortacha = ob.list[30].ortacha / ob.list[30].umumiy;
                    if (tt)
                        if (ob.list[30].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[30].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[30].Display, ob.list[30].umumiy, ortacha, ob.list[30].max, ob.list[30].min);
                    else
                        if (ob.list[30].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[30].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[30].Display, ob.list[30].umumiy, ortacha, ob.list[30].max, ob.list[30].min);
                    tt = true;
                }
                if (t[31])
                {
                    ortacha = ob.list[31].ortacha / ob.list[31].umumiy;
                    if (tt)
                        if (ob.list[31].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[31].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[31].Display, ob.list[31].umumiy, ortacha, ob.list[31].max, ob.list[31].min);
                    else
                        if (ob.list[31].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[31].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[31].Display, ob.list[31].umumiy, ortacha, ob.list[31].max, ob.list[31].min);
                    tt = true;
                }
                if (t[32])
                {
                    ortacha = ob.list[32].ortacha / ob.list[32].umumiy;
                    if (tt)
                        if (ob.list[32].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[32].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[32].Display, ob.list[32].umumiy, ortacha, ob.list[32].max, ob.list[32].min);
                    else
                        if (ob.list[32].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[32].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[32].Display, ob.list[32].umumiy, ortacha, ob.list[32].max, ob.list[32].min);
                    tt = true;
                }
                if (t[33])
                {
                    ortacha = ob.list[33].ortacha / ob.list[33].umumiy;
                    if (tt)
                        if (ob.list[33].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[33].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[33].Display, ob.list[33].umumiy, ortacha, ob.list[33].max, ob.list[33].min);
                    else
                        if (ob.list[33].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[33].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[33].Display, ob.list[33].umumiy, ortacha, ob.list[33].max, ob.list[33].min);
                    tt = true;
                }
                if (t[34])
                {
                    ortacha = ob.list[34].ortacha / ob.list[34].umumiy;
                    if (tt)
                        if (ob.list[34].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[34].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[34].Display, ob.list[34].umumiy, ortacha, ob.list[34].max, ob.list[34].min);
                    else
                        if (ob.list[34].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[34].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[34].Display, ob.list[34].umumiy, ortacha, ob.list[34].max, ob.list[34].min);
                    tt = true;
                }
                if (t[35])
                {
                    ortacha = ob.list[35].ortacha / ob.list[35].umumiy;
                    if (tt)
                        if (ob.list[35].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[35].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[35].Display, ob.list[35].umumiy, ortacha, ob.list[35].max, ob.list[35].min);
                    else
                        if (ob.list[35].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[35].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[35].Display, ob.list[35].umumiy, ortacha, ob.list[35].max, ob.list[35].min);
                    tt = true;
                }
                if (t[36])
                {
                    ortacha = ob.list[36].ortacha / ob.list[36].umumiy;
                    if (tt)
                        if (ob.list[36].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[36].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[36].Display, ob.list[36].umumiy, ortacha, ob.list[36].max, ob.list[36].min);
                    else
                        if (ob.list[36].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[36].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[36].Display, ob.list[36].umumiy, ortacha, ob.list[36].max, ob.list[36].min);
                    tt = true;
                }
                if (t[37])
                {
                    ortacha = ob.list[37].ortacha / ob.list[37].umumiy;
                    if (tt)
                        if (ob.list[37].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[37].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[37].Display, ob.list[37].umumiy, ortacha, ob.list[37].max, ob.list[37].min);
                    else
                        if (ob.list[37].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[37].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[37].Display, ob.list[37].umumiy, ortacha, ob.list[37].max, ob.list[37].min);
                    tt = true;
                }
                if (t[38])
                {
                    ortacha = ob.list[38].ortacha / ob.list[38].umumiy;
                    if (tt)
                        if (ob.list[38].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[38].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[38].Display, ob.list[38].umumiy, ortacha, ob.list[38].max, ob.list[38].min);
                    else
                        if (ob.list[38].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[38].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[38].Display, ob.list[38].umumiy, ortacha, ob.list[38].max, ob.list[38].min);
                    tt = true;
                }
                if (t[39])
                {
                    ortacha = ob.list[39].ortacha / ob.list[39].umumiy;
                    if (tt)
                        if (ob.list[39].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[39].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[39].Display, ob.list[39].umumiy, ortacha, ob.list[39].max, ob.list[39].min);
                    else
                        if (ob.list[39].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[39].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[39].Display, ob.list[39].umumiy, ortacha, ob.list[39].max, ob.list[39].min);
                    tt = true;
                }
                if (t[40])
                {
                    ortacha = ob.list[40].ortacha / ob.list[40].umumiy;
                    if (tt)
                        if (ob.list[40].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[40].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[40].Display, ob.list[40].umumiy, ortacha, ob.list[40].max, ob.list[40].min);
                    else
                        if (ob.list[40].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[40].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[40].Display, ob.list[40].umumiy, ortacha, ob.list[40].max, ob.list[40].min);
                    tt = true;
                }
                if (t[41])
                {
                    ortacha = ob.list[41].ortacha / ob.list[41].umumiy;
                    if (tt)
                        if (ob.list[41].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[41].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[41].Display, ob.list[41].umumiy, ortacha, ob.list[41].max, ob.list[41].min);
                    else
                        if (ob.list[41].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[41].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[41].Display, ob.list[41].umumiy, ortacha, ob.list[41].max, ob.list[41].min);
                    tt = true;
                }
                if (t[42])
                {
                    ortacha = ob.list[42].ortacha / ob.list[42].umumiy;
                    if (tt)
                        if (ob.list[42].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[42].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[42].Display, ob.list[42].umumiy, ortacha, ob.list[42].max, ob.list[42].min);
                    else
                        if (ob.list[42].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[42].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[42].Display, ob.list[42].umumiy, ortacha, ob.list[42].max, ob.list[42].min);
                    tt = true;
                }
                if (t[43])
                {
                    ortacha = ob.list[43].ortacha / ob.list[43].umumiy;
                    if (tt)
                        if (ob.list[43].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[43].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[43].Display, ob.list[43].umumiy, ortacha, ob.list[43].max, ob.list[43].min);
                    else
                        if (ob.list[43].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[43].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[43].Display, ob.list[43].umumiy, ortacha, ob.list[43].max, ob.list[43].min);
                    tt = true;
                }
                if (t[44])
                {
                    ortacha = ob.list[44].ortacha / ob.list[44].umumiy;
                    if (tt)
                        if (ob.list[44].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[44].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[44].Display, ob.list[44].umumiy, ortacha, ob.list[44].max, ob.list[44].min);
                    else
                        if (ob.list[44].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[44].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[44].Display, ob.list[44].umumiy, ortacha, ob.list[44].max, ob.list[44].min);
                    tt = true;
                }
                if (t[45])
                {
                    ortacha = ob.list[45].ortacha / ob.list[45].umumiy;
                    if (tt)
                        if (ob.list[45].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[45].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[45].Display, ob.list[45].umumiy, ortacha, ob.list[45].max, ob.list[45].min);
                    else
                        if (ob.list[45].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[45].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[45].Display, ob.list[45].umumiy, ortacha, ob.list[45].max, ob.list[45].min);
                    tt = true;
                }
                if (t[46])
                {
                    ortacha = ob.list[46].ortacha / ob.list[46].umumiy;
                    if (tt)
                        if (ob.list[46].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[46].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[46].Display, ob.list[46].umumiy, ortacha, ob.list[46].max, ob.list[46].min);
                    else
                        if (ob.list[46].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[46].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[46].Display, ob.list[46].umumiy, ortacha, ob.list[46].max, ob.list[46].min);
                    tt = true;
                }
                if (t[47])
                {
                    ortacha = ob.list[47].ortacha / ob.list[47].umumiy;
                    if (tt)
                        if (ob.list[47].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[47].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[47].Display, ob.list[47].umumiy, ortacha, ob.list[47].max, ob.list[47].min);
                    else
                        if (ob.list[47].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[47].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[47].Display, ob.list[47].umumiy, ortacha, ob.list[47].max, ob.list[47].min);
                    tt = true;
                }
                if (t[48])
                {
                    ortacha = ob.list[48].ortacha / ob.list[48].umumiy;
                    if (tt)
                        if (ob.list[48].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[48].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[48].Display, ob.list[48].umumiy, ortacha, ob.list[48].max, ob.list[48].min);
                    else
                        if (ob.list[48].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[48].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[48].Display, ob.list[48].umumiy, ortacha, ob.list[48].max, ob.list[48].min);
                    tt = true;
                }
                if (t[49])
                {
                    ortacha = ob.list[49].ortacha / ob.list[49].umumiy;
                    if (tt)
                        if (ob.list[49].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[49].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[49].Display, ob.list[49].umumiy, ortacha, ob.list[49].max, ob.list[49].min);
                    else
                        if (ob.list[49].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[49].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[49].Display, ob.list[49].umumiy, ortacha, ob.list[49].max, ob.list[49].min);
                    tt = true;
                }
                if (t[50])
                {
                    ortacha = ob.list[50].ortacha / ob.list[50].umumiy;
                    if (tt)
                        if (ob.list[50].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[50].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[50].Display, ob.list[50].umumiy, ortacha, ob.list[50].max, ob.list[50].min);
                    else
                        if (ob.list[50].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[50].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[50].Display, ob.list[50].umumiy, ortacha, ob.list[50].max, ob.list[50].min);
                    tt = true;
                }
                if (t[51])
                {
                    ortacha = ob.list[51].ortacha / ob.list[51].umumiy;
                    if (tt)
                        if (ob.list[51].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[51].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[51].Display, ob.list[51].umumiy, ortacha, ob.list[51].max, ob.list[51].min);
                    else
                        if (ob.list[51].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[51].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[51].Display, ob.list[51].umumiy, ortacha, ob.list[51].max, ob.list[51].min);
                    tt = true;
                }
                if (t[52])
                {
                    ortacha = ob.list[52].ortacha / ob.list[52].umumiy;
                    if (tt)
                        if (ob.list[52].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[52].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[52].Display, ob.list[52].umumiy, ortacha, ob.list[52].max, ob.list[52].min);
                    else
                        if (ob.list[52].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[52].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[52].Display, ob.list[52].umumiy, ortacha, ob.list[52].max, ob.list[52].min);
                    tt = true;
                }
                if (t[53])
                {
                    ortacha = ob.list[53].ortacha / ob.list[53].umumiy;
                    if (tt)
                        if (ob.list[53].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[53].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[53].Display, ob.list[53].umumiy, ortacha, ob.list[53].max, ob.list[53].min);
                    else
                        if (ob.list[53].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[53].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[53].Display, ob.list[53].umumiy, ortacha, ob.list[53].max, ob.list[53].min);
                    tt = true;
                }
                if (t[54])
                {
                    ortacha = ob.list[54].ortacha / ob.list[54].umumiy;
                    if (tt)
                        if (ob.list[54].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[54].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[54].Display, ob.list[54].umumiy, ortacha, ob.list[54].max, ob.list[54].min);
                    else
                        if (ob.list[54].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[54].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[54].Display, ob.list[54].umumiy, ortacha, ob.list[54].max, ob.list[54].min);
                    tt = true;
                }
                if (t[55])
                {
                    ortacha = ob.list[55].ortacha / ob.list[55].umumiy;
                    if (tt)
                        if (ob.list[55].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[55].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[55].Display, ob.list[55].umumiy, ortacha, ob.list[55].max, ob.list[55].min);
                    else
                        if (ob.list[55].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[55].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[55].Display, ob.list[55].umumiy, ortacha, ob.list[55].max, ob.list[55].min);
                    tt = true;
                }
                if (t[56])
                {
                    ortacha = ob.list[56].ortacha / ob.list[56].umumiy;
                    if (tt)
                        if (ob.list[56].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[56].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[56].Display, ob.list[56].umumiy, ortacha, ob.list[56].max, ob.list[56].min);
                    else
                        if (ob.list[56].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[56].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[56].Display, ob.list[56].umumiy, ortacha, ob.list[56].max, ob.list[56].min);
                    tt = true;
                }
                if (t[57])
                {
                    ortacha = ob.list[57].ortacha / ob.list[57].umumiy;
                    if (tt)
                        if (ob.list[57].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[57].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[57].Display, ob.list[57].umumiy, ortacha, ob.list[57].max, ob.list[57].min);
                    else
                        if (ob.list[57].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[57].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[57].Display, ob.list[57].umumiy, ortacha, ob.list[57].max, ob.list[57].min);
                    tt = true;
                }
                if (t[58])
                {
                    ortacha = ob.list[58].ortacha / ob.list[58].umumiy;
                    if (tt)
                        if (ob.list[58].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[58].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[58].Display, ob.list[58].umumiy, ortacha, ob.list[58].max, ob.list[58].min);
                    else
                        if (ob.list[58].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[58].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[58].Display, ob.list[58].umumiy, ortacha, ob.list[58].max, ob.list[58].min);
                    tt = true;
                }
                if (t[59])
                {
                    ortacha = ob.list[59].ortacha / ob.list[59].umumiy;
                    if (tt)
                        if (ob.list[59].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[59].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[59].Display, ob.list[59].umumiy, ortacha, ob.list[59].max, ob.list[59].min);
                    else
                        if (ob.list[59].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[59].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[59].Display, ob.list[59].umumiy, ortacha, ob.list[59].max, ob.list[59].min);
                    tt = true;
                }
                if (t[60])
                {
                    ortacha = ob.list[60].ortacha / ob.list[60].umumiy;
                    if (tt)
                        if (ob.list[60].umumiy == 0)
                            dataGridView1.Rows.Add(null, koms[60].Display);
                        else
                            dataGridView1.Rows.Add(null, koms[60].Display, ob.list[60].umumiy, ortacha, ob.list[60].max, ob.list[60].min);
                    else
                        if (ob.list[60].umumiy == 0)
                        dataGridView1.Rows.Add(ob.post, koms[60].Display);
                    else
                        dataGridView1.Rows.Add(ob.post, koms[60].Display, ob.list[60].umumiy, ortacha, ob.list[60].max, ob.list[60].min);
                    tt = true;
                }

            }
            Column10.Visible = false;
            Column8.Visible = false;
            Column9.Visible = false;
            Column7.Visible = false;
        }

        public HisobotPDKForm(List<HisobotPostPDK> result, List<HisobotPostPDK> result1, KompanentaClass[] koms, bool[] t, int Year, byte key)
        {
            InitializeComponent();
            this.Year = Year;
            if (key == 0)
                Text = "Характеристика загрязнения поверхностных вод по постам за " + (Year - 1).ToString() + "-" + Year.ToString() + " годов";
            else
            if (key == 1)
                Text = "Характеристика загрязнения поверхностных вод по постам в долях за " + (Year - 1).ToString() + "-" + Year.ToString() + " годов";
            else
            if (key == 2)
                Text = "Характеристика загрязнения поверхностных вод по бассейнам рек в долях за " + (Year - 1).ToString() + "-" + Year.ToString() + " годов";
            else
                Text = "Характеристика загрязнения поверхностных вод по бассейнам рек за " + (Year - 1).ToString() + "-" + Year.ToString() + " годов";
            double ortacha, ortacha2;
            bool tt;
            //MessageBox.Show(result.Count.ToString() + " = " + result1.Count.ToString());
            for (int i = 0; i < result.Count; i++)
            {
                tt = false;
                if (t[0])
                {
                    ortacha = result[i].list[0].ortacha / result[i].list[0].umumiy;
                    ortacha2 = result1[i].list[0].ortacha / result1[i].list[0].umumiy;
                    if (tt)
                        if (result[i].list[0].umumiy != 0 && result1[i].list[0].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[0].Display, result[i].list[0].umumiy, ortacha,
                                result[i].list[0].max, result[i].list[0].min, result1[i].list[0].umumiy, ortacha2,
                                result1[i].list[0].max, result1[i].list[0].min);
                        else if (result[i].list[0].umumiy != 0 && result[i].list[0].max != 0 && result[i].list[0].min > 0)
                            dataGridView1.Rows.Add(null, koms[0].Display, result[i].list[0].umumiy, ortacha,
                                result[i].list[0].max, result[i].list[0].min, null, null, null, null);
                        else if (result1[i].list[0].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[0].Display, null, null, null, null, result1[i].list[0].umumiy,
                                ortacha2, result1[i].list[0].max, result1[i].list[0].min);
                        else
                            dataGridView1.Rows.Add(null, koms[0].Display);
                    else if (result[i].list[0].umumiy != 0 && result1[i].list[0].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[0].Display, result[i].list[0].umumiy, ortacha,
                            result[i].list[0].max, result[i].list[0].min, result1[i].list[0].umumiy, ortacha2,
                            result1[i].list[0].max, result1[i].list[0].min);
                    else if (result[i].list[0].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[0].Display, result[i].list[0].umumiy, ortacha,
                            result[i].list[0].max, result[i].list[0].min, null, null, null, null);
                    else if (result1[i].list[0].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[0].Display, null, null, null, null, result1[i].list[0].umumiy,
                                ortacha2, result1[i].list[0].max, result1[i].list[0].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[0].Display);
                    tt = true;
                }
                if (t[1])
                {
                    ortacha = result[i].list[1].ortacha / result[i].list[1].umumiy;
                    ortacha2 = result1[i].list[1].ortacha / result1[i].list[1].umumiy;
                    if (tt)
                        if (result[i].list[1].umumiy != 0 && result1[i].list[1].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[1].Display, result[i].list[1].umumiy, ortacha,
                                result[i].list[1].max, result[i].list[1].min, result1[i].list[1].umumiy, ortacha2,
                                result1[i].list[1].max, result1[i].list[1].min);
                        else if (result[i].list[1].umumiy != 0 )
                            dataGridView1.Rows.Add(null, koms[1].Display, result[i].list[1].umumiy, ortacha,
                                result[i].list[1].max, result[i].list[1].min, null, null, null, null);
                        else if (result1[i].list[1].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[1].Display, null, null, null, null, result1[i].list[1].umumiy,
                                ortacha2, result1[i].list[1].max, result1[i].list[1].min);
                        else
                            dataGridView1.Rows.Add(null, koms[1].Display);
                    else if (result[i].list[1].umumiy != 0 && result1[i].list[1].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[1].Display, result[i].list[1].umumiy, ortacha,
                            result[i].list[1].max, result[i].list[1].min, result1[i].list[1].umumiy, ortacha2,
                            result1[i].list[1].max, result1[i].list[1].min);
                    else if (result[i].list[1].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[1].Display, result[i].list[1].umumiy, ortacha,
                            result[i].list[1].max, result[i].list[1].min, null, null, null, null);
                    else if (result1[i].list[1].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[1].Display, null, null, null, null, result1[i].list[1].umumiy,
                                ortacha2, result1[i].list[1].max, result1[i].list[1].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[1].Display);
                    tt = true;
                }
                if (t[2])
                {
                    ortacha = result[i].list[2].ortacha / result[i].list[2].umumiy;
                    ortacha2 = result1[i].list[2].ortacha / result1[i].list[2].umumiy;
                    if (tt)
                        if (result[i].list[2].umumiy != 0 && result1[i].list[2].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[2].Display, result[i].list[2].umumiy, ortacha,
                                result[i].list[2].max, result[i].list[2].min, result1[i].list[2].umumiy, ortacha2,
                                result1[i].list[2].max, result1[i].list[2].min);
                        else if (result[i].list[2].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[2].Display, result[i].list[2].umumiy, ortacha,
                                result[i].list[2].max, result[i].list[2].min, null, null, null, null);
                        else if (result1[i].list[2].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[2].Display, null, null, null, null, result1[i].list[2].umumiy,
                                ortacha2, result1[i].list[2].max, result1[i].list[2].min);
                        else
                            dataGridView1.Rows.Add(null, koms[2].Display);
                    else if (result[i].list[2].umumiy != 0 && result1[i].list[2].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[2].Display, result[i].list[2].umumiy, ortacha,
                            result[i].list[2].max, result[i].list[2].min, result1[i].list[2].umumiy, ortacha2,
                            result1[i].list[2].max, result1[i].list[2].min);
                    else if (result[i].list[2].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[2].Display, result[i].list[2].umumiy, ortacha,
                            result[i].list[2].max, result[i].list[2].min, null, null, null, null);
                    else if (result1[i].list[2].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[2].Display, null, null, null, null, result1[i].list[2].umumiy,
                                ortacha2, result1[i].list[2].max, result1[i].list[2].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[2].Display);
                    tt = true;
                }
                if (t[3])
                {
                    ortacha = result[i].list[3].ortacha / result[i].list[3].umumiy;
                    ortacha2 = result1[i].list[3].ortacha / result1[i].list[3].umumiy;
                    if (tt)
                        if (result[i].list[3].umumiy != 0 && result1[i].list[3].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[3].Display, result[i].list[3].umumiy, ortacha,
                                result[i].list[3].max, result[i].list[3].min, result1[i].list[3].umumiy, ortacha2,
                                result1[i].list[3].max, result1[i].list[3].min);
                        else if (result[i].list[3].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[3].Display, result[i].list[3].umumiy, ortacha,
                                result[i].list[3].max, result[i].list[3].min, null, null, null, null);
                        else if (result1[i].list[3].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[3].Display, null, null, null, null, result1[i].list[3].umumiy,
                                ortacha2, result1[i].list[3].max, result1[i].list[3].min);
                        else
                            dataGridView1.Rows.Add(null, koms[3].Display);
                    else if (result[i].list[3].umumiy != 0 && result1[i].list[3].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[3].Display, result[i].list[3].umumiy, ortacha,
                            result[i].list[3].max, result[i].list[3].min, result1[i].list[3].umumiy, ortacha2,
                            result1[i].list[3].max, result1[i].list[3].min);
                    else if (result[i].list[3].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[3].Display, result[i].list[3].umumiy, ortacha,
                            result[i].list[3].max, result[i].list[3].min, null, null, null, null);
                    else if (result1[i].list[3].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[3].Display, null, null, null, null, result1[i].list[3].umumiy,
                                ortacha2, result1[i].list[3].max, result1[i].list[3].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[3].Display);
                    tt = true;
                }
                if (t[4])
                {
                    ortacha = result[i].list[4].ortacha / result[i].list[4].umumiy;
                    ortacha2 = result1[i].list[4].ortacha / result1[i].list[4].umumiy;
                    if (tt)
                        if (result[i].list[4].umumiy != 0 && result1[i].list[4].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[4].Display, result[i].list[4].umumiy, ortacha,
                                result[i].list[4].max, result[i].list[4].min, result1[i].list[4].umumiy, ortacha2,
                                result1[i].list[4].max, result1[i].list[4].min);
                        else if (result[i].list[4].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[4].Display, result[i].list[4].umumiy, ortacha,
                                result[i].list[4].max, result[i].list[4].min, null, null, null, null);
                        else if (result1[i].list[4].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[4].Display, null, null, null, null, result1[i].list[4].umumiy,
                                ortacha2, result1[i].list[4].max, result1[i].list[4].min);
                        else
                            dataGridView1.Rows.Add(null, koms[4].Display);
                    else if (result[i].list[4].umumiy != 0 && result1[i].list[4].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[4].Display, result[i].list[4].umumiy, ortacha,
                            result[i].list[4].max, result[i].list[4].min, result1[i].list[4].umumiy, ortacha2,
                            result1[i].list[4].max, result1[i].list[4].min);
                    else if (result[i].list[4].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[4].Display, result[i].list[4].umumiy, ortacha,
                            result[i].list[4].max, result[i].list[4].min, null, null, null, null);
                    else if (result1[i].list[4].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[4].Display, null, null, null, null, result1[i].list[4].umumiy,
                                ortacha2, result1[i].list[4].max, result1[i].list[4].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[4].Display);
                    tt = true;
                }
                if (t[5])
                {
                    ortacha = result[i].list[5].ortacha / result[i].list[5].umumiy;
                    ortacha2 = result1[i].list[5].ortacha / result1[i].list[5].umumiy;
                    if (tt)
                        if (result[i].list[5].umumiy != 0 && result1[i].list[5].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[5].Display, result[i].list[5].umumiy, ortacha,
                                result[i].list[5].max, result[i].list[5].min, result1[i].list[5].umumiy, ortacha2,
                                result1[i].list[5].max, result1[i].list[5].min);
                        else if (result[i].list[5].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[5].Display, result[i].list[5].umumiy, ortacha,
                                result[i].list[5].max, result[i].list[5].min, null, null, null, null);
                        else if (result1[i].list[5].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[5].Display, null, null, null, null, result1[i].list[5].umumiy,
                                ortacha2, result1[i].list[5].max, result1[i].list[5].min);
                        else
                            dataGridView1.Rows.Add(null, koms[5].Display);
                    else if (result[i].list[5].umumiy != 0 && result1[i].list[5].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[5].Display, result[i].list[5].umumiy, ortacha,
                            result[i].list[5].max, result[i].list[5].min, result1[i].list[5].umumiy, ortacha2,
                            result1[i].list[5].max, result1[i].list[5].min);
                    else if (result[i].list[5].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[5].Display, result[i].list[5].umumiy, ortacha,
                            result[i].list[5].max, result[i].list[5].min, null, null, null, null);
                    else if (result1[i].list[5].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[5].Display, null, null, null, null, result1[i].list[5].umumiy,
                                ortacha2, result1[i].list[5].max, result1[i].list[5].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[5].Display);
                    tt = true;
                }
                if (t[6])
                {
                    ortacha = result[i].list[6].ortacha / result[i].list[6].umumiy;
                    ortacha2 = result1[i].list[6].ortacha / result1[i].list[6].umumiy;
                    if (tt)
                        if (result[i].list[6].umumiy != 0 && result1[i].list[6].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[6].Display, result[i].list[6].umumiy, ortacha,
                                result[i].list[6].max, result[i].list[6].min, result1[i].list[6].umumiy, ortacha2,
                                result1[i].list[6].max, result1[i].list[6].min);
                        else if (result[i].list[6].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[6].Display, result[i].list[6].umumiy, ortacha,
                                result[i].list[6].max, result[i].list[6].min, null, null, null, null);
                        else if (result1[i].list[6].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[6].Display, null, null, null, null, result1[i].list[6].umumiy,
                                ortacha2, result1[i].list[6].max, result1[i].list[6].min);
                        else
                            dataGridView1.Rows.Add(null, koms[6].Display);
                    else if (result[i].list[6].umumiy != 0 && result1[i].list[6].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[6].Display, result[i].list[6].umumiy, ortacha,
                            result[i].list[6].max, result[i].list[6].min, result1[i].list[6].umumiy, ortacha2,
                            result1[i].list[6].max, result1[i].list[6].min);
                    else if (result[i].list[6].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[6].Display, result[i].list[6].umumiy, ortacha,
                            result[i].list[6].max, result[i].list[6].min, null, null, null, null);
                    else if (result1[i].list[6].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[6].Display, null, null, null, null, result1[i].list[6].umumiy,
                                ortacha2, result1[i].list[6].max, result1[i].list[6].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[6].Display);
                    tt = true;
                }
                if (t[7])
                {
                    ortacha = result[i].list[7].ortacha / result[i].list[7].umumiy;
                    ortacha2 = result1[i].list[7].ortacha / result1[i].list[7].umumiy;
                    if (tt)
                        if (result[i].list[7].umumiy != 0 && result1[i].list[7].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[7].Display, result[i].list[7].umumiy, ortacha,
                                result[i].list[7].max, result[i].list[7].min, result1[i].list[7].umumiy, ortacha2,
                                result1[i].list[7].max, result1[i].list[7].min);
                        else if (result[i].list[7].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[7].Display, result[i].list[7].umumiy, ortacha,
                                result[i].list[7].max, result[i].list[7].min, null, null, null, null);
                        else if (result1[i].list[7].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[7].Display, null, null, null, null, result1[i].list[7].umumiy,
                                ortacha2, result1[i].list[7].max, result1[i].list[7].min);
                        else
                            dataGridView1.Rows.Add(null, koms[7].Display);
                    else if (result[i].list[7].umumiy != 0 && result1[i].list[7].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[7].Display, result[i].list[7].umumiy, ortacha,
                            result[i].list[7].max, result[i].list[7].min, result1[i].list[7].umumiy, ortacha2,
                            result1[i].list[7].max, result1[i].list[7].min);
                    else if (result[i].list[7].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[7].Display, result[i].list[7].umumiy, ortacha,
                            result[i].list[7].max, result[i].list[7].min, null, null, null, null);
                    else if (result1[i].list[7].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[7].Display, null, null, null, null, result1[i].list[7].umumiy,
                                ortacha2, result1[i].list[7].max, result1[i].list[7].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[7].Display);
                    tt = true;
                }
                if (t[8])
                {
                    ortacha = result[i].list[8].ortacha / result[i].list[8].umumiy;
                    ortacha2 = result1[i].list[8].ortacha / result1[i].list[8].umumiy;
                    if (tt)
                        if (result[i].list[8].umumiy != 0 && result1[i].list[8].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[8].Display, result[i].list[8].umumiy, ortacha,
                                result[i].list[8].max, result[i].list[8].min, result1[i].list[8].umumiy, ortacha2,
                                result1[i].list[8].max, result1[i].list[8].min);
                        else if (result[i].list[8].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[8].Display, result[i].list[8].umumiy, ortacha,
                                result[i].list[8].max, result[i].list[8].min, null, null, null, null);
                        else if (result1[i].list[8].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[8].Display, null, null, null, null, result1[i].list[8].umumiy,
                                ortacha2, result1[i].list[8].max, result1[i].list[8].min);
                        else
                            dataGridView1.Rows.Add(null, koms[8].Display);
                    else if (result[i].list[8].umumiy != 0 && result1[i].list[8].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[8].Display, result[i].list[8].umumiy, ortacha,
                            result[i].list[8].max, result[i].list[8].min, result1[i].list[8].umumiy, ortacha2,
                            result1[i].list[8].max, result1[i].list[8].min);
                    else if (result[i].list[8].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[8].Display, result[i].list[8].umumiy, ortacha,
                            result[i].list[8].max, result[i].list[8].min, null, null, null, null);
                    else if (result1[i].list[8].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[8].Display, null, null, null, null, result1[i].list[8].umumiy,
                                ortacha2, result1[i].list[8].max, result1[i].list[8].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[8].Display);
                    tt = true;
                }
                if (t[9])
                {
                    ortacha = result[i].list[9].ortacha / result[i].list[9].umumiy;
                    ortacha2 = result1[i].list[9].ortacha / result1[i].list[9].umumiy;
                    if (tt)
                        if (result[i].list[9].umumiy != 0 && result1[i].list[9].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[9].Display, result[i].list[9].umumiy, ortacha,
                                result[i].list[9].max, result[i].list[9].min, result1[i].list[9].umumiy, ortacha2,
                                result1[i].list[9].max, result1[i].list[9].min);
                        else if (result[i].list[9].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[9].Display, result[i].list[9].umumiy, ortacha,
                                result[i].list[9].max, result[i].list[9].min, null, null, null, null);
                        else if (result1[i].list[9].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[9].Display, null, null, null, null, result1[i].list[9].umumiy,
                                ortacha2, result1[i].list[9].max, result1[i].list[9].min);
                        else
                            dataGridView1.Rows.Add(null, koms[9].Display);
                    else if (result[i].list[9].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[9].Display, result[i].list[9].umumiy, ortacha,
                            result[i].list[9].max, result[i].list[9].min, result1[i].list[9].umumiy, ortacha2,
                            result1[i].list[9].max, result1[i].list[9].min);
                    else if (result[i].list[9].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[9].Display, result[i].list[9].umumiy, ortacha,
                            result[i].list[9].max, result[i].list[9].min, null, null, null, null);
                    else if (result1[i].list[9].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[9].Display, null, null, null, null, result1[i].list[9].umumiy,
                                ortacha2, result1[i].list[9].max, result1[i].list[9].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[9].Display);
                    tt = true;
                }
                if (t[10])
                {
                    ortacha = result[i].list[10].ortacha / result[i].list[10].umumiy;
                    ortacha2 = result1[i].list[10].ortacha / result1[i].list[10].umumiy;
                    if (tt)
                        if (result[i].list[10].umumiy != 0 && result1[i].list[10].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[10].Display, result[i].list[10].umumiy, ortacha,
                                result[i].list[10].max, result[i].list[10].min, result1[i].list[10].umumiy, ortacha2,
                                result1[i].list[10].max, result1[i].list[10].min);
                        else if (result[i].list[10].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[10].Display, result[i].list[10].umumiy, ortacha,
                                result[i].list[10].max, result[i].list[10].min, null, null, null, null);
                        else if (result1[i].list[10].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[10].Display, null, null, null, null, result1[i].list[10].umumiy,
                                ortacha2, result1[i].list[10].max, result1[i].list[10].min);
                        else
                            dataGridView1.Rows.Add(null, koms[10].Display);
                    else if (result[i].list[10].umumiy != 0 && result1[i].list[10].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[10].Display, result[i].list[10].umumiy, ortacha,
                            result[i].list[10].max, result[i].list[10].min, result1[i].list[10].umumiy, ortacha2,
                            result1[i].list[10].max, result1[i].list[10].min);
                    else if (result[i].list[10].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[10].Display, result[i].list[10].umumiy, ortacha,
                            result[i].list[10].max, result[i].list[10].min, null, null, null, null);
                    else if (result1[i].list[10].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[10].Display, null, null, null, null, result1[i].list[10].umumiy,
                                ortacha2, result1[i].list[10].max, result1[i].list[10].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[10].Display);
                    tt = true;
                }
                if (t[11])
                {
                    ortacha = result[i].list[11].ortacha / result[i].list[11].umumiy;
                    ortacha2 = result1[i].list[11].ortacha / result1[i].list[11].umumiy;
                    if (tt)
                        if (result[i].list[11].umumiy != 0 && result1[i].list[11].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[11].Display, result[i].list[11].umumiy, ortacha,
                                result[i].list[11].max, result[i].list[11].min, result1[i].list[11].umumiy, ortacha2,
                                result1[i].list[11].max, result1[i].list[11].min);
                        else if (result[i].list[11].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[11].Display, result[i].list[11].umumiy, ortacha,
                                result[i].list[11].max, result[i].list[11].min, null, null, null, null);
                        else if (result1[i].list[11].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[11].Display, null, null, null, null, result1[i].list[11].umumiy,
                                ortacha2, result1[i].list[11].max, result1[i].list[11].min);
                        else
                            dataGridView1.Rows.Add(null, koms[11].Display);
                    else if (result[i].list[11].umumiy != 0 && result1[i].list[11].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[11].Display, result[i].list[11].umumiy, ortacha,
                            result[i].list[11].max, result[i].list[11].min, result1[i].list[11].umumiy, ortacha2,
                            result1[i].list[11].max, result1[i].list[11].min);
                    else if (result[i].list[11].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[11].Display, result[i].list[11].umumiy, ortacha,
                            result[i].list[11].max, result[i].list[11].min, null, null, null, null);
                    else if (result1[i].list[11].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[11].Display, null, null, null, null, result1[i].list[11].umumiy,
                                ortacha2, result1[i].list[11].max, result1[i].list[11].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[11].Display);
                    tt = true;
                }
                if (t[12])
                {
                    ortacha = result[i].list[12].ortacha / result[i].list[12].umumiy;
                    ortacha2 = result1[i].list[12].ortacha / result1[i].list[12].umumiy;
                    if (tt)
                        if (result[i].list[12].umumiy != 0 && result1[i].list[12].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[12].Display, result[i].list[12].umumiy, ortacha,
                                result[i].list[12].max, result[i].list[12].min, result1[i].list[12].umumiy, ortacha2,
                                result1[i].list[12].max, result1[i].list[12].min);
                        else if (result[i].list[12].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[12].Display, result[i].list[12].umumiy, ortacha,
                                result[i].list[12].max, result[i].list[12].min, null, null, null, null);
                        else if (result1[i].list[12].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[12].Display, null, null, null, null, result1[i].list[12].umumiy,
                                ortacha2, result1[i].list[12].max, result1[i].list[12].min);
                        else
                            dataGridView1.Rows.Add(null, koms[12].Display);
                    else if (result[i].list[12].umumiy != 0 && result1[i].list[12].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[12].Display, result[i].list[12].umumiy, ortacha,
                            result[i].list[12].max, result[i].list[12].min, result1[i].list[12].umumiy, ortacha2,
                            result1[i].list[12].max, result1[i].list[12].min);
                    else if (result[i].list[12].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[12].Display, result[i].list[12].umumiy, ortacha,
                            result[i].list[12].max, result[i].list[12].min, null, null, null, null);
                    else if (result1[i].list[12].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[12].Display, null, null, null, null, result1[i].list[12].umumiy,
                                ortacha2, result1[i].list[12].max, result1[i].list[12].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[12].Display);
                    tt = true;
                }
                if (t[13])
                {
                    ortacha = result[i].list[13].ortacha / result[i].list[13].umumiy;
                    ortacha2 = result1[i].list[13].ortacha / result1[i].list[13].umumiy;
                    if (tt)
                        if (result[i].list[13].umumiy != 0 && result1[i].list[13].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[13].Display, result[i].list[13].umumiy, ortacha,
                                result[i].list[13].max, result[i].list[13].min, result1[i].list[13].umumiy, ortacha2,
                                result1[i].list[13].max, result1[i].list[13].min);
                        else if (result[i].list[13].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[13].Display, result[i].list[13].umumiy, ortacha,
                                result[i].list[13].max, result[i].list[13].min, null, null, null, null);
                        else if (result1[i].list[13].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[13].Display, null, null, null, null, result1[i].list[13].umumiy,
                                ortacha2, result1[i].list[13].max, result1[i].list[13].min);
                        else
                            dataGridView1.Rows.Add(null, koms[13].Display);
                    else if (result[i].list[13].umumiy != 0 && result1[i].list[13].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[13].Display, result[i].list[13].umumiy, ortacha,
                            result[i].list[13].max, result[i].list[13].min, result1[i].list[13].umumiy, ortacha2,
                            result1[i].list[13].max, result1[i].list[13].min);
                    else if (result[i].list[13].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[13].Display, result[i].list[13].umumiy, ortacha,
                            result[i].list[13].max, result[i].list[13].min, null, null, null, null);
                    else if (result1[i].list[13].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[13].Display, null, null, null, null, result1[i].list[13].umumiy,
                                ortacha2, result1[i].list[13].max, result1[i].list[13].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[13].Display);
                    tt = true;
                }
                if (t[14])
                {
                    ortacha = result[i].list[14].ortacha / result[i].list[14].umumiy;
                    ortacha2 = result1[i].list[14].ortacha / result1[i].list[14].umumiy;
                    if (tt)
                        if (result[i].list[14].umumiy != 0 && result1[i].list[14].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[14].Display, result[i].list[14].umumiy, ortacha,
                                result[i].list[14].max, result[i].list[14].min, result1[i].list[14].umumiy, ortacha2,
                                result1[i].list[14].max, result1[i].list[14].min);
                        else if (result[i].list[14].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[14].Display, result[i].list[14].umumiy, ortacha,
                                result[i].list[14].max, result[i].list[14].min, null, null, null, null);
                        else if (result1[i].list[14].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[14].Display, null, null, null, null, result1[i].list[14].umumiy,
                                ortacha2, result1[i].list[14].max, result1[i].list[14].min);
                        else
                            dataGridView1.Rows.Add(null, koms[14].Display);
                    else if (result[i].list[14].umumiy != 0 && result1[i].list[14].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[14].Display, result[i].list[14].umumiy, ortacha,
                            result[i].list[14].max, result[i].list[14].min, result1[i].list[14].umumiy, ortacha2,
                            result1[i].list[14].max, result1[i].list[14].min);
                    else if (result[i].list[14].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[14].Display, result[i].list[14].umumiy, ortacha,
                            result[i].list[14].max, result[i].list[14].min, null, null, null, null);
                    else if (result1[i].list[14].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[14].Display, null, null, null, null, result1[i].list[14].umumiy,
                                ortacha2, result1[i].list[14].max, result1[i].list[14].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[14].Display);
                    tt = true;
                }
                if (t[15])
                {
                    ortacha = result[i].list[15].ortacha / result[i].list[15].umumiy;
                    ortacha2 = result1[i].list[15].ortacha / result1[i].list[15].umumiy;
                    if (tt)
                        if (result[i].list[15].umumiy != 0 && result1[i].list[15].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[15].Display, result[i].list[15].umumiy, ortacha,
                                result[i].list[15].max, result[i].list[15].min, result1[i].list[15].umumiy, ortacha2,
                                result1[i].list[15].max, result1[i].list[15].min);
                        else if (result[i].list[15].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[15].Display, result[i].list[15].umumiy, ortacha,
                                result[i].list[15].max, result[i].list[15].min, null, null, null, null);
                        else if (result1[i].list[15].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[15].Display, null, null, null, null, result1[i].list[15].umumiy,
                                ortacha2, result1[i].list[15].max, result1[i].list[15].min);
                        else
                            dataGridView1.Rows.Add(null, koms[15].Display);
                    else if (result[i].list[15].umumiy != 0 && result1[i].list[15].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[15].Display, result[i].list[15].umumiy, ortacha,
                            result[i].list[15].max, result[i].list[15].min, result1[i].list[15].umumiy, ortacha2,
                            result1[i].list[15].max, result1[i].list[15].min);
                    else if (result[i].list[15].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[15].Display, result[i].list[15].umumiy, ortacha,
                            result[i].list[15].max, result[i].list[15].min, null, null, null, null);
                    else if (result1[i].list[15].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[15].Display, null, null, null, null, result1[i].list[15].umumiy,
                                ortacha2, result1[i].list[15].max, result1[i].list[15].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[15].Display);
                    tt = true;
                }
                if (t[16])
                {
                    ortacha = result[i].list[16].ortacha / result[i].list[16].umumiy;
                    ortacha2 = result1[i].list[16].ortacha / result1[i].list[16].umumiy;
                    if (tt)
                        if (result[i].list[16].umumiy != 0 && result1[i].list[16].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[16].Display, result[i].list[16].umumiy, ortacha,
                                result[i].list[16].max, result[i].list[16].min, result1[i].list[16].umumiy, ortacha2,
                                result1[i].list[16].max, result1[i].list[16].min);
                        else if (result[i].list[16].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[16].Display, result[i].list[16].umumiy, ortacha,
                                result[i].list[16].max, result[i].list[16].min, null, null, null, null);
                        else if (result1[i].list[16].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[16].Display, null, null, null, null, result1[i].list[16].umumiy,
                                ortacha2, result1[i].list[16].max, result1[i].list[16].min);
                        else
                            dataGridView1.Rows.Add(null, koms[16].Display);
                    else if (result[i].list[16].umumiy != 0 && result1[i].list[16].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[16].Display, result[i].list[16].umumiy, ortacha,
                            result[i].list[16].max, result[i].list[16].min, result1[i].list[16].umumiy, ortacha2,
                            result1[i].list[16].max, result1[i].list[16].min);
                    else if (result[i].list[16].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[16].Display, result[i].list[16].umumiy, ortacha,
                            result[i].list[16].max, result[i].list[16].min, null, null, null, null);
                    else if (result1[i].list[16].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[16].Display, null, null, null, null, result1[i].list[16].umumiy,
                                ortacha2, result1[i].list[16].max, result1[i].list[16].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[16].Display);
                    tt = true;
                }
                if (t[17])
                {
                    ortacha = result[i].list[17].ortacha / result[i].list[17].umumiy;
                    ortacha2 = result1[i].list[17].ortacha / result1[i].list[17].umumiy;
                    if (tt)
                        if (result[i].list[17].umumiy != 0 && result1[i].list[17].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[17].Display, result[i].list[17].umumiy, ortacha,
                                result[i].list[17].max, result[i].list[17].min, result1[i].list[17].umumiy, ortacha2,
                                result1[i].list[17].max, result1[i].list[17].min);
                        else if (result[i].list[17].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[17].Display, result[i].list[17].umumiy, ortacha,
                                result[i].list[17].max, result[i].list[17].min, null, null, null, null);
                        else if (result1[i].list[17].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[17].Display, null, null, null, null, result1[i].list[17].umumiy,
                                ortacha2, result1[i].list[17].max, result1[i].list[17].min);
                        else
                            dataGridView1.Rows.Add(null, koms[17].Display);
                    else if (result[i].list[17].umumiy != 0 && result1[i].list[17].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[17].Display, result[i].list[17].umumiy, ortacha,
                            result[i].list[17].max, result[i].list[17].min, result1[i].list[17].umumiy, ortacha2,
                            result1[i].list[17].max, result1[i].list[17].min);
                    else if (result[i].list[17].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[17].Display, result[i].list[17].umumiy, ortacha,
                            result[i].list[17].max, result[i].list[17].min, null, null, null, null);
                    else if (result1[i].list[17].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[17].Display, null, null, null, null, result1[i].list[17].umumiy,
                                ortacha2, result1[i].list[17].max, result1[i].list[17].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[17].Display);
                    tt = true;
                }
                if (t[18])
                {
                    ortacha = result[i].list[18].ortacha / result[i].list[18].umumiy;
                    ortacha2 = result1[i].list[18].ortacha / result1[i].list[18].umumiy;
                    if (tt)
                        if (result[i].list[18].umumiy != 0 && result1[i].list[18].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[18].Display, result[i].list[18].umumiy, ortacha,
                                result[i].list[18].max, result[i].list[18].min, result1[i].list[18].umumiy, ortacha2,
                                result1[i].list[18].max, result1[i].list[18].min);
                        else if (result[i].list[18].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[18].Display, result[i].list[18].umumiy, ortacha,
                                result[i].list[18].max, result[i].list[18].min, null, null, null, null);
                        else if (result1[i].list[18].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[18].Display, null, null, null, null, result1[i].list[18].umumiy,
                                ortacha2, result1[i].list[18].max, result1[i].list[18].min);
                        else
                            dataGridView1.Rows.Add(null, koms[18].Display);
                    else if (result[i].list[18].umumiy != 0 && result1[i].list[18].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[18].Display, result[i].list[18].umumiy, ortacha,
                            result[i].list[18].max, result[i].list[18].min, result1[i].list[18].umumiy, ortacha2,
                            result1[i].list[18].max, result1[i].list[18].min);
                    else if (result[i].list[18].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[18].Display, result[i].list[18].umumiy, ortacha,
                            result[i].list[18].max, result[i].list[18].min, null, null, null, null);
                    else if (result1[i].list[18].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[18].Display, null, null, null, null, result1[i].list[18].umumiy,
                                ortacha2, result1[i].list[18].max, result1[i].list[18].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[18].Display);
                    tt = true;
                }
                if (t[19])
                {
                    ortacha = result[i].list[19].ortacha / result[i].list[19].umumiy;
                    ortacha2 = result1[i].list[19].ortacha / result1[i].list[19].umumiy;
                    if (tt)
                        if (result[i].list[19].umumiy != 0 && result1[i].list[19].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[19].Display, result[i].list[19].umumiy, ortacha,
                                result[i].list[19].max, result[i].list[19].min, result1[i].list[19].umumiy, ortacha2,
                                result1[i].list[19].max, result1[i].list[19].min);
                        else if (result[i].list[19].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[19].Display, result[i].list[19].umumiy, ortacha,
                                result[i].list[19].max, result[i].list[19].min, null, null, null, null);
                        else if (result1[i].list[19].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[19].Display, null, null, null, null, result1[i].list[19].umumiy,
                                ortacha2, result1[i].list[19].max, result1[i].list[19].min);
                        else
                            dataGridView1.Rows.Add(null, koms[19].Display);
                    else if (result[i].list[19].umumiy != 0 && result1[i].list[19].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[19].Display, result[i].list[19].umumiy, ortacha,
                            result[i].list[19].max, result[i].list[19].min, result1[i].list[19].umumiy, ortacha2,
                            result1[i].list[19].max, result1[i].list[19].min);
                    else if (result[i].list[19].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[19].Display, result[i].list[19].umumiy, ortacha,
                            result[i].list[19].max, result[i].list[19].min, null, null, null, null);
                    else if (result1[i].list[19].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[19].Display, null, null, null, null, result1[i].list[19].umumiy,
                                ortacha2, result1[i].list[19].max, result1[i].list[19].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[19].Display);
                    tt = true;
                }
                if (t[20])
                {
                    ortacha = result[i].list[20].ortacha / result[i].list[20].umumiy;
                    ortacha2 = result1[i].list[20].ortacha / result1[i].list[20].umumiy;
                    if (tt)
                        if (result[i].list[20].umumiy != 0 && result1[i].list[20].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[20].Display, result[i].list[20].umumiy, ortacha,
                                result[i].list[20].max, result[i].list[20].min, result1[i].list[20].umumiy, ortacha2,
                                result1[i].list[20].max, result1[i].list[20].min);
                        else if (result[i].list[20].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[20].Display, result[i].list[20].umumiy, ortacha,
                                result[i].list[20].max, result[i].list[20].min, null, null, null, null);
                        else if (result1[i].list[20].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[20].Display, null, null, null, null, result1[i].list[20].umumiy,
                                ortacha2, result1[i].list[20].max, result1[i].list[20].min);
                        else
                            dataGridView1.Rows.Add(null, koms[20].Display);
                    else if (result[i].list[20].umumiy != 0 && result1[i].list[20].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[20].Display, result[i].list[20].umumiy, ortacha,
                            result[i].list[20].max, result[i].list[20].min, result1[i].list[20].umumiy, ortacha2,
                            result1[i].list[20].max, result1[i].list[20].min);
                    else if (result[i].list[20].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[20].Display, result[i].list[20].umumiy, ortacha,
                            result[i].list[20].max, result[i].list[20].min, null, null, null, null);
                    else if (result1[i].list[20].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[20].Display, null, null, null, null, result1[i].list[20].umumiy,
                                ortacha2, result1[i].list[20].max, result1[i].list[20].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[20].Display);
                    tt = true;
                }
                if (t[21])
                {
                    ortacha = result[i].list[21].ortacha / result[i].list[21].umumiy;
                    ortacha2 = result1[i].list[21].ortacha / result1[i].list[21].umumiy;
                    if (tt)
                        if (result[i].list[21].umumiy != 0 && result1[i].list[21].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[21].Display, result[i].list[21].umumiy, ortacha,
                                result[i].list[21].max, result[i].list[21].min, result1[i].list[21].umumiy, ortacha2,
                                result1[i].list[21].max, result1[i].list[21].min);
                        else if (result[i].list[21].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[21].Display, result[i].list[21].umumiy, ortacha,
                                result[i].list[21].max, result[i].list[21].min, null, null, null, null);
                        else if (result1[i].list[21].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[21].Display, null, null, null, null, result1[i].list[21].umumiy,
                                ortacha2, result1[i].list[21].max, result1[i].list[21].min);
                        else
                            dataGridView1.Rows.Add(null, koms[21].Display);
                    else if (result[i].list[21].umumiy != 0 && result1[i].list[21].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[21].Display, result[i].list[21].umumiy, ortacha,
                            result[i].list[21].max, result[i].list[21].min, result1[i].list[21].umumiy, ortacha2,
                            result1[i].list[21].max, result1[i].list[21].min);
                    else if (result[i].list[21].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[21].Display, result[i].list[21].umumiy, ortacha,
                            result[i].list[21].max, result[i].list[21].min, null, null, null, null);
                    else if (result1[i].list[21].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[21].Display, null, null, null, null, result1[i].list[21].umumiy,
                                ortacha2, result1[i].list[21].max, result1[i].list[21].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[21].Display);
                    tt = true;
                }
                if (t[22])
                {
                    ortacha = result[i].list[22].ortacha / result[i].list[22].umumiy;
                    ortacha2 = result1[i].list[22].ortacha / result1[i].list[22].umumiy;
                    if (tt)
                        if (result[i].list[22].umumiy != 0 && result1[i].list[22].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[22].Display, result[i].list[22].umumiy, ortacha,
                                result[i].list[22].max, result[i].list[22].min, result1[i].list[22].umumiy, ortacha2,
                                result1[i].list[22].max, result1[i].list[22].min);
                        else if (result[i].list[22].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[22].Display, result[i].list[22].umumiy, ortacha,
                                result[i].list[22].max, result[i].list[22].min, null, null, null, null);
                        else if (result1[i].list[22].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[22].Display, null, null, null, null, result1[i].list[22].umumiy,
                                ortacha2, result1[i].list[22].max, result1[i].list[22].min);
                        else
                            dataGridView1.Rows.Add(null, koms[22].Display);
                    else if (result[i].list[22].umumiy != 0 && result1[i].list[22].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[22].Display, result[i].list[22].umumiy, ortacha,
                            result[i].list[22].max, result[i].list[22].min, result1[i].list[22].umumiy, ortacha2,
                            result1[i].list[22].max, result1[i].list[22].min);
                    else if (result[i].list[22].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[22].Display, result[i].list[22].umumiy, ortacha,
                            result[i].list[22].max, result[i].list[22].min, null, null, null, null);
                    else if (result1[i].list[22].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[22].Display, null, null, null, null, result1[i].list[22].umumiy,
                                ortacha2, result1[i].list[22].max, result1[i].list[22].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[22].Display);
                    tt = true;
                }
                if (t[23])
                {
                    ortacha = result[i].list[23].ortacha / result[i].list[23].umumiy;
                    ortacha2 = result1[i].list[23].ortacha / result1[i].list[23].umumiy;
                    if (tt)
                        if (result[i].list[23].umumiy != 0 && result1[i].list[23].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[23].Display, result[i].list[23].umumiy, ortacha,
                                result[i].list[23].max, result[i].list[23].min, result1[i].list[23].umumiy, ortacha2,
                                result1[i].list[23].max, result1[i].list[23].min);
                        else if (result[i].list[23].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[23].Display, result[i].list[23].umumiy, ortacha,
                                result[i].list[23].max, result[i].list[23].min, null, null, null, null);
                        else if (result1[i].list[23].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[23].Display, null, null, null, null, result1[i].list[23].umumiy,
                                ortacha2, result1[i].list[23].max, result1[i].list[23].min);
                        else
                            dataGridView1.Rows.Add(null, koms[23].Display);
                    else if (result[i].list[23].umumiy != 0 && result1[i].list[23].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[23].Display, result[i].list[23].umumiy, ortacha,
                            result[i].list[23].max, result[i].list[23].min, result1[i].list[23].umumiy, ortacha2,
                            result1[i].list[23].max, result1[i].list[23].min);
                    else if (result[i].list[23].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[23].Display, result[i].list[23].umumiy, ortacha,
                            result[i].list[23].max, result[i].list[23].min, null, null, null, null);
                    else if (result1[i].list[23].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[23].Display, null, null, null, null, result1[i].list[23].umumiy,
                                ortacha2, result1[i].list[23].max, result1[i].list[23].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[23].Display);
                    tt = true;
                }
                if (t[24])
                {
                    ortacha = result[i].list[24].ortacha / result[i].list[24].umumiy;
                    ortacha2 = result1[i].list[24].ortacha / result1[i].list[24].umumiy;
                    if (tt)
                        if (result[i].list[24].umumiy != 0 && result1[i].list[24].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[24].Display, result[i].list[24].umumiy, ortacha,
                                result[i].list[24].max, result[i].list[24].min, result1[i].list[24].umumiy, ortacha2,
                                result1[i].list[24].max, result1[i].list[24].min);
                        else if (result[i].list[24].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[24].Display, result[i].list[24].umumiy, ortacha,
                                result[i].list[24].max, result[i].list[24].min, null, null, null, null);
                        else if (result1[i].list[24].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[24].Display, null, null, null, null, result1[i].list[24].umumiy,
                                ortacha2, result1[i].list[24].max, result1[i].list[24].min);
                        else
                            dataGridView1.Rows.Add(null, koms[24].Display);
                    else if (result[i].list[24].umumiy != 0 && result1[i].list[24].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[24].Display, result[i].list[24].umumiy, ortacha,
                            result[i].list[24].max, result[i].list[24].min, result1[i].list[24].umumiy, ortacha2,
                            result1[i].list[24].max, result1[i].list[24].min);
                    else if (result[i].list[24].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[24].Display, result[i].list[24].umumiy, ortacha,
                            result[i].list[24].max, result[i].list[24].min, null, null, null, null);
                    else if (result1[i].list[24].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[24].Display, null, null, null, null, result1[i].list[24].umumiy,
                                ortacha2, result1[i].list[24].max, result1[i].list[24].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[24].Display);
                    tt = true;
                }
                if (t[25])
                {
                    ortacha = result[i].list[25].ortacha / result[i].list[25].umumiy;
                    ortacha2 = result1[i].list[25].ortacha / result1[i].list[25].umumiy;
                    if (tt)
                        if (result[i].list[25].umumiy != 0 && result1[i].list[25].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[25].Display, result[i].list[25].umumiy, ortacha,
                                result[i].list[25].max, result[i].list[25].min, result1[i].list[25].umumiy, ortacha2,
                                result1[i].list[25].max, result1[i].list[25].min);
                        else if (result[i].list[25].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[25].Display, result[i].list[25].umumiy, ortacha,
                                result[i].list[25].max, result[i].list[25].min, null, null, null, null);
                        else if (result1[i].list[25].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[25].Display, null, null, null, null, result1[i].list[25].umumiy,
                                ortacha2, result1[i].list[25].max, result1[i].list[25].min);
                        else
                            dataGridView1.Rows.Add(null, koms[25].Display);
                    else if (result[i].list[25].umumiy != 0 && result1[i].list[25].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[25].Display, result[i].list[25].umumiy, ortacha,
                            result[i].list[25].max, result[i].list[25].min, result1[i].list[25].umumiy, ortacha2,
                            result1[i].list[25].max, result1[i].list[25].min);
                    else if (result[i].list[25].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[25].Display, result[i].list[25].umumiy, ortacha,
                            result[i].list[25].max, result[i].list[25].min, null, null, null, null);
                    else if (result1[i].list[25].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[25].Display, null, null, null, null, result1[i].list[25].umumiy,
                                ortacha2, result1[i].list[25].max, result1[i].list[25].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[25].Display);
                    tt = true;
                }
                if (t[26])
                {
                    ortacha = result[i].list[26].ortacha / result[i].list[26].umumiy;
                    ortacha2 = result1[i].list[26].ortacha / result1[i].list[26].umumiy;
                    if (tt)
                        if (result[i].list[26].umumiy != 0 && result1[i].list[26].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[26].Display, result[i].list[26].umumiy, ortacha,
                                result[i].list[26].max, result[i].list[26].min, result1[i].list[26].umumiy, ortacha2,
                                result1[i].list[26].max, result1[i].list[26].min);
                        else if (result[i].list[26].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[26].Display, result[i].list[26].umumiy, ortacha,
                                result[i].list[26].max, result[i].list[26].min, null, null, null, null);
                        else if (result1[i].list[26].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[26].Display, null, null, null, null, result1[i].list[26].umumiy,
                                ortacha2, result1[i].list[26].max, result1[i].list[26].min);
                        else
                            dataGridView1.Rows.Add(null, koms[26].Display);
                    else if (result[i].list[26].umumiy != 0 && result1[i].list[26].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[26].Display, result[i].list[26].umumiy, ortacha,
                            result[i].list[26].max, result[i].list[26].min, result1[i].list[26].umumiy, ortacha2,
                            result1[i].list[26].max, result1[i].list[26].min);
                    else if (result[i].list[26].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[26].Display, result[i].list[26].umumiy, ortacha,
                            result[i].list[26].max, result[i].list[26].min, null, null, null, null);
                    else if (result1[i].list[26].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[26].Display, null, null, null, null, result1[i].list[26].umumiy,
                                ortacha2, result1[i].list[26].max, result1[i].list[26].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[26].Display);
                    tt = true;
                }
                if (t[27])
                {
                    ortacha = result[i].list[27].ortacha / result[i].list[27].umumiy;
                    ortacha2 = result1[i].list[27].ortacha / result1[i].list[27].umumiy;
                    if (tt)
                        if (result[i].list[27].umumiy != 0 && result1[i].list[27].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[27].Display, result[i].list[27].umumiy, ortacha,
                                result[i].list[27].max, result[i].list[27].min, result1[i].list[27].umumiy, ortacha2,
                                result1[i].list[27].max, result1[i].list[27].min);
                        else if (result[i].list[27].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[27].Display, result[i].list[27].umumiy, ortacha,
                                result[i].list[27].max, result[i].list[27].min, null, null, null, null);
                        else if (result1[i].list[27].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[27].Display, null, null, null, null, result1[i].list[27].umumiy,
                                ortacha2, result1[i].list[27].max, result1[i].list[27].min);
                        else
                            dataGridView1.Rows.Add(null, koms[27].Display);
                    else if (result[i].list[27].umumiy != 0 && result1[i].list[27].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[27].Display, result[i].list[27].umumiy, ortacha,
                            result[i].list[27].max, result[i].list[27].min, result1[i].list[27].umumiy, ortacha2,
                            result1[i].list[27].max, result1[i].list[27].min);
                    else if (result[i].list[27].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[27].Display, result[i].list[27].umumiy, ortacha,
                            result[i].list[27].max, result[i].list[27].min, null, null, null, null);
                    else if (result1[i].list[27].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[27].Display, null, null, null, null, result1[i].list[27].umumiy,
                                ortacha2, result1[i].list[27].max, result1[i].list[27].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[27].Display);
                    tt = true;
                }
                if (t[28])
                {
                    ortacha = result[i].list[28].ortacha / result[i].list[28].umumiy;
                    ortacha2 = result1[i].list[28].ortacha / result1[i].list[28].umumiy;
                    if (tt)
                        if (result[i].list[28].umumiy != 0 && result1[i].list[28].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[28].Display, result[i].list[28].umumiy, ortacha,
                                result[i].list[28].max, result[i].list[28].min, result1[i].list[28].umumiy, ortacha2,
                                result1[i].list[28].max, result1[i].list[28].min);
                        else if (result[i].list[28].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[28].Display, result[i].list[28].umumiy, ortacha,
                                result[i].list[28].max, result[i].list[28].min, null, null, null, null);
                        else if (result1[i].list[28].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[28].Display, null, null, null, null, result1[i].list[28].umumiy,
                                ortacha2, result1[i].list[28].max, result1[i].list[28].min);
                        else
                            dataGridView1.Rows.Add(null, koms[28].Display);
                    else if (result[i].list[28].umumiy != 0 && result1[i].list[28].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[28].Display, result[i].list[28].umumiy, ortacha,
                            result[i].list[28].max, result[i].list[28].min, result1[i].list[28].umumiy, ortacha2,
                            result1[i].list[28].max, result1[i].list[28].min);
                    else if (result[i].list[28].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[28].Display, result[i].list[28].umumiy, ortacha,
                            result[i].list[28].max, result[i].list[28].min, null, null, null, null);
                    else if (result1[i].list[28].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[28].Display, null, null, null, null, result1[i].list[28].umumiy,
                                ortacha2, result1[i].list[28].max, result1[i].list[28].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[28].Display);
                    tt = true;
                }
                if (t[29])
                {
                    ortacha = result[i].list[29].ortacha / result[i].list[29].umumiy;
                    ortacha2 = result1[i].list[29].ortacha / result1[i].list[29].umumiy;
                    if (tt)
                        if (result[i].list[29].umumiy != 0 && result1[i].list[29].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[29].Display, result[i].list[29].umumiy, ortacha,
                                result[i].list[29].max, result[i].list[29].min, result1[i].list[29].umumiy, ortacha2,
                                result1[i].list[29].max, result1[i].list[29].min);
                        else if (result[i].list[29].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[29].Display, result[i].list[29].umumiy, ortacha,
                                result[i].list[29].max, result[i].list[29].min, null, null, null, null);
                        else if (result1[i].list[29].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[29].Display, null, null, null, null, result1[i].list[29].umumiy,
                                ortacha2, result1[i].list[29].max, result1[i].list[29].min);
                        else
                            dataGridView1.Rows.Add(null, koms[29].Display);
                    else if (result[i].list[29].umumiy != 0 && result1[i].list[29].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[29].Display, result[i].list[29].umumiy, ortacha,
                            result[i].list[29].max, result[i].list[29].min, result1[i].list[29].umumiy, ortacha2,
                            result1[i].list[29].max, result1[i].list[29].min);
                    else if (result[i].list[29].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[29].Display, result[i].list[29].umumiy, ortacha,
                            result[i].list[29].max, result[i].list[29].min, null, null, null, null);
                    else if (result1[i].list[29].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[29].Display, null, null, null, null, result1[i].list[29].umumiy,
                                ortacha2, result1[i].list[29].max, result1[i].list[29].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[29].Display);
                    tt = true;
                }
                if (t[30])
                {
                    ortacha = result[i].list[30].ortacha / result[i].list[30].umumiy;
                    ortacha2 = result1[i].list[30].ortacha / result1[i].list[30].umumiy;
                    if (tt)
                        if (result[i].list[30].umumiy != 0 && result1[i].list[30].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[30].Display, result[i].list[30].umumiy, ortacha,
                                result[i].list[30].max, result[i].list[30].min, result1[i].list[30].umumiy, ortacha2,
                                result1[i].list[30].max, result1[i].list[30].min);
                        else if (result[i].list[30].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[30].Display, result[i].list[30].umumiy, ortacha,
                                result[i].list[30].max, result[i].list[30].min, null, null, null, null);
                        else if (result1[i].list[30].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[30].Display, null, null, null, null, result1[i].list[30].umumiy,
                                ortacha2, result1[i].list[30].max, result1[i].list[30].min);
                        else
                            dataGridView1.Rows.Add(null, koms[30].Display);
                    else if (result[i].list[30].umumiy != 0 && result1[i].list[30].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[30].Display, result[i].list[30].umumiy, ortacha,
                            result[i].list[30].max, result[i].list[30].min, result1[i].list[30].umumiy, ortacha2,
                            result1[i].list[30].max, result1[i].list[30].min);
                    else if (result[i].list[30].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[30].Display, result[i].list[30].umumiy, ortacha,
                            result[i].list[30].max, result[i].list[30].min, null, null, null, null);
                    else if (result1[i].list[30].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[30].Display, null, null, null, null, result1[i].list[30].umumiy,
                                ortacha2, result1[i].list[30].max, result1[i].list[30].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[30].Display);
                    tt = true;
                }
                if (t[31])
                {
                    ortacha = result[i].list[31].ortacha / result[i].list[31].umumiy;
                    ortacha2 = result1[i].list[31].ortacha / result1[i].list[31].umumiy;
                    if (tt)
                        if (result[i].list[31].umumiy != 0 && result1[i].list[31].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[31].Display, result[i].list[31].umumiy, ortacha,
                                result[i].list[31].max, result[i].list[31].min, result1[i].list[31].umumiy, ortacha2,
                                result1[i].list[31].max, result1[i].list[31].min);
                        else if (result[i].list[31].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[31].Display, result[i].list[31].umumiy, ortacha,
                                result[i].list[31].max, result[i].list[31].min, null, null, null, null);
                        else if (result1[i].list[31].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[31].Display, null, null, null, null, result1[i].list[31].umumiy,
                                ortacha2, result1[i].list[31].max, result1[i].list[31].min);
                        else
                            dataGridView1.Rows.Add(null, koms[31].Display);
                    else if (result[i].list[31].umumiy != 0 && result1[i].list[31].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[31].Display, result[i].list[31].umumiy, ortacha,
                            result[i].list[31].max, result[i].list[31].min, result1[i].list[31].umumiy, ortacha2,
                            result1[i].list[31].max, result1[i].list[31].min);
                    else if (result[i].list[31].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[31].Display, result[i].list[31].umumiy, ortacha,
                            result[i].list[31].max, result[i].list[31].min, null, null, null, null);
                    else if (result1[i].list[31].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[31].Display, null, null, null, null, result1[i].list[31].umumiy,
                                ortacha2, result1[i].list[31].max, result1[i].list[31].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[31].Display);
                    tt = true;
                }
                if (t[32])
                {
                    ortacha = result[i].list[32].ortacha / result[i].list[32].umumiy;
                    ortacha2 = result1[i].list[32].ortacha / result1[i].list[32].umumiy;
                    if (tt)
                        if (result[i].list[32].umumiy != 0 && result1[i].list[32].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[32].Display, result[i].list[32].umumiy, ortacha,
                                result[i].list[32].max, result[i].list[32].min, result1[i].list[32].umumiy, ortacha2,
                                result1[i].list[32].max, result1[i].list[32].min);
                        else if (result[i].list[32].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[32].Display, result[i].list[32].umumiy, ortacha,
                                result[i].list[32].max, result[i].list[32].min, null, null, null, null);
                        else if (result1[i].list[32].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[32].Display, null, null, null, null, result1[i].list[32].umumiy,
                                ortacha2, result1[i].list[32].max, result1[i].list[32].min);
                        else
                            dataGridView1.Rows.Add(null, koms[32].Display);
                    else if (result[i].list[32].umumiy != 0 && result1[i].list[32].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[32].Display, result[i].list[32].umumiy, ortacha,
                            result[i].list[32].max, result[i].list[32].min, result1[i].list[32].umumiy, ortacha2,
                            result1[i].list[32].max, result1[i].list[32].min);
                    else if (result[i].list[32].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[32].Display, result[i].list[32].umumiy, ortacha,
                            result[i].list[32].max, result[i].list[32].min, null, null, null, null);
                    else if (result1[i].list[32].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[32].Display, null, null, null, null, result1[i].list[32].umumiy,
                                ortacha2, result1[i].list[32].max, result1[i].list[32].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[32].Display);
                    tt = true;
                }
                if (t[33])
                {
                    ortacha = result[i].list[33].ortacha / result[i].list[33].umumiy;
                    ortacha2 = result1[i].list[33].ortacha / result1[i].list[33].umumiy;
                    if (tt)
                        if (result[i].list[33].umumiy != 0 && result1[i].list[33].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[33].Display, result[i].list[33].umumiy, ortacha,
                                result[i].list[33].max, result[i].list[33].min, result1[i].list[33].umumiy, ortacha2,
                                result1[i].list[33].max, result1[i].list[33].min);
                        else if (result[i].list[33].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[33].Display, result[i].list[33].umumiy, ortacha,
                                result[i].list[33].max, result[i].list[33].min, null, null, null, null);
                        else if (result1[i].list[33].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[33].Display, null, null, null, null, result1[i].list[33].umumiy,
                                ortacha2, result1[i].list[33].max, result1[i].list[33].min);
                        else
                            dataGridView1.Rows.Add(null, koms[33].Display);
                    else if (result[i].list[33].umumiy != 0 && result1[i].list[33].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[33].Display, result[i].list[33].umumiy, ortacha,
                            result[i].list[33].max, result[i].list[33].min, result1[i].list[33].umumiy, ortacha2,
                            result1[i].list[33].max, result1[i].list[33].min);
                    else if (result[i].list[33].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[33].Display, result[i].list[33].umumiy, ortacha,
                            result[i].list[33].max, result[i].list[33].min, null, null, null, null);
                    else if (result1[i].list[33].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[33].Display, null, null, null, null, result1[i].list[33].umumiy,
                                ortacha2, result1[i].list[33].max, result1[i].list[33].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[33].Display);
                    tt = true;
                }
                if (t[34])
                {
                    ortacha = result[i].list[34].ortacha / result[i].list[34].umumiy;
                    ortacha2 = result1[i].list[34].ortacha / result1[i].list[34].umumiy;
                    if (tt)
                        if (result[i].list[34].umumiy != 0 && result1[i].list[34].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[34].Display, result[i].list[34].umumiy, ortacha,
                                result[i].list[34].max, result[i].list[34].min, result1[i].list[34].umumiy, ortacha2,
                                result1[i].list[34].max, result1[i].list[34].min);
                        else if (result[i].list[34].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[34].Display, result[i].list[34].umumiy, ortacha,
                                result[i].list[34].max, result[i].list[34].min, null, null, null, null);
                        else if (result1[i].list[34].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[34].Display, null, null, null, null, result1[i].list[34].umumiy,
                                ortacha2, result1[i].list[34].max, result1[i].list[34].min);
                        else
                            dataGridView1.Rows.Add(null, koms[34].Display);
                    else if (result[i].list[34].umumiy != 0 && result1[i].list[34].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[34].Display, result[i].list[34].umumiy, ortacha,
                            result[i].list[34].max, result[i].list[34].min, result1[i].list[34].umumiy, ortacha2,
                            result1[i].list[34].max, result1[i].list[34].min);
                    else if (result[i].list[34].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[34].Display, result[i].list[34].umumiy, ortacha,
                            result[i].list[34].max, result[i].list[34].min, null, null, null, null);
                    else if (result1[i].list[34].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[34].Display, null, null, null, null, result1[i].list[34].umumiy,
                                ortacha2, result1[i].list[34].max, result1[i].list[34].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[34].Display);
                    tt = true;
                }
                if (t[35])
                {
                    ortacha = result[i].list[35].ortacha / result[i].list[35].umumiy;
                    ortacha2 = result1[i].list[35].ortacha / result1[i].list[35].umumiy;
                    if (tt)
                        if (result[i].list[35].umumiy != 0 && result1[i].list[35].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[35].Display, result[i].list[35].umumiy, ortacha,
                                result[i].list[35].max, result[i].list[35].min, result1[i].list[35].umumiy, ortacha2,
                                result1[i].list[35].max, result1[i].list[35].min);
                        else if (result[i].list[35].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[35].Display, result[i].list[35].umumiy, ortacha,
                                result[i].list[35].max, result[i].list[35].min, null, null, null, null);
                        else if (result1[i].list[35].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[35].Display, null, null, null, null, result1[i].list[35].umumiy,
                                ortacha2, result1[i].list[35].max, result1[i].list[35].min);
                        else
                            dataGridView1.Rows.Add(null, koms[35].Display);
                    else if (result[i].list[35].umumiy != 0 && result1[i].list[35].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[35].Display, result[i].list[35].umumiy, ortacha,
                            result[i].list[35].max, result[i].list[35].min, result1[i].list[35].umumiy, ortacha2,
                            result1[i].list[35].max, result1[i].list[35].min);
                    else if (result[i].list[35].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[35].Display, result[i].list[35].umumiy, ortacha,
                            result[i].list[35].max, result[i].list[35].min, null, null, null, null);
                    else if (result1[i].list[35].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[35].Display, null, null, null, null, result1[i].list[35].umumiy,
                                ortacha2, result1[i].list[35].max, result1[i].list[35].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[35].Display);
                    tt = true;
                }
                if (t[36])
                {
                    ortacha = result[i].list[36].ortacha / result[i].list[36].umumiy;
                    ortacha2 = result1[i].list[36].ortacha / result1[i].list[36].umumiy;
                    if (tt)
                        if (result[i].list[36].umumiy != 0 && result1[i].list[36].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[36].Display, result[i].list[36].umumiy, ortacha,
                                result[i].list[36].max, result[i].list[36].min, result1[i].list[36].umumiy, ortacha2,
                                result1[i].list[36].max, result1[i].list[36].min);
                        else if (result[i].list[36].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[36].Display, result[i].list[36].umumiy, ortacha,
                                result[i].list[36].max, result[i].list[36].min, null, null, null, null);
                        else if (result1[i].list[36].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[36].Display, null, null, null, null, result1[i].list[36].umumiy,
                                ortacha2, result1[i].list[36].max, result1[i].list[36].min);
                        else
                            dataGridView1.Rows.Add(null, koms[36].Display);
                    else if (result[i].list[36].umumiy != 0 && result1[i].list[36].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[36].Display, result[i].list[36].umumiy, ortacha,
                            result[i].list[36].max, result[i].list[36].min, result1[i].list[36].umumiy, ortacha2,
                            result1[i].list[36].max, result1[i].list[36].min);
                    else if (result[i].list[36].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[36].Display, result[i].list[36].umumiy, ortacha,
                            result[i].list[36].max, result[i].list[36].min, null, null, null, null);
                    else if (result1[i].list[36].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[36].Display, null, null, null, null, result1[i].list[36].umumiy,
                                ortacha2, result1[i].list[36].max, result1[i].list[36].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[36].Display);
                    tt = true;
                }
                if (t[37])
                {
                    ortacha = result[i].list[37].ortacha / result[i].list[37].umumiy;
                    ortacha2 = result1[i].list[37].ortacha / result1[i].list[37].umumiy;
                    if (tt)
                        if (result[i].list[37].umumiy != 0 && result1[i].list[37].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[37].Display, result[i].list[37].umumiy, ortacha,
                                result[i].list[37].max, result[i].list[37].min, result1[i].list[37].umumiy, ortacha2,
                                result1[i].list[37].max, result1[i].list[37].min);
                        else if (result[i].list[37].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[37].Display, result[i].list[37].umumiy, ortacha,
                                result[i].list[37].max, result[i].list[37].min, null, null, null, null);
                        else if (result1[i].list[37].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[37].Display, null, null, null, null, result1[i].list[37].umumiy,
                                ortacha2, result1[i].list[37].max, result1[i].list[37].min);
                        else
                            dataGridView1.Rows.Add(null, koms[37].Display);
                    else if (result[i].list[37].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[37].Display, result[i].list[37].umumiy, ortacha,
                            result[i].list[37].max, result[i].list[37].min, result1[i].list[37].umumiy, ortacha2,
                            result1[i].list[37].max, result1[i].list[37].min);
                    else if (result[i].list[37].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[37].Display, result[i].list[37].umumiy, ortacha,
                            result[i].list[37].max, result[i].list[37].min, null, null, null, null);
                    else if (result1[i].list[37].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[37].Display, null, null, null, null, result1[i].list[37].umumiy,
                                ortacha2, result1[i].list[37].max, result1[i].list[37].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[37].Display);
                    tt = true;
                }
                if (t[38])
                {
                    ortacha = result[i].list[38].ortacha / result[i].list[38].umumiy;
                    ortacha2 = result1[i].list[38].ortacha / result1[i].list[38].umumiy;
                    if (tt)
                        if (result[i].list[38].umumiy != 0 && result1[i].list[38].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[38].Display, result[i].list[38].umumiy, ortacha,
                                result[i].list[38].max, result[i].list[38].min, result1[i].list[38].umumiy, ortacha2,
                                result1[i].list[38].max, result1[i].list[38].min);
                        else if (result[i].list[38].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[38].Display, result[i].list[38].umumiy, ortacha,
                                result[i].list[38].max, result[i].list[38].min, null, null, null, null);
                        else if (result1[i].list[38].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[38].Display, null, null, null, null, result1[i].list[38].umumiy,
                                ortacha2, result1[i].list[38].max, result1[i].list[38].min);
                        else
                            dataGridView1.Rows.Add(null, koms[38].Display);
                    else if (result[i].list[38].umumiy != 0 && result1[i].list[38].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[38].Display, result[i].list[38].umumiy, ortacha,
                            result[i].list[38].max, result[i].list[38].min, result1[i].list[38].umumiy, ortacha2,
                            result1[i].list[38].max, result1[i].list[38].min);
                    else if (result[i].list[38].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[38].Display, result[i].list[38].umumiy, ortacha,
                            result[i].list[38].max, result[i].list[38].min, null, null, null, null);
                    else if (result1[i].list[38].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[38].Display, null, null, null, null, result1[i].list[38].umumiy,
                                ortacha2, result1[i].list[38].max, result1[i].list[38].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[38].Display);
                    tt = true;
                }
                if (t[39])
                {
                    ortacha = result[i].list[39].ortacha / result[i].list[39].umumiy;
                    ortacha2 = result1[i].list[39].ortacha / result1[i].list[39].umumiy;
                    if (tt)
                        if (result[i].list[39].umumiy != 0 && result1[i].list[39].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[39].Display, result[i].list[39].umumiy, ortacha,
                                result[i].list[39].max, result[i].list[39].min, result1[i].list[39].umumiy, ortacha2,
                                result1[i].list[39].max, result1[i].list[39].min);
                        else if (result[i].list[39].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[39].Display, result[i].list[39].umumiy, ortacha,
                                result[i].list[39].max, result[i].list[39].min, null, null, null, null);
                        else if (result1[i].list[39].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[39].Display, null, null, null, null, result1[i].list[39].umumiy,
                                ortacha2, result1[i].list[39].max, result1[i].list[39].min);
                        else
                            dataGridView1.Rows.Add(null, koms[39].Display);
                    else if (result[i].list[39].umumiy != 0 && result1[i].list[39].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[39].Display, result[i].list[39].umumiy, ortacha,
                            result[i].list[39].max, result[i].list[39].min, result1[i].list[39].umumiy, ortacha2,
                            result1[i].list[39].max, result1[i].list[39].min);
                    else if (result[i].list[39].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[39].Display, result[i].list[39].umumiy, ortacha,
                            result[i].list[39].max, result[i].list[39].min, null, null, null, null);
                    else if (result1[i].list[39].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[39].Display, null, null, null, null, result1[i].list[39].umumiy,
                                ortacha2, result1[i].list[39].max, result1[i].list[39].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[39].Display);
                    tt = true;
                }
                if (t[40])
                {
                    ortacha = result[i].list[40].ortacha / result[i].list[40].umumiy;
                    ortacha2 = result1[i].list[40].ortacha / result1[i].list[40].umumiy;
                    if (tt)
                        if (result[i].list[40].umumiy != 0 && result1[i].list[40].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[40].Display, result[i].list[40].umumiy, ortacha,
                                result[i].list[40].max, result[i].list[40].min, result1[i].list[40].umumiy, ortacha2,
                                result1[i].list[40].max, result1[i].list[40].min);
                        else if (result[i].list[40].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[40].Display, result[i].list[40].umumiy, ortacha,
                                result[i].list[40].max, result[i].list[40].min, null, null, null, null);
                        else if (result1[i].list[40].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[40].Display, null, null, null, null, result1[i].list[40].umumiy,
                                ortacha2, result1[i].list[40].max, result1[i].list[40].min);
                        else
                            dataGridView1.Rows.Add(null, koms[40].Display);
                    else if (result[i].list[40].umumiy != 0 && result1[i].list[40].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[40].Display, result[i].list[40].umumiy, ortacha,
                            result[i].list[40].max, result[i].list[40].min, result1[i].list[40].umumiy, ortacha2,
                            result1[i].list[40].max, result1[i].list[40].min);
                    else if (result[i].list[40].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[40].Display, result[i].list[40].umumiy, ortacha,
                            result[i].list[40].max, result[i].list[40].min, null, null, null, null);
                    else if (result1[i].list[40].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[40].Display, null, null, null, null, result1[i].list[40].umumiy,
                                ortacha2, result1[i].list[40].max, result1[i].list[40].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[40].Display);
                    tt = true;
                }
                if (t[41])
                {
                    ortacha = result[i].list[41].ortacha / result[i].list[41].umumiy;
                    ortacha2 = result1[i].list[41].ortacha / result1[i].list[41].umumiy;
                    if (tt)
                        if (result[i].list[41].umumiy != 0 && result1[i].list[41].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[41].Display, result[i].list[41].umumiy, ortacha,
                                result[i].list[41].max, result[i].list[41].min, result1[i].list[41].umumiy, ortacha2,
                                result1[i].list[41].max, result1[i].list[41].min);
                        else if (result[i].list[41].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[41].Display, result[i].list[41].umumiy, ortacha,
                                result[i].list[41].max, result[i].list[41].min, null, null, null, null);
                        else if (result1[i].list[41].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[41].Display, null, null, null, null, result1[i].list[41].umumiy,
                                ortacha2, result1[i].list[41].max, result1[i].list[41].min);
                        else
                            dataGridView1.Rows.Add(null, koms[41].Display);
                    else if (result[i].list[41].umumiy != 0 && result1[i].list[41].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[41].Display, result[i].list[41].umumiy, ortacha,
                            result[i].list[41].max, result[i].list[41].min, result1[i].list[41].umumiy, ortacha2,
                            result1[i].list[41].max, result1[i].list[41].min);
                    else if (result[i].list[41].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[41].Display, result[i].list[41].umumiy, ortacha,
                            result[i].list[41].max, result[i].list[41].min, null, null, null, null);
                    else if (result1[i].list[41].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[41].Display, null, null, null, null, result1[i].list[41].umumiy,
                                ortacha2, result1[i].list[41].max, result1[i].list[41].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[41].Display);
                    tt = true;
                }
                if (t[42])
                {
                    ortacha = result[i].list[42].ortacha / result[i].list[42].umumiy;
                    ortacha2 = result1[i].list[42].ortacha / result1[i].list[42].umumiy;
                    if (tt)
                        if (result[i].list[42].umumiy != 0 && result1[i].list[42].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[42].Display, result[i].list[42].umumiy, ortacha,
                                result[i].list[42].max, result[i].list[42].min, result1[i].list[42].umumiy, ortacha2,
                                result1[i].list[42].max, result1[i].list[42].min);
                        else if (result[i].list[42].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[42].Display, result[i].list[42].umumiy, ortacha,
                                result[i].list[42].max, result[i].list[42].min, null, null, null, null);
                        else if (result1[i].list[42].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[42].Display, null, null, null, null, result1[i].list[42].umumiy,
                                ortacha2, result1[i].list[42].max, result1[i].list[42].min);
                        else
                            dataGridView1.Rows.Add(null, koms[42].Display);
                    else if (result[i].list[42].umumiy != 0 && result1[i].list[42].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[42].Display, result[i].list[42].umumiy, ortacha,
                            result[i].list[42].max, result[i].list[42].min, result1[i].list[42].umumiy, ortacha2,
                            result1[i].list[42].max, result1[i].list[42].min);
                    else if (result[i].list[42].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[42].Display, result[i].list[42].umumiy, ortacha,
                            result[i].list[42].max, result[i].list[42].min, null, null, null, null);
                    else if (result1[i].list[42].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[42].Display, null, null, null, null, result1[i].list[42].umumiy,
                                ortacha2, result1[i].list[42].max, result1[i].list[42].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[42].Display);
                    tt = true;
                }
                if (t[43])
                {
                    ortacha = result[i].list[43].ortacha / result[i].list[43].umumiy;
                    ortacha2 = result1[i].list[43].ortacha / result1[i].list[43].umumiy;
                    if (tt)
                        if (result[i].list[43].umumiy != 0 && result1[i].list[43].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[43].Display, result[i].list[43].umumiy, ortacha,
                                result[i].list[43].max, result[i].list[43].min, result1[i].list[43].umumiy, ortacha2,
                                result1[i].list[43].max, result1[i].list[43].min);
                        else if (result[i].list[43].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[43].Display, result[i].list[43].umumiy, ortacha,
                                result[i].list[43].max, result[i].list[43].min, null, null, null, null);
                        else if (result1[i].list[43].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[43].Display, null, null, null, null, result1[i].list[43].umumiy,
                                ortacha2, result1[i].list[43].max, result1[i].list[43].min);
                        else
                            dataGridView1.Rows.Add(null, koms[43].Display);
                    else if (result[i].list[43].umumiy != 0 && result1[i].list[43].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[43].Display, result[i].list[43].umumiy, ortacha,
                            result[i].list[43].max, result[i].list[43].min, result1[i].list[43].umumiy, ortacha2,
                            result1[i].list[43].max, result1[i].list[43].min);
                    else if (result[i].list[43].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[43].Display, result[i].list[43].umumiy, ortacha,
                            result[i].list[43].max, result[i].list[43].min, null, null, null, null);
                    else if (result1[i].list[43].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[43].Display, null, null, null, null, result1[i].list[43].umumiy,
                                ortacha2, result1[i].list[43].max, result1[i].list[43].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[43].Display);
                    tt = true;
                }
                if (t[44])
                {
                    ortacha = result[i].list[44].ortacha / result[i].list[44].umumiy;
                    ortacha2 = result1[i].list[44].ortacha / result1[i].list[44].umumiy;
                    if (tt)
                        if (result[i].list[44].umumiy != 0 && result1[i].list[44].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[44].Display, result[i].list[44].umumiy, ortacha,
                                result[i].list[44].max, result[i].list[44].min, result1[i].list[44].umumiy, ortacha2,
                                result1[i].list[44].max, result1[i].list[44].min);
                        else if (result[i].list[44].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[44].Display, result[i].list[44].umumiy, ortacha,
                                result[i].list[44].max, result[i].list[44].min, null, null, null, null);
                        else if (result1[i].list[44].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[44].Display, null, null, null, null, result1[i].list[44].umumiy,
                                ortacha2, result1[i].list[44].max, result1[i].list[44].min);
                        else
                            dataGridView1.Rows.Add(null, koms[44].Display);
                    else if (result[i].list[44].umumiy != 0 && result1[i].list[44].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[44].Display, result[i].list[44].umumiy, ortacha,
                            result[i].list[44].max, result[i].list[44].min, result1[i].list[44].umumiy, ortacha2,
                            result1[i].list[44].max, result1[i].list[44].min);
                    else if (result[i].list[44].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[44].Display, result[i].list[44].umumiy, ortacha,
                            result[i].list[44].max, result[i].list[44].min, null, null, null, null);
                    else if (result1[i].list[44].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[44].Display, null, null, null, null, result1[i].list[44].umumiy,
                                ortacha2, result1[i].list[44].max, result1[i].list[44].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[44].Display);
                    tt = true;
                }
                if (t[45])
                {
                    ortacha = result[i].list[45].ortacha / result[i].list[45].umumiy;
                    ortacha2 = result1[i].list[45].ortacha / result1[i].list[45].umumiy;
                    if (tt)
                        if (result[i].list[45].umumiy != 0 && result1[i].list[45].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[45].Display, result[i].list[45].umumiy, ortacha,
                                result[i].list[45].max, result[i].list[45].min, result1[i].list[45].umumiy, ortacha2,
                                result1[i].list[45].max, result1[i].list[45].min);
                        else if (result[i].list[45].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[45].Display, result[i].list[45].umumiy, ortacha,
                                result[i].list[45].max, result[i].list[45].min, null, null, null, null);
                        else if (result1[i].list[45].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[45].Display, null, null, null, null, result1[i].list[45].umumiy,
                                ortacha2, result1[i].list[45].max, result1[i].list[45].min);
                        else
                            dataGridView1.Rows.Add(null, koms[45].Display);
                    else if (result[i].list[45].umumiy != 0 && result1[i].list[45].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[45].Display, result[i].list[45].umumiy, ortacha,
                            result[i].list[45].max, result[i].list[45].min, result1[i].list[45].umumiy, ortacha2,
                            result1[i].list[45].max, result1[i].list[45].min);
                    else if (result[i].list[45].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[45].Display, result[i].list[45].umumiy, ortacha,
                            result[i].list[45].max, result[i].list[45].min, null, null, null, null);
                    else if (result1[i].list[45].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[45].Display, null, null, null, null, result1[i].list[45].umumiy,
                                ortacha2, result1[i].list[45].max, result1[i].list[45].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[45].Display);
                    tt = true;
                }
                if (t[46])
                {
                    ortacha = result[i].list[46].ortacha / result[i].list[46].umumiy;
                    ortacha2 = result1[i].list[46].ortacha / result1[i].list[46].umumiy;
                    if (tt)
                        if (result[i].list[46].umumiy != 0 && result1[i].list[46].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[46].Display, result[i].list[46].umumiy, ortacha,
                                result[i].list[46].max, result[i].list[46].min, result1[i].list[46].umumiy, ortacha2,
                                result1[i].list[46].max, result1[i].list[46].min);
                        else if (result[i].list[46].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[46].Display, result[i].list[46].umumiy, ortacha,
                                result[i].list[46].max, result[i].list[46].min, null, null, null, null);
                        else if (result1[i].list[46].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[46].Display, null, null, null, null, result1[i].list[46].umumiy,
                                ortacha2, result1[i].list[46].max, result1[i].list[46].min);
                        else
                            dataGridView1.Rows.Add(null, koms[46].Display);
                    else if (result[i].list[46].umumiy != 0 && result1[i].list[46].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[46].Display, result[i].list[46].umumiy, ortacha,
                            result[i].list[46].max, result[i].list[46].min, result1[i].list[46].umumiy, ortacha2,
                            result1[i].list[46].max, result1[i].list[46].min);
                    else if (result[i].list[46].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[46].Display, result[i].list[46].umumiy, ortacha,
                            result[i].list[46].max, result[i].list[46].min, null, null, null, null);
                    else if (result1[i].list[46].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[46].Display, null, null, null, null, result1[i].list[46].umumiy,
                                ortacha2, result1[i].list[46].max, result1[i].list[46].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[46].Display);
                    tt = true;
                }
                if (t[47])
                {
                    ortacha = result[i].list[47].ortacha / result[i].list[47].umumiy;
                    ortacha2 = result1[i].list[47].ortacha / result1[i].list[47].umumiy;
                    if (tt)
                        if (result[i].list[47].umumiy != 0 && result1[i].list[47].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[47].Display, result[i].list[47].umumiy, ortacha,
                                result[i].list[47].max, result[i].list[47].min, result1[i].list[47].umumiy, ortacha2,
                                result1[i].list[47].max, result1[i].list[47].min);
                        else if (result[i].list[47].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[47].Display, result[i].list[47].umumiy, ortacha,
                                result[i].list[47].max, result[i].list[47].min, null, null, null, null);
                        else if (result1[i].list[47].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[47].Display, null, null, null, null, result1[i].list[47].umumiy,
                                ortacha2, result1[i].list[47].max, result1[i].list[47].min);
                        else
                            dataGridView1.Rows.Add(null, koms[47].Display);
                    else if (result[i].list[47].umumiy != 0 && result1[i].list[47].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[47].Display, result[i].list[47].umumiy, ortacha,
                            result[i].list[47].max, result[i].list[47].min, result1[i].list[47].umumiy, ortacha2,
                            result1[i].list[47].max, result1[i].list[47].min);
                    else if (result[i].list[47].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[47].Display, result[i].list[47].umumiy, ortacha,
                            result[i].list[47].max, result[i].list[47].min, null, null, null, null);
                    else if (result1[i].list[47].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[47].Display, null, null, null, null, result1[i].list[47].umumiy,
                                ortacha2, result1[i].list[47].max, result1[i].list[47].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[47].Display);
                    tt = true;
                }
                if (t[48])
                {
                    ortacha = result[i].list[48].ortacha / result[i].list[48].umumiy;
                    ortacha2 = result1[i].list[48].ortacha / result1[i].list[48].umumiy;
                    if (tt)
                        if (result[i].list[48].umumiy != 0 && result1[i].list[48].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[48].Display, result[i].list[48].umumiy, ortacha,
                                result[i].list[48].max, result[i].list[48].min, result1[i].list[48].umumiy, ortacha2,
                                result1[i].list[48].max, result1[i].list[48].min);
                        else if (result[i].list[48].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[48].Display, result[i].list[48].umumiy, ortacha,
                                result[i].list[48].max, result[i].list[48].min, null, null, null, null);
                        else if (result1[i].list[48].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[48].Display, null, null, null, null, result1[i].list[48].umumiy,
                                ortacha2, result1[i].list[48].max, result1[i].list[48].min);
                        else
                            dataGridView1.Rows.Add(null, koms[48].Display);
                    else if (result[i].list[48].umumiy != 0 && result1[i].list[48].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[48].Display, result[i].list[48].umumiy, ortacha,
                            result[i].list[48].max, result[i].list[48].min, result1[i].list[48].umumiy, ortacha2,
                            result1[i].list[48].max, result1[i].list[48].min);
                    else if (result[i].list[48].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[48].Display, result[i].list[48].umumiy, ortacha,
                            result[i].list[48].max, result[i].list[48].min, null, null, null, null);
                    else if (result1[i].list[48].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[48].Display, null, null, null, null, result1[i].list[48].umumiy,
                                ortacha2, result1[i].list[48].max, result1[i].list[48].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[48].Display);
                    tt = true;
                }
                if (t[49])
                {
                    ortacha = result[i].list[49].ortacha / result[i].list[49].umumiy;
                    ortacha2 = result1[i].list[49].ortacha / result1[i].list[49].umumiy;
                    if (tt)
                        if (result[i].list[49].umumiy != 0 && result1[i].list[49].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[49].Display, result[i].list[49].umumiy, ortacha,
                                result[i].list[49].max, result[i].list[49].min, result1[i].list[49].umumiy, ortacha2,
                                result1[i].list[49].max, result1[i].list[49].min);
                        else if (result[i].list[49].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[49].Display, result[i].list[49].umumiy, ortacha,
                                result[i].list[49].max, result[i].list[49].min, null, null, null, null);
                        else if (result1[i].list[49].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[49].Display, null, null, null, null, result1[i].list[49].umumiy,
                                ortacha2, result1[i].list[49].max, result1[i].list[49].min);
                        else
                            dataGridView1.Rows.Add(null, koms[49].Display);
                    else if (result[i].list[49].umumiy != 0 && result1[i].list[49].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[49].Display, result[i].list[49].umumiy, ortacha,
                            result[i].list[49].max, result[i].list[49].min, result1[i].list[49].umumiy, ortacha2,
                            result1[i].list[49].max, result1[i].list[49].min);
                    else if (result[i].list[49].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[49].Display, result[i].list[49].umumiy, ortacha,
                            result[i].list[49].max, result[i].list[49].min, null, null, null, null);
                    else if (result1[i].list[49].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[49].Display, null, null, null, null, result1[i].list[49].umumiy,
                                ortacha2, result1[i].list[49].max, result1[i].list[49].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[49].Display);
                    tt = true;
                }
                if (t[50])
                {
                    ortacha = result[i].list[50].ortacha / result[i].list[50].umumiy;
                    ortacha2 = result1[i].list[50].ortacha / result1[i].list[50].umumiy;
                    if (tt)
                        if (result[i].list[50].umumiy != 0 && result1[i].list[50].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[50].Display, result[i].list[50].umumiy, ortacha,
                                result[i].list[50].max, result[i].list[50].min, result1[i].list[50].umumiy, ortacha2,
                                result1[i].list[50].max, result1[i].list[50].min);
                        else if (result[i].list[50].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[50].Display, result[i].list[50].umumiy, ortacha,
                                result[i].list[50].max, result[i].list[50].min, null, null, null, null);
                        else if (result1[i].list[50].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[50].Display, null, null, null, null, result1[i].list[50].umumiy,
                                ortacha2, result1[i].list[50].max, result1[i].list[50].min);
                        else
                            dataGridView1.Rows.Add(null, koms[50].Display);
                    else if (result[i].list[50].umumiy != 0 && result1[i].list[50].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[50].Display, result[i].list[50].umumiy, ortacha,
                            result[i].list[50].max, result[i].list[50].min, result1[i].list[50].umumiy, ortacha2,
                            result1[i].list[50].max, result1[i].list[50].min);
                    else if (result[i].list[50].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[50].Display, result[i].list[50].umumiy, ortacha,
                            result[i].list[50].max, result[i].list[50].min, null, null, null, null);
                    else if (result1[i].list[50].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[50].Display, null, null, null, null, result1[i].list[50].umumiy,
                                ortacha2, result1[i].list[50].max, result1[i].list[50].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[50].Display);
                    tt = true;
                }
                if (t[51])
                {
                    ortacha = result[i].list[51].ortacha / result[i].list[51].umumiy;
                    ortacha2 = result1[i].list[51].ortacha / result1[i].list[51].umumiy;
                    if (tt)
                        if (result[i].list[51].umumiy != 0 && result1[i].list[51].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[51].Display, result[i].list[51].umumiy, ortacha,
                                result[i].list[51].max, result[i].list[51].min, result1[i].list[51].umumiy, ortacha2,
                                result1[i].list[51].max, result1[i].list[51].min);
                        else if (result[i].list[51].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[51].Display, result[i].list[51].umumiy, ortacha,
                                result[i].list[51].max, result[i].list[51].min, null, null, null, null);
                        else if (result1[i].list[51].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[51].Display, null, null, null, null, result1[i].list[51].umumiy,
                                ortacha2, result1[i].list[51].max, result1[i].list[51].min);
                        else
                            dataGridView1.Rows.Add(null, koms[51].Display);
                    else if (result[i].list[51].umumiy != 0 && result1[i].list[51].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[51].Display, result[i].list[51].umumiy, ortacha,
                            result[i].list[51].max, result[i].list[51].min, result1[i].list[51].umumiy, ortacha2,
                            result1[i].list[51].max, result1[i].list[51].min);
                    else if (result[i].list[51].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[51].Display, result[i].list[51].umumiy, ortacha,
                            result[i].list[51].max, result[i].list[51].min, null, null, null, null);
                    else if (result1[i].list[51].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[51].Display, null, null, null, null, result1[i].list[51].umumiy,
                                ortacha2, result1[i].list[51].max, result1[i].list[51].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[51].Display);
                    tt = true;
                }
                if (t[52])
                {
                    ortacha = result[i].list[52].ortacha / result[i].list[52].umumiy;
                    ortacha2 = result1[i].list[52].ortacha / result1[i].list[52].umumiy;
                    if (tt)
                        if (result[i].list[52].umumiy != 0 && result1[i].list[52].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[52].Display, result[i].list[52].umumiy, ortacha,
                                result[i].list[52].max, result[i].list[52].min, result1[i].list[52].umumiy, ortacha2,
                                result1[i].list[52].max, result1[i].list[52].min);
                        else if (result[i].list[52].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[52].Display, result[i].list[52].umumiy, ortacha,
                                result[i].list[52].max, result[i].list[52].min, null, null, null, null);
                        else if (result1[i].list[52].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[52].Display, null, null, null, null, result1[i].list[52].umumiy,
                                ortacha2, result1[i].list[52].max, result1[i].list[52].min);
                        else
                            dataGridView1.Rows.Add(null, koms[52].Display);
                    else if (result[i].list[52].umumiy != 0 && result1[i].list[52].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[52].Display, result[i].list[52].umumiy, ortacha,
                            result[i].list[52].max, result[i].list[52].min, result1[i].list[52].umumiy, ortacha2,
                            result1[i].list[52].max, result1[i].list[52].min);
                    else if (result[i].list[52].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[52].Display, result[i].list[52].umumiy, ortacha,
                            result[i].list[52].max, result[i].list[52].min, null, null, null, null);
                    else if (result1[i].list[52].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[52].Display, null, null, null, null, result1[i].list[52].umumiy,
                                ortacha2, result1[i].list[52].max, result1[i].list[52].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[52].Display);
                    tt = true;
                }
                if (t[53])
                {
                    ortacha = result[i].list[53].ortacha / result[i].list[53].umumiy;
                    ortacha2 = result1[i].list[53].ortacha / result1[i].list[53].umumiy;
                    if (tt)
                        if (result[i].list[53].umumiy != 0 && result1[i].list[53].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[53].Display, result[i].list[53].umumiy, ortacha,
                                result[i].list[53].max, result[i].list[53].min, result1[i].list[53].umumiy, ortacha2,
                                result1[i].list[53].max, result1[i].list[53].min);
                        else if (result[i].list[53].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[53].Display, result[i].list[53].umumiy, ortacha,
                                result[i].list[53].max, result[i].list[53].min, null, null, null, null);
                        else if (result1[i].list[53].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[53].Display, null, null, null, null, result1[i].list[53].umumiy,
                                ortacha2, result1[i].list[53].max, result1[i].list[53].min);
                        else
                            dataGridView1.Rows.Add(null, koms[53].Display);
                    else if (result[i].list[53].umumiy != 0 && result1[i].list[53].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[53].Display, result[i].list[53].umumiy, ortacha,
                            result[i].list[53].max, result[i].list[53].min, result1[i].list[53].umumiy, ortacha2,
                            result1[i].list[53].max, result1[i].list[53].min);
                    else if (result[i].list[53].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[53].Display, result[i].list[53].umumiy, ortacha,
                            result[i].list[53].max, result[i].list[53].min, null, null, null, null);
                    else if (result1[i].list[53].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[53].Display, null, null, null, null, result1[i].list[53].umumiy,
                                ortacha2, result1[i].list[53].max, result1[i].list[53].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[53].Display);
                    tt = true;
                }
                if (t[54])
                {
                    ortacha = result[i].list[54].ortacha / result[i].list[54].umumiy;
                    ortacha2 = result1[i].list[54].ortacha / result1[i].list[54].umumiy;
                    if (tt)
                        if (result[i].list[54].umumiy != 0 && result1[i].list[54].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[54].Display, result[i].list[54].umumiy, ortacha,
                                result[i].list[54].max, result[i].list[54].min, result1[i].list[54].umumiy, ortacha2,
                                result1[i].list[54].max, result1[i].list[54].min);
                        else if (result[i].list[54].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[54].Display, result[i].list[54].umumiy, ortacha,
                                result[i].list[54].max, result[i].list[54].min, null, null, null, null);
                        else if (result1[i].list[54].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[54].Display, null, null, null, null, result1[i].list[54].umumiy,
                                ortacha2, result1[i].list[54].max, result1[i].list[54].min);
                        else
                            dataGridView1.Rows.Add(null, koms[54].Display);
                    else if (result[i].list[54].umumiy != 0 && result1[i].list[54].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[54].Display, result[i].list[54].umumiy, ortacha,
                            result[i].list[54].max, result[i].list[54].min, result1[i].list[54].umumiy, ortacha2,
                            result1[i].list[54].max, result1[i].list[54].min);
                    else if (result[i].list[54].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[54].Display, result[i].list[54].umumiy, ortacha,
                            result[i].list[54].max, result[i].list[54].min, null, null, null, null);
                    else if (result1[i].list[54].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[54].Display, null, null, null, null, result1[i].list[54].umumiy,
                                ortacha2, result1[i].list[54].max, result1[i].list[54].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[54].Display);
                    tt = true;
                }
                if (t[55])
                {
                    ortacha = result[i].list[55].ortacha / result[i].list[55].umumiy;
                    ortacha2 = result1[i].list[55].ortacha / result1[i].list[55].umumiy;
                    if (tt)
                        if (result[i].list[55].umumiy != 0 && result1[i].list[55].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[55].Display, result[i].list[55].umumiy, ortacha,
                                result[i].list[55].max, result[i].list[55].min, result1[i].list[55].umumiy, ortacha2,
                                result1[i].list[55].max, result1[i].list[55].min);
                        else if (result[i].list[55].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[55].Display, result[i].list[55].umumiy, ortacha,
                                result[i].list[55].max, result[i].list[55].min, null, null, null, null);
                        else if (result1[i].list[55].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[55].Display, null, null, null, null, result1[i].list[55].umumiy,
                                ortacha2, result1[i].list[55].max, result1[i].list[55].min);
                        else
                            dataGridView1.Rows.Add(null, koms[55].Display);
                    else if (result[i].list[55].umumiy != 0 && result1[i].list[55].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[55].Display, result[i].list[55].umumiy, ortacha,
                            result[i].list[55].max, result[i].list[55].min, result1[i].list[55].umumiy, ortacha2,
                            result1[i].list[55].max, result1[i].list[55].min);
                    else if (result[i].list[55].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[55].Display, result[i].list[55].umumiy, ortacha,
                            result[i].list[55].max, result[i].list[55].min, null, null, null, null);
                    else if (result1[i].list[55].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[55].Display, null, null, null, null, result1[i].list[55].umumiy,
                                ortacha2, result1[i].list[55].max, result1[i].list[55].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[55].Display);
                    tt = true;
                }
                if (t[56])
                {
                    ortacha = result[i].list[56].ortacha / result[i].list[56].umumiy;
                    ortacha2 = result1[i].list[56].ortacha / result1[i].list[56].umumiy;
                    if (tt)
                        if (result[i].list[56].umumiy != 0 && result1[i].list[56].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[56].Display, result[i].list[56].umumiy, ortacha,
                                result[i].list[56].max, result[i].list[56].min, result1[i].list[56].umumiy, ortacha2,
                                result1[i].list[56].max, result1[i].list[56].min);
                        else if (result[i].list[56].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[56].Display, result[i].list[56].umumiy, ortacha,
                                result[i].list[56].max, result[i].list[56].min, null, null, null, null);
                        else if (result1[i].list[56].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[56].Display, null, null, null, null, result1[i].list[56].umumiy,
                                ortacha2, result1[i].list[56].max, result1[i].list[56].min);
                        else
                            dataGridView1.Rows.Add(null, koms[56].Display);
                    else if (result[i].list[56].umumiy != 0 && result1[i].list[56].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[56].Display, result[i].list[56].umumiy, ortacha,
                            result[i].list[56].max, result[i].list[56].min, result1[i].list[56].umumiy, ortacha2,
                            result1[i].list[56].max, result1[i].list[56].min);
                    else if (result[i].list[56].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[56].Display, result[i].list[56].umumiy, ortacha,
                            result[i].list[56].max, result[i].list[56].min, null, null, null, null);
                    else if (result1[i].list[56].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[56].Display, null, null, null, null, result1[i].list[56].umumiy,
                                ortacha2, result1[i].list[56].max, result1[i].list[56].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[56].Display);
                    tt = true;
                }
                if (t[57])
                {
                    ortacha = result[i].list[57].ortacha / result[i].list[57].umumiy;
                    ortacha2 = result1[i].list[57].ortacha / result1[i].list[57].umumiy;
                    if (tt)
                        if (result[i].list[57].umumiy != 0 && result1[i].list[57].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[57].Display, result[i].list[57].umumiy, ortacha,
                                result[i].list[57].max, result[i].list[57].min, result1[i].list[57].umumiy, ortacha2,
                                result1[i].list[57].max, result1[i].list[57].min);
                        else if (result[i].list[57].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[57].Display, result[i].list[57].umumiy, ortacha,
                                result[i].list[57].max, result[i].list[57].min, null, null, null, null);
                        else if (result1[i].list[57].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[57].Display, null, null, null, null, result1[i].list[57].umumiy,
                                ortacha2, result1[i].list[57].max, result1[i].list[57].min);
                        else
                            dataGridView1.Rows.Add(null, koms[57].Display);
                    else if (result[i].list[57].umumiy != 0 && result1[i].list[57].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[57].Display, result[i].list[57].umumiy, ortacha,
                            result[i].list[57].max, result[i].list[57].min, result1[i].list[57].umumiy, ortacha2,
                            result1[i].list[57].max, result1[i].list[57].min);
                    else if (result[i].list[57].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[57].Display, result[i].list[57].umumiy, ortacha,
                            result[i].list[57].max, result[i].list[57].min, null, null, null, null);
                    else if (result1[i].list[57].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[57].Display, null, null, null, null, result1[i].list[57].umumiy,
                                ortacha2, result1[i].list[57].max, result1[i].list[57].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[57].Display);
                    tt = true;
                }
                if (t[58])
                {
                    ortacha = result[i].list[58].ortacha / result[i].list[58].umumiy;
                    ortacha2 = result1[i].list[58].ortacha / result1[i].list[58].umumiy;
                    if (tt)
                        if (result[i].list[58].umumiy != 0 && result1[i].list[58].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[58].Display, result[i].list[58].umumiy, ortacha,
                                result[i].list[58].max, result[i].list[58].min, result1[i].list[58].umumiy, ortacha2,
                                result1[i].list[58].max, result1[i].list[58].min);
                        else if (result[i].list[58].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[58].Display, result[i].list[58].umumiy, ortacha,
                                result[i].list[58].max, result[i].list[58].min, null, null, null, null);
                        else if (result1[i].list[58].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[58].Display, null, null, null, null, result1[i].list[58].umumiy,
                                ortacha2, result1[i].list[58].max, result1[i].list[58].min);
                        else
                            dataGridView1.Rows.Add(null, koms[58].Display);
                    else if (result[i].list[58].umumiy != 0 && result1[i].list[58].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[58].Display, result[i].list[58].umumiy, ortacha,
                            result[i].list[58].max, result[i].list[58].min, result1[i].list[58].umumiy, ortacha2,
                            result1[i].list[58].max, result1[i].list[58].min);
                    else if (result[i].list[58].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[58].Display, result[i].list[58].umumiy, ortacha,
                            result[i].list[58].max, result[i].list[58].min, null, null, null, null);
                    else if (result1[i].list[58].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[58].Display, null, null, null, null, result1[i].list[58].umumiy,
                                ortacha2, result1[i].list[58].max, result1[i].list[58].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[58].Display);
                    tt = true;
                }
                if (t[59])
                {
                    ortacha = result[i].list[59].ortacha / result[i].list[59].umumiy;
                    ortacha2 = result1[i].list[59].ortacha / result1[i].list[59].umumiy;
                    if (tt)
                        if (result[i].list[59].umumiy != 0 && result1[i].list[59].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[59].Display, result[i].list[59].umumiy, ortacha,
                                result[i].list[59].max, result[i].list[59].min, result1[i].list[59].umumiy, ortacha2,
                                result1[i].list[59].max, result1[i].list[59].min);
                        else if (result[i].list[59].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[59].Display, result[i].list[59].umumiy, ortacha,
                                result[i].list[59].max, result[i].list[59].min, null, null, null, null);
                        else if (result1[i].list[59].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[59].Display, null, null, null, null, result1[i].list[59].umumiy,
                                ortacha2, result1[i].list[59].max, result1[i].list[59].min);
                        else
                            dataGridView1.Rows.Add(null, koms[59].Display);
                    else if (result[i].list[59].umumiy != 0 && result1[i].list[59].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[59].Display, result[i].list[59].umumiy, ortacha,
                            result[i].list[59].max, result[i].list[59].min, result1[i].list[59].umumiy, ortacha2,
                            result1[i].list[59].max, result1[i].list[59].min);
                    else if (result[i].list[59].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[59].Display, result[i].list[59].umumiy, ortacha,
                            result[i].list[59].max, result[i].list[59].min, null, null, null, null);
                    else if (result1[i].list[59].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[59].Display, null, null, null, null, result1[i].list[59].umumiy,
                                ortacha2, result1[i].list[59].max, result1[i].list[59].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[59].Display);
                    tt = true;
                }
                if (t[60])
                {
                    ortacha = result[i].list[60].ortacha / result[i].list[60].umumiy;
                    ortacha2 = result1[i].list[60].ortacha / result1[i].list[60].umumiy;
                    if (tt)
                        if (result[i].list[60].umumiy != 0 && result1[i].list[60].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[60].Display, result[i].list[60].umumiy, ortacha,
                                result[i].list[60].max, result[i].list[60].min, result1[i].list[60].umumiy, ortacha2,
                                result1[i].list[60].max, result1[i].list[60].min);
                        else if (result[i].list[60].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[60].Display, result[i].list[60].umumiy, ortacha,
                                result[i].list[60].max, result[i].list[60].min, null, null, null, null);
                        else if (result1[i].list[60].umumiy != 0)
                            dataGridView1.Rows.Add(null, koms[60].Display, null, null, null, null, result1[i].list[60].umumiy,
                                ortacha2, result1[i].list[60].max, result1[i].list[60].min);
                        else
                            dataGridView1.Rows.Add(null, koms[60].Display);
                    else if (result[i].list[60].umumiy != 0 && result1[i].list[60].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[60].Display, result[i].list[60].umumiy, ortacha,
                            result[i].list[60].max, result[i].list[60].min, result1[i].list[60].umumiy, ortacha2,
                            result1[i].list[60].max, result1[i].list[60].min);
                    else if (result[i].list[60].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[60].Display, result[i].list[60].umumiy, ortacha,
                            result[i].list[60].max, result[i].list[60].min, null, null, null, null);
                    else if (result1[i].list[60].umumiy != 0)
                        dataGridView1.Rows.Add(result[i].post, koms[60].Display, null, null, null, null, result1[i].list[60].umumiy,
                                ortacha2, result1[i].list[60].max, result1[i].list[60].min);
                    else
                        dataGridView1.Rows.Add(result[i].post, koms[60].Display);
                    tt = true;
                }
            }
        }


        private void mnFileItemExportExcel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Excel.Application ObjExcel = new Excel.Application();
                Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
                Excel._Worksheet ObjWorkSheet = ObjExcel.Sheets[1] as Excel.Worksheet;
                Microsoft.Office.Interop.Excel.Range rng;

                int exel_row_index = 0;

                if (Column10.Visible == false)
                {
                    // Title
                    ObjWorkSheet.Cells[++exel_row_index, 1] = this.Text; //22
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString());
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    rng.Font.Bold = true;
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString(), "F" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);

                    // SHapka
                    exel_row_index++;
                    // A ustun
                    ObjWorkSheet.Cells[++exel_row_index, 1] = "Водный объект (пункт, категория, створ)";
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString(), "A" + (exel_row_index + 1).ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // B ustun
                    ObjWorkSheet.Cells[exel_row_index, 2] = "Преобладающие загрязняющие вещества(показатели загрязнения)";
                    rng = ObjWorkSheet.get_Range("B" + exel_row_index.ToString(), "B" + (exel_row_index + 1).ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C-F ustunlar
                    ObjWorkSheet.Cells[exel_row_index, 3] = "Отчетный " + Year.ToString() + " год";
                    rng = ObjWorkSheet.get_Range("C" + exel_row_index.ToString(), "F" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C ustun 4 - qator
                    ObjWorkSheet.Cells[++exel_row_index, 3] = "общее число определ.";
                    rng = ObjWorkSheet.get_Range("C" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // D ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 4] = "среднее содержание (в мг.)";
                    rng = ObjWorkSheet.get_Range("D" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 5] = "максимальная концент (в мг.)";
                    rng = ObjWorkSheet.get_Range("E" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 6] = "минимальная концентр (в мг.)";
                    rng = ObjWorkSheet.get_Range("F" + exel_row_index.ToString());
                    rng.Font.Bold = true;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        ObjWorkSheet.Cells[++exel_row_index, 1] = dataGridView1.Rows[i].Cells[0].Value;
                        ObjWorkSheet.Cells[exel_row_index, 2] = dataGridView1.Rows[i].Cells[1].Value;
                        ObjWorkSheet.Cells[exel_row_index, 3] = dataGridView1.Rows[i].Cells[2].Value;
                        ObjWorkSheet.Cells[exel_row_index, 4] = dataGridView1.Rows[i].Cells[3].Value;
                        ObjWorkSheet.Cells[exel_row_index, 5] = dataGridView1.Rows[i].Cells[4].Value;
                        ObjWorkSheet.Cells[exel_row_index, 6] = dataGridView1.Rows[i].Cells[5].Value;

                        rng = ObjWorkSheet.get_Range("A" + (i + 4));
                        rng.RowHeight = 15;
                    }
                    // toliq maska qoyish
                    rng = ObjWorkSheet.get_Range("A" + 3, "F" + exel_row_index);
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    rng.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rng.WrapText = true;
                    rng.Borders.Weight = 2;
                    rng.ColumnWidth = 16;

                    rng = ObjWorkSheet.get_Range("A3", "A" + exel_row_index.ToString());
                    rng.ColumnWidth = 25;

                    rng = ObjWorkSheet.get_Range("B3", "B" + exel_row_index.ToString());
                    rng.ColumnWidth = 25;

                    // Namber Format for the Colounms C - F
                    rng = ObjWorkSheet.get_Range("D5", "F" + exel_row_index.ToString());
                    rng.NumberFormat = "#,##0.00";

                    ObjExcel.Visible = true;
                    ObjExcel.UserControl = true;
                }
                else
                {
                    // Title
                    ObjWorkSheet.Cells[++exel_row_index, 1] = "Характ.загрязнения поверх.вод по постам в долях ПДК за " + (Year - 1).ToString() + "-" + Year.ToString() + " годов";//2
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString());
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    rng.Font.Bold = true;
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString(), "J" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);

                    // SHapka
                    exel_row_index++;
                    // A ustun
                    ObjWorkSheet.Cells[++exel_row_index, 1] = "Водный объект (пункт, категория, створ)";
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString(), "A" + (exel_row_index + 1).ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // B ustun
                    ObjWorkSheet.Cells[exel_row_index, 2] = "Преобладающие загрязняющие вещества(показатели загрязнения)";
                    rng = ObjWorkSheet.get_Range("B" + exel_row_index.ToString(), "B" + (exel_row_index + 1).ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C-F ustunlar
                    ObjWorkSheet.Cells[exel_row_index, 3] = "Предыдущий " + (Year - 1).ToString() + " год";
                    rng = ObjWorkSheet.get_Range("C" + exel_row_index.ToString(), "F" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C ustun 4 - qator
                    ObjWorkSheet.Cells[++exel_row_index, 3] = "общее число определ.";
                    rng = ObjWorkSheet.get_Range("C" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // D ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 4] = "среднее содержание (в мг.)";
                    rng = ObjWorkSheet.get_Range("D" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 5] = "максимальная концент (в мг.)";
                    rng = ObjWorkSheet.get_Range("E" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 6] = "минимальная концентр (в мг.)";
                    rng = ObjWorkSheet.get_Range("F" + exel_row_index.ToString());
                    rng.Font.Bold = true;

                    exel_row_index--;
                    // G-J ustunlar
                    ObjWorkSheet.Cells[exel_row_index, 7] = "Отчетный " + Year.ToString() + " год";
                    rng = ObjWorkSheet.get_Range("G" + exel_row_index.ToString(), "J" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C ustun 4 - qator
                    ObjWorkSheet.Cells[++exel_row_index, 7] = "общее число определ.";
                    rng = ObjWorkSheet.get_Range("G" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // D ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 8] = "среднее содержание (в мг.)";
                    rng = ObjWorkSheet.get_Range("H" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 9] = "максимальная концент (в мг.)";
                    rng = ObjWorkSheet.get_Range("I" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 10] = "минимальная концентр (в мг.)";
                    rng = ObjWorkSheet.get_Range("J" + exel_row_index.ToString());
                    rng.Font.Bold = true;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        ObjWorkSheet.Cells[++exel_row_index, 1] = dataGridView1.Rows[i].Cells[0].Value;
                        ObjWorkSheet.Cells[exel_row_index, 2] = dataGridView1.Rows[i].Cells[1].Value;
                        ObjWorkSheet.Cells[exel_row_index, 3] = dataGridView1.Rows[i].Cells[2].Value;
                        ObjWorkSheet.Cells[exel_row_index, 4] = dataGridView1.Rows[i].Cells[3].Value;
                        ObjWorkSheet.Cells[exel_row_index, 5] = dataGridView1.Rows[i].Cells[4].Value;
                        ObjWorkSheet.Cells[exel_row_index, 6] = dataGridView1.Rows[i].Cells[5].Value;

                        ObjWorkSheet.Cells[exel_row_index, 7] = dataGridView1.Rows[i].Cells[6].Value;
                        ObjWorkSheet.Cells[exel_row_index, 8] = dataGridView1.Rows[i].Cells[7].Value;
                        ObjWorkSheet.Cells[exel_row_index, 9] = dataGridView1.Rows[i].Cells[8].Value;
                        ObjWorkSheet.Cells[exel_row_index, 10] = dataGridView1.Rows[i].Cells[9].Value;

                        rng = ObjWorkSheet.get_Range("A" + (i + 4));
                        rng.RowHeight = 15;
                    }
                    // toliq maska qoyish
                    rng = ObjWorkSheet.get_Range("A" + 3, "J" + exel_row_index);
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    rng.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rng.WrapText = true;
                    rng.Borders.Weight = 2;
                    rng.ColumnWidth = 16;

                    rng = ObjWorkSheet.get_Range("A3", "A" + exel_row_index.ToString());
                    rng.ColumnWidth = 25;

                    rng = ObjWorkSheet.get_Range("B3", "B" + exel_row_index.ToString());
                    rng.ColumnWidth = 25;

                    // Namber Format for the Colounms D - F and H-J
                    rng = ObjWorkSheet.get_Range("D5", "F" + exel_row_index.ToString());
                    rng.NumberFormat = "#,##0.00";

                    rng = ObjWorkSheet.get_Range("H5", "J" + exel_row_index.ToString());
                    rng.NumberFormat = "#,##0.00";

                    ObjExcel.Visible = true;
                    ObjExcel.UserControl = true;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            this.Cursor = Cursors.Arrow;
        }

        private int work_count = 0;
        private bool IsClosedForm = true;
        private string textform = "";
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lbProssesStatus.Text = 0.ToString() + " / " + work_count.ToString();
            work_count = dataGridView1.Rows.Count;
            lbProssesStatus.Visible = true;
            tspbExportExcel.Visible = true;
            tspbExportExcel.Maximum = work_count;
            IsClosedForm = false;
            textform = this.Text;

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();

            this.Cursor = Cursors.Default;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                tspbExportExcel.Value = e.ProgressPercentage;
                lbProssesStatus.Text = (e.ProgressPercentage + 1).ToString() + "/" + work_count.ToString();
                if (e.ProgressPercentage == work_count)
                    IsClosedForm = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Excel.Application ObjExcel = new Excel.Application();
                Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
                Excel._Worksheet ObjWorkSheet = ObjExcel.Sheets[1] as Excel.Worksheet;
                Microsoft.Office.Interop.Excel.Range rng;

                int exel_row_index = 0;

                if (Column10.Visible == false)
                {
                    // Title
                    ObjWorkSheet.Cells[++exel_row_index, 1] = textform; //22
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString());
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    rng.Font.Bold = true;
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString(), "F" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);

                    // SHapka
                    exel_row_index++;
                    // A ustun
                    ObjWorkSheet.Cells[++exel_row_index, 1] = "Водный объект (пункт, категория, створ)";
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString(), "A" + (exel_row_index + 1).ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // B ustun
                    ObjWorkSheet.Cells[exel_row_index, 2] = "Преобладающие загрязняющие вещества(показатели загрязнения)";
                    rng = ObjWorkSheet.get_Range("B" + exel_row_index.ToString(), "B" + (exel_row_index + 1).ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C-F ustunlar
                    ObjWorkSheet.Cells[exel_row_index, 3] = "Отчетный " + Year.ToString() + " год";
                    rng = ObjWorkSheet.get_Range("C" + exel_row_index.ToString(), "F" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C ustun 4 - qator
                    ObjWorkSheet.Cells[++exel_row_index, 3] = "общее число определ.";
                    rng = ObjWorkSheet.get_Range("C" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // D ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 4] = "среднее содержание (в мг.)";
                    rng = ObjWorkSheet.get_Range("D" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 5] = "максимальная концент (в мг.)";
                    rng = ObjWorkSheet.get_Range("E" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 6] = "минимальная концентр (в мг.)";
                    rng = ObjWorkSheet.get_Range("F" + exel_row_index.ToString());
                    rng.Font.Bold = true;

                    for (int i = 0; i < work_count; i++)
                    {
                        ObjWorkSheet.Cells[++exel_row_index, 1] = dataGridView1.Rows[i].Cells[0].Value;
                        ObjWorkSheet.Cells[exel_row_index, 2] = dataGridView1.Rows[i].Cells[1].Value;
                        ObjWorkSheet.Cells[exel_row_index, 3] = dataGridView1.Rows[i].Cells[2].Value;
                        ObjWorkSheet.Cells[exel_row_index, 4] = dataGridView1.Rows[i].Cells[3].Value;
                        ObjWorkSheet.Cells[exel_row_index, 5] = dataGridView1.Rows[i].Cells[4].Value;
                        ObjWorkSheet.Cells[exel_row_index, 6] = dataGridView1.Rows[i].Cells[5].Value;

                        rng = ObjWorkSheet.get_Range("A" + (i + 4));
                        rng.RowHeight = 15;

                        (sender as BackgroundWorker).ReportProgress(i);
                    }
                    // toliq maska qoyish
                    rng = ObjWorkSheet.get_Range("A" + 3, "F" + exel_row_index);
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    rng.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rng.WrapText = true;
                    rng.Borders.Weight = 2;
                    rng.ColumnWidth = 16;

                    rng = ObjWorkSheet.get_Range("A3", "A" + exel_row_index.ToString());
                    rng.ColumnWidth = 25;

                    rng = ObjWorkSheet.get_Range("B3", "B" + exel_row_index.ToString());
                    rng.ColumnWidth = 25;

                    // Namber Format for the Colounms C - F
                    rng = ObjWorkSheet.get_Range("D5", "F" + exel_row_index.ToString());
                    rng.NumberFormat = "#,##0.00";

                    ObjExcel.Visible = true;
                    ObjExcel.UserControl = true;
                }
                else
                {
                    // Title
                    ObjWorkSheet.Cells[++exel_row_index, 1] = textform;//2
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString());
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    rng.Font.Bold = true;
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString(), "J" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);

                    // SHapka
                    exel_row_index++;
                    // A ustun
                    ObjWorkSheet.Cells[++exel_row_index, 1] = "Водный объект (пункт, категория, створ)";
                    rng = ObjWorkSheet.get_Range("A" + exel_row_index.ToString(), "A" + (exel_row_index + 1).ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // B ustun
                    ObjWorkSheet.Cells[exel_row_index, 2] = "Преобладающие загрязняющие вещества(показатели загрязнения)";
                    rng = ObjWorkSheet.get_Range("B" + exel_row_index.ToString(), "B" + (exel_row_index + 1).ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C-F ustunlar
                    ObjWorkSheet.Cells[exel_row_index, 3] = "Предыдущий " + (Year - 1).ToString() + " год";
                    rng = ObjWorkSheet.get_Range("C" + exel_row_index.ToString(), "F" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C ustun 4 - qator
                    ObjWorkSheet.Cells[++exel_row_index, 3] = "общее число определ.";
                    rng = ObjWorkSheet.get_Range("C" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // D ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 4] = "среднее содержание (в мг.)";
                    rng = ObjWorkSheet.get_Range("D" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 5] = "максимальная концент (в мг.)";
                    rng = ObjWorkSheet.get_Range("E" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 6] = "минимальная концентр (в мг.)";
                    rng = ObjWorkSheet.get_Range("F" + exel_row_index.ToString());
                    rng.Font.Bold = true;

                    exel_row_index--;
                    // G-J ustunlar
                    ObjWorkSheet.Cells[exel_row_index, 7] = "Отчетный " + Year.ToString() + " год";
                    rng = ObjWorkSheet.get_Range("G" + exel_row_index.ToString(), "J" + exel_row_index.ToString());
                    rng.Merge(Type.Missing);
                    rng.Font.Bold = true;
                    // C ustun 4 - qator
                    ObjWorkSheet.Cells[++exel_row_index, 7] = "общее число определ.";
                    rng = ObjWorkSheet.get_Range("G" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // D ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 8] = "среднее содержание (в мг.)";
                    rng = ObjWorkSheet.get_Range("H" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 9] = "максимальная концент (в мг.)";
                    rng = ObjWorkSheet.get_Range("I" + exel_row_index.ToString());
                    rng.Font.Bold = true;
                    // E ustun 4 - qator
                    ObjWorkSheet.Cells[exel_row_index, 10] = "минимальная концентр (в мг.)";
                    rng = ObjWorkSheet.get_Range("J" + exel_row_index.ToString());
                    rng.Font.Bold = true;

                    for (int i = 0; i < work_count; i++)
                    {
                        ObjWorkSheet.Cells[++exel_row_index, 1] = dataGridView1.Rows[i].Cells[0].Value;
                        ObjWorkSheet.Cells[exel_row_index, 2] = dataGridView1.Rows[i].Cells[1].Value;
                        ObjWorkSheet.Cells[exel_row_index, 3] = dataGridView1.Rows[i].Cells[2].Value;
                        ObjWorkSheet.Cells[exel_row_index, 4] = dataGridView1.Rows[i].Cells[3].Value;
                        ObjWorkSheet.Cells[exel_row_index, 5] = dataGridView1.Rows[i].Cells[4].Value;
                        ObjWorkSheet.Cells[exel_row_index, 6] = dataGridView1.Rows[i].Cells[5].Value;

                        ObjWorkSheet.Cells[exel_row_index, 7] = dataGridView1.Rows[i].Cells[6].Value;
                        ObjWorkSheet.Cells[exel_row_index, 8] = dataGridView1.Rows[i].Cells[7].Value;
                        ObjWorkSheet.Cells[exel_row_index, 9] = dataGridView1.Rows[i].Cells[8].Value;
                        ObjWorkSheet.Cells[exel_row_index, 10] = dataGridView1.Rows[i].Cells[9].Value;

                        rng = ObjWorkSheet.get_Range("A" + (i + 4));
                        rng.RowHeight = 15;

                        (sender as BackgroundWorker).ReportProgress(i);
                    }
                    // toliq maska qoyish
                    rng = ObjWorkSheet.get_Range("A" + 3, "J" + exel_row_index);
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    rng.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    rng.WrapText = true;
                    rng.Borders.Weight = 2;
                    rng.ColumnWidth = 16;

                    rng = ObjWorkSheet.get_Range("A3", "A" + exel_row_index.ToString());
                    rng.ColumnWidth = 25;

                    rng = ObjWorkSheet.get_Range("B3", "B" + exel_row_index.ToString());
                    rng.ColumnWidth = 25;

                    // Namber Format for the Colounms D - F and H-J
                    rng = ObjWorkSheet.get_Range("D5", "F" + exel_row_index.ToString());
                    rng.NumberFormat = "#,##0.00";

                    rng = ObjWorkSheet.get_Range("H5", "J" + exel_row_index.ToString());
                    rng.NumberFormat = "#,##0.00";

                    ObjExcel.Visible = true;
                    ObjExcel.UserControl = true;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                return;
            }
        }

        private void HisobotPDKForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsClosedForm)
            {
                //MessageBox.Show("");
                return;
            }
        }
    }
}