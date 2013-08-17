using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Monitor;

namespace GraphicsControls
{
    public enum RangeTestResult { IN_RANGE = 0, TOP = 1, BOTTOM, RIGHT,OUTRANGE } ;

    public class derivedCoordinatesBox : baseCoordinatesBox
    {
        /// <summary>
        /// 成员变量
        /// </summary>
        private static float k_f_ZoomOutRatio;
        private static float k_f_ZoomInRatio;

        private static int k_nMaxTicks_XAxis;
        private static int k_nMinTicks_XAxis;
        private static int k_nMaxTick_YAxis;
        private static int k_nMinTicks_YAxis;

        private static float m_f_MaxXScaleValue;
        private static float m_f_MinXScaleValue;

        private static float m_f_MaxYScaleValue;
        private static float m_f_MinYScaleValue;

        /// <summary>
        /// CoordinatesUI 构造函数
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="XIdent"></param>
        /// <param name="YIdent"></param>
        /// <param name="MaxXUnit"></param>
        /// <param name="MinXUnit"></param>
        /// <param name="MaxYUnit"></param>
        /// <param name="MinYUnit"></param>
        public derivedCoordinatesBox(int Width, int Height, int XIdent, int YIdent , int MaxXUnit , int MinXUnit , int MaxYUnit , int MinYUnit )
            : base()
        {
            this.CanvasWidth = Width;
            this.CanvasHeight = Height;

            // 设置边距 ( 单位 : pixel ) 
            this.BoxIndent_XAxis = XIdent;
            this.BoxIndent_YAxis = YIdent;


            // set the tick value ( quantity of unscaled data per tick of the grid
            this.DataAmountPerTick_XAxis = 10;
            this.DataAmountPerTick_YAxis = 10;

            //////////////////////////////////////////////////////////////////////////
            k_f_ZoomOutRatio = 1.5F;
            k_f_ZoomInRatio = 0.666F;

            k_nMaxTicks_XAxis = MaxXUnit;
            k_nMinTicks_XAxis = MinYUnit;
            k_nMaxTick_YAxis = MaxYUnit;
            k_nMinTicks_YAxis = MinYUnit;

            m_f_MaxYScaleValue = m_nCoordBoxHeight / k_nMinTicks_YAxis; // 6 units
            m_f_MinYScaleValue = m_nCoordBoxHeight / k_nMaxTick_YAxis; // 8 units

            m_f_MaxXScaleValue = m_nCoordBoxWitdh / k_nMinTicks_XAxis; // 10 units
            m_f_MinXScaleValue = m_nCoordBoxWitdh / k_nMaxTicks_XAxis; //  13 units

            // set the scale value
            this.PixelPerTick_XAxis = (int)((m_f_MinXScaleValue + m_f_MaxXScaleValue) * 0.5);
            this.PixelPerTick_YAxis = (int)((m_f_MinYScaleValue + m_f_MaxYScaleValue) * 0.5);

        }

        public void ResizeCoordinateBox( int width , int height  )
        {
            float ratio_X = width / this.CanvasWidth;
            float ratio_Y = height / this.CanvasHeight;

            this.CanvasWidth = width;
            this.CanvasHeight = height;

            m_f_MaxYScaleValue = m_nCoordBoxHeight / k_nMinTicks_YAxis; // 6 units
            m_f_MinYScaleValue = m_nCoordBoxHeight / k_nMaxTick_YAxis; // 8 units

            m_f_MaxXScaleValue = m_nCoordBoxWitdh / k_nMinTicks_XAxis; // 10 units
            m_f_MinXScaleValue = m_nCoordBoxWitdh / k_nMaxTicks_XAxis; //  13 units

            if (ratio_X > 1)  // Larger
                this.PixelPerTick_XAxis =(int) ( m_nCoordBoxWitdh / k_nMinTicks_XAxis );
            else
                this.PixelPerTick_XAxis = (int)(m_nCoordBoxWitdh / k_nMaxTicks_XAxis);

            if (ratio_Y > 1)
                this.PixelPerTick_YAxis = (int)(m_nCoordBoxHeight / k_nMinTicks_YAxis);
            else
                this.PixelPerTick_YAxis = (int)(m_nCoordBoxHeight / k_nMaxTick_YAxis);

            this.KeepXAxisSymmetric();
            this.KeepYAxisSymmetric();
        }

