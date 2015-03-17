using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telligent.Evolution.Extensibility.Rest.Version1;

public partial class Forums_ForumThreadList : System.Web.UI.UserControl
{
    private RestHost host;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptForumThreads.ItemDataBound += rptForumThreads_ItemDataBound;
    }

    void rptForumThreads_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;

        //dont use forum.url
        //[sitecore]/community/forums?f=id

        dynamic thread = (dynamic)e.Item.DataItem;
        var subjectLabel = e.Item.FindControl("lnkSubject") as HyperLink;
        var lblReplies = e.Item.FindControl("lblReplies") as Label;
        var lblViews = e.Item.FindControl("lblViews") as Label;
        var lblLast = e.Item.FindControl("lblLast") as Label;
        var lblAuthor = e.Item.FindControl("lblAuthor") as Label;
        subjectLabel.Text = thread.Subject;
        subjectLabel.NavigateUrl = string.Format("/community/forums/thread?t={0}", thread.Id);
        lblReplies.Text = thread.ReplyCount.ToString();
        lblViews.Text = thread.ViewCount.ToString();
        lblLast.Text = DateTime.Parse(thread.LatestPostDate.ToString()).ToString();
        lblAuthor.Text = thread.Author.DisplayName;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        litError.Visible = false;
        try
        {
            //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
            //Example, if you loaded by site name you could get the current site name.
            host = Host.Get("default");

            int forumId;
            if (Request["f"] == null || !Int32.TryParse(Request["f"], out forumId))
            {
                throw new ArgumentException("Forum Id was missing or invalid");
            }

            lnkForumList.Text = "Forums";
            lnkForumList.NavigateUrl = "/community/forums";
            lnkThreadCreate.Text = "New Post";
            lnkThreadCreate.NavigateUrl = string.Format("/community/forums/create?f={0}", forumId);

            var endpointForumShow = string.Format("forums/{0}.json", forumId);
            dynamic responseForumShow = host.GetToDynamic(2, endpointForumShow);

            litForumName.Text = responseForumShow.Forum.Name;

            var options = new NameValueCollection();
            options.Add("PageSize", "50");
            options.Add("PageIndex", "0");
            options.Add("SortBy", "LastPost");
            options.Add("SortOrder", "Descending");

            var endpointThreadList = string.Format("forums/{0}/threads.json?{1}", forumId,
                String.Join("&", options.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(options[a]))));
            dynamic responseThreadList = host.GetToDynamic(2, endpointThreadList);
            rptForumThreads.DataSource = responseThreadList.Threads;
            rptForumThreads.DataBind();
        }
        catch (Exception ex)
        {
            litError.Text = ex.Message + "<br/><pre>" + ex.StackTrace + "</pre>";
            litError.Visible = true;
        }
    }
}