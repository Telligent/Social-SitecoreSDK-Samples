using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class BlogPostViewModel
    {

        public BlogPostViewModel(dynamic post, dynamic comments)
        {
            this.Post = post;
            this.Comments = comments;
        }
        public dynamic Post { get; private set; }
        public dynamic Comments { get; private set; }
    }
}