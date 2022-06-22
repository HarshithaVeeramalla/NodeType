<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserName._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
       
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            
            <asp:Label ID="lblUserInfo" runat="server" Text="Label"></asp:Label>
        </div>
       
    </div>

</asp:Content>
