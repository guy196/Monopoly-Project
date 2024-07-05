using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonopolyProject
{
    //jail, office depot toysrus random wheel ski go
    public partial class Form1 : Form
    {
        //cayn is player one, PlayerOneMoney is cyan Player money and playerOnePoistion is cyan player position
        //yellow is player two

        //can you check who is the winner every frame instead of in the onclicl

        Random rnd = new Random();

        PictureBox[] pictureBoxes = new PictureBox[32];//creates an array of pictureBoxes
        Shop[] shops = new Shop[32];//creates an array of shops

        PictureBox Dice = new PictureBox();
        PictureBox PlayerOneGrafix = new PictureBox();
        PictureBox PlayerTwoGrafix = new PictureBox();
        PictureBox background = new PictureBox();
        PictureBox[] cardInfoPictureBox = new PictureBox[24];
        

        Label playersMoney;
        Label TurnLabel;
        Label[] cardInfo = new Label[24];

        Label rules = new Label();


        int pictureBoxIndex = 0;
        int PlayerOneMoney = 15000;
        int PlayerTwoMoney = 15000;
        int ShopsPlayerOneOwn = 0;
        int ShopsPlayerTwoOwn = 0;
        int turn = 0;
        int playerOnePoistion = 0;
        int playerTwoPosition = 0;
        int cardInfoTop = 0;
        int gamblingMoney = 0;
        int wonOrLost = -1;
        public Form1()
        {
            InitializeComponent();





            //////////////////// creating the background
            background.Left = 139;
            background.Top = 139;
            background.Top = 139;
            background.Height = 700;
            background.Width = 700;
            background.BackgroundImage = Image.FromFile(@"pic/Background.png");
            background.BackgroundImageLayout = ImageLayout.Stretch;
         
            Controls.Add(background);

            //////////////////// creating the shops values
            shops[0] = new Shop(0, 0, "GOBUTTON");//not a shop
            shops[0].SetSpecialShop();
            shops[1] = new Shop(1000, 400, "HM");
            shops[2] = new Shop(3000, 1000, "POLO");
            shops[3] = new Shop(4000, 1750, "TOMMY");
            shops[4] = new Shop(3500, 1300, "NIKE");
            shops[5] = new Shop(5000, 1900, "ADIDAS");
            shops[6] = new Shop(0, 0, "Lotarty");
            shops[6].SetSpecialShop();
            shops[7] = new Shop(3000, 1100, "TIMBERLAND");
            shops[8] = new Shop(6500, 3200, "Amusement Park");
            shops[9] = new Shop(3500, 1400, "ROPE PARK");
            shops[10] = new Shop(5000, 2150, "LASER");
            shops[11] = new Shop(1500, 550, "SAMSUNG");
            shops[12] = new Shop(0, 0, "JAIL");
            shops[12].SetSpecialShop();
            shops[13] = new Shop(5000, 2000, "Amazon Books");
            shops[14] = new Shop(4500, 1500, "Trampoline Park");
            shops[15] = new Shop(3500, 1400, "KFC");
            shops[16] = new Shop(1000, 450, "McDonalds");
            shops[17] = new Shop(3000, 1100, "Burger King");
            shops[18] = new Shop(0, 0, "Free Parking");
            shops[18].SetSpecialShop();
            shops[19] = new Shop(4000, 1700, "Pizza Hut");
            shops[20] = new Shop(3500, 1300, "Domino's");
            shops[21] = new Shop(1500, 600, "ToysRus");
            shops[22] = new Shop(1000, 500, "StarBucks");
            shops[23] = new Shop(5000, 2150, "BILLABONG");
            for (int i = 0; i < cardInfo.Length; i++)
            {
                cardInfo[i] = new Label();

            }
            //////////////////// creating shops info cards
            for (int i = 1; i < 6; i++)
            {
                cardInfo[i] = new Label();
                cardInfo[i].ForeColor = System.Drawing.Color.White;
                cardInfo[i].Font = new Font("Arial", 15, FontStyle.Bold);
                cardInfo[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                cardInfo[i].BackColor = Color.Black;
                cardInfo[i].Left = 1000;
                cardInfo[i].Top = cardInfoTop;
                cardInfo[i].Height = 100;
                cardInfo[i].Width = 200;
                cardInfoTop += 150;
                cardInfo[i].Text = shops[i].GetShopName() + " \nShop Cost:  " + shops[i].GetShopCost() + "\nShop Worth: " + shops[i].GetShopWorth();
                this.Controls.Add(cardInfo[i]);
            }
            cardInfoTop = 0;
            for (int i = 7; i < 12; i++)
            {
                cardInfo[i] = new Label();
                cardInfo[i].ForeColor = System.Drawing.Color.White;
                cardInfo[i].Font = new Font("Arial", 15, FontStyle.Bold);
                cardInfo[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                cardInfo[i].BackColor = Color.Black;
                cardInfo[i].Left = 1200;
                cardInfo[i].Top = cardInfoTop;
                cardInfo[i].Height = 100;
                cardInfo[i].Width = 200;
                cardInfoTop += 150;
                cardInfo[i].Text = shops[i].GetShopName() + " \nShop Cost:  " + shops[i].GetShopCost() + "\nShop Worth: " + shops[i].GetShopWorth();
                this.Controls.Add(cardInfo[i]);
            }
            cardInfoTop = 0;
            for (int i = 13; i < 18; i++)
            {
                cardInfo[i] = new Label();
                cardInfo[i].ForeColor = System.Drawing.Color.White;
                cardInfo[i].Font = new Font("Arial", 15, FontStyle.Bold);
                cardInfo[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                cardInfo[i].BackColor = Color.Black;
                cardInfo[i].Left = 1400;
                cardInfo[i].Top = cardInfoTop;
                cardInfo[i].Height = 100;
                cardInfo[i].Width = 200;
                cardInfoTop += 150;
                cardInfo[i].Text = shops[i].GetShopName() + " \nShop Cost:  " + shops[i].GetShopCost() + "\nShop Worth: " + shops[i].GetShopWorth();

                this.Controls.Add(cardInfo[i]);
            }
            cardInfoTop = 0;
            for (int i = 19; i < 24; i++)
            {
                cardInfo[i] = new Label();
                cardInfo[i].ForeColor = System.Drawing.Color.White;
                cardInfo[i].Font = new Font("Arial", 15, FontStyle.Bold);
                cardInfo[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                cardInfo[i].BackColor = Color.Black;
                cardInfo[i].Left = 1600;
                cardInfo[i].Top = cardInfoTop;
                cardInfo[i].Height = 100;
                cardInfo[i].Width = 200;
                cardInfoTop += 150;
                cardInfo[i].Text = (shops[i].GetShopName()) + " \nShop Cost:  " + shops[i].GetShopCost() + "\nShop Worth: " + shops[i].GetShopWorth();
                this.Controls.Add(cardInfo[i]);
            }

            //////////////////// creating the players
            PlayerOneGrafix = new PictureBox();
            PlayerTwoGrafix = new PictureBox();
            PlayerOneGrafix.Width = 50;
            PlayerOneGrafix.Height = 50;
            PlayerOneGrafix.Top = 0;
            PlayerOneGrafix.Left = 0;
            PlayerTwoGrafix.Width = 50;
            PlayerTwoGrafix.Height = 50;
            PlayerTwoGrafix.Top = 0;
            PlayerTwoGrafix.Left = 50;
            PlayerOneGrafix.BackgroundImage = Image.FromFile(@"players\1.jpg");
            PlayerOneGrafix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PlayerTwoGrafix.BackgroundImage = Image.FromFile(@"players\2.jpg");
            PlayerTwoGrafix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PlayerOneGrafix.BringToFront();
            PlayerTwoGrafix.BringToFront();

            playersMoney  = new Label();
            playersMoney.Width = 150;
            playersMoney.Height = 50;
            playersMoney.Left = 140;
            playersMoney.Top = 140;
            playersMoney.BackColor = Color.Black;
            playersMoney.ForeColor = Color.White;

            playersMoney.Text = "cyan's Money:" + PlayerOneMoney + "\nyellow's Money:" + PlayerTwoMoney;
            playersMoney.Font = new Font(playersMoney.Font, FontStyle.Bold);
            this.Controls.Add(playersMoney);

            this.Controls.Add(PlayerOneGrafix);
            this.Controls.Add(PlayerTwoGrafix);





            ////////////////////// creating the game squares
            for (int i = 0; i < pictureBoxes.Length; i++)
            {

                pictureBoxes[i] = new PictureBox(); //creates classes of pictureBoxes that has varibales
                pictureBoxes[i].Size = new Size(140, 140);
                pictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
            }
            ////////////////////// adding pictures to the game squares

            for (int i = 0; i < 24; i++)
            {
                pictureBoxes[i].Image = Image.FromFile(@"picturebox/" + i + ".jpg");
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
            }


            ////////////////////// positioning the game squares

            ////////////////////// starting on the right and going left and the top is 0
            for (int i = 0; i < 6; i++)
            {
                pictureBoxes[pictureBoxIndex].Text = i.ToString();
                pictureBoxes[pictureBoxIndex].Left = i * pictureBoxes[pictureBoxIndex].Width;
                pictureBoxes[pictureBoxIndex].BackColor = Color.Black;
                this.Controls.Add(pictureBoxes[pictureBoxIndex]);
                pictureBoxIndex++;
            }
            ////////////////////// starting on the top and going down, the left is (8 * pictureBoxes[i].Width) - calculating all the Width of all the picture box and this is where you want to put the left;
            for (int i = 0; i < 6; i++)
            {
                pictureBoxes[pictureBoxIndex].Text = i.ToString();
                pictureBoxes[pictureBoxIndex].Left = 6 * pictureBoxes[i].Width;
                pictureBoxes[pictureBoxIndex].Top = (i * pictureBoxes[i].Width);
                pictureBoxes[pictureBoxIndex].BackColor = Color.Black;
                this.Controls.Add(pictureBoxes[pictureBoxIndex]);
                pictureBoxIndex++;
            }
            ////////////////////// starting on the right and going left (8 * pictureBoxes[i].Width) - calculating all the Width of all the picture box and this is where you want to put the left;

            for (int i = 6; i > 0 ; i--)
            {
                pictureBoxes[pictureBoxIndex].Text = i.ToString();
                pictureBoxes[pictureBoxIndex].Left = i * pictureBoxes[pictureBoxIndex].Width;
                pictureBoxes[pictureBoxIndex].Top = 6 * pictureBoxes[i].Width;
                pictureBoxes[pictureBoxIndex].BackColor = Color.Black;
                this.Controls.Add(pictureBoxes[pictureBoxIndex]);
                pictureBoxIndex++;
            }
            ////////////////////// starting down and going up, the left is 0 
            for (int i = 6; i > 0; i--)
            {
                pictureBoxes[pictureBoxIndex].Text = i.ToString();
                pictureBoxes[pictureBoxIndex].Left = 0;
                pictureBoxes[pictureBoxIndex].Top = (i * pictureBoxes[i].Width);
                pictureBoxes[pictureBoxIndex].BackColor = Color.Black;
                this.Controls.Add(pictureBoxes[pictureBoxIndex]);
                pictureBoxIndex++;
            }

            ////////////////////// creating the dice
            Dice.Size = new Size(200, 200);
            Dice.Left = 1100;
            Dice.Top = 750;
            Dice.BorderStyle = BorderStyle.FixedSingle;
            Dice.BackgroundImage = Image.FromFile(@"pic/StartDice.png");
            Dice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            this.Controls.Add(Dice);
            Dice.Click += new EventHandler(OnClick);


            ////////////////////// creating the turns label

            TurnLabel = new Label();
            TurnLabel.Text = "Yellow's turn";
            TurnLabel.Width = 150;
            TurnLabel.Height = 50;
            TurnLabel.Left = 690;
            TurnLabel.Top = 140;
            TurnLabel.BackColor = Color.Yellow;
            TurnLabel.ForeColor = Color.Black;
            TurnLabel.Font = new Font(playersMoney.Font, FontStyle.Bold);
            this.Controls.Add(TurnLabel);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Dice.BringToFront();
            TurnLabel.BringToFront();
            playersMoney.BringToFront();
            rules.BringToFront();

        }
        private void OnClick(object sender, EventArgs e)
        {
            int diceNumber = rnd.Next(1, 7);
            Dice.BackgroundImage = Image.FromFile(@"pic/" + diceNumber + ".png");
            Dice.BackColor = Color.Transparent;
            Dice.SizeMode = PictureBoxSizeMode.StretchImage;

            turn++;
            if(turn % 2 == 0)//Player One turn - Cyan Turn,,,,yellow starts the game which means player 2 start the game
            {
                if (PlayerOneMoney < 0)
                {
                    DialogResult dr = MessageBox.Show("Cyan player, You have less than 0 dollars in your account. Our winner is Yellow Player!", "aaaa", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
                if (PlayerTwoMoney < 0)
                {
                    DialogResult dr = MessageBox.Show("Yellow player, You have less than 0 dollars in your account. Our winner is Cyan Player!", "aaaa", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
                TurnLabel.Text = "Yellow Turn";
                TurnLabel.BackColor = Color.Yellow;
                playerOnePoistion += diceNumber;

                if (playerOnePoistion >= 24)
                {
                    playerOnePoistion = playerOnePoistion - 24;
                    PlayerOneGrafix.Location = pictureBoxes[playerOnePoistion].Location;
                    MessageBox.Show("Cyan Player, you just completed a full turn, here is 1000 dollars on us for you!");
                    PlayerOneMoney += 1000;


                }
                else
                {
                    PlayerOneGrafix.Location = pictureBoxes[playerOnePoistion].Location;
                }
                background.BackgroundImage = Image.FromFile(@"picturebox/" + playerOnePoistion + ".jpg");

                if (playerOnePoistion == playerTwoPosition)
                {
                    PlayerOneGrafix.Location = new Point(PlayerOneGrafix.Location.X + 50, PlayerOneGrafix.Location.Y) ;
                }
                if(shops[playerOnePoistion].GetSpecialShop() == false)
                {
                    if (shops[playerOnePoistion].GetShopStatus() == false)
                    {
                        DialogResult dr = MessageBox.Show("Cyan player, Do you want to buy " + shops[playerOnePoistion].GetShopName() + " for: " + shops[playerOnePoistion].GetShopCost(), "Property", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {

                            if (PlayerOneMoney >= shops[playerOnePoistion].GetShopCost())
                            {
                                cardInfo[playerOnePoistion].ForeColor = System.Drawing.Color.Black;

                                cardInfo[playerOnePoistion].BackColor = Color.Cyan;
                                PlayerOneMoney = PlayerOneMoney - shops[playerOnePoistion].GetShopCost();
                                shops[playerOnePoistion].SetShopStatus();
                                pictureBoxes[playerOnePoistion].BackColor = Color.Cyan;
                                shops[playerOnePoistion].SetShopOwner(1);

                            }
                            else
                            {
                                MessageBox.Show("Not enough money");
                            }
                        }
                    }
                    else
                    {
                        if (shops[playerOnePoistion].GetShopOwner() == 2)
                        {
                            MessageBox.Show("This Place is owned by Yellow player \n Cyan player lose: " + shops[playerOnePoistion].GetShopWorth() + "\n Yellow Player earned: " + shops[playerOnePoistion].GetShopWorth());
                            PlayerOneMoney = PlayerOneMoney - shops[playerOnePoistion].GetShopWorth();
                            PlayerTwoMoney = PlayerTwoMoney + shops[playerOnePoistion].GetShopWorth();
                        }
                    }
                }
                else
                {
                    if(playerOnePoistion == 6)
                    {
                        gamblingMoney = rnd.Next(1, 5000);

                        wonOrLost = rnd.Next(0, 2);

                        if(wonOrLost == 0)
                        {
                            MessageBox.Show("You entered the gambling area and won " + gamblingMoney);
                            PlayerOneMoney += gamblingMoney;
                        }
                        else
                        {
                            MessageBox.Show("You entered the gambling area and lost " + gamblingMoney);
                            PlayerOneMoney -= gamblingMoney;

                        }
                    }
                    else if (playerOnePoistion == 12)
                    {
                        MessageBox.Show("Cyan player, You entered the jail and lost 500$");
                        PlayerOneMoney -= 500;
                    }
                }
                playersMoney.Text = "cyan's Money:" + PlayerOneMoney + "\nyellow's Money:" + PlayerTwoMoney;

                if (PlayerOneMoney < 0)
                {
                    DialogResult dr = MessageBox.Show("Cyan player, You have less than 0 dollars in your account. Our winner is Yellow Player!", "aaaa", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
                if (PlayerTwoMoney < 0)
                {
                    DialogResult dr = MessageBox.Show("Yellow player, You have less than 0 dollars in your account. Our winner is Cyan Player!", "aaaa", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
            }
            else //Player Two turn - yellow Turn 
            {

                if (PlayerOneMoney < 0)
                {
                    DialogResult dr = MessageBox.Show("Cyan player, You have less than 0 dollars in your account. Our winner is Yellow Player!", "aaaa", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
                if (PlayerTwoMoney < 0)
                {
                    DialogResult dr = MessageBox.Show("Yellow player, You have less than 0 dollars in your account. Our winner is Cyan Player!", "aaaa", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
                TurnLabel.Text = "Cyan Turn";
                TurnLabel.BackColor = Color.Cyan;
                playerTwoPosition += diceNumber;

                if (playerTwoPosition >= 24)
                {
                    playerTwoPosition = playerTwoPosition - 24;
                    PlayerTwoGrafix.Location = pictureBoxes[playerTwoPosition].Location;
                    MessageBox.Show("Yellow Player, you just completed a full turn, here is 1000 dollars on us for you!");
                    PlayerTwoMoney += 1000;

                }
                else
                {
                    PlayerTwoGrafix.Location = pictureBoxes[playerTwoPosition].Location;
                }
                background.BackgroundImage = Image.FromFile(@"picturebox/" + playerTwoPosition + ".jpg");
                if (playerOnePoistion == playerTwoPosition)
                {
                    PlayerOneGrafix.Location = new Point(PlayerOneGrafix.Location.X + 50, PlayerOneGrafix.Location.Y);
                }
                if (shops[playerTwoPosition].GetSpecialShop() == false)
                {
                    if (shops[playerTwoPosition].GetShopStatus() == false)
                    {
                        DialogResult dr = MessageBox.Show("Yellow player, Do you want to buy " + shops[playerTwoPosition].GetShopName() + " for: " + shops[playerTwoPosition].GetShopCost(), "Property", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {

                            if (PlayerTwoMoney >= shops[playerTwoPosition].GetShopCost())
                            {
                                cardInfo[playerTwoPosition].BackColor = Color.Yellow;
                                cardInfo[playerTwoPosition].ForeColor = System.Drawing.Color.Black;

                                PlayerTwoMoney = PlayerTwoMoney - shops[playerTwoPosition].GetShopCost();
                                shops[playerTwoPosition].SetShopStatus();
                                pictureBoxes[playerTwoPosition].BackColor = Color.Yellow;
                                shops[playerTwoPosition].SetShopOwner(2);
                            }
                            else
                            {
                                MessageBox.Show("Not enough money");
                            }
                        }
                    }
                    else
                    {
                        if (shops[playerTwoPosition].GetShopOwner() == 1)
                        {
                            MessageBox.Show("This Place is owned by Cyan player \n Yellow player lose: " + shops[playerOnePoistion].GetShopWorth() + "\n Cyan Player earned: " + shops[playerOnePoistion].GetShopWorth());
                            PlayerOneMoney = PlayerOneMoney + shops[playerTwoPosition].GetShopWorth();
                            PlayerTwoMoney = PlayerTwoMoney - shops[playerTwoPosition].GetShopWorth();
                        }
                    }
                }
                else
                {
                    if (playerTwoPosition == 6)
                    {
                        gamblingMoney = rnd.Next(1, 5000);

                        wonOrLost = rnd.Next(0, 2);

                        if (wonOrLost == 0)
                        {
                            MessageBox.Show("Yellow player, You entered the gambling area and won: " + gamblingMoney);
                            PlayerTwoMoney += gamblingMoney;
                        }
                        else
                        {
                            MessageBox.Show("Yellow player, You entered the gambling area and lost:  " + gamblingMoney);
                            PlayerTwoMoney -= gamblingMoney;

                        }
                    }
                    else if(playerTwoPosition == 12)
                    {
                        MessageBox.Show("Yellow player, You entered the jail and lost 500$");
                        PlayerTwoMoney -= 500;
                    }
                }
                playersMoney.Text = "cyan's Money:" + PlayerOneMoney + "\nyellow's Money:" + PlayerTwoMoney;

                if (PlayerOneMoney < 0)
                {
                    DialogResult dr = MessageBox.Show("Cyan player, You have less than 0 dollars in your account. Our winner is Yellow Player!", "aaaa", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
                if (PlayerTwoMoney < 0)
                {
                    DialogResult dr = MessageBox.Show("Yellow player, You have less than 0 dollars in your account. Our winner is Cyan Player!", "aaaa", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                }
            }
        }
    }
}