        // 测试是否超出 当前坐标系的范围
        // 输入: 转换后的 像素点
        // 输出: 超出哪一个边界
        public RangeTestResult IsInCoordinateBox(Point pixel)
        {
            // 假设 WorkSpace 即为 "CoordinateUI 得到的Graphics所属控件" ,则 该控件的location 和 CoordinateUI 的 Location" 
            if (pixel.Y < 0 || pixel.X < 0)
                return RangeTestResult.OUTRANGE;

            // 超出 Top X , 即以屏幕坐标来看, Y 值 < 0 + kYAxisIdent
            if (pixel.Y < BoxIndent_YAxis + 0)
                return RangeTestResult.TOP;

            // 超出 Right Y , 即以屏幕坐标轴, X 值 > Width - kXAxisIdent
            if (pixel.X > CanvasWidth - BoxIndent_XAxis + 0)
                return RangeTestResult.RIGHT;

            // 超出 Bottom X
            if (pixel.Y > CanvasHeight - BoxIndent_YAxis + 0)
                return RangeTestResult.BOTTOM;

            return RangeTestResult.IN_RANGE;
        }

        // 将 数据点 转换为 像素点
        // 输入: 之所以为 PointF 是因为 TranslateX 和 TranslateY 的输入为float
        // 输出: 同样 , TranslateX 和 TranslateY的返回值为int
        public Point DataToPixel( int x  , int y )
        {
            return new Point(base.DataToPixelOffset_XAxis(x), base.DataToPixelOffset_YAxis(y));
        }

        //沿着X轴平移
        //根据 鼠标事件的象素的改变
        public int MoveAlongXAxis(float delta_pixel)
        {
            int delta = (int)(delta_pixel * this.DataAmountPerTick_XAxis / this.PixelPerTick_XAxis);
            this.OriginX += delta;

            return (int) delta; 
        }

        //沿着Y轴平移
        // 原理和沿着X轴同样
        public int MoveAlongYAxis(float delta_pixel)
        {
            int delta = (int)(delta_pixel * this.DataAmountPerTick_YAxis / this.PixelPerTick_YAxis);
            this.Origin_Y += delta;

            return (int) delta;
        }

        //
        //
        public void SetDtRngXTick( int  nVal )
        {
            this.DataAmountPerTick_XAxis = nVal;

            this.KeepXAxisSymmetric();
        }
        public void SetDtRngYTick( int nVal )
        {
            this.DataAmountPerTick_YAxis = nVal;

            this.KeepYAxisSymmetric();
        }

        public int SetXScreenScale
        {
            get
            {
                return PixelPerTick_XAxis;
            }
            set
            {
                PixelPerTick_XAxis = value;
                this.KeepXAxisSymmetric();
            }
        }
        //放缩X轴  
        // MaxXScaleValue :最大网格的Width MinScaleValue :最小网格的 Width
        // 2012/4/30 : 应该在放缩之后 ,原来的X轴屏幕中心也然是现在的X轴屏幕中心
        public int ReScaleXAxis(int round)
        {
            float ratio = 0;
            float previous_center_x = this.OriginX + m_nCoordBoxWitdh / (2 * this.PixelPerTick_XAxis) * this.DataAmountPerTick_XAxis ;

            ////////////////////////////////////////////////////////////////////////// 确定 放大/缩小 系数
            if ( round >= 120  ) // zoom in
                ratio = k_f_ZoomInRatio;
            else 
            {
                if ( round <= -120 ) // zoom out 
                    ratio = k_f_ZoomOutRatio;
                else
                    return 0 ; 
            }

            ////////////////////////////////////////////////////////////////////////// 确定 RealXTickValue 和 XScreeScale
            if (round > 0)  // zoom in
            {
                if (this.PixelPerTick_XAxis < m_f_MaxXScaleValue * ratio)  // in range , so we scale the ScreenScale
                    this.PixelPerTick_XAxis = (int)(this.PixelPerTick_XAxis / ratio);
                else
                {
                    this.DataAmountPerTick_XAxis = Math.Max((int)(ratio * m_f_MinXScaleValue / this.PixelPerTick_XAxis * this.DataAmountPerTick_XAxis), 1);
                    this.PixelPerTick_XAxis = (int)m_f_MinXScaleValue;
                }
            }
            else  // zoom out , range increase , ratio >1 
            {
                if (this.PixelPerTick_XAxis > m_f_MinXScaleValue * ratio)
                    this.PixelPerTick_XAxis = (int)(this.PixelPerTick_XAxis / ratio);
                else
                {
                    this.DataAmountPerTick_XAxis = Math.Min((int)(ratio * m_f_MaxXScaleValue / this.PixelPerTick_XAxis * this.DataAmountPerTick_XAxis), 0x7fffffff);
                    this.PixelPerTick_XAxis = (int)m_f_MaxXScaleValue;
                }
            }

            // Bad Flavor : 这个共更能不应该在此出现, 
            // 但当时是否有有别的考虑呢 ?

            this.AnchorXAxisCenter(previous_center_x);

            return 1;
        }

