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

    }

    /// <summary>
    /// called when the "PROCESAR XML" button is pressed.
    /// Calls function that reads xml and inserts the info of the atletes that belong to the club requesting the info
    /// </summary>
    public void testInsert_Click(object sender, EventArgs args)
    {
        List<Athlete> allAthletes = dllXmlProcesser.ProcessXmlFiles(codeOfClub);
        TextBox1.TextMode = TextBoxMode.MultiLine;
        TextBox1.Text = JsonConvert.SerializeObject(allAthletes, Formatting.Indented); ;
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