using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Telerik.WinControls.UI;



namespace Asistente
{
    public partial class Form1 : RadForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private  Capture _capture;
        private readonly Capturadora _capt=new Capturadora();
        Timer _timer;
        private Timer _watcher;
        private double _nocaptimevar;
        private double _elapsedtime;
        //////////////////
    
        private void Form1_Load(object sender, EventArgs e)
        {
           
            //   imgCamUser.ZoomScale = 2.0;  // zoom in by 2x
            Rectangle res = Screen.PrimaryScreen.Bounds;
            // Calculate location (etc. 1366 Width - form size...)
            this.Location = new Point(res.Width - Size.Width,res.Height-Size.Height);
            _capture = new Capture();
            _timer=new Timer();
          //  _timer.Interval = 1;
            _timer.Tick += Timer_Tick;
            _timer.Start();

            _watcher = new Timer();
         //   _watcher.Interval = 100;
            _watcher.Tick += Watcher;
            _watcher.Start();
           //
            //  this.WindowState= FormWindowState.Minimized;
            //Hide();
            VideosForm f=new VideosForm();
            f.c = _capt;
            f.Show();
        }

        private void Watcher(object sender, EventArgs e)
        {
            imgCamUser.Image = (IImage) _capt.ImagenOut;
            imgCamUser.SetZoomScale(0.5, new Point(0, 0));
            nocapttime.Text = _nocaptimevar.ToString(CultureInfo.InvariantCulture);
        
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _elapsedtime += _timer.Interval;
            _capt.Capture(_capture,ref _elapsedtime,ref _nocaptimevar);
        }

       

    }
}
