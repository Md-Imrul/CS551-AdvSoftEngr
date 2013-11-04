<%@ Page Title="" Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="friendlist.aspx.cs" Inherits="friendlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Script" Runat="Server">
    <script type="text/javascript">
        var base_url = "http://localhost:50275/Service1.svc";
        $(document).ready(function () {
            loadTable();
            $('#addfriend').bind("click", addFriend_Process);
        });
        function loadTable() {
            $('#FriendTableContainer').jtable({
                title: 'My Friends',
                actions: {
                    listAction: base_url + '/friendList/102',
                    createAction: '/addFriend.aspx',
                    //updateAction: '/GettingStarted/UpdatePerson',
                    deleteAction: '/removefriend/102/'
                },
                fields: {
                    FriendId: {
                        key: true,
                        list: false
                    },
                    UserName: {
                        title: 'Friend Name',
                        width: '40%'
                    },
                    Email: {
                        title: 'Email',
                        width: '20%'
                    }
                    /*,
                    RecordDate: {
                        title: 'Record date',
                        width: '30%',
                        type: 'date',
                        create: false,
                        edit: false
                    }*/
                }
            });

            //Load student list from server
            $('#FriendTableContainer').jtable('load');
        }
        function addFriend_Process() {
            alert("test");
        }
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="FriendTableContainer"></div>
    <a id="addFriend" data-role="button" href="addfriend.aspx" data-icon="plus" 
        data-iconpos="left" data-inline="true">
        Add Friend
    </a>
    <div>Issues: <ul>
        <li>If you can't see a table, please refresh the page.</li>
        <li>As there are some bugs in SQL to retrieve the friend list, the above table is filled with dummy data.</li>
         </ul>
    </div>
</asp:Content>

