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
        int bulletDamage = 4;
        int bulletSpeed = 5;
        int bulletNum = 1;
        int enemyHealth = 20;
        int playerHealth = 100;
        int coins = 100;
        int towerCost = 25;
        int menuYSpacing = 8;
        int menuXSpacing = 16;
        int menuIconWidth = 20;
        int menuIconHeight = 20;
        int towerSelected;
        bool menuOpen = false;
        int currentOpen;
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
        #endregion
        #region lists&Arrays
        bool[] towerSpaceBought = new bool[5];
        bool[] towerOpen = new bool[5];
        string[] towerType = new string[5];
        Rectangle[] towerSpace = new Rectangle[5];
        Rectangle[] towerMenu = new Rectangle[4];
        int[,] towerLevel = new int[5,4] 
        {
            { 0, 0, 0, 0 },
            { 1, 0, 0, 0 },
            { 2, 0, 0, 0 },
            { 3, 0, 0, 0 },
            { 4, 0, 0, 0 },
        };
        Rectangle testRec = new Rectangle(50, 50, 50, 50);
        #endregion
        Random randGen = new Random();
        public Form1()
        {
            InitializeComponent();
            coinsLabel.Text = $"coins: {coins}";
            waveLabel.Text = $"wave: {wave}";
            towerSpace[0] = new Rectangle(50, 290, 65, 65);
            towerSpace[1] = new Rectangle(155, 290, 65, 65);
            towerSpace[2] = new Rectangle(260, 290, 65, 65);
            towerSpace[3] = new Rectangle(100, 395, 65, 65);
            towerSpace[4] = new Rectangle(205, 395, 65, 65);

         /*   towerMenu[0] = new Rectangle(0, 0, menuIconWidth, menuIconHeight);
            towerMenu[1] = new Rectangle(0, 0, menuIconWidth, menuIconHeight);
            towerMenu[2] = new Rectangle(0, 0, menuIconWidth, menuIconHeight);
            towerMenu[3] = new Rectangle(0, 0, menuIconWidth, menuIconHeight); */

            for (int i = 0; i < towerSpaceBought.Count(); i++)
            {
                towerType[i] = "original";
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // checks if each tower space is bought, and then paints it according to type
            for (int i = 0; i < towerSpace.Count(); i++)
            {
                if (towerSpaceBought[i] == false)
                {
                    e.Graphics.FillRectangle(lightGrayBrush, towerSpace[i]);
                }
                else
                {
                    switch (towerType[i])
                    {
                        case "original":
                            e.Graphics.FillRectangle(darkestGrayBrush, towerSpace[i]);
                            break;
                        case "doubleShot":
                            e.Graphics.FillRectangle(purpleBrush, towerSpace[i]);
                            break;
                        case "poison":
                            e.Graphics.FillRectangle(greenBrush, towerSpace[i]);
                            break;
                        case "destroyer":
                            e.Graphics.FillRectangle(redBrush, towerSpace[i]);
                            break;
                    }
                }
            }
            // checks if the menu is open, and then displays it
            if (menuOpen == true)
            {
               // e.Graphics.FillRectangle(redBrush, testRec);
                
                for (int i = 0; i < towerMenu.Count(); i++)
                {
                    e.Graphics.FillRectangle(yellowBrush, towerMenu[i]);
                } 
            }
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
                towerMenu[i] = new Rectangle(towerSpace[towerChosen].X + (towerSpace[towerChosen].Width /2 ) + (menuXSpacing * b) - (menuIconWidth / 2), 
                    towerSpace[towerChosen].Y - menuYSpacing -menuIconHeight, menuIconWidth, menuIconHeight);
             /*   int a = towerChosen * 2;
                int b = a - 3;
                towerMenu[i] = new Rectangle (towerSpace[towerChosen].X + (towerSpace[towerChosen].Width / 2) + (b * menuXSpacing) - (2 * menuIconWidth),
                towerSpace[towerChosen].Y - menuYSpacing - menuIconHeight, menuIconWidth, menuIconHeight); */
                towerOpen[i] = true;
            }
        }
        private void PurchaseUpgrade(int upgradeChoice)
        {
            // tower is upgraded
            upgradeChoice--;
            switch (upgradeChoice)
            {
                case 0:
                    coins = coins - 25;
                    towerLevel[upgradeChoice, towerSelected]++;
                    break;
                case 1:
                    coins = coins - 25;
                    towerLevel[upgradeChoice, towerSelected]++;
                    break;
                case 2:
                    coins = coins - 25;
                    towerLevel[upgradeChoice, towerSelected]++;
                    break;
            }
            // tower type is assigned 
            if (upgradeChoice == 0)
            {
                towerType[upgradeChoice] = "doubleShot";
            }
            else if (upgradeChoice == 1)
            {
                towerType[upgradeChoice] = "poison";
            }
            else
            {
                towerType[upgradeChoice] = "destroyer";
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
                              (e.Y > towerMenu[i].Y) && (e.Y < towerMenu[i].Y + towerMenu[i].Height) && coins > 25)
                        {
                            PurchaseUpgrade(i);
                        }
                    }
                    if ((e.X > towerMenu[0].X) && (e.X < towerMenu[0].X + towerMenu[0].Width) &&
                              (e.Y > towerMenu[0].Y) && (e.Y < towerMenu[0].Y + towerMenu[0].Height))
                    {
                        menuOpen = false;
                        towerOpen[currentOpen] = false;
                        towerMenu[currentOpen] = new Rectangle(0,0,menuIconWidth, menuIconHeight);
                    }
                }
            }
        }

        #region oops! 
        private void Form1_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}


