using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SolitaireHunting
{
    public partial class Form1 : Form
    {
        public class Card
        {
            public string Rank { get; set; } 
            public string Suit { get; set; } 
            public bool IsRed => Suit == "♥" || Suit == "♦";

            public Card(string rank, string suit)
            {
                Rank = rank;
                Suit = suit;
            }
        }

        private struct MoveRecord
        {
            public int StackIndex1;
            public int StackIndex2;
            public Card Card1;
            public Card Card2;
        }

        private List<Stack<Card>> gameStacks = new List<Stack<Card>>(); 
        private Stack<Card> trashStack = new Stack<Card>();             
        private Stack<MoveRecord> moveHistory = new Stack<MoveRecord>(); 

        private PictureBox[] cryptoBoxes; 
        private int selectedStackIndex = -1; 

        public Form1()
        {
            InitializeComponent();
            InitializeGameLayout();
            StartNewGame();
        }

        private void InitializeGameLayout()
        {
            cryptoBoxes = new PictureBox[] {
                pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox5, pictureBox6,
                pictureBox7, pictureBox8, pictureBox9
            };

            for (int i = 0; i < cryptoBoxes.Length; i++)
            {
                cryptoBoxes[i].Tag = i; 
                cryptoBoxes[i].MouseClick += Stack_MouseClick; 
            }

            новаяИграToolStripMenuItem.Click += (s, e) => StartNewGame();
            отменитьХодToolStripMenuItem.Click += (s, e) => UndoLastMove();
            правилаToolStripMenuItem.Click += (s, e) => ShowRules();
            выходToolStripMenuItem.Click += (s, e) => Application.Exit();
        }

        private void StartNewGame()
        {
            gameStacks.Clear();
            trashStack.Clear();
            moveHistory.Clear();
            selectedStackIndex = -1;

            for (int i = 0; i < 9; i++)
                gameStacks.Add(new Stack<Card>()); 

            string[] ranks = { "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] suits = { "♠", "♣", "♥", "♦" };
            List<Card> deck = new List<Card>();

            foreach (var rank in ranks)
                foreach (var suit in suits)
                    deck.Add(new Card(rank, suit));

            Random rand = new Random();
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }

            int deckIndex = 0;
            for (int s = 0; s < 9; s++)
            {
                for (int c = 0; c < 4; c++)
                {
                    gameStacks[s].Push(deck[deckIndex++]);
                }
            }

            RedrawBoard();
        }

        private void RedrawBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                bool isSelected = (i == selectedStackIndex);
                if (gameStacks[i].Count > 0)
                {
                    Card topCard = gameStacks[i].Peek();
                    cryptoBoxes[i].Image = GenerateCardImage(topCard, isSelected);
                }
                else
                {
                    cryptoBoxes[i].Image = GenerateEmptySlotImage(isSelected);
                }
            }

            if (trashStack.Count > 0)
            {
                pbTrash.Image = GenerateCardImage(trashStack.Peek(), false);
            }
            else
            {
                pbTrash.Image = GenerateEmptySlotImage(false);
            }
        }

        private Bitmap GenerateCardImage(Card card, bool isSelected)
        {
            Bitmap bmp = new Bitmap(90, 130);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                Pen borderPen = isSelected ? new Pen(Color.OrangeRed, 3) : new Pen(Color.Black, 1);
                g.DrawRectangle(borderPen, 1, 1, bmp.Width - 3, bmp.Height - 3);

                Brush textBrush = card.IsRed ? Brushes.Red : Brushes.Black;
                Font font = new Font("Arial", 16, FontStyle.Bold);

                g.DrawString(card.Rank, font, textBrush, 5, 5);
                g.DrawString(card.Suit, font, textBrush, 5, 30);

                g.DrawString(card.Rank, font, textBrush, bmp.Width - 30, bmp.Height - 55);
                g.DrawString(card.Suit, font, textBrush, bmp.Width - 30, bmp.Height - 30);
            }
            return bmp;
        }

        private Bitmap GenerateEmptySlotImage(bool isSelected)
        {
            Bitmap bmp = new Bitmap(90, 130);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.DarkGreen); 
                Pen borderPen = isSelected ? new Pen(Color.OrangeRed, 3) : new Pen(Color.Gray, 1);
                g.DrawRectangle(borderPen, 1, 1, bmp.Width - 3, bmp.Height - 3);
            }
            return bmp;
        }

        private void Stack_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox clickedBox = (PictureBox)sender;
            int clickedIndex = (int)clickedBox.Tag;

            if (gameStacks[clickedIndex].Count == 0 && selectedStackIndex == -1)
                return;

            if (selectedStackIndex == -1)
            {
                selectedStackIndex = clickedIndex;
                RedrawBoard();
            }
            else
            {
                if (selectedStackIndex == clickedIndex)
                {
                    selectedStackIndex = -1;
                    RedrawBoard();
                    return;
                }

                Card card1 = gameStacks[selectedStackIndex].Peek();
                Card card2 = gameStacks[clickedIndex].Peek();

                if (card1.Rank == card2.Rank)
                {
                    gameStacks[selectedStackIndex].Pop();
                    gameStacks[clickedIndex].Pop();

                    moveHistory.Push(new MoveRecord
                    {
                        StackIndex1 = selectedStackIndex,
                        StackIndex2 = clickedIndex,
                        Card1 = card1,
                        Card2 = card2
                    });
 
                    trashStack.Push(card2);

                    selectedStackIndex = -1;
                    RedrawBoard();

                    CheckWinCondition();
                }
                else
                {
                    selectedStackIndex = clickedIndex;
                    RedrawBoard();
                }
            }
        }

        private void UndoLastMove()
        {
            if (moveHistory.Count == 0)
            {
                MessageBox.Show("Нет ходов для отмены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var lastMove = moveHistory.Pop();

            gameStacks[lastMove.StackIndex1].Push(lastMove.Card1);
            gameStacks[lastMove.StackIndex2].Push(lastMove.Card2);

            if (trashStack.Count > 0)
                trashStack.Pop();

            selectedStackIndex = -1;
            RedrawBoard();
        }

        private void ShowRules()
        {
            FormRules rulesForm = new FormRules();
            rulesForm.ShowDialog();
        }

        private void CheckWinCondition()
        {
            bool isWin = gameStacks.All(s => s.Count == 0);
            if (isWin)
            {
                MessageBox.Show("Поздравляем! Вы полностью разобрали пасьянс!", "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}