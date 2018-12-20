using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO.Ports;
using AForge.Imaging;
using AForge.Imaging.Filters;



namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection cams;
        private VideoCaptureDevice cam;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo webcam in cams)
            {
                comboBox1.Items.Add(webcam.Name);
            }
            cam = new VideoCaptureDevice();
            comboBox2.DataSource = SerialPort.GetPortNames();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(cams[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += kamera_NewFrame;
            cam.Start();
        }
        private void kamera_NewFrame(object sender, NewFrameEventArgs eventargs)
        {
            Bitmap bm1 = (Bitmap)eventargs.Frame.Clone();
            Bitmap bm2 = (Bitmap)eventargs.Frame.Clone();
            pictureBox1.Image = bm1;

            EuclideanColorFiltering filter = new EuclideanColorFiltering();
            filter.CenterColor = new RGB(20,60,220);
            filter.Radius = 100;
            filter.ApplyInPlace(bm2);

            BlobCounter nesne = new BlobCounter();
            nesne.FilterBlobs = true;
            nesne.MinHeight = 15;
            nesne.MinWidth = 15;
            nesne.ProcessImage(bm2);
            Rectangle[] dortgenler = nesne.GetObjectsRectangles();
            foreach (Rectangle dortgen in dortgenler)
            {
                if (dortgen.X < bm2.Size.Width / 3 && dortgen.Y < bm2.Size.Height / 3)
                {
                    serialPort1.Write("1");
                }
                else if (dortgen.X < 2 * bm2.Size.Width / 3 && dortgen.Y < bm2.Size.Height / 3)
                {
                    serialPort1.Write("2");
                }
                else if (dortgen.X<3*bm2.Size.Width/3&&dortgen.Y<bm2.Size.Height/3)
                {
                    serialPort1.Write("3");
                }
                else if (dortgen.X<bm2.Size.Width/3&&dortgen.Y<2*bm2.Size.Height/3)
                {
                    serialPort1.Write("4");
                }
                else if (dortgen.X<2*bm2.Size.Width/3&&dortgen.Y<2*bm2.Size.Height/3)
                {
                    serialPort1.Write("5");
                }
                else if (dortgen.X<3*bm2.Size.Width/3&&dortgen.Y<2*bm2.Size.Height/3)
                {
                    serialPort1.Write("6");
                }
                else if (dortgen.X<bm2.Size.Width/3&&dortgen.Y<3*bm2.Size.Height/3)
                {
                    serialPort1.Write("7");
                }
                else if (dortgen.X<2*bm2.Size.Width/3&&dortgen.Y<3*bm2.Size.Height/3)
                {
                    serialPort1.Write("8");
                }
                else if (dortgen.X<3*bm2.Size.Width/3&&dortgen.Y<3*bm2.Size.Height/3)
                {
                    serialPort1.Write("9");
                }
            }
            pictureBox2.Image = bm2;


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cam.Stop();
            serialPort1.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = comboBox2.SelectedItem.ToString();
            serialPort1.Open();

        }
    }
}
