namespace Freewar
{
    using System;
    using System.Collections;

    public class KreisFinden
    {
        private int[,] r8r = new int[,] { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 } };
        private ArrayList Weg = new ArrayList();
        private ArrayList Weg3 = new ArrayList();
        private bool[,] Weg4 = new bool[640, 270];

        public double angle()
        {
            int count = 10;
            if (this.Weg.Count < 10)
            {
                count = this.Weg.Count;
            }
            double num2 = Convert.ToDouble((this.Weg[this.Weg.Count - 1] as int[])[0]);
            double num3 = Convert.ToDouble((this.Weg[this.Weg.Count - count] as int[])[0]);
            double num4 = Convert.ToDouble((this.Weg[this.Weg.Count - 1] as int[])[1]);
            double num5 = Convert.ToDouble((this.Weg[this.Weg.Count - count] as int[])[1]);
            num3 -= num2;
            num5 -= num4;
            double num6 = Math.Atan(num5 / num3);
            if ((num3 < 0.0) && (num5 >= 0.0))
            {
                num6 += 3.1415926535897931;
            }
            if ((num3 < 0.0) && (num5 < 0.0))
            {
                num6 -= 3.1415926535897931;
            }
            return (num6 + 3.1415926535897931);
        }

        public ArrayList Kreis_Finden(ref Stueck Start, bool[,] Pixel, int steps, int h)
        {
            int num = 0;
            int num2 = 0;
            int num3 = (Start.Pixel[0] as int[])[0];
            int num4 = (Start.Pixel[0] as int[])[1];
            int num5 = 0;
            int[] numArray4 = new int[] { 0, 0, -1, 0x63, -1, 0, 0 };
            numArray4[0] = num3;
            numArray4[1] = num4;
            int[] numArray = numArray4;
            this.Weg.Add(numArray.Clone());
            this.Weg3.Add(new double[2]);
            this.Weg4[numArray[0], numArray[1]] = true;
            for (int i = 0; i < 8; i++)
            {
                if (((num3 + this.r8r[i, 0]) == (Start.Pixel[1] as int[])[0]) && ((num4 + this.r8r[i, 1]) == (Start.Pixel[1] as int[])[1]))
                {
                    numArray[0] = (Start.Pixel[1] as int[])[0];
                    numArray[1] = (Start.Pixel[1] as int[])[1];
                    numArray[2] = i + 8;
                    numArray[3] = 0x63;
                    numArray[4] = i + 8;
                    numArray[5] = 1;
                    numArray[6] = 1;
                    break;
                }
            }
            num = numArray[2] + 10;
            this.Weg.Add(numArray.Clone());
            this.Weg3.Add(new double[] { this.angle(), 1.0 });
            this.Weg4[numArray[0], numArray[1]] = true;
            while ((steps > num2) && (this.Weg.Count > 1))
            {
                numArray = this.Weg[this.Weg.Count - 1] as int[];
                double[] numArray2 = (double[]) this.Weg3[this.Weg3.Count - 1];
                double[] numArray3 = numArray2;
                if (this.Weg3.Count > 10)
                {
                    numArray3 = (double[]) this.Weg3[this.Weg3.Count - 10];
                }
                this.Weg.RemoveAt(this.Weg.Count - 1);
                this.Weg3.RemoveAt(this.Weg3.Count - 1);
                this.Weg4[numArray[0], numArray[1]] = false;
                for (int j = numArray[4] + 1; j >= (numArray[4] - 1); j--)
                {
                    if (numArray[3] <= j)
                    {
                        j = numArray[3] - 1;
                    }
                    if ((num3 == (numArray[0] + this.r8r[j % 8, 0])) && (num4 == (numArray[1] + this.r8r[j % 8, 1])))
                    {
                        if (Start.Ellipse_C(this.Weg, h))
                        {
                            Start.Ellipse = true;
                            return this.Weg;
                        }
                        num5--;
                        this.Weg.RemoveAt(this.Weg.Count - 1);
                        this.Weg3.RemoveAt(this.Weg3.Count - 1);
                        this.Weg.RemoveAt(this.Weg.Count - 1);
                        this.Weg3.RemoveAt(this.Weg3.Count - 1);
                        this.Weg.RemoveAt(this.Weg.Count - 1);
                        this.Weg3.RemoveAt(this.Weg3.Count - 1);
                        break;
                    }
                    double num8 = this.angle();
                    double num9 = 3.1415926535897931;
                    if ((((((j < (numArray[4] - 1)) || (j > num)) || ((numArray[5] > 20) || (numArray[6] > 50))) || (((num8 >= (numArray2[0] + 0.175)) || (num8 <= (numArray2[0] - 0.24))) && (((num8 >= ((numArray2[0] - (2.0 * num9)) + 0.175)) && (num8 <= ((numArray2[0] + (2.0 * num9)) - 0.223))) && ((num2 > 10) && (h <= 2))))) || (((num8 >= (numArray2[0] + 0.24)) || (num8 <= (numArray2[0] - 0.24))) && (((num8 >= ((numArray2[0] - (2.0 * num9)) + 0.175)) && (num8 <= ((numArray2[0] + (2.0 * num9)) - 0.223))) && ((num2 > 10) && (h >= 3))))) || (((num8 >= (numArray3[0] + 1.07)) || (num8 < (numArray3[0] - 0.0))) && (((num8 >= ((numArray3[0] - (2.0 * num9)) + 1.07)) && (num8 <= ((numArray3[0] + (2.0 * num9)) - 0.0))) && (num2 > 20))))
                    {
                        break;
                    }
                    if ((((((numArray[0] + this.r8r[j % 8, 0]) >= 0) && ((numArray[1] + this.r8r[j % 8, 1]) >= 0)) && (((numArray[0] + this.r8r[j % 8, 0]) <= 0x27f) && ((numArray[1] + this.r8r[j % 8, 1]) <= 0x10d))) && ((Pixel[numArray[0] + this.r8r[j % 8, 0], numArray[1] + this.r8r[j % 8, 1]] && !this.Weg4[numArray[0] + this.r8r[j % 8, 0], numArray[1] + this.r8r[j % 8, 1]]) && (((numArray[0] + this.r8r[j % 8, 0]) >= (num3 - 70)) && ((numArray[1] + this.r8r[j % 8, 1]) >= (num4 - 70))))) && ((((numArray[0] + this.r8r[j % 8, 0]) <= (num3 + 70)) && ((numArray[1] + this.r8r[j % 8, 1]) <= (num4 + 70))) && ((numArray[4] <= (num - 4)) || (numArray3[1] >= (Math.Pow((double) ((numArray[0] + this.r8r[j % 8, 0]) - num3), 2.0) + Math.Pow((double) ((numArray[1] + this.r8r[j % 8, 1]) - num4), 2.0))))))
                    {
                        numArray[3] = j;
                        this.Weg.Add(numArray.Clone());
                        this.Weg3.Add(numArray2);
                        this.Weg4[numArray[0], numArray[1]] = true;
                        numArray[0] += this.r8r[j % 8, 0];
                        numArray[1] += this.r8r[j % 8, 1];
                        if (j != numArray[2])
                        {
                            numArray[5] = 0;
                        }
                        numArray[2] = j;
                        numArray[3] = 0x63;
                        if (j > numArray[4])
                        {
                            numArray[4] = j;
                            numArray[6] = 0;
                        }
                        numArray[5]++;
                        numArray[6]++;
                        this.Weg.Add(numArray.Clone());
                        this.Weg3.Add(new double[] { num8, Math.Pow((double) ((numArray[0] + this.r8r[j % 8, 0]) - num3), 2.0) + Math.Pow((double) ((numArray[1] + this.r8r[j % 8, 1]) - num4), 2.0) });
                        this.Weg4[numArray[0], numArray[1]] = true;
                    }
                }
                num2++;
            }
            return this.Weg;
        }
    }
}

