using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1: Form
    {
        private Button[,] board = new Button[3, 3]; 
        private bool isXTurn = true; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board[0, 0] = btn00;
            board[0, 1] = btn01;
            board[0, 2] = btn02;
            board[1, 0] = btn10;
            board[1, 1] = btn11;
            board[1, 2] = btn12;
            board[2, 0] = btn20;
            board[2, 1] = btn21;
            board[2, 2] = btn22;
            foreach (Button btn in board)
            {
                btn.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
                btn.Click += ButtonClick;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null || clickedButton.Text != "") return;
            clickedButton.Text = isXTurn ? "X" : "O";
            isXTurn = !isXTurn; 
            CheckWinner();
        }

        private void CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0].Text != "" && board[i, 0].Text == board[i, 1].Text && board[i, 1].Text == board[i, 2].Text)
                    ShowWinner(board[i, 0].Text);
                if (board[0, i].Text != "" && board[0, i].Text == board[1, i].Text && board[1, i].Text == board[2, i].Text)
                    ShowWinner(board[0, i].Text);
            }
            if (board[0, 0].Text != "" && board[0, 0].Text == board[1, 1].Text && board[1, 1].Text == board[2, 2].Text)
                ShowWinner(board[0, 0].Text);

            if (board[0, 2].Text != "" && board[0, 2].Text == board[1, 1].Text && board[1, 1].Text == board[2, 0].Text)
                ShowWinner(board[0, 2].Text);

            bool isDraw = true;
            foreach (Button btn in board)
                if (btn.Text == "") isDraw = false;

            if (isDraw) MessageBox.Show("It's a draw!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowWinner(string winner)
        {
            MessageBox.Show($"{winner} wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetBoard();
        }

        private void ResetBoard()
        {
            foreach (Button btn in board)
                btn.Text = "";
            isXTurn = true;
        }
    }


}

