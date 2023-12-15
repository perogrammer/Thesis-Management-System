<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Evaluate.aspx.cs" Inherits="ProjecFE.Evaluate" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Evaluation Page</title>
    <!-- Add your styles and scripts here -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Thesis Evaluation</h2>

            

            

            <!-- Comments Section -->
            <div>
                <h3>Comments</h3>
                <textarea class="form-control" rows="5" ID="txtComments" runat="server"></textarea>
            </div>

            <!-- Overall Feedback -->
            <div>
                <h3>Overall Feedback</h3>
                <textarea class="form-control" rows="3" ID="txtOverallFeedback" runat="server"></textarea>
            </div>

            <!-- Recommendations -->
            <div>
                <h3>Recommendations</h3>
                <textarea class="form-control" rows="3" ID="txtRecommendations" runat="server"></textarea>
            </div>

            <!-- Save and Submit Buttons -->
            <div class="text-center mt-4">
                <asp:Button ID="btnSaveDraft" runat="server" Text="Reject" CssClass="btn btn-primary" OnClick="btnReject_Click"  />
                <asp:Button ID="btnSubmitEvaluation" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnSubmitEvaluation_Click" />
            </div>
        </div>

        <!-- Add your scripts and any additional styling if needed -->
        

        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    </form>
</body>
</html>
