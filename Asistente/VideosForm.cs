using System;
using System.Drawing;
using System.Windows.Forms;
using AxWMPLib;
using Telerik.WinControls.UI;
using WMPLib;

namespace Asistente
{
    public partial class VideosForm : RadForm
    {
        public VideosForm()
        {
            InitializeComponent();
        }

        private const string Buscandoname = "buscando.mp4";
        private const string Interactuando = "interactuando.mp4";
        private const string Generico = "generico.mp4";
        private const string Ubicacion = "ubicacion.mp4";
        private  const string Foto = "foto.mp4";
        public Capturadora C;
        private Form1 _form;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            reproductor.uiMode = "none";
            Location = new Point(0);
            _form = new Form1();
            _form.Location = new Point(Location.X + Size.Width);
            _form.Fotoevent -= Form_fotoevent;
            _form.Fotoevent += Form_fotoevent;
            C = _form.Capt;
            _form.Show();
          //  _form.Visible = false;
            // res.Location
            // Calculate location (etc. 1366 Width - form size...)
            reproductor.settings.setMode("loop", true);
            PlayVideo(Buscandoname);
            C.OnCapturing += C_OnCapturing;
            C.OnNoCapturing += C_OnNoCapturing;
           reproductor.PlayStateChange += Reproductor_PlayStateChange;
        }


        private void VideosForm_Load(object sender, EventArgs e)
        {
            HideLabels();
            HidePanel();
        }

        private void Form_fotoevent()
        {
            HideLabels();
            PlayVideo(Foto,true);
        }

        private void Reproductor_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if ((WMPPlayState)e.newState == WMPPlayState.wmppsStopped)
            {
                if (reproductor.URL.Contains(Generico) || reproductor.URL.Contains(Ubicacion)
                    || reproductor.URL.Contains(Foto))
                {
                    
                    reproductor.Ctlcontrols.currentPosition = reproductor.currentMedia.duration;
                    reproductor.Ctlcontrols.play();
                    reproductor.Ctlcontrols.pause();
                }
            }
        }

        private void Browser_Play(object p)
        {
            ShowPanel();
            if (p == null)
            {
                if (!reproductor.URL.Contains(Generico))
                    PlayVideo(Generico,true);
            }
           else
            {
                string[] labels = (string[]) p;
                ShowLabels(labels[0],labels[1]);
                    PlayVideo(Ubicacion,true);
            }
        }

        private void C_OnNoCapturing()
        {
            HideLabels();
           HidePanel();
         if(b!=null && b.Visible)
                b.Close();
            if (_form != null && _form.Visible)
                _form.Visible = false;

            if (!reproductor.URL.Contains(Buscandoname))
            {
                PlayVideo(Buscandoname);
            }
            
        }

        private void C_OnCapturing()
        {
           ShowPanel();
            if ((!reproductor.URL.Contains(Interactuando) && !reproductor.URL.Contains(Ubicacion) &&
                !reproductor.URL.Contains(Generico) && !reproductor.URL.Contains(Foto)) || reproductor.playState == WMPPlayState.wmppsStopped || reproductor.playState == WMPPlayState.wmppsPaused)
            {
                PlayVideo(Interactuando);
                HideLabels();
            }
        }

        private void PlayVideo(string videoname,bool loop=false)
        {
            if(loop)
                reproductor.settings.setMode("loop", false);
            else
                reproductor.settings.setMode("loop", true);
            
            reproductor.URL = "Resources\\" + videoname;
           // reproductor.settings.autoStart = true;
          
            reproductor.Ctlcontrols.play();
           // Text = reproductor.playState.ToString();
        }

        //private string GetUrl(string videoname)
        //{
        //    return "Resources\\" + videoname;
        //}

        private Browser b;
      
        private void radButton1_Click(object sender, EventArgs e)
        {
            HidePanel();
            b = new Browser();
            b.Location = new Point(Location.X+Size.Width);
            b.Play += Browser_Play;
            b.ShowDialog();
            radButton1.Visible = true;
        }

        private void HideLabels()
        {
            radLabel1.Visible = false;
            radLabel2.Visible = false;
        }

        private void ShowLabels(string texto1,string texto2)
        {
            radLabel1.Text = @"Pasillo:"+texto1;
            radLabel2.Text = @"Estante:"+texto2;
            radLabel1.Visible = true;
            radLabel2.Visible = true;
        }

        private void ShowPanel()
        {
            radGroupBox1.Visible = true;
        }
        private void HidePanel()
        {
            radGroupBox1.Visible = false;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            _form.Visible = true;
        }

        
    }
}
