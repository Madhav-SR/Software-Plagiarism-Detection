using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.ComponentModel;
using DifferenceEngine;



namespace SoftwarePlagiarismFinder
{
    public partial class c2_FileComparision : Form
    {
        public static int count = 0;
        public static int counts = 0;
        public static int fcount = 0;
        public static int scount = 0;
        private DiffEngineLevel _level;
        public c2_FileComparision()
        {
            InitializeComponent();
        }
        public c2_FileComparision(string s,string t)
        {
            InitializeComponent();
            textBox1.Text = s;
            textBox2.Text = t;
            Program.org = s;
            Program.tar = t;
            if (lvDestination.Width > 100)
            {
                lvDestination.Columns[1].Width = -2;
            }
            if (lvSource.Width > 100)
            {
                lvSource.Columns[1].Width = -2;
            }
        }

        private void c2_FileComparision_Load(object sender, EventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(textBox1.Text, "*.*");
            listView1.View = View.Details;
            foreach (string s in files)
            {
                // Create the FileInfo object only when needed to ensure
                // the information is as current as possible.
                System.IO.FileInfo fi = null;

                fi = new System.IO.FileInfo(s);
                if (fi.Extension.ToString() == ".txt" || fi.Extension.ToString() == ".cs")
                {
                    comboBox1.Items.Add(fi.Name);
                }
                listView1.Items.Add(new ListViewItem(new string[] { fi.Name, fi.Extension, fi.Length.ToString(), fi.CreationTime.ToString() }));
            }
                string[] files1 = System.IO.Directory.GetFiles(textBox2.Text, "*.*");
                listView2.View = View.Details;
                foreach (string s1 in files1)
                {
                    // Create the FileInfo object only when needed to ensure
                    // the information is as current as possible.
                    System.IO.FileInfo fi2 = null;

                    fi2 = new System.IO.FileInfo(s1);
                    if (fi2.Extension.ToString() == ".txt" || fi2.Extension.ToString() == ".cs")
                    {
                        comboBox2.Items.Add(fi2.Name);
                    }
                    listView2.Items.Add(new ListViewItem(new string[] { fi2.Name, fi2.Extension, fi2.Length.ToString(), fi2.CreationTime.ToString() }));

                }
            
        }

        public void BResults(ArrayList al, double secs)
        {
            listView3.Items.Clear();
            ListViewItem lvi = null;
            foreach (DiffResultSpan drs in al)
            {
                lvi = new ListViewItem(drs.Status.ToString());
                lvi.SubItems.Add(drs.DestIndex == -1 ? "---" : drs.DestIndex.ToString());
                lvi.SubItems.Add(drs.SourceIndex == -1 ? "---" : drs.SourceIndex.ToString());
                lvi.SubItems.Add(drs.Length.ToString());
                //lvi.BackColor = shade ? Color.AliceBlue : Color.White;
                switch (drs.Status)
                {
                    case DiffResultSpanStatus.NoChange:
                        lvi.ForeColor = Color.Black;
                        lvi.BackColor = Color.White;
                        break;
                    case DiffResultSpanStatus.DeleteSource:
                        lvi.ForeColor = Color.White;
                        lvi.BackColor = Color.LightCoral;
                        break;
                    case DiffResultSpanStatus.AddDestination:
                        lvi.ForeColor = Color.White;
                        lvi.BackColor = Color.LightGreen;
                        break;
                    case DiffResultSpanStatus.Replace:
                        lvi.ForeColor = Color.White;
                        lvi.BackColor = Color.LightSkyBlue;
                        break;
                }
                listView3.Items.Add(lvi);
            }
        }
        public void BinaryDiff(string sFile, string dFile)
        {
           
            this.Cursor = Cursors.WaitCursor;

            DiffList_BinaryFile sLF = null;
            DiffList_BinaryFile dLF = null;
            try
            {
                sLF = new DiffList_BinaryFile(sFile);
                dLF = new DiffList_BinaryFile(dFile);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "File Error");
                return;
            }

