<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumThreadView.ascx.cs" Inherits="Forums_ForumThreadView" %>
<%@ Import Namespace="System.Data" %>

<style>
    div.thread, div.reply{border:1px solid #333; width:600px;margin-bottom:10px;}
    table.post-author-details{margin-bottom:5px;}
    div.post-author{padding:3px;background-color:#dcdcdc}
</style>
<div class="thread-list-container">
<h2><asp:HyperLink runat="server" ID="lnkForum"></asp:HyperLink> &raquo; <asp:Literal runat="server" ID="litThreadSubject"></asp:Literal></h2>
<div class="forums-list-wrapper">
    <div class="thread">
        <div class="post-author">
            <table class="post-author-details">
                <tbody>
                    <tr>
                        <td class="post-author-avatar"><asp:Image runat="server" ID="imgThreadAuthorAvatar" Height="50" Width="50"></asp:Image></td>
                        <td class="post-user">
                            <span><asp:Label runat="server" ID="lblThreadAuthorName"></asp:Label></span>
                            <div class="post-date">
                                Posted: <asp:Label runat="server" ID="lblThreadPostDate"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="user-defined-markup post-body">
            <asp:Literal runat="server" ID="litThreadBody"></asp:Literal>
        </div>
    </div>
    <div class="view-thread">
        <asp:Repeater runat="server" ID="rptReplies">
            <HeaderTemplate>
                <div class="reply-list">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="reply">
                    <div class="post-author">
                        <table class="post-author-details">
                            <tbody>
                                <tr>
                                    <td class="post-author-avatar"><asp:Image runat="server" ID="imgAuthorAvatar" Height="50" Width="50"></asp:Image></td>
                                    <td class="post-user">
                                        <span><asp:Label runat="server" ID="lblAuthorName"></asp:Label></span>
                                        <div class="post-date">
                                            Posted: <asp:Label runat="server" ID="lblPostDate"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="user-defined-markup post-body">
                        <asp:Literal runat="server" ID="litBody"></asp:Literal>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>

<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>
</div>