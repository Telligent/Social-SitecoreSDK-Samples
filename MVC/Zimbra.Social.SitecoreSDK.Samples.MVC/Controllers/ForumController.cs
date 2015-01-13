using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zimbra.Social.RemotingSDK.Sitecore;
using Zimbra.Social.SitecoreSDK.Samples.MVC.Models;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Controllers
{
   
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult ListForums()
        {
            //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
            //Example, if you loaded by site name you could get the current site name.
           var host = Api.GetHost("website", true);

            //When faced with options objects used in platofmr API, you can pass them in as Hashtables with the key being the property
            //and the value
           var options = new Hashtable();
           options.Add("PageSize", 50);
           options.Add("PageIndex", 0);
           options.Add("SortBy", "LastPost");
           options.Add("SortOrder", "Descending");

            //The third parameter is a params[] argument, it should be the method arguments for the corresponding API.
            //example:  If the API is core_v2_Foo.List(int,string,Options options) then the 3rd parm could be (1,"bar",Hashtable obj)
           dynamic forums = host.ExecuteMethod("core_v2_forum", "List", options);
          
            return View(forums);
        }

        public ActionResult ListThreads()
        {
            int forumId = 52;
            var host = Api.GetHost("website", true);
            var options = new Hashtable();
            options.Add("PageSize", 50);
            options.Add("PageIndex", 0);
            options.Add("SortBy", "LastPost");
            options.Add("SortOrder", "Descending");
            options.Add("ForumId",52);

            dynamic threads = host.ExecuteMethod("core_v2_forumThread", "List", options);
            return View(threads);
        }

        public ActionResult ViewThread()
        {
            var threadId = 238888;
            var host = Api.GetHost("website", true);

            var thread = host.ExecuteMethod("core_v2_forumThread", "Get", threadId);
            var replies = host.ExecuteMethod("core_v2_forumReply", "List", threadId);

            return View(new ForumThreadViewModel(thread, replies));
        }
    }
   
}