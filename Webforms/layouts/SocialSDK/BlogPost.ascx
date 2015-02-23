<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogPost.ascx.cs" Inherits="layouts_SocialSDK_BlogPost" %>
<div class="blog-post">
    <div class="blog-post-header">
        <h1 class="post-title"><asp:Label runat="server" ID="Label1"></asp:Label></h1>
    </div>
    <div class="post-meta">
        <ul class="post-meta-list">
                    <li class="post date"><asp:Label runat="server" ID="lblPostDate" CssClass="post-date"></asp:Label> by <asp:Label runat="server" ID="lblAuthor" CssClass="post-author"></asp:Label></li>
                    <li class="total-posts"><asp:Label runat="server" ID="lblViews"></asp:Label></li>
                    <li class="total-posts"><asp:Label runat="server" ID="lblComments"></asp:Label></li>
                    
                </ul>
    </div>
    <div class="blog-post-body user-generated-content">
        <asp:Literal runat="server" ID="litBody"></asp:Literal>
    </div>

</div>

    <div class="comments">
        <h3>Comments</h3>
      
        <ul class="comment-list">
            <asp:Repeater runat="server" ID="rptComments">
                <ItemTemplate>
                     <li>
                    <div class="comment-header">
                        <ul class="comment-meta">
                            <li class="author"><asp:Label runat="server" ID="lblAuthor"></asp:Label></li>
                            <li class="post-date"><asp:Label runat="server" ID="lblDate"></asp:Label></li>
                        </ul>
                    </div>
                  <div>
                      <asp:Literal runat="server" ID="litBody"></asp:Literal>
                  </div>
                </li>
                </ItemTemplate>
            </asp:Repeater>
               
            
        </ul>
    </div>
<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>