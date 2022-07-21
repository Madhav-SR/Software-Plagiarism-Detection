using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace SoftwarePlagiarismFinder
{
    public partial class c2_Packetmonitor : Form
    {
        FileSystemWatcher[] fsw = null;
        SystemMeter My_meter = new SystemMeter();
        Stopwatch stopwatch = new Stopwatch();
        public string routerip = "192.168.0.1", localip = null, lastdnsid = null;
        public int curansrr = -1, curauth = -1, preauth = -1, preansrr = -1, anomipcount = 0, totalanomalydetected = 0, processidentify = 0;
        public int ipheadanmcnt = 0, pktpoint = 0, unidentprotocol = 0, pktcount = 0;
        public int[] protocolstream = new int[10];
       
        public static int lcount = 0;
        public static int cwcount = 0;
        public static int ercount = 0;
        public static int ecount = 0;
        public static int twcount = 0;
        public static int wcount = 0;
        public static int ccount = 0;
        static int Rcount = 0;
        static int Dcount = 0;
        static int Ccount = 0;
        static int Chcount = 0;
        private bool m_bDirty;
        private System.IO.FileSystemWatcher m_Watcher;
        Portact pplist = new Portact();
        private bool m_bIsWatching;
        private StringBuilder m_Sb;
        public string x1, lastiphdanm, stw;
        string s = "";
        string[] ipf = null;
        TreeNode n;
        bool iscontinue = true;
        int receive;
        Socket mainSocket;
        byte[] bData = new byte[4096];
        string[] arr = new string[96];
        string[] array1 = new string[50];
        static int i = 0;
        bool rs = true;
        int pt = 0;
        IPAddress ipaddTcpScan;
        int[] ports = new int[5000];

        public c2_Packetmonitor()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            My_meter.SystemMeter_Event += new EventHandler<Event_Meter>(My_meter_SystemMeter_Event);
            m_Sb = new StringBuilder();
            m_bDirty = false;
            m_bIsWatching = false;
            newfileacess();
            toolStripComboBox1.Items.Add(Program.org);
            toolStripComboBox1.Items.Add(Program.tar);
            if (Program.count == "0")
            {
                toolStripComboBox1.SelectedIndex = 0;
            }
            else
            {
                toolStripComboBox1.SelectedIndex = 1;
            }
        }
        public void newfileacess()
        {
            if (m_bIsWatching)
            {
                m_bIsWatching = false;
                m_Watcher.EnableRaisingEvents = false;
                m_Watcher.Dispose();


            }
            else
            {
                string[] drives = System.IO.Directory.GetLogicalDrives();
                fsw = new FileSystemWatcher[drives.Length];
                for (int i = 0; i < drives.Length; i++)
                {
                    m_bIsWatching = true;
                    m_Watcher = new System.IO.FileSystemWatcher();

                    if (Directory.Exists(drives[i]))
                    {
                        m_Watcher.Filter = "*.*";
                        m_Watcher.Path = drives[i];
                        m_Watcher.IncludeSubdirectories = true;
                        m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                             | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                        m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
                        m_Watcher.Created += new FileSystemEventHandler(OnChanged3);
                        m_Watcher.Deleted += new FileSystemEventHandler(OnChanged2);
                        m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
                        m_Watcher.EnableRaisingEvents = true;
                    }
                }
            }
        }
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Rcount++;
            label32.Text = "Renamed Files :";
            if (!m_bDirty)
            {
                m_Sb.Remove(0, m_Sb.Length);
                m_Sb.Append(e.OldFullPath);
                m_Sb.Append(" ");
                m_Sb.Append(e.ChangeType.ToString());
                m_Sb.Append(" ");
                m_Sb.Append("to ");
                m_Sb.Append(e.Name);
                m_Sb.Append("    ");
                m_Sb.Append(DateTime.Now.ToString());
                m_bDirty = true;

                ListViewItem it = new ListViewItem(e.OldFullPath);
                it.ForeColor = Color.Blue;
                it.SubItems.Add(e.ChangeType.ToString() + " to " + e.Name);

                it.SubItems.Add(DateTime.Now.ToString());
                listView4.Items.Add(it);

                m_Watcher.Filter = e.Name;
                m_Watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - m_Watcher.Filter.Length);

            }
        }
        private void OnChanged2(object sender, FileSystemEventArgs e)
        {
            Dcount++;


            if (!m_bDirty)
            {
                m_Sb.Remove(0, m_Sb.Length);
                m_Sb.Append(e.FullPath);
                m_Sb.Append(" ");
                m_Sb.Append(e.ChangeType.ToString());
                m_Sb.Append("    ");
                m_Sb.Append(DateTime.Now.ToString());


                ListViewItem it = new ListViewItem(e.FullPath);
                it.ForeColor = Color.Red;
                it.SubItems.Add(e.ChangeType.ToString());
                it.SubItems.Add(DateTime.Now.ToString());
                listView4.Items.Add(it);

                m_bDirty = true;





            }
        }

        private void OnChanged3(object sender, FileSystemEventArgs e)
        {


            if (!m_bDirty)
            {
                Ccount++;


                m_Sb.Remove(0, m_Sb.Length);
                m_Sb.Append(e.FullPath);
                m_Sb.Append(" ");
                m_Sb.Append(e.ChangeType.ToString());
                m_Sb.Append("    ");

                m_Sb.Append(DateTime.Now.ToString());


                m_bDirty = true;



                ListViewItem it = new ListViewItem(e.FullPath);
                it.ForeColor = Color.Green;
                it.SubItems.Add(e.ChangeType.ToString());
                it.SubItems.Add(DateTime.Now.ToString());
                listView4.Items.Add(it);




            }
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {


            if (!m_bDirty)
            {


                m_Sb.Remove(0, m_Sb.Length);
                m_Sb.Append(e.FullPath);
                m_Sb.Append(" ");
                m_Sb.Append(e.ChangeType.ToString());
                m_Sb.Append("    ");

                m_Sb.Append(DateTime.Now.ToString());


                m_bDirty = true;



                if (e.ChangeType.ToString() == "Changed")
                {
                    Chcount++;

                    ListViewItem it = new ListViewItem(e.FullPath);
                    it.ForeColor = Color.Green;
                    it.SubItems.Add(e.ChangeType.ToString());
                    it.SubItems.Add(DateTime.Now.ToString());
                    listView4.Items.Add(it);
                }
                else
                {
                    ListViewItem it = new ListViewItem(e.FullPath);
                    it.ForeColor = Color.Black;
                    it.SubItems.Add(e.ChangeType.ToString());
                    it.SubItems.Add(DateTime.Now.ToString());
                    listView4.Items.Add(it);

                }
                if (Chcount > 100)
                {
                    x1 = e.Name;
                }
                string x = e.Name;
                int l = x.LastIndexOf("\\");
                string x2 = x.Substring(l + 1);
                string[] a = x2.Split('.');
                string x3 = a[0];

                int l11 = x2.LastIndexOf(".");
                string x4 = x2.Substring(l11 + 1);
                






            }
        }
        void pplist_portlistevent(object sender, PortEvent e)
        {

            lstport.Items.Clear();
            lcount = 0;
            cwcount = 0;
            ecount = 0;
            twcount = 0;
            wcount = 0;
            CheckForIllegalCrossThreadCalls = false;
            foreach (PortInfo prt in e.Portarg)
            {
                ListViewItem it = new ListViewItem(prt.process);
                it.SubItems.Add(prt.port);
                it.SubItems.Add(prt.protocol);
                it.SubItems.Add(prt.PID);
                it.SubItems.Add(prt.status);
                if (prt.status.ToString() == "LISTENING")
                {
                    it.ForeColor = Color.Green;
                    lcount++;
                }
                else if (prt.status.ToString() == "CLOSE_WAIT")
                {
                    it.ForeColor = Color.Red;
                    cwcount++;
                }
                else if (prt.status.ToString() == "ESTABLISHED")
                {
                    it.ForeColor = Color.Turquoise;
                    ecount++;
                }
                else if (prt.status.ToString() == "TIME_WAIT")
                {
                    it.ForeColor = Color.MediumVioletRed;
                    twcount++;
                }
                else if (prt.status.ToString() == "WAITING")
                {
                    it.ForeColor = Color.Orange;
                    wcount++;
                }

                lstport.Items.Add(it);

            }

            listBox2.Items.Clear();
            listBox2.Items.Add("Listening ports: " + lcount);
            listBox2.Items.Add("Close wait ports: " + cwcount);
            listBox2.Items.Add("Established ports: " + ecount);
            listBox2.Items.Add("Time waitng ports: " + twcount);
            listBox2.Items.Add("Waitng ports: " + wcount);




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            My_meter.startMeter();
            MemoryInfo();
        }

        void My_meter_SystemMeter_Event(object sender, Event_Meter e)
        {
            
            circularGauge1.Value = Convert.ToDouble(e.ProcessorUsage);
            circularGauge2.Value = Convert.ToDouble(e.RamUsage);
            circularGauge3.Value = Convert.ToDouble(e.DiskUsage);

            cpulist.Items.Add(e.ProcessorUsage);
            if (cpulist.Items.Count > 0)
            {
                decimal sum = 0;
                for (int i = 0; i < cpulist.Items.Count; i++)
                {
                    sum += Convert.ToDecimal(cpulist.Items[i]);
                }
                cpuavg.Text = Convert.ToString(Math.Round(sum / cpulist.Items.Count))+" %";
            }
            memorylist.Items.Add(e.RamUsage);
            if (memorylist.Items.Count > 0)
            {
                decimal sum = 0;
                for (int i = 0; i < memorylist.Items.Count; i++)
                {
                    sum += Convert.ToDecimal(memorylist.Items[i]);
                }
                memavg.Text = Convert.ToString(Math.Round(sum / memorylist.Items.Count)) + " %";
            }
            disklist.Items.Add(e.DiskUsage);
            if (disklist.Items.Count > 0)
            {
                decimal sum = 0;
                for (int i = 0; i < disklist.Items.Count; i++)
                {
                    sum += Convert.ToDecimal(disklist.Items[i]);
                }
                diskavg.Text = Convert.ToString(Math.Round(sum / disklist.Items.Count)) + " %";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            ListIp();
            Listlog();
            ListTcp();
            ListUdp();
            ListDns();
            getPacket();
            pplist.portlistevent += new EventHandler<PortEvent>(pplist_portlistevent);
            pplist.Start();
            lbt.Text = System.DateTime.Now.ToLongTimeString();
            
        }
        void PData(byte[] bData, int receive)
        {
            Ipheader ipob = new Ipheader(bData, receive);
            AddIp(ipob);
            switch (ipob.Protocoltype)
            {
                case protocol.TCP: Tcpheader tcpob = new Tcpheader(ipob.Data, (int)ipob.Messagelength);
                    AddTcp(tcpob, ipob);
                    DnsCheckTcp(tcpob, ipob);
                    break;


                case protocol.UDP: Udpheader udpob = new Udpheader(ipob.Data, (int)ipob.Messagelength);
                    AddUdp(udpob, ipob);
                    DnsCheckUdp(udpob, ipob);
                    break;

            }
            if (Convert.ToInt32(ipob.Headerlength) < 20)
            {
                ipheadanmcnt += 1;
                lastiphdanm = ipob.sourceaddr.ToString();
                totalanomalydetected++;
            }
            if (ipob.Protocoltype.ToString() == "TCP" || ipob.Protocoltype.ToString() == "UDP")
            {
                protocolstream[pktpoint] = 0;
                pktpoint++;
                if (pktpoint == 10)
                    pktpoint = 0;
            }
            else if (ipob.Protocoltype.ToString() == "Unknown")
            {
                unidentprotocol++;
                protocolstream[pktpoint] = 1;
                pktpoint++;
                if (pktpoint == 10)
                    pktpoint = 0;

                pktcount = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (protocolstream[i] == 1)
                    {
                        pktcount++;
                    }
                }
                if (pktcount > 6)
                {
                    totalanomalydetected++;
                }
            }
        }
        void OnReceive(IAsyncResult ir)
        {
            int receive = mainSocket.EndReceive(ir);
            PData(bData, receive);
            //checkAnomaly();
            if (iscontinue)
            {
                bData = new byte[4096];
                mainSocket.BeginReceive(bData, 0, bData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }

        }
        void ListDns()
        {
            lstdns.Items.Clear();
            lstdns.Columns.Clear();
            lstdns.Columns.Add("DNS Source", 140);
            lstdns.Columns.Add("Identification", 140);
            lstdns.Columns.Add("Flags", 130);
            lstdns.Columns.Add("Questions", 140);
            lstdns.Columns.Add("Answer RR", 100);
            lstdns.Columns.Add("Authority RR", 170);
            lstdns.Columns.Add("Additional RRs", 135);

        }
        void getPacket()
        {
            if (iscontinue)
            {
                iscontinue = true;
                IPHostEntry ipentry = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress[] addr = ipentry.AddressList;
                string s1 = addr[1].ToString();
                // string s1 = lbaport.Text.ToString();
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                mainSocket.Bind(new IPEndPoint(IPAddress.Parse(s1), 0));
                mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

                byte[] byTrue = new byte[4] { 1, 0, 0, 0 };
                byte[] byOut = new byte[4];
                mainSocket.IOControl(IOControlCode.ReceiveAll, byTrue, byOut);
                mainSocket.BeginReceive(bData, 0, bData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }
            else
            {
                iscontinue = false;
                mainSocket.Close();
            }
        }

        void Listlog()
        {
            lstpdet.Items.Clear();
            lstpdet.Columns.Clear();
            lstpdet.Columns.Add("Source IP", 200);
            lstpdet.Columns.Add("Destination IP", 200);
            lstpdet.Columns.Add("Date Time", 210);
        }
        void ListIp()
        {
            lsvip.Items.Clear();
            lsvip.Columns.Clear();
            lsvip.Columns.Add("Source IP", 100);
            lsvip.Columns.Add("Destination IP", 135);
            lsvip.Columns.Add("Version", 95);
            lsvip.Columns.Add("HeaderLength", 115);
            lsvip.Columns.Add("Differentiated sevice", 165);
            lsvip.Columns.Add("Total length", 105);
            lsvip.Columns.Add("Identification", 115);
            lsvip.Columns.Add("Flags", 75);
            lsvip.Columns.Add("Fragmentation", 105);
            lsvip.Columns.Add("Protocol", 95);
            lsvip.Columns.Add("Time to live", 95);
            lsvip.Columns.Add("Checksum", 95);

            //lsvip.Columns.Add("Source address", 145);
            //lsvip.Columns.Add("Destination address", 135);
            lsvip.Columns.Add("Date", 140);
            lsvip.Columns.Add("Time", 160);

        }

        void ListTcp()
        {
            lsvtcp.Items.Clear();
            lsvtcp.Columns.Clear();
            lsvtcp.Columns.Add("Source IP", 140);
            lsvtcp.Columns.Add("Destination IP", 140);
            lsvtcp.Columns.Add("Source Port", 130);
            lsvtcp.Columns.Add("Destination Port", 140);
            lsvtcp.Columns.Add("Sequence No", 100);
            lsvtcp.Columns.Add("Acknowledgement No", 170);
            lsvtcp.Columns.Add("Header Length", 135);
            lsvtcp.Columns.Add("Flag", 135);
            lsvtcp.Columns.Add("Window Size", 100);
            lsvtcp.Columns.Add("Checksum", 100);
            lsvtcp.Columns.Add("Urgent pointer", 120);


            lsvtcp.Columns.Add("Date", 150);
            lsvtcp.Columns.Add("Time", 160);


        }

        void ListUdp()
        {
            lsvudp.Items.Clear();
            lsvudp.Columns.Clear();
            lsvudp.Columns.Add("Source IP", 180);
            lsvudp.Columns.Add("Destination IP", 180);
            lsvudp.Columns.Add("Source Port", 180);
            lsvudp.Columns.Add("Destination Port", 180);
            lsvudp.Columns.Add("Length", 180);
            lsvudp.Columns.Add("Check sum", 180);
            //lsvudp.Columns.Add("Date Time", 190);


            lsvudp.Columns.Add("Date", 140);
            lsvudp.Columns.Add("Time", 160);

        }
        void AddIp(Ipheader ipobj)
        {
            ListViewItem it1 = new ListViewItem(ipobj.sourceaddr.ToString());

          
          
                it1.ForeColor = Color.Green;
            //it1.ForeColor = Color.Green;
            it1.SubItems.Add(ipobj.destaddr.ToString());
            it1.SubItems.Add(ipobj.Version);
            it1.SubItems.Add(ipobj.Headerlength);
            it1.SubItems.Add(ipobj.diffservice);
            it1.SubItems.Add(ipobj.TotalLength);
            it1.SubItems.Add(ipobj.Identification);
            it1.SubItems.Add(ipobj.Flags);
            it1.SubItems.Add(ipobj.Fragmentationoffset);
            it1.SubItems.Add(ipobj.Protocoltype.ToString());
            it1.SubItems.Add(ipobj.TTL);
            it1.SubItems.Add(ipobj.Checksum);
            it1.SubItems.Add(DateTime.Now.ToShortDateString());
            it1.SubItems.Add(DateTime.Now.ToLongTimeString());
            lsvip.Items.Add(it1);



        }
        void AddUdp(Udpheader udpobj, Ipheader ipobj)
        {
            ListViewItem it2 = new ListViewItem(ipobj.sourceaddr.ToString());
          
            if (udpobj.SourcePort.ToString() == udpobj.DestinationPort.ToString())
            {
                // if(ipobj.sourceaddr.ToString()==ipobj.destaddr.ToString())
                // {
                int ct = 0;

                string x = ipobj.sourceaddr.ToString();
              

                it2.ForeColor = Color.Red;

                AddTolistEntry(ipobj.sourceaddr.ToString(), ipobj.destaddr.ToString(), DateTime.Now.ToString());

                //udpcolor = true;

            }

           /* if (udpcolor)
            {
                //Listlog();
                it2.ForeColor = Color.Red;
                AddTolistEntry(ipobj.sourceaddr.ToString(), ipobj.destaddr.ToString(), DateTime.Now.ToString());

            }*/
            else
            {
                it2.ForeColor = Color.Green;
            }
            /* if (udpobj.SourcePort.ToString() == "53" || udpobj.DestinationPort.ToString() == "53")
             {
                 lstdns.Items.Add(ipobj.sourceaddr.ToString());
                 MessageBox.Show("DNS");
             }*/
            it2.SubItems.Add(ipobj.destaddr.ToString());
            it2.SubItems.Add(udpobj.SourcePort);
            it2.SubItems.Add(udpobj.DestinationPort);
            it2.SubItems.Add(udpobj.Length);
            it2.SubItems.Add(udpobj.Checksum);
            it2.SubItems.Add(DateTime.Now.ToShortDateString());
            it2.SubItems.Add(DateTime.Now.ToLongTimeString());
            lsvudp.Items.Add(it2);
            //checkDosLayer();
        }
        private void AddTolistEntry(string sourceip, string destinationip, string datetime)
        {
            ListViewItem Log = new ListViewItem(sourceip);
            // Log.ForeColor = Color.Red;
            // lstpdet.Items.Add(sourceip);
            Log.SubItems.Add(destinationip);
            Log.SubItems.Add(datetime);
            lstpdet.Items.Add(Log);

        }
       
        void AddTcp(Tcpheader tcpobj, Ipheader ipobj)
        {
            ListViewItem it3 = new ListViewItem(ipobj.sourceaddr.ToString());
            
                it3.ForeColor = Color.Green;
            // it3.ForeColor = Color.Green;
            it3.SubItems.Add(ipobj.destaddr.ToString());
            it3.SubItems.Add(tcpobj.Sourceport);
            it3.SubItems.Add(tcpobj.Destinationport);
            it3.SubItems.Add(tcpobj.SequenceNo);
            it3.SubItems.Add(tcpobj.AckNo);
            it3.SubItems.Add(tcpobj.HeaderLength);
            it3.SubItems.Add(tcpobj.Flags);
            it3.SubItems.Add(tcpobj.Windsize);
            it3.SubItems.Add(tcpobj.Checksum);
            it3.SubItems.Add(tcpobj.UrgentPtr);
            if (tcpobj.UrgentPtr != "")
                it3.SubItems.Add(tcpobj.UrgentPtr);
            //else
            //  it3.SubItems.Add("");

            it3.SubItems.Add(DateTime.Now.ToShortDateString());
            it3.SubItems.Add(DateTime.Now.Date.ToLongTimeString());
            lsvtcp.Items.Add(it3);
            // anomaly detection
            String SourceIP = "";
            int DestPort, i, k, count, index = 0;
            SourceIP = ipobj.sourceaddr.ToString();
            count = lsvtcp.Items.Count;
            IPHostEntry iphost = Dns.GetHostEntry(Dns.GetHostName());
            ipaddTcpScan = iphost.AddressList[0];
            for (i = 0; i < count; i++)
            {
                if (SourceIP == lsvtcp.Items[i].SubItems[0].Text)
                {
                    DestPort = int.Parse(lsvtcp.Items[i].SubItems[3].Text);
                    k = System.Array.IndexOf(ports, DestPort);
                    if (k == -1)
                    {
                        ports[index] = DestPort;
                        index++;
                    }
                    if (index >= 3 && SourceIP != ipaddTcpScan.ToString())
                    {
                        index = 0;
                        if (System.Array.IndexOf(array1, SourceIP) == -1)
                        {
                            array1[++pt] = SourceIP;
                           // DialogResult d = MessageBox.Show("ANOMALY DETECTED IP ADDRESS : " + SourceIP, "PORT SCANNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //MessageBox.Show(SourceIP + " Port Scanning " + ipobj.destaddr.ToString());
                            //AnomalySummary("DoS LAYER", "Anomaly detected IP Address" + SourceIP, DateTime.Now.ToLongTimeString());
                            //lstip.Items.Add(SourceIP);

                        }
                    }
                }
            }
        }
        void DnsCheckTcp(Tcpheader tcpobj, Ipheader ipobj)
        {


            if (tcpobj.Destinationport == "53" || tcpobj.Sourceport == "53")
            {
                DNSHeader dnsobj = new DNSHeader(tcpobj.Data, (int)tcpobj.MsgLength);
                ListViewItem item1 = new ListViewItem(ipobj.sourceaddr.ToString());
                item1.SubItems.Add(dnsobj.Identification);
                item1.SubItems.Add(dnsobj.Flags);
                item1.SubItems.Add(dnsobj.TotalQuestions);
                item1.SubItems.Add(dnsobj.TotalAnswerRRs);
                item1.SubItems.Add(dnsobj.TotalAuthorityRRs);
                item1.SubItems.Add(dnsobj.TotalAdditionalRRs);
                lstdns.Items.Add(item1);

                if (ipobj.sourceaddr.ToString() == routerip && ipobj.sourceaddr.ToString() != localip)
                {

                    curansrr = Convert.ToInt32(dnsobj.TotalAnswerRRs);
                    curauth = Convert.ToInt32(dnsobj.TotalAuthorityRRs);
                    if (preauth == 1 && curauth == 1)
                    {
                        if (preansrr == 0 && curansrr == 0)
                        {
                            anomipcount++;
                            lastdnsid = dnsobj.Identification;
                            totalanomalydetected++;
                        }
                    }
                }
            }


        }
        void DnsCheckUdp(Udpheader udpobj, Ipheader ipobj)
        {

            if (udpobj.DestinationPort == "53" || udpobj.SourcePort == "53")
            {
                DNSHeader dnsobj = new DNSHeader(udpobj.Data, Convert.ToInt32(udpobj.Length) - 8);
                ListViewItem item1 = new ListViewItem(ipobj.sourceaddr.ToString());
                item1.SubItems.Add(dnsobj.Identification);
                item1.SubItems.Add(dnsobj.Flags);
                item1.SubItems.Add(dnsobj.TotalQuestions);
                item1.SubItems.Add(dnsobj.TotalAnswerRRs);
                item1.SubItems.Add(dnsobj.TotalAuthorityRRs);
                item1.SubItems.Add(dnsobj.TotalAdditionalRRs);
                lstdns.Items.Add(item1);
                if (ipobj.sourceaddr.ToString() == routerip && ipobj.sourceaddr.ToString() != localip)
                {
                    curansrr = Convert.ToInt32(dnsobj.TotalAnswerRRs);
                    curauth = Convert.ToInt32(dnsobj.TotalAuthorityRRs);
                    if (preauth == 1 && curauth == 1)
                    {
                        if (preansrr == 0 && curansrr == 0)
                        {
                            anomipcount++;
                            lastdnsid = dnsobj.Identification;
                            totalanomalydetected++;
                        }
                    }
                }
            }
        }
        public struct MEMORYSTATUS
        {
            public long dwLength;
            public long dwMemoryLoad;
            public long dwTotalPhys;
            public long dwAvailPhys;
            public long dwTotalPagefile;
            public long dwAvailPagefile;
            public long dwTotalVirtual;
            public long dwAvailVirtual;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryStatusEx
        {
            public int dwLength;
            public int dwMemoryLoad;
            public long dwTotalPhys;
            public long dwAvailPhys;
            public long dwTotalPageFile;
            public long dwAvailPageFile;
            public long dwTotalVirtual;
            public long dwAvailVirtual;
            public long dwAvailExtendedVirtual;
        }

        [DllImport("Kernel32.dll", ExactSpelling = true)]
        private static extern void GlobalMemoryStatus(ref MEMORYSTATUS mm);



        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool GlobalMemoryStatusEx([In, Out] ref MemoryStatusEx mse);

        private void MemoryInfo()
        {
            string minfo = "";

            MemoryStatusEx ms = new MemoryStatusEx();
            ms.dwLength = Marshal.SizeOf(typeof(MemoryStatusEx));
            bool res = GlobalMemoryStatusEx(ref ms);




            label9.Text = ms.dwMemoryLoad.ToString();
            label10.Text = (((double.Parse(ms.dwTotalPhys.ToString())) / 1024) / 1024).ToString() + " MB";
            label11.Text = (((double.Parse(ms.dwAvailPhys.ToString())) / 1024) / 1024).ToString() + " MB";
            label12.Text = (((double.Parse(ms.dwTotalVirtual.ToString())) / 1024) / 1024).ToString() + " MB";
            label15.Text = (((double.Parse(ms.dwAvailVirtual.ToString())) / 1024) / 1024).ToString() + " MB";
            label18.Text = (((double.Parse(ms.dwTotalPageFile.ToString())) / 1024) / 1024).ToString() + " MB";
            label17.Text = (((double.Parse(ms.dwAvailPageFile.ToString())) / 1024) / 1024).ToString() + " MB";
            label21.Text = ms.dwLength.ToString();







        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
            if (m_bDirty)
            {

                m_bDirty = false;
            }
            lfs1.Text = Ccount.ToString();
            lfs2.Text = Dcount.ToString();
            lfs3.Text = Chcount.ToString();
            lfs4.Text = Rcount.ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int ij = Convert.ToInt32(label23.Text);
            if (Convert.ToInt32(label23.Text) > 0)
            {
                
                ij--;
                label23.Text = ij.ToString();
            }
            else if (ij == 0)
            {
                timer3.Enabled = false;
                MessageBox.Show("Data Collected...");
              
                timer2.Enabled = false;
                timer1.Enabled = false;
                pplist.Stop();
                datacollection();
               
            }
        }
        public void datacollection()
        {
            string cpu = "";
            string mem = "";
            string disk = "";
            int ipc = 0, tc = 0, uc = 0, dc = 0;
            int fc = 0, fcr = 0, fd = 0, fr = 0;
            int avgmem = 0, avgphy = 0;
            cpu = cpuavg.Text;
            mem = memavg.Text;
            disk = diskavg.Text;
            ipc = lsvip.Items.Count;
            tc = lsvtcp.Items.Count;
            uc = lsvudp.Items.Count;
            dc = lstdns.Items.Count;
            fc = Convert.ToInt32(lfs1.Text.ToString());
            fcr = Convert.ToInt32(lfs3.Text.ToString());
            fd = Convert.ToInt32(lfs2.Text.ToString());
            fr = Convert.ToInt32(lfs4.Text.ToString());

            StreamWriter sw = File.AppendText(Application.StartupPath + "\\test.txt");
            sw.WriteLine("....................................................................");
            sw.WriteLine();
            sw.WriteLine("Avg cpu usage="+cpu);
            sw.WriteLine("Avg memory usage=" + mem);
            sw.WriteLine("Avg memory usage=" + disk);
            sw.WriteLine("IP Packet count=" +ipc.ToString());
            sw.WriteLine("TCP Packet count=" + tc.ToString());
            sw.WriteLine("UDP Packet count=" + uc.ToString());
            sw.WriteLine("DNS Packet count=" + dc.ToString());
            sw.WriteLine("File Created=" + fc.ToString());
            sw.WriteLine("File Changed=" + fcr.ToString());
            sw.WriteLine("File Deleted=" + fd.ToString());
            sw.WriteLine("File Renamed=" + fr.ToString());
            sw.WriteLine("Birthmark");
            sw.WriteLine("....................................................................");
            
            if (Program.count == "0")
            {
                Program.b1 = Convert.ToInt32(Program.filecount_org);
                sw.WriteLine(Birthmark(Program.filecount_org));
                Program.count = "1";
                sw.WriteLine("....................................................................");
                sw.Close();
                c2_Packetmonitor obj = new c2_Packetmonitor();
                ActiveForm.Hide();
                obj.Show();
            }
            else
            {
                Program.b2 = Convert.ToInt32(Program.filecount_tar);
                sw.WriteLine(Birthmark(Program.filecount_tar));
                sw.WriteLine("....................................................................");
                sw.Close();
                c3 obj = new c3();
                MessageBox.Show("Please Start your First Program for Multi threading analysis...");
                Program.count1 = "0";
                ActiveForm.Hide();
                obj.Show();
            }

           

        }
        public void similarity()
        {
            double f = 0;
            double f1 = Convert.ToDouble(Program.sim);
            double f2 = Convert.ToDouble(Program.error);

            if (f1 > f2)
            {
                f = (f2 / f1) * 100;
                MessageBox.Show(f.ToString());
            }
            else
            {
                f = (f1 / f2) * 100;
                MessageBox.Show(f.ToString());
            }

        }
        public static string Birthmark(string essentials)
        {
            var Birthmark1 = System.Text.Encoding.UTF8.GetBytes(essentials);
            return System.Convert.ToBase64String(Birthmark1);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
