<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Query.aspx.cs" Inherits="Query" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-header">
                  <asp:Label ID="lblRpt" runat="server" Text="Report Details for "></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed table-bordered" Font-Size ="10"></asp:GridView>
        </div>
        <div class="col-xs-12">
        </div>
    </div>
</asp:Content>
