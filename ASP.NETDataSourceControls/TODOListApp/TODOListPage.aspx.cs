using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TODOListApp
{
    public partial class TODOListPage : System.Web.UI.Page
    {
        private int categoryId = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(this.DropDownListCategory.Text, out this.categoryId);
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // No idea where to attach the default values :X open to suggestions :X
            (this.DetailsViewTODO.DataItem as TODOs).CategoryId = categoryId;
            (this.DetailsViewTODO.DataItem as TODOs).Last_Edited = DateTime.Now;
        }
    }
}