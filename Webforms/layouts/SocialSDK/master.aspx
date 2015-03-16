<%@ Import Namespace="Sitecore.Analytics"%>
<%@ Page Language="c#" Inherits="System.Web.UI.Page" CodePage="65001" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <title>Social SDK Webforms Samples</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
       <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>

    <link href="~/layouts/SocialSDK/css/site.css" rel="stylesheet" />
  <sc:VisitorIdentification runat="server" />
</head>
<body> 
  <form id="mainform" method="post" runat="server">
      
       <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">SDK Samples</a>
                </div>
                <div id="navbar" class="collapse navbar-collapse">
                    <ul class="nav navbar-nav">
                        <li><asp:HyperLink runat="server" NavigateUrl="~/community/blogs.aspx">Blogs</asp:HyperLink></li>
                        <li><asp:HyperLink runat="server" NavigateUrl="~/community/forms.aspx">Forums</asp:HyperLink></li>
                    </ul>
                </div><!--/.nav-collapse -->
            </div>
        </nav>
      

    <div id="MainPanel" class="container">
      <sc:placeholder key="main" runat="server" /> 
    </div>
  </form>
 </body>
</html>
