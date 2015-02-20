using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.IO;
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

            var response = host.GetToDynamic(2, endpoint, true,options );

            return View("ListBlogs", response.Blogs);
        }

        public ActionResult ListPosts(int id)
        {

            var host = Host.Get("default");
            var parms = new NameValueCollection();
            parms.Add("PageSize", "50");
            parms.Add("PageIndex", "0");
            parms.Add("SortBy", "MostRecent");
            parms.Add("SortOrder", "Descending");



            var endpoint = "blogs/{blogid}/posts.json";
            var options = new RestGetOptions();
            options.QueryStringParameters = parms;

            var pathParameters = new NameValueCollection();
            pathParameters.Add("blogid",id.ToString());
            options.PathParameters = pathParameters;

            var response = host.GetToDynamic(2, endpoint, true, options);

            return View("PostList", response.BlogPosts);
        }

        public ActionResult ShowPost(int blogid,string slug)
        {

            var host = Host.Get("default");
            BlogPostViewModel model = null;
            

            var postResponse = host.GetToDynamic(2, "blogs/{blogid}/posts/{name}.json", true,
                new RestGetOptions()
                {
                    PathParameters = new NameValueCollection() {{"blogid", blogid.ToString()}, {"name", slug}}
                });

            if (postResponse != null)
            {
                var commentResponse = host.GetToDynamic(2, "comments.json", true,
                new RestGetOptions()
                {
                    QueryStringParameters  = new NameValueCollection()
                    {
                        { "ContentId", postResponse.BlogPost.ContentId.ToString() }
                        ,{ "ContentTypeId", postResponse.BlogPost.ContentTypeId }
                         ,{ "PageSize", "25" }
                          ,{ "SortBy", "CreatedUtcDate" }
                          ,{ "SortOrder", "Ascending" }
                    }
                });

                model = new BlogPostViewModel(postResponse.BlogPost
                    ,new CommentModel(postResponse.BlogPost.ContentTypeId
                        ,postResponse.BlogPost.ContentId
                        ,commentResponse.Comments));
               
            }

           

            return View("Post",model);
        }
    }

}