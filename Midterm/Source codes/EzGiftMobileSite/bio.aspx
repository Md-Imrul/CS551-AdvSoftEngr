<%@ Page Title="" Language="C#" MasterPageFile="~/common.master" AutoEventWireup="true" CodeFile="bio.aspx.cs" Inherits="Bio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Script" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div data-role="content">
        <div data-role="collapsible-set">
            <div data-role="collapsible">
                <h3>
                    Basics
                </h3>
				<div data-role="fieldcontain">
					<input name="" id="firstname" placeholder="First Name" value="" type="text">
				</div>
				<div data-role="fieldcontain">
					<input name="" id="lastname" placeholder="last name" value="" type="text">
				</div>
				<div data-role="fieldcontain">
					<input name="" id="dob" placeholder="date of birth" value="" type="date">
				</div>                
            </div>
            <div data-role="collapsible">
                <h3>
                    Contact
                </h3>
            </div>
        </div>
        <a data-role="button" href="#page1">
            Update
        </a>
        
    </div>
</asp:Content>

