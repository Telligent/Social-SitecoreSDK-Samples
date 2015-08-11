using System;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class CommentCreateModel
    {
        public CommentCreateModel() { }

        public CommentCreateModel(Guid contentTypeId,Guid contentId)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
        }

        public Guid ContentTypeId { get;  set; }
        public Guid ContentId { get;   set; }
        public string Body { get; set; }
    }
}