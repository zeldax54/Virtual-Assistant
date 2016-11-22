using System;
using System.Collections.Generic;
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

   public class Capturadora
    {
        private CascadeClassifier _cascadeClassifier;
        public bool Threeminflag { get; set;}
        public bool Capturing { get; set;}
        public IImage ImagenOut { get; set; }
        public double NocaptTime { get; set; }
        //Events
        //Capturing
        public delegate void OnCapturingManager();
        public event OnCapturingManager OnCapturing;
        //No capturing
        public delegate void OnNoCapturingManager();
        public event OnNoCapturingManager OnNoCapturing;
        public void Capture(Capture capture,double elapsedTime, double nocapttime)
        {
            
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");
            if (capture.QueryFrame() != null)
            {
                var imageFrame = capture.QueryFrame().ToImage<Bgr, Byte>();

                if (imageFrame != null)
                {
                    var grayframe = imageFrame.Convert<Gray, byte>();
                    var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);

                    if (!faces.Any())
                    {
                        Capturing = false;
                        nocapttime += elapsedTime;
                        if (nocapttime > 10000)
                        {
                            OnNoCapturing?.Invoke();
                            Threeminflag = true;
                        }
                    }
                    else
                    {
                        Threeminflag = false;
                        NocaptTime = 0;
                        Capturing = true;
                        OnCapturing?.Invoke();
                    }
                        foreach (var face in faces)
                        imageFrame.Draw(face, new Bgr(Color.Green), 3);
                    ImagenOut = imageFrame;
                    NocaptTime = (nocapttime/1000);
                }
               
            }

        }




    }
}
