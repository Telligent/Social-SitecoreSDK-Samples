using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telligent.Evolution.Extensibility.Rest.Version1;

public partial class layouts_SocialSDK_BlogList : System.Web.UI.UserControl
{
    private Host _host;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptBlogs.ItemDataBound += rptBlogs_ItemDataBound;
    }

    void rptBlogs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;

        dynamic blog = e.Item.DataItem;

        HyperLink lnkName = e.Item.FindControl("lnkBlogName") as HyperLink;
        Literal litBody = e.Item.FindControl("litBody") as Literal;
        Literal litPosts = e.Item.FindControl("litTotalPosts") as Literal;
        Literal litLast = e.Item.FindControl("litLastPost") as Literal;

        if (blog.Name != null)
        {
            lnkName.Text = blog.Name;
            lnkName.NavigateUrl = ResolveUrl(string.Format("~/community/blogs?blogId ={0}", blog.Id));
        }

        if (blog.Description != null)
            litBody.Text = blog.Description;
        if (blog.PostCount != null)
            litPosts.Text = blog.PostCount.ToString() + " Posts";
        if (blog.LatestPostDate != null)
            litLast.Text = "Last Post:" + DateTime.Parse(blog.LatestPostDate).ToShortDateString();


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        litError.Visible = false;
        try
        {
            var host = Host.Get("default");
            var parms = new NameValueCollection();
            parms.Add("PageSize", "50");
            parms.Add("PageIndex", "0");
            parms.Add("SortBy", "LastPost");
            parms.Add("SortOrder", "Descending");



            var endpoint = "blogs.json";
            var options = new RestGetOptions();
            options.QueryStringParameters = parms;

            var response = host.GetToDynamic(2, endpoint, true, options);
            rptBlogs.DataSource = response.Blogs;
            rptBlogs.DataBind();
        }
        catch (Exception ex)
        {

            litError.Text = "<pre>" + ex.Message + ":" + ex.StackTrace + "</pre>";
            litError.Visible = true;
        }
    }
}