using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telligent.Evolution.Extensibility.Rest.Version1;

public partial class Forums_ForumThreadCreate : System.Web.UI.UserControl
{
    private RestHost host;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        btnNewThreadAdd.Click += newThread_Click;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void newThread_Click(object sender, EventArgs e)
    {
        //If you loaded multiple hosts, like say for each website, replace the string with a retrieval method of your choice.
        //Example, if you loaded by site name you could get the current site name.
        host = Host.Get("default");

        int forumId;
        if (Request["f"] == null || !Int32.TryParse(Request["f"], out forumId))
        {
            throw new ArgumentException("Forum Id was missing or invalid");
        }

        var options = new NameValueCollection();
        options.Add("ForumId", forumId.ToString());
        options.Add("Subject", tbNewThreadSubject.Text);
        options.Add("Body", tbNewThreadBody.Text);

        var endpoint = string.Format("forums/{0}/threads.json", forumId);
        var postData = String.Join("&", options.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(options[a])));
        dynamic response = host.PostToDynamic(2, endpoint, postData);

        Response.Redirect(string.Format("/community/forum?f={0}", forumId));
    }
}