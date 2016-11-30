using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Asistente.Properties;
using Telerik.WinControls.Drawing;
using Telerik.WinControls.UI;
using System.IO;
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
            radButton1.Visible = false;
            // res.Location
            // Calculate location (etc. 1366 Width - form size...)
            reproductor.settings.setMode("loop", true);
            PlayVideo(buscandoname);
            c.OnCapturing += C_OnCapturing;
            c.OnNoCapturing += C_OnNoCapturing;
          //  reproductor.PlayStateChange += Reproductor_PlayStateChange;
        }

        private void Reproductor_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (reproductor.playState == WMPPlayState.wmppsMediaEnded)
            {
                if (reproductor.URL.Contains(generico) || reproductor.URL.Contains(ubicacion))
                {
                    HideLabels();
                   PlayVideo(interactuando);
                }
            }
        }

        private void Browser_Play(object p)
        {
            radButton1.Visible = true;
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
            radButton1.Visible = false;
         if(b.Visible)
                b.Close();
            if (!reproductor.URL.Contains(buscandoname))
            {
                PlayVideo(buscandoname);
            }
            
        }

        private void C_OnCapturing()
        {
            radButton1.Visible = true;
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
        private void radButton1_Click(object sender, EventArgs e)
        {
            radButton1.Visible = false;
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
    }
}
