using Newtonsoft.Json;
using System;
using System.Activities.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using testDLLrecordsNatacion.Model;
using testDLLrecordsNatacion.Model.Entities;
using WebGrease.Css.Extensions;
using Formatting = Newtonsoft.Json.Formatting;


public partial class About : Page
{
    private dbConnection dbCon = new dbConnection();
    private readonly string codeOfClub = "00300"; //ex.Tenis club Pamplona --> replace depending on the client where this DLL is implemented

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    /// <summary>
    /// function called from the "test" button of the view
    /// </summary>
    public void testBtn_Click(object sender, EventArgs args)
    {
        List<Athlete> atletas = new List<Athlete>();
        atletas = dbCon.SelectAllAthletes();

        resultLabel.TextMode = TextBoxMode.MultiLine;
        resultLabel.Text = JsonConvert.SerializeObject(atletas, Formatting.Indented); //"This is the result text";
        resultLabel.BackColor = System.Drawing.Color.Yellow;
    }

    /// <summary>
    /// called when the "PROCESAR XML" button is pressed.
    /// Reads xml and inserts the info of the atletes that belong to the club requesting the info
    /// </summary>
    public void testInsert_Click(object sender, EventArgs args)
    {
        List<Athlete> athletesFromClub = new List<Athlete>();

        //TODO: might have to change the way to obtain the files, depending on project requirements
        string[] xmlFilePaths = System.IO.Directory.GetFiles("C:\\Users\\crist\\source\\repos\\projectSimilarToTennisOne\\projectSimilarToTennisOne\\resources");

        //foreach (var filePath in xmlFilePaths)
        //{
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePaths[4]); //filePath);

            XmlNodeList clubs = doc.DocumentElement.SelectNodes("/LENEX/MEETS/MEET/CLUBS/CLUB");
            foreach (XmlNode club in clubs)
            {
                if (club.Attributes["code"].InnerText.ToString() == codeOfClub)
                {
                XmlNodeList athletes = club.ChildNodes[0].ChildNodes; //("/ATHLETES/ATHLETE");
                    foreach (XmlNode atheleteNode in athletes)
                    {
                        Athlete athlete = new Athlete();
                        string firstName = atheleteNode.Attributes["firstname"].InnerText;
                        string lastName = atheleteNode.Attributes["lastname"].InnerText;
                        athlete.FullName = lastName + ", " + firstName;
                        athlete.Birthdate = DateTime.Parse(atheleteNode.Attributes["birthdate"].InnerText);
                        athlete.Gender = atheleteNode.Attributes["gender"].InnerText;
                        athlete.Nation = atheleteNode.Attributes["nation"].InnerText;
                        athlete.License = atheleteNode.Attributes["license"].InnerText;
                        athlete.ClubCode = Int32.Parse(club.Attributes["code"].InnerText);
                        athlete.ClubName = club.Attributes["name"].InnerText;
                        athlete.ClubShortName = club.Attributes["shortname"].InnerText;

                        athletesFromClub.Add(athlete);

                        //TODO: también habrá que añadir info sobre sus results y los eventos
                    }
                }
            }
        //}

        //insert new athletes into the database
        foreach(Athlete athlete in athletesFromClub)
        {
            Athlete athleteExists = dbCon.SearchAthleteByName(athlete.FullName);
            if (athleteExists == null)
            {
                dbCon.InsertAthlete(athlete);
            }
            else
            {
                //TODO:if it already exists, check if it has empty fields that can be updated
                //TODO: add results for rankings, update and records o lo que sea
            }
        }
        //show all atheletes in db after inserting
        TextBox1.TextMode = TextBoxMode.MultiLine;
        TextBox1.Text = JsonConvert.SerializeObject(dbCon.SelectAllAthletes(), Formatting.Indented);
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
