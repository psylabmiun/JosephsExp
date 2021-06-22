//+++++++++
//TrialSet4
//+++++++++
//Message and start for Task 4 HARD
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrialSet4 : MonoBehaviour
{
    public ExperimentalProcedure experimentalProcedure;
    public TaskTestSession taskTestSession;
    public GameObject TextTrialSet4Go;
    public static bool BoolReadySet4;

    // Start is called before the first frame update
    void Init()
    {
        TaskTestSession.BoolTrialIsOn = false;
        TextTrialSet4Go.SetActive(true);
        Debug.Log("------------------------------------------THIS IS TrialSet4/Init() " + "IntTrialNo=" +
            TaskTestSession.IntTrialNo + "ExperimentalProcedure.BooltaskPartTwo=" + ExperimentalProcedure.BooltaskHardPartTwo);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TextTrialSet4Go.SetActive(false);
            BoolReadySet4 = true;
            FunctionTimer.Create(SetBoolBack, 0f, "SetTrialHardSet4BoolBack" + "IntTrialNo=" +
                TaskTestSession.IntTrialNo + "ExperimentalProcedure.BooltaskHardPartTwo=" + ExperimentalProcedure.BooltaskHardPartTwo);
        }
    }


    private void SetBoolBack()
    {
        FunctionTimer.StopTimer("SetTrialSet2BoolBack");
        Debug.Log("------------------------------------------THIS IS TrialSet4/SetBoolBack()" + "IntTrialNo=" +
            TaskTestSession.IntTrialNo + "ExperimentalProcedure.BooltaskHardPartTwo=" + ExperimentalProcedure.BooltaskHardPartTwo);
        TextTrialSet4Go.SetActive(false);
        BoolReadySet4 = false;
        ExperimentalProcedure.BooltaskHardPartTwo = false;
        ExperimentalProcedure.BooltaskHardPartOne = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (ExperimentalProcedure.BooltaskHardPartTwo == true)
        {
            Init();
        }
        else
        {
            TextTrialSet4Go.SetActive(false);
            BoolReadySet4 = false;
        }
    }
}
