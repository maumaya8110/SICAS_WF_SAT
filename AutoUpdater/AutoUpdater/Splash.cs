using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Ionic.Zip;
using System.Threading;

namespace AutoUpdater
{
    public partial class Splash : Form
    {
        public Splash(string imgsrc)
        {
            InitializeComponent();

            _ImgSrc = imgsrc;
            SetImage();
        }

        private string _ImgSrc;

        private void SetImage()
        {
            Image img = Image.FromFile(_ImgSrc);
            AppImagePictureBox.Size = img.Size;
            this.Height = img.Size.Height + 150;
            this.Width = img.Size.Width + 50;
            AppImagePictureBox.Location = new Point(25, 25);
            AppImagePictureBox.Image = img;

            LegendLabel.Location = new Point((this.Width - LegendLabel.Width)/2,this.Height - 100);
            AutoUpProgressBar.Location = new Point((this.Width - AutoUpProgressBar.Width) / 2, this.Height - 50);
        }

        private void AutoUpTimer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine(DateTime.Now);
            if (Utils.FTP_ISBUSY)
            {
                AutoUpProgressBar.Value = Utils.FTP_PERCENT;
            }
        }
    }
}
