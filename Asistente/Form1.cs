using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Telerik.WinControls.UI;

namespace Asistente
{
    public partial class Form1 : RadForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Capture _capture;
        private readonly Capturadora _capt=new Capturadora();
        Timer _timer;
        private Timer _watcher;
        private double nocaptimevar = 0;
        private double _elapsedtime;
      
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
            _capture = new Capture();
            _timer=new Timer();
            _timer.Tick += Timer_Tick;
            _timer.Start();

            _watcher = new Timer();
            _watcher.Interval = 100;
            _watcher.Tick += Watcher;
            _watcher.Start();
          
            //  this.WindowState= FormWindowState.Minimized;
            //Hide();
            VideosForm f=new VideosForm();
            f.c = _capt;
            f.Show();
        }

        private void Watcher(object sender, EventArgs e)
        {
            imgCamUser.Image = (IImage) _capt.ImagenOut;
            nocapttime.Text = _capt.NocaptTime.ToString(CultureInfo.InvariantCulture);
            if (_capt.Capturing)
            {
                _elapsedtime = 0;
            }
          
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _elapsedtime += _timer.Interval;
            _capt.Capture(_capture,  _elapsedtime, nocaptimevar);
            if (_capt.Threeminflag)
            {
                _elapsedtime = 0;
                _capt.NocaptTime = 0;

            }
          

        }

       

    }
}
