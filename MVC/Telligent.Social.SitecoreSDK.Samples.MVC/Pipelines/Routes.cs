using Sitecore.Pipelines;
using System.Web.Mvc;
using System.Web.Routing;

namespace Telligent.Social.SitecoreSDK.Samples.MVC.Initialize
{
    public class RegisterRoutes
    {
        public virtual void Process(PipelineArgs args)
        {
            var routes = RouteTable.Routes;
            
            //routes.MapRoute("xxx", "xxx/{controller}/{action}/{id}", new { action = "Index" });

            routes.MapRoute("ListForums", "mvccommunity/forums", new { controller = "Forum", action = "ListForums" });
            routes.MapRoute("ViewForum", "mvccommunity/forum/{forumId}", new { controller = "Forum", action = "ViewForum" });
            routes.MapRoute("ViewThread", "mvccommunity/thread/{threadId}", new { controller = "Forum", action = "ViewThread" });
            routes.MapRoute("CreateThread", "mvccommunity/thread/create/{forumId}", new { controller = "Forum", action = "CreateThread" });
            routes.MapRoute("CreateReply", "mvccommunity/thread/reply/create/{threadId}", new { controller = "Forum", action = "CreateReply" });
            
            routes.MapRoute("ListBlogs", "mvccommunity/blogs", new { controller = "Blog", action = "ListBlogs" });
            routes.MapRoute("BlogPostList", "mvccommunity/blogs/{id}", new { controller = "Blog", action = "ListPosts" });
            routes.MapRoute("BlogPost", "mvccommunity/blogs/{blogid}/post/{slug}", new { controller = "Blog", action = "ShowPost" });
        }
    }
}