<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.master" AutoEventWireup="true" CodeFile="College_Get.aspx.cs" Inherits="Student_College_Get" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="panel panel-default" style="margin-top: 5%;">
       <div class="panel-heading" >院级查询</div>
        <asp:GridView class="table table-striped table-bordered" ID="Course1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" BorderWidth="1px">
        </asp:GridView>
    </div>
</asp:Content>

