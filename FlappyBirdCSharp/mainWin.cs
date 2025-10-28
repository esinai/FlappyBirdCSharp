using FlappyBirdCSharp.ANN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdCSharp
{
    public partial class mainWin : Form
    {
        
        // initialize variables
        NetParams.GAME_MODE mode;
        int cloudSpeed = 2;
        int pipeSpeed = 10;
        int gravity = 2;
        int score = 0;
        int count = 0;
        int cloudCount = 0;
        Player AIPlyaer;
        bool isClosed = false;

        NetworkWin networkWin;
        Population population;
        Stopwatch stopwatch;
        int genration;
        public mainWin()
        {
            InitializeComponent();
            isClosed = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            btnLoad.Visible = false;
            btnLoad.Enabled = false;
            loginWin login = new loginWin(this);
            login.ShowDialog();
            genration = 1;
            //this.StartPosition = 
            //Set ground as parent for score text 


        }
        // what happens when timmer is running 
        private void gameTimerEvent(object sender, EventArgs e)
        {
            switch (mode)
            {
                case NetParams.GAME_MODE.PLAYING:
                    playGame();
                    break;
                case NetParams.GAME_MODE.TRAINING:
                    trainGame();
                    break;
                case NetParams.GAME_MODE.LOADING:
                    loadGame();
                    break;
                default:
                    break;
            }
            
            // Collision detection 
            if (checkCollitions()){
                endGame();
            }
            
            this.Invalidate();

        }

        private void loadGame()
        {
            double[] inputs;
            double[] outputs;
            double out1;
            inputs = getInput(AIPlyaer);
            outputs = AIPlyaer.neuranNetwork.Forward(inputs);
            out1 = NetParams.Sigmoid(outputs[0]);
            if (out1 > 0.444)
            {
                gravity = -20;
            }
            else
            {
                gravity = 5;
            }
            movePlayer(gravity, AIPlyaer);
            pipeBottom1.Left -= pipeSpeed;
            pipeTop1.Left -= pipeSpeed;

            clouds1.Left -= cloudSpeed;
            scoreText.Text = "Score: " + score;
            CheckClouds();
            CheckPipes();
        }

        private void trainGame()
        {

            //bird.Top += gravity;

            double[] inputs;
            double[] outputs;
            double out1;
            //moveAll(gravity);
            foreach (Player p in population.players)
            {
                inputs = getInput(p);
                outputs = p.neuranNetwork.Forward(inputs);
                out1 = NetParams.Sigmoid(outputs[0]);
                if (out1 > 0.5)
                {
                    gravity = -20;
                }
                else
                {
                    gravity = 5;
                }
                movePlayer(gravity, p);
            }

            pipeBottom1.Left -= pipeSpeed;
            pipeTop1.Left -= pipeSpeed;

            clouds1.Left -= cloudSpeed;
            scoreText.Text = "Score: " + score;

            label2.Text = "Alive : " + population.numOfAlive();
            // respawn clouds 

            CheckClouds();
            CheckPipes();

        }

        private void CheckPipes()
        {
            // move pipes to the left during timmer operation
            if (pipeBottom1.Left < -150)
            {
                int left = NetParams.randomNum.Next(650, 950);
                pipeBottom1.Left = pipeTop1.Left = left;
                score++;
                pipeSpeed++;
                count++;
                if (count % 2 == 0)
                {
                    pipeTop1.Top = NetParams.randomNum.Next(-94, -31);
                }
                else if (count % 2 == 1)
                {
                    pipeTop1.Top = NetParams.randomNum.Next(-31, -10);
                }
                pipeBottom1.Top = NetParams.randomNum.Next(320, 400);
            }

            // increase difficulty 
            if (score > 5 && score <= 10)
            {
                pipeSpeed = 8;
            }

            if (score > 10 && score <= 15)
            {
                pipeSpeed = 10;
            }
        }

        private void CheckClouds()
        {
            if (clouds1.Left < -200)
            {
                cloudCount++;
                clouds1.Left = 950;
                // set random vertical position for clouds
                if (cloudCount % 2 == 0)
                {
                    clouds1.Top = NetParams.randomNum.Next(158, 386);
                }
                else if (cloudCount % 2 == 1)
                {
                    clouds1.Top = NetParams.randomNum.Next(237, 368);
                }
            }
        }

        private void playGame()
        {
            pipeBottom1.Left -= pipeSpeed;
            pipeTop1.Left -= pipeSpeed;
            bird.Top += gravity;
            clouds1.Left -= cloudSpeed;
            scoreText.Text = "Score: " + score;
            CheckClouds();
            CheckPipes();
        }

        private bool checkCollitions()
        {
           if (mode == NetParams.GAME_MODE.PLAYING)
            {
                return (bird.Bounds.IntersectsWith(pipeBottom1.Bounds) ||
                bird.Bounds.IntersectsWith(pipeTop1.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds) ||
                bird.Top < -25);
                
            }
           if (mode == NetParams.GAME_MODE.LOADING)
            {
                if (AIPlyaer == null)
                    return false;
                return (AIPlyaer.getBird().Bounds.IntersectsWith(pipeBottom1.Bounds) ||
                AIPlyaer.getBird().Bounds.IntersectsWith(pipeTop1.Bounds) ||
                AIPlyaer.getBird().Bounds.IntersectsWith(ground.Bounds) ||
                AIPlyaer.getTop() < -25);
            }
            if (mode == NetParams.GAME_MODE.TRAINING)
            {
                bool tmp = true;
                foreach (Player p in population.players.Where(x => x.isAlive))
                {
                    tmp = (p.getBird().Bounds.IntersectsWith(pipeBottom1.Bounds) ||
                    p.getBird().Bounds.IntersectsWith(pipeTop1.Bounds) ||
                    p.getBird().Bounds.IntersectsWith(ground.Bounds) ||
                    p.getBird().Top < -25);
                    //tmp = !tmp;
                    p.score = stopwatch.Elapsed.TotalMilliseconds;
                    if (tmp)
                    {
                        p.isAlive = false;
                        p.getBird().Visible = false;

                    }
                }
                int alive = population.numOfAlive();
                label2.Text = "Alive : " + alive;
                return alive == 0;
            }
            return true;
        }

        private void movePlayer(int gravity, Player p)
        {
            p.move(p.getTop() + gravity);

        }

        private void drawLines(PaintEventArgs e)
        {
            if (mode != NetParams.GAME_MODE.TRAINING)
                return;
            double[] inputs = new double[3];
            Graphics g = e.Graphics;
            string str = "";
            Player toShow = population.players.OrderByDescending(j => j.score).FirstOrDefault();
            bestScoreTime.Text = "Best Time Alive: " + toShow.score;
            foreach (Player p in population.players)
            {
                if (!p.isAlive)
                    continue;
                int x = p.getBird().Location.X;
                int y = p.getBird().Location.Y;
                int x1 = pipeTop1.Location.X;
                int y1 = pipeTop1.Location.Y + pipeTop1.Height;
                int x2 = pipeBottom1.Location.X;
                int y2 = pipeBottom1.Location.Y;
                inputs = getInput(p);
                double [] output = p.neuranNetwork.Forward(inputs);
                
                networkWin.setNetwork(toShow.neuranNetwork,inputs);
                str = "x = " + x + " y = " + y + Environment.NewLine;
                str += "x1 = " + x1 + " y1 = " + y1 + Environment.NewLine;
                str += "x2 = " + x2 + " y2 = " + y2 + Environment.NewLine;
                str += "d1 = " + inputs[0] + " d2 = " + inputs[1] + Environment.NewLine;
                str += "d3 = " + inputs[2] + " output = " + output[0];
                
                if (x <= x1)
                {
                    g.DrawLine(new Pen(Brushes.Black), x + p.getBird().Width, y, x1, y1);
                }
                if (x <= x2)
                {
                    g.DrawLine(new Pen(Brushes.Black), x + p.getBird().Width, y + p.getBird().Height, x2, y2);
                }                              
            }           
            label1.Text = str;
        }

        private double [] getInput(Player p)
        {
            double[] inputs = new double[3];
            int x = p.getBird().Location.X;
            int y = p.getBird().Location.Y;
            int x1 = pipeTop1.Location.X;
            int y1 = pipeTop1.Location.Y + pipeTop1.Height;
            int x2 = pipeBottom1.Location.X;
            int y2 = pipeBottom1.Location.Y;


            inputs[0] = (x1 - x);
            inputs[1] = (y - y1);
            inputs[2] = (y2 - y);
            return inputs;
        }
        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (mode != NetParams.GAME_MODE.PLAYING)
                return;
            if (e.KeyCode == Keys.Space)
            {
                //When key is down gravity greater
                gravity = -20;
                //Suppress Key 'Ding' 
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
            
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (mode != NetParams.GAME_MODE.PLAYING)
                return;
            if (e.KeyCode == Keys.Space)
            {
                //When space key is up Gravity lessons
                gravity = 5;
            }
        }

        private void endGame()
        {
            switch(mode)
            {
                case NetParams.GAME_MODE.PLAYING:
                    bird.Visible = true;
                    isClosed = true;
                    endSingleGame();
                    break;
                case NetParams.GAME_MODE.TRAINING:
                    bird.Visible = false;
                    isClosed = true;
                    endTrainingGame();
                    break;
                case NetParams.GAME_MODE.LOADING:
                    bird.Visible = false;
                    isClosed = true;
                    endLoadingGame();
                    break;
                default:
                    break;
            }           
        }

        private void endLoadingGame()
        {
            
        }

        private void endTrainingGame()
        {
            genration++;
            pipeSpeed = 10;
            lblGen.Text = "Generation: " + genration;
            gameTimer.Stop();
            stopwatch.Stop();
            stopwatch.Reset();
            population.CreateNewGeneration();
            scoreText.Text += " Game Over!!!";
            foreach (Player p in population.players)
            {
                p.getBird().Location = new Point(53, 175);
                p.isAlive = true;
                p.getBird().Visible = true;
                p.getBird().Image = Properties.Resources.bird;
                p.getBird().BringToFront();
                p.score = 0;
                this.Controls.Add(p.getBird());
                //p.restartNetwork();

            }

            initScorePipesAndClouds();


            restartButton.Visible = false;
            restartButton.Enabled = false;
            //playBackgroundMusic();

            stopwatch.Start();
            gameTimer.Start();
        }

        private void endSingleGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!!";
            //Enable restart button
            restartButton.Visible = true;
            restartButton.Enabled = true;
        }

        public void startGame(NetParams.GAME_MODE mode)
        {
            this.mode = mode;
            switch (mode)
            {
                case NetParams.GAME_MODE.PLAYING:
                    this.Text = "Flappy Bird - Playing";
                    gameTimer.Interval = 30;
                    btnSave.Visible = false;
                    btnSave.Enabled = false;
                    label1.Text = "";
                    label2.Text = "";
                    lblGen.Visible = false;
                    bestScoreTime.Visible = false;
                    btnSave.Visible = false;
                    StartSingleGame();
                    break;
                case NetParams.GAME_MODE.TRAINING:
                    this.Text = "Flappy Bird - Training";
                    gameTimer.Interval = 2;
                    bird.Visible = false;
                    label1.Text = "";
                    label2.Text = "";
                    lblGen.Visible = true;
                    bestScoreTime.Visible = true;
                    btnSave.Visible = true;
                    StartTrainGame();
                    break;
                case NetParams.GAME_MODE.LOADING:
                    this.Text = "Flappy Bird - Loading";
                    bird.Visible = true;
                    gameTimer.Interval = 20;
                    restartButton.Visible = false;
                    label1.Text = "";
                    label2.Text = "";
                    lblGen.Visible = false;
                    bestScoreTime.Visible = false;
                    btnSave.Visible = false;
                    StartLoadPlayerGame();
                    break;
                case NetParams.GAME_MODE.EXIT:
                    Application.Exit();
                    break;
                default:
                    break;
            }

           
        }

        private void StartLoadPlayerGame()
        {
            initScorePipesAndClouds();
            if (!LoadPlayer())
            {
                MessageBox.Show("Failed to load player. Starting training mode instead.");
                startGame(NetParams.GAME_MODE.TRAINING);
                return;
            }
            AIPlyaer.getBird().Location = new Point(53, 175);
            this.Controls.Add(AIPlyaer.getBird());
            bird.Visible = false;
            gameTimer.Start();
        }

        private bool LoadPlayer()
        {
            try
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Set the filter to show only JSON files and then all files
                openFileDialog1.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1; // Selects the JSON filter by default
                openFileDialog1.InitialDirectory = folder;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the selected file
                    string filePath = openFileDialog1.FileName;
                    AIPlyaer = readFile(filePath);
                    return true;
                }

                return false;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading player: " + ex.Message);
                return false;
            }

        }

        private void StartTrainGame()
        {
            bird.Visible = false;
            stopwatch = new Stopwatch();
            initScorePipesAndClouds();
            population = new Population();
            restartButton.Visible = false;
            foreach (Player p in population.players)
            {
                p.getBird().Location = new Point(53, 175);
                p.isAlive = true;
                p.getBird().Visible = true;
                p.getBird().Image = Properties.Resources.bird;
                
                p.score = 0;
                this.Controls.Add(p.getBird());
                p.getBird().BringToFront();
            }

            networkWin = new NetworkWin(this);
            networkWin.Show();
            networkWin.setNetwork(population.players[0].neuranNetwork, null);
            gameTimer.Start();
        }

        private void initScorePipesAndClouds()
        {
            scoreText.Parent = ground;
            clouds1.SendToBack();
            scoreText.BackColor = Color.Transparent;
            pipeSpeed = 6;
            gravity = 5;
            score = 0;
            scoreText.Text = "Score: " + score;
            count = 0;
            pipeTop1.Location = new Point(318, -88);
            pipeBottom1.Location = new Point(318, 406);
            clouds1.Location = new Point(198, 115);
        }

        private void StartSingleGame()
        {
            initScorePipesAndClouds();
            bird.Location = new Point(53, 175);
            bird.Visible = true;
            restartButton.Visible = false;
            restartButton.Enabled = false;
            gameTimer.Start();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            //Reset the game when clicked 
            
           startGame(mode);
            restartButton.Visible = false;
            restartButton.Enabled = false;



        }

       

        private void scoreBackground_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawLines(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Player player= population.players.OrderByDescending(p => p.score).FirstOrDefault();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "\\"+DateTime.Now.ToString("dd.MM.yyyy.HH.mm")+ "_player.json";
            folder += fileName;
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = Newtonsoft.Json.JsonConvert.SerializeObject(player);
                writer = new StreamWriter(folder, false);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        public Player readFile(string path)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(path);
                var fileContents = reader.ReadToEnd();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folder += "\\player.json";
            Player player = readFile(folder);
            for (int i = 0; i < NetParams.POPULATION_SIZE; i++)
            {
                population.addPlayer(player);
            }
            restartButton_Click(null, null);
        }

        private void mainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosed)
            {
                Application.Exit();
            }
        }
    }
}
