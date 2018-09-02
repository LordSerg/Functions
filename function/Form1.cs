using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace function
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Blue,1);
            Pen p2 = new Pen(Color.Black, 2);
            Graphics g = CreateGraphics();
            double x1,y1;
            this.Refresh();
            double X0 = 0, Y0 = 500;
            g.DrawLine(p2, 0,500,1400,500);
            g.DrawLine(p2, 600, 0, 600, 1400);
            double k1, k2, k3;
            k1 = Double.Parse(textBox1.Text);
            k2 = Double.Parse(textBox2.Text);
            k3 = Double.Parse(textBox3.Text);
            if (comboBox1.Text == "y=k1*(x*k2)^(k3)")
            {


                for (double i = 0; i < 1400; i += 0.1)
                {
                    x1 = i;
                    y1 = (-k1) * (Math.Pow((x1 - 600) * k2, k3)) + 500;
                    if (((X0 > -2000) && (X0 < 2000)) && ((Y0 > -2000) && (Y0 < 2000)) && ((x1 > -2000) && (x1 < 2000)) && ((y1 > -2000) && (y1 < 2000)))
                    {
                        int X = Convert.ToInt32(X0);
                        int Y = Convert.ToInt32(Y0);
                        int x = Convert.ToInt32(x1);
                        int y = Convert.ToInt32(y1);
                        g.DrawLine(p, X, Y, x, y);
                    }
                    X0 = x1;
                    Y0 = y1;
                }
            }
            if (comboBox1.Text == "y=k1*sin(x*k2+k3)")
            {
                for (double i = 0; i < 1400; i += 0.1)
                {
                    x1 = i;
                    y1 = (-k1) * (Math.Sin((x1 - 600) * k2+k3)) + 500;
                    if (((X0 > -2000) && (X0 < 2000)) && ((Y0 > -2000) && (Y0 < 2000)) && ((x1 > -2000) && (x1 < 2000)) && ((y1 > -2000) && (y1 < 2000)))
                    {
                        int X = Convert.ToInt32(X0);
                        int Y = Convert.ToInt32(Y0);
                        int x = Convert.ToInt32(x1);
                        int y = Convert.ToInt32(y1);
                        g.DrawLine(p, X, Y, x, y);
                    }
                    X0 = x1;
                    Y0 = y1;
                }
            }
            if (comboBox1.Text == "y=k1*cos(x*k2+k3)")
            {
                for (double i = 0; i < 1400; i += 0.1)
                {
                    x1 = i;
                    y1 = (-k1) * (Math.Cos((x1 - 600) * k2+k3)) + 500;
                    if (((X0 > -2000) && (X0 < 2000)) && ((Y0 > -2000) && (Y0 < 2000)) && ((x1 > -2000) && (x1 < 2000)) && ((y1 > -2000) && (y1 < 2000)))
                    {
                        int X = Convert.ToInt32(X0);
                        int Y = Convert.ToInt32(Y0);
                        int x = Convert.ToInt32(x1);
                        int y = Convert.ToInt32(y1);
                        g.DrawLine(p, X, Y, x, y);
                    }
                    X0 = x1;
                    Y0 = y1;
                }
            }
            if (comboBox1.Text == "y=k1*(tg(x*k2))^(k3)")
            {
                for (double i = 0; i < 1400; i += 0.01)
                {
                    x1 = i;
                    y1 = (-k1) * Math.Pow((Math.Sin(x1 - 600) / Math.Cos(x1 - 600)),k3) * k2 + 500;
                    if (((X0 > -2000) && (X0 < 2000)) && ((Y0 > -2000) && (Y0 < 2000)) && ((x1 > -2000) && (x1 < 2000)) && ((y1 > -2000) && (y1 < 2000)))
                    {
                        int X = Convert.ToInt32(X0);
                        int Y = Convert.ToInt32(Y0);
                        int x = Convert.ToInt32(x1);
                        int y = Convert.ToInt32(y1);
                        g.DrawLine(p, X, Y, x, y);
                    }
                    X0 = x1;
                    Y0 = y1;
                }
            }
            if (comboBox1.Text == "y=k1*(ctg(x*k2))^(k3)")
            {
                for (double i = 0; i < 1400; i+=0.01)
                {
                    x1 = i;
                    y1 = (-k1) * Math.Pow((Math.Cos(x1 - 600) / Math.Sin(x1 - 600)),k3) * k2 + 500;
                    if (((X0 > -2000) && (X0 < 2000)) && ((Y0 > -2000) && (Y0 < 2000)) && ((x1 > -2000) && (x1 < 2000)) && ((y1 > -2000) && (y1 < 2000)))
                    {
                        int X = Convert.ToInt32(X0);
                        int Y = Convert.ToInt32(Y0);
                        int x = Convert.ToInt32(x1);
                        int y = Convert.ToInt32(y1);
                        g.DrawLine(p, X, Y, x, y);
                    }
                    X0 = x1;
                    Y0 = y1;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("y=k1*(x*k2)^(k3)");
            comboBox1.Items.Add("y=k1*sin(x*k2+k3)");
            comboBox1.Items.Add("y=k1*cos(x*k2+k3)");
            comboBox1.Items.Add("y=k1*(tg(x*k2))^(k3)");
            comboBox1.Items.Add("y=k1*(ctg(x*k2))^(k3)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            timer1.Enabled = !timer1.Enabled;
            timer1.Interval = 1;
            if (timer1.Enabled == true)
                button2.Text = "Stop";
            else
                button2.Text = "Start";
        }
        double z=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            z += 0.571;
            Pen p = new Pen(Color.Blue, 1);
            //Pen p2 = new Pen(Color.Black, 2);
            Graphics g = CreateGraphics();
            double x1, y1;
            this.Refresh();
            double X0 = 0, Y0 = 500;
            //g.DrawLine(p2, 0, 500, 1400, 500);
            //g.DrawLine(p2, 600, 0, 600, 1400);
            double k1, k2, k3;
            k1 = Double.Parse(textBox1.Text);
            k2 = Double.Parse(textBox2.Text);
            k3 = Double.Parse(textBox3.Text);

            
            if (comboBox1.Text == "y=k1*sin(x*k2+k3)")
            {
                for (double i = 0; i < 1400; i += 0.1)
                {
                    x1 = i;
                    y1 = (-k1) * (Math.Sin((x1 - 600) * k2 + k3+z)) + 500;
                    if (((X0 > -2000) && (X0 < 2000)) && ((Y0 > -2000) && (Y0 < 2000)) && ((x1 > -2000) && (x1 < 2000)) && ((y1 > -2000) && (y1 < 2000)))
                    {
                        int X = Convert.ToInt32(X0);
                        int Y = Convert.ToInt32(Y0);
                        int x = Convert.ToInt32(x1);
                        int y = Convert.ToInt32(y1);
                        g.DrawLine(p, X, Y, x, y);
                    }
                    X0 = x1;
                    Y0 = y1;
                }
            }
            if (comboBox1.Text == "y=k1*cos(x*k2+k3)")
            {
                for (double i = 0; i < 1400; i += 0.1)
                {
                    x1 = i;
                    y1 = (-k1) * (Math.Cos((x1 - 600) * k2 + k3+z)) + 500;
                    if (((X0 > -2000) && (X0 < 2000)) && ((Y0 > -2000) && (Y0 < 2000)) && ((x1 > -2000) && (x1 < 2000)) && ((y1 > -2000) && (y1 < 2000)))
                    {
                        int X = Convert.ToInt32(X0);
                        int Y = Convert.ToInt32(Y0);
                        int x = Convert.ToInt32(x1);
                        int y = Convert.ToInt32(y1);
                        g.DrawLine(p, X, Y, x, y);
                    }
                    X0 = x1;
                    Y0 = y1;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
