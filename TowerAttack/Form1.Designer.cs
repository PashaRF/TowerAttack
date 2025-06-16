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
            this.coinsLabel = new System.Windows.Forms.Label();
            this.waveLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.upgradeLabel3 = new System.Windows.Forms.Label();
            this.upgradeLabel2 = new System.Windows.Forms.Label();
            this.upgradeLabel1 = new System.Windows.Forms.Label();
            this.closeMenuLabel = new System.Windows.Forms.Label();
            this.newWaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // coinsLabel
            // 
            this.coinsLabel.AutoSize = true;
            this.coinsLabel.Location = new System.Drawing.Point(413, 32);
            this.coinsLabel.Name = "coinsLabel";
            this.coinsLabel.Size = new System.Drawing.Size(66, 16);
            this.coinsLabel.TabIndex = 0;
            this.coinsLabel.Text = "coins: 100";
            // 
            // waveLabel
            // 
            this.waveLabel.AutoSize = true;
            this.waveLabel.Location = new System.Drawing.Point(37, 38);
            this.waveLabel.Name = "waveLabel";
            this.waveLabel.Size = new System.Drawing.Size(49, 16);
            this.waveLabel.TabIndex = 1;
            this.waveLabel.Text = "wave 1";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // upgradeLabel3
            // 
            this.upgradeLabel3.AutoSize = true;
            this.upgradeLabel3.BackColor = System.Drawing.Color.Transparent;
            this.upgradeLabel3.Font = new System.Drawing.Font("Ebrima", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgradeLabel3.Location = new System.Drawing.Point(393, 185);
            this.upgradeLabel3.Name = "upgradeLabel3";
            this.upgradeLabel3.Size = new System.Drawing.Size(25, 23);
            this.upgradeLabel3.TabIndex = 2;
            this.upgradeLabel3.Text = "III";
            this.upgradeLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upgradeLabel2
            // 
            this.upgradeLabel2.AutoSize = true;
            this.upgradeLabel2.BackColor = System.Drawing.Color.Transparent;
            this.upgradeLabel2.Font = new System.Drawing.Font("Ebrima", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgradeLabel2.Location = new System.Drawing.Point(241, 291);
            this.upgradeLabel2.Name = "upgradeLabel2";
            this.upgradeLabel2.Size = new System.Drawing.Size(20, 23);
            this.upgradeLabel2.TabIndex = 3;
            this.upgradeLabel2.Text = "II";
            this.upgradeLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upgradeLabel1
            // 
            this.upgradeLabel1.AutoSize = true;
            this.upgradeLabel1.BackColor = System.Drawing.Color.Transparent;
            this.upgradeLabel1.Font = new System.Drawing.Font("Ebrima", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgradeLabel1.Location = new System.Drawing.Point(325, 315);
            this.upgradeLabel1.Name = "upgradeLabel1";
            this.upgradeLabel1.Size = new System.Drawing.Size(15, 23);
            this.upgradeLabel1.TabIndex = 4;
            this.upgradeLabel1.Text = "I";
            this.upgradeLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeMenuLabel
            // 
            this.closeMenuLabel.AutoSize = true;
            this.closeMenuLabel.BackColor = System.Drawing.Color.Transparent;
            this.closeMenuLabel.Font = new System.Drawing.Font("Ebrima", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeMenuLabel.Location = new System.Drawing.Point(243, 325);
            this.closeMenuLabel.Name = "closeMenuLabel";
            this.closeMenuLabel.Size = new System.Drawing.Size(21, 23);
            this.closeMenuLabel.TabIndex = 5;
            this.closeMenuLabel.Text = "X";
            this.closeMenuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newWaveButton
            // 
            this.newWaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.newWaveButton.Font = new System.Drawing.Font("OCR A Extended", 16.8F, System.Drawing.FontStyle.Bold);
            this.newWaveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newWaveButton.Location = new System.Drawing.Point(160, 28);
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
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.newWaveButton);
            this.Controls.Add(this.closeMenuLabel);
            this.Controls.Add(this.upgradeLabel1);
            this.Controls.Add(this.upgradeLabel2);
            this.Controls.Add(this.upgradeLabel3);
            this.Controls.Add(this.waveLabel);
            this.Controls.Add(this.coinsLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Label upgradeLabel3;
        private System.Windows.Forms.Label upgradeLabel2;
        private System.Windows.Forms.Label upgradeLabel1;
        private System.Windows.Forms.Label closeMenuLabel;
        private System.Windows.Forms.Button newWaveButton;
    }
}

