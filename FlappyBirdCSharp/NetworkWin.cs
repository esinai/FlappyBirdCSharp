using FlappyBirdCSharp.ANN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdCSharp
{
    public partial class NetworkWin : Form
    {
        public mainWin main;
        public NetworkWin(mainWin main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void NetworkWin_Load(object sender, EventArgs e)
        {

        }
        public void setNetwork(NeuralNetwork network, double[] inputs)
        {
            neuralNetworkControl1.SetNetwork(network,inputs);
        }
    }
}
