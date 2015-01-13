<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumList.ascx.cs" Inherits="Forums_ForumList" %>
<%@ Import Namespace="System.Data" %>

<style>
    .forum-list-container h2{font-size:120%}
    .forum-list-container .forum-description{ font-style: italic;font-size: 85%;}
</style>
<div class="forum-list-container">
<h2>Forums</h2>
<div class="forums-list-wrapper">
    <asp:Repeater runat="server" ID="rptForums">
        <HeaderTemplate>
            <table class="forum-list">
                <thead>
                   <tr>
                       <th>Name</th>
                       <th>Threads</th>
                       <th>Replies</th>
                       <th>Last</th>
                   </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <h3 class="forum-name"><asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></h3>
                    <div class="forum-description">
                        <asp:Literal runat="server" ID="litDescription"></asp:Literal>
                    </div>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblThreads"></asp:Label>
                </td>
                 <td>
                    <asp:Label runat="server" ID="lblReplies" CssClass=""></asp:Label>
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