using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTest
{
    public partial class Form1 : Form
    {
        IntPtr mMonitorList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mMonitorList = MonitorTools.InitList();
            MonitorTools.listProbe(mMonitorList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = MonitorTools.getCount(mMonitorList);
            label2.Text = ": "+ count;
            label4.Text = "";
            StringBuilder buf = new StringBuilder(1024);//指定的buf大小必须大于传入的字符长度
            for (int i = 0; i < count; i++)
            {
                MonitorTools.getDeviceName(mMonitorList, i, buf);
                label4.Text += buf.ToString() +"\n";
            }
        }
    }
}
