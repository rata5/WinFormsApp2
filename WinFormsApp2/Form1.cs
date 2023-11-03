using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Image originalImage { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(dialog.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double downscaleFactor))
            {
                if (pictureBox1.Image != null)
                {

                    Image downsizedImage = DownsizeImage(pictureBox1.Image, downscaleFactor);
                    pictureBox1.Image = downsizedImage;
                }
            }
        }

        private Image DownsizeImage(Image originalImage, double downscaleFactor)
        {
            int newWidth = (int)(originalImage.Width * downscaleFactor / 100);
            int newHeight = (int)(originalImage.Height * downscaleFactor / 100);


            Bitmap downsizedBitmap = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(downsizedBitmap))
            {

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }
            return downsizedBitmap;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
