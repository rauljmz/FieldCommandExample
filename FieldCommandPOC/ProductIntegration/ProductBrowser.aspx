<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductBrowser.aspx.cs" Inherits="FieldCommandPOC.ProductIntegration.ProductBrowser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Browser</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Select your product</h1>
    <div>
   <asp:Label runat="server" AssociatedControlID="ProductID" Text="Product ID:"></asp:Label>
         <asp:TextBox runat="server" ID="ProductID"></asp:TextBox>
        <asp:Button Text="OK" runat="server" ID="btnOK"/>
        <asp:Button Text="Cancel" runat="server" ID="btnCancel"/>
    </div>
    </form>
</body>
</html>
