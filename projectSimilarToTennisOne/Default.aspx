<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="Content/bootstrap.css" type="text/css"/>

        <script src="https://cdn.datatables.net/2.3.4/js/dataTables.js"></script>


    <h1>TEST TO DISPLAY INFORMATION</h1>

    <div style="margin-bottom:20px;">
        <asp:button id="Button1" onclick="testInsert_Click" runat="server" Text="Procesar XML"></asp:button>
    </div>

    <label style="font-weight:bold;font-size:large">Atletas</label>
    <div style="overflow-y: auto; max-height: 300px; width: 100%; margin-bottom:20px;">
         <asp:Table id="AthletesTable" class="table table-striped" runat="server" CellPadding="10" GridLines="both" 
             HorizontalAlign="Justify" Width="100%">
             <asp:TableHeaderRow class="thead">
                <asp:TableHeaderCell name="FullName">Nombre Completo</asp:TableHeaderCell>
                <asp:TableHeaderCell name="Birthdate">Fecha de Nacimiento</asp:TableHeaderCell>
                <asp:TableHeaderCell name="Gender">Género</asp:TableHeaderCell>
                <asp:TableHeaderCell name="Nation">País</asp:TableHeaderCell>
                <asp:TableHeaderCell name="License">Licencia</asp:TableHeaderCell>
                <asp:TableHeaderCell name="ClubCode">Código del club</asp:TableHeaderCell>
                <asp:TableHeaderCell name="ClubName">Nombre del club</asp:TableHeaderCell>
                <asp:TableHeaderCell name="ClubShortName">Abreviatura del club</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

     <label style="font-weight:bold;font-size:large">Eventos</label>
     <div style="overflow-y: auto; height: 300px; width: 100%; margin-bottom:20px;">
          <asp:Table id="EventsTable" class="table table-striped" runat="server" CellPadding="10" GridLines="both" 
              HorizontalAlign="Justify" Width="100%">
              <asp:TableHeaderRow class="thead">
                 <asp:TableHeaderCell name="MeetName">Competición</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="MeetDate">Fecha</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="Nation">País</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="City">Ciudad</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="Status">Clasificación</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="PoolLength">Longitud de la piscina</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="SessionNum">Nº Sesión</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="SessionName">Sesión</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="GenderCategory">Categoría de Género</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="EventRound">Ronda del Evento</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="EventCourse">Recorrido de nado</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="SwimDistance">Distancia de nado</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="SwimStroke">Estilo de nado</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="SwimRelayCount">Cantidad de relevos</asp:TableHeaderCell>
             </asp:TableHeaderRow>
         </asp:Table>
     </div>

     <label style="font-weight:bold;font-size:large">Resultados de pruebas</label>
     <div style="overflow-y: auto; height: 300px; width: 100%; margin-bottom:20px;">
          <asp:Table id="ResultsTable" class="table table-striped" runat="server" CellPadding="10" GridLines="both" HorizontalAlign="Justify" Width="100%">
              <asp:TableHeaderRow Font-Bold="true">
                 <asp:TableHeaderCell name="SplitDistance">Distancia recorrida</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="SwimTime">Tiempo</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="Points">Puntos</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="IsWaScoring">Evaluación según FINA?</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="EntryTime">Tiempo de entrada</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="Comment">Anotación</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="AgeGroupMaxAge">Edad máxima del evento</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="AgeGroupMinAge">Edad mínima del evento</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="EventId">Id del evento</asp:TableHeaderCell>
                 <asp:TableHeaderCell name="AthleteId">Id del atleta</asp:TableHeaderCell>
             </asp:TableHeaderRow>
         </asp:Table>
     </div>

</asp:Content>
