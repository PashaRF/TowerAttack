using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerAttack
{
    public partial class Form1 : Form
    {
        #region variables&Bools
        int wave = 0;
        int timer = 0;
        int reloadSpeed = 9;
        int bulletSize = 10;
        int bulletDamage = 4;
        int bulletSpeed = 10;
        int bulletNum = 1;
        int monsterHealth = 100;
        int monsterSpeed = 1;
        int coins = 100;
        int towerCost = 25;
        int menuYSpacing = 8;
        int menuXSpacing = 16;
        int menuIconWidth = 20;
        int menuIconHeight = 20;
        int towerSelected;
        bool menuOpen = false;
        bool targetSet = false;
        int currentOpen;
        int mouseX;
        int mouseY;
        int targetX;
        int targetY;
        int healthBarSize = 45;

        bool upArrowDown;
        bool downArrowDown;
        bool leftArrowDown;
        bool rightArrowDown;

        bool monsterDead = true;
        bool shootBullets = true;

        Rectangle monster = new Rectangle(1175, 20, 35, 35);
        Rectangle monsterEye1 = new Rectangle(1180, 35, 8, 8);
        Rectangle monsterEye2 = new Rectangle(1200, 35, 8, 8);
        Rectangle monsterHealthBar = new Rectangle(1170, 15, 0, 5);
        #endregion
        #region brushColours
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush lightGrayBrush = new SolidBrush(Color.FromArgb(255, 140, 140, 140));
        SolidBrush mediumGrayBrush = new SolidBrush(Color.FromArgb(255, 110, 110, 110));
        SolidBrush darkGrayBrush = new SolidBrush(Color.FromArgb(255, 80, 80, 80));
        SolidBrush darkestGrayBrush = new SolidBrush(Color.FromArgb(255, 50, 50, 50));
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        SolidBrush testBrush = new SolidBrush(Color.FromArgb(255, 100, 0, 0));
        #endregion
        #region lists&Arrays
        int[] numUpgrades = new int[5];
        bool[] towerSpaceBought = new bool[5];
        bool[] towerOpen = new bool[5];
        string[] towerType = new string[5];
        Rectangle[] towerSpace = new Rectangle[5];
        Rectangle[] backTowerSpace = new Rectangle[5];
        Rectangle[] towerMenu = new Rectangle[4];
        int[,] towerLevel = new int[5, 4]
        {
            { 0, 0, 0, 0 },
            { 1, 0, 0, 0 },
            { 2, 0, 0, 0 },
            { 3, 0, 0, 0 },
            { 4, 0, 0, 0 },
        };
        List<Rectangle> bulletList = new List<Rectangle>();
        List<float> bulletXSpeedList = new List<float>();
        List<float> bulletYSpeedList = new List<float>();

        Rectangle[] monsterParts = new Rectangle[4];
        #endregion
        Random randGen = new Random();
        public Form1()
        {
            InitializeComponent();
            #region setup
            closeMenuLabel.Hide();
            upgradeLabel1.Hide();
            upgradeLabel2.Hide();
            upgradeLabel3.Hide();
            coinsLabel.Text = $"coins: {coins}";
            waveLabel.Text = $"wave: {wave}";
            towerSpace[0] = new Rectangle(50, 290, 65, 65);
            towerSpace[1] = new Rectangle(155, 290, 65, 65);
            towerSpace[2] = new Rectangle(260, 290, 65, 65);
            towerSpace[3] = new Rectangle(100, 395, 65, 65);
            towerSpace[4] = new Rectangle(205, 395, 65, 65);

            backTowerSpace[0] = new Rectangle(45, 285, 75, 75);
            backTowerSpace[1] = new Rectangle(150, 285, 75, 75);
            backTowerSpace[2] = new Rectangle(255, 285, 75, 75);
            backTowerSpace[3] = new Rectangle(95, 390, 75, 75);
            backTowerSpace[4] = new Rectangle(200, 390, 75, 75);

            monsterParts[0] = monster;
            monsterParts[1] = monsterEye1;
            monsterParts[2] = monsterEye2;
            monsterParts[3] = monsterHealthBar;
            #endregion
            for (int i = 0; i < towerSpaceBought.Count(); i++)
            {
                towerType[i] = "original";
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timer > reloadSpeed)
            {
                CreateBullet();
                timer = 0;
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                float y;
                float x;
                y = bulletList[i].Y - bulletYSpeedList[i];
                x = bulletList[i].X - bulletXSpeedList[i];
                bulletList[i] = new Rectangle((int)x, (int)y, bulletList[i].Width, bulletList[i].Height);
                if (bulletList[i].Y > this.Height + 50)
                {
                    DestroyBullet(i);
                }
            }

            if (downArrowDown == true && monsterParts[0].Y <= this.Height - monsterParts[0].Height)
            {
                for (int i = 0; i < monsterParts.Count(); i++)
                {
                    monsterParts[i].Y = monsterParts[i].Y + monsterSpeed;
                }
            }

            if (upArrowDown == true && monsterParts[0].Y >= 0)
            {
                for (int i = 0; i < monsterParts.Count(); i++)
                {
                    monsterParts[i].Y = monsterParts[i].Y - monsterSpeed;
                }
            }

            if (leftArrowDown == true && monsterParts[0].X >= 0)
            {
                for (int i = 0; i < monsterParts.Count(); i++)
                {
                    monsterParts[i].X = monsterParts[i].X - monsterSpeed;
                }
            }

            if (rightArrowDown == true && monsterParts[0].X <= this.Width - monsterParts[0].Width)
            {
                for (int i = 0; i < monsterParts.Count(); i++)
                {
                    monsterParts[i].X = monsterParts[i].X + monsterSpeed;
                }
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                if (monsterParts[0].IntersectsWith(bulletList[i]))
                {
                    DestroyBullet(i);
                    monsterHealth = monsterHealth - 5;
                    coins = coins + 1;
                    if (wave != 0) 
                    { 
                        monsterParts[3] = new Rectangle(monsterParts[3].X, monsterParts[3].Y,
                        Convert.ToInt16((healthBarSize * monsterHealth) / (healthBarSize * 3 * wave)), monsterParts[3].Height);
                    }
                    coinsLabel.Text = $"coins: {coins}";
                    if (monsterHealth <= 0)
                    {
                        coins = coins + 100 * wave;
                        coinsLabel.Text = $"coins: {coins}";
                        for (int j = 0; j < monsterParts.Count(); j++)
                        {
                            monsterParts[j].X = monsterParts[j].X + 1000;
                        }
                        monsterDead = true;
                        shootBullets = false;
                        newWaveButton.Show();
                    }
                }
            }
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region static
            // checks if each tower space is bought, and then paints it according to type
            for (int i = 0; i < towerSpace.Count(); i++)
            {
                e.Graphics.FillRectangle(darkestGrayBrush, backTowerSpace[i]);
                if (towerSpaceBought[i] == false)
                {
                    e.Graphics.FillRectangle(lightGrayBrush, towerSpace[i]);
                }
                else
                {
                    int weight1 = 50 + (60 * towerLevel[i, 1]);
                    int weight2 = 50 + (60 * towerLevel[i, 2]);
                    int weight3 = 50 + (60 * towerLevel[i, 3]);

                    SolidBrush towerBrush = new SolidBrush(Color.FromArgb(255, weight1, weight2, weight3));
                    e.Graphics.FillRectangle(towerBrush, towerSpace[i]);
                }
            }
            // checks if the menu is open, and then displays it
            if (menuOpen == true)
            {
                coinsLabel.Text = $"coins: {coins}";
                e.Graphics.FillRectangle(redBrush, towerMenu[0]);
                for (int i = 1; i < towerMenu.Count(); i++)
                {
                    e.Graphics.FillRectangle(greenBrush, towerMenu[i]);
                }
                e.Graphics.DrawString("X", DefaultFont, blackBrush, towerMenu[0].X, towerMenu[0].Y);
                e.Graphics.DrawString("I", DefaultFont, blackBrush, towerMenu[1].X, towerMenu[1].Y);
                e.Graphics.DrawString("II", DefaultFont, blackBrush, towerMenu[2].X, towerMenu[2].Y);
                e.Graphics.DrawString("III", DefaultFont, blackBrush, towerMenu[3].X, towerMenu[3].Y);

                for (int i = 1; i < towerMenu.Count(); i++)
                {
                    if (100 >= (25 * Math.Pow(2, towerLevel[currentOpen, i])) && numUpgrades[currentOpen] <= 3)
                    {
                        e.Graphics.DrawString($"{25 * Math.Pow(2, towerLevel[currentOpen, i])}",
                            DefaultFont, blackBrush, towerMenu[i].X + 5, towerMenu[i].Y + 8);
                    }
                    else
                    {
                        e.Graphics.DrawString($"", DefaultFont, blackBrush, towerMenu[i].X + 5, towerMenu[i].Y + 8);
                    }
                }
            }
            e.Graphics.FillEllipse(greenBrush, monsterParts[0]);
            e.Graphics.FillRectangle(blackBrush, monsterParts[1]);
            e.Graphics.FillRectangle(blackBrush, monsterParts[2]);
            e.Graphics.FillRectangle(redBrush, monsterParts[3]);
            #endregion
            #region dynamic
            for (int i = 0; i < bulletList.Count; i++)
            {
                e.Graphics.FillEllipse(darkestGrayBrush, bulletList[i]);
            }
            #endregion
        }
        private void OpenMenu(int towerChosen)
        {
            currentOpen = towerChosen;
            // places the menu icons above the respective tower
            menuOpen = true;
            towerSelected = towerChosen;
            for (int i = 0; i < towerMenu.Count(); i++)
            {
                int a = i * 2;
                int b = a - 3;
                towerMenu[i] = new Rectangle(towerSpace[towerChosen].X + (towerSpace[towerChosen].Width / 2) + (menuXSpacing * b) - (menuIconWidth / 2),
                    towerSpace[towerChosen].Y - menuYSpacing - menuIconHeight, menuIconWidth, menuIconHeight);
            }
        }
        private void PurchaseUpgrade(int upgradeChoice, int price)
        {
            numUpgrades[currentOpen]++;
            towerSpaceBought[currentOpen] = true;
            // tower is upgraded
            coins = coins - price;
            towerLevel[currentOpen, upgradeChoice]++;
            // tower type is assigned 
            if (upgradeChoice == 1)
            {
                towerType[currentOpen] = "doubleShot";
            }
            else if (upgradeChoice == 2)
            {
                towerType[currentOpen] = "poison";
            }
            else
            {
                towerType[currentOpen] = "destroyer";
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            {
                // checks if the mouse clicks on each tower
                for (int i = 0; i < towerSpace.Count(); i++)
                {
                    if ((e.X > towerSpace[i].X) && (e.X < towerSpace[i].X + towerSpace[i].Width) &&
                              (e.Y > towerSpace[i].Y) && (e.Y < towerSpace[i].Y + towerSpace[i].Height) && menuOpen == false)
                    {
                        OpenMenu(i);
                    }
                }
                // checks if the mouse clicks each menu slot
                if (menuOpen == true)
                {
                    for (int i = 1; i < towerMenu.Count(); i++)
                    {
                        if ((e.X > towerMenu[i].X) && (e.X < towerMenu[i].X + towerMenu[i].Width) &&
                              (e.Y > towerMenu[i].Y) && (e.Y < towerMenu[i].Y + towerMenu[i].Height))
                        {
                            int cost = Convert.ToInt16(25 * Math.Pow(2, towerLevel[currentOpen, i]));
                            if (coins >= cost && numUpgrades[currentOpen] < 4 && cost <= 100)
                            {
                                switch (i)
                                {
                                    case 1:
                                        if (towerLevel[currentOpen, 2] != 0 && towerLevel[currentOpen, 3] != 0) { }
                                        else
                                        {
                                            PurchaseUpgrade(i, cost);
                                        }
                                        break;
                                    case 2:
                                        if (towerLevel[currentOpen, 1] != 0 && towerLevel[currentOpen, 3] != 0) { }
                                        else
                                        {
                                            PurchaseUpgrade(i, cost);

                                        }
                                        break;
                                    case 3:
                                        if (towerLevel[currentOpen, 1] != 0 && towerLevel[currentOpen, 2] != 0) 
                                        { 
                                        }
                                        else
                                        {
                                            PurchaseUpgrade(i, cost);
                                        }
                                        break;
                                }

                            }
                        }
                    }
                    if ((e.X > towerMenu[0].X) && (e.X < towerMenu[0].X + towerMenu[0].Width) &&
                              (e.Y > towerMenu[0].Y) && (e.Y < towerMenu[0].Y + towerMenu[0].Height))
                    {
                        menuOpen = false;
                        towerOpen[currentOpen] = false;
                    }
                }
            }
        }
        private void CreateBullet()
        {
            if (shootBullets == true)
            {
                for (int i = 0; i < towerSpaceBought.Count(); i++)
                {
                    int variation = randGen.Next(0, 8);
                    variation = variation - 4;
                    if (towerSpaceBought[i] == true)
                    {
                        Rectangle newBullet = new Rectangle(towerSpace[i].X + (towerSpace[i].Width / 2) - (bulletSize / 2) + variation,
                            towerSpace[i].Y, bulletSize, bulletSize);
                        bulletList.Add(newBullet);
                        int xPos;
                        int yPos;
                        if (targetSet == false)
                        {
                            xPos = mouseX;
                            yPos = mouseY;
                        }
                        else
                        {
                            xPos = targetX;
                            yPos = targetY;
                        }
                        FindBulletVelocity(newBullet, xPos, yPos);
                    }
                }
            }
        }
        private void DestroyBullet(int bulletNum)
        {
            bulletList.RemoveAt(bulletNum);
            bulletXSpeedList.RemoveAt(bulletNum);
            bulletYSpeedList.RemoveAt(bulletNum);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            // waveLabel.Text = $"x {e.X} yo and y {e.Y}";
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (targetSet == false)
            {
                targetSet = true;
                targetX = e.X;
                targetY = e.Y;
            }
            else
            {
                targetSet = false;
            }
        }
        private void FindBulletVelocity(Rectangle newBullet, int xPlace, int yPlace)
        {
            float testTopX = Convert.ToSingle(bulletSpeed * (newBullet.X - xPlace));
            float testTopY = Convert.ToSingle(bulletSpeed * (newBullet.Y - yPlace));
            float testBottom = Convert.ToSingle(Math.Sqrt(Math.Pow(yPlace - newBullet.Y, 2) + Math.Pow(xPlace - newBullet.X, 2)));
            float bulletXSpeed = testTopX / testBottom;
            float bulletYSpeed = testTopY / testBottom;
            bulletYSpeedList.Add(bulletYSpeed);
            bulletXSpeedList.Add(bulletXSpeed);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (monsterDead == false)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        upArrowDown = true;
                        break;
                    case Keys.S:
                        downArrowDown = true;
                        break;
                    case Keys.A:
                        leftArrowDown = true;
                        break;
                    case Keys.D:
                        rightArrowDown = true;
                        break;
                }
            }
            if (e.KeyCode == Keys.J)
            {
                if (shootBullets == false)
                {
                    shootBullets = true;
                }
                else
                {
                    shootBullets = false;
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    upArrowDown = false;
                    break;
                case Keys.S:
                    downArrowDown = false;
                    break;
                case Keys.A:
                    leftArrowDown = false;
                    break;
                case Keys.D:
                    rightArrowDown = false;
                    break;
            }
        }
        private void newWaveButton_Click(object sender, EventArgs e)
        {
            wave++;
            waveLabel.Text = $"wave: {wave}";
            monsterDead = false;
            for (int i = 0; i < 4; i++)
            {
                monsterParts[i].X = monsterParts[i].X - 1000;
            }
            monsterParts[0].Y = 20;
            monsterParts[1].Y = 35;
            monsterParts[2].Y = 35;
            monsterParts[3].Y = 12;
            shootBullets = true;
            newWaveButton.Hide();
            monsterHealth = 150 * wave;
            this.Focus();
        }
        #region oops! 
        private void Form1_Click(object sender, EventArgs e) { }
        #endregion
    }
}