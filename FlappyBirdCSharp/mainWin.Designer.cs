namespace FlappyBirdCSharp
{
    partial class mainWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.scoreText = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.restartButton = new System.Windows.Forms.Button();
            this.pipeTop1 = new System.Windows.Forms.PictureBox();
            this.ground = new System.Windows.Forms.PictureBox();
            this.pipeBottom1 = new System.Windows.Forms.PictureBox();
            this.scoreBackground = new System.Windows.Forms.PictureBox();
            this.clouds1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGen = new System.Windows.Forms.Label();
            this.bestScoreTime = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bird = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pipeTop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottom1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clouds1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.BackColor = System.Drawing.Color.Transparent;
            this.scoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.ForeColor = System.Drawing.Color.Blue;
            this.scoreText.Location = new System.Drawing.Point(43, 45);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(211, 55);
            this.scoreText.TabIndex = 4;
            this.scoreText.Text = "Score: 0";
            this.scoreText.UseWaitCursor = true;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.Gold;
            this.restartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.Location = new System.Drawing.Point(284, 237);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(214, 63);
            this.restartButton.TabIndex = 6;
            this.restartButton.Text = "Play Again";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // pipeTop1
            // 
            this.pipeTop1.Image = global::FlappyBirdCSharp.Properties.Resources.pipedown;
            this.pipeTop1.Location = new System.Drawing.Point(318, -88);
            this.pipeTop1.Name = "pipeTop1";
            this.pipeTop1.Size = new System.Drawing.Size(52, 246);
            this.pipeTop1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeTop1.TabIndex = 1;
            this.pipeTop1.TabStop = false;
            // 
            // ground
            // 
            this.ground.Image = global::FlappyBirdCSharp.Properties.Resources.ground;
            this.ground.Location = new System.Drawing.Point(-24, 524);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(924, 179);
            this.ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ground.TabIndex = 3;
            this.ground.TabStop = false;
            // 
            // pipeBottom1
            // 
            this.pipeBottom1.Image = global::FlappyBirdCSharp.Properties.Resources.pipe;
            this.pipeBottom1.Location = new System.Drawing.Point(318, 402);
            this.pipeBottom1.Name = "pipeBottom1";
            this.pipeBottom1.Size = new System.Drawing.Size(52, 224);
            this.pipeBottom1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeBottom1.TabIndex = 2;
            this.pipeBottom1.TabStop = false;
            // 
            // scoreBackground
            // 
            this.scoreBackground.BackColor = System.Drawing.Color.Transparent;
            this.scoreBackground.Location = new System.Drawing.Point(12, 589);
            this.scoreBackground.Name = "scoreBackground";
            this.scoreBackground.Size = new System.Drawing.Size(561, 180);
            this.scoreBackground.TabIndex = 5;
            this.scoreBackground.TabStop = false;
            this.scoreBackground.Click += new System.EventHandler(this.scoreBackground_Click);
            // 
            // clouds1
            // 
            this.clouds1.Image = global::FlappyBirdCSharp.Properties.Resources.clouds;
            this.clouds1.Location = new System.Drawing.Point(559, 237);
            this.clouds1.Name = "clouds1";
            this.clouds1.Size = new System.Drawing.Size(198, 115);
            this.clouds1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clouds1.TabIndex = 7;
            this.clouds1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // lblGen
            // 
            this.lblGen.AutoSize = true;
            this.lblGen.BackColor = System.Drawing.Color.Transparent;
            this.lblGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblGen.Location = new System.Drawing.Point(464, 616);
            this.lblGen.Name = "lblGen";
            this.lblGen.Size = new System.Drawing.Size(68, 20);
            this.lblGen.TabIndex = 10;
            this.lblGen.Text = "Gen : 1";
            // 
            // bestScoreTime
            // 
            this.bestScoreTime.AutoSize = true;
            this.bestScoreTime.Location = new System.Drawing.Point(455, 651);
            this.bestScoreTime.Name = "bestScoreTime";
            this.bestScoreTime.Size = new System.Drawing.Size(65, 13);
            this.bestScoreTime.TabIndex = 11;
            this.bestScoreTime.Text = "Time Alive:0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(205, 634);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(305, 634);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bird
            // 
            this.bird.Image = global::FlappyBirdCSharp.Properties.Resources.bird;
            this.bird.Location = new System.Drawing.Point(179, 181);
            this.bird.Name = "bird";
            this.bird.Size = new System.Drawing.Size(43, 41);
            this.bird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bird.TabIndex = 13;
            this.bird.TabStop = false;
            // 
            // mainWin
            // 
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(769, 691);
            this.Controls.Add(this.bird);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.bestScoreTime);
            this.Controls.Add(this.lblGen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.pipeTop1);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.pipeBottom1);
            this.Controls.Add(this.scoreBackground);
            this.Controls.Add(this.clouds1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(785, 730);
            this.MinimumSize = new System.Drawing.Size(785, 730);
            this.Name = "mainWin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameKeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameKeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pipeTop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottom1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clouds1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.PictureBox pipeTop1;
        private System.Windows.Forms.PictureBox pipeBottom1;
        private System.Windows.Forms.PictureBox ground;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox scoreBackground;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.PictureBox clouds1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGen;
        private System.Windows.Forms.Label bestScoreTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox bird;
    }
}

