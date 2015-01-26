using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telligent.Evolution.Extensibility.OAuthClient.Version1;
using Zimbra.Social.RemotingSDK.Sitecore;

namespace Zimbra.Social.SitecoreSDK.Samples.MVC
{
    public static class Helpers
    {
        public static HtmlString LoginLogoutLink(this HtmlHelper helper,string returnUrl = null)
        {
            

            var host = Api.GetHost("website", true);
            var user = OAuthAuthentication.GetAuthenticatedUser(host.Id);
            if (user != null)
            {
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("rtn", HttpContext.Current.Request.Url.OriginalString);
                return new HtmlString("<span class=\"sser-name\">" + user.UserName + "</span>&nbsp;<a href=\"" + OAuthAuthentication.EvolutionLogOut(host.Id, nvc).OriginalString + "\">Logout</a>");
            }
            else
            {
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("rtn", HttpContext.Current.Request.Url.OriginalString);
                return new HtmlString("<a href=\"" + OAuthAuthentication.Login(host.Id, nvc).OriginalString + "\">Login</a>");
            }
                
        }
    }
}