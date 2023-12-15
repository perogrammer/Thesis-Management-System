<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupervisorReg.aspx.cs" Inherits="ProjecFE.SupervisorReg" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supervisor Registration</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <style>
        body {
            background-color: #f8f9fa;
        }

        .container {
            margin-top: 50px;
        }

        .card {
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .card-header {
            background-color: #007bff;
            color: #fff;
        }

        .btn-register {
            background-color: #28a745;
            color: #fff;
        }

        .btn-register:hover {
            background-color: #218838;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header text-center">
                            <h3>Supervisor Registration</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="txtUsername">Username:</label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="txtEmail">Email:</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="txtPassword">Password:</label>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="txtConfirmPassword">Confirm Password:</label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" />
                            </div>
                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-register btn-block" OnClick="btnRegister_Click" />
                             <div class="text-center mt-3">
                                 <span>Already have an account?</span>
                                 <a href="Supervisor_login.aspx" class="btn btn-login mb-1 align-middle p-0">Login</a>
                             </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Bootstrap and jQuery Scripts -->
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
         <script>
             function btnRegister_Click() {
                 // Retrieve input values
                 var username = document.getElementById('txtUsername').value;
                 var email = document.getElementById('txtEmail').value;
                 var password = document.getElementById('txtPassword').value;
                 var confirmPassword = document.getElementById('txtConfirmPassword').value;

                 // Validate input (add more validation as needed)
                 if (username === '' || email === '' || password === '' || confirmPassword === '') {
                     alert('Please fill in all fields.');
                     return;
                 }

                 if (password !== confirmPassword) {
                     alert('Password and Confirm Password do not match.');
                     return;
                 }

                 // Perform registration logic (this is a basic example)
                 alert('Registration successful!');

                 // Redirect to login page
                 window.location.href = 'PanelMemeberLogin.aspx';
             }
         </script>
    </form>
</body>
</html>
