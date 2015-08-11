using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Web.Mvc;
using Telligent.Evolution.Extensibility.Rest.Version1;
using Zimbra.Social.SitecoreSDK.Samples.MVC.Models;
using Zimbra.Social.SitecoreSDK.Samples.MVC.Util;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Controllers
{
    public class SocialController : Controller
    {
        #region Comments

        [HttpPost]
        public ActionResult CreateComment(CommentCreateModel model)
        {
            if (!ModelState.IsValid) return PartialView("_socialServices", new SocialModel { Comments = null });

            var options = new NameValueCollection
                {
                    {"ConentId", model.ContentId.ToString()},
                    {"ContentTypeId", model.ContentTypeId.ToString()},
                    {"Body", model.Body}
                };

                var response = Post(Endpoints.CommentsJson, options);
                var socialModel = new SocialModel { Comments = new CommentModel(response.Content.ContentTypeId, response.Content.ContentId, response.Comment) };

            return PartialView("_socialServices", socialModel);
        }

        public ActionResult ListComments(SocialModel socialService)
        {

            var options = new NameValueCollection
            {
                { "ContentId", socialService.Comments.ContentId.ToString()},
                { "PageSize", "25" },
                { "SortBy", "CreatedUtcDate" },
                { "SortOrder", "Ascending" }
            };

            var response = Get(Endpoints.CommentsJson, options);
            socialService.Comments.Results = response;

            return PartialView("_socialServices", socialService);
        }

        public ActionResult ShowComment(Guid commentId)
        {
            var response = Get(string.Format(Endpoints.CommentShowJson));
            var socialModel = new SocialModel { Comments = new CommentModel(response.Content.ContentTypeId, response.Content.ContentId, response.Comment) };
            return PartialView("_socialServices", socialModel);
        }

        #endregion

        #region Likes

        [HttpPost]
        public ActionResult CreateLike(LikeCreateModel model)
        {
            var options = new NameValueCollection
            {
                {"ContentId", model.ContentId.ToString()},
                {"ContentTypeId", model.ContentTypeId.ToString()}
            };

            var response = Post(Endpoints.LikesJson, options);
            var socialModel = new SocialModel { Likes = new LikeModel(response.Content.ContentTypeId, response.Content.ContentId, response.Like) };
            return PartialView("_likeService", socialModel);
        }

        public ActionResult ListLikes(SocialModel socialService)
        {
            var options = new NameValueCollection
            {
                {"ContentId", socialService.Likes.ContentId.ToString()}
            };

            var response = Get(Endpoints.LikesJson, options); 
            socialService.Likes.Results = response;
            return PartialView("_likeService", socialService);
        }

        public ActionResult ShowLike(Guid contentId)
        {
            var options = new NameValueCollection
            {
                {"ContentId", contentId.ToString()}
            };
            var response = Get(Endpoints.LikeJson, options);
            var socialModel = new SocialModel { Likes = new LikeModel(response.Content.ContentTypeId, response.Content.ContentId, response.Like) };
            return PartialView("_likeService", socialModel);
        }

        #endregion

        #region Ratings

        [HttpPost]
        public ActionResult CreateRating(RateCreateModel model)
        {
            var parms = new NameValueCollection
            {
                {"ContentId", model.ContentId.ToString()},
                {"ContentTypeId", model.ContentTypeId.ToString()},
                {"Value", model.Score.ToString(CultureInfo.InvariantCulture)}
            };

            var response = Post(Endpoints.RatingsJson, parms);
            var socialModel = new SocialModel { Ratings = new RateModel(response.Content.ContentTypeId, response.Content.ContentId, response.Rating) };
            return PartialView("_socialServices", socialModel);
        }

        public ActionResult ListRatings(Guid contentId, Guid contentTypeId)
        {
            var options = new NameValueCollection
            {
                {"ContentId", contentId.ToString()},
                {"ContentTypeId", contentTypeId.ToString()}
            };

            var response = Get(Endpoints.RatingsJson, options);
            var socialModel = new SocialModel { Ratings = new RateModel(response.Content.ContentTypeId, response.Content.ContentId, response.Ratings) };
            return PartialView("_socialServices", socialModel);
        }

        public ActionResult ShowRating(SocialModel socialService)
        {
            var options = new NameValueCollection
            {
                {"ContentId", socialService.Ratings.ContentId.ToString()}
            };

            var response = Get(Endpoints.RatingJson, options);
            socialService.Ratings.Results = response;
            return PartialView("_rateService", socialService);
        }

        #endregion

        private dynamic Post(string endpoint, NameValueCollection parms)
        {
            var host = Host.Get("default");
            var options = new RestPostOptions { PostParameters = parms };
            return host.PostToDynamic(2, endpoint, true, options);
        }

        private dynamic Get(string endpoint, NameValueCollection parms = null)
        {
            var host = Host.Get("default");
            RestGetOptions options = null;
            if (parms != null) options = new RestGetOptions { QueryStringParameters = parms };

            return host.GetToDynamic(2, endpoint, true, options);
        }
    }
}