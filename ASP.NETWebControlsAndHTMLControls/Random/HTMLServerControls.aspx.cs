using Random.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Random
{
    public partial class HTMLServerControls : System.Web.UI.Page
    {
        private RandomNumberGenerator rng;
        public HTMLServerControls()
        {
            this.rng = new RandomNumberGenerator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRandom_OnClick(object sender, EventArgs e)
        {
            string errorMessage = "Error: Please enter correct numbers!";
            int min;
            int max;
            if (!int.TryParse(this.InputMinimum.Value,out min) || !int.TryParse(this.InputMaximum.Value, out max))
            {
                this.SpanResult.InnerText = errorMessage;
            }
            else if (min>max)
            {
                this.SpanResult.InnerText = errorMessage;
            }
            else
            {
                this.SpanResult.InnerText = this.rng.Generate(min, max).ToString();
            }
        }
    }
}