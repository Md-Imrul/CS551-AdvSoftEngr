<%@ Page Title="" Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Script" Runat="Server">
    <script type="text/javascript">
        var base_url = "http://localhost:50275/Service1.svc";

        $(document).ready(function () {
            $('#signup').bind("click", register_submit);
        });

        function register_submit() {
            //alert("test");            
            var uname = $('#username').val();
            var pass = $('#password').val();
            var confirm = $('#repassword').val();
            var email = $('#email').val();
            if (pass != confirm) {
                alert("Passwords didn't match!");
                $('#username').val("");
                $('#password').val("");
                return;
            }
            
            var cmp_url = base_url + "/register" + "/" + uname + "/" + pass + "/" + email;
            $.get(cmp_url, function (result) {
                //alert(result.errorCode);
                //var result = JSON.parse(JSON.stringify(result));
                //alert(result.errorCode);
                if (result.errorCode == 0) {
                    alert("Registered Successfully!");
                    window.location.replace("/home.aspx");
                } else {
                    //errorHandler(result.errorCode);
                }
            });            
            
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div data-role="content">
        <h3>
            Create your own account!
        </h3>
        <div data-role="fieldcontain">
            <input name="ID" id="username" placeholder="ID" value="" type="text">
        </div>
        <div data-role="fieldcontain">
            <input name="password" id="password" placeholder="password" type="password"/>
        </div>
        <div data-role="fieldcontain">
            <input name="repassword" id="repassword" placeholder="retype password" type="password"/>
        </div>
        <div data-role="fieldcontain">
            <input name="email" id="email" placeholder="Email" type="email"/>
        </div>
        <input id="signup" value="Sign Up" type="submit" />
    </div>
</asp:Content>

