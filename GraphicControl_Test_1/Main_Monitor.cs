//#define  _debug_movealong_x_

using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using Monitor.Properties;

// 为了设置属性
using System.Reflection;
using System.Text.RegularExpressions;

namespace Monitor
{
    public partial class Assembly_Monitor : Form
    {

        #region debug
#if _debug_movealong_x_ 
                private FileStream g_debug_file ;
                private StringBuilder g_stringbuilder ;
#endif
        #endregion

        #region Local Varialbes
        private const int g_k_nChannel = 4;

        private TextBox[] g_arrTextBoxes = new TextBox[g_k_nChannel];
        private CheckBox[] g_arrCheckBoxes = new CheckBox[g_k_nChannel];
        private Color[] g_arrChannelColor = { Color.Blue, Color.Green, Color.Orange, Color.Red };

        private SerialPort Comport = new SerialPort();
        private fmSerialPortSettings Settings_Form = new fmSerialPortSettings();
        private Settings Settings = new Settings();

        // Monitor State
        private bool g_boolTracing = false;
        private bool g_boolObserving = false;
        private bool g_boolRestarting = false;
        private bool g_boolPicking = false;
        private bool g_boolTimeisup = false;
        private bool g_boolMonitor = false;

        private static int g_nOld_X = -1;
        private static int g_nOld_Y = -1;

        private static int g_nTimer2Tick = 0;
        #endregion

        #region Sample Test Button
#if _Sample_Test_
        private List<Int16> g_i16SinCurveY;

        private bool boolSampleStart = false ;
        
        private void btnSampleTest_Click(object sender, EventArgs e) 
        {
            boolSampleStart = ! boolSampleStart ;
            if ( boolSampleStart )
                this.timer2.Start() ;
            else
            {
                this.timer2.Stop();
                this.Monitor_ReStart() ;
            }
        }
#endif


        #endregion

