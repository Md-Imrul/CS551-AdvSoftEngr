<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/common.master" CodeFile="home.aspx.cs" Inherits="home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> <title>Login</title> </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Script" runat="server"> </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" data-divider-theme="b" data-inset="true">
            <li data-role="list-divider" role="heading">
                My Profile
            </li>
            <li data-theme="c">
                <a href="bio.aspx" data-transition="slide">
                    Bio
                </a>
            </li>
            <li data-theme="c">
                <a href="friendlist.aspx" data-transition="slide">
                    Friends
                </a>
            </li>
            <li data-role="list-divider" role="heading">
                My Events
            </li>
            <li data-theme="c">
                <a href="wishlist.aspx" data-transition="slide">
                    My Wish List
                </a>
            </li>
            <li data-theme="c">
                <a href="events.aspx" data-transition="slide">
                    Upcoming Events
                </a>
            </li>
            <li data-role="list-divider" role="heading">
                Gifts
            </li>
            <li data-theme="c">
                <a href="mygifts.aspx" data-transition="slide">
                    Gifts I got
                </a>
            </li>
            <li data-theme="c">
                <a href="buygift.aspx" data-transition="slide">
                    Buy For Friend
                </a>
            </li>
        </ul>
    </div>
</asp:Content>