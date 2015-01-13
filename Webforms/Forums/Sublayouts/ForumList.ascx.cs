using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telligent.Evolution.Extensibility.UI.Version1;
using Zimbra.Social.RemotingSDK.Sitecore;

public partial class Forums_ForumList : System.Web.UI.UserControl
{
    private RemoteScriptedContentFragmentHost host;
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
        litDesc.Text = forum.Description;
        lblThreads.Text = forum.ThreadCount.ToString();
        lblReplies.Text = forum.ReplyCount.ToString();

      //  var ago = host.ExecuteMethod("core_v2_language", "FormatAgoDate", (DateTime) forum.LatestPostDate, true);
      //  lblLast.Text = ago.ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        litError.Visible = false;
        try
        {

            //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
            //Example, if you loaded by site name you could get the current site name.
             host = Api.GetHost("website", true);

            //When faced with options objects used in platofmr API, you can pass them in as Hashtables with the key being the property
            //and the value
            var options = new Hashtable();
            options.Add("PageSize",50);
            options.Add("PageIndex",0);
            options.Add("SortBy","LastPost");
            options.Add("SortOrder","Descending");

            //The third parameter is a params[] argument, it should be the method arguments for the corresponding API.
            //example:  If the API is core_v2_Foo.List(int,string,Options options) then the 3rd parm could be (1,"bar",Hashtable obj)
            dynamic forums = host.ExecuteMethod("core_v2_forum", "List", options);
            rptForums.DataSource = forums;
            rptForums.DataBind();
        }
        catch (Exception ex)
        {
            litError.Text = ex.Message + "<br/><pre>" + ex.StackTrace + "</pre>";
            litError.Visible = true;
        }


    }
}