        #region Constructor & Initializer
        public Assembly_Monitor()
        {
            Settings.Reload();

            InitializeComponent();

            InitializeSerialport();

            IntializeControls();

            InitializeDataset();

#if _debug_movealong_x_ 
            try
            {
                g_debug_file = new FileStream("d:\\debug_data.txt", FileMode.Create);
                g_stringbuilder = new StringBuilder(0);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
#endif
        }

        #region Initializer
        private void IntializeCoordinateUI()
        {
            this.Coordinates = new GraphicsControls.derivedCoordinatesBox(this.pnl_Monitor.Width, this.pnl_Monitor.Height, 60, 30, 8, 6, 10, 11);

            // 注意, 其实用不用 panel 都是无所谓的,关键是在
            // 哪个 Control ( Form , Panel 等) 的 Paint 事件处理函数中 调用 DisplayGraphics
            // 其次,刷新哪个

            // 设置 原点起始 坐标
            this.Coordinates.OriginX = -this.pnl_Monitor.Width / this.Coordinates.PixelPerTick_XAxis / 2;
            this.Coordinates.Origin_Y = -this.pnl_Monitor.Height / this.Coordinates.PixelPerTick_YAxis / 2;

            //this.TestUI.KeepXAxisSymmetric();
            //this.TestUI.KeepYAxisSymmetric();
        }

        private void InitializeMediaSilder()
        {
            // 这里会引发 mediaSlider 的 ValueChanged 事件,从而自动设定 Coodinate 的 TickValue
            this.mediaSlider1.Value = this.mediaSlider1.Maximum / 2;
            this.mediaSlider3.Value = this.mediaSlider3.Maximum / 2;

            this.mediaSlider1.Show();
            this.mediaSlider3.Show();
        }

        private void InitializeDataset()
        {
#if _Sample_Test_
            this.g_i16SinCurveY = new List<Int16>(0);
#endif

            this.g_i16ChannelDataset = new List<Int16>[g_k_nChannel] { new List<Int16>(0), new List<Int16>(0), new List<Int16>(0), new List<Int16>(0) };
        }

        private void IntializeControls()
        {
            // 设置 Form 的 属性
            this.DoubleBuffered = true;

            // 设置Panel 的 属性
            PropertyInfo info = this.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            info.SetValue(this.pnl_Monitor, true, null);

            /// 初始化 Coodinate
            IntializeCoordinateUI();

            //// 设置mediaSlider 的属性
            InitializeMediaSilder();

            /// 初始化设置表格
            IntializeSettingsForm();

            // 
            g_arrTextBoxes[0] = this.textBox_Channel1;
            g_arrTextBoxes[1] = this.textBox_Channel2;
            g_arrTextBoxes[2] = this.textBox_Channel3;
            g_arrTextBoxes[3] = this.textBox_Channel4;

            g_arrCheckBoxes[0] = this.checkBox1;
            g_arrCheckBoxes[1] = this.checkBox2;
            g_arrCheckBoxes[2] = this.checkBox3;
            g_arrCheckBoxes[3] = this.checkBox4;

            this.checkBox1.Checked = this.checkBox2.Checked = this.checkBox3.Checked = this.checkBox4.Checked = true;
            for (int i = 0; i < g_k_nChannel; ++i)
                g_arrCheckBoxes[i].ForeColor = g_arrChannelColor[i];

            //
            this.checkBox_DrawXOriginAxis.Checked = false;

            //
            this.btn_SerialPort_Stop.Enabled = false;
            this.btn_SerialPort_Open.Enabled = true;
            this.btn_SaveData.Enabled = false;

            //
            this.tssl_Comport_Settings.Text = "COM Port: " + this.Comport.PortName + " | Baud Rate: " + this.Comport.BaudRate.ToString() + " | Stop Bits: " + this.Comport.StopBits.ToString() + " |  Parity: " + this.Comport.Parity.ToString();

            // 
#if _Sample_Test_
            btnSampleTest.Show() ;
#else
            btnSampleTest.Hide();
#endif
        }

        private void InitializeSerialport()
        {


            // Set how many bytes to hold before trigger the DataReceived Handler 
            Comport.BaudRate = Settings.BaudRate;
            Comport.DataBits = Settings.DataBits;
            Comport.StopBits = Settings.StopBits;
            Comport.Parity = Settings.Parity;
            Comport.PortName = Settings.PortName;

            this.Comport.ReceivedBytesThreshold = 10;
        }

        private void InitializeControlState()
        {
        }

        private void IntializeSettingsForm()
        {
            Settings_Form.InitializePortSettings(ref Settings);
        }
        #endregion
        #endregion

        #region Monitor DataSet
        private List<byte> g_ubyteSerialportBuffer = new List<byte>(512);
        private List<Int16>[] g_i16ChannelDataset;
        #endregion

        #region <Timer and Tiem Series Control>
        private void timer2_Tick(object sender, EventArgs e)
        {
            // Refresh Period : 2 * 10ms = 20  ms , Frequecy : 1 / 20ms = 50HZ
            if (g_nTimer2Tick % 2 == 0)
            {
                g_boolTimeisup = true;
                this.pnl_Monitor.Invalidate(false);
                this.pnl_Monitor.Update();
            }

            ++g_nTimer2Tick;
        }
        #endregion

        #region Form Background Handler

        private void Monitor_Load(object sender, EventArgs e)
        {
            timer2.Start();

            Settings.Reload();

            this.MinimumSize = new Size(640, 480);

            this.UpdateButtonsStates();
        }

        private void Monitor_Closing(object sender, EventArgs e)
        {
            this.Settings.Save();

            Clipboard.Clear();

            this.timer2.Stop();

#if _debug_movealong_x_
            g_debug_file.Close() ;
#endif
        }

        private void Monitor_Resize(object sender, EventArgs e)
        {
            #region Corrected Mistake
            // 首先对 form 的 size 的最小值进行一定的限制
            //if (this.Width < 640)
            //    this.Width = 640;
            //if (this.Height < 480)
            //    this.Height = 480;
            // 已经在form_Load 中对其进行了限制, 此处不必限制.
            // 而且,此处的限制 会引起 反复的重绘,效果不佳.
            // 可以立即 进行 Invalidate 和 Update 


            // 我们只对 panel 1 进行 长度和宽度的放缩
            // 千万不可以写成 this.Height , 否则 Status Strip 将会遮住 panel1 
            #endregion

            // 不是 minimize 导致 的 resize
            if (this.ClientSize.Height != 0)
            {
                int nHeight = this.ClientSize.Height - this.statusStrip1.Height;

                int nDeltaHeight = nHeight - this.pnl_Monitor.Height;

                this.pnl_Monitor.Width = this.ClientSize.Width - this.pnl_Controls.Width;
                this.pnl_Controls.Height = this.pnl_Monitor.Height = nHeight;

                if (Coordinates != null)
                    this.Coordinates.ResizeCoordinateBox(pnl_Monitor.Width, pnl_Monitor.Height);

                foreach (Control control in this.pnl_Controls.Controls)
                {
                    if (control != null && control.Name != "panel1")
                        control.Location = new Point(control.Location.X, control.Location.Y + (int)(nDeltaHeight * 0.5));
                }
            }

            // form 中的所有子控件都需要重画,
            // 也就是 panel1 和 panel 2
            // 从而带动
            this.Invalidate(true);

        }

        private void Monitor_ReStart()
        {
            ////////////////////////////////////////////////////////////////////////// clear data 
            foreach (List<Int16> list in g_i16ChannelDataset)
                // list 的 count 被设置为0,并且原来的内存被释放;
                // 但 list 对象本身依然健在.
                list.Clear();

#if _Sample_Test_
            g_i16SinCurveY.Clear();
#endif

            ////////////////////////////////////////////////////////////////////////// reset clock 
            g_nTimer2Tick = 0;

        }

        #endregion

        #region Form Foreground Handler
        private void DrawDataset(Graphics g, Pen pen, ref List<Int16> dataset, int nXStartIndex , int nXEndIndex , int delta )
        {
            int counts = dataset.Count > nXEndIndex ? nXEndIndex >= 0 ? nXEndIndex : 0  : dataset.Count ;
            if (counts > 1)
            {
                int iter = nXStartIndex >= 0 ? nXStartIndex : 0 ;

                Point p1 = new Point();
                Point p2 = new Point();
 
                //for (iter = nXStartIndex; iter < counts - 1; ++iter)
                for ( ; iter + delta < counts ;  iter += delta )
                {
                    p1 = this.Coordinates.DataToPixel( iter, dataset[iter] ); // 这里需要重新考虑,尤其是 当在负半轴 的情况.
                    p2 = this.Coordinates.DataToPixel( iter + 1, dataset[iter + delta] );

                    // 这里需要 " 直线裁剪"算法
                    if (this.Coordinates.IsInCoordinateBox(p2) == GraphicsControls.RangeTestResult.IN_RANGE)
                        if (this.Coordinates.IsInCoordinateBox(p1) == GraphicsControls.RangeTestResult.IN_RANGE)
                            g.DrawLine(pen, p1, p2);
                }
            }
        }

        private void DrawDatasetWithDots(Graphics g, Pen pen, ref List<Int16> dataset, int nXStartIndex, int nXEndIndex , int delta)
        {
            SolidBrush fill_ellipse = new SolidBrush(pen.Color);

            int counts = dataset.Count > nXEndIndex ? nXEndIndex >= 0 ? nXEndIndex : 0 : dataset.Count;
            if (counts > 1)
            {
                int iter = nXStartIndex >= 0  ? nXStartIndex : 0  ;

                Point p1 = new Point();
                Point p2 = new Point();

                for ( ; iter + delta < counts ;  iter += delta )
                {
                    p1 = this.Coordinates.DataToPixel( iter, dataset[iter] ); // 这里需要重新考虑,尤其是 当在负半轴 的情况.
                    p2 = this.Coordinates.DataToPixel( iter + 1, dataset[iter + delta] );

                    // 这里需要 " 直线裁剪"算法
                    if (this.Coordinates.IsInCoordinateBox(p2) == GraphicsControls.RangeTestResult.IN_RANGE)
                        if (this.Coordinates.IsInCoordinateBox(p1) == GraphicsControls.RangeTestResult.IN_RANGE)
                        {
                            g.DrawLine(pen, p1, p2);
                            g.FillEllipse(fill_ellipse, p1.X - 2, p1.Y - 2, 5, 5);
                            g.FillEllipse(fill_ellipse, p2.X - 2, p2.Y - 2, 5, 5);
                        }
                }
            }
        }
        #endregion

        #region  Panel Cooridinate
        private void pnl_Monitor_paint(object sender, PaintEventArgs e)
        {
            // Set the SmoothingMode property to smooth the line.
            //
            //
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Create a new pen.
            //
            //
            Pen panel_pen = new Pen(Color.SkyBlue, 1);

            // Get needed information
            //
            //
            int start_index_x = (int)(this.Coordinates.OriginX) ;
            int end_index_x = this.Coordinates.MaxIndex_XAxis ;
            Point cursor_pixel = this.pnl_Monitor.PointToClient(Control.MousePosition);

            ////////////////////////////////////////////////////////////////////////// Timer Update
            if (g_boolMonitor && g_boolTimeisup || !g_boolMonitor ) //  
            {
                // Trace X 
                // As tracing x will update the coordinate parameters , so we should update them before drawing the coordinate
                //
                if (this.g_boolTracing)
                {
                    this.Coordinates.TraceXAxis(this.g_i16ChannelDataset[0].Count);
                }
                //Draw Coordinates
                //
                //
                this.Coordinates.DrawCoordinate(e.Graphics);
                //Draw Media Slider 
                //
                //
                this.mediaSlider1.DrawSlider();
                this.mediaSlider3.DrawSlider();
                // Draw serial port data 
                //
                //
                if (this.g_i16ChannelDataset[1].Count != 0)
                    // Draw dataset of each channel 
                    for (int ch = 0; ch < g_k_nChannel; ++ch)
                    {
                        if (g_arrCheckBoxes[ch].Checked)
                        {
                            panel_pen.Color = g_arrChannelColor[ch];

                            // 这里可以做许多 优化 
                            // 如果 不进行 条件判断的话 ,  当 绘制点的个数增多的时候 ( 也就是 DrawDataset 的 迭代次数增多 , 会严重影响效率
                            // 已经优化
                            float pixel_per_datum = this.Coordinates.PixelPerTick_XAxis / this.Coordinates.DataAmountPerTick_XAxis;

                            if ( pixel_per_datum >= 5) // && this.Coordinates.YScreenScale / this.Coordinates.RealYTickValue >= 5
                                this.DrawDatasetWithDots(e.Graphics, panel_pen, ref g_i16ChannelDataset[ch], start_index_x , end_index_x , 1  ); 
                            else
                                if (  pixel_per_datum <= 0.2 )
                                    this.DrawDataset(
                                        e.Graphics, panel_pen, ref g_i16ChannelDataset[ch], 
                                        start_index_x, end_index_x, 
                                        (int)(this.Coordinates.DataAmountPerTick_XAxis / this.Coordinates.PixelPerTick_XAxis) 
                                        );
                                else
                                    this.DrawDataset(e.Graphics, panel_pen, ref g_i16ChannelDataset[ch], start_index_x, end_index_x, 1);
                        }
                    }

                g_boolTimeisup = false;
            }

            ////////////////////////////////////////////////////////////////////////// Real time update

            // Draw observer line
            //
            //
            if (g_boolObserving)
            {
                panel_pen.Color = Color.White;

                Point p1 = new Point(cursor_pixel.X, 0);
                Point p2 = new Point(cursor_pixel.X, this.pnl_Monitor.Height);
                e.Graphics.DrawLine(panel_pen, p1, p2);
            }
            // Draw the picking box 
            //
            //
            if (g_boolPicking && g_nOld_X != -1 )
            {
                panel_pen.Color = Color.LightGreen;
                e.Graphics.DrawRectangle(panel_pen, g_nOld_X, g_nOld_Y, cursor_pixel.X - g_nOld_X, cursor_pixel.Y - g_nOld_Y);
                // ?? 如果这里变成了负数会怎么办 ??
            }

            // Draw X origin line 
            //
            //
            if (this.checkBox_DrawXOriginAxis.Checked)
                this.Coordinates.DrawXOriginAxis(e.Graphics);

            // Dispose the pen resource
            panel_pen.Dispose();
        }

        static int g_nAccumulated_Pixels_X = 0;
        static int g_nAccumulated_Pixels_Y = 0;
        private void pnlCoord_OnMouseMove(object sender, MouseEventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////
            // Get where cursor locates
            Point current_pixel = e.Location;

            // Calculate real X value
            int t_nRealX = this.Coordinates.PixelOffsetToData_XAxis(current_pixel.X);
            this.textBox_X_Value.Text = t_nRealX.ToString();

            // Update textbox data 
            for (int ch = 0; ch < g_k_nChannel; ++ch)
                if (t_nRealX >= 0 && t_nRealX < this.g_i16ChannelDataset[ch].Count)
                    this.g_arrTextBoxes[ch].Text = this.g_i16ChannelDataset[ch].ElementAt(t_nRealX).ToString();
                else
                    this.g_arrTextBoxes[ch].Text = "0";

            if (e.Button == MouseButtons.Left)
            {
                if (g_boolPicking)
                {

                }
                else  // 通过这种做法 , 可以 不需要 关闭 拖动的前提下 ,  进行截取
                {
                    g_nAccumulated_Pixels_X += g_nOld_X - e.Location.X;
                    g_nAccumulated_Pixels_Y += e.Location.Y - g_nOld_Y;

                    // 其实可以考虑用单个 byte 来置位 .
                    int clear_acc_X = 0;
                    int clear_acc_Y = 0;

                    if (Control.ModifierKeys == Keys.Control)
                    {
                        clear_acc_X = Coordinates.ReScaleXAxis(g_nAccumulated_Pixels_X);
                        clear_acc_Y = Coordinates.ReScaleYAxis(g_nAccumulated_Pixels_Y);
                    }
                    else
                    {
#if _debug_movealong_x_
                g_stringbuilder.Length = 0;
                g_stringbuilder.Append((g_nOld_X - e.Location.X).ToString() + " " + g_accu_pixel_x.ToString() + "\r\n");
                byte[] ascii_debug_data = new ASCIIEncoding().GetBytes(g_stringbuilder.ToString().ToCharArray());
                g_debug_file.Write( ascii_debug_data , 0  , ascii_debug_data.Length  );
#endif
                        clear_acc_X = Coordinates.MoveAlongXAxis(g_nAccumulated_Pixels_X) ;
                        clear_acc_Y = Coordinates.MoveAlongYAxis(g_nAccumulated_Pixels_Y) ;
                    }

                    if ( clear_acc_X != 0 )
                        g_nAccumulated_Pixels_X = 0;

                    if ( clear_acc_Y != 0 )
                        g_nAccumulated_Pixels_Y = 0;

                    g_nOld_X = e.Location.X;
                    g_nOld_Y = e.Location.Y;
                }
            }

            if (!Comport.IsOpen)
            {
                this.pnl_Monitor.Refresh();
            }
        }

        private void pnlCoordOnMouseDown(object sender, MouseEventArgs e)
        {
            // 如果左键按下
            if (e.Button == MouseButtons.Left)
            {
                //if (g_boolPicking)
                //{
                //}
                //else
                //{
                g_nOld_X = e.Location.X;
                g_nOld_Y = e.Location.Y;
                //}
            }
        }

        private void pnlCoord_OnMouseWheel(object sender, MouseEventArgs e)
        {
            // 注意 , 这里有个 Keys.ControlKey 的选项 ;  但不起作用.
            if (Control.ModifierKeys == Keys.Control)
            {
                this.Coordinates.ReScaleXYAxis(e.Delta);
                this.pnl_Monitor.Refresh();
            }
        }

        private Object g_clipborad_obejct = new Object();
        private void pnlCoordOnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (g_boolPicking)
                {
                    Bitmap bitmap = new Bitmap( Math.Abs( e.X - g_nOld_X) , Math.Abs( e.Y - g_nOld_Y) );
                    Graphics g = Graphics.FromImage(bitmap);

                    int  upper = (int)Math.Min ( g_nOld_Y , e.Y );
                    int left = (int)Math.Min ( g_nOld_X , e.X ) ;
                    
                    g.CopyFromScreen(this.PointToScreen(new Point(left, upper) ) , new Point(0, 0), bitmap.Size);
                    bitmap.MakeTransparent() ;

                    if (bitmap != null)
                    {
                        Clipboard.Clear();
                        Clipboard.SetData("Bitmap", (Object)bitmap);

                        if (!Clipboard.ContainsImage())
                            MessageBox.Show(" Clipboard Copy Failed !!! ");
                    }
                    else
                        MessageBox.Show(" Bitmap Copy Failed !!! ");
                }
                g_nOld_X = -1;
                g_nOld_Y = -1;

                g_nAccumulated_Pixels_X = 0;

#if _debug_movealong_x_
                g_stringbuilder.Length = 0 ;
                g_stringbuilder.Append("####");
                byte[] ascii_debug_data = new ASCIIEncoding().GetBytes(g_stringbuilder.ToString().ToCharArray());
                g_debug_file.Write(ascii_debug_data, 0, ascii_debug_data.Length);
#endif
            }
        }

