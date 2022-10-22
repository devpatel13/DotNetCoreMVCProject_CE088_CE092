<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="Library_Management_System.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex-preferred-size: 0;
            flex-basis: 0;
            -ms-flex-positive: 1;
            flex-grow: 1;
            max-width: 100%;
            top: 4px;
            left: -3px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style2 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 50%;
            flex: 0 0 50%;
            max-width: 50%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body style="background-color:lightcoral">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="100"/>
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h5>Your profile</h5>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                 <label>Full name:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox3" runat="server" placeholder="Full name "></asp:TextBox>
                            </div>
                            <div class="auto-style2">
                               <label>Date of birth:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox2" runat="server" placeholder="Password " TextMode="Date"></asp:TextBox>  
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                 <label>Contact Number:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox1" runat="server" placeholder="Contact Number " TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                               <label>Email ID:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox4" runat="server" placeholder="Email ID "></asp:TextBox>  
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                 <label>State:</label>
                                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                    <asp:ListItem Text="Select" Value="select" ReadOnly="True"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                               <label>City:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox6" runat="server" placeholder="City " TextMode="SingleLine" ReadOnly="False"></asp:TextBox>  
                            </div>
                             <div class="col-md-4">
                                 Pin code<label>:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox7" runat="server" placeholder="Pin code "></asp:TextBox>  
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                                <asp:TextBox class="form-control" ID="TextBox5" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="auto-style1">
                                <center>
                                    <hr>
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col"><center>
                                <span class="badge badge-info">Login credentials</span>
                                             </center>
                                
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                 <label>User Id:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox8" runat="server" placeholder="user Id " ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                               <label>Password:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox9" runat="server" placeholder="Password " TextMode="SingleLine" ReadOnly="True"></asp:TextBox>  
                            </div>
                            <div class="col-md-4">
                               <label>New Password:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox10" runat="server" placeholder="Password "></asp:TextBox>  
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group"> 
                                   
                                </div>
                               
                                 <div class="form-group"><center>
                                                                     <a href="usersignup.aspx">   
                                                                     <asp:Button ID="Button3" runat="server" Text="update"  class="btn btn-primary" value="Update" OnClick="Button3_Click" />
                                                                     

                                                         </center>
                                </div>  
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx">Back to home</a>
            </div>
            <div class="col-md-7 mx-auto">
                <div class="card">
                    
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/books1.png" width="100"/> 
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h5>Your issued books
                                    </h5>
                                    
                                </center>
                            </div>
                        </div>
                       
                      <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:user %>" ProviderName="<%$ ConnectionStrings:user.ProviderName %>" SelectCommand="SELECT [member_id], [book_id], [book_name], [due_date] FROM [book_issue]"></asp:SqlDataSource>
                                <asp:GridView CssClass="table table-dark table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False"  OnRowDataBound="GridView1_RowDataBound" >
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                        <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
                                    </Columns>
                                </asp:GridView>
                              
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group"> 
                                   
                                </div>
                               
                                 <div class="form-group"><center>
                                                                     <a href="usersignup.aspx">   <input ID="Button1" class="btn btn-primary " type="button" runat="server" value="Update" /></a> 

                                                         </center>
                                </div>  
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        
    </div>
                                                                     </a>
        </body>
        </asp:Content>
