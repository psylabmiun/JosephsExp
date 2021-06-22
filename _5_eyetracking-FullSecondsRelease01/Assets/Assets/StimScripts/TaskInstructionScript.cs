//+++++++++
//TaskInstructionScript.cs
//+++++++++
//Instructions for EASY Task
//Workflow to start practice runs EASY TASK 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInstructionScript : MonoBehaviour
{
    public ExperimentalProcedure experimentalProcedure;
    public TestsessionFailedTryItAgain testsessionFailedTryItAgain;
    public TaskTestSession taskTestSession;

    public GameObject textObject01;
    public GameObject textObject02;
    public GameObject textObject03;
    public GameObject textObject04;
    public GameObject textObject05;
    public GameObject textObject06;
    public GameObject textObject07;
    public GameObject FixationExample01;
    public GameObject TaskAExample;
    public GameObject TaskBExample;

    public enum InstructText
    {
        InstructStage00,
        InstructStage01,
        InstructStage02,
        InstructStage03,
        InstructStage04,
        InstructStage05,
        InstructStage06,
        InstructStage07,
        InstructStage08,
        InstructStage09
    }
    public InstructText instructText;
    private bool BoolInstructText01;
    private bool BoolInstructText02;
    private bool BoolInstructText03;
    private bool BoolInstructText04;
    private bool BoolInstructText05;
    private bool BoolInstructText06;
    private bool BoolInstructText07;
    private bool BoolInstructText08;
    private bool BoolInstructText09;
    public static bool BoolBeenHereBefore;

    public static bool ReadyTrials01;

    // Start is called before the first frame update
    void Start()
    {

        ReadyTrials01 = false;
        textObject01.SetActive(false);
        textObject02.SetActive(false);
        textObject03.SetActive(false);
        textObject04.SetActive(false);
        textObject05.SetActive(false);
        textObject06.SetActive(false);
        textObject07.SetActive(false);
        FixationExample01.SetActive(false);
        TaskAExample.SetActive(false);
        TaskBExample.SetActive(false);

    }

    void Update()
        {

        if (TaskTestSession.TaskLeft % 2 == 1)
        {
            FixationExample01.transform.localPosition = new Vector3(8.25f, 0.22f, 0f);
            TaskAExample.transform.localPosition = new Vector3(8.25f, 0.22f, 0f);
            TaskBExample.transform.localPosition = new Vector3(8.25f, 0.22f, 0f);
        }
        else
        {
            FixationExample01.transform.localPosition = new Vector3(-8.25f, 0.22f, 0f);
            TaskAExample.transform.localPosition = new Vector3(-8.25f, 0.22f, 0f);
            TaskBExample.transform.localPosition = new Vector3(-8.25f, 0.22f, 0f);
        }


        if (ExperimentalProcedure.BooltaskInstruction == false)
        {
            textObject01.SetActive(false);
            textObject02.SetActive(false);
            textObject03.SetActive(false);
            textObject04.SetActive(false);
            textObject05.SetActive(false);
            textObject06.SetActive(false);
            textObject07.SetActive(false);
            FixationExample01.SetActive(false);
            TaskAExample.SetActive(false);
            TaskBExample.SetActive(false);

        }
        else if (ExperimentalProcedure.BooltaskInstruction == true)
            {
            Start();

            switch (instructText)
            {
                case InstructText.InstructStage00:
                    textObject01.SetActive(true);
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText01 = true;
                        BoolInstructText02 = true;
                        instructText = InstructText.InstructStage02;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        instructText = InstructText.InstructStage00;
                    }
                    break;

                case InstructText.InstructStage01: //Text inactive: "Instructions for "N-back task (n=1)"
                    if (BoolBeenHereBefore == true)
                    {
                        instructText = InstructText.InstructStage00;
                        Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                        //These have been removed
                        //TestsessionFailedTryItAgain.BoolTimerFail1 = false;
                        //TestsessionFailedTryItAgain.BoolTimerFail2 = false;
                        //TestsessionFailedTryItAgain.BoolTimerFail3 = false;

                    }
                    break;

                case InstructText.InstructStage02: //InstructStage02 : The cross sign + appears  and disappears after three seconds
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObject01.SetActive(true);
                    textObject02.SetActive(true);
                    FixationExample01.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolBeenHereBefore = false;// explicitly placing this a couple of steps down.

                        BoolInstructText02 = false;
                        BoolInstructText03 = true;
                        instructText = InstructText.InstructStage03;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObject02.SetActive(false);
                        FixationExample01.SetActive(false);
                        TaskAExample.SetActive(true);
                        instructText = InstructText.InstructStage00;
                    }
                    break;

                case InstructText.InstructStage03: //InstructStage03  : After a brief pause it is then replaced by a letter 
                                                   //which is shown for 1 second. Remember the letter.
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObject01.SetActive(true);
                    textObject02.SetActive(true);
                    textObject03.SetActive(true);
                    FixationExample01.SetActive(false);
                    TaskAExample.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText03 = false;
                        BoolInstructText04 = true;
                        instructText = InstructText.InstructStage04;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObject03.SetActive(false);
                        TaskAExample.SetActive(false);
                        instructText = InstructText.InstructStage02;
                    }
                    break;

                case InstructText.InstructStage04: //InstructStage04 : After a brief pause it is replaced again
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObject01.SetActive(true);
                    textObject02.SetActive(true);
                    textObject03.SetActive(true);
                    textObject04.SetActive(true);
                    TaskAExample.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText04 = false;
                        BoolInstructText05 = true;

                        instructText = InstructText.InstructStage05;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObject04.SetActive(false);
                        TaskAExample.SetActive(false);
                        instructText = InstructText.InstructStage03;
                    }
                    break;

                case InstructText.InstructStage05: //InstructStage01 : //InstructStage04 : by another letter which is shown for 1 second. 
                                                   //If the next letter is the same press < yes >
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObject01.SetActive(true);
                    textObject02.SetActive(true);
                    textObject03.SetActive(true);
                    textObject04.SetActive(true);
                    textObject05.SetActive(true);
                    TaskAExample.SetActive(false);
                    TaskBExample.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText05 = false;
                        BoolInstructText06 = true;

                        instructText = InstructText.InstructStage06;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObject05.SetActive(false);
                        TaskAExample.SetActive(false);
                        TaskBExample.SetActive(false);
                        instructText = InstructText.InstructStage04;
                    }
                    break;

                case InstructText.InstructStage06: //InstructStage01: If it is not the same, press <no>. Any other images on the screen are only distractors.
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObject01.SetActive(true);
                    textObject02.SetActive(true);
                    textObject03.SetActive(true);
                    textObject04.SetActive(true);
                    textObject05.SetActive(true);
                    textObject06.SetActive(true);
                    TaskAExample.SetActive(false);
                    TaskBExample.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText06 = false;
                        BoolInstructText07 = true;
                        instructText = InstructText.InstructStage07;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObject06.SetActive(false);
                        TaskBExample.SetActive(true);
                        instructText = InstructText.InstructStage05;
                    }
                    break;

                case InstructText.InstructStage07: //InstructStage01 : Remember: it is important to perform the task as accurately and completely as possible. 
                                                   //When you have finished reading, press  < yes > for a test run.
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObject01.SetActive(false);
                    textObject02.SetActive(false);
                    textObject03.SetActive(false);
                    textObject04.SetActive(false);
                    textObject05.SetActive(false);
                    textObject06.SetActive(false);
                    TaskBExample.SetActive(false);
                    textObject07.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        textObject07.SetActive(false);
                        TaskBExample.SetActive(false);

                        BoolInstructText07 = false;
                        BoolInstructText08 = true;
                        instructText = InstructText.InstructStage08;

                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObject01.SetActive(true);
                        textObject02.SetActive(true);
                        textObject03.SetActive(true);
                        textObject04.SetActive(true);
                        textObject05.SetActive(true);
                        textObject06.SetActive(true);
                        textObject07.SetActive(false);
                        TaskBExample.SetActive(false);
                        instructText = InstructText.InstructStage06;
                    }
                    break;
                case InstructText.InstructStage08:
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObject01.SetActive(false);
                    textObject02.SetActive(false);
                    textObject03.SetActive(false);
                    textObject04.SetActive(false);
                    textObject05.SetActive(false);
                    textObject06.SetActive(false);
                    textObject07.SetActive(false);
                    TaskBExample.SetActive(false);

                    BoolInstructText08 = false;
                    BoolInstructText09 = true;
                    ReadyTrials01 = true;
                    instructText = InstructText.InstructStage09;
                    break;
                case InstructText.InstructStage09:
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    SetBoolReadyTrials01Back();
                    break;

            }

        }


    }

    public void SetBoolReadyTrials01Back()
    {
        ReadyTrials01 = false;
        BoolInstructText09 = false;
        instructText = InstructText.InstructStage01;
        Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " SetBoolReadyTrials01Back" + instructText);

    }
}