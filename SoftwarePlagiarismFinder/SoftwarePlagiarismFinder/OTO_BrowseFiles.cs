using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DifferenceEngine;
using System.Collections;
namespace SoftwarePlagiarismFinder
{
    public partial class OTO_BrowseFiles : Form
    {
      

        private DiffEngineLevel _level;

        public OTO_BrowseFiles()
        {
            InitializeComponent();
            _level = DiffEngineLevel.FastImperfect; 
        }

        private void cmdSource_Click(object sender, EventArgs e)
        {
            txtSource.Text = GetFileName();
        }

        private string GetFileName()
        {
            string fname = string.Empty;
            OpenFileDialog dlg = new OpenFileDialog();

            
            dlg.Filter = "All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fname = dlg.FileName;
            }
            return fname;
        }

        private void cmdDestination_Click(object sender, EventArgs e)
        {
            txtDestination.Text = GetFileName();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCompare_Click(object sender, EventArgs e)
        {
            string sFile = txtSource.Text.Trim();
            string dFile = txtDestination.Text.Trim();

            if (!ValidFile(sFile))
            {
                MessageBox.Show("Source file name is invalid.", "Invalid File");
                txtSource.Focus();
                return;
            }

            if (!ValidFile(dFile))
            {
                MessageBox.Show("Destination file name is invalid.", "Invalid File");
                txtDestination.Focus();
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

            if (chkBinary.Checked)
            {
                BinaryDiff(sFile, dFile);
            }
            else
            {
                TextDiff(sFile, dFile);
            }
			
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


        private void BinaryDiff(string sFile, string dFile)
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

                OTO_BinaryResults dlg = new OTO_BinaryResults(rep, time);
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
    }
}
