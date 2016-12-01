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
        private CascadeClassifier _cascadeClassifierfaces;
        private CascadeClassifier _cascadeClassifiereyes;
        public bool Threeminflag { get; set; }
        public bool Capturing { get; set; }
        public IImage ImagenOut { get; set; }


        //Events
        //Capturing
        public delegate void OnCapturingManager();

        public event OnCapturingManager OnCapturing;
        //No capturing
        public delegate void OnNoCapturingManager();

        public event OnNoCapturingManager OnNoCapturing;


        public void Capture(Capture capture, ref double elapsedTime, ref double nocapttime)
        {
            if (capture.QueryFrame() != null)
            {
                var imageFrame = capture.QueryFrame().ToImage<Bgr, Byte>();
                if (imageFrame != null)
                {
                    var grayframe = imageFrame.Convert<Gray, byte>();
                    _cascadeClassifierfaces = new CascadeClassifier(Application.StartupPath + "/face.xml");
                    _cascadeClassifiereyes = new CascadeClassifier(Application.StartupPath + "/eye.xml");
                    var faces = _cascadeClassifierfaces.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
                    var eyes = _cascadeClassifiereyes.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
                    if (!faces.Any() || !eyes.Any())
                    {
                        Capturing = false;
                        nocapttime += elapsedTime;
                        if (nocapttime > 10000)
                        {
                            OnNoCapturing?.Invoke();
                            Threeminflag = true;
                            elapsedTime = 0;
                            nocapttime = 0;
                        }
                    }
                    else
                    {
                        Threeminflag = false;
                        nocapttime = 0;
                        Capturing = true;
                        OnCapturing?.Invoke();
                        elapsedTime = 0;
                        foreach (var face in faces)
                            imageFrame.Draw(face, new Bgr(Color.Green), 3, Emgu.CV.CvEnum.LineType.FourConnected);
                        foreach (var eye in eyes)
                            imageFrame.Draw(eye, new Bgr(Color.Aqua), 3, Emgu.CV.CvEnum.LineType.AntiAlias);
                    }
                }
                ImagenOut = imageFrame?.SmoothGaussian(5, 5, 2, 0);
                nocapttime = (nocapttime/1000);
            }
        }




    }
}
