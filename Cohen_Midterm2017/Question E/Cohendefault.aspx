<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cohendefault.aspx.cs" Inherits="Cohen_Midterm2017.Question_E.Cohendefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Welcome to Michael Cohens Spring 2017 Midterm!
        <br />
        
        <asp:Menu ID="menuOverview" runat="server">
            <Items>
            <asp:MenuItem
                NavigateUrl="~/Question A/Cohen_questionA.aspx" 
                Text="Question A" 
                Value="Question A">
            </asp:MenuItem>
            <asp:MenuItem
                NavigateUrl="~/Question B/Cohen_questionB.aspx"
                Text="Question B"
                Value="Question B">
            </asp:MenuItem>
            <asp:MenuItem
                NavigateUrl="~/Question C/Cohen_questionC.aspx"
                Text="Question C"
                Value="Question C">                
            </asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <br />
        *This should totally get an A!*
    </div>
    </form>
</body>
</html>
