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
    public partial class c1_BrowseFolders : Form
    {
        public c1_BrowseFolders()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int fCount = Directory.GetFiles(textBox1.Text, "*", SearchOption.AllDirectories).Length;
            label7.Text = fCount.ToString();
            Program.filecount_org = label7.Text;
            int fCount1 = Directory.GetFiles(textBox2.Text, "*", SearchOption.AllDirectories).Length;
            label8.Text = fCount1.ToString();
            Program.filecount_tar = label8.Text;
            string[] files = System.IO.Directory.GetFiles(textBox1.Text, "*.*");
            listView1.View = View.Details;
            foreach (string s in files)
            {
                // Create the FileInfo object only when needed to ensure
                // the information is as current as possible.
                System.IO.FileInfo fi = null;
               
                    fi = new System.IO.FileInfo(s);
                    listView1.Items.Add(new ListViewItem(new string[] { fi.Name,fi.Extension,fi.Length.ToString(),fi.CreationTime.ToString() }));
               
            }


            string[] files1 = System.IO.Directory.GetFiles(textBox2.Text, "*.*");
            listView2.View = View.Details;
            foreach (string s in files1)
            {
                // Create the FileInfo object only when needed to ensure
                // the information is as current as possible.
                System.IO.FileInfo fi = null;

                fi = new System.IO.FileInfo(s);
                listView2.Items.Add(new ListViewItem(new string[] { fi.Name, fi.Extension, fi.Length.ToString(), fi.CreationTime.ToString() }));

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c2_FileComparision obj = new c2_FileComparision(textBox1.Text, textBox2.Text);
            ActiveForm.Hide();
            obj.Show();

        }

        /*
          string[] files = System.IO.Directory.GetFiles(currentDirName, "*.txt");

        foreach (string s in files)
        {
            // Create the FileInfo object only when needed to ensure
            // the information is as current as possible.
            System.IO.FileInfo fi = null;
            try
            {
                 fi = new System.IO.FileInfo(s);
            }
            catch (System.IO.FileNotFoundException e)
            {
                // To inform the user and continue is
                // sufficient for this demonstration.
                // Your application may require different behavior.
                Console.WriteLine(e.Message);
                continue;
            }
            Console.WriteLine("{0} : {1}",fi.Name, fi.Directory);
        }
         * */
    }
}
