using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoftwarePlagiarismFinder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static string filecount_org = "";
        public static string filecount_tar = "";
        public static string org = "";
        public static string tar = "";
        public static string count = "0";
        public static string count1 = "0";
        public static int cscount = 0;
        public static int cdcount_ = 0;


        public static int sim = 0;
        public static int error = 0;

        public static int b1= 0;
        public static int b2 = 0;
        public static int t1 = 0;
        public static int t2 = 0;


        //hash counts

        public static int c1 = 0;
        public static int c2 = 0;
        public static string ct1 = "0";
        public static string ct2 = "0";

        public static int f1 = 0;
        public static int f2 = 0;
        public static string ft1 = "0";
        public static string ft2 = "0";
        public static double tsim = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
