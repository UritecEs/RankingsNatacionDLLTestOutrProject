using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using testDLLrecordsNatacion;
using testDLLrecordsNatacion.Model.Entities;


public partial class _Default : Page
{

    private readonly string codeOfClub = "00300"; //ex.Tenis club Pamplona --> replace depending on the client where this DLL is implemented
    private testDLLrecordsNatacion.RankingsNatacionApi SwimRankingsApi = new testDLLrecordsNatacion.RankingsNatacionApi();
    private string tempResourcesFolderPath = "C:\\Users\\crist\\source\\repos\\projectSimilarToTennisOne\\projectSimilarToTennisOne\\Resources\\Temp\\ExcelRecordsFiles\\";

    #region view control Events and function callers
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadTablesData();
    }

    /// <summary>
    /// called when the "PROCESAR XML" button is pressed.
    /// Calls function that reads xml and inserts the info of the atletes that belong to the club requesting the info
    /// </summary>
    public void ImportXml_Click(object sender, EventArgs args)
    {
        SwimRankingsApi.ProcessXml(codeOfClub);
        Page_Load(sender, args); //reload page with updated information
    }

    /// <summary>
    /// called when the "PROCESAR EXCEL" button is pressed.
    /// Reads xml and inserts the info of the atletes that belong to the club requesting the info
    /// </summary>
    public void ImportExcel_Click(object sender, EventArgs args)
    {
        if (ExcelFileUpload.HasFile)
        {
            var file = ExcelFileUpload.FileContent;
            string fileName = ExcelFileUpload.FileName;
            string savePath = tempResourcesFolderPath + fileName;

            ExcelFileUpload.SaveAs(savePath);
            List<Record> updatedRecords = SwimRankingsApi.ImportDataFromExcel(codeOfClub, savePath);
            UploadStatusLabel.Text = "Excel file data imported successfully.";
            LoadTablesData();
        }
        else
        {
            UploadStatusLabel.Text = "You did not specify an Excel file to upload.";
            SwimRankingsApi.InsertarRecordsEsp();
        }
    }


    #endregion

    #region Other view-related functions
    private void LoadTablesData()
    {
        Dictionary<string, object> allData = SwimRankingsApi.FetchAllData();
        List<Athlete> allAthletes = (dynamic) allData["Athletes"];
        List<Event> allEvents = (dynamic) allData["Events"];
        List<Result> allResults = (dynamic) allData["Results"];
        List<Record> allRecords = (dynamic) allData["Records"];

        ResetTable(AthletesTable);
        ResetTable(EventsTable);
        ResetTable(ResultsTable);
        ResetTable(RecordsTable);
 
        //Generate tables
        foreach (Athlete athlete in allAthletes)
        {
            TableRow row = GenerateTableRowFromAthlete(athlete);
            AthletesTable.Rows.Add(row);
        }         
        foreach (Event evento in allEvents)
        {
            TableRow row = GenerateTableRowFromEvent(evento);
            EventsTable.Rows.Add(row);
        }
        foreach (Result result in allResults)
        {
            TableRow row = GenerateTableRowFromResult(result);
            ResultsTable.Rows.Add(row);
        }
        foreach (Record record in allRecords)
        {
              TableRow row = GenerateTableRowFromRecord(record);
            RecordsTable.Rows.Add(row);
        }

    }

    /// <summary>
    /// Removes all of the rows of a table except for the headers
    /// </summary>
    /// <param name="table"></param>
    private void ResetTable(Table table)
    {
        TableRow headersRow = table.Rows[0];
        table.Rows.Clear();
        table.Rows.Add(headersRow);
    }

    /// <summary>
    /// Generates a table row object to display all the object's attributes values 
    /// in different cells, corresponding to the columns of the table 
    /// </summary>
    /// <param name="athlete">The Athlete that we want to describe the properties of</param>
    /// <returns>TableRow with the described object data</returns>
    private TableRow GenerateTableRowFromAthlete(Athlete athlete)
    {
        TableRow row = new TableRow();
        row.ID = $"row_{athlete.Id}";

        Dictionary<string, string> properties = athlete.DescribePropertiesFormattedStr();
        for (int i = 0; i < properties.Count; i++)
        {
            var att = properties.ElementAt(i);
            string attName = att.Key;
            string attValue = att.Value;

            TableCell propertyCell = new TableCell();
            propertyCell.ID = $"cell_{attName}_{athlete.Id}";
            propertyCell.Controls.Add(new LiteralControl(attValue));
            row.Cells.Add(propertyCell);
        }

        return row;
    }

    /// <summary>
    /// Generates a table row object to display all the object's attributes values 
    /// in different cells, corresponding to the columns of the table 
    /// </summary>
    /// <param name="evento">The Event that we want to describe the properties of</param>
    /// <returns>TableRow with the described object data</returns>
    private TableRow GenerateTableRowFromEvent(Event evento)
    {
        TableRow row = new TableRow();
        row.ID = $"row_{evento.Id}";

        Dictionary<string, string> properties = evento.DescribePropertiesFormattedStr();
        for (int i = 0; i < properties.Count; i++)
        {
            var att = properties.ElementAt(i);
            string attName = att.Key;
            string attValue = att.Value;

            TableCell propertyCell = new TableCell();
            propertyCell.ID = $"cell_{attName}_{evento.Id}";
            propertyCell.Controls.Add(new LiteralControl(attValue));
            row.Cells.Add(propertyCell);
        }

        return row;
    }

    /// <summary>
    /// Generates a table row object to display all the object's attributes values 
    /// in different cells, corresponding to the columns of the table 
    /// </summary>
    /// <param name="result">The Result that we want to describe the properties of</param>
    /// <returns>TableRow with the described object data</returns>
    private TableRow GenerateTableRowFromResult(Result result)
    {
        TableRow row = new TableRow();
        row.ID = $"row_{result.Id}";

        Dictionary<string, string> properties = result.DescribePropertiesStr();
        for (int i = 0; i < properties.Count; i++)
        {
            var att = properties.ElementAt(i);
            string attName = att.Key;
            string attValue = att.Value;

            TableCell propertyCell = new TableCell();
            propertyCell.ID = $"cell_{attName}_{result.Id}";
            propertyCell.Controls.Add(new LiteralControl(attValue));
            row.Cells.Add(propertyCell);
        }

        return row;
    }

    /// <summary>
    /// Generates a table row object to display all the object's attributes values 
    /// in different cells, corresponding to the columns of the table 
    /// </summary>
    /// <param name="record">The Result that we want to describe the properties of</param>
    /// <returns>TableRow with the described object data</returns>
    private TableRow GenerateTableRowFromRecord(Record record)
    {
        TableRow row = new TableRow();
        row.ID = $"row_{record.Id}";

        Dictionary<string, string> properties = record.DescribePropertiesStr();
        for (int i = 0; i < properties.Count; i++)
        {
            var att = properties.ElementAt(i);
            string attName = att.Key;
            string attValue = att.Value;

            TableCell propertyCell = new TableCell();
            propertyCell.ID = $"cell_{attName}_{record.Id}";
            propertyCell.Controls.Add(new LiteralControl(attValue));
            row.Cells.Add(propertyCell);
        }

        return row;
    }
    #endregion

}