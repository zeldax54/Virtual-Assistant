using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Drawing.Imaging;

using System.IO;

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Streams;
using Telerik.WinControls.UI;

using System.Windows;
using System.Runtime.Serialization;




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
            compartir.Enabled = false;
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
                string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tmpimg.jpg");
                //   string dirWM = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tmpimgWM.Bmp");
                Bitmap img = imgCamUser.Image.Bitmap;
                Bitmap wm = new Bitmap("Resources\\WM.png");
                // img.Save(dir);
                //  WatermarkImage(dir, "Centro Multimedia @", dirWM, ImageFormat.Bmp);
                DrawWatermark(wm, img, 10, 10);
                fotocapt.Image = img;
                img.Save(dir,ImageFormat.Jpeg);
                this.dir = dir;
                foto.Enabled = true;
                compartir.Enabled = true;

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
            compartir.Enabled = false;
            _fotoworker.RunWorkerAsync();
            Fotoevent?.Invoke();
        }

     

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        //Share

        DataTransferManagerHelper dtmHelper;
        private void Form1_Shown(object sender, EventArgs e)
        {
            dtmHelper = new DataTransferManagerHelper(this.Handle);
            dtmHelper.DataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.DataRequested);
        }


        string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tmpimg.jpg");
        List<IStorageItem> filesToShare = null;
        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            try
            {
                Bitmap b = fotocapt.Image as Bitmap;
                DataPackage dataPackage = e.Request.Data;
                dataPackage.Properties.Title = "Foto";
                dataPackage.Properties.Description = "Compartido desde Centro Multimedia.";
               // dataPackage.SetData(DataFormats.Bitmap,b);
                //var resourceName = dir;
                //var html = String.Format("<p>HTML content</p><img src='{0}'/>", resourceName);
                //dataPackage.ResourceMap[resourceName] = RandomAccessStreamReference.CreateFromUri(
                //    new Uri(dir));
                //dataPackage.SetHtmlFormat(HtmlFormatHelper.CreateHtmlFormat(html));
                //
                dataPackage.SetStorageItems(filesToShare);
                //RandomAccessStreamReference imageStreamRef = RandomAccessStreamReference.CreateFromFile((IStorageFile)filesToShare[0]);

                //dataPackage.Properties.Thumbnail = imageStreamRef;

                //dataPackage.SetBitmap(imageStreamRef);
            }
            catch (Exception ee)
            {

            }
        }
        private async void compartir_Click(object sender, EventArgs e)
        {
            try
            {
               
                filesToShare = new List<IStorageItem>();
                var cont =  await StoreImageFromClipboardAsync();
                var file= await Put(cont);
                await Fill(file);
                dtmHelper.ShowShareUI();
                return;
            }
            catch (Exception ee)
            {

              
            }
            //  Windows.UI.ApplicationSettings.SettingsPane.Show();
            // FormStuffs.ShowMensaje("Comming Soon!!!");+
            // this.EnsureDataTransferManager();
           
        }
        private async Task Fill(StorageFile f )
        {
             filesToShare.Add(f);
        }
        private async Task<StorageFile> Put(IAsyncOperation<StorageFile> p)
        {
            return p.GetResults();
        }

        private async Task<IAsyncOperation<StorageFile>> StoreImageFromClipboardAsync()
        {
          return  await Task.Run(() => GetUno());
           
            //Code to work with myValues here...
            // filesToShare.Add(ifile);
        }

        private async Task<IAsyncOperation<StorageFile>> GetUno()
        {
            return StorageFile.GetFileFromPathAsync(dir);
        }




    }
}
