using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void btnGenerujHaslo_Click_1(object sender, EventArgs e)
        {
            //ciągi odpowiadające konkretnym ustawieniom
            string wielkie = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string male = wielkie.ToLower();
            string cyfry = "0123456789";
            
            //pobieranie ustawień hasła
            decimal liczbaWielkich = numericUpDown1.Value;
            decimal liczbaMalych = numericUpDown2.Value;
            decimal liczbaCyfr = numericUpDown3.Value;
            
            //Stworzenie maszyny losującej
            Random maszynaLosujaca = new Random();
            //stworzenie zmiennej na potrzeby zapisania w niej hasła końcowego
            string haslo = "";
            //generowanie poszczególnych części hasła
            for (int i = 0; i < liczbaWielkich; i++)
            {
                char znak = wielkie[maszynaLosujaca.Next(wielkie.Length)];
                haslo = haslo.Insert(maszynaLosujaca.Next(haslo.Length + 1),
                znak.ToString());
            }
            //to można skopiować i zmienić tylko ciąg z którego pobieramy znak
            for (int i = 0; i < liczbaMalych; i++)
            {
                char znak = male[maszynaLosujaca.Next(male.Length)];
                haslo = haslo.Insert(maszynaLosujaca.Next(haslo.Length + 1),
                znak.ToString());
            }
            for (int i = 0; i < liczbaCyfr; i++)
            {
                char znak = cyfry[maszynaLosujaca.Next(cyfry.Length)];
                haslo = haslo.Insert(maszynaLosujaca.Next(haslo.Length + 1),
                znak.ToString());
            }

            MessageBox.Show("Twoje nowo wygenerowane hasło to: " + haslo);
        }






        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
