using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace HydroDemo.Forms
{
    public partial class LoginForm : Form
    {
        public string parol = "";
        public event EventHandler GetBool;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!File.Exists(@"Data\Login.txt"))
            {
                MessageBox.Show("Файл не существует");
                this.Close();
                return;
            }

            StreamReader f = new StreamReader(@"Data\Login.txt");
            string password = f.ReadLine();
            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;
            sSourceData = textBox1.Text;

            //Create a byte array from source data.
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            
            if (password == BitConverter.ToString(tmpHash))
            {
                if (GetBool != null)
                    GetBool(this, e);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!File.Exists(@"Data\Login.txt"))
                {
                    MessageBox.Show("Файл не существует");
                    this.Close();
                    return;
                }

                StreamReader f = new StreamReader(@"Data\Login.txt");
                string password = f.ReadLine();
                string sSourceData;
                byte[] tmpSource;
                byte[] tmpHash;
                sSourceData = textBox1.Text;

                //Create a byte array from source data.
                tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);


                if (password == BitConverter.ToString(tmpHash))
                {
                    if (GetBool != null)
                        GetBool(this, e);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
