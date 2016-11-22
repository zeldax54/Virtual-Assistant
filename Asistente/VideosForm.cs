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
        public Capturadora c;
        
        private void VideosForm_Load(object sender, EventArgs e)
        {
            Point center = new Point(radButton1.Parent.Width / 2, radButton1.Parent.Height / 2);
            int x = center.X;// - average.X;
            int y = center.Y; //- average.Y;
            radButton1.Location = new Point(x,y);
            reproductor.settings.setMode("loop", true);
            PlayVideo(buscandoname);
            c.OnCapturing += C_OnCapturing;
            c.OnNoCapturing += C_OnNoCapturing;
        }

    

        private void C_OnNoCapturing()
        {
            if (!reproductor.URL.Contains(buscandoname))
                PlayVideo(buscandoname);
        }

        private void C_OnCapturing()
        {
           if(!reproductor.URL.Contains(interactuando))
                PlayVideo(interactuando);
        }

        private void PlayVideo(string videoname)
        {
            reproductor.URL = "Resources\\" + videoname;
            reproductor.settings.autoStart = true;
        }

        private string GetUrl(string videoname)
        {
            return "Resources\\" + videoname;;
        }

    }
}
