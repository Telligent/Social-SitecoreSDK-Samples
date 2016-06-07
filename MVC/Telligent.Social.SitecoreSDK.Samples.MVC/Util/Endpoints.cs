
namespace Telligent.Social.SitecoreSDK.Samples.MVC.Util
{
    public class Endpoints
    {
        //Comments
        public static string CommentsJson = "comments.json";
        public static string CommentShowJson = "comments/{0}.json";

        //Likes
        public static string LikesJson = "likes.json";
        public static string LikeJson = "like.json";

        //Ratings
        public static string RatingsJson = "ratings.json";
        public static string RatingJson = "rating.json";

        //Forums
        public static string ForumList = "forums.json?";
        public static string ForumView = "forums/{0}.json";
        public static string ThreadsList = "forums/{0}/threads.json?{1}";

        //Blogs
        public static string BlogsJson = "blogs.json";
        public static string BlogsPostJson = "blogs/{blogid}/posts.json";
        public static string BlogsPostNameJson = "blogs/{blogid}/posts/{name}.json";
    }
}