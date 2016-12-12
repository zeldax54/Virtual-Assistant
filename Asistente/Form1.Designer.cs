namespace Asistente
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imgCamUser = new Emgu.CV.UI.ImageBox();
            this.fotocapt = new System.Windows.Forms.PictureBox();
            this.compartir = new Telerik.WinControls.UI.RadButton();
            this.foto = new Telerik.WinControls.UI.RadButton();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotocapt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compartir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 394F));
            this.tableLayoutPanel1.Controls.Add(this.imgCamUser, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fotocapt, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.compartir, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.foto, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radMenu1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(683, 356);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // imgCamUser
            // 
            this.imgCamUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgCamUser.Location = new System.Drawing.Point(3, 33);
            this.imgCamUser.Name = "imgCamUser";
            this.imgCamUser.Size = new System.Drawing.Size(283, 290);
            this.imgCamUser.TabIndex = 2;
            this.imgCamUser.TabStop = false;
            // 
            // fotocapt
            // 
            this.fotocapt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fotocapt.Image = global::Asistente.Properties.Resources.none;
            this.fotocapt.InitialImage = ((System.Drawing.Image)(resources.GetObject("fotocapt.InitialImage")));
            this.fotocapt.Location = new System.Drawing.Point(292, 33);
            this.fotocapt.Name = "fotocapt";
            this.fotocapt.Size = new System.Drawing.Size(388, 290);
            this.fotocapt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fotocapt.TabIndex = 3;
            this.fotocapt.TabStop = false;
            // 
            // compartir
            // 
            this.compartir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.compartir.Location = new System.Drawing.Point(438, 329);
            this.compartir.Name = "compartir";
            this.compartir.Size = new System.Drawing.Size(95, 24);
            this.compartir.TabIndex = 5;
            this.compartir.Text = "Compartir";
            this.compartir.ThemeName = "VisualStudio2012Dark";
            this.compartir.Click += new System.EventHandler(this.compartir_Click);
            // 
            // foto
            // 
            this.foto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.foto.Location = new System.Drawing.Point(101, 329);
            this.foto.Name = "foto";
            this.foto.Size = new System.Drawing.Size(87, 24);
            this.foto.TabIndex = 4;
            this.foto.Text = "Foto";
            this.foto.ThemeName = "VisualStudio2012Dark";
            this.foto.Click += new System.EventHandler(this.foto_Click);
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1});
            this.radMenu1.Location = new System.Drawing.Point(3, 3);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.radMenu1.Size = new System.Drawing.Size(283, 24);
            this.radMenu1.TabIndex = 6;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "VisualStudio2012Dark";
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.AccessibleDescription = "Cerrar";
            this.radMenuItem1.AccessibleName = "Cerrar";
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Cerrar";
            this.radMenuItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radMenuItem1.Click += new System.EventHandler(this.radMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 356);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
           
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.ThemeName = "VisualStudio2012Dark";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotocapt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compartir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Emgu.CV.UI.ImageBox imgCamUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox fotocapt;
        private Telerik.WinControls.UI.RadButton foto;
        private Telerik.WinControls.UI.RadButton compartir;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
    }
}

