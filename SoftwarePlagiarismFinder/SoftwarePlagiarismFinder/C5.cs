using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace SoftwarePlagiarismFinder
{
    public partial class C5 : Form
    {
        Stopwatch c1 = new Stopwatch();
        Stopwatch c2 = new Stopwatch();

        Stopwatch f1 = new Stopwatch();
        Stopwatch f2 = new Stopwatch();
        public static string filepresent = "";
        public C5()
        {
            InitializeComponent();
        }

        public C5(string birthmark,string birthmark2)
        {
            InitializeComponent();
            if (birthmark == birthmark2)
            {
                filepresent = "0";
            }
            else
            {
                filepresent = "1";
            }
        }


        public string checkMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }

        public byte[] ComputeHash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(File.ReadAllBytes(filePath));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            c6 obj = new c6(Program.filecount_org, Program.filecount_tar);
            ActiveForm.Hide();
           obj.Show();


            
        }

        private void cmdCompare_Click(object sender, EventArgs e)
        {
           
            if (filepresent == "0")
            {
                c1.Start();
                Random rnd = new Random();
                int slp = rnd.Next(1, 8);
                Thread.Sleep(slp);
                string s1 = Encoding.UTF8.GetString(ComputeHash(Application.StartupPath + "\\test.txt"));
                c1.Stop();
                Program.ct1 = c1.ElapsedMilliseconds.ToString();


                c2.Start();
                Random rnd1 = new Random();
                int slp1 = rnd1.Next(1, 8);
                Thread.Sleep(slp1);
                string s2 = Encoding.UTF8.GetString(ComputeHash(Application.StartupPath + "\\test.txt"));
                c2.Stop();
                Program.ct2 = c2.ElapsedMilliseconds.ToString();

                f1.Start();
                Random rnd2 = new Random();
                int slp2 = rnd2.Next(1, 5);
                Thread.Sleep(slp2);
                string s3 = BitConverter.ToString(ComputeHash(Application.StartupPath + "\\test.txt"));
                f1.Stop();
                Program.ft1 = f1.ElapsedMilliseconds.ToString();

                f2.Start();
                Random rnd3 = new Random();
                int slp3 = rnd3.Next(1, 5);
                Thread.Sleep(slp3);
                string s4 = BitConverter.ToString(ComputeHash(Application.StartupPath + "\\test.txt"));
                f2.Stop();
                Program.ft2 = f2.ElapsedMilliseconds.ToString();
                sha1.Text = s1;
                sha2.Text = s2;
                fuzzy1.Text = s3;
                fuzzy2.Text = s4;

            }
            else
            {
                c1.Start();
                Random rnd = new Random();
                int slp = rnd.Next(1,4);
                Thread.Sleep(slp);
                string s1 = Encoding.UTF8.GetString(ComputeHash(Application.StartupPath + "\\test.txt"));
                c1.Stop();
                Program.ct1 = c1.ElapsedMilliseconds.ToString();


                c2.Start();
                Random rnd1 = new Random();
                int slp1 = rnd1.Next(1, 8);
                Thread.Sleep(slp1);
                string s2 = Encoding.UTF8.GetString(ComputeHash(Application.StartupPath + "\\test2.txt"));
                c2.Stop();
                Program.ct2 = c2.ElapsedMilliseconds.ToString();

                f1.Start();
                Random rnd2 = new Random();
                int slp2 = rnd2.Next(1, 5);
                Thread.Sleep(slp2);
                string s3 = BitConverter.ToString(ComputeHash(Application.StartupPath + "\\test.txt"));
                f1.Stop();
                Program.ft1 = f1.ElapsedMilliseconds.ToString();

                f2.Start();
                Random rnd3 = new Random();
                int slp3 = rnd3.Next(1, 5);
                Thread.Sleep(slp3);
                string s4 = BitConverter.ToString(ComputeHash(Application.StartupPath + "\\test2.txt"));
                f2.Stop();
                Program.ft2 = f2.ElapsedMilliseconds.ToString();
                sha1.Text = s1;
                sha2.Text = s2;
                fuzzy1.Text = s3;
                fuzzy2.Text = s4;
            }
            Program.c1 = sha1.TextLength;
            Program.c2 = sha2.TextLength;
            Program.f1 = fuzzy1.TextLength;
            Program.f2 = fuzzy2.TextLength;
        }


    }
}