        private void CopyImageToClipboard()
        { 
        }
        #endregion


        #region MediaSlider Value Changed Handler
        private void msld_XAxisZoom_ValueChanged(object sender, EventArgs e)
        {
            double val = (Math.Cos(Math.PI / (2 * mediaSlider1.Maximum) * mediaSlider1.Value - Math.PI) + 1) * 800 + 1;
            this.Coordinates.SetDtRngXTick((int)(val));

            if (!this.Comport.IsOpen)
            {
                this.pnl_Monitor.Invalidate(false);
                this.pnl_Monitor.Update();
            }
        }

        private void msld_YAxisZoom_ValueChanged(object sender, EventArgs e)
        {
            double val = (Math.Cos(Math.PI / (2 * mediaSlider3.Maximum) * mediaSlider3.Value - Math.PI) + 1) * 400 + 1;
            this.Coordinates.SetDtRngYTick((int)(val));

            if (!this.Comport.IsOpen)
            {
                this.pnl_Monitor.Refresh();
            }
        }
        #endregion

        #region Communication Protocol Parser
        private enum ProtocolParseState : byte { End = 0, HdrNotFnd, HdrFnd, FrmAck } ;
        private void sptDispatch()
        {
            ProtocolParseState state = ProtocolParseState.HdrNotFnd;
            byte dataLngth = 0;

            while (state != ProtocolParseState.End)
            {
                switch (state)
                {
                    case ProtocolParseState.HdrNotFnd: // FF not found
                        {
                            if (g_ubyteSerialportBuffer.Count < 13) // Data in Buffer Not Enough
                                state = ProtocolParseState.End;
                            else //  >=13
                            {
                                if (g_ubyteSerialportBuffer[0] == 0x00 && g_ubyteSerialportBuffer[1] == 0x80) // Possible Frame Found
                                    state = ProtocolParseState.HdrFnd;
                                else
                                    g_ubyteSerialportBuffer.RemoveAt(0); // Remain Frame Not Found
                                // state = ProtocolParseState.HdrNotFnd;
                            }
                            break;
                        }
                    case ProtocolParseState.HdrFnd:  // Varify the data length bit and Acknowledge [11] [12]  is next frame header 
                        {
                            if (g_ubyteSerialportBuffer.Count < 13)
                                state = ProtocolParseState.End;
                            else
                            {
                                dataLngth = g_ubyteSerialportBuffer[2];

                                if (dataLngth == 8) //  dataLenth is Varified 
                                {
                                    try
                                    {
                                        if (g_ubyteSerialportBuffer[3 + dataLngth] == 0x00 && g_ubyteSerialportBuffer[4 + dataLngth] == 0x80)
                                            state = ProtocolParseState.FrmAck;   // Try to dispatch 
                                        else
                                        {
                                            // we can ensure that the element [0] will not be  a  frame header
                                            g_ubyteSerialportBuffer.RemoveRange(0, 3);
                                            state = ProtocolParseState.HdrNotFnd;
                                        }
                                    }
                                    catch (System.ArgumentOutOfRangeException ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                }
                                else // dataLngth != 8 
                                {
                                    g_ubyteSerialportBuffer.RemoveRange(0, 3);
                                    state = ProtocolParseState.HdrNotFnd;
                                }
                            }
                            break;
                        }
                    case ProtocolParseState.FrmAck:  // Try to dispatch
                        {
                            try
                            {
                                for (byte ch = 0; ch < g_k_nChannel; ++ch)
                                {
                                    Int16 t_n16Val = BitConverter.ToInt16(g_ubyteSerialportBuffer.ToArray(), 2 * ch + 3);
                                    g_i16ChannelDataset[ch].Add(t_n16Val);
                                }

                                g_ubyteSerialportBuffer.RemoveRange(0, dataLngth + 3);
                                state = ProtocolParseState.HdrFnd;
                            }
                            catch (System.ArgumentOutOfRangeException ext)
                            {
                                MessageBox.Show(ext.ToString());
                            }
                            break;
                        }
                }
            }
        }
        private void sptOn_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // OuroChan : TRY and FINALLY block
            try
            {
                // Obtain the number of bytes waiting in the port's buffer
                int bytes = Comport.BytesToRead;
                byte[] t_byte_buf = new byte[bytes];

                // Read data from buffer 
                Comport.Read(t_byte_buf, 0, bytes);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////  
                //1.缓存数据  
                g_ubyteSerialportBuffer.AddRange(t_byte_buf);

                //2.解包
                this.sptDispatch();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        #region Not Used
        //private void sptDispatch2()
        //{
        //    //2.完整性判断  
        //    while (g_ubyteSerialportBuffer.Count >= 13)//至少要包含头（2字节）+长度（1字节 )
        //    {
        //        //<协议解析>  
        //        bool data_catched = false;//缓存记录数据是否捕获到  

        //        //2.1 查找数据头  
        //        if (g_ubyteSerialportBuffer[0] == 0x00 && g_ubyteSerialportBuffer[1] == 0x80)
        //        {
        //            //2.2 探测缓存数据是否有一条数据的字节，如果不够，就不用费劲的做其他验证了  
        //            //前面已经限定了剩余长度>=3，那我们这里一定能访问到buffer[2]这个长度  
        //            //数据长度  
        //            int data_length = g_ubyteSerialportBuffer[2];
        //            //数据完整判断第一步，长度是否足够
        //            // 如果 ubyte_buffer 中的数据长度不够,则
        //            if (g_ubyteSerialportBuffer.Count < data_length + 3)
        //                break;

        //            data_catched = true;
        //        }
        //        else // frame head not found 
        //        {
        //            //这里是很重要的，如果数据开始不是头，则删除数据  
        //            g_ubyteSerialportBuffer.RemoveAt(0);
        //        }

        //        if (data_catched)
        //        {
        //            int t_nDataLength = g_ubyteSerialportBuffer[2];

        //            // data offset : 3
        //            for (byte ch = 0; ch < gc_nChannel; ++ch)
        //            {
        //                try
        //                {
        //                    Int16 t_n16Val = BitConverter.ToInt16(g_ubyteSerialportBuffer.ToArray(), 2 * ch + 3);
        //                    //Int16 t_n16Val = (Int16)((int)g_ubyteSerialportBuffer[2 * ch + 3] + 256 * (int)g_ubyteSerialportBuffer[2 * ch + 4]);

        //                    // 添加16位数据
        //                    g_i16ChannelDataset[ch].Add(t_n16Val);
        //                }
        //                catch (System.ArgumentOutOfRangeException startIndexException)
        //                {
        //                    MessageBox.Show(" StartIndex Exception !!! ");
        //                }

        //            }
        //            g_ubyteSerialportBuffer.RemoveRange(0, t_nDataLength + 3);//正确分析一条数据，从缓存中移除数
        //        }
        //    }
        //}
        #endregion
        #endregion

        #region <Click Event Handler> Button , Checkbox

        #region Setting , Save Data , ObserveX , TraceX , Run , Stop , Rollback , AutoFit

        private void btn_ObserveData_Click(object sender, EventArgs e)
        {
            g_boolObserving = !g_boolObserving;
            if (!g_boolObserving)
            {
                btn_DataObserver.BackColor = Color.BlanchedAlmond;
                this.pnl_Monitor.Cursor = Cursors.Hand;
            }
            else
            {
                btn_DataObserver.BackColor = Color.WhiteSmoke;
                this.pnl_Monitor.Cursor = Cursors.Cross;
            }
        }

        private void checkBox_DrawOriginAxix_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Comport.IsOpen)
            {
                this.pnl_Monitor.Invalidate();
                this.pnl_Monitor.Update();
            }
        }

