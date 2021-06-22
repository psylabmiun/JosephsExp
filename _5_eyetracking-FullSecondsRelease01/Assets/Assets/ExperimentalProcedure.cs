using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ExperimentalProcedure : MonoBehaviour
{

    public ClickDataProt clickDataProt; //script ClickDataProt.cs
    public TaskInstructionScript taskInstructionScript;
    public TaskTestSession taskTestSession;
    public TestsessionFailedTryItAgain testsessionFailedTryItAgain;

    //public string password;

    public static bool Bool_startGreeting;

    public static bool Bool_dataProtection;


    public static bool Bool_questionnaireSPQ;
    public static bool Bool_scoreSufficient;
    public static bool Bool_requestCode;
    public static bool Bool_rejectParticipant;
    public static bool BooltaskInstruction;
    public static bool BooltaskCalibration;
    public static bool BooltaskTestSession;
    public static bool BooltaskScoreSufficient;
    public static bool BooltaskScoreNotSufficient;
    public static bool BooltaskPartOne;
    public static bool BooltaskPartTwo;
    public static bool BoolendOfTaskEasy;
    public static bool BooltaskHardInstruction;
    public static bool BooltaskHardTestSession;
    public static bool BooltaskHardScoreSufficient;
    public static bool BooltaskHardScoreNotSufficient;
    public static bool BoolsendResults;
    public static bool BooltaskHardPartOne;
    public static bool BooltaskHardPartTwo;
    public static bool BoolendOfTaskHard;
    public static bool Booldebrief;
    public static bool BoolcontactCompensation;
    public static bool BoolfinalWords;
    public static bool BoolcloseExperiment;


    public enum ExpProc
    {
/*        _startGreeting,
        _dataProtection,
        _questionnaireSPQ,*///this has been solved differently now
        _scoreSufficient,
        _requestCode,
        _rejectParticipant,
        taskInstruction,
        taskCalibration,
        taskTestSession,
        taskScoreSufficient,
        taskScoreNotSufficient,
        taskPartOne,
        taskPartTwo,
        taskHardInstruction,
        taskHardTestSession,
        testHardScoreSufficient,
        testHardScoreNotSufficient,
        taskHardPartOne,
        taskHardPartTwo,
        endOfTaskHard,
        endOfTaskEasy,
        sendResults,
        debrief,
        contactCompensation,
        finalWords,
        closeExperiment
    }

    public static ExpProc expProc;


    private void Start()
    {
/*        expProc = ExpProc._startGreeting;

        Bool_startGreeting = false;
        Bool_dataProtection = false;
        Bool_questionnaireSPQ = false;*///this has been solved differently now
        Bool_scoreSufficient = false;
        Bool_requestCode = false;
        Bool_rejectParticipant = false;
        BooltaskInstruction = false;
        BooltaskCalibration = false;
        BooltaskTestSession = false;
        BooltaskScoreSufficient = false;
        BooltaskScoreNotSufficient = false;
        BooltaskPartOne = false;
        BooltaskPartTwo = false;
        BoolendOfTaskEasy = false;
        BooltaskHardInstruction = false;
        BooltaskHardTestSession = false;
        BooltaskHardScoreSufficient = false;
        BooltaskHardScoreNotSufficient = false;
        BooltaskHardPartOne = false;
        BooltaskHardPartTwo = false;
        BoolsendResults = false;
        Booldebrief = false;
        BoolcontactCompensation = false;
        BoolfinalWords = false;
        BoolcloseExperiment = false;

    }



    /*Switch statement required */





    void Update ()
    {
        switch (expProc)
        {
/*            case ExpProc._startGreeting:
                Debug.Log("------------------------------------------THIS IS (BeginHere) " + expProc);
                Bool_startGreeting = true;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    expProc = ExpProc._dataProtection;
                    Bool_startGreeting = false;
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    expProc = ExpProc.taskInstruction;
                    Bool_startGreeting = false;
                }
                break;

            case ExpProc._dataProtection:
                Debug.Log("------------------------------------------THIS IS (dataProt) " + expProc);
                Bool_dataProtection = true;
                break;

            case ExpProc._questionnaireSPQ:
                Bool_questionnaireSPQ = true;
                Debug.Log("------------------------------------------THIS IS (QuesSPQ) " + expProc);
                break;

            //            case ExpProc._scoreSufficient:
            //                Debug.Log("------------------------------------------THIS IS (Score Sufficient) " + expProc);
            //                break;

*/            case ExpProc._requestCode:
                Bool_requestCode = true;
                Bool_questionnaireSPQ = false;
                Debug.Log("------------------------------------------THIS IS (RequestCode) " + expProc);
                if (Input.GetKeyDown(KeyCode.M))
                {
                    expProc = ExpProc.taskCalibration;
                    Bool_requestCode = false;
                }
                break;
            case ExpProc._rejectParticipant:
                Bool_rejectParticipant = true;
                Bool_questionnaireSPQ = false;
                Debug.Log("------------------------------------------THIS IS (RejectParticipant) " + expProc);
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
                break;
            case ExpProc.taskCalibration:
                Debug.Log("------------------------------------------THIS IS (TaskCalib) " + expProc);
                BooltaskCalibration = true;
                if (BooltaskInstruction == true)
                {
                    expProc = ExpProc.taskInstruction;
                    BooltaskCalibration = false;
                }
                break;
            case ExpProc.taskInstruction:
                 BooltaskInstruction = true;
                if (BooltaskTestSession == true)
                {
                    expProc = ExpProc.taskTestSession;
                    BooltaskInstruction = false;
                }
                break;
            case ExpProc.taskTestSession:
                Debug.Log("------------------------------------------THIS IS (TaskTestSession) " + expProc);
                BooltaskTestSession = true;
                if (BooltaskScoreSufficient)
                {
                    expProc = ExpProc.taskScoreSufficient;
                    BooltaskTestSession = false;
                }
                else if (!BooltaskScoreSufficient)
                {
                    expProc = ExpProc.testHardScoreNotSufficient;
                    BooltaskHardTestSession = false;
                    BooltaskHardScoreSufficient = false;
                    BooltaskHardScoreNotSufficient = true;
                    expProc = ExpProc.testHardScoreNotSufficient;
                }
                else if (BooltaskHardScoreSufficient)
                {
                    expProc = ExpProc.testHardScoreSufficient;
                    BooltaskHardTestSession = false;
                }
                else if (!BooltaskHardScoreSufficient)
                {
                    expProc = ExpProc.testHardScoreNotSufficient;
                    BooltaskHardTestSession = false;
                    BooltaskHardScoreSufficient = false;
                    BooltaskHardScoreNotSufficient = true;
                    expProc = ExpProc.testHardScoreNotSufficient;
                }
                break;
            case ExpProc.taskScoreSufficient:
                BooltaskScoreSufficient = true;//not finished
                break;

            case ExpProc.taskScoreNotSufficient:
                BooltaskScoreSufficient = false;
                break;

            case ExpProc.taskPartOne:
                BooltaskScoreSufficient = false;
                break;
            case ExpProc.taskPartTwo:
                BooltaskPartOne = false;
                break;
            case ExpProc.endOfTaskEasy:
                BoolendOfTaskEasy = false;
                break;
            case ExpProc.taskHardInstruction:
                BooltaskHardInstruction = true;
                if (BooltaskHardTestSession == true)
                {
                    expProc = ExpProc.taskHardTestSession;
                    BooltaskHardInstruction = false;
                }
                break;
            case ExpProc.testHardScoreSufficient:
                BooltaskHardScoreNotSufficient = false;
                break;

            case ExpProc.testHardScoreNotSufficient:
                BooltaskHardScoreSufficient = false;
                break;
            case ExpProc.taskHardPartOne:
                BooltaskScoreSufficient = false;
                break;
            case ExpProc.taskHardPartTwo:
                BooltaskHardPartOne = false;
                break;
            case ExpProc.endOfTaskHard:
                BooltaskHardPartTwo = false;
                break;
            case ExpProc.sendResults:
                BoolsendResults = true;
                break;
            case ExpProc.debrief:
                Bool_startGreeting = false;
                Bool_dataProtection = false;
                Bool_questionnaireSPQ = false;
                Bool_scoreSufficient = false;
                Bool_requestCode = false;
                Bool_rejectParticipant = false;
                BooltaskInstruction = false;
                BooltaskCalibration = false;
                BooltaskTestSession = false;
                BooltaskScoreSufficient = false;
                BooltaskPartOne = false;
                BooltaskPartTwo = false;
                BoolsendResults = false;
                Booldebrief = true;
                BoolcontactCompensation = false;
                BoolfinalWords = false;
                BoolcloseExperiment = false;
                break;
            case ExpProc.contactCompensation:
                Bool_startGreeting = false;
                Bool_dataProtection = false;
                Bool_questionnaireSPQ = false;
                Bool_scoreSufficient = false;
                Bool_requestCode = false;
                Bool_rejectParticipant = false;
                BooltaskInstruction = false;
                BooltaskCalibration = false;
                BooltaskTestSession = false;
                BooltaskScoreSufficient = false;
                BooltaskPartOne = false;
                BooltaskPartTwo = false;
                BoolsendResults = false;
                Booldebrief = false;
                BoolcontactCompensation = true;
                BoolfinalWords = false;
                BoolcloseExperiment = false;
                break;
            case ExpProc.finalWords:
                Bool_startGreeting = false;
                Bool_dataProtection = false;
                Bool_questionnaireSPQ = false;
                Bool_scoreSufficient = false;
                Bool_requestCode = false;
                Bool_rejectParticipant = false;
                BooltaskInstruction = false;
                BooltaskCalibration = false;
                BooltaskTestSession = false;
                BooltaskScoreSufficient = false;
                BooltaskPartOne = false;
                BooltaskPartTwo = false;
                BoolsendResults = false;
                Booldebrief = false;
                BoolcontactCompensation = false;
                BoolfinalWords = true;
                BoolcloseExperiment = false;
                break;
            case ExpProc.closeExperiment:
                Bool_startGreeting = false;
                Bool_dataProtection = false;
                Bool_questionnaireSPQ = false;
                Bool_scoreSufficient = false;
                Bool_requestCode = false;
                Bool_rejectParticipant = false;
                BooltaskInstruction = false;
                BooltaskCalibration = false;
                BooltaskTestSession = false;
                BooltaskScoreSufficient = false;
                BooltaskPartOne = false;
                BooltaskPartTwo = false;
                BoolsendResults = false;
                Booldebrief = false;
                BoolcontactCompensation = false;
                BoolfinalWords = false;
                BoolcloseExperiment = true;
                break;
        }
        
    }
}
