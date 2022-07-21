using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.IO;


namespace SoftwarePlagiarismFinder
{
    public partial class c3 : Form
    {
        GanttChart ganttChart1;
        public c3()
        {
            InitializeComponent();
            timer1.Enabled = false;
            ganttChart1 = new GanttChart();
            ganttChart1.AllowChange = false;
            ganttChart1.Dock = DockStyle.Fill;
            ganttChart1.FromDate = System.DateTime.Now;
            ganttChart1.ToDate = System.DateTime.Now.AddHours(1);
            timer2.Enabled = false;
            panel1.Controls.Add(ganttChart1);
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process procces = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.ProcessThreadCollection threadCollection = procces.Threads;

            string threads = string.Empty;

            foreach (System.Diagnostics.ProcessThread proccessThread in threadCollection)
            {
                threads += string.Format("Thread Id: {0}, ThreadState: {1}\r\n", proccessThread.Id, proccessThread.ThreadState);
            }

            MessageBox.Show(threads);
        }
        private void GetProcesses()
        {
            int count = 0;
            chart1.Series.Clear();

            string proinfo = string.Empty;
            Process[] pro = Process.GetProcesses();
            foreach (Process p in pro)
            {
                count++;
                proinfo = proinfo + "|" + p.ProcessName;
                ListViewItem it2 = new ListViewItem(p.ProcessName.ToString());
                it2.SubItems.Add(p.Id.ToString());
               
                it2.SubItems.Add(p.Threads.Count.ToString());
              
                it2.SubItems.Add(p.Responding.ToString());
               

                listView1.Items.Add(it2);
                chart1.Series.Add(count.ToString());
                chart1.Series[count.ToString()].Points.AddXY(count, p.Threads.Count);
                
               
            }

           DisplayInfo3(proinfo);

        }
        public void DisplayInfo3(string Information)
        {
            listView3.Items.Clear();

            string[] strArray = Information.Split((char)124);


            foreach (string process in strArray)
            {
                if (process.Equals("PROCESS") || process.Equals(string.Empty) || process.Equals("T"))
                    continue;
                listView3.Items.Add(process);

            }
        }

        public void addthreads()
        {
            try
            {
                GetProcesses();
                lstport.Items.Clear();
                lsport2.Items.Clear();
             
                System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();

                System.Diagnostics.ProcessThreadCollection myThreads = proc.Threads;

                Console.WriteLine("process: {0},  id: {1}", proc.ProcessName, proc.Id);


                // Add the series to the chart series collection.
                int count = 0;
                int wc = 0, rc = 0;
                List<BarInformation> lst1 = new List<BarInformation>();
                foreach (System.Diagnostics.ProcessThread pt in myThreads)
                {

                    ListViewItem it = new ListViewItem(pt.Id.ToString());
                    it.SubItems.Add(pt.StartTime.ToString());
                    it.SubItems.Add(pt.TotalProcessorTime.ToString());
                    if (pt.ThreadState.ToString() == "Wait")
                    {
                        DateTime t = DateTime.Now.AddMinutes(10);
                       
                        lst1.Add(new BarInformation(pt.Id.ToString(), pt.StartTime, t, Color.Black, Color.Khaki, count));
                    }
                    else
                    {
                        DateTime t = DateTime.Now.AddMinutes(10);
                      
                        lst1.Add(new BarInformation(pt.Id.ToString(), pt.StartTime, t, Color.Blue, Color.Khaki, count));
                    }
                    it.SubItems.Add(pt.ThreadState.ToString());

                    lstport.Items.Add(it);

                    
                   

                    ListViewItem it2 = new ListViewItem(pt.Id.ToString());
                    it2.SubItems.Add(pt.BasePriority.ToString());
                    it2.SubItems.Add(pt.CurrentPriority.ToString());
                    it2.SubItems.Add(pt.PriorityLevel.ToString());
                    it2.SubItems.Add(pt.PriorityBoostEnabled.ToString());

                    it2.SubItems.Add(pt.PrivilegedProcessorTime.Ticks.ToString());
                    it2.SubItems.Add(pt.StartAddress.ToString());

                    lsport2.Items.Add(it2);
                    count++;
                }
                foreach (BarInformation bar in lst1)
                {
                    DateTime to = System.DateTime.Now.AddMinutes(10);
                    ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, to, bar.Color, bar.HoverColor, bar.Index);
                }

            }
            catch (Exception ex)
            { }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            addthreads();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int ij = Convert.ToInt32(label23.Text);
            if (Convert.ToInt32(label23.Text) > 0)
            {

                ij--;
                label23.Text = ij.ToString();
            }
            else if (ij == 0)
            {
                timer2.Enabled = false;
                timer1.Enabled = false;

                if (Program.count1 == "0")
                {
                    MessageBox.Show("Data Collected of first programs threads...");
                    MessageBox.Show("Please Start your Secound Program for Multi threading analysis...");

                    StreamWriter sw = File.AppendText(Application.StartupPath + "\\test.txt");
                    sw.WriteLine("....................................................................");
                    sw.WriteLine();
                    sw.WriteLine("Process count=" +listView3.Items.Count);
                    sw.WriteLine("Thread Count=" + listView1.Items.Count);
                    Program.t1 = listView1.Items.Count;
                    Program.count1 = "1";

                    sw.WriteLine("....................................................................");







                    c3 obj = new c3();
                    ActiveForm.Hide();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Data Collected of Both programs threads...");
                    StreamWriter sw = File.AppendText(Application.StartupPath + "\\test.txt");
                    sw.WriteLine("....................................................................");
                    sw.WriteLine();
                    sw.WriteLine("Process count=" + listView3.Items.Count);
                    sw.WriteLine("Thread Count=" + listView1.Items.Count);
                    Program.t2 = listView1.Items.Count;
                    sw.WriteLine("....................................................................");
                    sw.Close();
                    C5 obj = new C5(Program.filecount_org, Program.filecount_tar);
                    ActiveForm.Hide();
                    obj.Show();
                }
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
