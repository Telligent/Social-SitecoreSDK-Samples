using System;

namespace Telligent.SitecoreSDK.Samples.MVC.Models
{
    public class LikeCreateDeleteModel
    {
        public LikeCreateDeleteModel() { }

        public LikeCreateDeleteModel(string url)
        {
            Url = url;
        }

        public LikeCreateDeleteModel(string contentTypeId, string contentId)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
        }

        public string ContentTypeId { get; set; }
        public string ContentId { get; set; }
        public string Url { get; set; }
    }
}