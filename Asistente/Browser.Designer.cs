namespace Asistente
{
    partial class Browser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statuslabel = new Telerik.WinControls.UI.RadLabel();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.Propiedades = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.Exit = new Telerik.WinControls.UI.RadMenuItem();
            this.Atras = new Telerik.WinControls.UI.RadMenuItem();
            this.Alante = new Telerik.WinControls.UI.RadMenuItem();
            this.Refrescar = new Telerik.WinControls.UI.RadMenuItem();
            this.Home = new Telerik.WinControls.UI.RadMenuItem();
            this.Imprimir = new Telerik.WinControls.UI.RadMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            ((System.ComponentModel.ISupportInitialize)(this.statuslabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            this.radMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statuslabel
            // 
            this.statuslabel.Location = new System.Drawing.Point(401, 5);
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(55, 18);
            this.statuslabel.TabIndex = 0;
            this.statuslabel.Text = "radLabel1";
            this.statuslabel.ThemeName = "VisualStudio2012Dark";
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.AccessibleDescription = "Archivo";
            this.radMenuItem1.AccessibleName = "Archivo";
            this.radMenuItem1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.Propiedades,
            this.radMenuSeparatorItem1,
            this.Exit});
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Archivo";
            this.radMenuItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // Propiedades
            // 
            this.Propiedades.AccessibleDescription = "Propiedades";
            this.Propiedades.AccessibleName = "Propiedades";
            this.Propiedades.Name = "Propiedades";
            this.Propiedades.Text = "Propiedades";
            this.Propiedades.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.Propiedades.Click += new System.EventHandler(this.Propiedades_Click);
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.AccessibleDescription = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.AccessibleName = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // Exit
            // 
            this.Exit.AccessibleDescription = "radMenuItem3";
            this.Exit.AccessibleName = "radMenuItem3";
            this.Exit.Name = "Exit";
            this.Exit.Text = "Exit";
            this.Exit.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Atras
            // 
            this.Atras.AccessibleDescription = "Atras";
            this.Atras.AccessibleName = "Atras";
            this.Atras.Name = "Atras";
            this.Atras.Text = "Atras";
            this.Atras.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            // 
            // Alante
            // 
            this.Alante.AccessibleDescription = "Alante";
            this.Alante.AccessibleName = "Alante";
            this.Alante.Name = "Alante";
            this.Alante.Text = "Alante";
            this.Alante.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.Alante.Click += new System.EventHandler(this.Alante_Click);
            // 
            // Refrescar
            // 
            this.Refrescar.AccessibleDescription = "Refrescar";
            this.Refrescar.AccessibleName = "Refrescar";
            this.Refrescar.Name = "Refrescar";
            this.Refrescar.Text = "Refrescar";
            this.Refrescar.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.Refrescar.Click += new System.EventHandler(this.Refrescar_Click);
            // 
            // Home
            // 
            this.Home.AccessibleDescription = "Home";
            this.Home.AccessibleName = "Home";
            this.Home.Name = "Home";
            this.Home.Text = "Home";
            this.Home.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Imprimir
            // 
            this.Imprimir.AccessibleDescription = "Imprimir";
            this.Imprimir.AccessibleName = "Imprimir";
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 29);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(831, 471);
            this.webBrowser1.TabIndex = 1;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 500);
            // 
            // radMenu1
            // 
            this.radMenu1.Controls.Add(this.statuslabel);
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.Atras,
            this.Alante,
            this.Refrescar,
            this.Home,
            this.Imprimir});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.radMenu1.Size = new System.Drawing.Size(831, 29);
            this.radMenu1.TabIndex = 0;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "TelerikMetro";
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.radMenu1);
            this.Name = "Browser";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Browser";
            this.ThemeName = "VisualStudio2012Dark";
            this.Load += new System.EventHandler(this.Browser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statuslabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            this.radMenu1.ResumeLayout(false);
            this.radMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem Atras;
        private Telerik.WinControls.UI.RadMenuItem Alante;
        private Telerik.WinControls.UI.RadMenuItem Refrescar;
        private Telerik.WinControls.UI.RadMenuItem Home;
        private Telerik.WinControls.UI.RadMenuItem Imprimir;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadLabel statuslabel;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadMenuItem Propiedades;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem Exit;
        private Telerik.WinControls.UI.RadMenu radMenu1;
    }
}