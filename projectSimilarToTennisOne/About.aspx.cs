using Newtonsoft.Json;
using System;
using System.Activities.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        List<Result> resultsToAdd = new List<Result>();
        List<Event> eventsToAdd = new List<Event>();
        List<string> eventNodeIdsOfEventObjsToAdd = new List<string>();

        //TODO: might have to change the way to obtain the files, depending on project requirements
        string[] xmlFilePaths = System.IO.Directory.GetFiles("C:\\Users\\crist\\source\\repos\\projectSimilarToTennisOne\\projectSimilarToTennisOne\\resources");

        //foreach (var filePath in xmlFilePaths)
        //{
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePaths[4]); //filePath);

            XmlNodeList clubNodes = doc.DocumentElement.SelectNodes("/LENEX/MEETS/MEET/CLUBS/CLUB");
            foreach (XmlNode clubNode in clubNodes)
            {
                if (clubNode.Attributes["code"].InnerText.ToString() == codeOfClub)
                {
                    XmlNodeList athleteNodes = clubNode.ChildNodes[0].ChildNodes;
                    foreach (XmlNode athleteNode in athleteNodes)
                    {
                        //Get the information of the athlete
                        Athlete athlete = new Athlete();
                        string firstName = athleteNode.Attributes["firstname"].InnerText;
                        string lastName = athleteNode.Attributes["lastname"].InnerText;
                        athlete.FullName = lastName + ", " + firstName;
                        athlete.Birthdate = DateTime.Parse(athleteNode.Attributes["birthdate"].InnerText);
                        athlete.Gender = athleteNode.Attributes["gender"].InnerText;
                        athlete.Nation = athleteNode.Attributes["nation"].InnerText;
                        athlete.License = athleteNode.Attributes["license"].InnerText;
                        athlete.ClubCode = Int32.Parse(clubNode.Attributes["code"].InnerText ?? "0");
                        athlete.ClubName = clubNode.Attributes["name"].InnerText;
                        athlete.ClubShortName = clubNode.Attributes["shortname"].InnerText;
                        athletesFromClub.Add(athlete);

                        //Get all the results of that athlete in that competition
                        XmlNodeList resultNodes = athleteNode.ChildNodes[0].ChildNodes;
                        foreach (XmlNode resultNode in resultNodes)
                        {
                            //Create the Event object belonging to that Result
                            string eventId = resultNode.Attributes["eventid"].InnerText;
                            string eventCourse = resultNode.Attributes["entrycourse"].InnerText;
                            XmlNode eventNode = doc.DocumentElement.SelectSingleNode($"/LENEX/MEETS/MEET/SESSIONS/SESSION/EVENTS/EVENT[@eventid={eventId}]");
                            XmlNode swimStyleNode = eventNode.ChildNodes[0];
                            XmlNode sessionNode = eventNode.ParentNode.ParentNode;
                            XmlNode meetNode = sessionNode.ParentNode.ParentNode;
                            
                            Event eventObj = new Event();
                            eventObj.MeetName = meetNode.Attributes["name"].InnerText;
                            eventObj.Nation = meetNode.Attributes["nation"].InnerText;
                            eventObj.City = meetNode.Attributes["city"].InnerText;
                            eventObj.Status = eventNode.Attributes["status"].InnerText;
                            eventObj.PoolLength = eventCourse == "LCM" ? 50 : 25;
                            eventObj.SessionNum = Int32.Parse(sessionNode.Attributes["number"].InnerText ?? "0");
                            eventObj.SessionName = sessionNode.Attributes["name"].InnerText;
                            eventObj.GenderCategory = eventNode.Attributes["gender"].InnerText;
                            eventObj.EventRound = eventNode.Attributes["round"].InnerText;
                            eventObj.EventCourse = eventCourse;
                            eventObj.SwimDistance = Int32.Parse(swimStyleNode.Attributes["distance"].InnerText ?? "0");
                            eventObj.SwimStroke = swimStyleNode.Attributes["stroke"].InnerText;
                            eventObj.SwimRelayCount = Int32.Parse(swimStyleNode.Attributes["relaycount"].InnerText ?? "0");
                            //check that the event has not already been added to the eventsToAdd list to avoid inserting duplicates in db
                            if (!eventNodeIdsOfEventObjsToAdd.Contains(eventId)) eventsToAdd.Add(eventObj);

                            //Get the Age Group of the result
                            string resultId = resultNode.Attributes["resultid"].InnerText;
                            XmlNode resultAgeGroupNode = doc.DocumentElement
                                .SelectSingleNode($"/LENEX/MEETS/MEET/SESSIONS/SESSION/EVENTS/EVENT[@eventid={eventId}]/AGEGROUPS/AGEGROUP/RANKINGS/RANKING[@resultid={resultId}]")
                                .ParentNode.ParentNode;
                            //XmlNode test = resultAgeGroupNode.ParentNode;
                            //XmlNode test2 = test.ParentNode;
                            //XmlNode test3 = resultAgeGroupNode.ParentNode.ParentNode;
                            int resultAgeGroupMax = Int32.Parse(resultAgeGroupNode.Attributes["agemax"].InnerText ?? "-1");
                            int resultAgeGroupMin = Int32.Parse(resultAgeGroupNode.Attributes["agemin"].InnerText ?? "-1");

                            //Create the Result object/s (splits are turned into result objects too)
                            Result result = new Result();
                            result.SplitDistance = Int32.Parse(resultNode.Attributes["distance"] != null 
                                                                ? resultNode.Attributes["distance"].InnerText 
                                                                : "0");
                            result.SwimTime = DateTime.ParseExact(resultNode.Attributes["swimtime"].InnerText, "hh:mm:ss.ff", CultureInfo.InvariantCulture);
                            result.Points = Int32.Parse(resultNode.Attributes["points"].InnerText ?? "0");
                            //result.IsWaScoring = --> checke with event
                            result.Comment = resultNode.Attributes["comment"].InnerText ?? null;
                            result.AgeGroupMaxAge = resultAgeGroupMax;
                            result.AgeGroupMinAge = resultAgeGroupMin;
                            //result.EventId = --> Event Id;
                            result.Event = null; //--> event;
                            result.AthleteId = athlete.Id;
                            result.Athlete = null; //athlete;

                            //añadir las splits a los results
                            if (resultNode.HasChildNodes)
                            {
                            //cambiar split distance del result original
                                int splitDistance = 0;

                                //TODO: añade los splits como si fueran resultados. El valor del result padre es como si fuera del ultimo split
                                foreach (XmlNode splitNode in resultNode.ChildNodes)
                                {
                                    Result splitResult = new Result();
                                    splitResult.SplitDistance = Int32.Parse(splitNode.Attributes["distance"].InnerText ?? "0");
                                    splitResult.SwimTime = DateTime.ParseExact(splitNode.Attributes["swimtime"].InnerText, "hh:mm:ss.ff", CultureInfo.InvariantCulture);
                                    splitResult.Points = 0; //or -1?
                                    //splitResult.IsWaScoring = --> checke with event
                                    splitResult.Comment = null;
                                    splitResult.AgeGroupMaxAge = resultAgeGroupMax;
                                    splitResult.AgeGroupMinAge = resultAgeGroupMin;
                                    //splitResult.EventId = --> Event Id;
                                    splitResult.Event = null; //--> event;
                                    splitResult.AthleteId = athlete.Id;
                                    splitResult.Athlete = null; //athlete;

                                    resultsToAdd.Add(splitResult);

                                    splitDistance = splitResult.SplitDistance; 
                                }
                                //change split distance of original result to save it as the last split
                                result.SplitDistance = splitDistance + eventObj.PoolLength; //calc distance of last split
                            }
                            resultsToAdd.Add(result);
                        }


                        //TODO: compare result with records and check if it needs to be added

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
                //TODO: if it already exists, check if it has empty fields that can be updated
                //TODO: add results for rankings, update and records o lo que sea
            }
        }
        //show all atheletes in db after inserting
        TextBox1.TextMode = TextBoxMode.MultiLine;
        TextBox1.Text = JsonConvert.SerializeObject(dbCon.SelectAllAthletes(), Formatting.Indented);

        //TODO: also insert the events and the results into the DB
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
