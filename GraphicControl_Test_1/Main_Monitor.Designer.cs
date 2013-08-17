namespace Monitor
{
    partial class Assembly_Monitor
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnl_Monitor = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_Comport_Settings = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.button16 = new System.Windows.Forms.Button();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button15 = new System.Windows.Forms.Button();
            this.btn_ZoomOutY = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.btn_ZoomInY = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.btn_ZoomOutX = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.button12 = new System.Windows.Forms.Button();
            this.btn_ZoomInX = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox_Channel4 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox_Channel3 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox_Channel2 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.mediaSlider1 = new MediaSlider.MediaSlider();
            this.button7 = new System.Windows.Forms.Button();
            this.mediaSlider3 = new MediaSlider.MediaSlider();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.btn_ZoomIn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox_X_Value = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.btn_ZoomOut = new System.Windows.Forms.Button();
            this.checkBox_DrawXOriginAxis = new System.Windows.Forms.CheckBox();
            this.textBox_Channel1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Controls = new System.Windows.Forms.Panel();
            this.btn_PickZone = new System.Windows.Forms.Button();
            this.btn_LoadData = new System.Windows.Forms.Button();
            this.btn_SaveBitmap = new System.Windows.Forms.Button();
            this.btn_ZoomAll = new System.Windows.Forms.Button();
            this.btn_BackToOrigin = new System.Windows.Forms.Button();
            this.btn_TraceTicks = new System.Windows.Forms.Button();
            this.btnSampleTest = new System.Windows.Forms.Button();
            this.btn_SerialPort_Open = new System.Windows.Forms.Button();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.btn_DataObserver = new System.Windows.Forms.Button();
            this.btn_SerialPort_Stop = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.pnl_Controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Monitor
            // 
            this.pnl_Monitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_Monitor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_Monitor.BackColor = System.Drawing.Color.Black;
            this.pnl_Monitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_Monitor.Location = new System.Drawing.Point(0, 0);
            this.pnl_Monitor.Name = "pnl_Monitor";
            this.pnl_Monitor.Size = new System.Drawing.Size(1104, 491);
            this.pnl_Monitor.TabIndex = 1;
            this.pnl_Monitor.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pnlCoord_OnMouseWheel);
            this.pnl_Monitor.MouseLeave += new System.EventHandler(this.pnlCoord_OnMouseLeave);
            this.pnl_Monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Monitor_paint);
            this.pnl_Monitor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCoord_OnMouseMove);
            this.pnl_Monitor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCoordOnMouseDown);
            this.pnl_Monitor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlCoordOnMouseUp);
            this.pnl_Monitor.MouseEnter += new System.EventHandler(this.pnlCoord_OnMouseEnter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Comport_Settings});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1270, 22);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_Comport_Settings
            // 
            this.tssl_Comport_Settings.BackColor = System.Drawing.Color.Transparent;
            this.tssl_Comport_Settings.Name = "tssl_Comport_Settings";
            this.tssl_Comport_Settings.Size = new System.Drawing.Size(131, 17);
            this.tssl_Comport_Settings.Text = "toolStripStatusLabel1";
            this.tssl_Comport_Settings.Click += new System.EventHandler(this.tsslComportSetting_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(771, 349);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(70, 21);
            this.textBox5.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(730, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "X 轴";
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.checkBox9.Location = new System.Drawing.Point(750, 174);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(48, 16);
            this.checkBox9.TabIndex = 22;
            this.checkBox9.Text = "X=0 ";
            this.checkBox9.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(771, 325);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(70, 21);
            this.textBox4.TabIndex = 16;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.button18.Location = new System.Drawing.Point(765, 267);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 14;
            this.button18.Text = "Observe X";
            this.button18.UseVisualStyleBackColor = false;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(765, 296);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 25;
            this.button17.Text = "Stop";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.BackColor = System.Drawing.Color.DimGray;
            this.checkBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.checkBox8.Location = new System.Drawing.Point(723, 426);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(42, 16);
            this.checkBox8.TabIndex = 13;
            this.checkBox8.Text = "# 4";
            this.checkBox8.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(765, 238);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 27;
            this.button16.Text = "跟踪X";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.BackColor = System.Drawing.Color.Gray;
            this.checkBox7.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox7.Location = new System.Drawing.Point(724, 402);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(42, 16);
            this.checkBox7.TabIndex = 12;
            this.checkBox7.Text = "# 3";
            this.checkBox7.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(771, 373);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 21);
            this.textBox3.TabIndex = 29;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.Color.Silver;
            this.checkBox6.ForeColor = System.Drawing.Color.Blue;
            this.checkBox6.Location = new System.Drawing.Point(723, 378);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(42, 16);
            this.checkBox6.TabIndex = 11;
            this.checkBox6.Text = "# 2";
            this.checkBox6.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(771, 397);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 21);
            this.textBox2.TabIndex = 30;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(738, 130);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(55, 20);
            this.button15.TabIndex = 9;
            this.button15.Text = "[Y轴] -";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // btn_ZoomOutY
            // 
            this.btn_ZoomOutY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ZoomOutY.Location = new System.Drawing.Point(42, 163);
            this.btn_ZoomOutY.Name = "btn_ZoomOutY";
            this.btn_ZoomOutY.Size = new System.Drawing.Size(71, 20);
            this.btn_ZoomOutY.TabIndex = 9;
            this.btn_ZoomOutY.Text = "[Y轴] -";
            this.btn_ZoomOutY.UseVisualStyleBackColor = true;
            this.btn_ZoomOutY.Click += new System.EventHandler(this.btn_ZoomOutY_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(771, 421);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 21);
            this.textBox1.TabIndex = 32;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(738, 81);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(55, 20);
            this.button14.TabIndex = 8;
            this.button14.Text = "[Y轴] +";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // btn_ZoomInY
            // 
            this.btn_ZoomInY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ZoomInY.Location = new System.Drawing.Point(42, 114);
            this.btn_ZoomInY.Name = "btn_ZoomInY";
            this.btn_ZoomInY.Size = new System.Drawing.Size(71, 20);
            this.btn_ZoomInY.TabIndex = 8;
            this.btn_ZoomInY.Text = "[Y轴] +";
            this.btn_ZoomInY.UseVisualStyleBackColor = true;
            this.btn_ZoomInY.Click += new System.EventHandler(this.btn_ZoomInY_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(710, 107);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(55, 20);
            this.button13.TabIndex = 7;
            this.button13.Text = "[X轴] -";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // btn_ZoomOutX
            // 
            this.btn_ZoomOutX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ZoomOutX.Location = new System.Drawing.Point(5, 137);
            this.btn_ZoomOutX.Name = "btn_ZoomOutX";
            this.btn_ZoomOutX.Size = new System.Drawing.Size(71, 20);
            this.btn_ZoomOutX.TabIndex = 7;
            this.btn_ZoomOutX.Text = "[X轴] -";
            this.btn_ZoomOutX.UseVisualStyleBackColor = true;
            this.btn_ZoomOutX.Click += new System.EventHandler(this.btn_ZoomOutX_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.Color.Silver;
            this.checkBox5.ForeColor = System.Drawing.Color.Blue;
            this.checkBox5.Location = new System.Drawing.Point(724, 354);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(42, 16);
            this.checkBox5.TabIndex = 36;
            this.checkBox5.Text = "# 1";
            this.checkBox5.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(771, 107);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(55, 20);
            this.button12.TabIndex = 6;
            this.button12.Text = "[X轴] +";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // btn_ZoomInX
            // 
            this.btn_ZoomInX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ZoomInX.Location = new System.Drawing.Point(82, 137);
            this.btn_ZoomInX.Name = "btn_ZoomInX";
            this.btn_ZoomInX.Size = new System.Drawing.Size(71, 20);
            this.btn_ZoomInX.TabIndex = 6;
            this.btn_ZoomInX.Text = "[X轴] +";
            this.btn_ZoomInX.UseVisualStyleBackColor = true;
            this.btn_ZoomInX.Click += new System.EventHandler(this.btn_ZoomInX_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(703, 209);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(53, 38);
            this.button11.TabIndex = 38;
            this.button11.Text = "Save Data";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // textBox_Channel4
            // 
            this.textBox_Channel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Channel4.Location = new System.Drawing.Point(84, 428);
            this.textBox_Channel4.Name = "textBox_Channel4";
            this.textBox_Channel4.Size = new System.Drawing.Size(70, 21);
            this.textBox_Channel4.TabIndex = 32;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(724, 17);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 23);
            this.button10.TabIndex = 5;
            this.button10.Text = "[整体] 放大";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // textBox_Channel3
            // 
            this.textBox_Channel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Channel3.Location = new System.Drawing.Point(84, 404);
            this.textBox_Channel3.Name = "textBox_Channel3";
            this.textBox_Channel3.Size = new System.Drawing.Size(70, 21);
            this.textBox_Channel3.TabIndex = 30;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(724, 46);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(87, 23);
            this.button9.TabIndex = 3;
            this.button9.Text = "[整体] 缩小";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // textBox_Channel2
            // 
            this.textBox_Channel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Channel2.Location = new System.Drawing.Point(84, 380);
            this.textBox_Channel2.Name = "textBox_Channel2";
            this.textBox_Channel2.Size = new System.Drawing.Size(70, 21);
            this.textBox_Channel2.TabIndex = 29;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(706, 281);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 38);
            this.button8.TabIndex = 40;
            this.button8.Text = "Sample Test";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // mediaSlider1
            // 
            this.mediaSlider1.Animated = true;
            this.mediaSlider1.AnimationSize = 0.2F;
            this.mediaSlider1.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Fast;
            this.mediaSlider1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.mediaSlider1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.mediaSlider1.AutoSize = true;
            this.mediaSlider1.BackColor = System.Drawing.Color.DarkGray;
            this.mediaSlider1.BackgroundImage = null;
            this.mediaSlider1.ButtonAccentColor = System.Drawing.Color.Yellow;
            this.mediaSlider1.ButtonBorderColor = System.Drawing.Color.IndianRed;
            this.mediaSlider1.ButtonColor = System.Drawing.Color.OrangeRed;
            this.mediaSlider1.ButtonCornerRadius = ((uint)(2u));
            this.mediaSlider1.ButtonSize = new System.Drawing.Size(24, 12);
            this.mediaSlider1.ButtonStyle = MediaSlider.MediaSlider.ButtonType.GlassInline;
            this.mediaSlider1.ContextMenuStrip = null;
            this.mediaSlider1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.mediaSlider1.LargeChange = 2;
            this.mediaSlider1.Location = new System.Drawing.Point(36, 97);
            this.mediaSlider1.Margin = new System.Windows.Forms.Padding(0);
            this.mediaSlider1.Maximum = 10;
            this.mediaSlider1.Minimum = 0;
            this.mediaSlider1.Name = "mediaSlider1";
            this.mediaSlider1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.mediaSlider1.ShowButtonOnHover = false;
            this.mediaSlider1.Size = new System.Drawing.Size(113, 12);
            this.mediaSlider1.SliderFlyOut = MediaSlider.MediaSlider.FlyOutStyle.None;
            this.mediaSlider1.SmallChange = 1;
            this.mediaSlider1.SmoothScrolling = true;
            this.mediaSlider1.TabIndex = 0;
            this.mediaSlider1.TickColor = System.Drawing.Color.DarkGray;
            this.mediaSlider1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mediaSlider1.TickType = MediaSlider.MediaSlider.TickMode.Standard;
            this.mediaSlider1.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mediaSlider1.TrackDepth = 6;
            this.mediaSlider1.TrackFillColor = System.Drawing.Color.DarkGray;
            this.mediaSlider1.TrackProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(101)))), ((int)(((byte)(188)))));
            this.mediaSlider1.TrackShadow = true;
            this.mediaSlider1.TrackShadowColor = System.Drawing.Color.Black;
            this.mediaSlider1.TrackStyle = MediaSlider.MediaSlider.TrackType.Value;
            this.mediaSlider1.Value = 0;
            this.mediaSlider1.ValueChanged += new MediaSlider.MediaSlider.ValueChangedDelegate(this.msld_XAxisZoom_ValueChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(762, 209);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 24;
            this.button7.Text = "Run";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // mediaSlider3
            // 
            this.mediaSlider3.Animated = true;
            this.mediaSlider3.AnimationSize = 0.2F;
            this.mediaSlider3.AnimationSpeed = MediaSlider.MediaSlider.AnimateSpeed.Fast;
            this.mediaSlider3.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.mediaSlider3.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.mediaSlider3.AutoSize = true;
            this.mediaSlider3.BackColor = System.Drawing.Color.DarkGray;
            this.mediaSlider3.BackgroundImage = null;
            this.mediaSlider3.ButtonAccentColor = System.Drawing.Color.Red;
            this.mediaSlider3.ButtonBorderColor = System.Drawing.Color.DarkOrange;
            this.mediaSlider3.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mediaSlider3.ButtonCornerRadius = ((uint)(2u));
            this.mediaSlider3.ButtonSize = new System.Drawing.Size(12, 24);
            this.mediaSlider3.ButtonStyle = MediaSlider.MediaSlider.ButtonType.GlassInline;
            this.mediaSlider3.ContextMenuStrip = null;
            this.mediaSlider3.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.mediaSlider3.LargeChange = 2;
            this.mediaSlider3.Location = new System.Drawing.Point(24, 6);
            this.mediaSlider3.Margin = new System.Windows.Forms.Padding(0);
            this.mediaSlider3.Maximum = 10;
            this.mediaSlider3.Minimum = 0;
            this.mediaSlider3.Name = "mediaSlider3";
            this.mediaSlider3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.mediaSlider3.ShowButtonOnHover = false;
            this.mediaSlider3.Size = new System.Drawing.Size(12, 103);
            this.mediaSlider3.SliderFlyOut = MediaSlider.MediaSlider.FlyOutStyle.None;
            this.mediaSlider3.SmallChange = 1;
            this.mediaSlider3.SmoothScrolling = true;
            this.mediaSlider3.TabIndex = 0;
            this.mediaSlider3.TickColor = System.Drawing.Color.DarkGray;
            this.mediaSlider3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mediaSlider3.TickType = MediaSlider.MediaSlider.TickMode.Standard;
            this.mediaSlider3.TrackBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mediaSlider3.TrackDepth = 6;
            this.mediaSlider3.TrackFillColor = System.Drawing.Color.DarkGray;
            this.mediaSlider3.TrackProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(101)))), ((int)(((byte)(188)))));
            this.mediaSlider3.TrackShadow = true;
            this.mediaSlider3.TrackShadowColor = System.Drawing.Color.Black;
            this.mediaSlider3.TrackStyle = MediaSlider.MediaSlider.TrackType.Value;
            this.mediaSlider3.Value = 0;
            this.mediaSlider3.ValueChanged += new MediaSlider.MediaSlider.ValueChangedDelegate(this.msld_YAxisZoom_ValueChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.DarkGray;
            this.checkBox2.ForeColor = System.Drawing.Color.Blue;
            this.checkBox2.Location = new System.Drawing.Point(13, 385);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(42, 16);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "# 2";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.DarkGray;
            this.checkBox3.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox3.Location = new System.Drawing.Point(14, 409);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(42, 16);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "# 3";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // btn_ZoomIn
            // 
            this.btn_ZoomIn.AutoEllipsis = true;
            this.btn_ZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_ZoomIn.Location = new System.Drawing.Point(47, 17);
            this.btn_ZoomIn.Name = "btn_ZoomIn";
            this.btn_ZoomIn.Size = new System.Drawing.Size(82, 23);
            this.btn_ZoomIn.TabIndex = 5;
            this.btn_ZoomIn.Text = "[整体] 放大";
            this.btn_ZoomIn.UseVisualStyleBackColor = true;
            this.btn_ZoomIn.Click += new System.EventHandler(this.btn_Zoom_In);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.DarkGray;
            this.checkBox1.ForeColor = System.Drawing.Color.Blue;
            this.checkBox1.Location = new System.Drawing.Point(14, 361);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 16);
            this.checkBox1.TabIndex = 36;
            this.checkBox1.Text = "# 1";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox_X_Value
            // 
            this.textBox_X_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_X_Value.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_X_Value.Location = new System.Drawing.Point(84, 332);
            this.textBox_X_Value.Name = "textBox_X_Value";
            this.textBox_X_Value.ReadOnly = true;
            this.textBox_X_Value.Size = new System.Drawing.Size(70, 21);
            this.textBox_X_Value.TabIndex = 16;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.DarkGray;
            this.checkBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.checkBox4.Location = new System.Drawing.Point(13, 433);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(42, 16);
            this.checkBox4.TabIndex = 13;
            this.checkBox4.Text = "# 4";
            this.checkBox4.UseVisualStyleBackColor = false;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // btn_ZoomOut
            // 
            this.btn_ZoomOut.Location = new System.Drawing.Point(47, 60);
            this.btn_ZoomOut.Name = "btn_ZoomOut";
            this.btn_ZoomOut.Size = new System.Drawing.Size(82, 23);
            this.btn_ZoomOut.TabIndex = 3;
            this.btn_ZoomOut.Text = "[整体] 缩小";
            this.btn_ZoomOut.UseVisualStyleBackColor = true;
            this.btn_ZoomOut.Click += new System.EventHandler(this.btn_Zoom_Out);
            // 
            // checkBox_DrawXOriginAxis
            // 
            this.checkBox_DrawXOriginAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_DrawXOriginAxis.AutoSize = true;
            this.checkBox_DrawXOriginAxis.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.checkBox_DrawXOriginAxis.Location = new System.Drawing.Point(13, 303);
            this.checkBox_DrawXOriginAxis.Name = "checkBox_DrawXOriginAxis";
            this.checkBox_DrawXOriginAxis.Size = new System.Drawing.Size(48, 16);
            this.checkBox_DrawXOriginAxis.TabIndex = 22;
            this.checkBox_DrawXOriginAxis.Text = "X=0 ";
            this.checkBox_DrawXOriginAxis.UseVisualStyleBackColor = false;
            this.checkBox_DrawXOriginAxis.CheckedChanged += new System.EventHandler(this.checkBox_DrawOriginAxix_CheckedChanged);
            // 
            // textBox_Channel1
            // 
            this.textBox_Channel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Channel1.Location = new System.Drawing.Point(84, 356);
            this.textBox_Channel1.Name = "textBox_Channel1";
            this.textBox_Channel1.Size = new System.Drawing.Size(70, 21);
            this.textBox_Channel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(12, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "X 轴";
            // 
            // pnl_Controls
            // 
            this.pnl_Controls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_Controls.BackColor = System.Drawing.Color.DarkGray;
            this.pnl_Controls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Controls.Controls.Add(this.btn_PickZone);
            this.pnl_Controls.Controls.Add(this.btn_LoadData);
            this.pnl_Controls.Controls.Add(this.btn_SaveBitmap);
            this.pnl_Controls.Controls.Add(this.btn_ZoomAll);
            this.pnl_Controls.Controls.Add(this.btn_BackToOrigin);
            this.pnl_Controls.Controls.Add(this.btn_TraceTicks);
            this.pnl_Controls.Controls.Add(this.btnSampleTest);
            this.pnl_Controls.Controls.Add(this.btn_SerialPort_Open);
            this.pnl_Controls.Controls.Add(this.btn_SaveData);
            this.pnl_Controls.Controls.Add(this.label1);
            this.pnl_Controls.Controls.Add(this.textBox_Channel1);
            this.pnl_Controls.Controls.Add(this.checkBox_DrawXOriginAxis);
            this.pnl_Controls.Controls.Add(this.btn_ZoomOut);
            this.pnl_Controls.Controls.Add(this.checkBox4);
            this.pnl_Controls.Controls.Add(this.textBox_X_Value);
            this.pnl_Controls.Controls.Add(this.checkBox1);
            this.pnl_Controls.Controls.Add(this.btn_ZoomIn);
            this.pnl_Controls.Controls.Add(this.checkBox3);
            this.pnl_Controls.Controls.Add(this.btn_DataObserver);
            this.pnl_Controls.Controls.Add(this.checkBox2);
            this.pnl_Controls.Controls.Add(this.mediaSlider3);
            this.pnl_Controls.Controls.Add(this.button7);
            this.pnl_Controls.Controls.Add(this.btn_SerialPort_Stop);
            this.pnl_Controls.Controls.Add(this.mediaSlider1);
            this.pnl_Controls.Controls.Add(this.button8);
            this.pnl_Controls.Controls.Add(this.textBox_Channel2);
            this.pnl_Controls.Controls.Add(this.button9);
            this.pnl_Controls.Controls.Add(this.textBox_Channel3);
            this.pnl_Controls.Controls.Add(this.button10);
            this.pnl_Controls.Controls.Add(this.textBox_Channel4);
            this.pnl_Controls.Controls.Add(this.button11);
            this.pnl_Controls.Controls.Add(this.btn_ZoomInX);
            this.pnl_Controls.Controls.Add(this.button12);
            this.pnl_Controls.Controls.Add(this.checkBox5);
            this.pnl_Controls.Controls.Add(this.btn_ZoomOutX);
            this.pnl_Controls.Controls.Add(this.button13);
            this.pnl_Controls.Controls.Add(this.btn_ZoomInY);
            this.pnl_Controls.Controls.Add(this.button14);
            this.pnl_Controls.Controls.Add(this.textBox1);
            this.pnl_Controls.Controls.Add(this.btn_ZoomOutY);
            this.pnl_Controls.Controls.Add(this.button15);
            this.pnl_Controls.Controls.Add(this.textBox2);
            this.pnl_Controls.Controls.Add(this.checkBox6);
            this.pnl_Controls.Controls.Add(this.textBox3);
            this.pnl_Controls.Controls.Add(this.checkBox7);
            this.pnl_Controls.Controls.Add(this.button16);
            this.pnl_Controls.Controls.Add(this.checkBox8);
            this.pnl_Controls.Controls.Add(this.button17);
            this.pnl_Controls.Controls.Add(this.button18);
            this.pnl_Controls.Controls.Add(this.textBox4);
            this.pnl_Controls.Controls.Add(this.checkBox9);
            this.pnl_Controls.Controls.Add(this.label2);
            this.pnl_Controls.Controls.Add(this.textBox5);
            this.pnl_Controls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_Controls.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Controls.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl_Controls.Location = new System.Drawing.Point(1103, 0);
            this.pnl_Controls.Name = "pnl_Controls";
            this.pnl_Controls.Size = new System.Drawing.Size(167, 494);
            this.pnl_Controls.TabIndex = 42;
            // 
            // btn_PickZone
            // 
            this.btn_PickZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PickZone.BackgroundImage = global::Monitor.Properties.Resources.obseve_data;
            this.btn_PickZone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_PickZone.Location = new System.Drawing.Point(86, 222);
            this.btn_PickZone.Name = "btn_PickZone";
            this.btn_PickZone.Size = new System.Drawing.Size(33, 27);
            this.btn_PickZone.TabIndex = 45;
            this.btn_PickZone.UseVisualStyleBackColor = true;
            this.btn_PickZone.Click += new System.EventHandler(this.btn_PickZone_Click);
            // 
            // btn_LoadData
            // 
            this.btn_LoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LoadData.BackgroundImage = global::Monitor.Properties.Resources.下载;
            this.btn_LoadData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_LoadData.Location = new System.Drawing.Point(125, 220);
            this.btn_LoadData.Name = "btn_LoadData";
            this.btn_LoadData.Size = new System.Drawing.Size(33, 27);
            this.btn_LoadData.TabIndex = 44;
            this.btn_LoadData.UseMnemonic = false;
            this.btn_LoadData.UseVisualStyleBackColor = true;
            this.btn_LoadData.Click += new System.EventHandler(this.btn_LoadData_Click);
            // 
            // btn_SaveBitmap
            // 
            this.btn_SaveBitmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveBitmap.BackgroundImage = global::Monitor.Properties.Resources.images;
            this.btn_SaveBitmap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SaveBitmap.Location = new System.Drawing.Point(125, 189);
            this.btn_SaveBitmap.Name = "btn_SaveBitmap";
            this.btn_SaveBitmap.Size = new System.Drawing.Size(33, 27);
            this.btn_SaveBitmap.TabIndex = 43;
            this.btn_SaveBitmap.UseVisualStyleBackColor = true;
            this.btn_SaveBitmap.Click += new System.EventHandler(this.btn_SaveBitmap_Click);
            // 
            // btn_ZoomAll
            // 
            this.btn_ZoomAll.BackgroundImage = global::Monitor.Properties.Resources.traceX;
            this.btn_ZoomAll.Location = new System.Drawing.Point(8, 255);
            this.btn_ZoomAll.Name = "btn_ZoomAll";
            this.btn_ZoomAll.Size = new System.Drawing.Size(33, 27);
            this.btn_ZoomAll.TabIndex = 41;
            this.btn_ZoomAll.UseVisualStyleBackColor = true;
            this.btn_ZoomAll.Click += new System.EventHandler(this.btn_ZoomAll_Click);
            // 
            // btn_BackToOrigin
            // 
            this.btn_BackToOrigin.Location = new System.Drawing.Point(47, 255);
            this.btn_BackToOrigin.Name = "btn_BackToOrigin";
            this.btn_BackToOrigin.Size = new System.Drawing.Size(33, 27);
            this.btn_BackToOrigin.TabIndex = 0;
            this.btn_BackToOrigin.Text = "<-";
            this.btn_BackToOrigin.UseVisualStyleBackColor = true;
            this.btn_BackToOrigin.Click += new System.EventHandler(this.btn_BackToOrigin_Click);
            // 
            // btn_TraceTicks
            // 
            this.btn_TraceTicks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TraceTicks.BackgroundImage = global::Monitor.Properties.Resources.target_x;
            this.btn_TraceTicks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_TraceTicks.Location = new System.Drawing.Point(47, 222);
            this.btn_TraceTicks.Name = "btn_TraceTicks";
            this.btn_TraceTicks.Size = new System.Drawing.Size(33, 27);
            this.btn_TraceTicks.TabIndex = 27;
            this.btn_TraceTicks.UseVisualStyleBackColor = true;
            this.btn_TraceTicks.Click += new System.EventHandler(this.btn_TraceTicks_Click);
            // 
            // btnSampleTest
            // 
            this.btnSampleTest.Location = new System.Drawing.Point(85, 289);
            this.btnSampleTest.Name = "btnSampleTest";
            this.btnSampleTest.Size = new System.Drawing.Size(75, 23);
            this.btnSampleTest.TabIndex = 42;
            // 
            // btn_SerialPort_Open
            // 
            this.btn_SerialPort_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SerialPort_Open.BackColor = System.Drawing.Color.Transparent;
            this.btn_SerialPort_Open.BackgroundImage = global::Monitor.Properties.Resources.Run_Modified;
            this.btn_SerialPort_Open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_SerialPort_Open.Location = new System.Drawing.Point(8, 189);
            this.btn_SerialPort_Open.Name = "btn_SerialPort_Open";
            this.btn_SerialPort_Open.Size = new System.Drawing.Size(33, 27);
            this.btn_SerialPort_Open.TabIndex = 24;
            this.btn_SerialPort_Open.UseVisualStyleBackColor = false;
            this.btn_SerialPort_Open.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveData.BackgroundImage = global::Monitor.Properties.Resources.save_file;
            this.btn_SaveData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_SaveData.Location = new System.Drawing.Point(86, 189);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(33, 27);
            this.btn_SaveData.TabIndex = 38;
            this.btn_SaveData.UseVisualStyleBackColor = true;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // btn_DataObserver
            // 
            this.btn_DataObserver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DataObserver.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_DataObserver.BackgroundImage = global::Monitor.Properties.Resources.observe_x_4;
            this.btn_DataObserver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_DataObserver.Location = new System.Drawing.Point(8, 222);
            this.btn_DataObserver.Name = "btn_DataObserver";
            this.btn_DataObserver.Size = new System.Drawing.Size(33, 27);
            this.btn_DataObserver.TabIndex = 14;
            this.btn_DataObserver.UseVisualStyleBackColor = false;
            this.btn_DataObserver.Click += new System.EventHandler(this.btn_ObserveData_Click);
            // 
            // btn_SerialPort_Stop
            // 
            this.btn_SerialPort_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SerialPort_Stop.BackgroundImage = global::Monitor.Properties.Resources.Stop_Blue;
            this.btn_SerialPort_Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_SerialPort_Stop.Location = new System.Drawing.Point(47, 189);
            this.btn_SerialPort_Stop.Name = "btn_SerialPort_Stop";
            this.btn_SerialPort_Stop.Size = new System.Drawing.Size(33, 27);
            this.btn_SerialPort_Stop.TabIndex = 25;
            this.btn_SerialPort_Stop.UseVisualStyleBackColor = true;
            this.btn_SerialPort_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // Assembly_Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1270, 516);
            this.Controls.Add(this.pnl_Controls);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnl_Monitor);
            this.IsMdiContainer = true;
            this.Name = "Assembly_Monitor";
            this.Text = "Monitor_V2.0";
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Monitor_Closing);
            this.Resize += new System.EventHandler(this.Monitor_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnl_Controls.ResumeLayout(false);
            this.pnl_Controls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
  
        #endregion

        private GraphicsControls.derivedCoordinatesBox Coordinates;

        private System.Windows.Forms.Panel pnl_Monitor;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button btn_ZoomOutY;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button btn_ZoomInY;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button btn_ZoomOutX;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button btn_ZoomInX;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox textBox_Channel4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox textBox_Channel3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox_Channel2;
        private System.Windows.Forms.Button button8;
        private MediaSlider.MediaSlider mediaSlider1;
        private System.Windows.Forms.Button button7;
        private MediaSlider.MediaSlider mediaSlider3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button btn_ZoomIn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox_X_Value;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button btn_ZoomOut;
        private System.Windows.Forms.CheckBox checkBox_DrawXOriginAxis;
        private System.Windows.Forms.TextBox textBox_Channel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.Button btn_SerialPort_Open;
        private System.Windows.Forms.Button btn_TraceTicks;
        private System.Windows.Forms.Panel pnl_Controls;
        private System.Windows.Forms.Button btn_DataObserver;
        private System.Windows.Forms.Button btn_SerialPort_Stop;
        private System.Windows.Forms.Button btnSampleTest;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Comport_Settings;
        private System.Windows.Forms.Button btn_BackToOrigin;
        private System.Windows.Forms.Button btn_ZoomAll;
        private System.Windows.Forms.Button btn_SaveBitmap;
        private System.Windows.Forms.Button btn_LoadData;
        private System.Windows.Forms.Button btn_PickZone;
    }
}

