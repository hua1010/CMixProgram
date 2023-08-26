using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
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
        private string[] templist = { "USER", "6500K", "9300K", "SRGB", "5800", "7500" };
        private byte[] tempIndex = { 0x0B, 0x05, 0x08, 0x01, 0x04, 0x06 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mMonitorList = MonitorTools.InitList();
            MonitorTools.listProbe(mMonitorList);
            for(int i = 0; i < templist.Length; i++)
            {
                ComboboxItem citem = new ComboboxItem();
                citem.Text = String.Format("{0}: {1}", tempIndex[i], templist[i]);
                citem.Value = tempIndex[i];
                temperature.Items.Add(citem);
            }
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
                try
                {
                    ComboboxItem item = devicebox.Items[devicebox.SelectedIndex] as ComboboxItem;
                    volumeValue = MonitorTools.getVCPValue(mMonitorList, item.Value, ((byte)MonitorTools.DeviceCode.VOLUME));
                    volume.Text = volumeValue.ToString();
                }catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Device {0} don't support DCC/CI: Message: {1}", devicebox.SelectedIndex, ex.Message));
                }
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
                rawCapabilities.Clear();
                inputlist.Items.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Device {0} don't support DCC/CI: Message: {1}", devicebox.SelectedIndex ,ex.Message));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (devicebox.Items.Count > 0)
            {
                StringBuilder buf = new StringBuilder(1024);//指定的buf大小必须大于传入的字符长度
                int index = devicebox.SelectedIndex;
                ComboboxItem item = devicebox.Items[index] as ComboboxItem;
                MonitorTools.getRawCapabilities(mMonitorList, item.Value, buf);
                rawCapabilities.Text = buf.ToString();


                string code_num = MonitorTools.DeviceCode.INPUT_SOURCE.ToString("X");
                string vcpString = SplitVCPString(buf.ToString(), "vcp");
                string commandlist = SplitVCPString(vcpString, code_num);

                string[] command = commandlist.Split(' ');
                string match = @"[a-z0-9]+";

                for (int num = 0; num < command.Length; num++)
                {
                    if(Regex.IsMatch(command[num], match))
                    {
                        byte source = Convert.ToByte(command[num], 16);
                        ComboboxItem citem = new ComboboxItem();
                        citem.Text = String.Format("{0}: {1}", source, "UnKnown InputSource");
                        citem.Value = source;
                        inputlist.Items.Add(citem);
                    }
                }
            }
        }

        private void inputlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (devicebox.Items.Count > 0)
            {
                ComboboxItem item = inputlist.Items[inputlist.SelectedIndex] as ComboboxItem;
                MonitorTools.setVCPValue(mMonitorList, devicebox.SelectedIndex, (byte)MonitorTools.DeviceCode.INPUT_SOURCE, (byte)item.Value);
            }
        }

        private void temperature_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (devicebox.Items.Count > 0)
            {
                ComboboxItem item = temperature.Items[temperature.SelectedIndex] as ComboboxItem;
                MonitorTools.setVCPValue(mMonitorList, devicebox.SelectedIndex, (byte)MonitorTools.DeviceCode.SELECT_COLOR_PRESET, (byte)item.Value);

                red_gain.Text = MonitorTools.getVCPValue(mMonitorList, devicebox.SelectedIndex, (byte)MonitorTools.DeviceCode.RED_GAIN).ToString();
                green_gain.Text = MonitorTools.getVCPValue(mMonitorList, devicebox.SelectedIndex, (byte)MonitorTools.DeviceCode.GREEN_GAIN).ToString();
                blue_gain.Text = MonitorTools.getVCPValue(mMonitorList, devicebox.SelectedIndex, (byte)MonitorTools.DeviceCode.BLUE_GAIN).ToString();
            }
        }


        private string SplitVCPString(string str, string code)
        {
            string vcpString = str.Substring(str.IndexOf(code) + code.Length);
            StringBuilder buf = new StringBuilder(1024);
            int flag = 0;
            foreach (var item in vcpString)
            {
                if (item == '(')
                {
                    if (flag != 0) buf.Append(item);
                    flag++;
                }
                else if (item == ')')
                {
                    flag--;
                    if (flag != 0) buf.Append(item);
                }
                else
                    buf.Append(item);

                if (flag == 0)
                    break;
            }
            return buf.ToString();
        }

        private void red_gain_TextChanged(object sender, EventArgs e)
        {
            if (devicebox.Items.Count > 0 && temperature.SelectedIndex >= 0 && temperature.SelectedIndex < temperature.Items.Count )
            {
                byte gain = Convert.ToByte(red_gain.Text, 10);
                MonitorTools.setVCPValue(mMonitorList, devicebox.SelectedIndex, (byte)MonitorTools.DeviceCode.RED_GAIN, gain);
            }
        }

        private void green_gain_TextChanged(object sender, EventArgs e)
        {
            if (devicebox.Items.Count > 0 && temperature.SelectedIndex >= 0 && temperature.SelectedIndex < temperature.Items.Count)
            {
                byte gain = Convert.ToByte(green_gain.Text, 10);
                MonitorTools.setVCPValue(mMonitorList, devicebox.SelectedIndex, (byte)MonitorTools.DeviceCode.GREEN_GAIN, gain);
            }
        }

        private void blue_gain_TextChanged(object sender, EventArgs e)
        {
            if (devicebox.Items.Count > 0 && temperature.SelectedIndex >= 0 && temperature.SelectedIndex < temperature.Items.Count)
            {
                byte gain = Convert.ToByte(blue_gain.Text, 10);
                MonitorTools.setVCPValue(mMonitorList, devicebox.SelectedIndex, (byte)MonitorTools.DeviceCode.BLUE_GAIN, gain);
            }
        }

        private void red_gain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void green_gain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void blue_gain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

    }
}
