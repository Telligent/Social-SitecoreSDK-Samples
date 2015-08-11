using System;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class RateCreateModel
    {
        public RateCreateModel() { }

        public RateCreateModel(Guid contentTypeId, Guid contentId)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
        }

        public Guid ContentTypeId { get;  set; }
        public Guid ContentId { get;   set; }
        public double Score { get; set; }
    }
}