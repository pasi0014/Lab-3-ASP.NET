<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="Lab_3.AddCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <h1 id="title">Add New Courses</h1>
            <hr id="line">
            <div class="form-group">
                Course Number:
                <asp:TextBox runat="server" class="form-control" ID="courseNumber"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="courseNumber" ErrorMessage="*Required Number*" ForeColor="red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                Course Name:
                <asp:TextBox runat="server" CssClass="form-control" ID="courseName"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="courseName" ErrorMessage="*Required Name*" ForeColor="red"></asp:RequiredFieldValidator>
                </div>
            <asp:Button ID="submitCourseInfo" CssClass="btn btn-primary" runat="server" OnClick="submitCourseInfo_Click" Text="Submit Course Information" />
        </div>
        <br/>
        <div class="container">
            <h3>The Following courses are currently in the system:</h3>
            <asp:Table runat="server" ID="tblCourses" CssClass="table table-dark">
                <asp:TableRow>
                    <asp:TableHeaderCell><a href="AddCourse.aspx?sort=code">Course Code</a></asp:TableHeaderCell>
                    <asp:TableHeaderCell><a href="AddCourse.aspx?sort=title">Course Title</a></asp:TableHeaderCell>    
                </asp:TableRow>
            </asp:Table>
        </div>
</asp:Content>
