
namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class BlogPostViewModel
    {
        public BlogPostViewModel(dynamic post, SocialModel socialModel)
        {
            Post = post;
            SocialModel = socialModel;
        }

        public dynamic Post { get; private set; }
        public SocialModel SocialModel { get; private set; }
    }
}