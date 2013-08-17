using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IconCont
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //////////////////////////////////////////////////////////////////////////
            picb_Box_Configure() ;
        }

        private void btn_LoadBitmap_Click(object sender, EventArgs e)
        {
                OpenFileDialog dlg = new OpenFileDialog();
            
                dlg.Title = "Load Bitmap";
                dlg.DefaultExt = ".bmp";
                dlg.AddExtension = true;
                dlg.Filter = " BMP|*.bmp";

                // If OK enter , then ShowDialog return true ; else return false
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picb_Box.BackgroundImage = Image.FromFile(dlg.FileName);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.ToString());
                    }
                }
        }

        private void picb_Box_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btn_SaveIcon_Click(object sender, EventArgs e)
        {
           SaveFileDialog dlg = new SaveFileDialog();

            dlg.Title = "Save Icon";
            dlg.DefaultExt = ".bmp";
            dlg.AddExtension = true;
            dlg.Filter = " BMP|*.bmp";

            // If OK enter , then ShowDialog return true ; else return false
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(picb_Box.BackgroundImage);
                    IntPtr hIcon = bitmap.GetHicon();

                    Icon icon = Icon.FromHandle(hIcon);
                    this.Icon = icon;

                    FileStream fs = new FileStream( dlg.FileName , FileMode.Create);
                    icon.Save(fs);

                    icon.Dispose();
                     fs.Close();

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
            }
        }

        private void picb_Box_Configure()
        {
         }
    }
}
