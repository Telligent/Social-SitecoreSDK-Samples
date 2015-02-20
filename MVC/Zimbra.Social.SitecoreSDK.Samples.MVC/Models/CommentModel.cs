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
        }
       public Guid ContentTypeId { get; private set; }
       public Guid ContentId { get; private set; }
       public dynamic Comments { get; private set; }
    }

   
}