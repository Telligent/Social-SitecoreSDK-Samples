<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumThreadCreate.ascx.cs" Inherits="Forums_ForumThreadCreate" %>



<h2>Create Thread</h2>

        <div class="form-group">
        <asp:Label runat="server"  AssociatedControlID="tbNewThreadSubject" Text="Subject"></asp:Label>
        <asp:TextBox runat="server" ID="tbNewThreadSubject" CssClass="text-input form-control"></asp:TextBox>
        </div>
        <div class="form-group">
        <asp:Label runat="server"  Text="Body" AssociatedControlID="tbNewThreadBody"></asp:Label>
        <asp:TextBox runat="server" ID="tbNewThreadBody" TextMode="MultiLine" CssClass="text-input form-control"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="btnNewThreadAdd" Text="Post" CssClass="submit-button btn btn-primary"></asp:Button>


<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>
