using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabCourseSys
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile file = context.Request.Files[0];
            String fileName = System.IO.Path.GetFileName(file.FileName);
            file.SaveAs(System.Web.HttpContext.Current.Server.MapPath("../backUp/") + fileName);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}