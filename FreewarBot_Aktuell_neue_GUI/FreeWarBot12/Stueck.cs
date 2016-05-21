namespace Freewar
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Threading;

    public class Stueck
    {
        public double a;
        public double b = 12800.0;
        public double c;
        private double Distance;
        public bool Ellipse;
        private int Height;
        private int Left = 640;
        public int mx;
        public int my;
        public ArrayList Pixel = new ArrayList();
        public bool Testen = true;
        private int Top = 270;
        private int Width;


        public bool Calc()
        {
            for (int i = 0; i < this.Pixel.Count; i++)
            {
                int[] numArray = this.Pixel[i] as int[];
                if (numArray[0] < this.Left)
                {
                    this.Left = numArray[0];
                }
                if (numArray[1] < this.Top)
                {
                    this.Top = numArray[1];
                }
                if (numArray[0] > this.Width)
                {
                    this.Width = numArray[0];
                }
                if (numArray[1] > this.Height)
                {
                    this.Height = numArray[1];
                }
            }
            this.Width -= this.Left;
            this.Height -= this.Top;
            double num2 = Convert.ToDouble((this.Pixel[0] as int[])[0]);
            double num3 = Convert.ToDouble((this.Pixel[this.Pixel.Count - 1] as int[])[0]);
            double num4 = Convert.ToDouble((this.Pixel[this.Pixel.Count / 2] as int[])[0]);
            double num5 = Convert.ToDouble((this.Pixel[0] as int[])[1]);
            double num6 = Convert.ToDouble((this.Pixel[this.Pixel.Count - 1] as int[])[1]);
            double num7 = Convert.ToDouble((this.Pixel[this.Pixel.Count / 2] as int[])[1]);
            num3 -= num2;
            num6 -= num5;
            num4 -= num2;
            num7 -= num5;
            double a = Math.Atan(num6 / num3);
            if ((num3 < 0.0) && (num6 > 0.0))
            {
                a += 3.1415926535897931;
            }
            if ((num3 < 0.0) && (num6 < 0.0))
            {
                a -= 3.1415926535897931;
            }
            double num9 = (Math.Sin(a) * num4) - (Math.Cos(a) * num7);
            this.Distance = Math.Abs(num9);
            if (num9 < 0.0)
            {
                ArrayList list = new ArrayList();
                for (int j = this.Pixel.Count - 1; j > -1; j--)
                {
                    list.Add(this.Pixel[j]);
                }
                this.Pixel = list;
            }
            return true;
        }

        public bool Check(int Pixel, int Width, int Height, double Distance)
        {
            if (!this.Testen)
            {
                return false;
            }
            if (this.Ellipse)
            {
                return false;
            }
            if (Pixel > this.Pixel.Count)
            {
                return false;
            }
            if (Width > this.Width)
            {
                return false;
            }
            if (Height > this.Height)
            {
                return false;
            }
            if (Distance > this.Distance)
            {
                return false;
            }
            if (this.Left < 3)
            {
                return false;
            }
            if (this.Top < 3)
            {
                return false;
            }
            if ((this.Left + this.Width) > 0x27c)
            {
                return false;
            }
            if ((this.Top + this.Height) > 0x10a)
            {
                return false;
            }
            return true;
        }

        public bool Ellipse_C(ArrayList Weg, int h)
        {
           // Bitmap sender = new Bitmap(640, 270);
            Bitmap sender = (Bitmap)Image.FromFile(@"Captcha.png");
            //for (int i = 0; i < 640; i++)
            //{
            //    for (int n = 0; n < 270; n++)
            //    {
            //       // sender.SetPixel(i, n, Color.White);
            //    }
            //}
            this.a = 0.0;
            this.b = 12800.0;
            int[,] numArray = new int[Weg.Count, 2];
            bool[,] flagArray = new bool[640, 270];
            int x = 0;
            int y = 0;
            for (int j = 0; j < Weg.Count; j++)
            {
                numArray[j, 0] = (Weg[j] as int[])[0];
                numArray[j, 1] = (Weg[j] as int[])[1];
                x += numArray[j, 0];
                y += numArray[j, 1];
                flagArray[numArray[j, 0], numArray[j, 1]] = true;
                sender.SetPixel(numArray[j, 0], numArray[j, 1], Color.Red);
            }
            this.mx = x / Weg.Count;
            this.my = y / Weg.Count;
            for (int k = 0; k < Weg.Count; k++)
            {
                double num7 = Math.Pow((double) (numArray[k, 0] - this.mx), 2.0) + Math.Pow((double) (numArray[k, 1] - this.my), 2.0);
                if (num7 > this.a)
                {
                    this.a = num7;
                    if ((numArray[k, 1] - this.my) != 0)
                    {
                        this.c = Math.Atan(((double) (numArray[k, 0] - this.mx)) / ((double) (numArray[k, 1] - this.my)));
                    }
                    else
                    {
                        this.c = 1.5707963267948966;
                    }
                }
                if (num7 < this.b)
                {
                    this.b = num7;
                }
            }
            this.a = Math.Sqrt(this.a);
            this.b = Math.Sqrt(this.b);
            int num8 = 0;
            for (int m = 0; m < 360; m++)
            {
                x = Convert.ToInt16(Math.Round((double) ((((this.a * Math.Sin((6.2831853071795862 * m) / 360.0)) * Math.Sin(this.c)) - ((this.b * Math.Cos((6.2831853071795862 * m) / 360.0)) * Math.Cos(this.c))) + this.mx)));
                y = Convert.ToInt16(Math.Round((double) ((((this.a * Math.Sin((6.2831853071795862 * m) / 360.0)) * Math.Cos(this.c)) + ((this.b * Math.Cos((6.2831853071795862 * m) / 360.0)) * Math.Sin(this.c))) + this.my)));
                try
                {
                    sender.SetPixel(x, y, Color.Green);
                    if (((((flagArray[x - 2, y - 2] || flagArray[x - 1, y - 2]) || (flagArray[x, y - 2] || flagArray[x + 1, y - 2])) || ((flagArray[x + 2, y - 2] || flagArray[x - 2, y - 1]) || (flagArray[x - 1, y - 1] || flagArray[x, y - 1]))) || (((flagArray[x + 1, y - 1] || flagArray[x + 2, y - 1]) || (flagArray[x - 2, y] || flagArray[x - 1, y])) || ((flagArray[x, y] || flagArray[x + 1, y]) || (flagArray[x + 2, y] || flagArray[x - 2, y + 1])))) || (((flagArray[x - 1, y + 1] || flagArray[x, y + 1]) || (flagArray[x + 1, y + 1] || flagArray[x + 2, y + 1])) || ((flagArray[x - 2, y + 2] || flagArray[x - 1, y + 2]) || ((flagArray[x, y + 2] || flagArray[x + 1, y + 2]) || flagArray[x + 2, y + 2]))))
                    {
                        num8++;
                    }
                }
                catch
                {
                }
            }
            sender.SetPixel(numArray[0, 0], numArray[0, 1], Color.Blue);
            sender.SetPixel(this.mx, this.my, Color.Blue);
            return ((num8 > 340) || ((num8 > 270) && ((h % 2) == 0)));
        }
    }
}

