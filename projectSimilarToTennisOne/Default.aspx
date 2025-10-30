<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>TEST TO DISPLAY INFORMATION</h1>

    <asp:button id="Button1" onclick="testInsert_Click" runat="server" Text="Procesar XML"></asp:button>
    <div>
        <label style="font-weight:bold;font-size:large">All athletes:</label>
         <asp:Table id="Table1" runat="server" CellPadding="10" GridLines="both" HorizontalAlign="Justify" Width="100%">
             <asp:TableRow Font-Bold="true">
                <asp:TableCell>ID</asp:TableCell>
                <asp:TableCell>FullName</asp:TableCell>
                <asp:TableCell>Birthdate</asp:TableCell>
                <asp:TableCell>Gender</asp:TableCell>
                <asp:TableCell>Nation</asp:TableCell>
                <asp:TableCell>License</asp:TableCell>
                <asp:TableCell>ClubCode</asp:TableCell>
                <asp:TableCell>ClubName</asp:TableCell>
                <asp:TableCell>ClubShortName</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
