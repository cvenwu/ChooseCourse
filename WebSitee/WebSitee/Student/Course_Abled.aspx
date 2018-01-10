<%@ Page Title="可选课程" EnableEventValidation="true" Language="C#" MasterPageFile="~/Student/Student.master" AutoEventWireup="true" CodeFile="Course_Abled.aspx.cs" Inherits="Student_Course_Abled" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="panel panel-default" style="margin-top: 5%;">
       <div class="panel-heading" >可选课程</div>
        <asp:GridView AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand"  class="table table-striped table-bordered" ID="Course1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" BorderWidth="1px">
            <RowStyle HorizontalAlign ="Center" VerticalAlign="Middle" />
            <Columns>
                <asp:BoundField DataField="cid" HeaderText="课程序号" Visible="False" />
                <asp:BoundField DataField="c_id" HeaderText="课程编号"  />
                <asp:BoundField DataField="ty_name" HeaderText="课程类别" />
                <asp:BoundField DataField="c_name" HeaderText="课程名称" />
                <asp:BoundField DataField="te_id" HeaderText="教师编号"/>
                <asp:BoundField DataField="te_name" HeaderText="教师名称" />
                <asp:BoundField DataField="c_score" HeaderText="课程学分" />
                <asp:BoundField DataField="c_time" HeaderText="课程学时" />
                <asp:BoundField DataField="c_number" HeaderText="课程总容量" />
                <asp:BoundField DataField="c_balannumber" HeaderText="课程剩余容量" />
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="选修" HeaderText="操作"  CommandName="Select" />
            </Columns>
        </asp:GridView>
    </div>  
    
</asp:Content>




