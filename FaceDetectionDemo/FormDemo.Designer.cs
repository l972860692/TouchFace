namespace FaceDetectionDemo
{
    partial class FormDemo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.FacePictureBox = new System.Windows.Forms.PictureBox();
            this.TimerDetector = new System.Windows.Forms.Timer(this.components);
            this.VideoPlayer = new AForge.Controls.VideoSourcePlayer();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FacePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonStart
            // 
            this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStart.Location = new System.Drawing.Point(846, 14);
            this.ButtonStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(143, 73);
            this.ButtonStart.TabIndex = 1;
            this.ButtonStart.Text = "打开摄像头并识别人脸";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(846, 95);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 26);
            this.comboBox1.TabIndex = 2;
            // 
            // FacePictureBox
            // 
            this.FacePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FacePictureBox.Location = new System.Drawing.Point(14, 14);
            this.FacePictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FacePictureBox.Name = "FacePictureBox";
            this.FacePictureBox.Size = new System.Drawing.Size(722, 502);
            this.FacePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FacePictureBox.TabIndex = 4;
            this.FacePictureBox.TabStop = false;
            // 
            // VideoPlayer
            // 
            this.VideoPlayer.Location = new System.Drawing.Point(29, 28);
            this.VideoPlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VideoPlayer.Name = "VideoPlayer";
            this.VideoPlayer.Size = new System.Drawing.Size(271, 202);
            this.VideoPlayer.TabIndex = 5;
            this.VideoPlayer.Text = "videoSourcePlayer1";
            this.VideoPlayer.VideoSource = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(846, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 530);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VideoPlayer);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.FacePictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormDemo";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FacePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox FacePictureBox;
        private System.Windows.Forms.Timer TimerDetector;
        private AForge.Controls.VideoSourcePlayer VideoPlayer;
        private System.Windows.Forms.Label label1;
    }
}

