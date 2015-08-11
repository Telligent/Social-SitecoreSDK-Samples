using System;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class RateModel
    {
        public RateModel() { }

        public RateModel(Guid contentTypeId, Guid contentId, dynamic results)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
            Results = results;
            Value = results != null && results.Rating != null ? results.Rating : 0;
            RateCreateModel = new LikeCreateModel(contentTypeId, contentId);
        }

        public int Value { get; set; }
        public Guid ContentTypeId { get;  set; }
        public Guid ContentId { get; set; }
        public LikeCreateModel RateCreateModel { get; set; }
        public dynamic Results { get; set; }
    }
}