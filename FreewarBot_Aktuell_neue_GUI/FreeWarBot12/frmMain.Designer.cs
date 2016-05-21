using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
namespace FreeWarBot12
{
    partial class frmMain
    {
         // Set up the delays for the ToolTip.
            
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 


        protected override void Dispose(bool disposing)
        {
            StreamWriter myFile = new StreamWriter(Application.StartupPath + "\\Settings.bin");
            myFile.WriteLine(Settings._Username);
            myFile.WriteLine(StringCipher.Encrypt(Settings._Password, "Fail22"));
            myFile.WriteLine(Settings._World);
            myFile.WriteLine(Settings.LastOilPickUp);
            myFile.WriteLine(Settings.LastFederationPickUp);
            myFile.WriteLine(Settings.LastSumpfgasPickUp);
            myFile.Close();

            StreamWriter myFile1 = new StreamWriter(Application.StartupPath + "\\SettingsMain.bin");
            myFile1.WriteLine(checkBox1.Checked.ToString());
            myFile1.WriteLine(checkBox2.Checked.ToString());
            myFile1.WriteLine(checkBox3.Checked.ToString());
            myFile1.WriteLine(checkBox4.Checked.ToString());
            myFile1.WriteLine(checkBox5.Checked.ToString());
            myFile1.WriteLine(checkBox6.Checked.ToString());
            myFile1.WriteLine(checkBox7.Checked.ToString());
            myFile1.WriteLine(Settings.PickUpOil);
            myFile1.WriteLine(Settings.PickUpSumpfgas);
            myFile1.WriteLine(checkBox10.Checked.ToString());
            myFile1.WriteLine(Settings.PickUpFederation);
            myFile1.WriteLine(checkBox12.Checked.ToString());
            myFile1.WriteLine(checkBox13.Checked.ToString());
            myFile1.WriteLine(comboBox1.Text);
            myFile1.WriteLine(comboBox2.Text);
            myFile1.WriteLine(comboBox3.Text);
            myFile1.WriteLine(comboBox4.Text);
            myFile1.WriteLine(comboBox5.Text);
            myFile1.WriteLine(comboBox6.Text);
            myFile1.WriteLine(comboBox7.Text);
            myFile1.WriteLine(textBox3.Text);
            myFile1.WriteLine(textBox4.Text);
            myFile1.WriteLine(cÜberweisen.Checked.ToString());
            myFile1.WriteLine(checkBoxShop.Checked.ToString());
            myFile1.WriteLine(CaptchaCracker.Checked.ToString());
            myFile1.Close();
            try
            {
                Process[] proc = Process.GetProcessesByName("FreeWarBot12.exe");
                proc[0].Kill();
            }
            catch { }
            System.Environment.Exit(0);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.WBTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.mynotifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.ambiance_ThemeContainer1 = new Ambiance_ThemeContainer();
            this.iTalk_Button_23 = new iTalk.iTalk_Button_2();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.iTalk_ControlBox1 = new iTalk.iTalk_ControlBox();
            this.iTalk_Button_22 = new iTalk.iTalk_Button_2();
            this.iTalk_TabControl1 = new iTalk.iTalk_TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.iTalk_Panel4 = new iTalk.iTalk_Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ambiance_Label4 = new Ambiance_Label();
            this.ambiance_Label3 = new Ambiance_Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cÜberweisen = new CheckBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.iTalk_Panel3 = new iTalk.iTalk_Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox5 = new CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ambiance_Label2 = new Ambiance_Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.iTalk_Panel2 = new iTalk.iTalk_Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.checkBoxShop = new CheckBox();
            this.iTalk_Panel1 = new iTalk.iTalk_Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.checkBox17 = new CheckBox();
            this.ambiance_Label5 = new Ambiance_Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox6 = new CheckBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox27 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.ambiance_Label6 = new Ambiance_Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.checkBox16 = new CheckBox();
            this.checkBox8 = new CheckBox();
            this.checkBox9 = new CheckBox();
            this.checkBox11 = new CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.ambiance_Label1 = new Ambiance_Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel12 = new System.Windows.Forms.Panel();
            this.checkBox12 = new CheckBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.checkBox15 = new CheckBox();
            this.checkBox13 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.checkBox1 = new CheckBox();
            this.checkBox3 = new CheckBox();
            this.checkBox4 = new CheckBox();
            this.checkBox10 = new CheckBox();
            this.checkBox7 = new CheckBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ambiance_Label8 = new Ambiance_Label();
            this.ambiance_Label7 = new Ambiance_Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox31 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.CaptchaCracker = new CheckBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.pictureBox25 = new System.Windows.Forms.PictureBox();
            this.webBrowser5 = new System.Windows.Forms.WebBrowser();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.webBrowser4 = new System.Windows.Forms.WebBrowser();
            this.webBrowser3 = new System.Windows.Forms.WebBrowser();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.iTalk_Button_21 = new iTalk.iTalk_Button_2();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.button2 = new Button();
            this.button7 = new Button();
            this.button5 = new Button();
            this.button8 = new Button();
            this.button6 = new Button();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox14 = new CheckBox();
            this.button4 = new Button();
            this.iTalk_ProgressBar1 = new iTalk.iTalk_ProgressBar();
            this.button1 = new Button();
            this.button9 = new Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.iTalk_Button_24 = new iTalk.iTalk_Button_2();
            this.ambiance_ThemeContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            this.iTalk_TabControl1.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.iTalk_Panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.iTalk_Panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.iTalk_Panel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.iTalk_Panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).BeginInit();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            this.tabPage10.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 540000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // timer3
            // 
            this.timer3.Interval = 500000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 500000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // WBTimer
            // 
            this.WBTimer.Interval = 3000;
            this.WBTimer.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // toolTip2
            // 
            this.toolTip2.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip2_Popup);
            // 
            // mynotifyicon
            // 
            this.mynotifyicon.Icon = ((System.Drawing.Icon)(resources.GetObject("mynotifyicon.Icon")));
            this.mynotifyicon.Text = "BaW Freewar Bot";
            this.mynotifyicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mynotifyicon_MouseDoubleClick);
            // 
            // timer5
            // 
            this.timer5.Interval = 60000;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick_1);
            // 
            // ambiance_ThemeContainer1
            // 
            this.ambiance_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.ambiance_ThemeContainer1.Controls.Add(this.iTalk_Button_24);
            this.ambiance_ThemeContainer1.Controls.Add(this.iTalk_Button_23);
            this.ambiance_ThemeContainer1.Controls.Add(this.pictureBox26);
            this.ambiance_ThemeContainer1.Controls.Add(this.iTalk_ControlBox1);
            this.ambiance_ThemeContainer1.Controls.Add(this.iTalk_Button_22);
            this.ambiance_ThemeContainer1.Controls.Add(this.iTalk_TabControl1);
            this.ambiance_ThemeContainer1.Controls.Add(this.iTalk_ProgressBar1);
            this.ambiance_ThemeContainer1.Controls.Add(this.button1);
            this.ambiance_ThemeContainer1.Controls.Add(this.button9);
            this.ambiance_ThemeContainer1.Controls.Add(this.groupBox1);
            this.ambiance_ThemeContainer1.Controls.Add(this.label11);
            this.ambiance_ThemeContainer1.Controls.Add(this.button3);
            this.ambiance_ThemeContainer1.Controls.Add(this.pictureBox1);
            this.ambiance_ThemeContainer1.Controls.Add(this.groupBox4);
            this.ambiance_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ambiance_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ambiance_ThemeContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.ambiance_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.ambiance_ThemeContainer1.MinimumSize = new System.Drawing.Size(126, 39);
            this.ambiance_ThemeContainer1.Name = "ambiance_ThemeContainer1";
            this.ambiance_ThemeContainer1.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.ambiance_ThemeContainer1.RoundCorners = true;
            this.ambiance_ThemeContainer1.Sizable = true;
            this.ambiance_ThemeContainer1.Size = new System.Drawing.Size(1053, 623);
            this.ambiance_ThemeContainer1.SmartBounds = true;
            this.ambiance_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.ambiance_ThemeContainer1.TabIndex = 82;
            this.ambiance_ThemeContainer1.Text = "Bot aller Wesen - Freewar Bot";
            this.ambiance_ThemeContainer1.Click += new System.EventHandler(this.ambiance_ThemeContainer1_Click);
            // 
            // iTalk_Button_23
            // 
            this.iTalk_Button_23.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_23.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Button_23.ForeColor = System.Drawing.Color.White;
            this.iTalk_Button_23.Image = null;
            this.iTalk_Button_23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_23.Location = new System.Drawing.Point(909, 200);
            this.iTalk_Button_23.Name = "iTalk_Button_23";
            this.iTalk_Button_23.Size = new System.Drawing.Size(121, 23);
            this.iTalk_Button_23.TabIndex = 87;
            this.iTalk_Button_23.Text = "Forum";
            this.iTalk_Button_23.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_23.Click += new System.EventHandler(this.iTalk_Button_23_Click);
            // 
            // pictureBox26
            // 
            this.pictureBox26.Image = global::FreeWarBot12.Properties.Resources.free_user;
            this.pictureBox26.Location = new System.Drawing.Point(12, 183);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(142, 36);
            this.pictureBox26.TabIndex = 86;
            this.pictureBox26.TabStop = false;
            // 
            // iTalk_ControlBox1
            // 
            this.iTalk_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ControlBox1.Location = new System.Drawing.Point(972, -1);
            this.iTalk_ControlBox1.Name = "iTalk_ControlBox1";
            this.iTalk_ControlBox1.Size = new System.Drawing.Size(77, 19);
            this.iTalk_ControlBox1.TabIndex = 85;
            this.iTalk_ControlBox1.Text = "iTalk_ControlBox1";
            this.iTalk_ControlBox1.Click += new System.EventHandler(this.iTalk_ControlBox1_Click);
            // 
            // iTalk_Button_22
            // 
            this.iTalk_Button_22.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_22.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Button_22.ForeColor = System.Drawing.Color.White;
            this.iTalk_Button_22.Image = null;
            this.iTalk_Button_22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_22.Location = new System.Drawing.Point(712, 56);
            this.iTalk_Button_22.Name = "iTalk_Button_22";
            this.iTalk_Button_22.Size = new System.Drawing.Size(126, 31);
            this.iTalk_Button_22.TabIndex = 65;
            this.iTalk_Button_22.Text = "Stop";
            this.iTalk_Button_22.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_22.Click += new System.EventHandler(this.iTalk_Button_22_Click);
            // 
            // iTalk_TabControl1
            // 
            this.iTalk_TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.iTalk_TabControl1.Controls.Add(this.tabPage8);
            this.iTalk_TabControl1.Controls.Add(this.tabPage4);
            this.iTalk_TabControl1.Controls.Add(this.tabPage13);
            this.iTalk_TabControl1.Controls.Add(this.tabPage11);
            this.iTalk_TabControl1.Controls.Add(this.tabPage10);
            this.iTalk_TabControl1.Controls.Add(this.tabPage12);
            this.iTalk_TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.iTalk_TabControl1.ItemSize = new System.Drawing.Size(44, 135);
            this.iTalk_TabControl1.Location = new System.Drawing.Point(12, 225);
            this.iTalk_TabControl1.Multiline = true;
            this.iTalk_TabControl1.Name = "iTalk_TabControl1";
            this.iTalk_TabControl1.SelectedIndex = 0;
            this.iTalk_TabControl1.Size = new System.Drawing.Size(1028, 381);
            this.iTalk_TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.iTalk_TabControl1.TabIndex = 84;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage8.Controls.Add(this.iTalk_Panel4);
            this.tabPage8.Controls.Add(this.iTalk_Panel3);
            this.tabPage8.Controls.Add(this.iTalk_Panel2);
            this.tabPage8.Controls.Add(this.iTalk_Panel1);
            this.tabPage8.Controls.Add(this.pictureBox18);
            this.tabPage8.Controls.Add(this.panel1);
            this.tabPage8.Controls.Add(this.pictureBox23);
            this.tabPage8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage8.Location = new System.Drawing.Point(139, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(885, 373);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Allgemein";
            // 
            // iTalk_Panel4
            // 
            this.iTalk_Panel4.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Panel4.Controls.Add(this.groupBox2);
            this.iTalk_Panel4.Location = new System.Drawing.Point(516, 148);
            this.iTalk_Panel4.Name = "iTalk_Panel4";
            this.iTalk_Panel4.Padding = new System.Windows.Forms.Padding(5);
            this.iTalk_Panel4.Size = new System.Drawing.Size(337, 211);
            this.iTalk_Panel4.TabIndex = 111;
            this.iTalk_Panel4.Text = "iTalk_Panel4";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.ambiance_Label4);
            this.groupBox2.Controls.Add(this.ambiance_Label3);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cÜberweisen);
            this.groupBox2.Controls.Add(this.comboBox5);
            this.groupBox2.Location = new System.Drawing.Point(45, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 108);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(125, 70);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(122, 22);
            this.textBox4.TabIndex = 53;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // ambiance_Label4
            // 
            this.ambiance_Label4.AutoSize = true;
            this.ambiance_Label4.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ambiance_Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_Label4.Location = new System.Drawing.Point(7, 70);
            this.ambiance_Label4.Name = "ambiance_Label4";
            this.ambiance_Label4.Size = new System.Drawing.Size(112, 19);
            this.ambiance_Label4.TabIndex = 42;
            this.ambiance_Label4.Text = "Empfängername:";
            // 
            // ambiance_Label3
            // 
            this.ambiance_Label3.AutoSize = true;
            this.ambiance_Label3.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ambiance_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_Label3.Location = new System.Drawing.Point(7, 30);
            this.ambiance_Label3.Name = "ambiance_Label3";
            this.ambiance_Label3.Size = new System.Drawing.Size(83, 19);
            this.ambiance_Label3.TabIndex = 41;
            this.ambiance_Label3.Text = "Kontostand:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 40;
            // 
            // cÜberweisen
            // 
            this.cÜberweisen.BackColor = System.Drawing.Color.Transparent;
            this.cÜberweisen.Checked = false;
            this.cÜberweisen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cÜberweisen.Location = new System.Drawing.Point(6, 6);
            this.cÜberweisen.Name = "cÜberweisen";
            this.cÜberweisen.Size = new System.Drawing.Size(136, 15);
            this.cÜberweisen.TabIndex = 36;
            this.cÜberweisen.Text = "Überweisen";
            this.cÜberweisen.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox8_CheckedChanged_2);
            // 
            // comboBox5
            // 
            this.comboBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "500",
            "1000",
            "3000",
            "5000",
            "7000",
            "10000",
            "20000",
            "30000",
            "40000",
            "50000",
            "100000"});
            this.comboBox5.Location = new System.Drawing.Point(125, 30);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(122, 21);
            this.comboBox5.TabIndex = 37;
            this.comboBox5.Text = "10000";
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // iTalk_Panel3
            // 
            this.iTalk_Panel3.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Panel3.Controls.Add(this.panel5);
            this.iTalk_Panel3.Controls.Add(this.panel6);
            this.iTalk_Panel3.Location = new System.Drawing.Point(318, 148);
            this.iTalk_Panel3.Name = "iTalk_Panel3";
            this.iTalk_Panel3.Padding = new System.Windows.Forms.Padding(5);
            this.iTalk_Panel3.Size = new System.Drawing.Size(187, 211);
            this.iTalk_Panel3.TabIndex = 110;
            this.iTalk_Panel3.Text = "iTalk_Panel3";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.Controls.Add(this.textBox3);
            this.panel5.Controls.Add(this.checkBox5);
            this.panel5.Location = new System.Drawing.Point(25, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(140, 45);
            this.panel5.TabIndex = 58;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(3, 19);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(122, 22);
            this.textBox3.TabIndex = 52;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.BackColor = System.Drawing.Color.Transparent;
            this.checkBox5.Checked = false;
            this.checkBox5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox5.Location = new System.Drawing.Point(3, 3);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(106, 15);
            this.checkBox5.TabIndex = 51;
            this.checkBox5.Text = "AutoChara";
            this.checkBox5.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox5_CheckedChanged_1);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.ambiance_Label2);
            this.panel6.Controls.Add(this.comboBox2);
            this.panel6.Location = new System.Drawing.Point(25, 74);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(140, 64);
            this.panel6.TabIndex = 59;
            // 
            // ambiance_Label2
            // 
            this.ambiance_Label2.AutoSize = true;
            this.ambiance_Label2.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ambiance_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_Label2.Location = new System.Drawing.Point(6, 4);
            this.ambiance_Label2.Name = "ambiance_Label2";
            this.ambiance_Label2.Size = new System.Drawing.Size(113, 19);
            this.ambiance_Label2.TabIndex = 32;
            this.ambiance_Label2.Text = "Geld zur Bank ab";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000",
            "1500",
            "2000",
            "3000",
            "4000",
            "5000",
            "6000",
            "7000",
            "8000",
            "9000",
            "10000",
            "15000",
            "20000",
            "100000",
            "1000000"});
            this.comboBox2.Location = new System.Drawing.Point(10, 29);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 31;
            this.comboBox2.Text = "2000";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // iTalk_Panel2
            // 
            this.iTalk_Panel2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Panel2.Controls.Add(this.panel2);
            this.iTalk_Panel2.Location = new System.Drawing.Point(32, 148);
            this.iTalk_Panel2.Name = "iTalk_Panel2";
            this.iTalk_Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.iTalk_Panel2.Size = new System.Drawing.Size(269, 97);
            this.iTalk_Panel2.TabIndex = 109;
            this.iTalk_Panel2.Text = "iTalk_Panel2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.checkBoxShop);
            this.panel2.Location = new System.Drawing.Point(10, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 52);
            this.panel2.TabIndex = 50;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.White;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "[87/97] Das Felsendorf - Felsenshop",
            "[79/110] Plefir - Haus der Pilze",
            "[86/85] Buran - Der Shop",
            "[84/112] Loranien - Ein weißes Haus",
            "[71/90] Sutranien - Die Feuerstelle",
            "[114/114] Orewu - Der Salzshop",
            "[101/116] Mentoran - Das Nomadendorf",
            "[90/115] Kerdis - Der knorrige Baum",
            "[97/101] Konlir - Das Dorf Konlir",
            "[501/54] Narubia - Haus der Finsternis",
            "[106/95] Ferdolien - Der Blumenpavillon",
            "[77/101] Gobos - Die rote Hütte",
            "Random"});
            this.comboBox3.Location = new System.Drawing.Point(3, 22);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(237, 21);
            this.comboBox3.TabIndex = 50;
            this.comboBox3.Text = "[87/97] Das Felsendorf - Felsenshop";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged_1);
            // 
            // checkBoxShop
            // 
            this.checkBoxShop.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxShop.Checked = false;
            this.checkBoxShop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxShop.Location = new System.Drawing.Point(3, 3);
            this.checkBoxShop.Name = "checkBoxShop";
            this.checkBoxShop.Size = new System.Drawing.Size(155, 15);
            this.checkBoxShop.TabIndex = 49;
            this.checkBoxShop.Text = "Shop bevorzugen";
            this.checkBoxShop.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBoxShop_CheckedChanged_1);
            // 
            // iTalk_Panel1
            // 
            this.iTalk_Panel1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Panel1.Controls.Add(this.panel7);
            this.iTalk_Panel1.Controls.Add(this.panel3);
            this.iTalk_Panel1.Location = new System.Drawing.Point(32, 259);
            this.iTalk_Panel1.Name = "iTalk_Panel1";
            this.iTalk_Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.iTalk_Panel1.Size = new System.Drawing.Size(269, 100);
            this.iTalk_Panel1.TabIndex = 108;
            this.iTalk_Panel1.Text = "iTalk_Panel1";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel7.Controls.Add(this.checkBox17);
            this.panel7.Controls.Add(this.ambiance_Label5);
            this.panel7.Controls.Add(this.comboBox1);
            this.panel7.Location = new System.Drawing.Point(7, 13);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(133, 75);
            this.panel7.TabIndex = 60;
            // 
            // checkBox17
            // 
            this.checkBox17.BackColor = System.Drawing.Color.Transparent;
            this.checkBox17.Checked = false;
            this.checkBox17.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox17.Location = new System.Drawing.Point(7, 55);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(96, 15);
            this.checkBox17.TabIndex = 61;
            this.checkBox17.Text = "Diebeshöhle";
            this.checkBox17.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox17_CheckedChanged_1);
            // 
            // ambiance_Label5
            // 
            this.ambiance_Label5.AutoSize = true;
            this.ambiance_Label5.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ambiance_Label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_Label5.Location = new System.Drawing.Point(3, 4);
            this.ambiance_Label5.Name = "ambiance_Label5";
            this.ambiance_Label5.Size = new System.Drawing.Size(75, 19);
            this.ambiance_Label5.TabIndex = 54;
            this.ambiance_Label5.Text = "Jagdgebiet";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Random"});
            this.comboBox1.Location = new System.Drawing.Point(6, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 60;
            this.comboBox1.Text = "Random";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_2);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.checkBox6);
            this.panel3.Controls.Add(this.comboBox4);
            this.panel3.Location = new System.Drawing.Point(146, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 57);
            this.panel3.TabIndex = 56;
            // 
            // checkBox6
            // 
            this.checkBox6.BackColor = System.Drawing.Color.Transparent;
            this.checkBox6.Checked = false;
            this.checkBox6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox6.Location = new System.Drawing.Point(3, 3);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(101, 15);
            this.checkBox6.TabIndex = 25;
            this.checkBox6.Text = "Change area";
            this.checkBox6.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox6_CheckedChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100"});
            this.comboBox4.Location = new System.Drawing.Point(15, 21);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(56, 21);
            this.comboBox4.TabIndex = 35;
            this.comboBox4.Text = "30";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // pictureBox18
            // 
            this.pictureBox18.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox18.Image")));
            this.pictureBox18.Location = new System.Drawing.Point(6, 3);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(20, 367);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox18.TabIndex = 107;
            this.pictureBox18.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.pictureBox13);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox27);
            this.panel1.Controls.Add(this.pictureBox19);
            this.panel1.Controls.Add(this.pictureBox11);
            this.panel1.Controls.Add(this.pictureBox10);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.pictureBox12);
            this.panel1.Controls.Add(this.pictureBox9);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.ambiance_Label6);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.checkBox16);
            this.panel1.Controls.Add(this.checkBox8);
            this.panel1.Controls.Add(this.checkBox9);
            this.panel1.Controls.Add(this.checkBox11);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.checkBox15);
            this.panel1.Controls.Add(this.checkBox13);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox10);
            this.panel1.Controls.Add(this.checkBox7);
            this.panel1.Location = new System.Drawing.Point(32, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 136);
            this.panel1.TabIndex = 49;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(439, 100);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(24, 24);
            this.pictureBox13.TabIndex = 121;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(439, 66);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.TabIndex = 120;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(439, 36);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.TabIndex = 119;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox27
            // 
            this.pictureBox27.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox27.Image")));
            this.pictureBox27.Location = new System.Drawing.Point(223, 100);
            this.pictureBox27.Name = "pictureBox27";
            this.pictureBox27.Size = new System.Drawing.Size(24, 24);
            this.pictureBox27.TabIndex = 118;
            this.pictureBox27.TabStop = false;
            // 
            // pictureBox19
            // 
            this.pictureBox19.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox19.Image")));
            this.pictureBox19.Location = new System.Drawing.Point(647, 12);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(24, 24);
            this.pictureBox19.TabIndex = 117;
            this.pictureBox19.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(439, 6);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(24, 24);
            this.pictureBox11.TabIndex = 116;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(223, 66);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(24, 24);
            this.pictureBox10.TabIndex = 115;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(222, 36);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(24, 24);
            this.pictureBox8.TabIndex = 114;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(222, 6);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(24, 24);
            this.pictureBox12.TabIndex = 113;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(18, 100);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(24, 24);
            this.pictureBox9.TabIndex = 112;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(18, 66);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(24, 24);
            this.pictureBox7.TabIndex = 111;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(18, 36);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.TabIndex = 110;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(18, 6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 24);
            this.pictureBox5.TabIndex = 109;
            this.pictureBox5.TabStop = false;
            // 
            // ambiance_Label6
            // 
            this.ambiance_Label6.AutoSize = true;
            this.ambiance_Label6.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ambiance_Label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_Label6.Location = new System.Drawing.Point(620, 94);
            this.ambiance_Label6.Name = "ambiance_Label6";
            this.ambiance_Label6.Size = new System.Drawing.Size(147, 19);
            this.ambiance_Label6.TabIndex = 108;
            this.ambiance_Label6.Text = "Lager leeren (Stunden)";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(773, 90);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(34, 22);
            this.textBox5.TabIndex = 107;
            this.textBox5.Text = "24";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // checkBox16
            // 
            this.checkBox16.BackColor = System.Drawing.Color.Transparent;
            this.checkBox16.Checked = false;
            this.checkBox16.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox16.Location = new System.Drawing.Point(253, 104);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(116, 15);
            this.checkBox16.TabIndex = 105;
            this.checkBox16.Text = "AutoHarvest";
            this.checkBox16.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox16_CheckedChanged_1);
            // 
            // checkBox8
            // 
            this.checkBox8.BackColor = System.Drawing.Color.Transparent;
            this.checkBox8.Checked = false;
            this.checkBox8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox8.Location = new System.Drawing.Point(469, 104);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(155, 15);
            this.checkBox8.TabIndex = 77;
            this.checkBox8.Text = "Öl abholen";
            this.checkBox8.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox8_CheckedChanged_3);
            // 
            // checkBox9
            // 
            this.checkBox9.BackColor = System.Drawing.Color.Transparent;
            this.checkBox9.Checked = false;
            this.checkBox9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox9.Location = new System.Drawing.Point(469, 71);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(155, 15);
            this.checkBox9.TabIndex = 78;
            this.checkBox9.Text = "Sumpfgas abholen";
            this.checkBox9.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox9_CheckedChanged_2);
            // 
            // checkBox11
            // 
            this.checkBox11.BackColor = System.Drawing.Color.Transparent;
            this.checkBox11.Checked = false;
            this.checkBox11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox11.Location = new System.Drawing.Point(469, 40);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(155, 15);
            this.checkBox11.TabIndex = 79;
            this.checkBox11.Text = "Stiftung abholen";
            this.checkBox11.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox11_CheckedChanged_3);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.pictureBox17);
            this.panel4.Controls.Add(this.ambiance_Label1);
            this.panel4.Controls.Add(this.numericUpDown1);
            this.panel4.Location = new System.Drawing.Point(644, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(173, 46);
            this.panel4.TabIndex = 100;
            // 
            // pictureBox17
            // 
            this.pictureBox17.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox17.Image")));
            this.pictureBox17.Location = new System.Drawing.Point(3, 3);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(24, 24);
            this.pictureBox17.TabIndex = 101;
            this.pictureBox17.TabStop = false;
            // 
            // ambiance_Label1
            // 
            this.ambiance_Label1.AutoSize = true;
            this.ambiance_Label1.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ambiance_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_Label1.Location = new System.Drawing.Point(38, 4);
            this.ambiance_Label1.Name = "ambiance_Label1";
            this.ambiance_Label1.Size = new System.Drawing.Size(69, 19);
            this.ambiance_Label1.TabIndex = 100;
            this.ambiance_Label1.Text = "Heilen ab:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.White;
            this.numericUpDown1.Location = new System.Drawing.Point(129, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(34, 22);
            this.numericUpDown1.TabIndex = 33;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel12.Controls.Add(this.checkBox12);
            this.panel12.Controls.Add(this.comboBox7);
            this.panel12.Location = new System.Drawing.Point(677, 7);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(140, 29);
            this.panel12.TabIndex = 66;
            // 
            // checkBox12
            // 
            this.checkBox12.BackColor = System.Drawing.Color.Transparent;
            this.checkBox12.Checked = false;
            this.checkBox12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox12.Location = new System.Drawing.Point(3, 7);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(70, 15);
            this.checkBox12.TabIndex = 25;
            this.checkBox12.Text = "Repair";
            this.checkBox12.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox12_CheckedChanged);
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "1",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "5",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80"});
            this.comboBox7.Location = new System.Drawing.Point(95, 3);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(35, 21);
            this.comboBox7.Sorted = true;
            this.comboBox7.TabIndex = 35;
            this.comboBox7.Text = "80";
            this.comboBox7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
            // 
            // checkBox15
            // 
            this.checkBox15.BackColor = System.Drawing.Color.Transparent;
            this.checkBox15.Checked = false;
            this.checkBox15.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox15.Location = new System.Drawing.Point(48, 71);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(116, 15);
            this.checkBox15.TabIndex = 80;
            this.checkBox15.Text = "AutoChase";
            this.checkBox15.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox15_CheckedChanged);
            // 
            // checkBox13
            // 
            this.checkBox13.BackColor = System.Drawing.Color.Transparent;
            this.checkBox13.Checked = false;
            this.checkBox13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox13.Location = new System.Drawing.Point(469, 10);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(143, 15);
            this.checkBox13.TabIndex = 46;
            this.checkBox13.Text = "Use Protection";
            this.checkBox13.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox13_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Checked = false;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkBox2.Location = new System.Drawing.Point(48, 10);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(116, 15);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "AutoWalk";
            this.checkBox2.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Checked = false;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox1.Location = new System.Drawing.Point(48, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(143, 15);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "AutoKill";
            this.checkBox1.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Checked = false;
            this.checkBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox3.Location = new System.Drawing.Point(48, 104);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(116, 15);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "AutoTake";
            this.checkBox3.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox3_CheckedChanged_1);
            // 
            // checkBox4
            // 
            this.checkBox4.BackColor = System.Drawing.Color.Transparent;
            this.checkBox4.Checked = false;
            this.checkBox4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox4.Location = new System.Drawing.Point(252, 10);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(134, 15);
            this.checkBox4.TabIndex = 15;
            this.checkBox4.Text = "AutoSell";
            this.checkBox4.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.BackColor = System.Drawing.Color.Transparent;
            this.checkBox10.Checked = false;
            this.checkBox10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox10.Location = new System.Drawing.Point(253, 71);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(157, 15);
            this.checkBox10.TabIndex = 45;
            this.checkBox10.Text = "Store Items";
            this.toolTip2.SetToolTip(this.checkBox10, "Wakrudpilze, Pfeile, Seelenkapseln, Geisterfunken werden automatisch eingelagert " +
        "(Pfeilbeutel, Geisterschild, usw.)");
            this.checkBox10.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox10_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.BackColor = System.Drawing.Color.Transparent;
            this.checkBox7.Checked = false;
            this.checkBox7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox7.Location = new System.Drawing.Point(252, 40);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(134, 15);
            this.checkBox7.TabIndex = 27;
            this.checkBox7.Text = "Sell Maha";
            this.checkBox7.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox7_CheckedChanged);
            // 
            // pictureBox23
            // 
            this.pictureBox23.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox23.Image")));
            this.pictureBox23.Location = new System.Drawing.Point(859, 3);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(20, 367);
            this.pictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox23.TabIndex = 106;
            this.pictureBox23.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage4.Controls.Add(this.pictureBox21);
            this.tabPage4.Controls.Add(this.pictureBox20);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.pictureBox14);
            this.tabPage4.Controls.Add(this.pictureBox31);
            this.tabPage4.Controls.Add(this.pictureBox16);
            this.tabPage4.Controls.Add(this.pictureBox15);
            this.tabPage4.Controls.Add(this.pictureBox2);
            this.tabPage4.Controls.Add(this.pictureBoxCaptcha);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(139, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(885, 373);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Captcha";
            // 
            // pictureBox21
            // 
            this.pictureBox21.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox21.Image")));
            this.pictureBox21.Location = new System.Drawing.Point(0, 3);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(927, 38);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox21.TabIndex = 112;
            this.pictureBox21.TabStop = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox20.Image")));
            this.pictureBox20.Location = new System.Drawing.Point(0, 335);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(927, 38);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 111;
            this.pictureBox20.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ambiance_Label8);
            this.groupBox5.Controls.Add(this.ambiance_Label7);
            this.groupBox5.Location = new System.Drawing.Point(18, 213);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(149, 97);
            this.groupBox5.TabIndex = 110;
            this.groupBox5.TabStop = false;
            // 
            // ambiance_Label8
            // 
            this.ambiance_Label8.AutoSize = true;
            this.ambiance_Label8.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_Label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ambiance_Label8.Location = new System.Drawing.Point(6, 17);
            this.ambiance_Label8.Name = "ambiance_Label8";
            this.ambiance_Label8.Size = new System.Drawing.Size(113, 20);
            this.ambiance_Label8.TabIndex = 109;
            this.ambiance_Label8.Text = "Captcha Zähler";
            // 
            // ambiance_Label7
            // 
            this.ambiance_Label7.AutoSize = true;
            this.ambiance_Label7.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label7.Font = new System.Drawing.Font("Segoe UI", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_Label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(169)))), ((int)(((byte)(222)))));
            this.ambiance_Label7.Location = new System.Drawing.Point(56, 43);
            this.ambiance_Label7.Name = "ambiance_Label7";
            this.ambiance_Label7.Size = new System.Drawing.Size(39, 45);
            this.ambiance_Label7.TabIndex = 108;
            this.ambiance_Label7.Text = "0";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
            this.pictureBox14.Location = new System.Drawing.Point(202, 155);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(40, 40);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 107;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox31
            // 
            this.pictureBox31.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox31.Image")));
            this.pictureBox31.Location = new System.Drawing.Point(156, 155);
            this.pictureBox31.Name = "pictureBox31";
            this.pictureBox31.Size = new System.Drawing.Size(40, 40);
            this.pictureBox31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox31.TabIndex = 106;
            this.pictureBox31.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox16.Image")));
            this.pictureBox16.Location = new System.Drawing.Point(110, 155);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(40, 40);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox16.TabIndex = 103;
            this.pictureBox16.TabStop = false;
            this.pictureBox16.Click += new System.EventHandler(this.pictureBox16_Click);
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox15.Image")));
            this.pictureBox15.Location = new System.Drawing.Point(64, 155);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(40, 40);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 102;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(18, 155);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 101;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBoxCaptcha
            // 
            this.pictureBoxCaptcha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCaptcha.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCaptcha.Image")));
            this.pictureBoxCaptcha.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCaptcha.InitialImage")));
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(302, 61);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(554, 249);
            this.pictureBoxCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCaptcha.TabIndex = 80;
            this.pictureBoxCaptcha.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.groupBox3.Controls.Add(this.panel11);
            this.groupBox3.Location = new System.Drawing.Point(6, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 88);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Captcha";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel11.Controls.Add(this.CaptchaCracker);
            this.panel11.Controls.Add(this.comboBox6);
            this.panel11.Location = new System.Drawing.Point(6, 19);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(238, 54);
            this.panel11.TabIndex = 63;
            // 
            // CaptchaCracker
            // 
            this.CaptchaCracker.BackColor = System.Drawing.Color.Transparent;
            this.CaptchaCracker.Checked = false;
            this.CaptchaCracker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CaptchaCracker.Location = new System.Drawing.Point(3, 3);
            this.CaptchaCracker.Name = "CaptchaCracker";
            this.CaptchaCracker.Size = new System.Drawing.Size(138, 15);
            this.CaptchaCracker.TabIndex = 46;
            this.CaptchaCracker.Text = "CaptchaCracker";
            this.CaptchaCracker.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox11_CheckedChanged_2);
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "[96/99] Die Goldmine",
            "[89/93] Hewien - Der Steinbruch",
            "[100/104] Nawor - Gold sieben",
            "[100/105] Nawor - Gold sieben",
            "[101/105] Nawor - Gold sieben",
            "[102/105] Nawor - Gold sieben",
            "[100/106] Nawor - Gold sieben",
            "[101/106] Nawor - Gold sieben",
            "[102/106] Nawor - Gold sieben",
            "[103/106] Nawor - Gold sieben",
            "[75/116] Loranien - Holz hacken",
            "[75/115] Loranien - Holz hacken",
            "[76/115] Loranien - Holz hacken",
            "[76/116] Loranien - Holz hacken",
            "[79/116] Loranien - Zauberkugel",
            "[80/116] Loranien - Zauberkugel",
            "[81/116] Loranien - Zauberkugel",
            "[82/116] Loranien - Zauberkugel",
            "[83/116] Loranien - Zauberkugel",
            "[84/116] Loranien - Zauberkugel",
            "[85/116] Loranien - Zauberkugel",
            "[-1297/-1397] Reines Ingerium",
            "[-1296/-1397] Unreines Ingerium"});
            this.comboBox6.Location = new System.Drawing.Point(3, 20);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(232, 23);
            this.comboBox6.TabIndex = 46;
            this.comboBox6.Text = "[96/99] Die Goldmine";
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // tabPage13
            // 
            this.tabPage13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage13.Controls.Add(this.pictureBox25);
            this.tabPage13.Controls.Add(this.webBrowser5);
            this.tabPage13.Controls.Add(this.webBrowser2);
            this.tabPage13.Controls.Add(this.webBrowser4);
            this.tabPage13.Controls.Add(this.webBrowser3);
            this.tabPage13.Location = new System.Drawing.Point(139, 4);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(885, 373);
            this.tabPage13.TabIndex = 5;
            this.tabPage13.Text = "Überwachen";
            // 
            // pictureBox25
            // 
            this.pictureBox25.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox25.Image")));
            this.pictureBox25.Location = new System.Drawing.Point(687, -4);
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.Size = new System.Drawing.Size(20, 204);
            this.pictureBox25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox25.TabIndex = 109;
            this.pictureBox25.TabStop = false;
            // 
            // webBrowser5
            // 
            this.webBrowser5.Location = new System.Drawing.Point(5, 348);
            this.webBrowser5.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser5.Name = "webBrowser5";
            this.webBrowser5.ScriptErrorsSuppressed = true;
            this.webBrowser5.Size = new System.Drawing.Size(872, 27);
            this.webBrowser5.TabIndex = 3;
            this.webBrowser5.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser5_DocumentCompleted);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(711, 6);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(166, 194);
            this.webBrowser2.TabIndex = 108;
            this.webBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted_1);
            // 
            // webBrowser4
            // 
            this.webBrowser4.Location = new System.Drawing.Point(8, 206);
            this.webBrowser4.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser4.Name = "webBrowser4";
            this.webBrowser4.ScriptErrorsSuppressed = true;
            this.webBrowser4.Size = new System.Drawing.Size(869, 138);
            this.webBrowser4.TabIndex = 2;
            this.webBrowser4.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser4_DocumentCompleted);
            // 
            // webBrowser3
            // 
            this.webBrowser3.Location = new System.Drawing.Point(8, 6);
            this.webBrowser3.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.ScriptErrorsSuppressed = true;
            this.webBrowser3.Size = new System.Drawing.Size(673, 194);
            this.webBrowser3.TabIndex = 1;
            this.webBrowser3.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser3_DocumentCompleted);
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage11.Controls.Add(this.iTalk_Button_21);
            this.tabPage11.Controls.Add(this.pictureBox24);
            this.tabPage11.Controls.Add(this.pictureBox22);
            this.tabPage11.Controls.Add(this.webBrowser1);
            this.tabPage11.Location = new System.Drawing.Point(139, 4);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(885, 373);
            this.tabPage11.TabIndex = 3;
            this.tabPage11.Text = "BaW Chat";
            // 
            // iTalk_Button_21
            // 
            this.iTalk_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_21.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Button_21.ForeColor = System.Drawing.Color.White;
            this.iTalk_Button_21.Image = null;
            this.iTalk_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_21.Location = new System.Drawing.Point(570, 6);
            this.iTalk_Button_21.Name = "iTalk_Button_21";
            this.iTalk_Button_21.Size = new System.Drawing.Size(166, 21);
            this.iTalk_Button_21.TabIndex = 114;
            this.iTalk_Button_21.Text = "Im Browser öffnen";
            this.iTalk_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_21.Click += new System.EventHandler(this.iTalk_Button_21_Click);
            // 
            // pictureBox24
            // 
            this.pictureBox24.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox24.Image")));
            this.pictureBox24.Location = new System.Drawing.Point(860, -23);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(25, 405);
            this.pictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox24.TabIndex = 113;
            this.pictureBox24.TabStop = false;
            // 
            // pictureBox22
            // 
            this.pictureBox22.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox22.Image")));
            this.pictureBox22.Location = new System.Drawing.Point(0, -23);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(25, 405);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox22.TabIndex = 112;
            this.pictureBox22.TabStop = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(34, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(821, 367);
            this.webBrowser1.TabIndex = 109;
            this.webBrowser1.Url = new System.Uri("http://fwzybot.saveboards.com/chatbox/index.forum", System.UriKind.Absolute);
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage10.Controls.Add(this.button2);
            this.tabPage10.Controls.Add(this.button7);
            this.tabPage10.Controls.Add(this.button5);
            this.tabPage10.Controls.Add(this.button8);
            this.tabPage10.Controls.Add(this.button6);
            this.tabPage10.Location = new System.Drawing.Point(139, 4);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(885, 373);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "Verwaltung";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button2.Image = null;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(3, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Healitems";
            this.button2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button2.Click += new System.EventHandler(this.button2_Click_3);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button7.Image = null;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(3, 111);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(201, 30);
            this.button7.TabIndex = 2;
            this.button7.Text = "Items im Inventar behalten";
            this.button7.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button5.Image = null;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(201, 30);
            this.button5.TabIndex = 0;
            this.button5.Text = "Shopitems";
            this.button5.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button8.Image = null;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(3, 147);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(201, 30);
            this.button8.TabIndex = 3;
            this.button8.Text = "Markthallenitems";
            this.button8.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button6.Image = null;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(3, 39);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(201, 30);
            this.button6.TabIndex = 1;
            this.button6.Text = "Bankitems";
            this.button6.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage12.Controls.Add(this.label5);
            this.tabPage12.Controls.Add(this.checkBox14);
            this.tabPage12.Controls.Add(this.button4);
            this.tabPage12.Location = new System.Drawing.Point(139, 4);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(885, 373);
            this.tabPage12.TabIndex = 4;
            this.tabPage12.Text = "Auftragsbot";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(14, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 83;
            this.label5.Text = "Beta";
            // 
            // checkBox14
            // 
            this.checkBox14.BackColor = System.Drawing.Color.Transparent;
            this.checkBox14.Checked = false;
            this.checkBox14.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkBox14.Location = new System.Drawing.Point(17, 61);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(183, 15);
            this.checkBox14.TabIndex = 80;
            this.checkBox14.Text = "Auftragsbot";
            this.checkBox14.CheckedChanged += new CheckBox.CheckedChangedEventHandler(this.checkBox14_CheckedChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button4.Image = null;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(17, 92);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 23);
            this.button4.TabIndex = 81;
            this.button4.Text = "Aktueller Auftrag";
            this.button4.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // iTalk_ProgressBar1
            // 
            this.iTalk_ProgressBar1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.iTalk_ProgressBar1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.iTalk_ProgressBar1.Location = new System.Drawing.Point(12, 56);
            this.iTalk_ProgressBar1.Maximum = ((long)(100));
            this.iTalk_ProgressBar1.MinimumSize = new System.Drawing.Size(100, 100);
            this.iTalk_ProgressBar1.Name = "iTalk_ProgressBar1";
            this.iTalk_ProgressBar1.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(169)))), ((int)(((byte)(222)))));
            this.iTalk_ProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.iTalk_ProgressBar1.ProgressShape = iTalk.iTalk_ProgressBar._ProgressShape.Flat;
            this.iTalk_ProgressBar1.Size = new System.Drawing.Size(120, 120);
            this.iTalk_ProgressBar1.TabIndex = 83;
            this.iTalk_ProgressBar1.Text = "iTalk_ProgressBar1";
            this.iTalk_ProgressBar1.Value = ((long)(5));
            this.iTalk_ProgressBar1.Click += new System.EventHandler(this.iTalk_ProgressBar1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.Image = null;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(712, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.TabIndex = 81;
            this.button1.Text = "Bot-Fenster anzeigen";
            this.button1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button9.Image = null;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(712, 91);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(190, 23);
            this.button9.TabIndex = 78;
            this.button9.Text = "Fortschritt anzeigen";
            this.button9.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.panel10);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(138, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 124);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel10.Controls.Add(this.label4);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Controls.Add(this.label1);
            this.panel10.ForeColor = System.Drawing.Color.Black;
            this.panel10.Location = new System.Drawing.Point(6, 17);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(163, 99);
            this.panel10.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lebenspunkte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Geld";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Erfahrung";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(-112, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(262, 12);
            this.label14.TabIndex = 77;
            this.label14.Text = "Free Version - viele Funktionen stehen nicht zur Verfügung";
            this.label14.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(908, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 15);
            this.label11.TabIndex = 73;
            this.label11.Text = "©BaW 2016";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button3.Image = null;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(712, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 23);
            this.button3.TabIndex = 75;
            this.button3.Text = "Pfad neu berechnen";
            this.button3.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button3.Click += new System.EventHandler(this.button3_Click_3);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(909, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.listBox2);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(313, 56);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(376, 166);
            this.groupBox4.TabIndex = 65;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Protokoll";
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(3, 14);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(367, 147);
            this.listBox2.TabIndex = 65;
            // 
            // iTalk_Button_24
            // 
            this.iTalk_Button_24.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_24.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iTalk_Button_24.BackgroundImage")));
            this.iTalk_Button_24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iTalk_Button_24.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Button_24.ForeColor = System.Drawing.Color.White;
            this.iTalk_Button_24.Image = ((System.Drawing.Image)(resources.GetObject("iTalk_Button_24.Image")));
            this.iTalk_Button_24.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iTalk_Button_24.Location = new System.Drawing.Point(712, 179);
            this.iTalk_Button_24.Name = "iTalk_Button_24";
            this.iTalk_Button_24.Size = new System.Drawing.Size(83, 43);
            this.iTalk_Button_24.TabIndex = 88;
            this.iTalk_Button_24.TextAlignment = System.Drawing.StringAlignment.Near;
            this.iTalk_Button_24.Click += new System.EventHandler(this.iTalk_Button_24_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1053, 623);
            this.Controls.Add(this.ambiance_ThemeContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "frmMain";
            this.Text = "Bot aller Wesen - Freewar Bot";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ambiance_ThemeContainer1.ResumeLayout(false);
            this.ambiance_ThemeContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            this.iTalk_TabControl1.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.iTalk_Panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.iTalk_Panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.iTalk_Panel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.iTalk_Panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).EndInit();
            this.tabPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

      

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private Timer timer3;
        private Timer timer4;
        private Timer WBTimer;
        private Panel panel10;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private GroupBox groupBox4;
        private Label label11;
        private PictureBox pictureBox1;
        private Button button3;
        private Label label14;
        private Ambiance_ThemeContainer ambiance_ThemeContainer1;
        private Button button9;
        private Button button1;
        private ToolTip toolTip2;
        private NotifyIcon mynotifyicon;
        private Timer timer5;
        private iTalk.iTalk_ProgressBar iTalk_ProgressBar1;
        private iTalk.iTalk_TabControl iTalk_TabControl1;
        private TabPage tabPage8;
        private Panel panel1;
        private PictureBox pictureBox19;
        private PictureBox pictureBox11;
        private PictureBox pictureBox10;
        private PictureBox pictureBox8;
        private PictureBox pictureBox12;
        private PictureBox pictureBox9;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private Ambiance_Label ambiance_Label6;
        private TextBox textBox5;
        private CheckBox checkBox16;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private CheckBox checkBox11;
        private Panel panel4;
        private PictureBox pictureBox17;
        private Ambiance_Label ambiance_Label1;
        private NumericUpDown numericUpDown1;
        private Panel panel12;
        private CheckBox checkBox12;
        private ComboBox comboBox7;
        private CheckBox checkBox15;
        private CheckBox checkBox13;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox10;
        private CheckBox checkBox7;
        private Panel panel2;
        private ComboBox comboBox3;
        private CheckBox checkBoxShop;
        private Panel panel7;
        private CheckBox checkBox17;
        private Ambiance_Label ambiance_Label5;
        private ComboBox comboBox1;
        private Panel panel5;
        private TextBox textBox3;
        private CheckBox checkBox5;
        private Panel panel6;
        private Ambiance_Label ambiance_Label2;
        private ComboBox comboBox2;
        private Panel panel3;
        private CheckBox checkBox6;
        private ComboBox comboBox4;
        private TabPage tabPage4;
        private GroupBox groupBox5;
        private Ambiance_Label ambiance_Label8;
        private Ambiance_Label ambiance_Label7;
        private PictureBox pictureBox14;
        private PictureBox pictureBox31;
        private PictureBox pictureBox16;
        private PictureBox pictureBox15;
        private PictureBox pictureBox2;
        private PictureBox pictureBoxCaptcha;
        private GroupBox groupBox3;
        private Panel panel11;
        private CheckBox CaptchaCracker;
        private ComboBox comboBox6;
        private TabPage tabPage12;
        private Label label5;
        private CheckBox checkBox14;
        private Button button4;
        private TabPage tabPage10;
        private Button button7;
        private Button button5;
        private Button button8;
        private Button button6;
        private TabPage tabPage11;
        private WebBrowser webBrowser1;
        private TabPage tabPage13;
        private WebBrowser webBrowser5;
        private WebBrowser webBrowser2;
        private WebBrowser webBrowser4;
        private WebBrowser webBrowser3;
        private PictureBox pictureBox23;
        private GroupBox groupBox2;
        private TextBox textBox4;
        private Ambiance_Label ambiance_Label4;
        private Ambiance_Label ambiance_Label3;
        private Label label10;
        private CheckBox cÜberweisen;
        private ComboBox comboBox5;
        private PictureBox pictureBox18;
        private PictureBox pictureBox21;
        private PictureBox pictureBox20;
        private PictureBox pictureBox24;
        private PictureBox pictureBox22;
        private PictureBox pictureBox25;
        private iTalk.iTalk_Button_2 iTalk_Button_21;
        private iTalk.iTalk_Button_2 iTalk_Button_22;
        private iTalk.iTalk_ControlBox iTalk_ControlBox1;
        private PictureBox pictureBox26;
        private iTalk.iTalk_Button_2 iTalk_Button_23;
        private ListBox listBox2;
        private PictureBox pictureBox13;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox27;
        private iTalk.iTalk_Panel iTalk_Panel1;
        private iTalk.iTalk_Panel iTalk_Panel4;
        private iTalk.iTalk_Panel iTalk_Panel3;
        private iTalk.iTalk_Panel iTalk_Panel2;
        private Button button2;
        private iTalk.iTalk_Button_2 iTalk_Button_24;
    }
}