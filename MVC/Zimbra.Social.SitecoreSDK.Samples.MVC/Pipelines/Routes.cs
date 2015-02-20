using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Initialize
{
    public class RegisterRoutes
    {
        public virtual void Process(PipelineArgs args)
        {
            var routes = RouteTable.Routes;
            routes.MapRoute("ListForums", "mvccommunity/forums", new { controller = "Forum", action = "ListForums" });
            routes.MapRoute("ViewForum", "mvccommunity/forum/{forumId}", new { controller = "Forum", action = "ViewForum" });
            routes.MapRoute("ViewThread", "mvccommunity/thread/{threadId}", new { controller = "Forum", action = "ViewThread" });
            routes.MapRoute("CreateThread", "mvccommunity/thread/create/{forumId}", new { controller = "Forum", action = "CreateThread" });
            routes.MapRoute("CreateReply", "mvccommunity/thread/reply/create/{threadId}", new { controller = "Forum", action = "CreateReply" });
            //routes.MapRoute("xxx", "xxx/{controller}/{action}/{id}", new { action = "Index" });

            routes.MapRoute("ListBlogs", "mvccommunity/blogs", new { controller = "Blog", action = "ListBlogs" });
        }
    }
}