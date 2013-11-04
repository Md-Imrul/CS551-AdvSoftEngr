<%@ Page Title="" Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="wishlist.aspx.cs" Inherits="wishlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Script" Runat="Server">
    <script type="text/javascript">
        var base_url = "http://localhost:50275/Service1.svc";
        $(document).ready(function () {
            loadTable();
            //$('#addfriend').bind("click", addFriend_Process);
        });
        function loadTable() {
                $('#ItemTableContainer').jtable({
                    title: 'Wish List',
                    actions: {
                        listAction: base_url + '/wishlist/102',
                        //createAction: '/addFriend.aspx',
                        //updateAction: '/GettingStarted/UpdatePerson',
                        //deleteAction: '/removefriend/102/'
                    },
                    fields: {
                        ItemId: {
                            key: true,
                            list: false
                        },
                        UserId: {
                            list: false
                        },
                        Upc: {
                            title: 'Code',
                            width: '20%'
                        },

                        Description: {
                            title: 'Decription',
                            width: '40%'
                        },
                        
                    }
                });

                //Load student list from server
                $('#ItemTableContainer').jtable('load');
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="ItemTableContainer"></div>    
    <div data-role="collapsible-set">
            <div data-role="collapsible" data-collapsed="true">
                <h3>
                    Add Item in wish list
                </h3>
                <div data-role="fieldcontain">
                    <input name="" id="searchinput1" placeholder="Barcode" value="" type="search">
                </div>                
                <div data-role="fieldcontain">
                    <label for="textarea1">
                        Description
                    </label>
                    <textarea name="" id="textarea1" placeholder=""></textarea>
                </div>
                <input value="Add" type="submit">
            </div>
        </div>
    <div>Issues:<ul>
        <li>If you can't see a table, please refresh the page.</li>
        <li>The 'Add Wish Item' is based on search by barcode in UPC-Database, it's not implemented yet.</li>        
         </ul>
    </div>
</asp:Content>

