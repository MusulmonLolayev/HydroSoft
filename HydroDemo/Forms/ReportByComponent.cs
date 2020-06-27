using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HydroDemo.Models;

namespace HydroDemo.Forms
{
    public partial class ReportByComponent : Form
    {
        public int sel_com_index;
        public int sel_river_index;
        public int dt1, dt2;

        private List<PostClass> posts;

        public ReportByComponent(KompanentaClass []list, List<RiverClass> rivers, List<PostClass> posts)
        {
            InitializeComponent();
            this.posts = posts;

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Display";

            comboBox2.DataSource = rivers.OrderBy(x => x.Name).ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.SelectedIndexChanged += changesel;
            comboBox2.SelectedIndex = 0;

            comboBox3.DisplayMember = "NameObserve";
        }

        private void changesel(object sender, EventArgs e)
        {
            int sel = (comboBox2.SelectedItem as RiverClass).Id;
            comboBox3.DataSource = posts.Where(x => x.River_Id == sel).OrderBy(x => x.NameObserve).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sel_com_index = comboBox1.SelectedIndex;
                sel_river_index = comboBox3.SelectedIndex;
                dt1 = int.Parse(textBox1.Text);
                dt2 = int.Parse(textBox2.Text);

                Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
