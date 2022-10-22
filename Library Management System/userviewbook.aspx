<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userviewbook.aspx.cs" Inherits="Library_Management_System.userviewbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<body style="background-color:lightcoral">
    <div class="container">
            <div class="row">
                <link href="datatables/css/jquery.dataTables.min.css" rel="stylesheet" />
                <script src="datatables/js/jquery.dataTables.min.js"></script>
                <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                <div class="col-sm-12">
                    <center>
                        <h3>
                        Book Inventory List</h3>
                    </center>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:user %>" ProviderName="<%$ ConnectionStrings:user.ProviderName %>" SelectCommand="SELECT [book_name], [genre], [author_name], [language], [edition], [book_descrpition] FROM [book]"></asp:SqlDataSource>
                    <br />
                    <div class="row">
                        <div class="card">
                            <div class="card-body">

                                <div class="row">
                                   
                                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                            <Columns>
                                                <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                                <asp:BoundField DataField="genre" HeaderText="genre" SortExpression="genre" />
                                                <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                                <asp:BoundField DataField="language" HeaderText="language" SortExpression="language" />
                                                <asp:BoundField DataField="edition" HeaderText="edition" SortExpression="edition" />
                                                <asp:BoundField DataField="book_descrpition" HeaderText="book_descrpition" SortExpression="book_descrpition" />
                                            </Columns>
                                         
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <center>
                    <a href="home.aspx" style="color:black">
                        << Back to Home</a><span class="clearfix"></span>
                            <br />
                            <center>
            </div>
        </div>
</body>
</asp:Content>