            try
            {
                double time = 0;
                DiffEngine de = new DiffEngine();
                time = de.ProcessDiff(sLF, dLF, _level);

                ArrayList rep = de.DiffReport();

                BResults(rep, time);
               

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                string tmp = string.Format("{0}{1}{1}***STACK***{1}{2}",
                    ex.Message,
                    Environment.NewLine,
                    ex.StackTrace);
                MessageBox.Show(tmp, "Compare Error");
                return;
            }
            this.Cursor = Cursors.Default;
        }
        private bool ValidFile(string fname)
        {
            if (fname != string.Empty)
            {
                if (File.Exists(fname))
                {
                    return true;
                }
            }
            return false;
        }
        private void cmdCompare_Click(object sender, EventArgs e)
        {
           
            string sFile =textBox1.Text+"\\" +comboBox1.Text.Trim();
            string dFile = textBox2.Text + "\\" + comboBox2.Text.Trim();
            textBox3.Text = sFile;
            textBox4.Text = dFile;

            if (!ValidFile(sFile))
            {
                MessageBox.Show("Source file name is invalid.", "Invalid File");
                comboBox1.Focus();
                return;
            }

            if (!ValidFile(dFile))
            {
                MessageBox.Show("Destination file name is invalid.", "Invalid File");
                comboBox2.Focus();
                return;
            }


            if (rbFast.Checked)
            {
                _level = DiffEngineLevel.FastImperfect;
            }
            else
            {
                if (rbMedium.Checked)
                {
                    _level = DiffEngineLevel.Medium;
                }
                else
                {
                    _level = DiffEngineLevel.SlowPerfect;
                }
            }
            BinaryDiff(sFile, dFile);
            TextDiff(sFile, dFile);
            System.IO.File.WriteAllText(Application.StartupPath + "\\test.txt", string.Empty);
            filewriter();
            r();
        }

        public void r()
        {
            label12.Text = counts.ToString();
            label11.Text = count.ToString();
        }
        public void filewriter()
        {
           
            StringBuilder sb;
            var sw = new StreamWriter(Application.StartupPath + "\\test.txt");
            fcount = 0;
            scount = 0;
            sw.WriteLine();
            sw.WriteLine("....................................................................");
            sw.WriteLine();
            sw.WriteLine("Comparing file : " + comboBox1.Text + " with " + comboBox2.Text);
            sw.WriteLine();
            sw.WriteLine("....................................................................");
           
            sw.WriteLine();
            sw.WriteLine();
            sw.WriteLine();
            if (listView3.Items.Count > 0)
            {
                // the actual data
               
                foreach (ListViewItem lvi in listView3.Items)
                {
                    sb = new StringBuilder();
                    if (lvi.Text.ToString()== "NoChange")
                    {
                        scount++;
                        counts++;
                    }
                    else
                    {
                        fcount++;
                        count++;
                    }
                    foreach (ListViewItem.ListViewSubItem listViewSubItem in lvi.SubItems)
                    {
                        sb.Append(string.Format("{0}\t", listViewSubItem.Text));
                    }
                    sw.WriteLine(sb.ToString());
                   
                }
                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine("Differences between  : " + comboBox1.Text + " and " + comboBox2.Text+" = "+fcount.ToString()+" numbers");
                sw.WriteLine();
                Program.error = Program.error + fcount;
                Program.sim = Program.sim + scount;
                sw.WriteLine(fcount.ToString() + " numbers means " + fcount.ToString() + " occurences of errors like source addition,deletion,updation etc");
                sw.WriteLine();
               
                sw.WriteLine("Similarity between  : " + comboBox1.Text + " and " + comboBox2.Text + " = " + scount.ToString() + " numbers");
                sw.WriteLine();
                sw.WriteLine("....................................................................");

                sw.WriteLine();
                sw.WriteLine("....................................................................");
            }
            sw.Close();
        }


