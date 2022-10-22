<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="Library_Management_System.adminpublisher" %>
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
                                    <h5>Publisher details</h5>
                                    
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/publisher.png" width="100"/>
                                    
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                 <label>Publisher Id:</label>
                                <div class="input-group">
                                    <asp:TextBox Cssclass="form-control" ID="TextBox3" runat="server" placeholder="ID "></asp:TextBox>
                                   
                                </div>
                                
                                    
                            </div>
                            <div class="col-md-6">
                               <label>Publisher Name:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox2" runat="server" placeholder="name " TextMode="SingleLine"></asp:TextBox>  
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
                           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:user %>" ProviderName="<%$ ConnectionStrings:user.ProviderName %>" SelectCommand="SELECT * FROM [publisher]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-dark table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_Id" DataSourceID="SqlDataSource2">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_Id" HeaderText="publisher_Id" ReadOnly="True" SortExpression="publisher_Id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                    </Columns>
                                </asp:GridView>
                              
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        
    </div>
</asp:Content>
