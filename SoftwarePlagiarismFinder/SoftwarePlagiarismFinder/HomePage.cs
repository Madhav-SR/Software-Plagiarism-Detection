using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftwarePlagiarismFinder
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            OTO_BrowseFiles obj = new OTO_BrowseFiles();
            obj.Show();
        }

        private void toolStripLabel9_Click(object sender, EventArgs e)
        {
            c1_BrowseFolders obj = new c1_BrowseFolders();
            obj.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
