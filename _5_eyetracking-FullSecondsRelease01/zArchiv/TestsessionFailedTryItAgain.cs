using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections.Specialized;

public class TestsessionFailedTryItAgain : MonoBehaviour
{
    public ExperimentalProcedure experimentalProcedureScript;
    public TaskInstructionScript taskInstructionScript;
    public TestsessionSuccess testsessionSuccess;
    public TaskTestSession taskTestSession;

    public GameObject TextTestSessionFailedOnce;
    public GameObject TextTestSessionFailedTwice;
    public static bool BoolTestSessionFailedOnce = false;
    public static bool BoolTestSessionFailedTwice = false;
    public static bool BoolReadySet1;
    public int IntFinishHTM;
    void Start()
    {
        TaskTestSession.BoolTrialIsOn = false;
        BoolTestSessionFailedOnce = true;
        Debug.Log("------------------------------------------THIS IS  " + "TestsessionFailedTryItAgain / Start() ");

        if (TaskTestSession.IntTrialNo == 1)
        {
            Debug.Log("------------------------------------------THIS IS  " + "TestsessionFailedTryItAgain(TaskTestSession.IntTrialNo == 1) " + "IntTrialNo=" + TaskTestSession.IntTrialNo);
            TextTestSessionFailedOnce.SetActive(true);
            TextTestSessionFailedTwice.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskInstruction;
                ExperimentalProcedure.BooltaskInstruction = true;
                ExperimentalProcedure.BooltaskScoreNotSufficient = false;
                TaskInstructionScript.BoolBeenHereBefore = true;
                BoolTestSessionFailedTwice = true;
            }
        }

        else if (TaskTestSession.IntTrialNo == 2)
        {
            Debug.Log("------------------------------------------THIS IS  " + "TestsessionFailedTryItAgain(TaskTestSession.IntTrialNo == 2) " + "IntTrialNo=" + TaskTestSession.IntTrialNo);
            TextTestSessionFailedOnce.SetActive(false);
            TextTestSessionFailedTwice.SetActive(true);
            IntFinishHTM++;
            IncreaseIntFinishHTM();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskPartOne;
                ExperimentalProcedure.BooltaskInstruction = false;
                ExperimentalProcedure.BooltaskScoreNotSufficient = false;
                TaskInstructionScript.BoolBeenHereBefore = false;
                BoolReadySet1 = true;
                ExperimentalProcedure.BooltaskPartOne = false;
                FunctionTimer.Create(IncreaseIntFinishHTM, 0f, "SetTrialSet1BoolBack");
                Debug.Log("------------------------------------------THIS IS TrialSet1/Init(if (Input.GetKeyDown(KeyCode.Return)))");
            }

        }
    }


    private void IncreaseIntFinishHTM()
    {
        Debug.Log("------------------------------------------THIS IS TrialSet1/SetBoolBack()" + ExperimentalProcedure.BooltaskPartOne);
        FunctionTimer.StopTimer("SetTrialSet1BoolBack");
        IntFinishHTM++;
        BoolReadySet1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IntFinishHTM == 2)
            {
            File.AppendAllText(Application.dataPath + "/FinalLog/webform/gradtest/SendingTheData.htm", IntFinishHTM++ 
+ "You can find the log files on your hard drive here<br><br>"
+ "<big>" + File.AppendAllText(Application.dataPath + "/FinalLog/<br>"
+ "<a href=""file:///" + File.AppendAllText(Application.dataPath + "/FinalLog/""" + "</a>"
+ "please do not change these files in anway or we cannot decrypt them."
+ "<br><br>"
+ "<br>The files required are as follows" 
+ "<br>ExpSession1.txt"
+ "<br>ExpSession2.txt"
+ "<br>ExpSession3.txt"
+ "<br>ExpSession4.txt"
+ "<br>TrialSessions1und2.txt"
+ "<br>TrialSessions3und4.txt"
+ "<br>In addition you will find this questionnaire as a PDF, in case you prefer to fill it out offline."
+ "<br><br><br>"
+ "</form >"
+ "<a href=""#top"">Now click here to return to the top of page. Check your details and click the ""send"" button.</a>"
+ "<br><br><br>"
+ 	"&nbsp;&nbsp Data protection clause <a href=""https://www.given-communication.de/Haftungsausschluss-en.html"" target=""_blank""" + ">(Data protection clause here, opens in a new window)</a></i><br>"
+ "</body>"
+ "</html>");
        }

        if (ExperimentalProcedure.BooltaskScoreNotSufficient == true)
        {
            Start();

        }
        else
        {
            TextTestSessionFailedOnce.SetActive(false);
            TextTestSessionFailedTwice.SetActive(false);
        }
    }
}
