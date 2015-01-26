using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telligent.Evolution.Extensibility.Rest.Version1;


public partial class Forums_ForumList : System.Web.UI.UserControl
{
    private RestHost host;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptForums.ItemDataBound += rptForums_ItemDataBound;
    }

    void rptForums_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType !=ListItemType.AlternatingItem)
            return;

        dynamic forum = (dynamic) e.Item.DataItem;
        var nameLabel = e.Item.FindControl("lnkName") as HyperLink;
        var litDesc = e.Item.FindControl("litDescription") as Literal;
        var lblThreads = e.Item.FindControl("lblThreads") as Label;
        var lblReplies = e.Item.FindControl("lblReplies") as Label;
        var lblLast = e.Item.FindControl("lblLast") as Label; 
        nameLabel.Text = forum.Name;
        nameLabel.NavigateUrl = forum.Url;
        litDesc.Text = string.IsNullOrEmpty(forum.Description) ? "":forum.Description;
        lblThreads.Text = forum.ThreadCount.ToString();
        lblReplies.Text = forum.ReplyCount.ToString();
        lblLast.Text = DateTime.Parse(forum.LatestPostDate.ToString()).ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        litError.Visible = false;
        try
        {

            //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
            //Example, if you loaded by site name you could get the current site name.
             host = Zimbra.Social.RemotingSDK.Sitecore.Api.GetHost("website", true);

            var options = new NameValueCollection();
            options.Add("PageSize", "50");
            options.Add("PageIndex", "0");
            options.Add("SortBy", "LastPost");
            options.Add("SortOrder", "Descending");

            var endpoint = "forums.json?" + String.Join("&", options.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(options[a])));
            dynamic response = host.GetToDynamic(2, endpoint);
            rptForums.DataSource = response.Forums;
            rptForums.DataBind();
        }
        catch (Exception ex)
        {
            litError.Text = ex.Message + "<br/><pre>" + ex.StackTrace + "</pre>";
            litError.Visible = true;
        }


    }
}