        private void AnchorXAxisCenter( float center_x )
        {
            this.OriginX = center_x - m_nCoordBoxWitdh / (2 * this.PixelPerTick_XAxis) * this.DataAmountPerTick_XAxis;
        }

        //放缩Y轴
        // 解释 类比X轴
        public int ReScaleYAxis(int round)
        {
            ////////////////////////////////////////////////////////////////////////// Scale the value first
            /// 这一部分可以再优化: 预先计算一个临界值, 然后与这个临界值比较 而不必先 做乘法
            float ratio = 0 ;

            float previous_center_y = this.Origin_Y + m_nCoordBoxHeight / (2 * this.PixelPerTick_YAxis) * this.DataAmountPerTick_YAxis;

            //////////////////////////////////////////////////////////////////////////
            if (round >= 120) // zoom in
                ratio = k_f_ZoomInRatio;
            else
            {
                if (round <= -120) // zoom out 
                    ratio = k_f_ZoomOutRatio;
                else
                    return 0;
            }

            if ( round > 0 )  // zoom in
            {
                if (this.PixelPerTick_YAxis < m_f_MaxYScaleValue * ratio)  // in range , so we scale the ScreenScale
                    this.PixelPerTick_YAxis =(int)(this.PixelPerTick_YAxis / ratio );
                else
                {
                    this.DataAmountPerTick_YAxis = Math.Max((int)(ratio * m_f_MinYScaleValue / this.PixelPerTick_YAxis * this.DataAmountPerTick_YAxis), 1);
                    this.PixelPerTick_YAxis = (int)m_f_MinYScaleValue;
                }
            }
            else  // zoom out , range increase , ratio >1 
            {
                if (this.PixelPerTick_YAxis > m_f_MinYScaleValue * ratio)
                    this.PixelPerTick_YAxis = (int)(this.PixelPerTick_YAxis / ratio);
                else
                {
                    this.DataAmountPerTick_YAxis = Math.Min((int)(ratio * m_f_MaxYScaleValue / this.PixelPerTick_YAxis * this.DataAmountPerTick_YAxis), 0x7fffffff);
                    this.PixelPerTick_YAxis = (int)m_f_MaxYScaleValue;
                }
            }

            this.AnchorYAxisCenter(previous_center_y);

            return 1;
        }
        private void AnchorYAxisCenter(float center_y)
        {
            this.Origin_Y = center_y - m_nCoordBoxHeight / (2 * this.PixelPerTick_YAxis) * this.DataAmountPerTick_YAxis;
        }

        //  整体放大和缩小
        //  Round : 正 放大 ; 负 : 缩小
        public void ReScaleXYAxis(int round)
        {
            this.ReScaleXAxis(round);
            this.ReScaleYAxis(round);
        }

