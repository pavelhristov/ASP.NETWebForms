using System;
using System.Xml.Linq;

namespace XMLReader
{
    public partial class Reader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Gave up and out of time :X
            var doc = XDocument.Load("/data.xml");
            var root = doc.Root;
        }
    }
}