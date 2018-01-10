<%@ Page Title="开办课程-教师" Language="C#" MasterPageFile="~/Teacher/Teacher.master" AutoEventWireup="true" CodeFile="Course_Add.aspx.cs" Inherits="Teacher_Course_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="panel panel-primary" style="margin-top: 5%;">
      <div class="panel-heading">开办课程登记</div>
      <div class="input-group" style="margin-top: 1%">
        <span class="input-group-addon" id="sizing-addon1">课程编号</span>
         <asp:TextBox ID="CourseId" CssClass="form-control" TextMode="SingleLine" runat="server" Width="1938px"></asp:TextBox>
      </div>
      <div class="input-group">
        <span class="input-group-addon" id="sizing-addon1">课程类别</span>
         <asp:DropDownList ID="CourseType" runat="server">
         </asp:DropDownList>
      </div>
      <div class="input-group">
        <span class="input-group-addon" id="sizing-addon1">课程名称</span>
        <asp:TextBox ID="CourseName" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
      </div>
      <div class="input-group">
        <span class="input-group-addon" id="sizing-addon1">课程学分</span>
         <asp:TextBox ID="CourseScore" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
      </div>
      <div class="input-group">
        <span class="input-group-addon" id="sizing-addon1">课程课时</span>
         <asp:TextBox ID="CourseTime" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
      </div>
      <div class="input-group">
        <span class="input-group-addon" id="sizing-addon1">课程容量</span>
         <asp:TextBox ID="CourseNumber" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
      </div>
        <asp:Button CssClass="btn btn-primary btn-lg" runat="server" Width="100%" Text="登记" OnClick="AddCourse"></asp:Button>
      

    <!--<table class="table table-striped">
          <tr>
              <td>课程编号</td>
              <td></td>
          </tr>   
          <tr>
              <td>课程种类</td>
              <td></td>
          </tr> 
          <tr>
              <td></td>
              <td></td>
          </tr> 
      </table>-->
    </div>
</asp:Content>

