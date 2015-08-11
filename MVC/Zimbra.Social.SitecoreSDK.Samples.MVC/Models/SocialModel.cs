
using System;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class SocialModel
    {
        private readonly Guid _contentTypeId;
        private readonly Guid _contentId;

        private CommentModel _comments;
        private LikeModel _likes;
        private RateModel _ratings;

        public SocialModel() { }

        public SocialModel(string url) { }

        public SocialModel(Guid contentTypeId, Guid contentId)
        {
            _contentTypeId = contentTypeId;
            _contentId = contentId;
        }
        
        public CommentModel Comments {
            get
            {
                return _comments ?? (_comments = new CommentModel { ContentTypeId = _contentTypeId, ContentId = _contentId });
            }
            set
            {
                _comments = value;
            }
        }
        public LikeModel Likes
        {
            get
            {
                return _likes ?? (_likes = new LikeModel { ContentTypeId = _contentTypeId, ContentId = _contentId });
            }
            set
            {
                _likes = value;
            }
        }
        public RateModel Ratings
        {
            get
            {
                return _ratings ?? (_ratings = new RateModel { ContentTypeId = _contentTypeId, ContentId = _contentId });
            }
            set
            {
                _ratings = value;
            }
        }
    }
}