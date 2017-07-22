<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cohen_questionB.aspx.cs" Inherits="Cohen_Midterm2017.Cohen_questionB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:TextBox 
            runat="server"
            ID="txtSearch" >
        </asp:TextBox>

        <asp:Button 
            runat="server"
            ID="btnSearch" 
            Text="Search" OnClick="btnSearch_Click"/>

        <asp:GridView
            runat="server"
            ID="grdSuppliersList"
            DataSourceID="Midterm"
            AllowPaging="false"
            AllowSorting="true">
        </asp:GridView>
        <br />
        <br />
         <asp:GridView 
            runat="server"
            ID="grdSearch" 
            DataSourceID="Midterm_two"
            Visible="false">
        </asp:GridView>

        <asp:SqlDataSource 
            runat="server"
            ID="Midterm" 
            SelectCommand="SELECT SupplierID, CompanyName, ContactName, State, Phone FROM Suppliers ORDER BY CompanyName DESC"
            ConnectionString="<%$ ConnectionStrings:Midterm %>">
        </asp:SqlDataSource>
      

         <asp:SqlDataSource
            runat="server"
            ID="Midterm_two"
            SelectCommand="SELECT * FROM Suppliers WHERE CompanyName LIKE @CompanyName + '%'"
            ConnectionString="<%$ ConnectionStrings:Midterm %>">
          <SelectParameters>
            <asp:ControlParameter
                Name="CompanyName"
                ControlID="txtSearch"
                PropertyName="Text"
                />
        </SelectParameters>
        </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
