<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/Teacher.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Student_index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="panel panel-default" style="margin-top: 5%;">
       <div class="panel-heading" >全部课程</div>
        <asp:GridView class="table table-striped table-bordered" ID="Course1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" BorderWidth="1px"></asp:GridView>
    </div>
</asp:Content>



