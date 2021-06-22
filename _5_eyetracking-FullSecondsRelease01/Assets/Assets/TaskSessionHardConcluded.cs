using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections.Specialized;

public class TaskSessionHardConcluded : MonoBehaviour
{
    string startupPath = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/";
    string StrngInstructionsHTM = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/" + "FinalInstructions.htm";
    string StrngSendingDataHTM = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/" + "SendingTheData.htm";
    string StrngInstructionsHref = "Fil" + "e:///" + System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/" + "SendingTheData.htm";
    string StrngFinalQuestionnaire = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/" + "FinalQuestionnaire.htm";
    string StrngFinalQuestionnaireHref = "Fil" + "e:///" + System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/" + "FinalQuestionnaire.htm";
    string AddStrngEyeDatOneAndTwo = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/TrialSessions1und2.txt";
    string AddStrngEyeDatThree = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/ExpSession1.txt";
    string AddStrngEyeDatFour = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/ExpSession2.txt";
    string AddStrngEyeDatFiveAndSix = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/TrialSessions3und4.txt";
    string AddStrngEyeDatSeven = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/ExpSession3.txt";
    string AddStrngEyeDatEight = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/ExpSession4.txt";
    string AddStrngDeBrief = System.IO.Directory.GetCurrentDirectory() + "/SpiderExperimentV05R02_Data/FinalLog/Debrief/Debrief.txt";

    public int OpenHTMFile;
    public int GetTheLog;
    public int OpenInExplorer;
    public int IntFinishHTM;


    public GameObject TextendOfTaskHard;
    public ExperimentalProcedure experimentalProcedure;

