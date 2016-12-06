using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Telerik.WinControls.UI;


using Timer = System.Windows.Forms.Timer;
 

namespace Asistente
{
  
    public partial class Form1 : RadForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        public readonly Capturadora Capt=new Capturadora();
        Timer _timer;
        private double _nocaptimevar;
        private double _elapsedtime;
        readonly BackgroundWorker _fotoworker=new BackgroundWorker();
        public delegate void FotoManager();
        public event FotoManager Fotoevent;
        //////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            // Rectangle res = Screen.PrimaryScreen.Bounds;
            // this.Location = new Point(res.Width - Size.Width,res.Height-Size.Height);
            _timer =new Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 1;
            //  _timer.Start();
            Application.Idle += Application_Idle;
            //  this.WindowState= FormWindowState.Minimized;
            _fotoworker.DoWork += _fotoworker_DoWork;
            _fotoworker.RunWorkerCompleted += _fotoworker_RunWorkerCompleted;

          }
        private void _timer_Tick(object sender, EventArgs e)
        {
            _elapsedtime += _timer.Interval;
            Capt.Capture(ref _elapsedtime, ref _nocaptimevar, imgCamUser);
            Text = ((int) _nocaptimevar/10).ToString();
          //  Text =(_elapsedtime/10).ToString();
        }

        private void _fotoworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tmpimg.Bmp");
                //   string dirWM = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tmpimgWM.Bmp");
                Bitmap img = imgCamUser.Image.Bitmap;
                Bitmap wm = new Bitmap("Resources\\WM.png");
                // img.Save(dir);
                //  WatermarkImage(dir, "Centro Multimedia @", dirWM, ImageFormat.Bmp);
                DrawWatermark(wm, img, 10, 10);
                fotocapt.Image = img;
                img.Save(dir);
                foto.Enabled = true;
                // Process.Start(dir);
            }
            catch (Exception ee)
            {
                FormStuffs.ShowMensaje(@"Ha ocurrido un problema mientras se tomaba la foto.Intente mas tarde." + '\n' + ee.Message);
            }
            foto.Enabled = true;
            Capt.StopRecon = false;
        }

        private void DrawWatermark(Bitmap watermarkBm, Bitmap resultBm, int x, int y)
        {
            const byte ALPHA = 128;
            // Set the watermark's pixels' Alpha components.
            Color clr;
            for (int py = 0; py < watermarkBm.Height; py++)
            {
                for (int px = 0; px < watermarkBm.Width; px++)
                {
                    clr = watermarkBm.GetPixel(px, py);
                    watermarkBm.SetPixel(px, py,
                        Color.FromArgb(ALPHA, clr.R, clr.G, clr.B));
                }
            }

            // Set the watermark's transparent color.
            watermarkBm.MakeTransparent(watermarkBm.GetPixel(0, 0));

            // Copy onto the result image.
            using (Graphics gr = Graphics.FromImage(resultBm))
            {
                gr.DrawImage(watermarkBm, x, y);

            }
        }

        private void _fotoworker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i < 7; i++)
            {
                if(i==4)
                    Capt.StopRecon = true;
                Thread.Sleep(1000);
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            _elapsedtime += _timer.Interval;
            Capt.Capture(ref _elapsedtime, ref _nocaptimevar, imgCamUser);
            Text = ((int)_nocaptimevar/1000).ToString();
        }

        private void foto_Click(object sender, EventArgs e)
        {
             foto.Enabled = false;
            _fotoworker.RunWorkerAsync();
            Fotoevent?.Invoke();
        }
  
        private void compartir_Click(object sender, EventArgs e)
        {
          //  Windows.UI.ApplicationSettings.SettingsPane.Show();
            FormStuffs.ShowMensaje("Comming Soon!!!");
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }




    }
 }
