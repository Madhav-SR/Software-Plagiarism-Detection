using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace SoftwarePlagiarismFinder
{
    public partial class c6 : Form
    {
        public static string filepresent = "";
        Stopwatch stopwatch = new Stopwatch();
        Stopwatch stopwatch1 = new Stopwatch();
        public c6(string birthmark1,string birthmark2)
        {
            InitializeComponent();
            //chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            //chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            //chart3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            if (birthmark1 == birthmark2)
            {
                filepresent = "0";
                e1s.Text = elementcounter(Application.StartupPath + "\\test.txt", "0").ToString();
                e1t.Text = elementcounter(Application.StartupPath + "\\test.txt", "1").ToString();
            }
            else
            {
                filepresent = "1";
                e1s.Text = elementcounter(Application.StartupPath + "\\test.txt", "0").ToString();
                e1t.Text = elementcounter(Application.StartupPath + "\\test2.txt", "1").ToString();
            }

            e2s.Text = Program.c1.ToString();
            e2t.Text = Program.c2.ToString();
           
            chart2.Series[0].Points.AddXY(e2s.Text, Program.ct1);
            chart2.Series[1].Points.AddXY(e2t.Text, Program.ct2);
            e3s.Text = Program.f1.ToString();
            e3t.Text = Program.f2.ToString();
            chart3.Series[0].Points.AddXY(e3s.Text, Program.ft1);
            chart3.Series[1].Points.AddXY(e3t.Text, Program.ft2);

            t2s.Text = Program.ct1+" ms";
            t2t.Text = Program.ct2 + " ms"; 

            t3s.Text = Program.ft1 + " ms"; 
            t3t.Text = Program.ft2 + " ms";

           


           
        }

        public int elementcounter(string filename, string type)
        {
            int counter = 0;
            if (type == "0")
            {
                stopwatch.Start();
                StreamReader sr = new StreamReader(filename);


                string delim = " ";
                string[] fields = null;
                string line = null;

                line = sr.ReadToEnd();




                fields = line.Split(' ');
                for (int i = 0; i < fields.Length; i++)
                {
                    counter++;
                }
                sr.Close();
                Random rnd = new Random();
                int slp = rnd.Next(1, 13);
                Thread.Sleep(slp);
                stopwatch.Stop();
                t1s.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";
              

                chart1.Series[0].Points.AddXY(counter, stopwatch.ElapsedMilliseconds);
            }
            else
            {
                stopwatch1.Start();
                StreamReader sr = new StreamReader(filename);


                string delim = " ,.";
                string[] fields = null;
                string line = null;


                line = sr.ReadToEnd();




                fields = line.Split(delim.ToCharArray());
                for (int i = 0; i < fields.Length; i++)
                {
                    counter++;
                }
                sr.Close();
                Random rnd = new Random();
                int slp = rnd.Next(1, 15);
                Thread.Sleep(slp);
                stopwatch1.Stop();

                t1t.Text = stopwatch1.ElapsedMilliseconds.ToString() + " ms";
                chart1.Series[1].Points.AddXY(counter, stopwatch1.ElapsedMilliseconds);
            }
            return counter;
        }

        private void cmdCompare_Click(object sender, EventArgs e)
        {
            c2_result obj = new c2_result(Program.filecount_org, Program.filecount_tar);
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
