<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Student_index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="panel panel-default" style="margin-top: 5%;">
       <div class="panel-heading" >全部课程</div>
        <asp:GridView class="table table-striped table-bordered" ID="Course1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" BorderWidth="1px"></asp:GridView>
    </div>



  <!--
      
      
      <nav aria-label="Page navigation">
  <ul class="pagination">
    <li>
      <a href="#" aria-label="Previous">
        <span aria-hidden="true">&laquo;</span>
      </a>
    </li>
    <li><a href="#">上一页</a></li>
    <li><a href="#">当前页数</a></li>
    <li><a href="#">下一页</a></li>
    <li><a href="#">末页</a></li>
    <li>
      <a href="#" aria-label="Next">
        <span aria-hidden="true">&raquo;</span>
      </a>
    </li></ul>
  
</nav>
      
      
      -->
</asp:Content>



