using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OX_nowy
{
    public partial class Form1 : Form
    {
        private char currentPlayer = 'O';
        private int movesCount = 0;
        private string a = "";
        private string komp = "";
        private string inteligentny = "";
        private MiniMax minimax;
        public Form1()
        {
            InitializeComponent();
            minimax = new MiniMax('X');
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string[] GetBoardState()
        {
            string[] boardState = new string[9];

            for (int i = 0; i < 9; i++)
            {
                boardState[i] = Controls.Find("button" + (i + 1), true)[0].Text;
            }

            return boardState;
        }







        private void KomputerWykonajRuch()
        {
            // Sprawdź dostępne puste pola
            var dostepnePola = Controls.OfType<Button>().Where(button => button.Text == "").ToList();

            if (dostepnePola.Any())
            {

                if (inteligentny == "tak")
                {
                    int bestMove = minimax.FindBestMove(GetBoardState());
                    if (bestMove != -1)
                        Controls.Find("button" + (bestMove + 1), true)[0].Text = "X";


                }
                else if (komp == "tak")
                {


                    // Wybierz losowe puste pole
                    Random random = new Random();
                    int losowyIndex = random.Next(0, dostepnePola.Count);
                    dostepnePola[losowyIndex].Text = currentPlayer.ToString();
                }
                // Zmiana gracza po ruchu komputera
                currentPlayer = (currentPlayer == 'O') ? 'X' : 'O';

                // Zwiększenie licznika ruchów
                movesCount++;

                if (CheckForWin())
                {

                    MessageBox.Show("Gracz X wygrywa!");



                    label2.Text = "X";

                    ResetBoard();

                }
                else if (movesCount == 9)
                {

                    MessageBox.Show("Remis!");

                    ResetBoard();
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            if (button.Text == "")
            {
                button.Text = currentPlayer.ToString();
                movesCount++;

                if (CheckForWin())
                {

                    MessageBox.Show("Gracz " + currentPlayer + " wygrywa!");

                    a = currentPlayer.ToString();
                    label2.Text = a;
                    ResetBoard();
                }
                else if (movesCount == 9)
                {
                    MessageBox.Show("Remis!");
                    ResetBoard();
                }
                if (movesCount <= 9)
                {
                    currentPlayer = (currentPlayer == 'O') ? 'X' : 'O';

                    if (komp == "tak")
                    {
                        KomputerWykonajRuch();

                    }

                }
                //inteligentny
                if (checkBox2.Checked)
                {
                    if (inteligentny == "tak" && currentPlayer == 'X')
                    {

                        KomputerWykonajRuch();

                    }
                }



            }
        }
        private void ResetBoard()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Text = "";
                }
            }

            currentPlayer = 'O';
            movesCount = 0;
            button10.Text = "Nowa gra";
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;

        }
        private bool CheckForWin()
        {
            // Sprawdzenie wierszy

            if (CheckWinCondition(button1.Text, button2.Text, button3.Text))
            {
                button1.BackColor = Color.Pink;
                button2.BackColor = Color.Pink;
                button3.BackColor = Color.Pink;
                return true;
            }
            if (CheckWinCondition(button4.Text, button5.Text, button6.Text))
            {
                button4.BackColor = Color.Red;
                button5.BackColor = Color.Red;
                button6.BackColor = Color.Red;
                return true;
            }
            if (CheckWinCondition(button7.Text, button8.Text, button9.Text))
            {
                button7.BackColor = Color.Yellow;
                button8.BackColor = Color.Yellow;
                button9.BackColor = Color.Yellow;
                return true;
            }
            // Sprawdzenie kolumn
            if (CheckWinCondition(button1.Text, button4.Text, button7.Text))
            {
                button1.BackColor = Color.Green;
                button4.BackColor = Color.Green;
                button7.BackColor = Color.Green;
                return true;
            }
            if (CheckWinCondition(button2.Text, button5.Text, button8.Text))
            {
                button2.BackColor = Color.Magenta;
                button5.BackColor = Color.Magenta;
                button8.BackColor = Color.Magenta;
                return true;
            }

            if (CheckWinCondition(button3.Text, button6.Text, button9.Text))
            {
                button3.BackColor = Color.Purple;
                button6.BackColor = Color.Purple;
                button9.BackColor = Color.Purple;
                return true;
            }

            // Sprawdzenie przekątnych
            if (CheckWinCondition(button1.Text, button5.Text, button9.Text))
            {
                button1.BackColor = Color.Violet;
                button5.BackColor = Color.Violet;
                button9.BackColor = Color.Violet;
                return true;
            }

            if (CheckWinCondition(button3.Text, button5.Text, button7.Text))
            {
                button3.BackColor = Color.Aqua;
                button5.BackColor = Color.Aqua;
                button7.BackColor = Color.Aqua;
                return true;
            }
            return false;

        }

        private bool CheckWinCondition(string a, string b, string c)
        {
            return !string.IsNullOrEmpty(a) && a == b && b == c;

        }


        private void Button10_Click(object sender, EventArgs e)
        {
            ResetBoard();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;

            if (checkBox2.Checked)
            {
                inteligentny = "tak";
                if (currentPlayer == 'X') // Ensure it's X's turn
                {
                    int bestMove = minimax.FindBestMove(GetBoardState());
                    if (bestMove != -1)
                        Controls.Find("button" + (bestMove + 1), true)[0].Text = "X";
                }
            }
            else
            {
                inteligentny = "";
            }
        }


        //komputer inteligentny

        public class MiniMax

        {
            private char player;  // Gracz (O lub X)



            public MiniMax(char player)
            {
                this.player = player;

            }

            public int FindBestMove(string[] board)
            {
                int bestMove = -1;
                int bestScore = int.MinValue;

                for (int i = 0; i < board.Length; i++)
                {
                    if (string.IsNullOrEmpty(board[i]))
                    {
                        board[i] = player.ToString();

                        int score = MiniMaxAlgorithm(board, 0, false);

                        board[i] = "";  // Przywróć puste pole

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = i;

                        }
                    }
                }

                return bestMove;
            }

            public int MiniMaxAlgorithm(string[] board, int depth, bool isMaximizing)
            {
                int score = Evaluate(board);

                if (score == 10)  // Wygrana gracza X
                    return score;





                if (score == -10)  // Wygrana gracza O
                    return score;


                if (!Array.Exists(board, cell => string.IsNullOrEmpty(cell)))  // Remis
                    return 0;

                if (isMaximizing)
                {
                    int bestScore = int.MinValue;

                    for (int i = 0; i < board.Length; i++)
                    {
                        if (string.IsNullOrEmpty(board[i]))
                        {
                            board[i] = player.ToString();
                            bestScore = Math.Max(bestScore, MiniMaxAlgorithm(board, depth + 1, false));
                            board[i] = "";  // Przywróć puste pole
                        }
                    }

                    return bestScore;
                }
                else
                {
                    int bestScore = int.MaxValue;

                    for (int i = 0; i < board.Length; i++)
                    {
                        if (string.IsNullOrEmpty(board[i]))
                        {
                            board[i] = (player == 'X') ? 'O'.ToString() : 'X'.ToString();
                            bestScore = Math.Min(bestScore, MiniMaxAlgorithm(board, depth + 1, true));
                            board[i] = "";  // Przywróć puste pole
                        }
                    }
                    return bestScore;
                }
            }

            private int Evaluate(string[] board)
            {
                // Możliwe kombinacje wygranych
                string[][] winPatterns = new string[][]
                {
             new string[] { "0", "1", "2" },  // Wiersze
             new string[] { "3", "4", "5" },
             new string[] { "6", "7", "8" },
             new string[] { "0", "3", "6" },  // Kolumny
             new string[] { "1", "4", "7" },
             new string[] { "2", "5", "8" },
             new string[] { "0", "4", "8" },  // Przekątne
             new string[] { "2", "4", "6" }
                };

                foreach (var pattern in winPatterns)
                {
                    string val1 = board[int.Parse(pattern[0])];
                    string val2 = board[int.Parse(pattern[1])];
                    string val3 = board[int.Parse(pattern[2])];

                    if (val1 == "X" && val2 == "X" && val3 == "X")
                        return 10;  // Wygrana gracza X
                    else if (val1 == "O" && val2 == "O" && val3 == "O")
                        return -10;  // Wygrana gracza O

                }

                return 0;  // Brak wygranej
            }
        }
    }
}
















