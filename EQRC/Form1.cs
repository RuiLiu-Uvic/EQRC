using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections;
using System.Threading;

namespace EQRC 
{
    public partial class Form1 : Form
    {
        class Mag//
        {

            public int width = 0;
            public int height = 0;
            public byte[,] RGB;
            public byte[,] gray;
        }
        class Mag02//
        {
            
            public int width=0;
            public int height=0;
            public byte[,] RGB;
            public byte[] gray;   
        }

        String s_change = "33\\297"; //change for different QR codes
        int all = 297;
        int version = 33;

        int times =300;
        Mag NowLoad = new Mag();

        Mag02 Split01 = new Mag02();
        Mag02 Split02 = new Mag02();
 
        HiPerfTimer time = new HiPerfTimer();
        HiPerfTimer retime = new HiPerfTimer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            //   openPic = new OpenFileDialog();
            //   openPic.FileName = "200.bmp";
          //  openPic.Filter = "JPG ILE(*jpg)|*.jpg|PNG FILE(*.png)|*.png|BMP FILE(*.bmp)|*.bmp";
          //  openPic.ShowDialog();
            //   if (openPic.FileName != "")
          //   {
                
          //       Load.ImageLocation = openPic.FileName;
          // //       Load.Image = Image.FromFile(Load.ImageLocation);
            //    }
           
          
        }





        private Double[] Test_Split()
        {
            //start for timing
            retime.Start();

          //  String s_change = "25\\300";
          //  int all = 300;
          //  int version = 25;
            //
            FileStream fs = new FileStream("path" + s_change + ".bmp", FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(fs);
            Bitmap picture = new Bitmap("path" + s_change + ".bmp");
            picture = (Bitmap)img;

            Load.Image = picture;//show

            NowLoad.width = picture.Width;
            NowLoad.height = img.Height;


            NowLoad.RGB = new byte[3, NowLoad.width * NowLoad.height];
            //  byte[] gray = new byte[picture.Width * picture.Height];

            int n = 0;
            int j = 0, i = 0;
            for (i = 0; i < picture.Height; i++)
            {
                for (j = 0; j < picture.Width; j++)
                {
                    NowLoad.RGB[0, n] = picture.GetPixel(j, i).R;
                    NowLoad.RGB[1, n] = picture.GetPixel(j, i).G;
                    NowLoad.RGB[2, n] = picture.GetPixel(j, i).B;

                    n++;
                }
            }

            NowLoad.gray = new byte[NowLoad.width, NowLoad.width];

            n = 0;
            for (i = 0; i < NowLoad.width; i++)
                for (j = 0; j < NowLoad.width; j++)
                {
                    //  NowLoad.gray[i] = Convert.ToByte((Convert.ToInt32(NowLoad.RGB[0, i]) + Convert.ToInt32(NowLoad.RGB[1, i]) + Convert.ToInt32(NowLoad.RGB[2, i])) / 3);
                    NowLoad.gray[i, j] = Convert.ToByte(0.299 * Convert.ToInt32(NowLoad.RGB[0, n]) + 0.587 * Convert.ToInt32(NowLoad.RGB[1, n]) + 0.114 * Convert.ToInt32(NowLoad.RGB[2, n]));
                    n++;
                }



            //----------------LOAD----------------------------------------------------------

            n = 0;
            i = 0;
            j = 0;

            byte[] One = new byte[version * 2 * version * 2];
            byte[] Two = new byte[version * 2 * version * 2];
            int cal01 = all / version;
            int ran = 0;
            //stop timing
            retime.Stop();
            Double time01 = retime.Duration;
      //      ReTimeBox.Text = time01.ToString();
            retime.ClearTimer();

            //start timing
            time.Start();

            for (i = 0; i < all; i = i + cal01)
                for (j = 0; j < all; j = j + cal01)
                {
                    ran = new Random(Guid.NewGuid().GetHashCode()).Next(0, 2);
                    if (NowLoad.gray[i, j] == 0)
                    {
                        if (ran == 0)
                        {

                            One[n] = 255;
                            One[n + 1] = 0;
                            One[n + 2] = 0;
                            One[n + 3] = 255;
                            Two[n] = 255;
                            Two[n + 1] = 0;
                            Two[n + 2] = 0;
                            Two[n + 3] = 255;
                            n = n + 4;

                        }
                        else
                        {
                            One[n] = 0;
                            One[n + 1] = 255;
                            One[n + 2] = 255;
                            One[n + 3] = 0;
                            Two[n] = 0;
                            Two[n + 1] = 255;
                            Two[n + 2] = 255;
                            Two[n + 3] = 0;
                            n = n + 4;
                        }
                    }
                    if (NowLoad.gray[i, j] == 255)
                    {
                        if (ran == 0)
                        {

                            One[n] = 255;
                            One[n + 1] = 0;
                            One[n + 2] = 0;
                            One[n + 3] = 255;
                            Two[n] = 0;
                            Two[n + 1] = 255;
                            Two[n + 2] = 255;
                            Two[n + 3] = 0;
                            n = n + 4;

                        }
                        else
                        {
                            One[n] = 0;
                            One[n + 1] = 255;
                            One[n + 2] = 255;
                            One[n + 3] = 0;
                            Two[n] = 255;
                            Two[n + 1] = 0;
                            Two[n + 2] = 0;
                            Two[n + 3] = 255;
                            n = n + 4;
                        }
                    }

                }


            Bitmap bmp = ToGrayBitmap(One, version * 2, version * 2);
            Bitmap bmp02 = ToGrayBitmap(Two, version * 2, version * 2);

            //split codes generated, stop timing
            time.Stop();
            Double time02 = time.Duration;
     //       TimeBox.Text = time02.ToString();
            time.ClearTimer();

            fs.Close();
            Double[] return_time= new Double[] { time01, time02 };
            return return_time;

        }
        private void Split_Click(object sender, EventArgs e)
        {
            //----------------LOAD----------------------------------------------------------

         //   int times = 2;
            Double[] time_average = new Double[] {0,0 };
            Double[] time_receive = new Double[] { 0, 0 };
            ArrayList record_data_reprocessing = new ArrayList { };
            ArrayList record_data_computing = new ArrayList { };
            for (int i = 0; i < times; i++)
            {
                time_receive = Test_Split();
                record_data_reprocessing.Add(time_receive[0]);
                record_data_computing.Add(time_receive[1]);
                time_average[0] = time_average[0] + time_receive[0];
                time_average[1] = time_average[1] + time_receive[1];
            }



            time_average[0] = time_average[0] / times; 
            ReTimeBox.Text = time_average[0].ToString();
            time_average[1] = time_average[1] / times;
            TimeBox.Text = time_average[1].ToString();
            // bmp.Save("path" + s_change + "one.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            // bmp02.Save("path" + s_change + "two.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

            //save

            FileStream fs = File.Open(@"split_reprocessing.txt", FileMode.Create);
            StreamWriter wr = new StreamWriter(fs);
            for (int i = 0; i < record_data_reprocessing.Count; i++)
            {
                wr.WriteLine(record_data_reprocessing[i]);
            }
            wr.Flush();
            wr.Close();

            fs.Close();

            FileStream fs2 = File.Open(@"split_computing.txt", FileMode.Create);
            StreamWriter wr2 = new StreamWriter(fs2);
            for (int i = 0; i < record_data_computing.Count; i++)
            {
                wr2.WriteLine(record_data_computing[i]);
            }
            wr2.Flush();
            wr2.Close();

            fs2.Close();




        }


        public static Bitmap ToGrayBitmap(byte[] rawValues, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height),
             ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            int stride = bmpData.Stride;
            int offset = stride - width;  
            IntPtr iptr = bmpData.Scan0;  
            int scanBytes = stride * height;

            int posScan = 0, posReal = 0;
            byte[] pixelValues = new byte[scanBytes]; 

            for (int x = 0; x < height; x++)
            {
 
                for (int y = 0; y < width; y++)
                {
                    pixelValues[posScan++] = rawValues[posReal++];
                }
                posScan += offset;    
            }

            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpData);  
  
