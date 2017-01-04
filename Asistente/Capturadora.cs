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
        private readonly CascadeClassifier _cascadeClassifierfaces= new CascadeClassifier(Application.StartupPath + "/face.xml");
        private readonly CascadeClassifier _cascadeClassifiereyes= new CascadeClassifier(Application.StartupPath + "/eye.xml");
     
        //Capturing Events
        public delegate void OnCapturingManager();
        public event OnCapturingManager OnCapturing;
        //No capturing Events
        public delegate void OnNoCapturingManager();
        public event OnNoCapturingManager OnNoCapturing;

        private readonly Capture _capture;
        public bool StopRecon;
        private const int Stoptime = 300000;

       
        public Capturadora()
        {
            _capture = new Capture();
            //_capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 640);
           // _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 480);
             _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 1280);
            _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 1024);
            _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 30);
          
        }

        public void Capture(ref double elapsedTime, ref double nocapttime,ImageBox imgCamUser)
        {
            
                if (_capture.QueryFrame() != null)
                {
                    var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>();
                    if (imageFrame != null && !StopRecon)
                    {
                        var grayframe = imageFrame.Convert<Gray, byte>();
                        var faces = _cascadeClassifierfaces.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
                        var eyes = _cascadeClassifiereyes.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
                        if (!faces.Any() || !eyes.Any())
                        {
                           
                            nocapttime += elapsedTime;
                            if (nocapttime >= Stoptime)
                            {
                                OnNoCapturing?.Invoke();
                                elapsedTime = 0;
                                nocapttime = 0;
                            }
                        }
                        else
                        {
                            nocapttime = 0;
                            OnCapturing?.Invoke();
                            elapsedTime = 0;
                            foreach (var face in faces)
                                imageFrame.Draw(face, new Bgr(Color.LightGreen), 3, Emgu.CV.CvEnum.LineType.FourConnected);
                        foreach (var eye in eyes)
                            imageFrame.Draw(eye, new Bgr(Color.Aqua), 3, Emgu.CV.CvEnum.LineType.AntiAlias);
                    }
                    }
                    imgCamUser.SetZoomScale(0.5, new Point(0, 0));
                    imgCamUser.Image = imageFrame;
                }
            
           
        }





    }
}
