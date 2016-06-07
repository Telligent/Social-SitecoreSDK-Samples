

namespace Telligent.Social.SitecoreSDK.Samples.MVC.Models
{
    public class SocialModel
    {
        public SocialModel() { }

        public SocialModel(string url)
        {
            Url = url;
        }

        public SocialModel(string contentTypeId, string contentId)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
        }

        public string Url { get; set; }
        public string ContentTypeId { get; set; }
        public string ContentId { get; set; }
    }
}