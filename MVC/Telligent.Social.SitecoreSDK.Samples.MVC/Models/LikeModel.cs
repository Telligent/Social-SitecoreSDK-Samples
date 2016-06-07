using System;

namespace Telligent.Social.SitecoreSDK.Samples.MVC.Models
{
    public class LikeModel
    {
        public LikeModel() { }

        public LikeModel(string contentTypeId, string contentId, dynamic results)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
            Results = results;
        }

       public string ContentTypeId { get; set; }
       public string ContentId { get; set; }
       public string Url { get; set; }
       public dynamic Results { get; set; }
       public bool IsLiked { get; set; }
    }
}