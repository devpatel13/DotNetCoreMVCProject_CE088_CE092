<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="Library_Management_System.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lf-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/adminuser.png" width="175"/>
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Admin login</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group"> 
                                    <label>Admin ID:</label>
                                    <asp:TextBox Cssclass="form-control" ID="adminidTextBox" runat="server" placeholder="Admin ID "></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group"> 
                                    <label>Password:</label>
                                    <asp:TextBox Cssclass="form-control" ID="passTextBox" runat="server" placeholder="Password " TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="Button1" class="btn btn-primary btn-block btn-lg" runat="server" Text="Log in" OnClick="Button_Click1"/>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx">Back to home</a>
            </div>
        </div>
    </div>
</asp:Content>
