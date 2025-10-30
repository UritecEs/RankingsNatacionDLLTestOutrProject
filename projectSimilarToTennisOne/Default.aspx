<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>TEST TO DISPLAY INFORMATION</h1>

    <asp:button id="Button1" onclick="testInsert_Click" runat="server" Text="Procesar XML"></asp:button>
    <asp:TextBox Width="1500" Height="600" id="TextBox1" runat="server" TextMode="MultiLine">[Atletas del club de tenis de Pamplona que aparecen en el XML]</asp:TextBox>

</asp:Content>
