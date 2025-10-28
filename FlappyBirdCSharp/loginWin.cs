using FlappyBirdCSharp.ANN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdCSharp
{
    public partial class loginWin : Form
    {
        private mainWin mainWin;
        bool isClosing = false;
        public loginWin(mainWin mainWin)
        {
            InitializeComponent();
            this.mainWin = mainWin;
            isClosing = false;
        }

        private void loginWin_Load(object sender, EventArgs e)
        {
            isClosing = false;
        }

        private void btnPlaySingel_Click(object sender, EventArgs e)
        {
            mainWin.startGame(NetParams.GAME_MODE.PLAYING);
            isClosing = true;
            this.Close();
        }

        private void btnTrainMode_Click(object sender, EventArgs e)
        {
            mainWin.startGame(NetParams.GAME_MODE.TRAINING);
            isClosing = true;
            this.Close();
        }

        private void btnLoadPlayer_Click(object sender, EventArgs e)
        {
            mainWin.startGame(NetParams.GAME_MODE.LOADING);
            isClosing = true;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            mainWin.startGame(NetParams.GAME_MODE.EXIT);
            isClosing = false;
            this.Close();
        }

        private void loginWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                Application.Exit();
            }
        }
    }
}
