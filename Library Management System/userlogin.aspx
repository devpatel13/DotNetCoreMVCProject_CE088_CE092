<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="Library_Management_System.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body style="background-color:lightcoral">
        <div class="container" >
        <div class="row">
            <div class="col-lf-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="175"/>
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h4>member login</h4>
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
                                    <label>Email ID:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email" ErrorMessage="Please enter the userID" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<asp:TextBox Cssclass="form-control" ID="email" runat="server" placeholder="Member ID "></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group"> 
                                    <label>Password:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" ErrorMessage="Please enter the Password" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<asp:TextBox Cssclass="form-control" ID="password" runat="server" placeholder="Password " TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="Button1" class="btn btn-primary btn-block btn-lg" runat="server" Text="Log in" OnClick="Button1_Click" />
                                </div>
                                 <div class="form-group">
                                <a href="usersignup.aspx">   <input ID="Button2" class="btn btn-info btn-block btn-lg" type="button" runat="server" value="Sign up" /></a> 
                                </div>  
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx" style="color:black">Back to home</a>
            </div>
        </div>
    </div>
    </body>
</asp:Content>
