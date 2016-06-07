
namespace Telligent.Social.SitecoreSDK.Samples.MVC.Models
{
    public class ForumThreadViewModel
    {
        public ForumThreadViewModel(dynamic thread,dynamic replies)
        {
            Thread = thread;
            Replies = replies;
        }
        public dynamic Thread { get; private set; }
        public dynamic Replies { get; private set; }
    }
}