
namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class CommentCreateModel
    {
        public CommentCreateModel() { }

        public CommentCreateModel(string url)
        {
            Url = url;
        }

        public CommentCreateModel(string contentTypeId, string contentId)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
        }

        public string ContentTypeId { get; set; }
        public string ContentId { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
    }
}