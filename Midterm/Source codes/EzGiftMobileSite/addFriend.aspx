<%@ Page Title="" Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="addFriend.aspx.cs" Inherits="addFriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Script" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            // bind "ENTER" button with search event
            /*
            $('#q').keypress(function (event) {                
                var code = event.keyCode || event.which;
                if (code == 13) {
                    search_process(); 
                }
            });
            */
            $('#search').bind("click", search_process);
            //load jtable
            loadTable();
        });
        function search_process() {
            var base_url = "http://localhost:50275/Service1.svc";
            
            var cmp_url = base_url + "/searchUser" + "/" + $('#q').val();

            $.get(cmp_url, function (result) {
                //alert(result.Records[0].UserName);
                //{"Records":[{"Email":"rasool@email.com","UserId":103,"UserName":"rasool"}],"Result":"OK"}
                var link = '<a id="addFriend" data-role="button" href="' + base_url + '/addfriend/102/' 
                    + result.Records[0].UserId + '" data-icon="plus" data-iconpos="left" data-inline="true">Add</a>';
                $('#UserTableContainer').jtable('addRecord', {
                    clientOnly: 'true' ,
                    record: {
                        UserId: result.Records[0].UserId,
                        UserName: result.Records[0].UserName,
                        Email: result.Records[0].Email,
                        Add: link
                    }                    
                    
                });
            });
        }

        function loadTable() {
            $('#UserTableContainer').jtable({
                title: 'Users',
                actions: {
                    //listAction: base_url + '/friendList/102',
                    //createAction: '/addFriend.aspx',
                    //updateAction: '/GettingStarted/UpdatePerson',
                    //deleteAction: '/removefriend/102/'
                },
                fields: {
                    UserId: {
                        key: true,
                        list: false
                    },
                    UserName: {
                        title: 'User Name',
                        width: '40%'
                    },
                    Email: {
                        title: 'Email',
                        width: '20%'
                    },
                    Add: {
                        title: '#',
                        width: '10%'                        
                    }   
                }
            });

            //Load student list from server
           // $('#FriendTableContainer').jtable('load');
        }
            
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div data-role="content">
        <div data-role="fieldcontain">
            <input name="search" id="q" placeholder="Friend Name" value="" data-mini="true"
            type="search" />
            <button id="search">Search</button>
        </div>
        
        <div id="UserTableContainer"></div>
    </div>
    <div>Issues:<ul>
        <li>If you can't see a table, please refresh the page.</li>
        <li>While clicking the 'Add' link adds the person as friend of the user, it should give a success message. Instead it directing to another page. </li>        
         </ul>
    </div>
</asp:Content>

