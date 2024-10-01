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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap b;
        Graphics g;
        double from, to,min,max;
        private void button1_Click(object sender, EventArgs e)
        {
            build_f();
        }
        void build_f()
        {
            if (textBox1.Text != "")
            {
                int[] z = convert_to_function(textBox1.Text);
                //to = trackBar1.Value;
                //from = trackBar2.Value;
                double step = /*Math.Abs(from - to) / 1000*/0.1, k,k1;
                double j = from;
                g.Clear(Color.White);
                /*min=f(from, z, 0, z.Length - 1);
                max = min;
                for (double i=from;i<=to;i+=step)
                {
                    k = f(i, z, 0, z.Length - 1);
                    if (min > k)
                        min = k;
                    if (max < k)
                        max = k;
                }*/
                for (double i = from; i <= to; i += step)
                {
                    k = f(j, z, 0, z.Length - 1);
                    k1 = f(i, z, 0, z.Length - 1);
                    if (Math.Abs(k) > Math.Abs(min - max) * 2 && Math.Abs(k1) > Math.Abs(min - max) * 2)
                    {
                        j = i;
                    }
                    else
                    {
                        try
                        {
                            g.DrawLine(Pens.Black, (float)(pictureBox1.Width / 2 + j * (pictureBox1.Width / Math.Abs(from - to))), (float)(pictureBox1.Height / 2 - k * (pictureBox1.Height / Math.Abs(min - max))), (float)(pictureBox1.Width / 2 + i * (pictureBox1.Width / Math.Abs(from - to))), (float)(pictureBox1.Height / 2 - k1 * (pictureBox1.Height / Math.Abs(min - max))));
                            j = i;
                        }
                        catch
                        {
                            j = i;
                        }
                    }
                    /*try
                    {
                        g.DrawLine(Pens.Black, (float)(pictureBox1.Width / 2 + j * (pictureBox1.Width / Math.Abs(from - to))), (float)(pictureBox1.Height / 2 - k * (pictureBox1.Height / Math.Abs(min - max))), (float)(pictureBox1.Width / 2 + i * (pictureBox1.Width / Math.Abs(from - to))), (float)(pictureBox1.Height / 2 - k1 * (pictureBox1.Height / Math.Abs(min - max))));
                        j = i;
                    }
                    catch(OverflowException)
                    {
                        if (k > 0)
                        {
                            g.DrawLine(Pens.Black, (float)(pictureBox1.Width / 2 + j * (pictureBox1.Width / Math.Abs(from - to))), (float)(pictureBox1.Height / 2 - k * (pictureBox1.Height / Math.Abs(min - max))), (float)(pictureBox1.Width / 2 + i * (pictureBox1.Width / Math.Abs(from - to))), (float)(pictureBox1.Height / 2 - k1 * (pictureBox1.Height / Math.Abs(min - max))));
                            j = i;
                        }
                        else
                        {

                        }
                    }*/
                }
                pictureBox1.Image = b;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            min = -trackBar1.Value;
            max = trackBar1.Value;
            label2.Text=("x = ["+from+", "+to+ "]\ny = [" + min + ", " + max + "]\n");
            if (checkBox1.Checked)
                build_f();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            to = trackBar2.Value;
            from = -trackBar2.Value;
            label2.Text = ("x = [" + from + ", " + to + "]\ny = [" + min + ", " + max + "]\n");
            if (checkBox1.Checked)
                build_f();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            g = Graphics.FromImage(b);
            min = -trackBar1.Value;
            max = trackBar1.Value;
            to = trackBar2.Value;
            from = -trackBar2.Value;
            label2.Text = ("x = [" + from + ", " + to + "]\ny = [" + min + ", " + max + "]\n");
        }
        static int[] convert_to_function(string s)
        {
            int[] a = new int[s.Length];
            int length = s.Length, k = 0;
            char[] c = new char[s.Length];
            for (int i = 0; i < length; i++)
                c[i] = s[i];
            bool b = false;
            int breck = -100;
            for (int i = 0; i < s.Length; i++)
            {
                if (c[i] == ' ')
                {
                    k++;
                    length--;
                }
                else if (c[i] == 'x')
                {
                    a[i - k] = -1;
                    b = false;
                }
                else if (c[i] == '+')
                {
                    a[i - k] = -2;
                    b = false;
                }
                else if (c[i] == '-')
                {
                    a[i - k] = -3;
                    b = false;
                }
                else if (c[i] == '*')
                {
                    a[i - k] = -4;
                    b = false;
                }
                else if (c[i] == '/')
                {
                    a[i - k] = -5;
                    b = false;
                }
                else if (c[i] == '^')
                {
                    a[i - k] = -6;
                    b = false;
                }
                else if (c[i] == 'c' || c[i] == 'C')//тригонометрические функции
                {//косинус или котангенс
                    length -= 2;
                    b = false;
                    if (c[i + 1] == 'o')
                    {//косинус cos
                        a[i - k] = -7;
                    }
                    else if (c[i + 1] == 't')
                    {//котангенс ctg
                        a[i - k] = -10;
                    }
                    i += 2;
                    k += 2;
                }
                else if (c[i] == 's' || c[i] == 'S')
                {//синус sin
                    b = false;
                    length -= 2;
                    a[i - k] = -8;
                    i += 2;
                    k += 2;
                }
                else if (c[i] == 't' || c[i] == 'T')
                {//тангенс
                    b = false;
                    if (c[i + 1] == 'g')//разновидности написания
                    {//tg
                        length--;
                        a[i - k] = -9;
                        i++;
                        k++;
                    }
                    else if (c[i + 1] == 'a')
                    {//tan
                        length -= 2;
                        a[i - k] = -9;
                        i += 2;
                        k += 2;
                    }
                }
                else if (c[i] == '(')
                {
                    b = false;
                    a[i - k] = breck;
                    breck--;
                }
                else if (c[i] == ')')
                {
                    b = false;
                    breck++;
                    a[i - k] = breck;
                }
                else if (c[i] >= '0' && c[i] <= '9')
                {
                    if (b == false)
                    {
                        a[i - k] = Convert.ToInt32(c[i] - '0');
                        b = true;
                    }
                    else
                    {
                        k++;
                        a[i - k] *= 10;
                        a[i - k] += Convert.ToInt32(c[i] - '0');
                        length--;
                    }
                }
            }
            int[] a1 = new int[length];
            for (int i = 0; i < length; i++)
                a1[i] = a[i];
            return a1;
        }


        static double f(double x, int[] n, int i_start, int i_end)
        {
            double answer = 0;
            if (i_start < 0)
            {//если первым действием - отрицательное число, например: -5+4х, то
                //"-" в данном случае - действие: 0-5
                answer = 0;
            }
            else if (i_start == i_end)
            {
                if (n[i_start] == -1)
                    answer = x;
                else
                    answer = n[i_start];
            }
            else if (n[i_start] <= -100 && n[i_end] <= -100)
            {//если пришла функция в скобочках,
                answer = f(x, n, i_start + 1, i_end - 1);//то обкусываем их
            }
            else
            {
                int max = -50, imax = i_start;
                for (int i = i_start; i <= i_end; i++)
                {//поиск последнего действия
                    if (n[i] <= -100)
                    {//игнорируем скобочки
                        int j = i + 1;
                        while (n[i] != n[j])
                        {
                            j++;
                        }
                        i = j;
                    }
                    else if (n[i] < -1 && n[i] > max)
                    {
                        max = n[i];
                        imax = i;
                    }
                }
                if (max == -2)
                    answer = f(x, n, i_start, imax - 1) + f(x, n, imax + 1, i_end);
                else if (max == -3)
                    answer = f(x, n, i_start, imax - 1) - f(x, n, imax + 1, i_end);
                else if (max == -4)
                    answer = f(x, n, i_start, imax - 1) * f(x, n, imax + 1, i_end);
                else if (max == -5)
                    answer = f(x, n, i_start, imax - 1) / f(x, n, imax + 1, i_end);
                else if (max == -6)
                    answer = Math.Pow(f(x, n, i_start, imax - 1), f(x, n, imax + 1, i_end));
                else if (max == -7)
                    answer = Math.Cos(f(x, n, imax + 1, i_end));
                else if (max == -8)
                    answer = Math.Sin(f(x, n, imax + 1, i_end));
                else if (max == -9)
                    answer = Math.Tan(f(x, n, imax + 1, i_end));
                else if (max == -10)
                    answer = 1 / Math.Tan(f(x, n, imax + 1, i_end));
            }
            return answer;
        }
    }
}
