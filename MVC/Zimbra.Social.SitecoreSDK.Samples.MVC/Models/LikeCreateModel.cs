using System;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class LikeCreateModel
    {
        public LikeCreateModel() { }

        public LikeCreateModel(Guid contentTypeId, Guid contentId)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
        }

        public Guid ContentTypeId { get;  set; }
        public Guid ContentId { get;   set; }
    }
}