using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Bitmap originalImage { get; private set; }

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

                    Bitmap downsizedImage = DownsizeImage((Bitmap)pictureBox1.Image, downscaleFactor);
                    pictureBox1.Image = downsizedImage;
                }
            }
        }

        private Bitmap DownsizeImage(Bitmap originalImage, double downscaleFactor)
        {
            int newWidth = (int)(originalImage.Width * downscaleFactor / 100);
            int newHeight = (int)(originalImage.Height * downscaleFactor / 100);


            Bitmap downsizedBitmap = new Bitmap(newWidth, newHeight);

            for (int i = 0; i < newHeight; i++)
            {
                for (int j = 0; j < newWidth; j++)
                {
                    int X = (int)(i / downscaleFactor * originalImage.Width);
                    int Y = (int)(j / downscaleFactor * originalImage.Height);

                    Color averageColor = originalImage.GetPixel(X, Y);

                    downsizedBitmap.SetPixel(i, j, averageColor);
                }
            }

            return downsizedBitmap;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
