using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Author: Vladislav Ignatov 
 * Class: Cop 4365 – Software Systems Development
 * Date: 10/27/2016 
 */

namespace VladislavIgnatovAssignment04
{
    public partial class CardGenerator : Form
    {
        // Card array to keep track of what cards have been used.
        int[,] cardlist = new int[4, 13];

        // 2d Image Array
        Bitmap[,] ImageArr = new Bitmap[4, 13];

        // List of cards
        List<Card> card_hand = new List<Card>();

        public CardGenerator()
        {
            InitializeComponent();
        }

        // Generates 5 cards and displace them.
        private void generate_hand_button_Click(object sender, EventArgs e)
        {
            // set defualt lable
            result_lable.Text = "None";
            Card1_Suit.Text = "";
            Card2_Suit.Text = "";
            Card3_Suit.Text = "";
            Card4_Suit.Text = "";
            Card5_Suit.Text = "";
            Card1_Rank.Text = "";
            Card2_Rank.Text = "";
            Card3_Rank.Text = "";
            Card4_Rank.Text = "";
            Card5_Rank.Text = "";

            Random rand = new Random();

            //loops until there are 5 cards in the hand
            while (card_hand.Count != 5)
            {
                //x,y generate random numbers for suit and rank
                int x = rand.Next(0, 4);
                int y = rand.Next(0, 13);

                // check to see if card had been made already
                if (cardlist[x,y] == 0)
                {
                    cardlist[x,y] = 1; // set card a 1 meaning that this cad cant be made again
                    Card cardtmp = new Card(x, y);// make new card and initolize it
                    card_hand.Add(cardtmp); // add card to hand
                }
            }

            //boolan check for the type of hand
            setFinalLable();

            //sets the images
            setImages();

            //clear out all memory in the globels
            clearoutMemory();

        }

