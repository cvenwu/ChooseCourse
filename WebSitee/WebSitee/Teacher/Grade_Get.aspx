<%@ Page Title="成绩查询-教师" Language="C#" MasterPageFile="~/Teacher/Teacher.master" AutoEventWireup="true" CodeFile="Grade_Get.aspx.cs" Inherits="Teacher_Grade_Get" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="panel panel-default" style="margin-top: 5%;">
       <div class="panel-heading" >成绩查询</div>
        <asp:GridView class="table table-striped table-bordered" ID="Grade1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" BorderWidth="1px"></asp:GridView>
    </div>
</asp:Content>

