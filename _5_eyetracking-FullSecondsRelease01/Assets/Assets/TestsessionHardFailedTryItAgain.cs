using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsessionHardFailedTryItAgain : MonoBehaviour
{
    public ExperimentalProcedure experimentalProcedureScript;
    public TaskHardInstructionScript taskHardInstructionScript;
    public TestsessionSuccess testsessionSuccess;
    public TaskTestSession taskTestSession;

    public GameObject TextTestSessionHardFailedOnce;
    public GameObject TextTestSessionHarddFailedTwice;
    public static bool BooltestSessionHardFailedOnce = false;
    public static bool BooltestSessionHardFailedTwice = false;
    public static bool BoolHardReadySet1;

    void Start()
    {
        TaskTestSession.BoolTrialIsOn = false;
        Debug.Log("------------------------------------------THIS IS  " + "TestsessionFailedTryItAgain / Start() ");

        if (TaskTestSession.IntTrialNo == 5)//Check this
        {
            Debug.Log("------------------------------------------THIS IS  " + "TestsessionFailedTryItAgain(TaskTestSession.IntTrialNo == 1) " + "IntTrialNo=" + TaskTestSession.IntTrialNo);
            TextTestSessionHardFailedOnce.SetActive(true);
            TextTestSessionHarddFailedTwice.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskHardInstruction;
                ExperimentalProcedure.BooltaskHardInstruction = true;
                ExperimentalProcedure.BooltaskHardScoreNotSufficient = false;
                TaskHardInstructionScript.BoolBeenHereBeforeHard = true;
                BooltestSessionHardFailedTwice = true;
            }
        }

        else if (TaskTestSession.IntTrialNo == 6)
        {
            Debug.Log("------------------------------------------THIS IS  " + "TestsessionFailedTryItAgain(TaskTestSession.IntTrialNo == 2) " + "IntTrialNo=" + TaskTestSession.IntTrialNo);
            TextTestSessionHardFailedOnce.SetActive(false);
            TextTestSessionHarddFailedTwice.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskHardPartOne;
                ExperimentalProcedure.BooltaskHardInstruction = false;
                ExperimentalProcedure.BooltaskHardScoreNotSufficient = false;
                TaskHardInstructionScript.BoolBeenHereBeforeHard = false;
                BoolHardReadySet1 = true;
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
        BoolHardReadySet1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ExperimentalProcedure.BooltaskHardScoreNotSufficient == true)
        {
            Start();
        }
        else
        {
            TextTestSessionHardFailedOnce.SetActive(false);
            TextTestSessionHarddFailedTwice.SetActive(false);
        }
    }
}
