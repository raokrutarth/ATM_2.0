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
using System.IO;

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
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                listOfCams.Items.Add(VideoCaptureDevice.Name);
            }
            listOfCams.SelectedIndex = 0;

            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }

        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            userImage.Image = bit;
        }

        private void Count_Tick(object sender, EventArgs e)
        {
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
					// Convert image to a useable format.
					/*MemoryStream ms = new MemoryStream();
					userImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

					// Send the image size.
					Size imgSize = userImage.Image.Size;
					string sizeString = imgSize.Width.ToString() + "\n" + imgSize.Height.ToString();
					atm.serverConnection.SendData("setFaceImageSize", sizeString);*/

					// Send image for verification.
					//Message response = atm.serverConnection.SendData("authenticateFace", ms.ToArray(), true);
					Message response = atm.serverConnection.SendData("authenticateFace", "haha we have no face", true);
					Console.WriteLine("AUTH STAGE 3, FACE: {0}", response.data);
					if (response.data == "Face Verified")
					{
						if (cam.IsRunning)
						{
							cam.Stop();
						}
						this.Close();
					}
					else
					{
						photoMSG.Text = "Please try again.";
					}
                }
                catch (Exception exc)
                {
					Console.WriteLine(exc.ToString());
                    photoMSG.Text = "Please try again.";
					if (cam.IsRunning)
					{
						cam.Stop();
					}
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

