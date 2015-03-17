<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumList.ascx.cs" Inherits="Forums_ForumList" %>
<%@ Import Namespace="System.Data" %>

<h1>Forums</h1>


    <asp:Repeater runat="server" ID="rptForums">
        <HeaderTemplate>
            <table class="forum-list table table-bordered">
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


<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>
