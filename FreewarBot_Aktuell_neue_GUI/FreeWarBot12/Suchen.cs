
using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Freewar
{
    public class Suchen
    {
        public Bitmap Bild;
        private string Path = "";
        private bool[,] Pixel = new bool[640, 270];
        private bool[,] Pixel_rot = new bool[640, 270];
        private ArrayList Stuecke = new ArrayList();
        public Bitmap E_Suchen()
        {
            bool[,] pixel = this.Pixel.Clone() as bool[,];
            for (int i = 1; i <= 4; i++)
            {
                if (i == 3)
                {
                    pixel = this.Pixel.Clone() as bool[,];
                }
                for (int j = 0; j < this.Stuecke.Count; j++)
                {
                    Stueck start = this.Stuecke[j] as Stueck;
                    if (start.Check(2, 2, 2, 0.4))
                    {
                        KreisFinden finden = new KreisFinden();
                        ArrayList list = new ArrayList();
                        if ((i % 2) == 1)
                        {
                            list = finden.Kreis_Finden(ref start, this.Pixel, 0x186a0, i);
                        }
                        else
                        {
                            list = finden.Kreis_Finden(ref start, pixel, 0x186a0, i);
                        }
                        if (start.Ellipse)
                        {
                            for (int m = 0; m < list.Count; m++)
                            {
                                pixel[(list[m] as int[])[0], (list[m] as int[])[1]] = false;
                                this.Bild.SetPixel((list[m] as int[])[0], (list[m] as int[])[1], Color.Green);
                            }
                            start.Testen = false;
                        }
                        else if (list.Count == 1)
                        {
                            start.Testen = false;
                        }
                    }
                }
                int num4 = 0;
                for (int k = 0; k < this.Stuecke.Count; k++)
                {
                    Stueck stueck2 = this.Stuecke[k] as Stueck;
                    if (stueck2.Ellipse)
                    {
                        for (int n = 0; n < this.Stuecke.Count; n++)
                        {
                            Stueck stueck3 = this.Stuecke[n] as Stueck;
                            if (((stueck3.Ellipse && (stueck2.a != stueck3.a)) && ((stueck2.b != stueck3.b) && ((Math.Pow((double)(stueck2.mx - stueck3.mx), 2.0) + Math.Pow((double)(stueck2.my - stueck3.my), 2.0)) < 50.0))) && ((Math.Abs((double)(stueck2.a - stueck3.a)) > 3.0) || (Math.Abs((double)(stueck2.b - stueck3.b)) > 3.0)))
                            {
                                num4++;
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my - 7, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my - 7, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my - 7, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my - 7, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my - 7, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my - 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my - 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my - 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my - 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my - 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my - 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my - 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my - 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my - 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my - 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 6, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 6, stueck2.my - 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 6, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 6, stueck2.my - 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 7, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 6, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 6, stueck2.my - 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 7, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 6, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 6, stueck2.my - 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 7, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 6, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 6, stueck2.my, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 7, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 6, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 6, stueck2.my + 1, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 7, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 6, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 6, stueck2.my + 2, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 6, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 6, stueck2.my + 3, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 6, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 6, stueck2.my + 4, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 5, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 5, stueck2.my + 5, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 4, stueck2.my + 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 3, stueck2.my + 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my + 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my + 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my + 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my + 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my + 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 3, stueck2.my + 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 4, stueck2.my + 6, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 2, stueck2.my + 7, Color.Red);
                                this.Bild.SetPixel(stueck2.mx - 1, stueck2.my + 7, Color.Red);
                                this.Bild.SetPixel(stueck2.mx, stueck2.my + 7, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 1, stueck2.my + 7, Color.Red);
                                this.Bild.SetPixel(stueck2.mx + 2, stueck2.my + 7, Color.Red);
                            }
                        }
                    }
                }
                Image Copy = new Bitmap(this.Bild);
                if (num4 != 0)
                {
                    try
                    {
                       
                    }
                    catch { }
                    return this.Bild;
                }
            }
           // Image Copy1 = new Bitmap(this.Bild);
            
            //Copy1.Save(Application.StartupPath + "\\");
            return this.Bild;
        }

        public void Laden(string Path)
        {
            this.Path = Path;
            int[,] numArray = new int[,] { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 }};
            int[,] numArray2 = new int[,] { { 0, -2 }, { 1, -2 }, { 2, -2 }, { 2, -1 }, { 2, 0 }, { 2, 1 }, { 2, 2 }, { 1, 2 }, { 0, 2 }, { -1, 2 }, { -2, 2 }, { -2, 1 }, { -2, 0 }, { -2, -1 }, { -2, -2 }, { -1, -2 } };
            StreamReader SR = new StreamReader(Path);
            this.Bild = new Bitmap(SR.BaseStream);
            SR.Close();
            for (int i = 0; i < this.Bild.Width; i++)
            {
                for (int m = 0; m < this.Bild.Height; m++)
                {
                    if (this.Bild.GetPixel(i, m).B < 200)
                    {
                        this.Pixel[i, m] = true;
                    }
                }
            }
            for (int j = 2; j < (this.Bild.Width - 2); j++)
            {
                for (int n = 2; n < (this.Bild.Height - 2); n++)
                {
                    if (this.Pixel[j, n])
                    {
                        int num5 = 0;
                        for (int num6 = 0; num6 < 8; num6++)
                        {
                            if (this.Pixel[j + numArray[num6, 0], n + numArray[num6, 1]])
                            {
                                num5++;
                            }
                        }
                        if (num5 < 3)
                        {
                            this.Pixel_rot[j, n] = true;
                        }
                        if (num5 == 3)
                        {
                            int num7 = 0;
                            for (int num8 = 0; num8 < 0x10; num8++)
                            {
                                if (this.Pixel[j + numArray2[num8, 0], n + numArray2[num8, 1]])
                                {
                                    num7++;
                                }
                            }
                            if (num7 < 3)
                            {
                                this.Pixel_rot[j, n] = true;
                            }
                        }
                    }
                }
            }
            for (int k = 0; k < this.Bild.Width; k++)
            {
                for (int num10 = 0; num10 < this.Bild.Height; num10++)
                {
                    int[] numArray3;
                    if (!this.Pixel_rot[k, num10])
                    {
                        continue;
                    }
                    int num11 = 0;
                    for (int num12 = 0; num12 < 8; num12++)
                    {
                        if (this.Pixel_rot[k + numArray[num12, 0], num10 + numArray[num12, 1]])
                        {
                            num11++;
                        }
                    }
                    if (num11 != 1)
                    {
                        continue;
                    }
                    Stueck stueck = new Stueck();
                    stueck.Pixel.Add(new int[] { k, num10 });
                    this.Pixel_rot[k, num10] = false;
                    Label_028A:
                    numArray3 = stueck.Pixel[stueck.Pixel.Count - 1] as int[];
                    for (int num13 = 0; num13 < 8; num13++)
                    {
                        if (this.Pixel_rot[numArray3[0] + numArray[num13, 0], numArray3[1] + numArray[num13, 1]])
                        {
                            stueck.Pixel.Add(new int[] { numArray3[0] + numArray[num13, 0], numArray3[1] + numArray[num13, 1] });
                            this.Pixel_rot[numArray3[0] + numArray[num13, 0], numArray3[1] + numArray[num13, 1]] = false;
                            goto Label_028A;
                        }
                    }
                    stueck.Calc();
                    this.Stuecke.Add(stueck);
                }
            }
        }
    }
}
