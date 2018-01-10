<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.master" AutoEventWireup="true" CodeFile="System_Get.aspx.cs" Inherits="Student_System_Get" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    

    <div class="panel panel-default" style="margin-top: 5%;">
        <div class="row">
            <asp:TextBox runat="server" ID="CollogeToSearch" CssClass="col-lg-8 form-control" style="position: relative; left: 15px;"/>
          <div class="col-lg-4">
              <asp:Button runat="server" OnClick="SearchCollege" Text="查询" CssClass="form-control btn btn-primary "/>
          </div>    
        </div>
       <div class="panel-heading" >系部查询</div>
        <asp:GridView class="table table-striped table-bordered" ID="System1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" BorderWidth="1px">
        </asp:GridView>
    </div>
</asp:Content>

