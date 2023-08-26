namespace WindowsTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.devicebox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.rawCapabilities = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.volume = new System.Windows.Forms.Label();
            this.volume_up = new System.Windows.Forms.Button();
            this.volume_down = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.inputlist = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.temperature = new System.Windows.Forms.ComboBox();
            this.red_gain = new System.Windows.Forms.TextBox();
            this.green_gain = new System.Windows.Forms.TextBox();
            this.blue_gain = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备总数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "获取设备总数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "设备名：";
            // 
            // devicebox
            // 
            this.devicebox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicebox.FormattingEnabled = true;
            this.devicebox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.devicebox.Location = new System.Drawing.Point(239, 66);
            this.devicebox.Name = "devicebox";
            this.devicebox.Size = new System.Drawing.Size(290, 20);
            this.devicebox.TabIndex = 5;
            this.devicebox.SelectedIndexChanged += new System.EventHandler(this.devicebox_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "获取设备功能字符串";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rawCapabilities
            // 
            this.rawCapabilities.Location = new System.Drawing.Point(302, 143);
            this.rawCapabilities.Name = "rawCapabilities";
            this.rawCapabilities.Size = new System.Drawing.Size(335, 21);
            this.rawCapabilities.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Volume: ";
            // 
            // volume
            // 
            this.volume.AutoSize = true;
            this.volume.Location = new System.Drawing.Point(235, 105);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(11, 12);
            this.volume.TabIndex = 10;
            this.volume.Text = "0";
            // 
            // volume_up
            // 
            this.volume_up.Location = new System.Drawing.Point(270, 100);
            this.volume_up.Name = "volume_up";
            this.volume_up.Size = new System.Drawing.Size(36, 23);
            this.volume_up.TabIndex = 11;
            this.volume_up.Text = "+";
            this.volume_up.UseVisualStyleBackColor = true;
            this.volume_up.Click += new System.EventHandler(this.volume_up_Click);
            // 
            // volume_down
            // 
            this.volume_down.Location = new System.Drawing.Point(312, 100);
            this.volume_down.Name = "volume_down";
            this.volume_down.Size = new System.Drawing.Size(31, 23);
            this.volume_down.TabIndex = 12;
            this.volume_down.Text = "-";
            this.volume_down.UseVisualStyleBackColor = true;
            this.volume_down.Click += new System.EventHandler(this.volume_down_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "InputSouce:";
            // 
            // inputlist
            // 
            this.inputlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputlist.FormattingEnabled = true;
            this.inputlist.Location = new System.Drawing.Point(302, 183);
            this.inputlist.Name = "inputlist";
            this.inputlist.Size = new System.Drawing.Size(227, 20);
            this.inputlist.TabIndex = 14;
            this.inputlist.SelectedIndexChanged += new System.EventHandler(this.inputlist_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Color temperature:";
            // 
            // temperature
            // 
            this.temperature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.temperature.FormattingEnabled = true;
            this.temperature.Location = new System.Drawing.Point(302, 220);
            this.temperature.Name = "temperature";
            this.temperature.Size = new System.Drawing.Size(227, 20);
            this.temperature.TabIndex = 16;
            this.temperature.SelectedIndexChanged += new System.EventHandler(this.temperature_SelectedIndexChanged);
            // 
            // red_gain
            // 
            this.red_gain.Location = new System.Drawing.Point(250, 272);
            this.red_gain.MaxLength = 3;
            this.red_gain.Name = "red_gain";
            this.red_gain.Size = new System.Drawing.Size(67, 21);
            this.red_gain.TabIndex = 17;
            this.red_gain.TextChanged += new System.EventHandler(this.red_gain_TextChanged);
            this.red_gain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.red_gain_KeyPress);
            // 
            // green_gain
            // 
            this.green_gain.Location = new System.Drawing.Point(323, 272);
            this.green_gain.MaxLength = 3;
            this.green_gain.Name = "green_gain";
            this.green_gain.Size = new System.Drawing.Size(72, 21);
            this.green_gain.TabIndex = 18;
            this.green_gain.TextChanged += new System.EventHandler(this.green_gain_TextChanged);
            this.green_gain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.green_gain_KeyPress);
            // 
            // blue_gain
            // 
            this.blue_gain.Location = new System.Drawing.Point(401, 272);
            this.blue_gain.MaxLength = 3;
            this.blue_gain.Name = "blue_gain";
            this.blue_gain.Size = new System.Drawing.Size(69, 21);
            this.blue_gain.TabIndex = 19;
            this.blue_gain.TextChanged += new System.EventHandler(this.blue_gain_TextChanged);
            this.blue_gain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.blue_gain_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "RGB Gain:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.blue_gain);
            this.Controls.Add(this.green_gain);
            this.Controls.Add(this.red_gain);
            this.Controls.Add(this.temperature);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.inputlist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.volume_down);
            this.Controls.Add(this.volume_up);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rawCapabilities);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.devicebox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "DDC/CI调试DEMO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox devicebox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox rawCapabilities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label volume;
        private System.Windows.Forms.Button volume_up;
        private System.Windows.Forms.Button volume_down;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox inputlist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox temperature;
        private System.Windows.Forms.TextBox red_gain;
        private System.Windows.Forms.TextBox green_gain;
        private System.Windows.Forms.TextBox blue_gain;
        private System.Windows.Forms.Label label7;
    }
}

