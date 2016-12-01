using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Telerik.WinControls.UI;

namespace Asistente
{
    public partial class TakePic : RadForm
    {
        public TakePic()
        {
            InitializeComponent();
        }
        private Timer _t=new Timer();

        private void TakePic_Load(object sender, EventArgs e)
        {
            _t.Tick += _t_Tick;
            _t.Start();
        }

        private void _t_Tick(object sender, EventArgs e)
        {
           SendImage();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tmpimg.Bmp");
             //   string dirWM = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tmpimgWM.Bmp");
                Bitmap img = picbox.Image.Bitmap;
                Bitmap wm = new Bitmap("Resources\\WM.png");
               // img.Save(dir);
              //  WatermarkImage(dir, "Centro Multimedia @", dirWM, ImageFormat.Bmp);
                DrawWatermark(wm, img, 10, 10);
                img.Save(dir);
                Process.Start(dir);
            }
            catch (Exception ee)
            {
                FormStuffs.ShowMensaje(@"Ha ocurrido un problema mientras se tomaba la foto.Intente mas tarde."+'\n'+ee.Message);

            }
        }

        private Capture c=new Capture();

        private void SendImage()
        {
            c.QueryFrame();
            var imageFrame = c.QueryFrame().ToImage<Bgr, Byte>();
            picbox.Image = imageFrame?.SmoothGaussian(5, 5, 2, 0);
        }



        public void WatermarkImage(string sourceImage, string text, string targetImage, ImageFormat fmt)
        {
            try
          {
                // open source image as stream and create a memorystream for output

                    FileStream source = new FileStream(sourceImage, FileMode.Open);
                    Stream output = new MemoryStream();
                    Image img = Image.FromStream(source);
                    Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
	                //choose color and transparency
                    Color color = Color.FromArgb(100, 255, 0, 0);
	                //location of the watermark text in the parent image
                    Point pt = new Point(10, 5);
                    SolidBrush brush = new SolidBrush(color);
	                //draw text on image
                    Graphics graphics = Graphics.FromImage(img);
                    graphics.DrawString(text, font, brush, pt);
                    graphics.Dispose();
	                //update image memorystream
                    img.Save(output, fmt);
                    Image imgFinal = Image.FromStream(output);
	                //write modified image to file
                    Bitmap bmp = new System.Drawing.Bitmap(img.Width, img.Height, img.PixelFormat);
                    Graphics graphics2 = Graphics.FromImage(bmp);
                    graphics2.DrawImage(imgFinal, new Point(0, 0));
                    bmp.Save(targetImage, fmt);
                    imgFinal.Dispose();
                    img.Dispose();

                }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
      }

        // Copy the watermark image over the result image.
        private void DrawWatermark(Bitmap watermark_bm,Bitmap result_bm, int x, int y)
        {
            const byte ALPHA = 128;
            // Set the watermark's pixels' Alpha components.
            Color clr;
            for (int py = 0; py < watermark_bm.Height; py++)
            {
                for (int px = 0; px < watermark_bm.Width; px++)
                {
                    clr = watermark_bm.GetPixel(px, py);
                    watermark_bm.SetPixel(px, py,
                        Color.FromArgb(ALPHA, clr.R, clr.G, clr.B));
                }
            }

            // Set the watermark's transparent color.
            watermark_bm.MakeTransparent(watermark_bm.GetPixel(0, 0));

            // Copy onto the result image.
            using (Graphics gr = Graphics.FromImage(result_bm))
            {
                gr.DrawImage(watermark_bm, x, y);
                
            }
        }
    }
}
