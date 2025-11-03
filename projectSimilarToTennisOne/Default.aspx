<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- <link rel="stylesheet" href="Content/TailwindDatatableStyle.css" type="text/css" />
        
        <link rel="stylesheet" href="https://cdn.datatables.net/2.3.4/css/dataTables.dataTables.css" />
        <script src="https://cdn.datatables.net/2.3.4/js/dataTables.js"></script>
        -->

            
        <link rel="stylesheet" href="https://cdn.datatables.net/2.3.4/css/dataTables.dataTables.css" />
        <script src="https://cdn.datatables.net/2.3.4/js/dataTables.js"></script>


    <h1>TEST TO DISPLAY INFORMATION</h1>

    <asp:button id="Button1" onclick="testInsert_Click" runat="server" Text="Procesar XML"></asp:button>

    <div>
        <label style="font-weight:bold;font-size:large">Atletas</label>
         <asp:Table id="AthletesTable" class="dataTable table-striped" runat="server" CellPadding="10" GridLines="both" 
             HorizontalAlign="Justify" style="max-height:500px;" Width="100%">
             <asp:TableHeaderRow Font-Bold="true">
                <asp:TableCell name="FullName">Nombre Completo</asp:TableCell>
                <asp:TableCell name="Birthdate">Fecha de Nacimiento</asp:TableCell>
                <asp:TableCell name="Gender">Género</asp:TableCell>
                <asp:TableCell name="Nation">País</asp:TableCell>
                <asp:TableCell name="License">Licencia</asp:TableCell>
                <asp:TableCell name="ClubCode">Código del club</asp:TableCell>
                <asp:TableCell name="ClubName">Nombre del club</asp:TableCell>
                <asp:TableCell name="ClubShortName">Abreviatura del club</asp:TableCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

     <div>
         <label style="font-weight:bold;font-size:large">Eventos</label>
          <asp:Table id="EventsTable" class="dataTable table-striped" runat="server" CellPadding="10" GridLines="both" 
              HorizontalAlign="Justify" style="max-height:500px;min-height:fit-content;" Width="100%">
              <asp:TableHeaderRow Font-Bold="true">
                 <asp:TableCell name="MeetName">Competición</asp:TableCell>
                 <asp:TableCell name="MeetDate">Fecha</asp:TableCell>
                 <asp:TableCell name="Nation">País</asp:TableCell>
                 <asp:TableCell name="City">Ciudad</asp:TableCell>
                 <asp:TableCell name="Status">Clasificación</asp:TableCell>
                 <asp:TableCell name="PoolLength">Longitud de la piscina</asp:TableCell>
                 <asp:TableCell name="SessionNum">Nº Sesión</asp:TableCell>
                 <asp:TableCell name="SessionName">Sesión</asp:TableCell>
                 <asp:TableCell name="GenderCategory">Categoría de Género</asp:TableCell>
                 <asp:TableCell name="EventRound">Ronda del Evento</asp:TableCell>
                 <asp:TableCell name="EventCourse">Recorrido de nado</asp:TableCell>
                 <asp:TableCell name="SwimDistance">Distancia de nado</asp:TableCell>
                 <asp:TableCell name="SwimStroke">Estilo de nado</asp:TableCell>
                 <asp:TableCell name="SwimRelayCount">Cantidad de relevos</asp:TableCell>
             </asp:TableHeaderRow>
         </asp:Table>
     </div>

     <div>
         <label style="font-weight:bold;font-size:large">Resultados de pruebas</label>
          <asp:Table id="ResultsTable" class="dataTable table-striped" runat="server" CellPadding="10" GridLines="both" HorizontalAlign="Justify" Width="100%">
              <asp:TableHeaderRow Font-Bold="true">
                 <asp:TableCell name="SplitDistance">Distancia recorrida</asp:TableCell>
                 <asp:TableCell name="SwimTime">Tiempo</asp:TableCell>
                 <asp:TableCell name="Points">Puntos</asp:TableCell>
                 <asp:TableCell name="IsWaScoring">Evaluación según FINA?</asp:TableCell>
                 <asp:TableCell name="EntryTime">Tiempo de entrada</asp:TableCell>
                 <asp:TableCell name="Comment">Anotación</asp:TableCell>
                 <asp:TableCell name="AgeGroupMaxAge">Edad máxima del evento</asp:TableCell>
                 <asp:TableCell name="AgeGroupMinAge">Edad mínima del evento</asp:TableCell>
                 <asp:TableCell name="EventId">Id del evento</asp:TableCell>
                 <asp:TableCell name="AthleteId">Id del atleta</asp:TableCell>
             </asp:TableHeaderRow>
         </asp:Table>
     </div>

</asp:Content>
