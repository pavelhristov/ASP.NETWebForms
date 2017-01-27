using Random.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Random
{
    public partial class WebServerControls : System.Web.UI.Page
    {
        private RandomNumberGenerator rng;

        public WebServerControls()
        {
            this.rng = new RandomNumberGenerator();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRandom_Click(object sender, EventArgs e)
        {
            string errorMessage = "Error: Please enter correct numbers!";
            int min;
            int max;
            if (!int.TryParse(this.MinimumNumber.Text, out min) || !int.TryParse(this.MaximumNumber.Text, out max))
            {
                this.LableResult.Text = errorMessage;
            }
            else if (min>max)
            {
                this.LableResult.Text = errorMessage;
            }
            else
            {
                this.LableResult.Text = this.rng.Generate(min, max).ToString();
            }
        }
    }
}