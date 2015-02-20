using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class BlogPostViewModel
    {

        public BlogPostViewModel(dynamic post, CommentModel  commentModel)
        {
            this.Post = post;
            this.CommentModel = commentModel;
        }
        public dynamic Post { get; private set; }
        public CommentModel CommentModel { get; private set; }
    }
}