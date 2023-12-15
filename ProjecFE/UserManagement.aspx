<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Management</title>
    <!-- Include your CSS styles or external stylesheet links here -->
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }

        .btn {
            padding: 10px;
            text-decoration: none;
            background-color: #4caf50;
            color: #fff;
            border-radius: 5px;
        }

        .btn:hover {
            background-color: #45a049;
        }

        .complete-btn {
            padding: 10px;
            text-decoration: none;
            background-color: #007bff;
            color: #fff;
            border-radius: 5px;
            margin-top: 10px;
            display: inline-block;
        }

        .complete-btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>User Management</h2>

        <!-- Add your HTML elements and ASP.NET controls here for search, filters, etc. -->

        <table>
            <tr>
                <th>User ID</th>
                <th>Username</th>
                <th>Email</th>
                <th>Role</th>
                <th>Status</th>
                <th>Actions</th>
            </tr>
            <!-- Add rows dynamically based on the data from the code-behind -->
            <tr>
                <td>1</td>
                <td>john_doe</td>
                <td>john@example.com</td>
                <td>Admin</td>
                <td>Active</td>
                <td>
                    <a href="#" class="btn">Edit</a>
                    <a href="#" class="btn">Delete</a>
                </td>
            </tr>
            <!-- Add more rows as needed -->
        </table>

        <!-- Pagination, filters, and other UI elements can be added here -->

        <a href="Home.aspx" class="complete-btn">Complete</a>

    </form>
</body>
</html>
