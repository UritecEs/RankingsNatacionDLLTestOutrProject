<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <h1>TEST TO DISPLAY INFORMATION</h1>
    <asp:button id="testBtn" onclick="testBtn_Click" runat="server" Text="TEST"></asp:button>
    <asp:TextBox Width="1500" Height="600" id="resultLabel" runat="server" >[Result goes here]</asp:TextBox>

    <asp:button id="Button1" onclick="testInsert_Click" runat="server" Text="Procesar XML"></asp:button>
    <asp:TextBox Width="1500" Height="600" id="TextBox1" runat="server" TextMode="MultiLine">[Atletas del club de tenis de Pamplona que aparecen en el XML]</asp:TextBox>

</asp:Content>
