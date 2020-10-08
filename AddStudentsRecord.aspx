<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeBehind="AddStudentsRecord.aspx.cs" Inherits="Lab_3.AddStudentsRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
            <h1 class="title">Add Student Records</h1>
            <hr>
            <div class="form-group row mt-2" style="margin-top:30px;">
               <span class="col-sm-2 col-form-label" >Course: </span>
                <div class="col-sm-6 p-3">
                    <asp:DropDownList runat="server" class="form-control w-25" ID="courseSelection"  AutoPostBack="true" OnSelectedIndexChanged="courseSelection_SelectedIndexChanged">
                        <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row ">
                <span class="col-sm-2 col-form-label" >Student Number</span>
                <div class="col-sm-6 p-3">
                    <asp:TextBox runat="server" ID="studentNumber" class="form-control w-15"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="studentNumber" CssClass="error" ErrorMessage="*Field required*"/>
                </div>
            </div>
            <div class="form-group row">
                <span class="col-sm-2 col-form-label" >Student Name</span>
                <div class="col-sm-6 p-3">
                    <asp:TextBox runat="server" ID="studentName" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="studentName" ErrorMessage="*Field Required*" CssClass="error"/>
                </div>
            </div>
            <div class="form-group row">
                <span class="col-sm-2 col-form-label" >Grade</span>
                <div class="col-sm-6 p-3">
                    <asp:TextBox runat="server" ID="grade" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="grade" ErrorMessage="*Field Required*" CssClass="error"/>
                </div>
            </div>

            <div class="form-group row">
                <asp:Button runat="server" Text="Add Student Record" ID="btnAddstudentRecord" OnClick="btnAddstudentRecord_Click" class="btn btn-primary" />
            </div>

            <div class="form-group row">
                <h4>The selected course has the following student records:</h4>
            </div>

            <div class="form-group row">
                <asp:Table runat="server" ID="tblStudents" class="table table-dark">
                    <asp:TableRow>
                        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Grade</asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
         </div>
</asp:Content>
