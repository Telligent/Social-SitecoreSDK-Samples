using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Shell.Framework.Commands.Favorites;
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

        host = Host.Get("default");

        int forumId;
        if (Request["f"] == null || !Int32.TryParse(Request["f"], out forumId))
        {
            throw new ArgumentException("Forum Id was missing or invalid");
        }

        var options = new NameValueCollection();

        options.Add("Subject", tbNewThreadSubject.Text);
        options.Add("Body", tbNewThreadBody.Text);

        var pathParms = new NameValueCollection();
        pathParms.Add("forumid",forumId.ToString());

        var endpoint = "forums/{forumid}/threads.json";
        
        dynamic response = host.PostToDynamic(2, endpoint, true,new RestPostOptions(){PathParameters = pathParms,PostParameters = options});

        Response.Redirect(string.Format("/community/forum?f={0}", forumId));
    }
}