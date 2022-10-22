<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="Library_Management_System.adminbookissuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body style="background-color:lightcoral">
    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    
                    <div class="card-body">
                        
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h5>Book issuing</h5>
                                    
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/books.png" width="100"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                           
                            <div class="col-md-6">
                               <label>Member ID:</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox2" runat="server" placeholder="Member ID" TextMode="SingleLine"></asp:TextBox>  
                            </div>
                             <div class="col-md-6">
                                 <label>Book Id:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                 </label>&nbsp;<div class="form-group">
                                     <div class="input-group">
                                    <asp:TextBox Cssclass="form-control" ID="TextBox3" runat="server" placeholder="Book ID "></asp:TextBox>
                                    <asp:Button ID ="Button4" runat="server" Text="Fill Deatails" class="btn btn-primary" OnClick="Button4_Click1" CausesValidation="False"/>
                                     </div> 
                                </div>
                                
                            </div>
                        </div>
                        <div class="row">
                           
                            <div class="col-md-6">
                               <label>Member Name:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox1" runat="server" placeholder="Member Name " TextMode="SingleLine" ReadOnly="True"></asp:TextBox>  
                            </div>
                            <div class="col-md-6">
                               <label>Book Name:</label>
                                    <asp:TextBox Cssclass="form-control" ID="TextBox4" runat="server" placeholder="Book Name " TextMode="SingleLine" ReadOnly="True"></asp:TextBox>  
                            </div> 
                                
                            </div>
                        <div class="row">
                           
                            <div class="col-md-6">
                               <label>Start Date:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox5" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </label>
                                    &nbsp;<asp:TextBox Cssclass="form-control" ID="TextBox5" runat="server" placeholder="Member Name " TextMode="Date" ReadOnly="False"></asp:TextBox>  
                            </div>
                            <div class="col-md-6">
                               <label>End date:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox6" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </label>
                                    &nbsp;<asp:TextBox Cssclass="form-control" ID="TextBox6" runat="server" placeholder="Book Name " TextMode="Date" ReadOnly="False"></asp:TextBox>  
                            </div> 
                                
                            </div>
                         <div class="row">
                            <div class="col-4">
                               <hr /> 
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-6"><center><asp:Button ID="Button3" runat="server" Text="Issue" CssClass="btn btn-primary" OnClick="Button3_Click" /></center>
                                
                            </div>
                               <div class="col-6"><center><asp:Button ID="Button5" runat="server" Text="Return" CssClass="btn btn-success" OnClick="Button5_Click" /></center>
                                
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
            <div class="col-md-7 mx-auto">
                <div class="card">
                    
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h4>Issued Book List</h4> 
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                       
                       <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:user %>" ProviderName="<%$ ConnectionStrings:user.ProviderName %>" SelectCommand="SELECT * FROM [book_issue]"></asp:SqlDataSource>
                                <asp:GridView CssClass="table table-dark table-bordered" ID="GridView1" runat="server"  AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDatasource1" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" InsertVisible="False" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="member_name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                        <asp:BoundField DataField="issue_date" HeaderText="issue_date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
 </body>
</asp:Content>
