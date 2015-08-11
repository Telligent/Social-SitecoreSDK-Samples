using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telligent.Evolution.Extensibility.Rest.Version1;
using Zimbra.Social.SitecoreSDK.Samples.MVC.Models;
using Zimbra.Social.SitecoreSDK.Samples.MVC.Util;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum  Currently a site wide aggregate
        public ActionResult ListForums()
        {
            //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
            //Example, if you loaded by site name you could get the current site name.
            var host = Host.Get("default");

            //When faced with options objects used in platofmr API, you can pass them in as Hashtables with the key being the property
            //and the value
            var options = new NameValueCollection
            {
                {"PageSize", "50"},
                {"PageIndex", "0"},
                {"SortBy", "LastPost"},
                {"SortOrder", "Descending"}
            };

            var endpoint = Endpoints.ForumList + ParseQueryString(options);
            //The third parameter is a params[] argument, it should be the method arguments for the corresponding API.
            //example:  If the API is core_v2_Foo.List(int,string,Options options) then the 3rd parm could be (1,"bar",Hashtable obj)

            var response =host.GetToDynamic(2, endpoint);
           
            return View("ListForums", response.Forums);
        }

        public ActionResult ViewForum(int forumId)
        {
            //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
            //Example, if you loaded by site name you could get the current site name.
            var host = Host.Get("default");

            var endpointForumShow = string.Format(Endpoints.ForumView, forumId);
            dynamic responseForumShow = host.GetToDynamic(2, endpointForumShow);

            ViewBag.ForumName = responseForumShow.Forum.Name;
            ViewBag.ForumId = responseForumShow.Forum.Id;

            var options = new NameValueCollection
            {
                {"PageSize", "50"},
                {"PageIndex", "0"},
                {"SortBy", "LastPost"},
                {"SortOrder", "Descending"}
            };

            var endpointThreadList = string.Format(Endpoints.ThreadsList, forumId,
                String.Join("&", options.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(options[a]))));
            dynamic responseThreadList = host.GetToDynamic(2, endpointThreadList);

            return View("ViewForum", responseThreadList.Threads);
        }

        public ActionResult ViewThread(int threadId)
        {
            //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
            //Example, if you loaded by site name you could get the current site name.
            var host = Host.Get("default");

            var endpointThreadShow = string.Format("forums/threads/{0}.json", threadId);
            dynamic responseThreadShow = host.GetToDynamic(2, endpointThreadShow);

            var options = new NameValueCollection();
            options.Add("PageSize", "50");
            options.Add("PageIndex", "0");
            options.Add("SortBy", "PostDate");
            options.Add("SortOrder", "Ascending");

            var endpointForumShow = string.Format("forums/{0}.json", responseThreadShow.Thread.ForumId);
            dynamic responseForumShow = host.GetToDynamic(2, endpointForumShow);

            ViewBag.ForumName = responseForumShow.Forum.Name;
            ViewBag.ForumId = responseForumShow.Forum.Id;

            var endpoint = string.Format("forums/{0}/threads/{1}/replies.json?{2}", responseForumShow.Forum.Id, threadId,
                String.Join("&", options.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(options[a]))));
            dynamic response = host.GetToDynamic(2, endpoint);
            if (response.Errors.Count > 0)
                throw new Exception(response.Errors[0].Message.ToString());

            return View("ViewThread", new ForumThreadViewModel(responseThreadShow.Thread, response.Replies));
        }

        public ActionResult CreateReply(int threadId)
        {
            return View(new ForumReplyCreateModel() { ThreadId = threadId });
        }

        [HttpPost]
        public ActionResult CreateReply(ForumReplyCreateModel model)
        {
            if (ModelState.IsValid)
            {
                //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
                //Example, if you loaded by site name you could get the current site name.
                var host = Host.Get("default");

                var path = new NameValueCollection();
                path.Add("ThreadId", model.ThreadId.ToString());
                var post = new NameValueCollection();
                post.Add("Body", model.Body);

                dynamic response = host.PostToDynamic(2, "forums/threads/{ThreadId}/replies.json", true, 
                    new RestPostOptions { PathParameters = path, PostParameters = post });

                return RedirectToAction("ViewThread",new{threadId=model.ThreadId});
            }
            return View(model);
        }

        public ActionResult CreateThread(int forumId)
        {
            return View(new ForumThreadCreateModel() { ForumId = forumId });
        }

        [HttpPost]
        public ActionResult CreateThread(ForumThreadCreateModel model)
        {
            if (ModelState.IsValid)
            {
                //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
                //Example, if you loaded by site name you could get the current site name.
                var host = Host.Get("default");

                var path = new NameValueCollection();
                path.Add("ForumId", model.ForumId.ToString());
                var post = new NameValueCollection();
                post.Add("Subject", model.Subject);
                post.Add("Body", model.Body);

                dynamic response = host.PostToDynamic(2, "forums/{ForumId}/threads.json", true, new RestPostOptions { PathParameters = path, PostParameters = post});

                return RedirectToAction("ViewThread",new {threadId=response.Thread.Id});
            }

            return View(model);
        }

        private string ParseQueryString(NameValueCollection nvc)
        {
            string q = String.Join("&",
              nvc.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(nvc[a])));
            return q;
        }
    }
   
}