        private void clearoutMemory()
        {
            // rest on the memory in cardlist
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (cardlist[i, j] == 1)
                    {
                        cardlist[i, j] = 0;
                    }
                }
            }
            // clears the hand
            card_hand.Clear();
        }

        private void setImages()
        {
            //sets the images
            CardsImage();

            //sets the picture boxes
            pictureBox1.Image = ImageArr[card_hand[0].Suit, card_hand[0].Rank];
            pictureBox2.Image = ImageArr[card_hand[1].Suit, card_hand[1].Rank];
            pictureBox3.Image = ImageArr[card_hand[2].Suit, card_hand[2].Rank];
            pictureBox4.Image = ImageArr[card_hand[3].Suit, card_hand[3].Rank];
            pictureBox5.Image = ImageArr[card_hand[4].Suit, card_hand[4].Rank];
        }

        private void setFinalLable()
        {
            //boolan check for the type of hand
            if (isFullHouse(card_hand))
            {
                result_lable.Text = "Is Full House";
            }
            if (isThree(card_hand))
            {
                result_lable.Text = "Is Three of a Kind";
            }
            if (isFour(card_hand))
            {
                result_lable.Text = "Is Four of a Kind";
            }
            if (isTwoPair(card_hand))
            {
                result_lable.Text = "Is Two Pair";
            }
            if (isOnePair(card_hand))
            {
                result_lable.Text = "Is One Pair";
            }
            if (isStrait(card_hand) && !isFlush(card_hand))
            {
                result_lable.Text = "Is a Strait";
            }
            if (isFlush(card_hand) && !isStrait(card_hand))
            {
                result_lable.Text = "Is a Flush";
            }
            if (isFlush(card_hand) && isStrait(card_hand))
            {
                result_lable.Text = "Is a Straight Flush";
            }
        }

        private void CardsImage()
        {
            // Clubs
            ImageArr[0, 0] = Properties.Resources.ace_of_clubs;
            ImageArr[0, 1] = Properties.Resources._2_of_clubs;
            ImageArr[0, 2] = Properties.Resources._3_of_clubs;
            ImageArr[0, 3] = Properties.Resources._4_of_clubs;
            ImageArr[0, 4] = Properties.Resources._5_of_clubs;
            ImageArr[0, 5] = Properties.Resources._6_of_clubs;
            ImageArr[0, 6] = Properties.Resources._7_of_clubs;
            ImageArr[0, 7] = Properties.Resources._8_of_clubs;
            ImageArr[0, 8] = Properties.Resources._9_of_clubs;
            ImageArr[0, 9] = Properties.Resources._10_of_clubs;
            ImageArr[0, 10] = Properties.Resources.jack_of_clubs2;
            ImageArr[0, 11] = Properties.Resources.queen_of_clubs2;
            ImageArr[0, 12] = Properties.Resources.king_of_clubs2;

            // Dimonds
            ImageArr[1, 0] = Properties.Resources.ace_of_diamonds;
            ImageArr[1, 1] = Properties.Resources._2_of_diamonds;
            ImageArr[1, 2] = Properties.Resources._3_of_diamonds;
            ImageArr[1, 3] = Properties.Resources._4_of_diamonds;
            ImageArr[1, 4] = Properties.Resources._5_of_diamonds;
            ImageArr[1, 5] = Properties.Resources._6_of_diamonds;
            ImageArr[1, 6] = Properties.Resources._7_of_diamonds;
            ImageArr[1, 7] = Properties.Resources._8_of_diamonds;
            ImageArr[1, 8] = Properties.Resources._9_of_diamonds;
            ImageArr[1, 9] = Properties.Resources._10_of_diamonds;
            ImageArr[1, 10] = Properties.Resources.jack_of_diamonds2;
            ImageArr[1, 11] = Properties.Resources.queen_of_diamonds2;
            ImageArr[1, 12] = Properties.Resources.king_of_diamonds2;

            // Hearts
            ImageArr[2, 0] = Properties.Resources.ace_of_hearts;
            ImageArr[2, 1] = Properties.Resources._2_of_hearts;
            ImageArr[2, 2] = Properties.Resources._3_of_hearts;
            ImageArr[2, 3] = Properties.Resources._4_of_hearts;
            ImageArr[2, 4] = Properties.Resources._5_of_hearts;
            ImageArr[2, 5] = Properties.Resources._6_of_hearts;
            ImageArr[2, 6] = Properties.Resources._7_of_hearts;
            ImageArr[2, 7] = Properties.Resources._8_of_hearts;
            ImageArr[2, 8] = Properties.Resources._9_of_hearts;
            ImageArr[2, 9] = Properties.Resources._10_of_hearts;
            ImageArr[2, 10] = Properties.Resources.jack_of_hearts2;
            ImageArr[2, 11] = Properties.Resources.queen_of_hearts2;
            ImageArr[2, 12] = Properties.Resources.king_of_hearts2;

            // Spades
            ImageArr[3, 0] = Properties.Resources.ace_of_spades;
            ImageArr[3, 1] = Properties.Resources._2_of_spades;
            ImageArr[3, 2] = Properties.Resources._3_of_spades;
            ImageArr[3, 3] = Properties.Resources._4_of_spades;
            ImageArr[3, 4] = Properties.Resources._5_of_spades;
            ImageArr[3, 5] = Properties.Resources._6_of_spades;
            ImageArr[3, 6] = Properties.Resources._7_of_spades;
            ImageArr[3, 7] = Properties.Resources._8_of_spades;
            ImageArr[3, 8] = Properties.Resources._9_of_spades;
            ImageArr[3, 9] = Properties.Resources._10_of_spades;
            ImageArr[3, 10] = Properties.Resources.jack_of_spades2;
            ImageArr[3, 11] = Properties.Resources.queen_of_spades2;
            ImageArr[3, 12] = Properties.Resources.king_of_spades2;
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            // close application
            this.Close();
        }

        private bool isFour(List<Card> tmp)
        {
            // Put Rank into an array and then Sorts it.
            int[] arr = new int[5] { tmp[0].Rank, tmp[1].Rank, tmp[2].Rank, tmp[3].Rank, tmp[4].Rank };
            Array.Sort(arr);

            //Check to see if there is a Four of a kind.
            if ((arr[0] == arr[1] && arr[1] == arr[2] && arr[2] == arr[3]) || (arr[1] == arr[2] && arr[2] == arr[3] && arr[3] == arr[4]))
            {
                return true;
            }

            // if not returns false
            return false;
        }

        private bool isFlush(List<Card> tmp)
        {
            // Put Suit into an array and then Sorts it.
            int[] arr = new int[5] { tmp[0].Suit, tmp[1].Suit, tmp[2].Suit, tmp[3].Suit, tmp[4].Suit };
            Array.Sort(arr);

            //Check to see if there is a Flush.
            if (arr[0] == arr[1] && arr[1] == arr[2] && arr[2] == arr[3] && arr[3] == arr[4])
            {
                return true;
            }

            // if not returns false
            return false;
        }

        private bool isFullHouse(List<Card> tmp)
        {
            // Put rank into an array and then Sorts it.
            int[] arr = new int[5] { tmp[0].Rank, tmp[1].Rank, tmp[2].Rank, tmp[3].Rank, tmp[4].Rank };
            Array.Sort(arr);

            //Check to see if there is a Full House.
            if ((arr[0] == arr[1] && arr[1] == arr[2] && arr[3] == arr[4]) || (arr[0] == arr[1] && arr[2] == arr[3] && arr[3] == arr[4]))
            {
                return true;
            }

            // if not returns false
            return false;
        }

        private bool isThree(List<Card> tmp)
        {
            // Checks to see if the Hand is Full House or a Four of a Kind.
            if (isFullHouse(tmp) || isFour(tmp))
            {
                return false;
            }

            // Put rank into an array and then Sorts it.
            int[] arr = new int[5] { tmp[0].Rank, tmp[1].Rank, tmp[2].Rank, tmp[3].Rank, tmp[4].Rank };
            Array.Sort(arr);

            //Check to see if there is a three of a kind.
            if (arr[0] == arr[1] && arr[1] == arr[2] && arr[3] != arr[0] && arr[4] != arr[0] && arr[3] != arr[4])
            {
                return true;
            }
            if (arr[1] == arr[2] && arr[2] == arr[3] && arr[0] != arr[1] && arr[4] != arr[1] && arr[0] != arr[4])
            {
                return true;
            }
            if (arr[2] == arr[3] && arr[3] == arr[4] && arr[0] != arr[2] && arr[1] != arr[2] && arr[0] != arr[1])
            {
                return true;
            }

            // if not returns false
            return false;
        }

        private bool isTwoPair(List<Card> tmp)
        {
            // Checks to see if the Hand is Full House or a Four of a Kind or a Three of Kind.
            if (isFullHouse(tmp) || isFour(tmp) || isThree(tmp))
            {
                return false;
            }

            // Put rank into an array and then Sorts it.
            int[] arr = new int[5] { tmp[0].Rank, tmp[1].Rank, tmp[2].Rank, tmp[3].Rank, tmp[4].Rank };
            Array.Sort(arr);

            //Check to see if there is a two pair.
            if (arr[0] == arr[1] && arr[2] == arr[3])
            {
                return true;
            }
            if (arr[0] == arr[1] && arr[3] == arr[4])
            {
                return true;
            }
            if (arr[1] == arr[2] && arr[3] == arr[4])
            {
                return true;
            }

            // if not returns false
            return false;
        }

        private bool isOnePair(List<Card> tmp)
        {
            // Checks to see if the Hand is Full House or a Four of a Kind or a Three of Kind.
            if (isFullHouse(tmp) || isFour(tmp) || isThree(tmp) || isTwoPair(tmp))
            {
                return false;
            }

            // Put rank into an array and then Sorts it.
            int[] arr = new int[5] { tmp[0].Rank, tmp[1].Rank, tmp[2].Rank, tmp[3].Rank, tmp[4].Rank };
            Array.Sort(arr);

            //Check to see if there is a on pair.
            if (arr[0] == arr[1])
            {
                return true;
            }
            if (arr[1] == arr[2])
            {
                return true;
            }
            if (arr[2] == arr[3])
            {
                return true;
            }
            if (arr[3] == arr[4])
            {
                return true;
            }

            // if not returns false
            return false;
        }

        private bool isStrait(List<Card> tmp)
        {
            // Checks to see if the Hand is a Flush.
            if (isOnePair(tmp) || isFullHouse(tmp) || isFour(tmp) || isThree(tmp) || isTwoPair(tmp))
            {
                return false;
            }

            // Put rank into an array and then Sorts it.
            int[] arr = new int[5] { tmp[0].Rank, tmp[1].Rank, tmp[2].Rank, tmp[3].Rank, tmp[4].Rank };
            Array.Sort(arr);

            
            if (arr[0] == 0)
            {
                //if there is a tiger ace in the array it checks it.
                if (arr[1] == 1 && arr[2] == 2 && arr[3] == 3 && arr[4] == 4)
                {
                    return true;
                }
                if (arr[1] == 9 && arr[2] == 10 && arr[3] == 11 && arr[4] == 12)
                {
                    return true;
                }
            }else
            {
                // checks for a squance in the array 
                int check = arr[0] + 1;

                for (int i = 1; i < 5; i++)
                {
                    if (arr[i] != check)
                    {
                        return false;
                    }
                    check++;
                }

                return true;
            }
            
            // if not returns false
            return false;
        }

        // tests specific cards for what they are.
        private void test_hand_button_Click(object sender, EventArgs e)
        {
            // set lable to default None
            result_lable.Text = "None";
            try
            {
                //check if the inputs are negative
                if (int.Parse(Card1_Suit.Text) < 0 || int.Parse(Card1_Rank.Text) < 0)
                {
                    throw new Exception("Number must be positive or zero!");
                }
                if (int.Parse(Card2_Suit.Text) < 0 || int.Parse(Card2_Rank.Text) < 0)
                {
                    throw new Exception("Number must be positive or zero!");
                }
                if (int.Parse(Card3_Suit.Text) < 0 || int.Parse(Card3_Rank.Text) < 0)
                {
                    throw new Exception("Number must be positive or zero!");
                }
                if (int.Parse(Card4_Suit.Text) < 0 || int.Parse(Card4_Rank.Text) < 0)
                {
                    throw new Exception("Number must be positive or zero!");
                }
                if (int.Parse(Card5_Suit.Text) < 0 || int.Parse(Card5_Rank.Text) < 0)
                {
                    throw new Exception("Number must be positive or zero!");
                }

                //check if there are duplicate cards
                if(cardlist[int.Parse(Card1_Suit.Text), int.Parse(Card1_Rank.Text) - 1] == 0)
                {
                    cardlist[int.Parse(Card1_Suit.Text), int.Parse(Card1_Rank.Text) - 1] = 1;
                }
                else
                {
                    clearoutMemory();
                    throw new Exception("Card alreay in hand! Suit: " + Card1_Suit.Text + " Rank: " + Card1_Rank.Text);
                }
                if (cardlist[int.Parse(Card2_Suit.Text), int.Parse(Card2_Rank.Text) - 1] == 0)
                {
                    cardlist[int.Parse(Card2_Suit.Text), int.Parse(Card2_Rank.Text) - 1] = 1;
                }
                else
                {
                    clearoutMemory();
                    throw new Exception("Card alreay in hand!" + Card2_Suit.Text + " Rank: " + Card2_Rank.Text);
                }
                if (cardlist[int.Parse(Card3_Suit.Text), int.Parse(Card3_Rank.Text) - 1] == 0)
                {
                    cardlist[int.Parse(Card3_Suit.Text), int.Parse(Card3_Rank.Text) - 1] = 1;
                }
                else
                {
                    clearoutMemory();
                    throw new Exception("Card alreay in hand!" + Card3_Suit.Text + " Rank: " + Card3_Rank.Text);
                }
                if (cardlist[int.Parse(Card4_Suit.Text), int.Parse(Card4_Rank.Text) - 1] == 0)
                {
                    cardlist[int.Parse(Card4_Suit.Text), int.Parse(Card4_Rank.Text) - 1] = 1;
                }
                else
                {
                    clearoutMemory();
                    throw new Exception("Card alreay in hand!" + Card4_Suit.Text + " Rank: " + Card4_Rank.Text);
                }
                if (cardlist[int.Parse(Card5_Suit.Text), int.Parse(Card5_Rank.Text) - 1] == 0)
                {
                    cardlist[int.Parse(Card5_Suit.Text), int.Parse(Card5_Rank.Text) - 1] = 1;
                }
                else
                {
                    clearoutMemory();
                    throw new Exception("Card alreay in hand!" + Card5_Suit.Text + " Rank: " + Card5_Rank.Text);
                }

                // creates cards
                Card card1 = new Card(int.Parse(Card1_Suit.Text), int.Parse(Card1_Rank.Text) - 1);
                Card card2 = new Card(int.Parse(Card2_Suit.Text), int.Parse(Card2_Rank.Text) - 1);
                Card card3 = new Card(int.Parse(Card3_Suit.Text), int.Parse(Card3_Rank.Text) - 1);
                Card card4 = new Card(int.Parse(Card4_Suit.Text), int.Parse(Card4_Rank.Text) - 1);
                Card card5 = new Card(int.Parse(Card5_Suit.Text), int.Parse(Card5_Rank.Text) - 1);

                // adds cards to the hand
                card_hand.Add(card1);
                card_hand.Add(card2);
                card_hand.Add(card3);
                card_hand.Add(card4);
                card_hand.Add(card5);

                //set the lable and checks it with boolean
                setFinalLable();

                //sets the images
                setImages();

            }
            catch (Exception ex)
            {
                // if the input is not int then this will pop up
                MessageBox.Show(ex.Message);
            }

            //reset the memory in globels
            clearoutMemory();
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            // set defualt lable
            result_lable.Text = "None";
            Card1_Suit.Text = "";
            Card2_Suit.Text = "";
            Card3_Suit.Text = "";
            Card4_Suit.Text = "";
            Card5_Suit.Text = "";
            Card1_Rank.Text = "";
            Card2_Rank.Text = "";
            Card3_Rank.Text = "";
            Card4_Rank.Text = "";
            Card5_Rank.Text = "";
        }
    }
}
