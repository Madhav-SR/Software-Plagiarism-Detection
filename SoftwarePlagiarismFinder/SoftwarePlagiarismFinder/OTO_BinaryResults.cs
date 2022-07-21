using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DifferenceEngine;

namespace SoftwarePlagiarismFinder
{
    public partial class OTO_BinaryResults : Form
    {
        public OTO_BinaryResults(ArrayList al, double secs)
        {
            InitializeComponent();
            this.Text = string.Format("Binary Results: {0} secs.", secs.ToString("#0.00"));
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
                listView1.Items.Add(lvi);
            }
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            int w = Math.Max((listView1.Width - 20) / 4, 50);
            foreach (ColumnHeader ch in listView1.Columns)
            {
                ch.Width = w;
            }
        }

        private void OTO_BinaryResults_Resize(object sender, EventArgs e)
        {

        }

        private void OTO_BinaryResults_Load(object sender, EventArgs e)
        {
            listView1_Resize(this, e);
        }
    }
}
