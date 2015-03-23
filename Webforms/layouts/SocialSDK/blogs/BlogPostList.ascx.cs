using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telligent.Evolution.Extensibility.Rest.Version1;

public partial class layouts_SocialSDK_BlogPostList : System.Web.UI.UserControl
{
    
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPosts.ItemDataBound += rptPosts_ItemDataBound;
    }

    void rptPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;

        dynamic post = e.Item.DataItem;

        HyperLink lnkName = e.Item.FindControl("lnkTitle") as HyperLink;
        Literal litBody = e.Item.FindControl("litBody") as Literal;
        Label lblPostDate = e.Item.FindControl("lblPostDate") as Label;
        Label lblAuthor = e.Item.FindControl("lblAuthor") as Label;
        Label lblViews = e.Item.FindControl("lblViews") as Label;
        Label lblComments = e.Item.FindControl("lblComments") as Label;

        if (post.Title != null)
        {
            lnkName.Text = post.Title;
            lnkName.NavigateUrl = ResolveUrl(string.Format("~/community/blogs/post?postId={0}&blogId={1}", post.Id,post.BlogId));
        }

        if (post.Excerpt != null)
            litBody.Text = post.Excerpt;
        if (post.CommentCount != null)
            lblComments.Text = post.CommentCount.ToString() + " Commments";
        if (post.PublishedDate != null)
            lblPostDate.Text = DateTime.Parse(post.PublishedDate).ToString("f");
        if (post.Views != null)
            lblViews.Text = post.Views + " Views";
        if (post.Author.DisplayName != null)
            lblAuthor.Text = post.Author.DisplayName;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        litError.Visible = false;
        try
        {
            var id = Request.QueryString["blogid"];
            if(string.IsNullOrEmpty(id))
                throw new ApplicationException("blogid querystring parameter is required.");
            var host = Host.Get("default");
            var parms = new NameValueCollection();
            parms.Add("PageSize", "50");
            parms.Add("PageIndex", "0");
            parms.Add("SortBy", "MostRecent");
            parms.Add("SortOrder", "Descending");



            var endpoint = "blogs/{blogid}/posts.json";
            var options = new RestGetOptions();
            options.QueryStringParameters = parms;

            var pathParameters = new NameValueCollection();
            pathParameters.Add("blogid",id);
            options.PathParameters = pathParameters;

            var response = host.GetToDynamic(2, endpoint, true, options);
            rptPosts.DataSource = response.BlogPosts;
            rptPosts.DataBind();
        }
        catch (Exception ex)
        {

            litError.Text = "<pre>" + ex.Message + ":" + ex.StackTrace + "</pre>";
            litError.Visible = true;
        }
    }
}