        public void filewriter1()
        {

            StringBuilder sb;

           
            StreamWriter sw = File.AppendText(Application.StartupPath + "\\test.txt");
            fcount = 0;
            scount = 0;
            sw.WriteLine();
            sw.WriteLine("....................................................................");
            sw.WriteLine();
            sw.WriteLine("Comparing file : " + comboBox1.Text + " with " + comboBox2.Text);
            sw.WriteLine();
          
            sw.WriteLine("....................................................................");

            sw.WriteLine();
          
            sw.WriteLine();
            if (listView3.Items.Count > 0)
            {
                // the actual data

                foreach (ListViewItem lvi in listView3.Items)
                {
                    sb = new StringBuilder();
                    if (lvi.Text.ToString() == "NoChange")
                    {
                        counts++;
                        scount++;
                    }
                    else
                    {
                        fcount++;
                        count++;
                    }
                    foreach (ListViewItem.ListViewSubItem listViewSubItem in lvi.SubItems)
                    {
                        sb.Append(string.Format("{0}\t", listViewSubItem.Text));
                    }
                    sw.WriteLine(sb.ToString());

                }
                Program.error = Program.error + fcount;
                Program.sim = Program.sim + scount;
                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine("Differences between  : " + comboBox1.Text + " and " + comboBox2.Text + " = " + fcount.ToString() + " numbers");
                sw.WriteLine(fcount.ToString() + " numbers means " + fcount.ToString() + " occurences of errors like source addition,deletion,updation etc");
                sw.WriteLine();
                sw.WriteLine("Similarity between  : " + comboBox1.Text + " and " + comboBox2.Text + " = " + scount.ToString() + " numbers");
                sw.WriteLine();
                sw.WriteLine("....................................................................");

                sw.WriteLine();
                sw.WriteLine("....................................................................");
            }
            sw.Close();
        }
         public void Results(DiffList_TextFile source, DiffList_TextFile destination, ArrayList DiffLines, double seconds)
        {
            ListViewItem lviS;
            ListViewItem lviD;
            int cnt = 1;
            int i;

            foreach (DiffResultSpan drs in DiffLines)
            {
                switch (drs.Status)
                {
                    case DiffResultSpanStatus.DeleteSource:
                        for (i = 0; i < drs.Length; i++)
                        {
                            lviS = new ListViewItem(cnt.ToString("00000"));
                            lviD = new ListViewItem(cnt.ToString("00000"));
                            lviS.BackColor = Color.Red;
                            lviS.SubItems.Add(((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line);
                            lviD.BackColor = Color.LightGray;
                            lviD.SubItems.Add("");

                            lvSource.Items.Add(lviS);
                            lvDestination.Items.Add(lviD);
                            cnt++;
                        }

                        break;
                    case DiffResultSpanStatus.NoChange:
                        for (i = 0; i < drs.Length; i++)
                        {
                            lviS = new ListViewItem(cnt.ToString("00000"));
                            lviD = new ListViewItem(cnt.ToString("00000"));
                            lviS.BackColor = Color.White;
                            lviS.SubItems.Add(((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line);
                            lviD.BackColor = Color.White;
                            lviD.SubItems.Add(((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line);

                            lvSource.Items.Add(lviS);
                            lvDestination.Items.Add(lviD);
                            cnt++;
                        }

                        break;
                    case DiffResultSpanStatus.AddDestination:
                        for (i = 0; i < drs.Length; i++)
                        {
                            lviS = new ListViewItem(cnt.ToString("00000"));
                            lviD = new ListViewItem(cnt.ToString("00000"));
                            lviS.BackColor = Color.LightGray;
                            lviS.SubItems.Add("");
                            lviD.BackColor = Color.LightGreen;
                            lviD.SubItems.Add(((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line);

                            lvSource.Items.Add(lviS);
                            lvDestination.Items.Add(lviD);
                            cnt++;
                        }

                        break;
                    case DiffResultSpanStatus.Replace:
                        for (i = 0; i < drs.Length; i++)
                        {
                            lviS = new ListViewItem(cnt.ToString("00000"));
                            lviD = new ListViewItem(cnt.ToString("00000"));
                            lviS.BackColor = Color.Red;
                            lviS.SubItems.Add(((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line);
                            lviD.BackColor = Color.LightGreen;
                            lviD.SubItems.Add(((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line);

                            lvSource.Items.Add(lviS);
                            lvDestination.Items.Add(lviD);
                            cnt++;
                        }

                        break;
                }

            }
         }

         private void TextDiff1(string sFile, string dFile)
         {
             this.Cursor = Cursors.WaitCursor;

             DiffList_TextFile sLF = null;
             DiffList_TextFile dLF = null;
             try
             {
                 sLF = new DiffList_TextFile(sFile);
                 dLF = new DiffList_TextFile(dFile);
             }
             catch (Exception ex)
             {
                 this.Cursor = Cursors.Default;
                 MessageBox.Show(ex.Message, "File Error");
                 return;
             }

             try
             {
                 double time = 0;
                 DiffEngine de = new DiffEngine();
                 time = de.ProcessDiff(sLF, dLF, _level);

                 ArrayList rep = de.DiffReport();
                 OTO_Results dlg = new OTO_Results(sLF, dLF, rep, time);
                 dlg.ShowDialog();
                 dlg.Dispose();

             }
             catch (Exception ex)
             {
                 this.Cursor = Cursors.Default;
                 string tmp = string.Format("{0}{1}{1}***STACK***{1}{2}",
                     ex.Message,
                     Environment.NewLine,
                     ex.StackTrace);
                 MessageBox.Show(tmp, "Compare Error");
                 return;
             }
             this.Cursor = Cursors.Default;
         }
        private void TextDiff(string sFile, string dFile)
        {
            this.Cursor = Cursors.WaitCursor;

            DiffList_TextFile sLF = null;
            DiffList_TextFile dLF = null;
            try
            {
                sLF = new DiffList_TextFile(sFile);
                dLF = new DiffList_TextFile(dFile);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "File Error");
                return;
            }

            try
            {
                double time = 0;
                DiffEngine de = new DiffEngine();
                time = de.ProcessDiff(sLF, dLF, _level);

                ArrayList rep = de.DiffReport();
                Results(sLF, dLF, rep, time);
               
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                string tmp = string.Format("{0}{1}{1}***STACK***{1}{2}",
                    ex.Message,
                    Environment.NewLine,
                    ex.StackTrace);
                MessageBox.Show(tmp, "Compare Error");
                return;
            }
            this.Cursor = Cursors.Default;
        }

        private void lvSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSource.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvDestination.Items[lvSource.SelectedItems[0].Index];
                lvi.Selected = true;
                lvi.EnsureVisible();
            }
        }

        private void lvDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDestination.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvSource.Items[lvDestination.SelectedItems[0].Index];
                lvi.Selected = true;
                lvi.EnsureVisible();
            }
        }

        private void lvDestination_Resize(object sender, EventArgs e)
        {
            if (lvDestination.Width > 100)
            {
                lvDestination.Columns[1].Width = -2;
            }
        }

        private void lvSource_Resize(object sender, EventArgs e)
        {
            if (lvSource.Width > 100)
            {
                lvSource.Columns[1].Width = -2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sFile = textBox1.Text + "\\" + comboBox1.Text.Trim();
          
            int i = comboBox2.Items.Count;
            for (int j = 1; j < comboBox2.Items.Count; j++)
            {
                string dFile = textBox2.Text + "\\" + comboBox2.Text.Trim();
                comboBox2.SelectedIndex = j;
                BinaryDiff(sFile, dFile);
                TextDiff1(sFile, dFile);
                filewriter1();
               
            }
            r();
        }

        public void similarity()
        {
            double f = 0;
            double f1 = Convert.ToDouble(Program.sim);
            double f2 = Convert.ToDouble(Program.error);

            if (f1 > f2)
            {
                f = (f2 / f1) * 100;
                Program.tsim = f;
            }
            else
            {
                f = (f1 / f2) * 100;
                Program.tsim = f;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            similarity();
            c2_Packetmonitor obj = new c2_Packetmonitor();
            Program.count = "0";
            ActiveForm.Hide();
            obj.Show();

        }
    }
}
