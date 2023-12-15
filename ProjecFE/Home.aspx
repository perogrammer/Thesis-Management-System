<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjecFE.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thesis Management System</title>
    <style>
        body {
            background-image: url('your-background-image-url');
            background-size: cover;
            background-position: center;
            color: #fff;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        .navbar {
            background-color: #333;
            overflow: hidden;
        }

        .navbar a {
            float: left;
            display: block;
            color: #f2f2f2;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

        .navbar a:hover {
            background-color: #ddd;
            color: black;
        }

        .navbar .logo {
            float: left;
            display: block;
            padding: 14px 16px;
            text-decoration: none;
        }

        .navbar .right-links {
            float: right;
        }

        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 80vh;
        }

        .card {
            background-color: rgba(0, 0, 0, 0.7);
            padding: 20px;
            border-radius: 10px;
            text-align: center;
        }

        h1 {
            margin-bottom: 30px;
        }

        .role-button {
            margin: 10px;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
            background-color: #941b0c;
            color: #fff;
            border: none;
            border-radius: 5px;
        }

        .role-button:hover {
            background-color: #6c1308;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <h1>Welcome to the Thesis Management System</h1>
                <a href="WebForm1.aspx" class="role-button">Student </a>
                <a href="PanelMemeberLogin.aspx" class="role-button">Panel Member</a>
                <a href="Supervisor_login.aspx" class="role-button">Supervisor</a>
                <a href="AdminLogin.aspx" class="role-button">Admin</a>
            </div>
        </div>
    </form>
</body>
</html>
