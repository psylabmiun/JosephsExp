using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSessionEasyConcluded : MonoBehaviour
{
    public TaskTestSession taskTestSession;
    public GameObject TextendOfTaskEasy;
    public ExperimentalProcedure experimentalProcedure;
    // Start is called before the first frame update
    void Start()
    {
        TaskTestSession.BoolTrialIsOn = false;
        TextendOfTaskEasy.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskHardInstruction;
            ExperimentalProcedure.BooltaskHardInstruction = true;
            ExperimentalProcedure.BooltaskHardScoreNotSufficient = false;
            ExperimentalProcedure.BooltaskHardScoreSufficient = false;
            ExperimentalProcedure.BoolendOfTaskEasy = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ExperimentalProcedure.BoolendOfTaskEasy == true)
        {
            Start();
        }
        else
        {
            TextendOfTaskEasy.SetActive(false);

        }

    }
}
