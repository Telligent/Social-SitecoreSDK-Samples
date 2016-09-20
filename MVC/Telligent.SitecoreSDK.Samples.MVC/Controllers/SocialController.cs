using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Web.Mvc;
using Telligent.Evolution.Extensibility.OAuthClient.Version1;
using Telligent.Evolution.Extensibility.Rest.Version1;
using Telligent.SitecoreSDK.Samples.MVC.Models;
using Telligent.SitecoreSDK.Samples.MVC.Util;

namespace Telligent.SitecoreSDK.Samples.MVC.Controllers
{
    public class SocialController : Controller
    {
        #region Comments

        [HttpPost]
        public ContentResult CommentCreate(CommentCreateModel model)
        {
            if (!ModelState.IsValid) return Content(@"{""success"":""false"",""error"":""Model state is not valid.""}", "application/json");

            var options = new NameValueCollection
            {
                {"Body", model.Body}
            };

            if (!string.IsNullOrEmpty(model.Url))
            {
                options.Add("ContentUrl", model.Url);
            }
            else
            {
                options.Add("ContentTypeId", model.ContentTypeId);
                options.Add("ContentId", model.ContentId);
            }

            return Post(Endpoints.CommentsJson, options);
        }

        public ActionResult CommentList(SocialModel socialService)
        {
            var comments = new CommentModel();
            var options = new NameValueCollection
            {
                { "PageSize", "25" },
                { "SortBy", "CreatedUtcDate" },
                { "SortOrder", "Ascending" }
            };

            if (!string.IsNullOrEmpty(socialService.Url))
            {
                comments.Url = socialService.Url;
                options.Add("ContentUrl", socialService.Url);
            }
            else
            {
                comments.ContentId = socialService.ContentId;
                comments.ContentTypeId = socialService.ContentTypeId;
                options.Add("ContentId", socialService.ContentId);
            }

            comments.Results = Get(Endpoints.CommentsJson, options);

            return PartialView("_commentService", comments);
        }

        public ActionResult CommentShow(Guid commentId)
        {
            var comments = new CommentModel
            {
                Results = Get(string.Format(Endpoints.CommentShowJson))
            };
            return PartialView("_commentService", comments);
        }

        #endregion

        #region Likes

        [HttpPost]
        public ContentResult LikeCreate(LikeCreateDeleteModel model)
        {
            return LikePost(model, Endpoints.LikesJson, Post);
        }

        [HttpPost]
        public ContentResult LikeDelete(LikeCreateDeleteModel model)
        {
            return LikePost(model, Endpoints.LikeJson, Delete);
        }

        public ActionResult LikeList(SocialModel socialService)
        {
            return LikeGet(socialService, Endpoints.LikesJson, true);
        }

        public ActionResult LikeShow(SocialModel socialService)
        {
            return LikeGet(socialService, Endpoints.LikeJson);
        }

        private ActionResult LikeGet(SocialModel socialService, string endpoint, bool checkIsLiked = false)
        {
            var like = new LikeModel();
            var options = new NameValueCollection();

            if (!string.IsNullOrEmpty(socialService.Url))
            {
                like.Url = socialService.Url;
                options.Add("ContentUrl", socialService.Url);
            }
            else
            {
                like.ContentId = socialService.ContentId;
                like.ContentTypeId = socialService.ContentTypeId;
                options.Add("ContentId", socialService.ContentId);
            }

            if (checkIsLiked)
            {
                var optionsChecker = new NameValueCollection(options);
                var host = Host.Get("default");
                var user = host.GetCurrentHttpContext().Items["SDK-User"] as User;
                if (user != null)
                {
                    optionsChecker.Add("UserId", user.UserId.ToString(CultureInfo.InvariantCulture));
                    optionsChecker.Add("PageSize", "1");
                    optionsChecker.Add("PageIndex", "0");
                }
                var likeChecker = Get(endpoint, optionsChecker);
                like.IsLiked = likeChecker != null && likeChecker.TotalCount > 0;
            }

            like.Results = Get(endpoint, options);

            return PartialView("_likeService", like);
        }

        private ContentResult LikePost(LikeCreateDeleteModel model, string endpoint, Func<string, NameValueCollection, ContentResult> request)
        {
            if (!ModelState.IsValid) return Content(@"{""success"":""false"",""error"":""Model state is not valid.""}", "application/json");

            var options = new NameValueCollection();

            if (!string.IsNullOrEmpty(model.Url))
            {
                options.Add("ContentUrl", model.Url);
            }

            if (!string.IsNullOrEmpty(model.ContentTypeId))
            {
                options.Add("ContentTypeId", model.ContentTypeId);
            }

            if (!string.IsNullOrEmpty(model.ContentId))
            {
                
                options.Add("ContentId", model.ContentId);
            }

            return request(endpoint, options);
        }

        #endregion

        #region Ratings

        [HttpPost]
        public ContentResult RateCreate(RateCreateModel model)
        {
            var options = new NameValueCollection
            {
                {"Value", model.Score.ToString(CultureInfo.InvariantCulture)}
            };

            if (!string.IsNullOrEmpty(model.Url))
            {
                options.Add("ContentUrl", model.Url);
            }
            else
            {
                options.Add("ContentTypeId", model.ContentTypeId);
                options.Add("ContentId", model.ContentId);
            }

            return Post(Endpoints.RatingsJson, options);
        }
        
        public ActionResult RateShow(SocialModel socialService)
        {
            var rating = new RateModel();
            var options = new NameValueCollection();

            if (!string.IsNullOrEmpty(socialService.Url))
            {
                rating.Url = socialService.Url;
                options.Add("ContentUrl", socialService.Url);
            }
            else
            {
                rating.ContentId = socialService.ContentId;
                rating.ContentTypeId = socialService.ContentTypeId;
                options.Add("ContentId", socialService.ContentId);
            }

            rating.Results = Get(Endpoints.RatingJson, options);

            return PartialView("_rateService", rating);
        }

        #endregion

        #region Helpers

        private ContentResult Delete(string endpoint, NameValueCollection parms)
        {
            var host = Host.Get("default");
            var options = new RestDeleteOptions { QueryStringParameters = parms };
            try
            {
                var json = host.DeleteToString(2, endpoint, true, options);
                return Content(json, "application/json");
            }
            catch (Exception)
            {
                return Content("{}", "application/json");
            }
        }

        private ContentResult Post(string endpoint, NameValueCollection parms)
        {
            var host = Host.Get("default");
            var options = new RestPostOptions { PostParameters = parms };
            var json = host.PostToString(2, endpoint, true, options);

            return Content(json, "application/json");
        }

        private dynamic Get(string endpoint, NameValueCollection parms = null)
        {
            var host = Host.Get("default");
            RestGetOptions options = null;
            if (parms != null) options = new RestGetOptions { QueryStringParameters = parms };

            return host.GetToDynamic(2, endpoint, true, options);
        }

        #endregion
    }
}