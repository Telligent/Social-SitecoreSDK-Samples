<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogList.ascx.cs" Inherits="layouts_SocialSDK_BlogList" %>
<div class="blogs">
    <ul class="blog-list">
        
        <asp:Repeater runat="server" ID="rptBlogs">
            <ItemTemplate>
                  <li class="blog-list-item">
            <h3 class="blog-name"><asp:HyperLink runat="server" ID="lnkBlogName"></asp:HyperLink></h3>
            <div class="blog-description">
               <asp:Literal runat="server" ID="litBody"></asp:Literal>
            </div>
            <div class="blog-meta">
                <ul class="blog-meta-list">
                    <li class="total-posts"><asp:Literal runat="server" ID="litTotalPosts"></asp:Literal></li>
                    <li class="last-post"><asp:Literal runat="server" ID="litLastPost"></asp:Literal></li>
                </ul>
            </div>
        </li>
            </ItemTemplate>
        </asp:Repeater>
   
</ul>

</div>
<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>