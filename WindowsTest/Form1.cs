using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTest
{
    public partial class Form1 : Form
    {
        IntPtr mMonitorList;
        private ulong volumeValue = 0;
        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

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
            StringBuilder buf = new StringBuilder(1024);//指定的buf大小必须大于传入的字符长度
            for (int i = 0; i < count; i++)
            {
                MonitorTools.getDeviceName(mMonitorList, i, buf);
                ComboboxItem item = new ComboboxItem();
                item.Text = String.Format("{0}: {1}", i, buf);
                item.Value = i;
                devicebox.Items.Add(item);
            }
            if(devicebox.Items.Count > 0) { 
                devicebox.SelectedIndex = 0;
                ComboboxItem item = devicebox.Items[devicebox.SelectedIndex] as ComboboxItem;
                volumeValue = MonitorTools.getVCPValue(mMonitorList, item.Value, ((byte)MonitorTools.DeviceCode.VOLUME));
                volume.Text = volumeValue.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(devicebox.Items.Count > 0)
            {
                StringBuilder buf = new StringBuilder(1024);//指定的buf大小必须大于传入的字符长度
                int index = devicebox.SelectedIndex;
                ComboboxItem item = devicebox.Items[index]as ComboboxItem;
                MonitorTools.getRawCapabilities(mMonitorList, item.Value, buf);
                rawCapabilities.Text = buf.ToString();
            }
        }

        private void volume_up_Click(object sender, EventArgs e)
        {
            if(devicebox.Items.Count > 0)
            {
                if(volumeValue > 0 && volumeValue < 100)
                {
                    volumeValue++;
                    ComboboxItem item = devicebox.Items[devicebox.SelectedIndex] as ComboboxItem;
                    MonitorTools.setVCPValue(mMonitorList, item.Value, ((byte)MonitorTools.DeviceCode.VOLUME), volumeValue);
                    volume.Text = volumeValue.ToString();
                }
            }
        }

        private void volume_down_Click(object sender, EventArgs e)
        {
            if (devicebox.Items.Count > 0)
            {
                if (volumeValue > 0 && volumeValue <= 100)
                {
                    volumeValue--;
                    ComboboxItem item = devicebox.Items[devicebox.SelectedIndex] as ComboboxItem;
                    MonitorTools.setVCPValue(mMonitorList, item.Value, ((byte)MonitorTools.DeviceCode.VOLUME), volumeValue);
                    volume.Text = volumeValue.ToString();
                }
            }
        }

        private void devicebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboboxItem item = devicebox.Items[devicebox.SelectedIndex] as ComboboxItem;
                volumeValue = MonitorTools.getVCPValue(mMonitorList, item.Value, ((byte)MonitorTools.DeviceCode.VOLUME));
                volume.Text = volumeValue.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
