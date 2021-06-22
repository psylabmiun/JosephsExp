using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsessionSuccess : MonoBehaviour
{
    public ExperimentalProcedure experimentalProcedureScript;
    public TaskInstructionScript taskInstructionScript;
    public TestsessionFailedTryItAgain testsessionFailedTryItAgain;
    public TestsessionHardFailedTryItAgain testsessionHardFailedTryItAgain;
    public TaskTestSession taskTestSession;

    public GameObject SuccessTestSession1;
    public GameObject SuccessTestSession2;
    public int TestSessionSuccessNumberOfTimes;
    public static bool BoolTestSession1Passed = false;
    public static bool BoolTestSession2Passed = false;

    void Start()
    {
        TaskTestSession.BoolTrialIsOn = false;
        BoolTestSession1Passed = true;
        if (TaskTestSession.IntTrialNo == 1)
        {
            SuccessTestSession1.SetActive(true);
            SuccessTestSession2.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskInstruction;
                ExperimentalProcedure.BooltaskInstruction = true;
                ExperimentalProcedure.BooltaskScoreNotSufficient = false;
                TaskInstructionScript.BoolBeenHereBefore = true;
                ExperimentalProcedure.BooltaskScoreSufficient = false;
                BoolTestSession2Passed = true;
            }

        }
        else if (TaskTestSession.IntTrialNo == 2)
        {
            SuccessTestSession1.SetActive(false);
            SuccessTestSession2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExperimentalProcedure.BooltaskScoreNotSufficient = false;
                ExperimentalProcedure.BooltaskScoreSufficient = false;
                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskPartOne;
                ExperimentalProcedure.BooltaskPartOne = true;
                TestsessionFailedTryItAgain.BoolReadySet1 = true;
                FunctionTimer.Create(SetBoolBack, 0f, "SetTrialSet1BoolBack");
                Debug.Log("------------------------------------------THIS IS TrialSet1/Start(else if (Input.GetKeyDown(KeyCode.Return)))");
            }

        }
    }

    private void SetBoolBack()
    {
        Debug.Log("------------------------------------------THIS IS TrialSet1/SetBoolBack()" + ExperimentalProcedure.BooltaskPartOne);
        FunctionTimer.StopTimer("SetTrialSet1BoolBack");
        SuccessTestSession2.SetActive(false);
        TestsessionFailedTryItAgain.BoolReadySet1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ExperimentalProcedure.BooltaskScoreSufficient)
        {
            Start();
        }
        else
        {
            SuccessTestSession1.SetActive(false);
            SuccessTestSession2.SetActive(false);

        }
    }
}
