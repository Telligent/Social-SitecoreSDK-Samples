using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telligent.Evolution.Extensibility.Rest.Version1;

public partial class layouts_SocialSDK_BlogPost : System.Web.UI.UserControl
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptComments.ItemDataBound += rptComments_ItemDataBound;
    }

    void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;

        dynamic comment = e.Item.DataItem;
        Literal litBody = e.Item.FindControl("litBody") as Literal;
        Label lblDate = e.Item.FindControl("lblDate") as Label;
        Label lblAuthor = e.Item.FindControl("lblAuthor") as Label;

        if (comment.User.DisplayName != null)
            lblAuthor.Text = comment.User.DisplayName;
        if (comment.CreatedDate != null)
            lblDate.Text = DateTime.Parse(comment.CreatedDate).ToString("f");
        if (comment.Body != null)
            litBody.Text = comment.Body;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var blogid = Request.QueryString["blogid"];
            if (string.IsNullOrEmpty(blogid))
                throw new ApplicationException("blogid querystring parameter is required.");
            var postid = Request.QueryString["postid"];
            if (string.IsNullOrEmpty(postid))
                throw new ApplicationException("blogid querystring parameter is required.");

            var host = Host.Get("default");


            var postResponse = host.GetToDynamic(2, "blogs/{blogid}/posts/{id}.json", true,
                new RestGetOptions()
                {
                    PathParameters = new NameValueCollection() { { "blogid", blogid.ToString() }, { "id", postid } }
                });

            if (postResponse != null)
            {
                dynamic post = postResponse.BlogPost;
                if (post.Body != null)
                    litBody.Text = post.Body;
                if (post.CommentCount != null)
                    lblComments.Text = post.CommentCount.ToString() + " Commments";
                if (post.PublishedDate != null)
                    lblPostDate.Text = DateTime.Parse(post.PublishedDate).ToString("f");
                if (post.Views != null)
                    lblViews.Text = post.Views + " Views";
                if (post.Author.DisplayName != null)
                    lblAuthor.Text = post.Author.DisplayName;

                dynamic  commentResponse = host.GetToDynamic(2, "comments.json", true,
                new RestGetOptions()
                {
                    QueryStringParameters = new NameValueCollection()
                    {
                        { "ContentId", postResponse.BlogPost.ContentId.ToString() }
                        ,{ "ContentTypeId", postResponse.BlogPost.ContentTypeId }
                         ,{ "PageSize", "25" }
                          ,{ "SortBy", "CreatedUtcDate" }
                          ,{ "SortOrder", "Ascending" }
                    }
                });

                rptComments.DataSource = commentResponse.Comments;
                rptComments.DataBind();


            }
        }
        catch (Exception ex)
        {

            litError.Text = "<pre>" + ex.Message + ":" + ex.StackTrace + "</pre>";
            litError.Visible = true;
        }
       
       
    }
}