<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumThreadCreate.ascx.cs" Inherits="Forums_ForumThreadCreate" %>


<style>
    .thread-create-wrapper {width:600px;}
    .thread-create-wrapper .text-input {display:block;width:100%;}
    .thread-create-wrapper .submit-button {margin-left:auto; margin-right:0;}
</style>
<h2>Create Thread</h2>
<div class="thread-create-container">
    <div class="thread-create-wrapper">
        <asp:TextBox runat="server" ID="tbNewThreadSubject" CssClass="text-input"></asp:TextBox>
        <asp:TextBox runat="server" ID="tbNewThreadBody" TextMode="MultiLine" CssClass="text-input"></asp:TextBox>
        <asp:Button runat="server" ID="btnNewThreadAdd" Text="Post" CssClass="submit-button"></asp:Button>
    </div>

<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>
</div>