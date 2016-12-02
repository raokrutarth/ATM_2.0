using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Controls;
using AForge.Imaging;
using AForge.Math;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ATM
{
    public partial class PhotoAuth : Form
    {
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private ATMClient atm;
        //private Bitmap bit;
        private int timeLeft;
        public PhotoAuth()
        {
            InitializeComponent();
        }

        public PhotoAuth(ATMClient atm)
        {
            this.atm = atm;
            InitializeComponent();
        }
        private int getTime()
        {
            string name = Convert.ToString(DateTime.Now);
            string[] date = name.Split('/');
            date = date[2].Substring(5).Split(':');
            string time = date[0] + date[1] + date[2];
            time = time.Substring(0, time.Length - 2);
            time = time.Substring(time.Length - 3);
            return Int32.Parse(time);
        }
        private void takePic_Click(object sender, EventArgs e)
        {
            timeLeft = 6;
            Count.Enabled = true;
                
        }
        
    

        private void PhotoAuth_Load(object sender, EventArgs e)
        {
            /* PHOTO TESTING
             * FOR HAL AND RAO
             *
             */
            Message msg = atm.serverConnection.SendData(/*not correct type*/"PhotoAuth", ImageToByte(userImage.Image), true);
            Console.Write(msg.type + " " + msg.data+ "\n");
            /*
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                listOfCams.Items.Add(VideoCaptureDevice.Name);
            }
            listOfCams.SelectedIndex = 0;

            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
            */
        }

        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            userImage.Image = bit;
        }

        private void Count_Tick(object sender, EventArgs e)
        {
            Boolean success = true;
            string name = Convert.ToString(DateTime.Now);
            string path = "C:\\Users\\Rashon\\Documents\\Github\\ATM_2.0\\client\\pictures\\";
            name = path + "Awesome.jpg";
            if (timeLeft > 1)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                CountDown.Text = (timeLeft).ToString();
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                Count.Stop();
                try
                {
                    if (atm.serverConnection.Connect())
                    {
                        Console.Write("still connected");
                    } else
                    {
                        Console.Write("Broken");
                    }
                    userImage.Image.Save(name);

                }
                catch (Exception)
                {
                    success = false;
                    photoMSG.Text = "pathing wrong";
                }
                if (success)
                {
                    if (cam.IsRunning)
                    {
                        if (atm.serverConnection.Connect())
                        {
                            Console.Write("still connected");
                        }
                        else
                        {
                            Console.Write("Broken");
                        }
                        cam.Stop();
                        //Message msg = atm.serverConnection.SendData("PhotoAuth", ImageToByte(userImage.Image), true);
                    }
                    if (atm.serverConnection.Connect())
                    {
                        Console.Write("still connected");
                    }
                    else
                    {
                        Console.Write("Broken");
                    }
                    this.Close();
                }

            }
        }
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }

    }