        private void tsslComportSetting_Click(object sender, EventArgs e)
        {
            Settings_Form.ShowDialog();

            tssl_Comport_Settings.Text = Settings_Form.GetSerialPortSettingsString();
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            if (this.Comport.IsOpen)
            {
                MessageBox.Show("Stop the port first");
            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Save Data";
                dlg.DefaultExt = ".txt";
                dlg.AddExtension = true;
                dlg.Filter = "Text ASCII |*.txt|Excel|*.xsl;*.xlsx|All Files |*.*";

                // 获取当前时间 , 并 将时间 设置为 初始文件名
                System.TimeSpan current_time = System.DateTime.Now.TimeOfDay;
                dlg.FileName = ((int)current_time.TotalMinutes).ToString() + "_" + current_time.Hours.ToString() + "_" + current_time.Minutes.ToString();

                // If OK enter , then ShowDialog return true ; else return false
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileStream fstream = new FileStream(dlg.FileName, FileMode.Create);
                        StringBuilder sb = new StringBuilder(0);

                        for (int index = 0; index < g_i16ChannelDataset[0].Count; ++index)
                            for (int channel = 0; channel < g_k_nChannel; ++channel)
                            {
                                sb.Append(g_i16ChannelDataset[channel][index].ToString().PadLeft(10) + " ");
                                if ((channel + 1) % g_k_nChannel == 0)
                                    sb.Append("\r\n");
                            }

                        byte[] ascii_saved_data = new ASCIIEncoding().GetBytes(sb.ToString().ToCharArray());
                        fstream.Write(ascii_saved_data, 0, ascii_saved_data.Length);
                        fstream.Close();
                    }
                    catch (System.Exception exception)
                    {
                        MessageBox.Show(exception.ToString());
                    }
                }
            }
        }

        private void btn_BackToOrigin_Click(object sender, EventArgs e)
        {
            if (g_i16ChannelDataset[0].Count != 0)
                this.Coordinates.MoveToOrigin();
            else
                MessageBox.Show("No Data To Display ");

            if (!this.Comport.IsOpen)
            {
                this.pnl_Monitor.Refresh();
            }
        }

        private void btn_ZoomAll_Click(object sender, EventArgs e)
        {
            if (g_i16ChannelDataset[0].Count != 0)
            {
                short[] maxs = new short[4];
                short[] mins = new short[4];
                for (int i = 0; i < g_k_nChannel; ++i)
                {
                    maxs[i] = this.g_i16ChannelDataset[i].Max();
                    mins[i] = this.g_i16ChannelDataset[i].Min();
                }

                // 注意,这里一定要保证 参数传递时 , 最小值 , 最大值 的顺序.
                this.Coordinates.ZoomZone(0, g_i16ChannelDataset[1].Count, mins.Min(), maxs.Max());
            }
            else
                MessageBox.Show("No Data To Display ");

            if (!this.Comport.IsOpen)
            {
                this.pnl_Monitor.Refresh();
            }
        }

        /// <summary>
        ///  Serial Port Components
        /// </summary>
        private void btn_Run_Click(object sender, EventArgs e)
        {
            if (g_boolRestarting)
            {
                this.Monitor_ReStart();
                this.g_boolRestarting = false;
            }

            bool error = false;
            // OuroChan 
            Comport.DataReceived += new SerialDataReceivedEventHandler(sptOn_DataReceived);

            try
            {
                InitializeSerialport();

                Comport.Open();
            }
            catch (UnauthorizedAccessException) { error = true; }
            catch (IOException) { error = true; }
            catch (ArgumentException) { error = true; }
            //finally
            //{
            if (error)
            {
                MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Comport = new SerialPort();
            }
            else // comport is open 
                g_boolMonitor = true;

            this.UpdateButtonsStates();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            // If the port is open, close it.
            if (Comport.IsOpen)
            {
                // SerialDataReceivedEventHandler Unregistered
                Comport.DataReceived -= this.sptOn_DataReceived;

                try
                {
                    Comport.Close();
                }
                catch (System.Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }

                g_boolRestarting = true;
                g_boolMonitor = false;
            }

            // update button states
            this.UpdateButtonsStates();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Comport.IsOpen)
            {
                this.pnl_Monitor.Invalidate();
                this.Update();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Comport.IsOpen)
            {
                this.pnl_Monitor.Invalidate();
                this.Update();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Comport.IsOpen)
            {
                this.pnl_Monitor.Invalidate();
                this.Update();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Comport.IsOpen)
            {
                this.pnl_Monitor.Invalidate();
                this.Update();
            }
        }

        #endregion

        #region Zoom In / Zoom Out
        private void btn_Zoom_Out(object sender, EventArgs e)
        {
            this.Coordinates.ReScaleXYAxis(-120);
            //this.TestUI.MoveOriginToCenter();
            /// 这个功能会影响 X trace  , 所以 在此去除

            if (!this.Comport.IsOpen)
                this.pnl_Monitor.Invalidate(false);
        }

        private void btn_Zoom_In(object sender, EventArgs e)
        {
            this.Coordinates.ReScaleXYAxis(120);
            //this.TestUI.MoveOriginToCenter();
            /// 这个功能会影响 X trace , 所以 在此去除

            if (!this.Comport.IsOpen)
                this.pnl_Monitor.Invalidate(false);
        }

        // Y Axis Zoom in  Y++
        private void btn_ZoomInY_Click(object sender, EventArgs e)
        {
            this.Coordinates.ReScaleYAxis(120);

            if (!this.Comport.IsOpen)
                this.pnl_Monitor.Invalidate(false);
        }

        // Y Axis Zoom out Y --
        private void btn_ZoomOutY_Click(object sender, EventArgs e)
        {
            this.Coordinates.ReScaleYAxis(-120);

            if (!this.Comport.IsOpen)
                this.pnl_Monitor.Invalidate(false);
        }

        // X Axis Zoom in X++
        private void btn_ZoomInX_Click(object sender, EventArgs e)
        {
            this.Coordinates.ReScaleXAxis(120);

            if (!this.Comport.IsOpen)
                this.pnl_Monitor.Refresh();
        }

        // X Axis Zoom out X--
        private void btn_ZoomOutX_Click(object sender, EventArgs e)
        {
            this.Coordinates.ReScaleXAxis(-120);
            //this.TestUI.KeepXAxisSymmetric();

            if (!this.Comport.IsOpen)
                this.pnl_Monitor.Refresh();
        }
        #endregion
        #endregion

        private void UpdateButtonsStates()
        {
            // Run
            this.btn_SerialPort_Open.Enabled = !this.Comport.IsOpen;
            if (!btn_SerialPort_Open.Enabled)
                btn_SerialPort_Open.BackgroundImage = Resources.Run_Gray;
            else
                btn_SerialPort_Open.BackgroundImage = Resources.Run_Modified;

            // Stop
            this.btn_SerialPort_Stop.Enabled = this.Comport.IsOpen;
            if (btn_SerialPort_Stop.Enabled)
                btn_SerialPort_Stop.BackgroundImage = Resources.Stop_Blue;
            else
                btn_SerialPort_Stop.BackgroundImage = Resources.Stop_Gray;

            // Save data
            this.btn_SaveData.Enabled = !this.Comport.IsOpen;
            if (btn_SaveData.Enabled)
                btn_SaveData.BackgroundImage = Resources.save_file;
            else
                btn_SaveData.BackgroundImage = Resources.SaveData_Gray;

            // Trace X : Cancel Tracing if Necessary.
            if (g_boolTracing)
            {

                //////////////////////////////////////////////////////////////////////////
                //// Try out 2              

                //int in_panel2_x = btnTraceX.Size.Width / 2;
                //int in_panel2_y =btnTraceX.Size.Height / 2;

                // 得到 btnTraceX 的 中心的 屏幕坐标值
                //Point screen_point = this.btnTraceX.PointToScreen(new Point(in_panel2_x, in_panel2_y));
                //// 将cursor 设置为 btnTraceX  中心的屏幕坐标值
                //Cursor.Position = screen_point;

                // 重要: 由于 Control 的Location 属性是以 包含该Control 的容器Control 的 Client 坐标系为基准的
                // 而 鼠标Event 的参数 是以 Client 坐标系 表示的.

                // 将btnTraceX 的 中心的 屏幕坐标值 转换为 所在容器 panel2 的
                //Point clientscreen_point = this.panel2.PointToClient(screen_point);
                // 调试坐标系的位置 , 在 通过 panel2 的 PointToClient 方法之后 , 可以将 ObserveX  左上角 移动到 traceX 的中心.
                //btn_ObserveX.Location = clientscreen_point;
                //btnTraceX.Hide();

                //MouseEventArgs CancelTracingClick = new MouseEventArgs(MouseButtons.Left, 1, clientscreen_point.X, clientscreen_point.Y, 0);
                // 关键问题是 OnMouseClick  "好像" 不起作用.
                //OnMouseClick(CancelTracingClick);

                //////////////////////////////////////////////////////////////////////////
                // Try out 3

                // 应该也可已通过 重载 OnClick 事件 来达到目的.
                // 而不要直接调用 btnTrace_Click() .
                EventArgs args = new EventArgs();
                this.btn_TraceTicks_Click(this, args);

                //这个是 btnTrace 的母口, 当然不可以使用.
                //this.btnTraceX.Click(this , args);

                //////////////////////////////////////////////////////////////////////////
                // Try out 1
                //g_boolTracing = false;
            }

            if (this.Comport.IsOpen)
                this.Text = " Reading Serial Port ";
            else
                this.Text = "Monitor_V2.0";
        }

        private void btn_TraceTicks_Click(object sender, EventArgs e)
        {
            if (!this.Comport.IsOpen)
                g_boolTracing = false;
            else
            {
                g_boolTracing = !g_boolTracing;
                if (g_boolTracing)
                    btn_TraceTicks.BackColor = Color.Red;
                else
                    btn_TraceTicks.BackColor = Color.AntiqueWhite;
            }
        }

        private void btn_SaveBitmap_Click(object sender, EventArgs e)
        {
            if (this.Comport.IsOpen)
            {
                MessageBox.Show("Stop the port first");
            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Save Bitmap";
                dlg.DefaultExt = ".jpg";
                dlg.AddExtension = true;
                dlg.Filter = " BMP|*.bmp|JPEG|*.jpg;";

                // 将时间 设置为 初始文件名
                System.TimeSpan current_time = System.DateTime.Now.TimeOfDay;
                dlg.FileName = ((int)current_time.TotalMinutes).ToString() + "_" + current_time.Hours.ToString() + "_" + current_time.Minutes.ToString();

                // If OK enter , then ShowDialog return true ; else return false
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Step 1. 延迟 , 目的是 等待 SaveFileDialog 消失
                    Thread.Sleep(1000);
                    // 
                    //this.Refresh();

                    // Step 2 . 保存 没有 SaveFileDialog 的 图像 .
                    try
                    {
                        // 创建一个"空白"位图 , 本质上就是 在 VDRAM 中 开辟一段存储空间
                        Bitmap bitmap = new Bitmap(pnl_Monitor.Width, pnl_Monitor.Height);
                        // 创建GDI 图元 , 对指定的 VDRAM 中的 存储单元 进行数据的设置/写入
                        Graphics g = Graphics.FromImage(bitmap);
                        // 从屏幕所在的 VDRAM 存储单元中 拷贝内存块 . 
                        // 注意 , 由于截图实际上并非连续的 存储单元 , 而是 象素数组中 某个 区域 , 也就是说 , 从 一维内存模型 来看
                        //  这一片区域 实际上 是 几段 不连续 内存区域
                        g.CopyFromScreen(this.PointToScreen(pnl_Monitor.Location), new Point(0, 0), pnl_Monitor.Size);

                        bitmap.MakeTransparent();

                        bitmap.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Bmp);

                    }
                    catch (System.Exception exception)
                    {
                        MessageBox.Show(exception.ToString());
                    }
                }
            }
        }

        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Load Dataset";
            dlg.DefaultExt = ".txt";
            dlg.AddExtension = true;
            dlg.Filter = "Text|*.txt";

            // If OK enter , then ShowDialog return true ; else return false
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ////////////////////////////////////////////////////////////////////////// 清空"先前" 显示的dataset
                Monitor_ReStart();

                //////////////////////////////////////////////////////////////////////////  从文件中"一次性" 读取数据
                string IV_Columns_Data = File.ReadAllText(dlg.FileName);

                ///////////// 删除 newline 
                // Tryout 1 : Trim can only remove leading / tailing characters
                // IV_Columns_Data = IV_Columns_Data.Trim('\r', '\n');

                // Tryout 2 : Regular Expression
                // 通过正则式 , 去除 \t \r \ n 
                IV_Columns_Data = Regex.Replace(IV_Columns_Data, @"\t|\n|\r", " ");

                // Tryout 3 : Normal String Replacement

                ////////////////////////////////////////////////////////////////////////// 
                // 分割存储各个 dataset  的数据    
                // 根据 空格 划分 strings , 并存储在 string 数组中
                string[] split_data = IV_Columns_Data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // 得到每个channel 的 数据长度 ( 每个channel必须相等)
                int fence = split_data.Length / 4;
                // foreach (List<Int16> list in g_i16ChannelDataset) 
                //    list.
                // 给每个通道赋值
                for (int index = 0; index < fence; ++index)
                {
                    g_i16ChannelDataset[0].Add(Convert.ToInt16(split_data[4 * index + 0]));
                    g_i16ChannelDataset[1].Add(Convert.ToInt16(split_data[4 * index + 1]));
                    g_i16ChannelDataset[2].Add(Convert.ToInt16(split_data[4 * index + 2]));
                    g_i16ChannelDataset[3].Add(Convert.ToInt16(split_data[4 * index + 3]));
                }

                //this.Text = dlg.SafeFileName;  // SafeFileName : filename.extension
                this.Text = dlg.FileName;

                ////////////////////////////////////////////////////////////////////////// 刷新
                this.pnl_Monitor.Refresh();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            MessageBox.Show("yes");
        }

        private void btn_PickZone_Click(object sender, EventArgs e)
        {
            g_boolPicking = !g_boolPicking;
            if (!g_boolPicking)
            {
                btn_PickZone.BackColor = Color.BlanchedAlmond;
                this.pnl_Monitor.Cursor = Cursors.Hand;
            }
            else
            {
                btn_PickZone.BackColor = Color.WhiteSmoke;
                this.pnl_Monitor.Cursor = Cursors.Cross;
            }
        }

        private void pnlCoord_OnMouseEnter(object sender, EventArgs e)
        {
            this.pnl_Monitor.Focus();
        }

        private void pnlCoord_OnMouseLeave(object sender, EventArgs e)
        {

        }
    }
}
