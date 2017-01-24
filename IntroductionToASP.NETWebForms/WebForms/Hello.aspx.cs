using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class Hello : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Write("Page_Load invoked" + "<br/>");
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Response.Write("Page_PreInit invoked" + "<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Response.Write("Page_Init invoked" + "<br/>");
        }
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Response.Write("Page_PreRender invoked" + "<br/>");
            this.LabelAssemblyLocation.Text = $"Assembly: {Assembly.GetExecutingAssembly().Location}";
        }
        
        protected void ButtonSubmit_Init(object sender, EventArgs e)
        {
            this.Response.Write("ButtonSubmit_Init invoked" + "<br/>");
        }

        protected void ButtonSubmit_Load(object sender, EventArgs e)
        {
            this.Response.Write("ButtonSubmit_Load invoked" + "<br/>");
        }
        
        protected void ButtonSubmit_PreRender(object sender, EventArgs e)
        {
            this.Response.Write("ButtonSubmit_PreRender invoked" + "<br/>");
        }

        protected void TextBoxName_Init(object sender, EventArgs e)
        {
            Response.Write("TextBoxName_Init invoked" + "<br/>");
        }

        protected void TextBoxName_Load(object sender, EventArgs e)
        {
            Response.Write("TextBoxName_Load invoked" + "<br/>");
        }

        protected void TextBoxName_PreRender(object sender, EventArgs e)
        {
            Response.Write("TextBoxName_PreRender invoked" + "<br/>");
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string name = this.TextBoxName.Text;
            if (name.Length<1)
            {
                name = "Pesho";
            }
            this.LabelMessage.Text = $"Hello {name}!";
            Response.Write("ButtonSubmit_Click invoked" + "<br/>");
        }
    }
}