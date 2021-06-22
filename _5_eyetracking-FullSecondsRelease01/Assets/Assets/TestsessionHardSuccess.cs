using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsessionHardSuccess : MonoBehaviour
{
    public ExperimentalProcedure experimentalProcedureScript;
    public TaskHardInstructionScript taskHardInstructionScript;
    public TestsessionHardFailedTryItAgain testsessionHardFailedTryItAgain;
    public TaskTestSession taskTestSession;

    public GameObject SuccessTestSessionHard1;
    public GameObject SuccessTestSessionHard2;
    public int TestSessionHardSuccessNumberOfTimes;
    public static bool BoolTestSessionHard1Passed;
    public static bool BoolTestSessionHard2Passed;

    void Start()
    {
        TaskTestSession.BoolTrialIsOn = false;
        BoolTestSessionHard1Passed = true;
        if (TaskTestSession.IntTrialNo == 5)
        {
Debug.Log("------------------------------------------THIS IS  " + "TestSessionHardSuccess/Start() " + "IntTrialNo=" + TaskTestSession.IntTrialNo);

            SuccessTestSessionHard1.SetActive(true);
            SuccessTestSessionHard2.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskHardInstruction;
                ExperimentalProcedure.BooltaskHardInstruction = true;
                ExperimentalProcedure.BooltaskHardScoreNotSufficient = false;
                TaskHardInstructionScript.BoolBeenHereBeforeHard = true;
                ExperimentalProcedure.BooltaskHardScoreSufficient = false;
                BoolTestSessionHard2Passed = true;
            }

        }
        else if (TaskTestSession.IntTrialNo == 6)
        {
            SuccessTestSessionHard1.SetActive(false);
            SuccessTestSessionHard2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExperimentalProcedure.BooltaskHardScoreNotSufficient = false;
                ExperimentalProcedure.BooltaskHardScoreSufficient = false;
                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskHardPartOne;
                TestsessionHardFailedTryItAgain.BoolHardReadySet1 = true;
                ExperimentalProcedure.BooltaskHardPartOne = false;
                FunctionTimer.Create(SetBoolBack, 0f, "SetTrialSet1BoolBack");
                Debug.Log("------------------------------------------THIS IS TrialSet1/Init(if (Input.GetKeyDown(KeyCode.Return)))");
            }

        }
    }


    private void SetBoolBack()
    {
        Debug.Log("------------------------------------------THIS IS TrialSet1/SetBoolBack()" + ExperimentalProcedure.BooltaskHardPartOne);
        FunctionTimer.StopTimer("SetTrialSet1BoolBack");
        TestsessionHardFailedTryItAgain.BoolHardReadySet1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ExperimentalProcedure.BooltaskHardScoreSufficient)
        {
            Start();
        }
        else
        {
            SuccessTestSessionHard1.SetActive(false);
            SuccessTestSessionHard2.SetActive(false);

        }
    }
}
