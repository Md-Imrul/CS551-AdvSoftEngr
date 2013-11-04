<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/common.master" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> <title>Login</title> </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Script" runat="server"> 
    <script type="text/javascript">
        var base_url = "http://localhost:50275/Service1.svc";

        $(document).ready(function () {
            $('#login').bind("click", login_submit);
        });

        function login_submit() {
            //alert("test");
            var uname = $('#username').val();
            var pass = $('#password').val();
            if (uname == "" || pass == "") { alert("Username and password can not be empty"); return;}
            var cmp_url = base_url + "/login" + "/" + uname + "/" + pass;
            $.get(cmp_url, function (result) {
                //alert(result.errorCode);
                //var result = JSON.parse(JSON.stringify(result));
                //alert(result.errorCode);
                if (result.errorCode == 0) {
                    window.location.replace("/home.aspx");
                } else {
                    errorHandler(result.errorCode);
                }
            });            
        }

        function errorHandler(errorCode) {            
            if (errorCode == -1) {
                // html() and hidden functions not working!
                $('#error').html("Test");
                $('#error').hidden = "";
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">                        
    <div data-role="content">
        <div id="error"></div>
        <div data-role="fieldcontain">
            <input type="text" name="username" id="username" placeholder="ID" />
        </div>
        <div data-role="fieldcontain">
            <input type="password" name="password" id="password" placeholder="password"/>
        </div>
        <div data-role="fieldcontain">
            <button id="login" value="Login" >Login</button>
        </div>
		<div>
            <a id="signup" href="register.aspx" target="_blank" data-transition="fade">
                Sign Up
            </a>
        </div>
    </div>

</asp:Content>
