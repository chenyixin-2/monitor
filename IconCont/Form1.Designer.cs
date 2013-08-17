namespace IconCont
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_LoadBitmap = new System.Windows.Forms.Button();
            this.btn_SaveIcon = new System.Windows.Forms.Button();
            this.picb_Box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_LoadBitmap
            // 
            this.btn_LoadBitmap.Location = new System.Drawing.Point(62, 52);
            this.btn_LoadBitmap.Name = "btn_LoadBitmap";
            this.btn_LoadBitmap.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadBitmap.TabIndex = 0;
            this.btn_LoadBitmap.Text = "Load";
            this.btn_LoadBitmap.UseVisualStyleBackColor = true;
            this.btn_LoadBitmap.Click += new System.EventHandler(this.btn_LoadBitmap_Click);
            // 
            // btn_SaveIcon
            // 
            this.btn_SaveIcon.Location = new System.Drawing.Point(62, 103);
            this.btn_SaveIcon.Name = "btn_SaveIcon";
            this.btn_SaveIcon.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveIcon.TabIndex = 1;
            this.btn_SaveIcon.Text = "2 Icon";
            this.btn_SaveIcon.UseVisualStyleBackColor = true;
            this.btn_SaveIcon.Click += new System.EventHandler(this.btn_SaveIcon_Click);
            // 
            // picb_Box
            // 
            this.picb_Box.Location = new System.Drawing.Point(259, 52);
            this.picb_Box.Name = "picb_Box";
            this.picb_Box.Size = new System.Drawing.Size(215, 202);
            this.picb_Box.TabIndex = 2;
            this.picb_Box.TabStop = false;
            this.picb_Box.Paint += new System.Windows.Forms.PaintEventHandler(this.picb_Box_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 352);
            this.Controls.Add(this.picb_Box);
            this.Controls.Add(this.btn_SaveIcon);
            this.Controls.Add(this.btn_LoadBitmap);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picb_Box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_LoadBitmap;
        private System.Windows.Forms.Button btn_SaveIcon;
        private System.Windows.Forms.PictureBox picb_Box;
    }
}

