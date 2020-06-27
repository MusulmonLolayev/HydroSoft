using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace HydroDemo.Forms
{
    public partial class ChangeLogin : Form
    {
        public ChangeLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(@"Data\Login.txt"))
                {
                    MessageBox.Show("Файл не существует");
                    this.Close();
                    return;
                }

                StreamReader f = new StreamReader(@"Data\Login.txt");
                
                string password = f.ReadLine();
                f.Close();
                string sSourceData;
                byte[] tmpSource;
                byte[] tmpHash;
                sSourceData = textBox1.Text;
                if (!textBox2.Text.Equals(textBox3.Text))
                {
                    MessageBox.Show("Пароли не совпадает");
                    return;
                }
                //Create a byte array from source data.
                tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

                if (password == BitConverter.ToString(tmpHash))
                {
                    string newpassword = textBox2.Text;
                    byte[] newbayt = ASCIIEncoding.ASCII.GetBytes(newpassword);
                    byte[] newhash = new MD5CryptoServiceProvider().ComputeHash(newbayt);

                    string javob = BitConverter.ToString(newhash);

                    StreamWriter fw = new StreamWriter(@"Data\Login.txt");
                    if (!File.Exists(@"Data\Login.txt"))
                    {
                        MessageBox.Show("Файл не существует");
                        this.Close();
                        return;
                    }
                    fw.WriteLine(javob);
                    fw.Close();
                    MessageBox.Show("Пароль изменение");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
