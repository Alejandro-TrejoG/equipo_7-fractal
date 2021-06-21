using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConjuntoMandelbrot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MandelbrotSet();
        }
        private void MandelbrotSet() 
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            Bitmap bmp = new Bitmap(width, height);

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col ++)
                {
                    double c_re = (col - width / 2.0) * 4.0 / width;
                    double c_im = (row - height / 2.0) * 4.0 / height;
                    int iteracion = 0;
                    double x = 0, y = 0;

                    while (iteracion<1000 && ((x*x) + (y*y)<=4)) 
                    {
                        double x_temp = (x * x) - (y * y) + c_re;
                        y = 2 * x * y + c_im;
                        x = x_temp;
                        iteracion++;
                    }

                    if (iteracion < 1000)
                    {
                        bmp.SetPixel(col, row, Color.FromArgb(iteracion%128, iteracion%50*5, iteracion%10));
                    }
                    else
                    {
                        bmp.SetPixel(col, row, Color.Black);
                    }
                }
            }
            pictureBox1.Image = bmp;
        }
    }
}
