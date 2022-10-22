<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="Library_Management_System.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    
                    <div class="card-body">
                        
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h5>Author details</h5>
                                    
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/writer.png" width="100"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                 <label>Author Id:</label>
                                <div class="input-group">
                                    <asp:TextBox Cssclass="form-control" ID="TextBox3" runat="server" placeholder="ID "></asp:TextBox>
                                    
                                </div>
                                
                                    
                            </div>
                            <div class="col-md-6">
                               <label>Author Name:</label>
                                    <asp:TextBox Cssclass="form-control" ID="name" runat="server" placeholder="name " TextMode="SingleLine"></asp:TextBox>  
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-4">
                               <hr /> 
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button3" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Button3_Click" />
                            </div>
                               <div class="col-4">
                                <asp:Button ID="Button5" runat="server" Text="Update" CssClass="btn btn-success" OnClick="Button5_Click" />
                            </div>
                               <div class="col-4">
                                <asp:Button ID="Button6" runat="server" Text="Delete" CssClass="btn btn-warning" OnClick="Button6_Click" />
                            </div>
                        </div>
                         

                         
                        
                        
                        <div class="row">
                            <div class="col-4">
                                
                            </div>
                        </div>
                        
                    </div>
                </div>
                <a href="homepage.aspx">Back to home</a>
            </div>
            <div class="col-md-6 mx-auto">
                <div class="card">
                    
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h4>Author list</h4> 
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                       
                       <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" OnSelecting="SqlDataSource1_Selecting" ConnectionString="<%$ ConnectionStrings:user %>" ProviderName="<%$ ConnectionStrings:user.ProviderName %>" SelectCommand="SELECT * FROM [author]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-dark table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_Id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_Id" HeaderText="author_Id" ReadOnly="True" SortExpression="author_Id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                    </Columns>
                                </asp:GridView>
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
