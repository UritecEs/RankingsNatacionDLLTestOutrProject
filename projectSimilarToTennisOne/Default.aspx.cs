using Newtonsoft.Json;
using System;
using System.Activities.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using testDLLrecordsNatacion;
using testDLLrecordsNatacion.Model;
using testDLLrecordsNatacion.Model.Entities;
using WebGrease.Css.Extensions;
using Formatting = Newtonsoft.Json.Formatting;


public partial class _Default : Page
{
    private LenexXmlProcesser dllXmlProcesser = new LenexXmlProcesser();
    private readonly string codeOfClub = "00300"; //ex.Tenis club Pamplona --> replace depending on the client where this DLL is implemented

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Athlete> allAthletes = dllXmlProcesser.ProcessXmlFiles(codeOfClub);

        // Generate rows and cells.           
        foreach (Athlete athlete in allAthletes)
        {
            TableRow row = new TableRow();

            TableCell id = new TableCell();
            id.Controls.Add(new LiteralControl(athlete.Id.ToString()));
            row.Cells.Add(id);

            TableCell fullName = new TableCell();
            fullName.Controls.Add(new LiteralControl(athlete.FullName));
            row.Cells.Add(fullName);

            TableCell birthdate = new TableCell();
            birthdate.Controls.Add(new LiteralControl(athlete.Birthdate.ToString()));
            row.Cells.Add(birthdate);

            TableCell gender = new TableCell();
            gender.Controls.Add(new LiteralControl(athlete.Gender));
            row.Cells.Add(gender);

            TableCell nation = new TableCell();
            nation.Controls.Add(new LiteralControl(athlete.Nation));
            row.Cells.Add(nation);

            TableCell license = new TableCell();
            license.Controls.Add(new LiteralControl(athlete.License));
            row.Cells.Add(license);

            TableCell clubcode = new TableCell();
            clubcode.Controls.Add(new LiteralControl(athlete.ClubCode.ToString()));
            row.Cells.Add(clubcode);

            TableCell clubname = new TableCell();
            clubname.Controls.Add(new LiteralControl(athlete.ClubName));
            row.Cells.Add(clubname);

            TableCell clubshortname = new TableCell();
            clubshortname.Controls.Add(new LiteralControl(athlete.ClubShortName));
            row.Cells.Add(clubshortname);

            Table1.Rows.Add(row);
        }
    }

    /// <summary>
    /// called when the "PROCESAR XML" button is pressed.
    /// Calls function that reads xml and inserts the info of the atletes that belong to the club requesting the info
    /// </summary>
    public void testInsert_Click(object sender, EventArgs args)
    {
        /*List<Athlete> allAthletes = dllXmlProcesser.ProcessXmlFiles(codeOfClub);

        // Generate rows and cells.           
        foreach (Athlete athlete in allAthletes)
        {
            TableRow row = new TableRow();

            TableCell id = new TableCell();
            id.Controls.Add(new LiteralControl(athlete.Id.ToString()));
            row.Cells.Add(id);

            TableCell fullName = new TableCell();
            fullName.Controls.Add(new LiteralControl(athlete.FullName));
            row.Cells.Add(fullName);

            TableCell birthdate = new TableCell();
            birthdate.Controls.Add(new LiteralControl(athlete.Birthdate.ToString()));
            row.Cells.Add(birthdate);

            TableCell gender = new TableCell();
            gender.Controls.Add(new LiteralControl(athlete.Gender));
            row.Cells.Add(gender);

            TableCell nation = new TableCell();
            nation.Controls.Add(new LiteralControl(athlete.Nation));
            row.Cells.Add(nation);

            TableCell license = new TableCell();
            license.Controls.Add(new LiteralControl(athlete.License));
            row.Cells.Add(license);

            TableCell clubcode = new TableCell();
            clubcode.Controls.Add(new LiteralControl(athlete.ClubCode.ToString()));
            row.Cells.Add(clubcode);

            TableCell clubname = new TableCell();
            clubname.Controls.Add(new LiteralControl(athlete.ClubName));
            row.Cells.Add(clubname);

            TableCell clubshortname = new TableCell();
            clubshortname.Controls.Add(new LiteralControl(athlete.ClubShortName));
            row.Cells.Add(clubshortname);

            Table1.Rows.Add(row);
        }*/
    }

    /// <summary>
    /// called when the "PROCESAR EXCEL" button is pressed.
    /// Reads xml and inserts the info of the atletes that belong to the club requesting the info
    /// </summary>
    public void testInsertExcel_Click(object sender, EventArgs args)
    {
        //TODO
    }

}