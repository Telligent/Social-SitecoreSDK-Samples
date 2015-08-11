using System;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class LikeModel
    {
        public LikeModel() { }

        public LikeModel(Guid contentTypeId, Guid contentId, dynamic results)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
            Results = results;
            LikeCreateModel = new LikeCreateModel(contentTypeId, contentId);
        }

       public Guid ContentTypeId { get;  set; }
       public Guid ContentId { get; set; }
       public LikeCreateModel LikeCreateModel { get; set; }
       public dynamic Results { get; set; }
    }
}