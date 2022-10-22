<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Library_Management_System.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <%--bootstrap css--%>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <%--datatables css--%>

     <%--fontawesome css--%>
    <link href="fontawesome/css/all.css" rel="stylesheet" />

        <%--our custom css--%>
    <link href="css/customstylesheet.css" rel="stylesheet" />

    <%--jquery--%>
    
    

    <script src="bootstrap/js/jquery-3.3.1.slim.min.js"></script>
    <%--popper js--%>
    <script src="bootstrap/js/popper.min.js"></script>
    <%--bootstrap js--%>
</head>
<body>


    
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <form id="form1" runat="server">
<div class="container">
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
                                    <label>Email ID:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Id is required" ForeColor="Red" ControlToValidate="email"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<asp:TextBox Cssclass="form-control" ID="email" runat="server" placeholder="Member ID "></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group"> 
                                    <label>Password:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is Required" ForeColor="Red" ControlToValidate="password"></asp:RequiredFieldValidator>
                                    </label>
                                    &nbsp;<asp:TextBox Cssclass="form-control" ID="password" runat="server" placeholder="Password " TextMode="Password"></asp:TextBox>
                                </div>
                                
 `                              <div class="form-group">
                                 <asp:Button ID="Button3" class="btn btn-primary  btn-block  " runat="server" Text="Log in" runat="server" value="" OnClick="Button3_Click"/>  </a> 
                                </div>  

                                 <div class="form-group">
                                <asp:Button ID="Button4" runat="server"  class="btn btn-info btn-block " Text="Sign up" runat="server"  value="" OnClick="Button4_Click"/>  </a> 
                                </div>  
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx">Back to home</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
