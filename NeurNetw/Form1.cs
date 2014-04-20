using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeurNetw
{
    public partial class Form1 : Form
    {
        Network network;
        Boolean draw;

        public Form1()
        {
            InitializeComponent();
            Bitmap bm = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, bm.Width, bm.Height);
            pictureBox1.Image = bm;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox2.Refresh();
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Bitmap bm = new Bitmap(200, 200);
            Graphics g = Graphics.FromImage(bm);
            pictureBox1.Image = bm;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.network = new Network();
            Teacher t = new Teacher();
            t.getOuts("outs.txt");
            t.teach(1, network);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[] x = new ImgToVector(new Bitmap(pictureBox1.Image), this.network.signCnt).getVector();
            String result = network.recognize(x);
            try
            {
                pictureBox2.Image = Image.FromFile(result);
            }
            catch (IOException ex)
            {
                pictureBox2.Image = Image.FromFile("smile.jpgg");
            }

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.DrawRectangle(new Pen(Color.Black, 2), e.X, e.Y, 2, 2); 
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.DrawRectangle(new Pen(Color.Black, 2), e.X, e.Y, 2, 2);
                g.Dispose();
                pictureBox1.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);
            g.Dispose();
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }
    }
}
