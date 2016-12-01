using System;
using System.Drawing;
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

        private readonly string buscandoname = "buscando.mp4";
        private readonly string interactuando = "interactuando.mp4";
        private readonly string generico = "generico.mp4";
        private readonly string ubicacion = "ubicacion.mp4";
        public Capturadora c;
        private void VideosForm_Load(object sender, EventArgs e)
        {
            HideLabels();
            HidePanel();
            // res.Location
            // Calculate location (etc. 1366 Width - form size...)
            reproductor.settings.setMode("loop", true);
            PlayVideo(buscandoname);
            c.OnCapturing += C_OnCapturing;
            c.OnNoCapturing += C_OnNoCapturing;
          //  reproductor.PlayStateChange += Reproductor_PlayStateChange;
        }

        //private void Reproductor_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        //{
        //    if (reproductor.playState == WMPPlayState.wmppsMediaEnded)
        //    {
        //        if (reproductor.URL.Contains(generico) || reproductor.URL.Contains(ubicacion))
        //        {
        //           HideLabels();
        //           PlayVideo(interactuando);
        //        }
        //    }
        //}

        private void Browser_Play(object p)
        {
            ShowPanel();
            if (p == null)
            {
                if (!reproductor.URL.Contains(generico))
                    PlayVideo(generico,true);
            }
           else
            {
                string[] labels = (string[]) p;
                ShowLabels(labels[0],labels[1]);
                    PlayVideo(ubicacion,true);
            }
        }

        private void C_OnNoCapturing()
        {
            HideLabels();
           HidePanel();
         if(b!=null && b.Visible)
                b.Close();
            if (t != null && t.Visible)
                t.Close();

            if (!reproductor.URL.Contains(buscandoname))
            {
                PlayVideo(buscandoname);
            }
            
        }

        private void C_OnCapturing()
        {
           ShowPanel();
            if ((!reproductor.URL.Contains(interactuando) && !reproductor.URL.Contains(ubicacion) &&
                !reproductor.URL.Contains(generico))|| reproductor.playState == WMPPlayState.wmppsStopped)
            {
                PlayVideo(interactuando);
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
            reproductor.settings.autoStart = true;
        }

        private string GetUrl(string videoname)
        {
            return "Resources\\" + videoname;;
        }

        private Browser b;
        private TakePic t;
        private void radButton1_Click(object sender, EventArgs e)
        {
            HidePanel();
            Location = new Point(0);
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
            t = new TakePic();
            t.ShowDialog();
           
        }
    }
}
