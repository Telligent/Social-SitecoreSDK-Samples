using System;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class RateCreateModel
    {
        public RateCreateModel() { }

        public RateCreateModel(string url)
        {
            Url = url;
        }

        public RateCreateModel(string contentTypeId, string contentId)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
        }

        public string ContentTypeId { get; set; }
        public string ContentId { get; set; }
        public string Url { get; set; }
        public double Score { get; set; }
    }
}