    void Start()
    {
        TaskTestSession.BoolTrialIsOn = false;

        TextendOfTaskHard.SetActive(true);

        GetTheLog = 0;
        OpenHTMFile = 0;
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetTheLog = 1;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            OpenHTMFile = 1;
        }

    }


    public void Wait()
    {
        FunctionTimer.StopTimer("WaitingTime");
        FunctionTimer.Create(makeHTMtest, 3f, "MakeHTMWait");
    }
    public void makeHTMtest()
    {
        IntFinishHTM++;
        FunctionTimer.StopTimer("MakeHTMWait");
        IntFinishHTM++;

        //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //EVERYTHING BELOW CREATES DATA IN THE FILE FinalInstructions.htm 
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //


        File.AppendAllText(StrngInstructionsHTM,
    "<b><big><big><big>Thank you for taking part. To finish off, we need two things: <br> <br><br> </big>1. The data log files. You can either:</big></big><br> " +
    "<big>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a. Try clicking here for instructions on how to send them: </big><br><i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        //++++++++++++++++++++++++++++++++++++++++++++
        //OPTION 1.A CREATES A LINK SendingTheData.HTM
        //++++++++++++++++++++++++++++++++++++++++++++
        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngInstructionsHref = StrngInstructionsHref.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngInstructionsHTM,
                @"<a href=""");
        StrngInstructionsHref = StrngInstructionsHref.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngSendingDataHTM = StrngSendingDataHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngInstructionsHTM,
            StrngInstructionsHref +
            @"""" +
        ">" + StrngSendingDataHTM +
        "</a>");
        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngInstructionsHTM,
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<small><i>If the link has been successfully created, this will open a new local HTM file from your " +
        "browser with further instructions.</i></small>" +

        //+++++++++++++++++++++++++++++++
        //OPTION 1.B CREATES A mailto LINK
        //+++++++++++++++++++++++++++++++
        "<br><br><br><b><big>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b. Alternatively you can open an email with the following mailto link. " +
        "Further instructions will be contained in the email: </big></b><br>");

        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        AddStrngEyeDatOneAndTwo = AddStrngEyeDatOneAndTwo.Replace(@"/", @"\");   // explorer doesn't like front slashes
        AddStrngEyeDatThree = AddStrngEyeDatThree.Replace(@"/", @"\");   // explorer doesn't like front slashes
        AddStrngEyeDatFour = AddStrngEyeDatFour.Replace(@"/", @"\");   // explorer doesn't like front slashes
        AddStrngEyeDatFiveAndSix = AddStrngEyeDatFiveAndSix.Replace(@"/", @"\");   // explorer doesn't like front slashes
        AddStrngEyeDatSeven = AddStrngEyeDatSeven.Replace(@"/", @"\");   // explorer doesn't like front slashes
        AddStrngEyeDatEight = AddStrngEyeDatEight.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngInstructionsHTM,
        @"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><i><a href=""mailto:jogi1800@student.miun.se?subject=Data%20for%20Spider%20Experiment&amp;body=" +
        "Please send the following files  which can be found at the following location (provided the path  has been created correctly, you can copy and paste it into explorer.)%0d%0a%0d%0a" +
        "Folder: " + startupPath +
        "%0d%0aTrialSessions1und2.txt" +
        "%0d%0aExpSession1.txt" +
        "%0d%0aExpSession2.txt" +
        "%0d%0aTrialSessions3und4.txt " +
        "%0d%0aExpSession3.txt" +
        "%0d%0aExpSession4.txt" +
        "%0d%0a%0d%0aPlease don't forget to send your Final Questionnaire Data which you can find in the same folder, either as Instructions+Debrief.PDF or as instructions.txt");

        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngInstructionsHTM,
        @"""> Send us your data per email</a></i></b>");


        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        startupPath = startupPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngInstructionsHTM,

        //+++++++++++++++++++++++++++
        //OPTION 1.C GIVES INSTRUCTIONS FOR OPENING THE FOLDER IF A AND B FAIL
        //+++++++++++++++++++++++++++



        "<br><br><br><b><big>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c. If both options fail, please locate the files yourself in " +
        "the folder of this application where you saved it after download: </big></b><br><br>" +
            "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...Your computer path... /SpiderExperimentV05R02_DataFinalLog/ <br> " +
            "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This folder contains the following files. " +

            "<br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i>- " +
            "Instructions.txt which will explain everything you have to do." +
            "<br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i>- " +
            "Instructions+Debrief.PDF which will explain everything you have to do and which also contains the debriefing information for this experiment.</i><br><br>" +
            "<br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i>- " +
            "<b>I have tried to recreate the path here. If that worked, " +
            "you can copy and paste the link into explorer.  </b>" +
            "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
            );

        startupPath = startupPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngInstructionsHref = StrngInstructionsHref.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngInstructionsHTM,

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //THE LINK TO THE FOLDER startupPath (FinalLog) IS NOT CREATED, BUT ONLY PRINTED FOR COPY PASTE
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            startupPath +
        "</a></i>");


        //+++++++++++++++++++++++++++
        //OPTION 2 ATTEMPTS TO CREATE A LINK TO THE FINAL QUESTIONNAIRE
        //+++++++++++++++++++++++++++

        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngInstructionsHref = StrngInstructionsHref.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngInstructionsHTM,
        "<br><br><br><big><big><b>2. The other thing is the final questionnaire which can be found here: </b></big></big><br><br>");

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //ATTEMPTS TO CREATE A LINK TO THE FINAL QUESTIONNAIRE 
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngFinalQuestionnaire = StrngFinalQuestionnaire.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngFinalQuestionnaireHref = StrngFinalQuestionnaireHref.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngInstructionsHTM,


        @"<i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=""" +
            StrngFinalQuestionnaireHref +
            @"""" +
        ">" + StrngFinalQuestionnaire +
        "</a></i>" +
        "<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>" +
        "</body></html>");


        //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //EVERYTHING BELOW CREATES DATA IN THE FILE SendingTheData.htm 
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //

        StrngSendingDataHTM = StrngSendingDataHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngSendingDataHTM,
        @"<br></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><i><a href=""mailto:jogi1800@student.miun.se?subject=Data%20for%20Spider%20Experiment&amp;body=" +
        "Please send the following files which can be found at the following location (provided the path  has been created correctly, you can copy and paste it into explorer.)%0d%0a%0d%0a" +
        "Folder: " + startupPath +
        "%0d%0aTrialSessions1und2.txt" +
        "%0d%0aExpSession1.txt" +
        "%0d%0aExpSession2.txt" +
        "%0d%0aTrialSessions3und4.txt " +
        "%0d%0aExpSession3.txt" +
        "%0d%0aExpSession4.txt" +
        "%0d%0a%0d%0aPlease don't forget to send your Final Questionnaire Data which you can find in the same folder, either as Instructions+Debrief.PDF or as instructions.txt");
        StrngSendingDataHTM = StrngSendingDataHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngSendingDataHTM,
        @"""> jogi1800@student.miun.se</a></i></b>");


        StrngSendingDataHTM = StrngSendingDataHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngSendingDataHTM,
        "<br><br><br><b><big>Please also make sure you fill in the final questionnaire, which can be found as a pdf in the same folder: <br><br></big></b><i>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        "Application folder/..../SpiderExperimentV05R02_Data/FinalLog/" +
        "<br><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;I have tried to recreate the path to the folder (below) with the files. " +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        startupPath +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        "You can try copying and pasting this address into explorer." +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if that doesn't work you will have locate the files yourself in the application folder.");


        StrngSendingDataHTM = StrngSendingDataHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngSendingDataHTM,
        "<br><br><big><big><b>The questionnaire is also available as a htm form which " +
        "opens in your browser and can be found in the same folder as above.</big></big></b><br><br>");

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //ATTEMPTS TO CREATE A LINK TO THE FINAL QUESTIONNAIRE 
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        StrngSendingDataHTM = StrngSendingDataHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        StrngFinalQuestionnaireHref = StrngFinalQuestionnaireHref.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngSendingDataHTM,
        @"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i><a href=""" +
            StrngFinalQuestionnaireHref +
            @"""" +
        ">" + StrngFinalQuestionnaire +
        "</a>" +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Also here, I have attempted to create a link the file automatically." +
        "</i><br><br><br><br><br><br><br><br><br><br><br><br>" +
        "</body>" +
        "</html>");

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //EVERYTHING BELOW CREATES DATA IN THE FILE FinalQuestionnaire.htm 
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++

        StrngFinalQuestionnaire = StrngFinalQuestionnaire.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngFinalQuestionnaire,
        @"<br></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><i><a href=""mailto:jogi1800@student.miun.se?subject=Data%20for%20Spider%20Experiment&amp;body=" +
        "Please send the following files which can be found at the following location (provided the path  has been created correctly, you can copy and paste it into explorer.)%0d%0a%0d%0a" +
        "Folder: " + startupPath +
        "%0d%0aTrialSessions1und2.txt" +
        "%0d%0aExpSession1.txt" +
        "%0d%0aExpSession2.txt" +
        "%0d%0aTrialSessions3und4.txt " +
        "%0d%0aExpSession3.txt" +
        "%0d%0aExpSession4.txt" +
        "%0d%0a%0d%0aPlease don't forget to send your Final Questionnaire Data which you can find in the same folder, either as Instructions+Debrief.PDF or as instructions.txt");
        StrngFinalQuestionnaire = StrngFinalQuestionnaire.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngFinalQuestionnaire,
        @"""> jogi1800@student.miun.se</a></i></b>" +
               "<br><br>&nbsp;&nbsp;Alternatively, if the link does not work. you can copy and paste it into an email." +
        "<br><br>&nbsp;&nbsp;<br><br><big><big><input name=" +
        @"""Please press to send your answers"" type=""submit"" VALUE=""CLICK THIS BUTTON TO SEND!"" /> <br></big></big>" +
        "&nbsp;&nbsp;If the transmission fails and you get a different message, use the back button in your browser to return to the form and try again. " +
        "<br>&nbsp;&nbsp;If it still doesn't work, please send an email to the email adress above.</i><br>" +
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //8 Questions
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        "&nbsp;&nbsp;&nbsp;&nbsp;<big><big><b><br>answer the following 8 questions.</u></big></big></big></b><br><br><br>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;<b>" +
        "1. Was it difficult to ignore the images? <br><br></b>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //This is a single radio button
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        "<input type=" +
        @"""radio"" name=""radio1"" value=""Yes"">Yes" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=" +
        @"""radio"" name=""radio1"" value=""No"">No<br><br> <br>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;<b>2. How often did you look? <br><br></b>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //This is a series of radio buttons
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        StrngFinalQuestionnaire = StrngFinalQuestionnaire.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(StrngFinalQuestionnaire,
                @"<input type=""radio"" name=""radio2"" value=""not at all"">not at all" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=" +
                @"""radio"" name=""radio2"" value=""seldom"">seldom" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=" +
                @"""radio"" name=""radio2"" value=""sometimes"">sometimes &nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=" +
                @"""radio"" name=""radio2"" value=""often"">often" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=" +
                @"""radio"" name=""radio2"" value=""all the time"">all the time<br><br> <br>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;<b>3. Did you experience fear during this experiment? <br><br></b>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=" +
                @"""radio"" name=""radio3"" value=""not at all"">not at all" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=" +
                @"""radio"" name=""radio3"" value=""seldom"">seldom" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=" +
                @"""radio"" name=""radio3"" value=""sometimes"">sometimes" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;<input type=" +
                @"""radio"" name=""radio3"" value=""often"">often" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                "<input type=" +
                @"""radio"" name=""radio3"" value=""all the time"">all the time<br><br> <br>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;<b>4. If you experienced fear, how intense was it? <br><br></b>" +

                @"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio4"" value=""very low"">very low
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio4"" value=""low"">low
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio4"" value=""medium"">medium
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio4"" value=""high"">high
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio4"" value=""very high"">very high<br><br> <br> 
        &nbsp;&nbsp;&nbsp;&nbsp;<b>" +

                @"5. Did you experience disgust during this experiment? <br><br></b>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                @"<input type=""radio"" name=""radio5"" value=""not at all"">not at all
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio5"" value=""seldom"">seldom
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio5"" value=""sometimes"">sometimes
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio5"" value=""often"">often
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio5"" value=""all the time"">all the time<br><br> <br> 
        &nbsp;&nbsp;&nbsp;&nbsp;<b>

        6. If you experienced disgust, how intense was it? <br><br></b>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <input type=""radio"" name=""radio6"" value=""very low"">very low
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio6"" value=""low"">low
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio6"" value=""medium"">medium
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio6"" value=""high"">high
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio6"" value=""very high"">very high<br><br> <br> 
        &nbsp;&nbsp;&nbsp;&nbsp;<b>

        7. Were you startled during this experiment? <br><br></b>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <input type=""radio"" name=""radio7"" value=""not at all"">not at all
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio7"" value=""seldom"">seldom
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio7"" value=""sometimes"">sometimes
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio7"" value=""often"">often
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio7"" value=""all the time"">all the time<br><br> <br> 
        &nbsp;&nbsp;&nbsp;&nbsp;<b>

        8. If you were startled, how intense was it? <br><br></b>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio8"" value=""very low"">very low
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio8"" value=""low"">low
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio8"" value=""medium"">medium
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio8"" value=""high"">high
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type=""radio"" name=""radio8"" value=""very high"">very high<br><br> <br> 

	
        <b> 
        <big>Please go back to the top and send your answers? And please don't forget to send us your data as well. <br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>

        </body></html>");


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        AddStrngDeBrief = AddStrngDeBrief.Replace(@"/", @"\");   // explorer doesn't like front slashes
        File.AppendAllText(AddStrngDeBrief,
@"Evolution has given us not only the physical characteristics of our ancestors, but also specific aspects of their " +
 "behaviour. This experiment focuses on one aspect of apparently inherited behaviour, that is the emotional reactions to " +
 "spiders, which are thought to be of value for survival. Since spiders are potentially dangerous animals, it makes " +
 "sense that our ancestors will have adapted specific abilities to see them and act accordingly. Most of " +
 "the research on this matter has focused on central presentation of images of spiders and snakes. This experiment, " +
 "on the other hand, focuses on peripheral images. While a task is being performed, the spiders are shown at the side " +
 "of the visual field and measurements are taken in order to see whether participants look more readily towards spiders " +
 "or neutral stimuli (mushrooms.) This research hypothesised that the participants would look more quickly and more often " +
 "at spiders presented in the periphery than at mushrooms and that the pupil size would also grow, indicating emotional " +
 "reaction, even if this emotional reaction is not perceived consciously. This experiment thus focuses on two aspects of psychology:" +
 "\r\n\r\n evolutionary psychology and inherited (phylogenetic) behaviours \r\n emotions as subconscious phenomena.\r\n\r\n" +
 "I (Joseph Given, the Student Researcher) am very grateful to you for your participation in this experiment, within the scope of the master in emotional " +
 "psychology.If you have any further questions on the research or later on the results, then please send me an email " +
 "at jogi1800@student.miun.se and I will try to answer any questions you may have.\r\n My Professor Fredrik Åhs is also " +
 "available if you have any specific points you would like to raise with him about your participation " +
 "in this research.");


        IntFinishHTM++;
        IntFinishHTM++;
    }
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //Probably no longer required
    public void ShowExplorer()
    {
        startupPath = startupPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        //System.Diagnostics.Process.Start("explorer.exe", startupPath);
        Application.OpenURL("file:" + "//" + startupPath + "FinalLog/FinalLog.txt");

        // Update is called once per frame
    }
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


    void OpenTheHTM()
    {
        StrngInstructionsHTM = StrngInstructionsHTM.Replace(@"/", @"\");   // explorer doesn't like front slashes
        System.Diagnostics.Process.Start(StrngInstructionsHTM);
    }
    void GetLog()
    {
        startupPath = startupPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        System.Diagnostics.Process.Start(startupPath);
    }


    // Update is called once per frame
    void Update()
    {


        if (ExperimentalProcedure.BoolendOfTaskHard == true)
        {
            IntFinishHTM++;
            if (IntFinishHTM == 2)
            {
                IntFinishHTM++;
                FunctionTimer.Create(Wait, 2f, "WaitingTime");

            }
            Start();

        }
        else
        {
            TextendOfTaskHard.SetActive(false);
        }



        //ToEnd


        if (OpenHTMFile == 1)
        {
            OpenHTMFile = 0;
            OpenTheHTM();
        }

        if (GetTheLog == 1)
        {
            GetTheLog = 0;
            GetLog();
        }

    }
}
