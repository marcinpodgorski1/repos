using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace FORMS_OX
{
    public partial class Form1 : Form
    {
        private char currentPlayer = 'O';
        private int movesCount = 0;
        private string a = "";

        public Form1()
        {
            InitializeComponent();
            
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
                else
                {
                    currentPlayer = (currentPlayer == 'O') ? 'X' : 'O';


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
            button12.Text = "Ostatnie wygrane";

        }

        private bool CheckForWin()
        {
            // Sprawdzenie wierszy
            for (int i = 0; i < 3; i++)
            {
                if (CheckWinCondition(button1.Text, button2.Text, button3.Text) ||
                    CheckWinCondition(button4.Text, button5.Text, button6.Text) ||
                    CheckWinCondition(button7.Text, button8.Text, button9.Text))
                {
                    return true;
                }
            }

            // Sprawdzenie kolumn
            for (int i = 0; i < 3; i++)
            {
                if (CheckWinCondition(button1.Text, button4.Text, button7.Text) ||
                    CheckWinCondition(button2.Text, button5.Text, button8.Text) ||
                    CheckWinCondition(button3.Text, button6.Text, button9.Text))
                {
                    return true;
                }
            }

            // Sprawdzenie przekątnych
            if (CheckWinCondition(button1.Text, button5.Text, button9.Text) ||
                CheckWinCondition(button3.Text, button5.Text, button7.Text))
            {
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







        // ostatnie wygrane trzeba zrobić tablice któa będzie w pętli wyświetlać co i jak.

    }
}
