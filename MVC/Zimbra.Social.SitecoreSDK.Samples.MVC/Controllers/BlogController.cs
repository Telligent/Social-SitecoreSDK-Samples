using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sitecore.Tasks;
using Telligent.Evolution.Extensibility.Rest.Version1;
using Zimbra.Social.SitecoreSDK.Samples.MVC.Models;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Controllers
{

    public class BlogController : Controller
    {
        // GET: Forum  Currently a site wide aggregate
        public ActionResult ListBlogs()
        {

            var host = Host.Get("default");
            var parms = new NameValueCollection();
            parms.Add("PageSize", "50");
            parms.Add("PageIndex", "0");
            parms.Add("SortBy", "LastPost");
            parms.Add("SortOrder", "Descending");



            var endpoint = "blogs.json";
            var options = new RestGetOptions();
            options.QueryStringParameters = parms;

            var response = host.GetToDynamic(2, endpoint, true, new RestGetOptions() );

            return View("ListBlogs", response.Blogs);
        }


    }

}