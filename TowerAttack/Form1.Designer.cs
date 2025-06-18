namespace TowerAttack
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.coinsLabel = new System.Windows.Forms.Label();
            this.waveLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.newWaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // coinsLabel
            // 
            this.coinsLabel.AutoSize = true;
            this.coinsLabel.BackColor = System.Drawing.Color.SkyBlue;
            this.coinsLabel.Font = new System.Drawing.Font("OCR A Extended", 12.8F);
            this.coinsLabel.Location = new System.Drawing.Point(2, 69);
            this.coinsLabel.Name = "coinsLabel";
            this.coinsLabel.Size = new System.Drawing.Size(127, 24);
            this.coinsLabel.TabIndex = 0;
            this.coinsLabel.Text = "coins:100";
            // 
            // waveLabel
            // 
            this.waveLabel.AutoSize = true;
            this.waveLabel.BackColor = System.Drawing.Color.SkyBlue;
            this.waveLabel.Font = new System.Drawing.Font("OCR A Extended", 12.8F);
            this.waveLabel.Location = new System.Drawing.Point(12, 33);
            this.waveLabel.Name = "waveLabel";
            this.waveLabel.Size = new System.Drawing.Size(101, 24);
            this.waveLabel.TabIndex = 1;
            this.waveLabel.Text = "wave: 1";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.BackColor = System.Drawing.Color.SkyBlue;
            this.gameOverLabel.Font = new System.Drawing.Font("Ebrima", 45.2F, System.Drawing.FontStyle.Bold);
            this.gameOverLabel.Location = new System.Drawing.Point(1, 168);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(483, 101);
            this.gameOverLabel.TabIndex = 5;
            this.gameOverLabel.Text = "GAME OVER";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newWaveButton
            // 
            this.newWaveButton.BackColor = System.Drawing.Color.SkyBlue;
            this.newWaveButton.Font = new System.Drawing.Font("OCR A Extended", 16.8F, System.Drawing.FontStyle.Bold);
            this.newWaveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newWaveButton.Location = new System.Drawing.Point(236, 56);
            this.newWaveButton.Name = "newWaveButton";
            this.newWaveButton.Size = new System.Drawing.Size(197, 37);
            this.newWaveButton.TabIndex = 6;
            this.newWaveButton.Text = "NEW WAVE";
            this.newWaveButton.UseVisualStyleBackColor = false;
            this.newWaveButton.Click += new System.EventHandler(this.newWaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.newWaveButton);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.waveLabel);
            this.Controls.Add(this.coinsLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label coinsLabel;
        private System.Windows.Forms.Label waveLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Button newWaveButton;
    }
}

