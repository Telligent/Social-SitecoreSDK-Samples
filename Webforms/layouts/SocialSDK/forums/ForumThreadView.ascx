<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumThreadView.ascx.cs" Inherits="Forums_ForumThreadView" %>
<%@ Import Namespace="System.Data" %>




    <h1>
        <asp:HyperLink runat="server" ID="lnkForum"></asp:HyperLink>
        &raquo;
        <asp:Literal runat="server" ID="litThreadSubject"></asp:Literal></h1>
<asp:Literal runat="server" ID="litStatus" Visible ="false"></asp:Literal>
    <div class="thread rounded bold-round">
        <ul class="post-author meta list-inline">
            <li>
                <asp:Image runat="server" ID="imgThreadAuthorAvatar" Height="50" Width="50"></asp:Image></li>
            <li class="author">
                <asp:Label runat="server" ID="lblThreadAuthorName"></asp:Label></li>
            <li class="post-date">Posted:
                <asp:Label runat="server" ID="lblThreadPostDate"></asp:Label>
            </li>

        </ul>

        <p class="user-defined-markup post-body">
            <asp:Literal runat="server" ID="litThreadBody"></asp:Literal>
        </p>
    </div>
   <hr/>
    <div class="view-thread">
        <asp:Repeater runat="server" ID="rptReplies">

            <ItemTemplate>
                <asp:Panel CssClass="reply rounded" id="divReplyContainer" runat="server">
                    <ul class="post-author meta list-inline">

                                <li class="author"><asp:Label runat="server" ID="lblAuthorName"></asp:Label></li>
                                <li class="post-date">
                                   Posted:
                                            <asp:Label runat="server" ID="lblPostDate"></asp:Label>
                                </li>
      
            </ul>
                   
                    <p class="user-defined-markup post-body">
                        <asp:Literal runat="server" ID="litBody"></asp:Literal>
                    </p>
                </asp:Panel>
            </ItemTemplate>
        
        </asp:Repeater>
        <div class="reply-to">
            <div class="form-group">
                 <asp:TextBox runat="server" ID="tbNewReplyBody" TextMode="MultiLine" CssClass="text-input form-control"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnNewReplyAdd" Text="Reply" CssClass="submit-button btn btn-default"></asp:Button>
        </div>
    </div>


<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>
