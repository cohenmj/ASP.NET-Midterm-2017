<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cohen_questionA.aspx.cs" Inherits="Cohen_Midterm2017.Cohen_questionA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:RadioButtonList 
            ID="rdlCompanyName"
            DataSourceID="Midterm"
            DataTextField="CompanyName"
            runat="server">
        </asp:RadioButtonList>
    
        <asp:Button 
            ID="rdlSubmit" 
            runat="server" 
            Text="Submit" 
            OnClick="rdlSubmit_Click" />
        <asp:Panel 
            ID="dtlPanel"
            DataSourceID="Midterm2"
            GroupingText="Supplier Details"
            runat="server">
        <asp:DetailsView 
            ID="dtlCompanyDetails"
            DataSourceID="Midterm2"
            runat="server"
            Height="50px"
            Width="125px">
        </asp:DetailsView>
        </asp:Panel>

        <asp:SqlDataSource 
            ID="Midterm"
            runat="server"
            SelectCommand="SELECT * from Suppliers"
            ConnectionString="<%$ ConnectionStrings:Midterm %>">
        </asp:SqlDataSource>

        <asp:SqlDataSource
            ID="Midterm2"
            runat="server"
            SelectCommand="SELECT * FROM Suppliers where CompanyName=@CompanyName"
            ConnectionString="<%$ ConnectionStrings:Midterm %>">
          <SelectParameters>
            <asp:ControlParameter
                Name="CompanyName"
                ControlID="rdlCompanyName"
                PropertyName="SelectedValue"
                />
        </SelectParameters>
        </asp:SqlDataSource>
            
    
    </div>
        
            
        
    </form>
</body>
</html>
