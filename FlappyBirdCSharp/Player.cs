using FlappyBirdCSharp.ANN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdCSharp
{
    [Serializable]
    /// <summary>
    /// Represents a player (bird) in the Flappy Bird game, controlled by a neural network.
    /// </summary>
    public class Player
    {
        PictureBox bird;

        /// <summary>
        /// Static identifier for the player.
        /// </summary>
        public static int id;

        /// <summary>
        /// The neural network controlling this player.
        /// </summary>
        public NeuralNetwork neuranNetwork { get; set; }

        /// <summary>
        /// The shape of the neural network.
        /// </summary>
        public int[] networkShape { get; set; }

        /// <summary>
        /// Indicates whether the player is alive.
        /// </summary>
        public bool isAlive { get; set; }

        /// <summary>
        /// The score achieved by the player.
        /// </summary>
        public double score { get; set; }

        /// <summary>
        /// Initializes a new player with a neural network and a visual bird.
        /// </summary>
        public Player(int[] networkShape)
        {
            this.networkShape = networkShape;            
            this.score = 0;
            this.isAlive = true;
            this.bird = new System.Windows.Forms.PictureBox();
            this.bird.Image = global::FlappyBirdCSharp.Properties.Resources.bird;
            this.bird.Location = new System.Drawing.Point(53, 175);
            this.bird.Name = "bird"+id;
            this.bird.Size = new System.Drawing.Size(50, 50);
            this.bird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bird.TabIndex = 0;
            this.bird.TabStop = false;
            this.bird.Visible = true;
            this.bird.BringToFront();
            
            neuranNetwork = new NeuralNetwork(networkShape);
        }

        /// <summary>
        /// Creates a clone of the player, including its neural network and visual representation.
        /// </summary>
        public Player clone()
        {
            Player result = new Player(networkShape);
            
            result.networkShape = networkShape;
            result.score = score;
            result.isAlive = isAlive;
            result.bird = new System.Windows.Forms.PictureBox();
            result.bird.Image = global::FlappyBirdCSharp.Properties.Resources.bird;
            result.bird.Location = new System.Drawing.Point(53, 175);
            result.bird.Name = "bird" + id;
            result.bird.Size = new System.Drawing.Size(50, 50);
            result.bird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            result.bird.TabIndex = 0;
            result.bird.TabStop = false;
            result.bird.Visible = true;
            result.bird.BringToFront();
            result.neuranNetwork = this.neuranNetwork;
            return result;
        }

        /// <summary>
        /// Resets the player's neural network.
        /// </summary>
        public void restartNetwork()
        {
            neuranNetwork = new NeuralNetwork(networkShape);
        }

        /// <summary>
        /// Moves the bird to a new vertical position.
        /// </summary>
        public void move (int top)
        {
            bird.Top = top;
            bird.Invalidate();
        }

        /// <summary>
        /// Gets the current vertical position of the bird.
        /// </summary>
        public int getTop()
        {
            return bird.Top;
        }

        /// <summary>
        /// Performs crossover between two parent players to produce a new player.
        /// </summary>
        public Player CrossOver(Player parentA,Player parentB)
        {
            Player result = clone();
            double tilt = parentA.score / (parentA.score + parentB.score);
            result.neuranNetwork = result.neuranNetwork.CrossOver(parentA.neuranNetwork, parentB.neuranNetwork,tilt);
            return result;
        }
        
        /// <summary>
        /// Gets the PictureBox representing the bird.
        /// </summary>
        public PictureBox getBird()
        {
            return bird;
        }
    }
}
