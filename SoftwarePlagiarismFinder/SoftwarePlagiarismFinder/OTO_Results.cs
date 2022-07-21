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
    public partial class OTO_Results : Form
    {
       
        public OTO_Results(DiffList_TextFile source, DiffList_TextFile destination, ArrayList DiffLines, double seconds)
        {
            InitializeComponent();
            this.Text = string.Format("Results: {0} secs.", seconds.ToString("#0.00"));

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

        private void lvSource_Resize(object sender, EventArgs e)
        {
            if (lvSource.Width > 100)
            {
                lvSource.Columns[1].Width = -2;
            }
        }

        private void lvDestination_Resize(object sender, EventArgs e)
        {
            if (lvDestination.Width > 100)
            {
                lvDestination.Columns[1].Width = -2;
            }
        }

        private void OTO_Results_Resize(object sender, EventArgs e)
        {
            int w = this.ClientRectangle.Width / 2;
            lvSource.Location = new Point(0, 0);
            lvSource.Width = w;
            lvSource.Height = this.ClientRectangle.Height;

            lvDestination.Location = new Point(w + 1, 0);
            lvDestination.Width = this.ClientRectangle.Width - (w + 1);
            lvDestination.Height = this.ClientRectangle.Height;
        }

        private void OTO_Results_Load(object sender, EventArgs e)
        {
            OTO_Results_Resize(sender, e);
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
    }
}
