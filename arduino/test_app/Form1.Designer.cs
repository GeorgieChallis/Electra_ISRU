namespace ArduinoTester
{
    partial class GS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GS));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Title_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rover_group_ctrl = new System.Windows.Forms.GroupBox();
            this.status_text = new System.Windows.Forms.Label();
            this.Disconnect_Button = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Connect_Button = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.settings_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Green_Button = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.green_label = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.yellow_label = new System.Windows.Forms.Label();
            this.Yellow_Button = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.red_label = new System.Windows.Forms.Label();
            this.Red_Button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Electro_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.electro_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.heater_label = new System.Windows.Forms.Label();
            this.Heater_Button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.magnet_label = new System.Windows.Forms.Label();
            this.Magnet_Button = new System.Windows.Forms.Button();
            this.Stop_Button = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.light_text = new System.Windows.Forms.Label();
            this.temp_text = new System.Windows.Forms.Label();
            this.GetLight_Button = new System.Windows.Forms.Button();
            this.GetTemp_Button = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.rover_group_ctrl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(8)))), ((int)(((byte)(48)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(605, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Title_label
            // 
            this.Title_label.AutoSize = true;
            this.Title_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(8)))), ((int)(((byte)(48)))));
            this.Title_label.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Title_label.Location = new System.Drawing.Point(131, 26);
            this.Title_label.Name = "Title_label";
            this.Title_label.Size = new System.Drawing.Size(458, 37);
            this.Title_label.TabIndex = 1;
            this.Title_label.Text = "Arduino Test Rig (ISRU Serial Comms)";
            this.Title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(674, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "V. 1.0.0";
            // 
            // rover_group_ctrl
            // 
            this.rover_group_ctrl.Controls.Add(this.status_text);
            this.rover_group_ctrl.Controls.Add(this.Disconnect_Button);
            this.rover_group_ctrl.Controls.Add(this.label28);
            this.rover_group_ctrl.Controls.Add(this.textBox1);
            this.rover_group_ctrl.Controls.Add(this.Connect_Button);
            this.rover_group_ctrl.Controls.Add(this.label38);
            this.rover_group_ctrl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rover_group_ctrl.Location = new System.Drawing.Point(30, 93);
            this.rover_group_ctrl.Name = "rover_group_ctrl";
            this.rover_group_ctrl.Size = new System.Drawing.Size(256, 143);
            this.rover_group_ctrl.TabIndex = 8;
            this.rover_group_ctrl.TabStop = false;
            // 
            // status_text
            // 
            this.status_text.AutoSize = true;
            this.status_text.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status_text.Location = new System.Drawing.Point(114, 62);
            this.status_text.Name = "status_text";
            this.status_text.Size = new System.Drawing.Size(79, 13);
            this.status_text.TabIndex = 27;
            this.status_text.Text = "Not Connected";
            // 
            // Disconnect_Button
            // 
            this.Disconnect_Button.BackColor = System.Drawing.SystemColors.Window;
            this.Disconnect_Button.Enabled = false;
            this.Disconnect_Button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Disconnect_Button.Location = new System.Drawing.Point(136, 94);
            this.Disconnect_Button.Name = "Disconnect_Button";
            this.Disconnect_Button.Size = new System.Drawing.Size(81, 32);
            this.Disconnect_Button.TabIndex = 27;
            this.Disconnect_Button.Text = "Disconnect";
            this.Disconnect_Button.UseVisualStyleBackColor = false;
            this.Disconnect_Button.Click += new System.EventHandler(this.button3_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label28.Location = new System.Drawing.Point(54, 62);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 13);
            this.label28.TabIndex = 26;
            this.label28.Text = "Status:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = "COM4";
            // 
            // Connect_Button
            // 
            this.Connect_Button.BackColor = System.Drawing.SystemColors.Window;
            this.Connect_Button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Connect_Button.Location = new System.Drawing.Point(41, 94);
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(81, 32);
            this.Connect_Button.TabIndex = 26;
            this.Connect_Button.Text = "Connect";
            this.Connect_Button.UseVisualStyleBackColor = false;
            this.Connect_Button.Click += new System.EventHandler(this.button17_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label38.Location = new System.Drawing.Point(38, 31);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(56, 13);
            this.label38.TabIndex = 24;
            this.label38.Text = "COM Port:";
            // 
            // settings_button
            // 
            this.settings_button.BackColor = System.Drawing.SystemColors.Window;
            this.settings_button.Location = new System.Drawing.Point(797, 662);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(119, 23);
            this.settings_button.TabIndex = 16;
            this.settings_button.Text = "Settings";
            this.settings_button.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Green_Button);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.green_label);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.yellow_label);
            this.groupBox1.Controls.Add(this.Yellow_Button);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.red_label);
            this.groupBox1.Controls.Add(this.Red_Button);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(308, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 143);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Indicator LEDs";
            // 
            // Green_Button
            // 
            this.Green_Button.BackColor = System.Drawing.Color.LightGreen;
            this.Green_Button.Enabled = false;
            this.Green_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Green_Button.Location = new System.Drawing.Point(266, 41);
            this.Green_Button.Name = "Green_Button";
            this.Green_Button.Size = new System.Drawing.Size(73, 35);
            this.Green_Button.TabIndex = 37;
            this.Green_Button.Text = "Toggle Green LED";
            this.Green_Button.UseVisualStyleBackColor = false;
            this.Green_Button.Click += new System.EventHandler(this.Green_Button_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(255, 96);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(47, 13);
            this.label41.TabIndex = 36;
            this.label41.Text = "Status:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // green_label
            // 
            this.green_label.AutoSize = true;
            this.green_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green_label.Location = new System.Drawing.Point(303, 96);
            this.green_label.Name = "green_label";
            this.green_label.Size = new System.Drawing.Size(13, 13);
            this.green_label.TabIndex = 35;
            this.green_label.Text = "--";
            this.green_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(149, 96);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(47, 13);
            this.label29.TabIndex = 34;
            this.label29.Text = "Status:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yellow_label
            // 
            this.yellow_label.AutoSize = true;
            this.yellow_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yellow_label.Location = new System.Drawing.Point(195, 96);
            this.yellow_label.Name = "yellow_label";
            this.yellow_label.Size = new System.Drawing.Size(13, 13);
            this.yellow_label.TabIndex = 33;
            this.yellow_label.Text = "--";
            this.yellow_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Yellow_Button
            // 
            this.Yellow_Button.BackColor = System.Drawing.Color.LemonChiffon;
            this.Yellow_Button.Enabled = false;
            this.Yellow_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Yellow_Button.Location = new System.Drawing.Point(159, 41);
            this.Yellow_Button.Name = "Yellow_Button";
            this.Yellow_Button.Size = new System.Drawing.Size(73, 35);
            this.Yellow_Button.TabIndex = 32;
            this.Yellow_Button.Text = "Toggle Yellow LED";
            this.Yellow_Button.UseVisualStyleBackColor = false;
            this.Yellow_Button.Click += new System.EventHandler(this.Yellow_Button_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(42, 96);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(47, 13);
            this.label32.TabIndex = 27;
            this.label32.Text = "Status:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // red_label
            // 
            this.red_label.AutoSize = true;
            this.red_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red_label.Location = new System.Drawing.Point(91, 96);
            this.red_label.Name = "red_label";
            this.red_label.Size = new System.Drawing.Size(13, 13);
            this.red_label.TabIndex = 26;
            this.red_label.Text = "--";
            this.red_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Red_Button
            // 
            this.Red_Button.BackColor = System.Drawing.Color.MistyRose;
            this.Red_Button.Enabled = false;
            this.Red_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Red_Button.Location = new System.Drawing.Point(50, 41);
            this.Red_Button.Name = "Red_Button";
            this.Red_Button.Size = new System.Drawing.Size(73, 36);
            this.Red_Button.TabIndex = 23;
            this.Red_Button.Text = "Toggle Red LED";
            this.Red_Button.UseVisualStyleBackColor = false;
            this.Red_Button.Click += new System.EventHandler(this.Red_Button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Electro_Button);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.electro_label);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.heater_label);
            this.groupBox2.Controls.Add(this.Heater_Button);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.magnet_label);
            this.groupBox2.Controls.Add(this.Magnet_Button);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(308, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 135);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensor Data";
            // 
            // Electro_Button
            // 
            this.Electro_Button.BackColor = System.Drawing.Color.Gainsboro;
            this.Electro_Button.Enabled = false;
            this.Electro_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Electro_Button.Location = new System.Drawing.Point(255, 32);
            this.Electro_Button.Name = "Electro_Button";
            this.Electro_Button.Size = new System.Drawing.Size(91, 35);
            this.Electro_Button.TabIndex = 46;
            this.Electro_Button.Text = "Toggle Electrolysis";
            this.Electro_Button.UseVisualStyleBackColor = false;
            this.Electro_Button.Click += new System.EventHandler(this.Electro_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(253, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Status:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // electro_label
            // 
            this.electro_label.AutoSize = true;
            this.electro_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.electro_label.Location = new System.Drawing.Point(300, 88);
            this.electro_label.Name = "electro_label";
            this.electro_label.Size = new System.Drawing.Size(13, 13);
            this.electro_label.TabIndex = 44;
            this.electro_label.Text = "--";
            this.electro_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(146, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Status:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // heater_label
            // 
            this.heater_label.AutoSize = true;
            this.heater_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heater_label.Location = new System.Drawing.Point(192, 88);
            this.heater_label.Name = "heater_label";
            this.heater_label.Size = new System.Drawing.Size(13, 13);
            this.heater_label.TabIndex = 42;
            this.heater_label.Text = "--";
            this.heater_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Heater_Button
            // 
            this.Heater_Button.BackColor = System.Drawing.Color.Gainsboro;
            this.Heater_Button.Enabled = false;
            this.Heater_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Heater_Button.Location = new System.Drawing.Point(149, 33);
            this.Heater_Button.Name = "Heater_Button";
            this.Heater_Button.Size = new System.Drawing.Size(89, 35);
            this.Heater_Button.TabIndex = 41;
            this.Heater_Button.Text = "Toggle Heater";
            this.Heater_Button.UseVisualStyleBackColor = false;
            this.Heater_Button.Click += new System.EventHandler(this.Heater_Button_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Status:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // magnet_label
            // 
            this.magnet_label.AutoSize = true;
            this.magnet_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.magnet_label.Location = new System.Drawing.Point(88, 88);
            this.magnet_label.Name = "magnet_label";
            this.magnet_label.Size = new System.Drawing.Size(13, 13);
            this.magnet_label.TabIndex = 39;
            this.magnet_label.Text = "--";
            this.magnet_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Magnet_Button
            // 
            this.Magnet_Button.BackColor = System.Drawing.Color.Gainsboro;
            this.Magnet_Button.Enabled = false;
            this.Magnet_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Magnet_Button.Location = new System.Drawing.Point(42, 33);
            this.Magnet_Button.Name = "Magnet_Button";
            this.Magnet_Button.Size = new System.Drawing.Size(92, 36);
            this.Magnet_Button.TabIndex = 38;
            this.Magnet_Button.Text = "Toggle Magnet";
            this.Magnet_Button.UseVisualStyleBackColor = false;
            this.Magnet_Button.Click += new System.EventHandler(this.Magnet_Button_Click);
            // 
            // Stop_Button
            // 
            this.Stop_Button.BackColor = System.Drawing.Color.Firebrick;
            this.Stop_Button.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stop_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Stop_Button.Location = new System.Drawing.Point(308, 411);
            this.Stop_Button.Name = "Stop_Button";
            this.Stop_Button.Size = new System.Drawing.Size(386, 52);
            this.Stop_Button.TabIndex = 29;
            this.Stop_Button.Text = "Emergency Stop";
            this.Stop_Button.UseVisualStyleBackColor = false;
            this.Stop_Button.Click += new System.EventHandler(this.Stop_Button_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label51);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label52);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.light_text);
            this.groupBox3.Controls.Add(this.temp_text);
            this.groupBox3.Controls.Add(this.GetLight_Button);
            this.groupBox3.Controls.Add(this.GetTemp_Button);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(30, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 135);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sensor Data";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(190, 96);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(15, 13);
            this.label51.TabIndex = 45;
            this.label51.Text = "%";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "deg C";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(146, 76);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(74, 13);
            this.label52.TabIndex = 44;
            this.label52.Text = "Light Level:";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Reaction Temp:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // light_text
            // 
            this.light_text.AutoSize = true;
            this.light_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.light_text.Location = new System.Drawing.Point(157, 96);
            this.light_text.Name = "light_text";
            this.light_text.Size = new System.Drawing.Size(34, 13);
            this.light_text.TabIndex = 43;
            this.light_text.Text = "---------";
            this.light_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // temp_text
            // 
            this.temp_text.AutoSize = true;
            this.temp_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temp_text.Location = new System.Drawing.Point(37, 96);
            this.temp_text.Name = "temp_text";
            this.temp_text.Size = new System.Drawing.Size(37, 13);
            this.temp_text.TabIndex = 26;
            this.temp_text.Text = "----------";
            this.temp_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GetLight_Button
            // 
            this.GetLight_Button.BackColor = System.Drawing.Color.Transparent;
            this.GetLight_Button.Enabled = false;
            this.GetLight_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GetLight_Button.Location = new System.Drawing.Point(132, 37);
            this.GetLight_Button.Name = "GetLight_Button";
            this.GetLight_Button.Size = new System.Drawing.Size(114, 30);
            this.GetLight_Button.TabIndex = 42;
            this.GetLight_Button.Text = "Get Light Level";
            this.GetLight_Button.UseVisualStyleBackColor = false;
            this.GetLight_Button.Click += new System.EventHandler(this.GetLight_Button_Click);
            // 
            // GetTemp_Button
            // 
            this.GetTemp_Button.BackColor = System.Drawing.Color.Transparent;
            this.GetTemp_Button.Enabled = false;
            this.GetTemp_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GetTemp_Button.Location = new System.Drawing.Point(13, 37);
            this.GetTemp_Button.Name = "GetTemp_Button";
            this.GetTemp_Button.Size = new System.Drawing.Size(111, 30);
            this.GetTemp_Button.TabIndex = 24;
            this.GetTemp_Button.Text = "Get Temperature";
            this.GetTemp_Button.UseVisualStyleBackColor = false;
            this.GetTemp_Button.Click += new System.EventHandler(this.GetTemp_Button_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Gainsboro;
            this.button11.Enabled = false;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button11.Location = new System.Drawing.Point(30, 411);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(124, 52);
            this.button11.TabIndex = 31;
            this.button11.Text = "Log to File";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Gainsboro;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button12.Location = new System.Drawing.Point(162, 411);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(124, 52);
            this.button12.TabIndex = 32;
            this.button12.Text = "Settings";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // GS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(8)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(731, 512);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Stop_Button);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.settings_button);
            this.Controls.Add(this.rover_group_ctrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title_label);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GS";
            this.Text = "[Electra] Test Application for ISRU Arduino Commands";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.rover_group_ctrl.ResumeLayout(false);
            this.rover_group_ctrl.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Title_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox rover_group_ctrl;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Red_Button;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label red_label;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Connect_Button;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label status_text;
        private System.Windows.Forms.Button Yellow_Button;
        private System.Windows.Forms.Button Green_Button;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label green_label;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label yellow_label;
        private System.Windows.Forms.Button Disconnect_Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Stop_Button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label temp_text;
        private System.Windows.Forms.Button GetTemp_Button;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label light_text;
        private System.Windows.Forms.Button GetLight_Button;
        private System.Windows.Forms.Button Electro_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label electro_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label heater_label;
        private System.Windows.Forms.Button Heater_Button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label magnet_label;
        private System.Windows.Forms.Button Magnet_Button;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
    }
}

