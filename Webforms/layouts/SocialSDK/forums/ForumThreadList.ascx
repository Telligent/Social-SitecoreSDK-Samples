<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumThreadList.ascx.cs" Inherits="Forums_ForumThreadList" %>
<%@ Import Namespace="System.Data" %>


<div class="thread-list-container">
<h2><asp:HyperLink runat="server" ID="lnkForumList"></asp:HyperLink> &raquo; <asp:Literal runat="server" ID="litForumName"></asp:Literal></h2>
<asp:HyperLink runat="server" ID="lnkThreadCreate" CssClass="new-thread-button btn btn-primary"></asp:HyperLink>

    <asp:Repeater runat="server" ID="rptForumThreads">
        <HeaderTemplate>
            <table class="thread-list table table-bordered">
                <thead>
                   <tr>
                       <th>Subject</th>
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
                   
                </td>
                <td>
                    <asp:Label runat="server" ID="lblReplies"></asp:Label>
                </td>
                 <td>
                    <asp:Label runat="server" ID="lblViews" CssClass=""></asp:Label>
                </td>
                 <td>
                     <ul class="list-unstyled">
                           <li class="author"><asp:Label runat="server"  ID="lblAuthor"></asp:Label></li>
                         <li><asp:Label runat="server" ID="lblLast"></asp:Label></li>
                     </ul>
                    
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
