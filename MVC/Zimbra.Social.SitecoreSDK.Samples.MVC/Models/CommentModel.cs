using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Query.Dynamic;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC.Models
{
    public class CommentModel
    {
        public CommentModel(Guid contentTypeId,Guid contentId, dynamic comments)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
            Comments = comments;
            CommentCreateModel = new CommentCreateModel(contentTypeId, contentId);
        }
       public Guid ContentTypeId { get;  set; }
       public Guid ContentId { get; private set; }
       public CommentCreateModel CommentCreateModel { get;  set; }
       public dynamic Comments { get;  set; }
    }

   
}