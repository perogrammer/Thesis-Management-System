<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanelView.aspx.cs" Inherits="ProjecFE.PanelView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thesis Viewer</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <style>
        body {
            background-color: #f8f9fa;
            font-family: Arial, sans-serif;
        }

        .container {
            margin-top: 50px;
        }

        .btn-action {
            margin-top: 10px;
        }

        .dropdown-container {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Thesis Information</h2>
            <!-- Add thesis details here based on your data -->

            <div class="dropdown-container">
                <label for="ddlThesisFiles">Select Thesis File:</label>
                <asp:DropDownList ID="ddlThesisFiles" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlThesisFiles_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            
            <div class="text-center mt-4">
                <a href="Evaluate.aspx" class="btn  btn-primary btn-action">Evaluate</a>
            </div>
            <asp:Label ID="lblFileContents" runat="server" Text=""></asp:Label>
        </div>

        <!-- Bootstrap and jQuery Scripts -->
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

       
    </form>
</body>
</html>
