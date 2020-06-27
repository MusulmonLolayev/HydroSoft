using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HydroDemo.Models;

namespace HydroSoft
{
    public partial class IZVSelectYear : Form
    {
        public int riverId;
        public int year;
        public IZVSelectYear(List<RiverClass> rivers)
        {
            InitializeComponent();
            comboBox1.DataSource = rivers;
            comboBox1.Name = "Name";
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                riverId = ((RiverClass)comboBox1.SelectedItem).Id;
                year = dateTimePicker1.Value.Year;

                if (checkBox1.Checked == false)
                {
                    year = 0;
                }

                this.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
