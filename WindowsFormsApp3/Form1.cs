using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        int randNum, userNum, prevNum, hodCount;
        bool gameFinished;
        const int maxCount = 7;
        public Form1()
        {
            InitializeComponent();
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userNum = int.Parse(textBox1.Text);
            if (userNum == prevNum) 
            {
                return;
            }
            prevNum = userNum;
            label3.Visible = false;
            label4.Visible = false;
            hodCount++;
            label5.Text = "Оставшиеся ходы : " + (maxCount - hodCount).ToString();
            if (userNum == randNum)
            {
                MessageBox.Show("Вы угадали число за " + hodCount.ToString() + " ходов.");
                FinishGame();
            }

            else if (userNum < randNum)
            {
                label4.Visible = true;
            }

            else if (userNum > randNum)
            {
                label3.Visible = true;
            }

            if ((hodCount == maxCount) &&(!gameFinished))
            {
                MessageBox.Show("Вам не удалось угадать число за " + maxCount.ToString() + " ходов. Игра окончена.");
                FinishGame();
            }
        }
        private void SetupGame()
        {
            gameFinished = false;
            Random r = new Random();
            randNum = r.Next(0, 101);
            hodCount = 0;
            textBox1.Text = "";
            prevNum = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button1.Visible = false;
            button2.Visible = true;
            textBox1.Visible = true;
            label1.Visible = true;
            SetupGame();
            label5.Visible = true;
            label5.Text = "Оставшиеся ходы : " + maxCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            textBox1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            SetupGame();
            label5.Visible = true;
            label5.Text = "Оставшиеся ходы : " + maxCount.ToString();
        }

        private void FinishGame()
        {
            button1.Visible = true;
            button2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = false;
            gameFinished = true;
        }
    }
}