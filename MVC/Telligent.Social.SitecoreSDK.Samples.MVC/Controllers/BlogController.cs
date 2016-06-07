using System.Collections.Specialized;
using System.Globalization;
using System.Web.Mvc;
using Telligent.Evolution.Extensibility.Rest.Version1;
using Telligent.Social.SitecoreSDK.Samples.MVC.Models;
using Telligent.Social.SitecoreSDK.Samples.MVC.Util;

namespace Telligent.Social.SitecoreSDK.Samples.MVC.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult ListBlogs()
        {
            var host = Host.Get("default");
            var parms = new NameValueCollection
            {
                {"PageSize", "50"},
                {"PageIndex", "0"},
                {"SortBy", "LastPost"},
                {"SortOrder", "Descending"}
            };

            var options = new RestGetOptions {QueryStringParameters = parms};
            var response = host.GetToDynamic(2, Endpoints.BlogsJson, true,options );

            return View("ListBlogs", response.Blogs);
        }

        public ActionResult ListPosts(int id)
        {
            var host = Host.Get("default");
            var parms = new NameValueCollection
            {
                {"PageSize", "50"},
                {"PageIndex", "0"},
                {"SortBy", "MostRecent"},
                {"SortOrder", "Descending"}
            };

            var options = new RestGetOptions {QueryStringParameters = parms};
            var pathParameters = new NameValueCollection {{"blogid", id.ToString(CultureInfo.InvariantCulture)}};

            options.PathParameters = pathParameters;

            var response = host.GetToDynamic(2, Endpoints.BlogsPostJson, true, options);

            return View("PostList", response.BlogPosts);
        }

        public ActionResult ShowPost(int blogid, string slug)
        {
            var host = Host.Get("default");

            BlogPostViewModel model = null;

            var postResponse = host.GetToDynamic(2, 
                Endpoints.BlogsPostNameJson, 
                true,
                new RestGetOptions
                {
                    PathParameters = new NameValueCollection
                    {
                        { "blogid", blogid.ToString(CultureInfo.InvariantCulture) }, 
                        { "name", slug }
                    }
                });

            if (postResponse != null)
            {
                model = new BlogPostViewModel(postResponse.BlogPost);
            }

            return View("Post", model);
        }
    }
}