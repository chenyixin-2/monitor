using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Monitor
{
    public class baseCoordinatesBox
    {
        #region  GDI+ Resources
        protected Font m_fontLabel;
        protected SolidBrush m_brushLabel;
        protected Pen m_penUI;
        protected Pen m_penGrid;
        #endregion 

        #region  Constructor & Destructor

        public baseCoordinatesBox()
        {
            m_penUI = new Pen(Color.White);

            m_penGrid = new Pen(Color.DarkGreen);
            m_penGrid.Width = 0.1F;

            m_brushLabel = new SolidBrush(Color.White);

            m_fontLabel = new Font("Arial", 10);
        }

        ~baseCoordinatesBox()
        {
            m_penUI.Dispose();
            m_penGrid.Dispose();
            m_brushLabel.Dispose();
            m_fontLabel.Dispose();
        }

        #endregion         

        #region Coordinate Parameters

        #region Inner State
        // 我希望得到这个 成员得到继承.
        protected enum SizeStateMask :byte
        {
            InitialState = 0xF0,
            SizeNormalState = 0xFF,
            CanvasWidthSetMask = 0x08, CanvasHeightSetMask = 0x04, XIndentSetMask = 0x02, YIndentSetMask = 0x01,
            CanvasWidthClearMask = 0xF7, CanvasHeightClearMask = 0xFB, XIndentClearMask = 0xFD, YIndentClearMask = 0xFE
        };
        protected SizeStateMask m_ssmSizeState = SizeStateMask.InitialState;

        protected enum CoordStateMask : byte
        {
            InitialState = 0xD0,   // 因为只需要表示 6 个参数的状态, 所以 InitialState = (1100 0000)B 
            CoordNormalState = 0xFF ,
            XTickPxlSetMask = 0x20 , XTickPxlClearMask = 0xDF,
            YTickPxlSetMask = 0x10 , YTickPxlClearMask = 0xEF,
            XTickDtRgSetMask = 0x08 , XTickDtRgClearMask = 0xF7 , 
            YTickDtRgSetMask = 0x04 , YTickDtRgClearMask = 0xFB ,
            OrgXDtValSetMask = 0x02, OrgXDtValClearMask = 0xFD ,
            OrgYDtValSetMask = 0x01, OrgYDtValClearMask = 0xFE, 
        }
        protected CoordStateMask m_csmCoordState = CoordStateMask.InitialState;

        #endregion  // constants & variable
        protected const int k_nPixelsOffset_Axis2Box = 3;
        protected const int k_nPixelsPerTick_Long = 5;
        protected const int k_nPixelsPerTcik_Short = 2;

        protected int m_nCanvasHeight = -1 ;
        protected int m_nCanvasWidth = -1 ;

        protected int m_nCoordBoxWitdh = -1 ;
        protected int m_nCoordBoxHeight = -1 ;

        protected int m_nSampleDataRange = -1;

        protected int m_nCoordBoxIndent_XAxis = -1 ;
        protected int m_nCoordBoxIndent_YAxis = -1 ;

        protected int m_nPixelsPerTick_XAxis = -1 ;
        protected int m_nPixelsPerTick_YAxis = -1 ;

        protected float m_f_DataAmountPerTick_XAxis = -1 ;
        protected float m_f_DataAmountPerTick_YAxis = -1 ;

        protected float m_fOriginValue_XAxis = -1;
        protected float m_fOriginValue_YAxis = -1;

        #region Constants
        protected const byte c_m_i8NormalState = 10;
        protected const SizeStateMask c_m_i8SizeNormalState = SizeStateMask.SizeNormalState;

        #endregion

        #endregion

        #region Workspace Corners
        private const byte k_nCornerCount = 4;
        public enum CornersIndex : byte { LeftUp = 0, RightUp, RightDown, LeftDown };
        protected Point[] m_pArray_Corners = new Point[k_nCornerCount];

        #endregion

        #region Private Methods
        #region Initialize Coordinates Boxs

        protected void InitializeCoordinateBox()
        {
            m_nCoordBoxWitdh = this.CanvasWidth - 2 * this.BoxIndent_XAxis;
            m_nCoordBoxHeight = this.CanvasHeight - 2 * this.BoxIndent_YAxis;

            m_nSampleDataRange = (int)this.m_nCoordBoxWitdh / this.m_nPixelsPerTick_XAxis * (int)this.m_f_DataAmountPerTick_XAxis;

            InitializeBoxCorners();
        }
        protected void InitializeBoxCorners()
        {
            m_pArray_Corners[(byte)CornersIndex.RightDown] = new Point(m_nCanvasWidth - m_nCoordBoxIndent_XAxis, m_nCanvasHeight - m_nCoordBoxIndent_YAxis);
            m_pArray_Corners[(byte)CornersIndex.RightUp] = new Point(m_nCanvasWidth - m_nCoordBoxIndent_XAxis, m_nCoordBoxIndent_YAxis);
            m_pArray_Corners[(byte)CornersIndex.LeftUp] = new Point(m_nCoordBoxIndent_XAxis, m_nCoordBoxIndent_YAxis);
            m_pArray_Corners[(byte)CornersIndex.LeftDown] = new Point(m_nCoordBoxIndent_XAxis, m_nCanvasHeight - m_nCoordBoxIndent_YAxis);
        }
        #endregion

        #region Draw Axis
        protected void DrawXAxis(Graphics g) 
        {
            m_penUI.DashStyle = DashStyle.Solid;

            PointF pt_start = new PointF(m_nCoordBoxIndent_XAxis, CanvasHeight - m_nCoordBoxIndent_YAxis + k_nPixelsOffset_Axis2Box );
            PointF pt_end = new PointF( CanvasWidth - m_nCoordBoxIndent_XAxis, CanvasHeight - m_nCoordBoxIndent_YAxis+ k_nPixelsOffset_Axis2Box);

            g.DrawLine( m_penUI , pt_start, pt_end);
        }
        protected void DrawYAxis(Graphics g) 
        {
            m_penUI.DashStyle = DashStyle.Solid;

            PointF pt_start = new PointF( m_nCoordBoxIndent_XAxis- k_nPixelsOffset_Axis2Box , m_nCoordBoxIndent_YAxis);
            PointF pt_end = new PointF( m_nCoordBoxIndent_XAxis - k_nPixelsOffset_Axis2Box , CanvasHeight - m_nCoordBoxIndent_YAxis);

            g.DrawLine( m_penUI , pt_start, pt_end);
        }
        #endregion

        #region Draw Box
        protected void DrawCoordinateBox( Graphics g)
        {
            // 设置为 虚线
            m_penUI.DashStyle = DashStyle.DashDot;

            // 画 直线
            for (byte enumIndex = 0; enumIndex < k_nCornerCount ;  ++enumIndex)
                g.DrawLine(m_penUI, m_pArray_Corners[enumIndex], m_pArray_Corners[(enumIndex + 1) % k_nCornerCount]);
        }
        #endregion

        #region  Draw Tick and Grid

        private void DrawTickAndGrid_XAxis(Graphics g)
        {
            System.Drawing.StringFormat string_format = new System.Drawing.StringFormat();

            ////////////////////////////////////////////////////////////////////////// X Axis
            int start_index_x = (int)(this.m_fOriginValue_XAxis / m_f_DataAmountPerTick_XAxis);
            float leftdown_corner_x = m_pArray_Corners[(byte)CornersIndex.LeftDown].X;
            float leftdown_corner_y = m_pArray_Corners[(byte)CornersIndex.LeftDown].Y;
            float rightdow_corner_x = m_pArray_Corners[(int)CornersIndex.RightDown].X;


            float delta = start_index_x * m_f_DataAmountPerTick_XAxis - this.m_fOriginValue_XAxis;
            float bias_x = m_fOriginValue_XAxis / this.m_f_DataAmountPerTick_XAxis;
            bool is_odd = false;

            while (true)
            {
                //float pixel_x = delta / this.m_f_DataAmountPerTick_XAxis * this.m_nPixelsPerTick_XAxis + m_pArray_Corners[(int)CornersIndex.LeftDown].X;
                float pixel_x = (start_index_x - bias_x) * this.m_nPixelsPerTick_XAxis + leftdown_corner_x;
                float pixel_y = leftdown_corner_y;

                if (pixel_x > rightdow_corner_x)  // out of box , so we quit the loop 
                    break;
                else
                    if (pixel_x < leftdown_corner_x) // not in the box yet , so we neglect the things to be done in the rest of the loop 
                    {
                        delta = this.m_f_DataAmountPerTick_XAxis + delta;
                        ++start_index_x;

                        continue;
                    }

                m_penUI.DashStyle = DashStyle.Solid;

                // Draw X Tick
                if (is_odd)
                    g.DrawLine(m_penUI, pixel_x, pixel_y + k_nPixelsOffset_Axis2Box, pixel_x, pixel_y + k_nPixelsPerTick_Long + k_nPixelsOffset_Axis2Box);
                else
                    g.DrawLine(m_penUI, pixel_x, pixel_y + k_nPixelsOffset_Axis2Box, pixel_x, pixel_y + k_nPixelsPerTcik_Short + k_nPixelsOffset_Axis2Box);

                // Draw Label 
                SizeF strSize = g.MeasureString(Convert.ToString(this.m_fOriginValue_XAxis + delta), m_fontLabel);
                g.DrawString(Convert.ToString(this.m_fOriginValue_XAxis + delta), m_fontLabel, m_brushLabel, pixel_x - strSize.Width / 2, pixel_y + k_nPixelsOffset_Axis2Box + k_nPixelsPerTick_Long, string_format);

                // Draw X Grid
                g.DrawLine(m_penGrid, pixel_x, pixel_y, pixel_x, pixel_y - m_nCoordBoxHeight);

                is_odd = !is_odd;

                delta = this.m_f_DataAmountPerTick_XAxis + delta;
                ++start_index_x;
            }
        }

        private void DrawTickAndGrid_YAxis(Graphics g)
        {
            System.Drawing.StringFormat string_format = new System.Drawing.StringFormat();

            ////////////////////////////////////////////////////////////////////////// Y Axis
            int start_index_y = (int)(this.m_fOriginValue_YAxis / m_f_DataAmountPerTick_YAxis);
            float leftdown_corner_x = m_pArray_Corners[(byte)CornersIndex.LeftDown].X;
            float leftdown_corner_y = m_pArray_Corners[(byte)CornersIndex.LeftDown].Y;
            float leftup_corner_y = m_pArray_Corners[(int)CornersIndex.LeftUp].Y;


            float delta = start_index_y * m_f_DataAmountPerTick_YAxis - this.m_fOriginValue_YAxis;
            float bias_y = m_fOriginValue_YAxis / this.m_f_DataAmountPerTick_YAxis;
            bool is_odd = false;

            while (true)
            {
                float pixel_x = leftdown_corner_x;
                float pixel_y = leftdown_corner_y - ( start_index_y - bias_y ) * this.m_nPixelsPerTick_YAxis;

                // 超出坐标系显示范围. 
                if (pixel_y < leftup_corner_y )
                    break;
                else
                    if (pixel_y > leftdown_corner_y )
                    {
                        delta = delta + m_f_DataAmountPerTick_YAxis;
                        ++start_index_y;
                        continue;
                    }

                m_penUI.DashStyle = DashStyle.Solid;

                // Draw  Y Tick 
                if (is_odd)
                    g.DrawLine(m_penUI, pixel_x - k_nPixelsOffset_Axis2Box, pixel_y, pixel_x - k_nPixelsPerTick_Long - k_nPixelsOffset_Axis2Box, pixel_y);
                else
                {
                    g.DrawLine(m_penUI, pixel_x - k_nPixelsOffset_Axis2Box, pixel_y, pixel_x - k_nPixelsPerTcik_Short - k_nPixelsOffset_Axis2Box, pixel_y);
                }

                // Draw Label 
                SizeF strSize = g.MeasureString(Convert.ToString(this.m_fOriginValue_YAxis + delta), m_fontLabel);
                g.DrawString(Convert.ToString(this.m_fOriginValue_YAxis + delta), m_fontLabel, m_brushLabel, pixel_x - strSize.Width - k_nPixelsPerTick_Long, pixel_y - strSize.Height / 2, string_format);

                // Draw  Y Grid
                g.DrawLine(m_penGrid, pixel_x, pixel_y, pixel_x + m_nCoordBoxWitdh, pixel_y);

                is_odd = !is_odd;

                delta = delta + m_f_DataAmountPerTick_YAxis;
                ++start_index_y;
            }
        }

        protected void DrawTickAndGrid(Graphics g)
        {
            DrawTickAndGrid_XAxis(g);
            DrawTickAndGrid_YAxis(g);
        }
        #region Draw Label
        protected void DrawXlabel(Graphics g) { }
        protected void DrawYlabel(Graphics g) { }
        #endregion

        #endregion
        #endregion

        #region Pubic Interfaces
        public void DrawCoordinate(Graphics g)
        {
            if ( m_ssmSizeState == SizeStateMask.SizeNormalState  && m_csmCoordState == CoordStateMask.CoordNormalState )
            {
                this.DrawXAxis(g);
                this.DrawYAxis(g);
                this.DrawTickAndGrid(g);

                // 放在最后一个绘制,这样Grid 就不会覆盖Box .
                this.DrawCoordinateBox(g);
            }
        }
        public int DataToPixelOffset_XAxis(float x)
        {
            float delta_x = x - m_fOriginValue_XAxis;
            if (delta_x >= 0)
                return (int)(delta_x / this.m_f_DataAmountPerTick_XAxis * this.m_nPixelsPerTick_XAxis + m_nCoordBoxIndent_XAxis);
            else
                return -1;
        }
        public int DataToPixelOffset_YAxis(float y)
        {
            float delta_y = y - m_fOriginValue_YAxis;
            if (delta_y >= 0)
                // note :  - delta / ...
                return (int)(-delta_y / this.m_f_DataAmountPerTick_YAxis * this.m_nPixelsPerTick_YAxis + m_nCoordBoxIndent_YAxis + m_nCoordBoxHeight);
            else
                return -1;
        }
        #endregion

        #region Attributes

        #region System Parameters and Varify
        /// <summary>
        /// 我的考量 : 对这些属性或者参数 提供 合法性 验证是十分必要的.
        /// 同时,考虑到有些属性 变化得比较频繁 ,而其他的则相对 稳定 , 所以 ,这种验证机制 不应该做的很复杂.
        /// 这样, 既提高了鲁棒性 ,性能损失又很小.
        /// </summary>
        public int CanvasHeight
        {
            get { return m_nCanvasHeight; }
            set 
            {
                m_ssmSizeState = m_ssmSizeState & SizeStateMask.CanvasHeightClearMask;
                m_nCanvasHeight = value;

                if (value > 0)
                    m_ssmSizeState = m_ssmSizeState | SizeStateMask.CanvasHeightSetMask;

                if  ( (m_ssmSizeState & c_m_i8SizeNormalState) == c_m_i8SizeNormalState)
                    this.InitializeCoordinateBox();
             }
        }
        public int CanvasWidth
        {
            get { return m_nCanvasWidth;}
            set
            {
                m_ssmSizeState = m_ssmSizeState & SizeStateMask.CanvasWidthClearMask;
                m_nCanvasWidth = value;

                if (value > 0)
                    m_ssmSizeState = m_ssmSizeState | SizeStateMask.CanvasWidthSetMask;

                if ((m_ssmSizeState & c_m_i8SizeNormalState) == c_m_i8SizeNormalState)
                    this.InitializeCoordinateBox();
            } 
        }

        public int BoxIndent_XAxis
        {
            get { return m_nCoordBoxIndent_XAxis; }
            set 
            {
                m_ssmSizeState = m_ssmSizeState & SizeStateMask.XIndentClearMask ;
                m_nCoordBoxIndent_XAxis = value;

                if (value > 0)
                    m_ssmSizeState = m_ssmSizeState | SizeStateMask.XIndentSetMask;

                if ((m_ssmSizeState & c_m_i8SizeNormalState) == c_m_i8SizeNormalState)
                    this.InitializeCoordinateBox();
            }            
        }
        public int BoxIndent_YAxis
        {
            get { return m_nCoordBoxIndent_YAxis; }
            set 
            {
                m_ssmSizeState = m_ssmSizeState & SizeStateMask.YIndentClearMask;
                m_nCoordBoxIndent_YAxis = value;

                if (value > 0)
                    m_ssmSizeState = m_ssmSizeState | SizeStateMask.YIndentSetMask;

                if ((m_ssmSizeState & c_m_i8SizeNormalState) == c_m_i8SizeNormalState)
                    this.InitializeCoordinateBox();
            }
        }

        public int PixelPerTick_XAxis
        {
            get
            {
                return m_nPixelsPerTick_XAxis;
            }
            set
            {
                m_csmCoordState = m_csmCoordState & CoordStateMask.XTickPxlClearMask ;
                m_nPixelsPerTick_XAxis = value;


                if (value > 0)
                    m_csmCoordState = m_csmCoordState | CoordStateMask.XTickPxlSetMask;
            }
        }
        public int PixelPerTick_YAxis
        {
            get
            {
                return m_nPixelsPerTick_YAxis;
            }
            set
            {
                m_csmCoordState = m_csmCoordState & CoordStateMask.YTickPxlClearMask;
                m_nPixelsPerTick_YAxis = value;

                if (value > 0)
                    m_csmCoordState = m_csmCoordState | CoordStateMask.YTickPxlSetMask;
            }
        }

        public float DataAmountPerTick_XAxis
        {
            get
            {
                return m_f_DataAmountPerTick_XAxis;
            }
            set
            {
                m_csmCoordState = m_csmCoordState & CoordStateMask.XTickDtRgClearMask;

                // 如果 tickvalue < 10  ,则 以 "1" 为分度单位 ; 否则 , 以 "10" 为分度单位 .
                if (value < 10)
                    m_f_DataAmountPerTick_XAxis = value;
                else  
                   m_f_DataAmountPerTick_XAxis = (int)((value * 0.1) * 10);
                   //m_fDataRangePerXAxisTick = (int) value / 10 * 10;
                
                    // 下面的这段代码 , 会导致 TickValue 到达 10 之后无法"继续"放缩的问题.
                    // 注意到 , 区别在于 , value * 0.1 先被转换成了 整形数 , 再 * 10 . 理论上 ,这应该是没有问题的呀 .
                    // m_fDataRangePerXAxisTick = (int)(value * 0.1) * 10;

                // 总结 : 
                // 虽然做出了修改 , 但是 , 在 分度值 为 " 1 " 的时候 ,仍然无法恢复 .
                // 这很有可能是由于 X/YAxis 放大时,"缩放系数" 乘法结果阶段时造成的问题. 造成的.
                // 需要一个更加精良的参数系统 . 

                if (value > 0)
                    m_csmCoordState = m_csmCoordState | CoordStateMask.XTickDtRgSetMask;
            }
        }
        public float DataAmountPerTick_YAxis
        {
            get 
            {
                return m_f_DataAmountPerTick_YAxis ;
            }
            set
            {
                m_csmCoordState = m_csmCoordState & CoordStateMask.YTickDtRgClearMask;
                
                if (value < 10)
                    m_f_DataAmountPerTick_YAxis = value;
                else
                    m_f_DataAmountPerTick_YAxis = (int)((value * 0.1) * 10);

                if (value > 0)
                    m_csmCoordState = m_csmCoordState | CoordStateMask.YTickDtRgSetMask;
            }
        }

        public float OriginX
        {
            get
            {
                return m_fOriginValue_XAxis;
            }
            set
            {
                m_csmCoordState = m_csmCoordState & CoordStateMask.OrgXDtValClearMask;
                //if (value < 10)
                // 应该将 数值的具体控制 放置在"属性设置"中 , 
                // 因为 , 对外提供什么样的接口 , 就不应该 外界参数传递的时候 , 采用 强制转换的 方式 .
                m_fOriginValue_XAxis = (int) value;         
                //else
                //    m_fOriginXDataValue = (int)(value * 0.1) * 10;

                    m_csmCoordState = m_csmCoordState | CoordStateMask.OrgXDtValSetMask;
            }
        }
        public float Origin_Y 
        {
            get
            {
                return m_fOriginValue_YAxis;
            }
            set
            {
                m_csmCoordState = m_csmCoordState & CoordStateMask.OrgYDtValClearMask;

                //if (value < 10)
                m_fOriginValue_YAxis = (int) value;
                //else
                //    m_fOriginYDataValue = (int)(value * 0.1) * 10;

                    m_csmCoordState = m_csmCoordState | CoordStateMask.OrgYDtValSetMask;
            }
        }
        #endregion

        #region Other Attributes
        ////////// 可有可无 , 因而 也未实现
        //public string LabelRightY { get; set; }
        //public string LabelX { get; set; }
        //public string LabelY { get; set; }

        //public int YInterval { get; set; }
        //public int XInterval { get; set; }

        //public string YVirtualValue { get; set; }
        //public string XVirtualValue { get; set; }
        #endregion

        #endregion
    }
}
