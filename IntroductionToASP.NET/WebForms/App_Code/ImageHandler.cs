using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.App_Code
{
    public class ImageHandler : IHttpHandler
    {
        public ImageHandler()
        {

        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;

            Response.Write("<h1>*.img</h1>");
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}