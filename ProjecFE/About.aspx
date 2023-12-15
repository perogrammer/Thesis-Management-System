<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ProjecFE.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Statistics</title>
    <!-- Add your styles and scripts here -->
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Nested Subquery 1</h2>
            <asp:GridView ID="gvNestedSubquery1" runat="server" AutoGenerateColumns="True"></asp:GridView>



            <%--<h2 class="text-center">Nested Subquery 2</h2>
            <asp:GridView ID="gvNestedSubquery2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />
            
            <h2 class="text-center">Nested Subquery 3</h2>
            <asp:GridView ID="gvNestedSubquery3" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Nested Subquery 4</h2>
            <asp:GridView ID="gvNestedSubquery4" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Aggregate and Group By 1</h2>
            <asp:GridView ID="gvAggregateGroupBy1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Aggregate and Group By 2</h2>
            <asp:GridView ID="gvAggregateGroupBy2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Aggregate and Group By 3</h2>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Aggregate and Group By 4</h2>
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Two Table Join 1</h2>
            <asp:GridView ID="gvTwoTableJoin1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Two Table Join 2</h2>
            <asp:GridView ID="gvTwoTableJoin2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Two Table Join 3</h2>
            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Two Table Join 4</h2>
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Three Table Join 1</h2>
            <asp:GridView ID="gvThreeTableJoin1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Three Table Join 2</h2>
            <asp:GridView ID="gvThreeTableJoin2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />
            
            <h2 class="text-center">Three Table Join 3</h2>
            <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Four Table Join 1</h2>
            <asp:GridView ID="gvFourTableJoin1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Four Table Join 2</h2>
            <asp:GridView ID="gvFourTableJoin2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />--%>

            <!-- Bootstrap and jQuery Scripts -->
            <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
            <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
        </div>
    </form>
</body>
</html>
