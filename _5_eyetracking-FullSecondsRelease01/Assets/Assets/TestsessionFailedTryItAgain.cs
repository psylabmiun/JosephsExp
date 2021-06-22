using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskPartOne;
                ExperimentalProcedure.BooltaskInstruction = false;
                ExperimentalProcedure.BooltaskScoreNotSufficient = false;
                TaskInstructionScript.BoolBeenHereBefore = false;
                BoolReadySet1 = true;
                ExperimentalProcedure.BooltaskPartOne = false;
                FunctionTimer.Create(SetBoolBack, 0f, "SetTrialSet1BoolBack");
                Debug.Log("------------------------------------------THIS IS TrialSet1/Init(if (Input.GetKeyDown(KeyCode.Return)))");
            }

        }
    }


    private void SetBoolBack()
    {
        Debug.Log("------------------------------------------THIS IS TrialSet1/SetBoolBack()" + ExperimentalProcedure.BooltaskPartOne);
        FunctionTimer.StopTimer("SetTrialSet1BoolBack");
        BoolReadySet1 = false;
    }

    // Update is called once per frame
    void Update()
    {
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
