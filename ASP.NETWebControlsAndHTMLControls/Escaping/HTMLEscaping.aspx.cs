using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escaping
{
    public partial class HTMLEscaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRunScript_Click(object sender, EventArgs e)
        {
            this.TextBoxScriptResult.Text = this.TextBoxScriptContainer.Text;
            this.LabelScriptResult.Text = Server.HtmlEncode(this.TextBoxScriptContainer.Text);
        }
    }
}