
namespace FlappyBirdCSharp
{
    partial class NetworkWin
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
            this.neuralNetworkControl1 = new FlappyBirdCSharp.UCUtils.NeuralNetworkControl();
            this.SuspendLayout();
            // 
            // neuralNetworkControl1
            // 
            this.neuralNetworkControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.neuralNetworkControl1.BackColor = System.Drawing.Color.LightBlue;
            this.neuralNetworkControl1.Location = new System.Drawing.Point(21, 12);
            this.neuralNetworkControl1.Name = "neuralNetworkControl1";
            this.neuralNetworkControl1.Size = new System.Drawing.Size(942, 661);
            this.neuralNetworkControl1.TabIndex = 0;
            // 
            // NetworkWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 685);
            this.Controls.Add(this.neuralNetworkControl1);
            this.Location = new System.Drawing.Point(800, 0);
            this.Name = "NetworkWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NetworkWin";
            this.Load += new System.EventHandler(this.NetworkWin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCUtils.NeuralNetworkControl neuralNetworkControl1;
    }
}