        #region Not Necessary
        // 坐标原点重置
        // 
        public void MoveToOrigin()
        {
            this.KeepYAxisSymmetric();
            this.KeepXAxisSymmetric();
        }
        #endregion

        // 维持X 轴对称
        //
        private void KeepYAxisSymmetric()
        {
            this.Origin_Y = 0 - (int)(m_nCoordBoxHeight / (2 * this.PixelPerTick_YAxis) * this.DataAmountPerTick_YAxis);
        }

        // 维持Y 轴对称
        //
        private void KeepXAxisSymmetric()
        {
            this.OriginX = 0 - (int)(m_nCoordBoxWitdh / (2 * this.PixelPerTick_XAxis) * this.DataAmountPerTick_XAxis);
        }

        // X 轴跟随
        //
        public void TraceXAxis( int counts )
        {
            if ( counts!=0  )
            {
                // 1. 计算当前 X 的 range
                int tmp_nXAxisDisplayRange = (int)(m_nCoordBoxWitdh / this.PixelPerTick_XAxis * this.DataAmountPerTick_XAxis);

                // 2 .如果超出,则平移"一格"的距离
                if ( counts >(int)this.OriginX + tmp_nXAxisDisplayRange  ) 
                {
                    // 3. 平移 1个 网格
                    //MoveAlongXAxis( this.XScreenScale * 1);

                    // 3.移动到前沿
                    MoveToXAxisFrontier(counts);
                }
            }
        }

        private void MoveToXAxisFrontier(int nXFrontier)
        {
            this.OriginX = (int)(nXFrontier - m_nCoordBoxWitdh / this.PixelPerTick_XAxis * this.DataAmountPerTick_XAxis);
        }

        // 通过"象素"级别的"计算"来达到 "数据定位" 的精度
        // 计算 X 的 "工程值" , 实际上 , X 即为数据的 "单位时间内" 采样次数.
        public int PixelOffsetToData_XAxis(int pixel_x)
        {
            return (int)((float)(pixel_x - this.BoxIndent_XAxis) / this.PixelPerTick_XAxis * DataAmountPerTick_XAxis + this.OriginX);
        }

        // 计算 Y 的 "工程值" 
        // 但是 , 其实我们通过采样点
        public int PixelOffsetToData_YAxis( int pixel_y) 
        {
            return 0;
        }

        //绘制 Y=0 轴
        public void DrawXOriginAxis( Graphics g ) 
        {
            // Set the DashCap to round.
            Pen linePen = new Pen(Color.SkyBlue);
            linePen.DashCap = System.Drawing.Drawing2D.DashCap.Round;

            // Create a custom dash pattern.
            linePen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };

            // 如果 TranslateX/Y 是 >= , 那么当在坐标原点的情况,就会判定为 - 1 即 超界
            Point p1_pixel =this.DataToPixel( (int)this.OriginX /*+1*/ , 0 ) ;
            Point p2_pixel = new Point( (int)this.CanvasWidth- this.BoxIndent_XAxis , p1_pixel.Y ) ;

            // Draw Horizonal
            g.DrawLine(linePen, p1_pixel, p2_pixel);

        }

        // 放大某个区域
        // 这里要考虑的是 ,究竟将数据验证放在何处 ?
        // 这里假设的是数据都是有效而合理的
        public void ZoomZone( int Xmin , int Xmax , int Ymin , int Ymax )
        {
            this.DataAmountPerTick_XAxis = Math.Abs(Xmax - Xmin) / (k_nMaxTicks_XAxis - 2);
            this.DataAmountPerTick_YAxis = Math.Abs(Ymax - Ymin) / (k_nMaxTick_YAxis - 2) * 2 ;   // * 2 是为了后面的 KeepYAxisSymmetric 

            this.OriginX = 0 - DataAmountPerTick_XAxis; // 0 - RealXTickValue * 1 ( 2/2 : 即保持 原点距离 最左边有一个tick 的距离)

            this.KeepYAxisSymmetric();
        }

        public int MaxIndex_XAxis
        {
            get
            {
                return PixelOffsetToData_XAxis(m_pArray_Corners[(byte)CornersIndex.RightUp].X);
            }
        }

    }
}
