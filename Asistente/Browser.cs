using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using WMPLib;

namespace Asistente
{
    public partial class Browser : RadForm
    {
        public Browser()
        {
            InitializeComponent();
        }

        public delegate void PlayVideoManager(object p);
        public event PlayVideoManager Play;

        private void Browser_Load(object sender, EventArgs e)
        {
            webBrowser1.CanGoBackChanged += (webBrowser1_CanGoBackChanged);
            webBrowser1.CanGoForwardChanged += (webBrowser1_CanGoForwardChanged);
            webBrowser1.DocumentTitleChanged += (webBrowser1_DocumentTitleChanged);
            webBrowser1.StatusTextChanged += (webBrowser1_StatusTextChanged);
            // Load the user's home page.
            webBrowser1.NewWindow += WebBrowser1_NewWindow;
            webBrowser1.DocumentCompleted += LoadCompleteEventHandler;
            // webBrowser1.GoHome();
          //  webBrowser1.Navigate("C:/Users/HL/Desktop/busquedas/20161129123234/index.html");
           webBrowser1.Navigate("http://biblioteca.iae.edu.ar/uhtbin/cgisirsi.exe/x/x/0/49/");
          
        }

        private void LoadCompleteEventHandler(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection elements = webBrowser1.Document.GetElementsByTagName("input");

            foreach (HtmlElement input in elements)
            {
                if (input.GetAttribute("type").ToLower() == "text" || input.GetAttribute("type").ToLower() == "password")
                {
                   input.GotFocus += (o, args) => VirtualKeyBoardHelper.AttachTabTip();
                   input.LostFocus += (o, args) => VirtualKeyBoardHelper.RemoveTabTip();
                }
            }
            if (webBrowser1.Document.Title.Contains("Resultados del catálogo"))
            {
                HtmlElementCollection uls = webBrowser1.Document.GetElementsByTagName("form");
                HtmlElementCollection links = null;
                HtmlElementCollection inputs = null;
                List<HtmlElement> inputsf = new List<HtmlElement>();
                HtmlElement resultform = uls.Cast<HtmlElement>().Where(elem => elem.Id == "hitlist").ToList().FirstOrDefault();
                if (resultform != null && resultform.Children.Count > 0)
                {
                    links = resultform.GetElementsByTagName("a");
                    inputs = resultform.GetElementsByTagName("input");
                }
                //foreach (HtmlElement i in inputs)
                //    if (i.Id!=null && i.Id.Contains("VIEW"))
                //        inputsf.Add(i);

                if (links != null && links.Count > 0)
                    foreach (HtmlElement a in links)
                    {

                        a.Click -= A_Click;
                        a.Click += A_Click;
                    }
            }
          
           
            //foreach (HtmlElement ipf in inputsf)
            //{
              
            //    ipf.Click += A_Click;
            //}    
            //if (inputs != null)
            //{
            //    var htmlElements = inputs as HtmlElement[] ?? inputs.ToArray();
            //    if(htmlElements.Any())
            //        foreach (HtmlElement i in htmlElements)
            //        {
            //            i.Click += A_Click;
            //        }
            //}
        }


        private void A_Click(object sender, HtmlElementEventArgs e)
        {
            
            HtmlElement elem = (HtmlElement) sender;
            if (elem.Parent != null)
            {
                if (elem.OuterHtml.ToLower().Contains("</a>"))
                {
                    HtmlElement parent = elem.Parent.Parent;
                    var dd = parent?.GetElementsByTagName("dd").Cast<HtmlElement>().FirstOrDefault(a => a.OuterHtml.ToLower().Contains("call_number"));
                    if (dd != null)
                    {
                        string[] datos = Helper.PasilloEstante(dd.InnerHtml);
                        if (datos == null)
                        {
                            Play?.Invoke(null);
                        }
                        else
                        {
                            Play?.Invoke(datos);
                        }

                    }
                }
                //if (elem.Id.ToLower().Contains("view"))
                //{
                //    HtmlElement parent = elem.Parent.Parent?.GetElementsByTagName("dd").Cast<HtmlElement>().FirstOrDefault(a => a.OuterHtml.ToLower().Contains("call_number"));
                //    if (parent != null)
                //    {
                //        MessageBox.Show(parent.InnerHtml);
                //    }
                //}

            }
        }

        private void WebBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            webBrowser1.Navigate(webBrowser1.StatusText);
        }

        private void webBrowser1_CanGoBackChanged(object sender, EventArgs e)
        {
            Atras.Enabled = webBrowser1.CanGoBack;
        }
        private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
        {
            Alante.Enabled = webBrowser1.CanGoForward;
        }
        private void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle;
        }
        private void webBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            statuslabel.Text=webBrowser1.StatusText;
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void Alante_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Refrescar_Click(object sender, EventArgs e)
        {
            if (!webBrowser1.Url.Equals("about:blank"))
            {
                webBrowser1.Refresh();
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();
        }

        private void Propiedades_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPropertiesDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    internal class VirtualKeyBoardHelper
    {
        public static void AttachTabTip()
        {
            //if (!IsStart("TabTip"))
            Process.Start("TabTip.exe");

        }

        public static void RemoveTabTip()
        {
            int idproc = GetIdProcces("TabTip"); //cerrando proceso
            if (idproc != -1)
                Process.GetProcessById(idproc).Kill();
        }

        private static bool IsStart(string nameProcces)
        {
            var asProccess = Process.GetProcessesByName(nameProcces);
            return asProccess.Any();
        }

        private static int GetIdProcces(string nameProcces)
        {
            try
            {
                Process[] asProccess = Process.GetProcessesByName(nameProcces);
                foreach (Process pProccess in asProccess.Where(pProccess => pProccess.MainWindowTitle == ""))
                    return pProccess.Id;
                return -1;
            }
            catch
            {
                return -1;
            }
        }
    }
}
