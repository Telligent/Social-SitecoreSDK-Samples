<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumThreadList.ascx.cs" Inherits="Forums_ForumThreadList" %>
<%@ Import Namespace="System.Data" %>

<style>
    .thread-list-container h2{font-size:120%}
    .thread-list-container .thread-description{ font-style: italic;font-size: 85%;}
    .thread-list {border-collapse: separate; border-spacing: 2px; border-color: rgb(128, 128, 128);}
    .thread-list thead tr {border-bottom:solid 1px black;}
    .thread-list .thread-content {width:400px;}
    .new-thread-button {float:right;text-decoration: none;text-align: center;background: rgb(94, 180, 46);color: rgb(255, 255, 255);font-weight: 400;font-size: 13px;padding: 7px 30px;margin:10px}
</style>
<div class="thread-list-container">
<h2><asp:HyperLink runat="server" ID="lnkForumList"></asp:HyperLink> &raquo; <asp:Literal runat="server" ID="litForumName"></asp:Literal></h2>
<asp:HyperLink runat="server" ID="lnkThreadCreate" CssClass="new-thread-button"></asp:HyperLink>
<div class="forums-list-wrapper">
    <asp:Repeater runat="server" ID="rptForumThreads">
        <HeaderTemplate>
            <table class="thread-list">
                <thead>
                   <tr>
                       <th></th>
                       <th>Replies</th>
                       <th>Views</th>
                       <th>Last</th>
                   </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="thread-content">
                    <h3 class="thread-name"><asp:HyperLink runat="server" ID="lnkSubject"></asp:HyperLink></h3>
                    <div class="thread-description">
                        <asp:Literal runat="server" ID="litBody"></asp:Literal>
                    </div>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblReplies"></asp:Label>
                </td>
                 <td>
                    <asp:Label runat="server" ID="lblViews" CssClass=""></asp:Label>
                </td>
                 <td>
                    <asp:Label runat="server" ID="lblLast"></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>

<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>
</div>