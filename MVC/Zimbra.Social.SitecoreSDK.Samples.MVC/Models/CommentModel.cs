using System;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class CommentModel
    {
        public CommentModel() { }

        public CommentModel(Guid contentTypeId, Guid contentId, dynamic results)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
            Results = results;
            CommentCreateModel = new CommentCreateModel(contentTypeId, contentId);
        }

       public Guid ContentTypeId { get;  set; }
       public Guid ContentId { get; set; }
       public CommentCreateModel CommentCreateModel { get;  set; }
       public dynamic Results { get;  set; }
    }
}