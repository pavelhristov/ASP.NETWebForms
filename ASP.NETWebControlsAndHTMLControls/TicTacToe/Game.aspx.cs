using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicTacToe
{
    public partial class Game : System.Web.UI.Page
    {
        // Most terrible thing that I have done in the past year, please don't do this in home!
        // Fully aware I'm not supposed to do this.
        static string[,] gameField = new string[3, 3];
        static string playerChar = "X";
        static string aiChar = "O";


        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void Cell_Click(object sender, EventArgs e)
        {
            var cell = ((Control)sender).ID.Split('_');
            ((Button)sender).Text = playerChar;
            ((Button)sender).Enabled = false;
            gameField[int.Parse(cell[1]), int.Parse(cell[2])] = playerChar;

            if (isWinning(gameField, playerChar))
            {
                this.form1.InnerHtml = "You win!";
                gameField = new string[3, 3];
                return;
            }
            AI(gameField, new Random());

            if (isWinning(gameField, aiChar))
            {
                this.form1.InnerHtml = "You lose!";
                gameField = new string[3, 3];
                return;
            }
        }

        // no comment... 
        private bool isWinning(string[,] field, string ch)
        {
            if (field[0, 0] == ch)
            {
                if (field[0, 1] == ch)
                {
                    if (field[0, 2] == ch)
                    {
                        return true;
                    }
                }
                if (field[1, 1] == ch)
                {
                    if (field[2, 2] == ch)
                    {
                        return true;
                    }
                }
                if (field[1, 0] == ch)
                {
                    if (field[2, 0] == ch)
                    {
                        return true;
                    }
                }
            }
            if (field[1, 0] == ch)
            {
                if (field[1, 1] == ch)
                {
                    if (field[1, 2] == ch)
                    {
                        return true;
                    }
                }
            }
            if (field[2, 0] == ch)
            {
                if (field[2, 1] == ch)
                {
                    if (field[2, 2] == ch)
                    {
                        return true;
                    }
                }
            }
            if (field[0, 1] == ch)
            {
                if (field[1, 1] == ch)
                {
                    if (field[2, 1] == ch)
                    {
                        return true;
                    }
                }
            }
            if (field[0, 2] == ch)
            {
                if (field[1, 2] == ch)
                {
                    if (field[2, 2] == ch)
                    {
                        return true;
                    }
                }
            }
            if (field[0, 2] == ch)
            {
                if (field[1, 1] == ch)
                {
                    if (field[2, 0] == ch)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void AI(string[,] field, Random rng)
        {
            int row = 0;
            int col = 0;
            int counter = 0;
            do
            {
                if (counter < 20)
                {
                    row = rng.Next(0, 2);
                    col = rng.Next(0, 2);
                }
                else if (counter % 3 == 0)
                {
                    row++;
                    if (row >= 3)
                    {
                        row = 0;
                    }
                }
                else
                {
                    col++;
                    if (col >= 3)
                    {
                        col = 0;
                    }
                }
                counter++;
                if (counter > 1000)
                {
                    this.form1.InnerHtml = "Draw!";
                    gameField = new string[3, 3];
                    return;
                }
            } while (field[row, col] == playerChar || field[row, col] == aiChar);

            field[row, col] = aiChar;
            Button btn = (Button)FindControl($"Cell_{row}_{col}");
            btn.Text = aiChar;
            btn.Enabled = false;
        }
    }
}