using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewFaceCore.Sharp;
using ViewFaceCore.Sharp.Model;

namespace FaceDetectionDemo
{
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
            InitializeComponent();

            TimerDetector.Interval = 20 / 15; // 15 FPS
            TimerDetector.Tick += TimerDetector_Tick;

            VideoPlayer.Visible = false; // 隐藏摄像头画面控件
        }

        /// <summary>
        /// 摄像头设备信息集合
        /// </summary>
        FilterInfoCollection VideoDevices;
        /// <summary>
        /// 人脸位置信息集合
        /// </summary>
        List<Rectangle> FaceRectangles = new List<Rectangle>();

        /// <summary>
        /// 人脸识别库
        /// </summary>
        ViewFace ViewFace = new ViewFace();

        /// <summary>
        /// 窗体加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            VideoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            comboBox1.Items.Clear();
            foreach (FilterInfo info in VideoDevices)
            {
                comboBox1.Items.Add(info.Name);
            }
            if (comboBox1.Items.Count > 0)
            { comboBox1.SelectedIndex = 0; }
        }

        /// <summary>
        /// 点击开始按钮时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {

            #region 识别老照片
            DirectoryInfo TheFolder = new DirectoryInfo(@"C:\Users\mrls\Desktop\video");
            if (!TheFolder.Exists)
            {

                MessageBox.Show("文件夹不存在");
                return;
            }
            var files = TheFolder.GetFiles().Where(x => ".jpg,.png,".Contains(x.Extension.ToLower() + "")).ToList();

            foreach (FileInfo NextFile in files)
            {

                float[] oldEigenValues;
                Bitmap oldImg = (Bitmap)Image.FromFile(NextFile.FullName);   
                var oldFaces = ViewFace.FaceDetector(oldImg);   
                if (oldFaces.Length > 0)  
                {

                    var oldPoints = ViewFace.FaceMark(oldImg, oldFaces[0]);  
                    oldEigenValues = ViewFace.Extract(oldImg, oldPoints);  
                }
                else
                {
                    oldEigenValues = new float[0];  
                }
                var person = new PersonInfo();
                person.Name = NextFile.Name.Substring(0, NextFile.Name.IndexOf("."));
                person.oldEigenValues = oldEigenValues;
                personInfos.Add(person);

            }

            #endregion
            if (VideoPlayer.IsRunning)
            {
                VideoPlayer.SignalToStop();
                VideoPlayer.WaitForStop();
                TimerDetector.Start();
                ButtonStart.Text = "打开摄像头并识别人脸";
            }
            else
            {
                if (comboBox1.SelectedIndex == -1) return;
                FilterInfo info = VideoDevices[comboBox1.SelectedIndex];
                VideoCaptureDevice videoCapture = new VideoCaptureDevice(info.MonikerString);
                VideoPlayer.VideoSource = videoCapture;
                VideoPlayer.Start();
                TimerDetector.Start();
                ButtonStart.Text = "关闭摄像头";
            }
        }
        public static List<PersonInfo> personInfos = new List<PersonInfo>();
    
        private void TimerDetector_Tick(object sender, EventArgs e)
        {
            //label1.Text = "";
            if (VideoPlayer.IsRunning)
            {


                Bitmap bitmap = VideoPlayer.GetCurrentVideoFrame(); // 获取摄像头画面

                if (bitmap != null)
                {
                    var infos = ViewFace.FaceDetector(bitmap); // 识别画面中的人脸
                    FaceRectangles.Clear();
                    var test = ViewFace.FaceType;

                    foreach (var info in infos)
                    {
                        FaceRectangles.Add(new Rectangle(info.Location.X, info.Location.Y, info.Location.Width, info.Location.Height));

                        // 识别 bitmap 中指定的人脸信息 info 的关键点坐标。
                        var faceps = ViewFace.FaceMark(bitmap, info);
                        var s = ViewFace.Extract(bitmap, faceps);
                        //bitmap.Save($"{DateTime.Now.Ticks}.jpg");

                        personInfos.Where(x => true || x.Name == "刘松").ToList().ForEach(x =>
                             {

                                 float similarity = ViewFace.Similarity(x.oldEigenValues, s); // 对比两张照片上的数据，确认是否是同一个人。


                            if (ViewFace.IsSelf(similarity))
                                 {
                                     label1.Text = $"{x.Name} ";

                                //label1.Text = $"{similarity} ";

                            }


                             });


                    }
                    if (FaceRectangles.Count > 0) 
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.DrawRectangles(new Pen(Color.Red, 4), FaceRectangles.ToArray());
                        }

                    }
                }
                FacePictureBox.Image = bitmap;

            }
        }

        /// <summary>
        /// 窗体关闭时，关闭摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            VideoPlayer.SignalToStop();
            VideoPlayer.WaitForStop();
        }
    }
}
