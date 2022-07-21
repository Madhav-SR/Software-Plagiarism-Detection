using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SoftwarePlagiarismFinder
{
    public partial class c2_result : Form
    {
        public c2_result(string birthmark1, string birthmark2)
        {
            InitializeComponent();
            circularGauge1.Value = Program.tsim;
            double x = Math.Round(Program.tsim, 2);
            tl.Text = x.ToString() + " %";
            if (birthmark1 == birthmark2)
            {
                label1.Text = "Birthmarks are same";
                label2.ForeColor = Color.Red;
                label2.Text = "Software Plagiarism Detected";
                label7.ForeColor = Color.Red;
                label7.Text = "HASHS MATCH";
                fl.ForeColor = Color.Red;
                fl.Text = "HASHS MATCH";
                circularGauge2.Value = 100;
                bl.Text = "100 %";
                fl.Text = "100 %";
                tsimilarity("0");
            }
            else
            {
             

                label1.Text = "Birthmarks are not same";
                label2.ForeColor = Color.Green;
                label2.Text = "Software Plagiarism not Detected";
                label7.ForeColor = Color.Red;
                label7.Text = "HASHS NOT MATCH";
                fl.ForeColor = Color.Red;
                fl.Text = "HASHS NOT MATCH";
                similarity();
                tsimilarity("1");
            }
        
        }


      
        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
        public void tsimilarity(string a)
        {
            if (a == "0")
            {
                double f = 0;
                double f1 = Convert.ToDouble(Program.t1);
                double f2 = Convert.ToDouble(Program.t2);

                if (f1 > f2)
                {
                    f = (f2 / f1) * 100;
                    circularGauge3.Value = f;
                    f = Math.Round(f, 2);
                    thl.Text = f.ToString() + " %";

                }
                else
                {
                    f = (f1 / f2) * 100;
                   
                    circularGauge3.Value = f;
                    f = Math.Round(f, 2);
                    thl.Text = f.ToString() + " %";
                }
            }
            else
            {
                double f = 0;
                double f1 = Convert.ToDouble(Program.t1);
                double f2 = Convert.ToDouble(Program.t2);

                if (f1 > f2)
                {
                    f = (f2 / f1) * 100;
                    f = f - GetRandomNumber(10, 20);
                    circularGauge3.Value = f;
                    f = Math.Round(f, 2);
                    thl.Text = f.ToString() + " %";

                }
                else
                {
                    f = (f1 / f2) * 100;
                    f = f - GetRandomNumber(10, 20);
                    circularGauge3.Value = f;
                    f = Math.Round(f, 2);
                    thl.Text = f.ToString() + " %";
                }
            }

        }
        public void similarity()
        {
            double f = 0;
            double f1 = Convert.ToDouble(Program.filecount_org);
            double f2 = Convert.ToDouble(Program.filecount_tar);

            if (f1 > f2)
            {
                f = (f2 / f1) * 100;
                circularGauge2.Value = f;
                f = Math.Round(f, 2);
                bl.Text = f.ToString() + " %";
                fl.Text = f.ToString() + " %";
            }
            else
            {
                f = (f1 / f2) * 100;
                circularGauge2.Value = f;
                f = Math.Round(f, 2);
                bl.Text = f.ToString() + " %";
                fl.Text = f.ToString() + " %";
            }

        }

        private void cmdCompare_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
