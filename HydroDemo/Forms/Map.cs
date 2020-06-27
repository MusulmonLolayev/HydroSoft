using HydroSoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HydroSoft.Forms
{
    public delegate void CreateImage(MapModel map, string file);
    public delegate void DeleteImage(MapModel map);
    public partial class Map : Form
    {
        public List<MapModel> maps;
        public CreateImage createImage;
        public DeleteImage deleteImage;
        public Bitmap image;
        public Map(List<MapModel> maps, CreateImage createImage, DeleteImage deleteImage)
        {
            InitializeComponent();

            this.maps = maps;
            this.createImage = createImage;
            this.deleteImage = deleteImage;

            maps.ForEach(x =>
            {
                listBox1.Items.Add(x.Name);
            });
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndices.Count > 0)
                {
                    MapModel map = maps[listBox1.SelectedIndices[0]];
                    pictureBox1.Image = new Bitmap(System.IO.Directory.GetCurrentDirectory() + $@"/images/{map.Id}");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Пишите наименованную");
                    return;
                }
                OpenFileDialog open = new OpenFileDialog();
                open.Multiselect = false;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    if (createImage != null)
                    {
                        MapModel map = new MapModel();
                        map.Name = textBox1.Text;
                        createImage(map, open.FileName);
                        maps.Add(map);
                        listBox1.Items.Add(map.Name);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndices.Count > 0)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.InitialImage = null;
                    pictureBox1.Image = null;
                    pictureBox1.Update();

                    MapModel map = maps[listBox1.SelectedIndices[0]];
                    deleteImage?.Invoke(map);
                    maps.RemoveAt(listBox1.SelectedIndex);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
