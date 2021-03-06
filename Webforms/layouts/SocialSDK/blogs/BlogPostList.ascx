﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogPostList.ascx.cs" Inherits="layouts_SocialSDK_BlogPostList" %>
<div class="blog-posts">
    <h1>Blog Posts</h1>
    <ul class="blog-post-list list-unstyled">
        <asp:Repeater runat="server" ID="rptPosts">
            <ItemTemplate>
                <li class="blog-list-item">
                    <h3 class="post-name">
                        <asp:HyperLink runat="server" ID="lnkTitle"></asp:HyperLink></h3>

                    <div class="post-meta">
                        <ul class="meta list-inline">
                            <li class="post date">
                                <asp:Label runat="server" ID="lblPostDate" CssClass="post-date"></asp:Label>
                                by
                                <asp:Label runat="server" ID="lblAuthor" CssClass="post-author"></asp:Label></li>
                            <li class="total-posts">
                                <asp:Label runat="server" ID="lblViews"></asp:Label></li>
                            <li class="total-posts">
                                <asp:Label runat="server" ID="lblComments"></asp:Label></li>

                        </ul>
                    </div>
                    <p class="blog-description">
                        <asp:Literal runat="server" ID="litBody"></asp:Literal>
                    </p>
                </li>
            </ItemTemplate>
        </asp:Repeater>


    </ul>

</div>
<asp:Literal runat="server" ID="litError" Visible="false"></asp:Literal>