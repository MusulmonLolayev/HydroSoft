using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HydroSoft.Forms
{
    public partial class Graphic : Form
    {
        public Graphic(List<Series> list)
        {
            InitializeComponent();
            Legend legend = new Legend();
            chart1.Legends.Add(legend);

            list.ForEach(x =>
            {
                chart1.Series.Add(x);
            });
        }
    }
}
