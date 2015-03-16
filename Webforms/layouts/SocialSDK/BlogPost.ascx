<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogPost.ascx.cs" Inherits="layouts_SocialSDK_BlogPost" %>
<div class="blog-post row">
    <div class="blog-post-header">
        <h2 class="post-title"><asp:Label runat="server" ID="lblTitle"></asp:Label></h2>
    </div>
    <div class="post-meta">
        <ul class="meta list-inline">
                    <li class="post date"><asp:Label runat="server" ID="lblPostDate" CssClass="post-date"></asp:Label> by <asp:Label runat="server" ID="lblAuthor" CssClass="author"></asp:Label></li>
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
      
        <ul class="comment-list list-unstyled">
            <asp:Repeater runat="server" ID="rptComments">
                <ItemTemplate>
                     <li class="comment-list-item">
                    <div class="comment-header">
                        <ul class="meta list-inline">
                            <li class="author"><asp:Label runat="server" ID="lblAuthor"></asp:Label></li>
                            <li class="post-date"><asp:Label runat="server" ID="lblDate"></asp:Label></li>
                        </ul>
                    </div>
                  <p>
                      <asp:Literal runat="server" ID="litBody"></asp:Literal>
                  </p>
                </li>
                </ItemTemplate>
            </asp:Repeater>
               
            
        </ul>
    </div>
<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>