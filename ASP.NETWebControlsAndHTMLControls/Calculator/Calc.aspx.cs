using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Calc : System.Web.UI.Page
    {
        // Way too broken but out of time.
        static double lastNumber = 0;
        static string operation = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelInfo.Text = string.Empty;
            this.LabelLastNumber.Text = lastNumber.ToString();
            this.LabelOperation.Text = operation;
        }

        protected void Number_Click(object sender, EventArgs e)
        {
            this.InputField.Text += ((Button)sender).Text;
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.InputField.Text = string.Empty;
            lastNumber = 0;
        }

        protected void Operation_Click(object sender, EventArgs e)
        {
            double current;
            if (double.TryParse(this.InputField.Text, out current))
            {
                var temp = ((Button)sender).Text;
                if (temp == "=")
                {
                    temp = operation;
                }
                operation = temp;
                switch (temp)
                {
                    case "+": lastNumber += current; break;
                    case "-": lastNumber -= current; break;
                    case "/": lastNumber /= current; break;
                    case "x": lastNumber *= current; break;
                    case "√": lastNumber = Math.Sqrt(current); break;
                    default:
                        this.LabelInfo.Text = "Invalid operation!";
                        break;
                }

                this.InputField.Text = string.Empty;
                this.LabelLastNumber.Text = lastNumber.ToString();
            }
            this.LabelOperation.Text = operation;
        }
    }
}