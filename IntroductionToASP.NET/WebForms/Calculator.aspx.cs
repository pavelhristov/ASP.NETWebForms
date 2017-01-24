using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.BusinessLogic;

namespace WebForms
{
    public partial class Calculator : Page
    {
        private readonly CalculatorLogic calculatorLogic;
        public Calculator()
        {
            this.calculatorLogic = new CalculatorLogic();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            double number1;
            double number2;
            if (!double.TryParse(this.TextBoxNumber1.Text,out number1) || !double.TryParse(this.TextBoxNumber2.Text, out number2))
            {
                this.LabelSum.Text = "Error: Please enter correct numbers!";
            }
            else
            {
                this.LabelSum.Text = this.calculatorLogic.Sum(number1, number2).ToString();
            }
        }
    }
}