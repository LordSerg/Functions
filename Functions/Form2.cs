using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Functions
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bit);
        }

        float Y_com(float x)
        {
            return Y_odnor(x) + Y_NEodnor(x);
        }
        //ДР:
        //y'' - 6y' + 9y = 4x^2 - 2x + 6
        float Y_odnor1(float x)
        {//общее однородного ур.
            return C1*(float)Math.Pow(Math.E,3*x)+C2*x* (float)Math.Pow(Math.E,3*x);
        }
        float Y_NEodnor1(float x)
        {//частное неоднородного ур.
            return (4.0f / 9) * x * x + (7.0f / 27) * x + (20.0f / 27);
        }
        //ДР:
        //y'' - 7y' + 6y = sinx
        float Y_odnor(float x)
        {//общее однородного ур.
            return C1 * (float)Math.Pow(Math.E, 6 * x) + C2 * (float)Math.Pow(Math.E, x);
        }
        float Y_NEodnor(float x)
        {//частное неоднородного ур.
            return (7.0f / 74) *(float)Math.Cos(x) + (5.0f / 74) * (float)Math.Sin(x);
        }
        float C1, C2;
        Bitmap bit;
        Graphics g;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            C1 = (float)trackBar1.Value / 1000.0f;
            label1.Text = C1.ToString();
            Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            C2 = (float)trackBar2.Value / 1000.0f;
            label2.Text = C2.ToString();
            Draw();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            if(pictureBox1.Width>0&&pictureBox1.Height>0)
            {
                bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(bit);
            }
            Draw();
        }

        private void Draw2()
        {
            g.Clear(Color.White);
            float fromX=float.Parse(textBox1.Text),
                toX= float.Parse(textBox2.Text), step;
            float fromY = float.Parse(textBox3.Text),
                toY = float.Parse(textBox4.Text);
            step = (toX - fromX) / (float)pictureBox1.Width;
            float y,y1;
            for(float i=fromX;i<=toX;i+=step)
            {
                if (checkBox1.Checked)
                {//общ_однор
                    //y = Y_odnor(i);
                    //if (y > fromY && y < toY)
                    //    bit.SetPixel((int)((float)pictureBox1.Width * i /(toX-fromX)),
                    //        (int)((float)pictureBox1.Height * (toY-y) /(toY-fromY)), Color.Red);

                    y = Y_odnor(i);
                    y1 = Y_odnor(i+ step);

                    if((y > fromY && y < toY)&& (y1 > fromY && y1 < toY))
                    g.DrawLine(new Pen(Color.Red), (float)pictureBox1.Width * i / (toX - fromX), (float)pictureBox1.Height * (toY - y) / (toY - fromY),
                        (float)pictureBox1.Width * (i+ step) / (toX - fromX), (float)pictureBox1.Height * (toY - y1) / (toY - fromY));
                }
                if (checkBox2.Checked)
                {//част_неоднор
                    //y = Y_NEodnor(i);
                    //if (y > fromY && y < toY)
                    //    bit.SetPixel((int)((float)pictureBox1.Width * i / (toX - fromX)),
                    //        (int)((float)pictureBox1.Height * (toY - y) / (toY - fromY)), Color.Green);
                    y = Y_NEodnor(i);
                    y1 = Y_NEodnor(i + step);

                    if ((y > fromY && y < toY) && (y1 > fromY && y1 < toY))
                        g.DrawLine(new Pen(Color.Green), (float)pictureBox1.Width * i / (toX - fromX), (float)pictureBox1.Height * (toY - y) / (toY - fromY),
                        (float)pictureBox1.Width * (i + step) / (toX - fromX), (float)pictureBox1.Height * (toY - y1) / (toY - fromY));
                }
                if (checkBox3.Checked)
                {//общее
                    //y = Y_com(i);
                    //if (y > fromY && y < toY)
                    //    bit.SetPixel((int)((float)pictureBox1.Width * i / (toX - fromX)),
                    //        (int)((float)pictureBox1.Height * (toY - y) / (toY - fromY)), Color.Blue);
                    y = Y_com(i);
                    y1 = Y_com(i + step);

                    if ((y > fromY && y < toY) && (y1 > fromY && y1 < toY))
                        g.DrawLine(new Pen(Color.Blue), (float)pictureBox1.Width * i / (toX - fromX), (float)pictureBox1.Height * (toY - y) / (toY - fromY),
                        (float)pictureBox1.Width * (i + step) / (toX - fromX), (float)pictureBox1.Height * (toY - y1) / (toY - fromY));
                }
            }
            pictureBox1.Image = bit;
        }

        private void Draw1()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            float fromX = float.Parse(textBox1.Text),
                toX = float.Parse(textBox2.Text), step;
            step = 0.1f;//(toX - fromX) / (float)pictureBox1.Width;
            //float y, y1;
            for (float i = fromX; i <= toX; i += step)
            {
                if (checkBox1.Checked)
                    chart1.Series[0].Points.AddXY(i, Y_odnor(i));
                if (checkBox2.Checked)
                    chart1.Series[1].Points.AddXY(i, Y_NEodnor(i));
                if (checkBox3.Checked)
                    chart1.Series[2].Points.AddXY(i, Y_com(i));
            }
        }
        public float Y(float x, float c1,float c2)
        {
            return c1 * (float)Math.Cos(5 * x) + c2* (float)Math.Sin(3 * x);
        }
        private void Draw()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            chart1.Series[5].Points.Clear();
            chart1.Series[6].Points.Clear();
            chart1.Series[7].Points.Clear();
            chart1.Series[8].Points.Clear();

            chart1.ChartAreas[0].AxisY.Maximum = 30;
            chart1.ChartAreas[0].AxisY.Minimum = -30;

            float fromX = float.Parse(textBox1.Text),
                toX = float.Parse(textBox2.Text), step;
            step = 0.01f;//(toX - fromX) / (float)pictureBox1.Width;
                        //float y, y1;
            int k = 0;
            if (checkBox4.Checked)
            {
                //Random rand = new Random();
                //for (float c1 = -100; c1 <= 100; c1 += 100)
                //    for (float c2 = -100; c2 <= 100; c2 += 100)
                //    {
                //        for (float i = fromX; i <= toX; i += step)
                //            chart1.Series[k].Points.AddXY(i, Y(i, c1, c2));
                //        k++;
                //        //chart1.Series[3].Color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                //    }

                for (float i = fromX; i <= toX; i += step)
                    chart1.Series[0].Points.AddXY(i, Y(i, C1, C2));
            }
        }
    }
}
