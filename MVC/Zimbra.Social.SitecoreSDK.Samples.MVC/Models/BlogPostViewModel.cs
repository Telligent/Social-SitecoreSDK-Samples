
namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class BlogPostViewModel
    {
        public BlogPostViewModel(dynamic post)
        {
            Post = post;
        }

        public dynamic Post { get; private set; }
    }
}