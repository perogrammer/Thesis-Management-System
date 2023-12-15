<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminReg.aspx.cs" Inherits="ProjecFE.AdminReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Statistics</title>
    <!-- Add your styles and scripts here -->
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Subquery to find students who have submitted a proposal</h2>
            <asp:GridView ID="gvNestedSubquery1" runat="server" AutoGenerateColumns="True"></asp:GridView>

            <h2 class="text-center">Subquery to find administrators who have approved proposals</h2>
            <asp:GridView ID="gvNestedSubquery2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />
            
            <h2 class="text-center">Subquery to find thesis supervisors for students with pending proposals</h2>
            <asp:GridView ID="gvNestedSubquery3" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Nested Subquery 4</h2>
            <asp:GridView ID="gvNestedSubquery4" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Count of proposals for each student with more than 2 proposals</h2>
            <asp:GridView ID="gvAggregateGroupBy1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Average approval status count for each panel member</h2>
            <asp:GridView ID="gvAggregateGroupBy2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Aggregate and Group By 3</h2>
            <asp:GridView ID="gvAggregateGroupBy3" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Aggregate and Group By 4</h2>
            <asp:GridView ID="gvAggregateGroupBy4" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Joining ThesisProposals and Students to get proposal details with studentIDs</h2>
            <asp:GridView ID="gvTwoTableJoin1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Joining ThesisProposals and Students to get proposal details with student names</h2>
            <asp:GridView ID="gvTwoTableJoin2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Two Table Join 3</h2>
            <asp:GridView ID="gvTwoTableJoin3" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Two Table Join 4</h2>
            <asp:GridView ID="gvTwoTableJoin4" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Joining ProposalReviews, PanelMembers, and Users to get reviews along with panel member names and roles</h2>
            <asp:GridView ID="gvThreeTableJoin1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Joining ThesisProposals, Students, and Users to get proposal details with student names and usernames</h2>
            <asp:GridView ID="gvThreeTableJoin2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />
            
            <h2 class="text-center">Three Table Join 3</h2>
            <asp:GridView ID="gvThreeTableJoin3" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Four Table Join 1</h2>
            <asp:GridView ID="gvFourTableJoin1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <h2 class="text-center">Four Table Join 2</h2>
            <asp:GridView ID="gvFourTableJoin2" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped" />

            <!-- Bootstrap and jQuery Scripts -->
            <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
            <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
        </div>
    </form>
</body>
</html>