            ColorPalette tempPalette;
            using (Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                tempPalette = tempBmp.Palette;
            }
            for (int i = 0; i < 256; i++)
            {
                tempPalette.Entries[i] = Color.FromArgb(i, i, i);
            }

            bmp.Palette = tempPalette;

            return bmp;
        }


        private void StackButton_Click(object sender, EventArgs e)
        {
            //----------------LOAD----------------------------------------------------------


            Double[] time_average = new Double[] { 0, 0 };
            Double[] time_receive = new Double[] { 0, 0 };
            ArrayList record_data_reprocessing = new ArrayList { };
            ArrayList record_data_computing = new ArrayList { };
            for (int i = 0; i < times; i++)
            {
                time_receive = Test_Stack();
                record_data_reprocessing.Add(time_receive[0]);
                record_data_computing.Add(time_receive[1]);
                time_average[0] = time_average[0] + time_receive[0];
                time_average[1] = time_average[1] + time_receive[1];
            }
            time_average[0] = time_average[0] / times;
            ReTimeBox.Text = time_average[0].ToString();
            time_average[1] = time_average[1] / times;
            TimeBox.Text = time_average[1].ToString();

            //save


            FileStream fs = File.Open(@"stack_reprocessing.txt", FileMode.Create);
            StreamWriter wr = new StreamWriter(fs);
            for (int i = 0; i < record_data_reprocessing.Count; i++)
            {
                wr.WriteLine(record_data_reprocessing[i]);
            }
            wr.Flush();
            wr.Close();

            fs.Close();

            FileStream fs2 = File.Open(@"stack_computing.txt", FileMode.Create);
            StreamWriter wr2 = new StreamWriter(fs2);
            for (int i = 0; i < record_data_computing.Count; i++)
            {
                wr2.WriteLine(record_data_computing[i]);
            }
            wr2.Flush();
            wr2.Close();

            fs2.Close();

            // bmp.Save("path" + s_change + "stack.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

        }//合并


        private Double[] Test_Stack() {
            //   String s_change = "25\\300";

            retime.Start();

         
            FileStream fs01 = new FileStream("path" + s_change + "one.bmp", FileMode.Open, FileAccess.Read);
            FileStream fs02 = new FileStream("path" + s_change + "Two.bmp", FileMode.Open, FileAccess.Read);
            Image img01 = Image.FromStream(fs01);
            Image img02 = Image.FromStream(fs02);
            Bitmap picture01 = (Bitmap)img01;
            Bitmap picture02 = (Bitmap)img02;

            Split01.width = picture01.Width;
            Split02.width = picture02.Width;

            Split01.height = picture01.Height;
            Split02.height = picture02.Height;

            Split01.RGB = new byte[3, Split01.width * Split01.height];

            int n = 0;
            int j = 0, i = 0;
            for (i = 0; i < picture01.Height; i++)
            {
                for (j = 0; j < picture01.Width; j++)
                {
                    Split01.RGB[0, n] = picture01.GetPixel(j, i).R;
                    Split01.RGB[1, n] = picture01.GetPixel(j, i).G;
                    Split01.RGB[2, n] = picture01.GetPixel(j, i).B;

                    n++;
                }
            }

            Split01.gray = new byte[Split01.width * Split01.width];

            for (i = 0; i < Split01.width * Split01.height; i++)
            {
                Split01.gray[i] = Convert.ToByte(0.299 * Convert.ToInt32(Split01.RGB[0, i]) + 0.587 * Convert.ToInt32(Split01.RGB[1, i]) + 0.114 * Convert.ToInt32(Split01.RGB[2, i]));
            }

            Split02.RGB = new byte[3, Split02.width * Split02.height];
            n = 0;
            for (i = 0; i < picture02.Height; i++)
            {
                for (j = 0; j < picture02.Width; j++)
                {
                    Split02.RGB[0, n] = picture02.GetPixel(j, i).R;
                    Split02.RGB[1, n] = picture02.GetPixel(j, i).G;
                    Split02.RGB[2, n] = picture02.GetPixel(j, i).B;

                    n++;
                }
            }

            Split02.gray = new byte[Split02.width * Split02.width];

            for (i = 0; i < Split02.width * Split02.height; i++)
            {
                Split02.gray[i] = Convert.ToByte(0.299 * Convert.ToInt32(Split02.RGB[0, i]) + 0.587 * Convert.ToInt32(Split02.RGB[1, i]) + 0.114 * Convert.ToInt32(Split02.RGB[2, i]));
            }


            byte[] StackSum = new byte[Split02.width * Split02.width];
            byte[] StackGray = new byte[Split02.width * Split02.width / 4];

            //finish preprocessing, stop timing
            retime.Stop();
            Double time01 = retime.Duration;
            //      ReTimeBox.Text = time01.ToString();
            retime.ClearTimer();

            time.Start();
            //————————————————————computing————————————————————————————————————————————————————————————————————————————————————————————————

            for (i = 0; i < Split02.width * Split02.width; i++)
            {
                StackSum[i] = (byte)((Split01.gray[i] + Split02.gray[i]) % 2);
            }
            n = 0;
            for (i = 0; i < Split02.width * Split02.width; i = i + 4)
            {
                if (StackSum[i] == 0 && StackSum[i] == StackSum[i + 1] && StackSum[i] == StackSum[i + 2] && StackSum[i] == StackSum[i + 3])
                    StackGray[n] = 0;
                if (StackSum[i] == 1 && StackSum[i] == StackSum[i + 1] && StackSum[i] == StackSum[i + 2] && StackSum[i] == StackSum[i + 3])
                    StackGray[n] = 255;
                //   else
                //       return;
                n++;
            }


            Bitmap bmp = ToGrayBitmap(StackGray, Split02.width / 2, Split02.width / 2);

            time.Stop();
            Double time02 = time.Duration;
            //       TimeBox.Text = time02.ToString();
            time.ClearTimer();

            fs01.Close();
            fs02.Close();
            Double[] return_time = new Double[] { time01, time02 };
            return return_time;





        }





        ////////////////////////




        /////////////////////




    }

    internal class HiPerfTimer
    {
       
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
    
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private long startTime, stopTime;
      
        private long freq;

        public HiPerfTimer()
        {
            startTime = 0;
            stopTime = 0;

            if (QueryPerformanceFrequency(out freq) == false)
            {
                throw new Win32Exception();
            }
        }

        // timing
        public void Start()
        {
            // lets do the waiting threads there work
            Thread.Sleep(0);

            QueryPerformanceCounter(out startTime);
        }

        // stop timing
        public void Stop()
        {
            QueryPerformanceCounter(out stopTime);
        }

        // ms
        public double Duration
        {
            get
            {
                return (double)(stopTime - startTime) * 1000 / (double)freq;
            }
        }
        //clear
        public void ClearTimer()
        {
            startTime = 0;
            stopTime = 0;
        }
    }
}
