//+++++++++
//TaskHardInstructionScript.cs
//+++++++++
//Instructions for HARD Task
//Workflow to start practice runs HARD TASK 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHardInstructionScript : MonoBehaviour
{
    public ExperimentalProcedure experimentalProcedure;
    public TestsessionFailedTryItAgain testsessionFailedTryItAgain;
    public TaskTestSession taskTestSession;

    public GameObject textObjectHard01;
    public GameObject textObjectHard02;
    public GameObject textObjectHard03;
    public GameObject textObjectHard04;
    public GameObject textObjectHard05;
    public GameObject textObjectHard06;
    public GameObject textObjectHard07;
    public GameObject FixationExample01;
    public GameObject TaskHardAExample;
    public GameObject TaskHardBExample;

    public enum InstructText
    {
        InstructHardStage00,
        InstructHardStage01,
        InstructHardStage02,
        InstructHardStage03,
        InstructHardStage04,
        InstructHardStage05,
        InstructHardStage06,
        InstructHardStage07,
        InstructHardStage08,
        InstructHardStage09
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
    public static bool BoolBeenHereBeforeHard;


    public static bool ReadyHardTrials01;

    // Start is called before the first frame update
    void Start()
    {

        ReadyHardTrials01 = false;
        textObjectHard01.SetActive(false);
        textObjectHard02.SetActive(false);
        textObjectHard03.SetActive(false);
        textObjectHard04.SetActive(false);
        textObjectHard05.SetActive(false);
        textObjectHard06.SetActive(false);
        textObjectHard07.SetActive(false);
        FixationExample01.SetActive(false);
        TaskHardAExample.SetActive(false);
        TaskHardBExample.SetActive(false);

    }

    void Update()
    {

        if (TaskTestSession.TaskLeft % 2 == 1)
        {
            FixationExample01.transform.localPosition = new Vector3(8.25f, 0.22f, 1.4f);
            TaskHardAExample.transform.localPosition = new Vector3(8.25f, 0.22f, 1.4f);
            TaskHardBExample.transform.localPosition = new Vector3(8.25f, 0.22f, 1.4f);
        }
        else
        {
            FixationExample01.transform.localPosition = new Vector3(-8.25f, 0.22f, 1.4f);
            TaskHardAExample.transform.localPosition = new Vector3(-8.25f, 0.22f, 1.4f);
            TaskHardBExample.transform.localPosition = new Vector3(-8.25f, 0.22f, 1.4f);
        }


        if (ExperimentalProcedure.BooltaskHardInstruction == false)
        {
            textObjectHard01.SetActive(false);
            textObjectHard02.SetActive(false);
            textObjectHard03.SetActive(false);
            textObjectHard04.SetActive(false);
            textObjectHard05.SetActive(false);
            textObjectHard06.SetActive(false);
            textObjectHard07.SetActive(false);
            FixationExample01.SetActive(false);
            TaskHardAExample.SetActive(false);
            TaskHardBExample.SetActive(false);

        }
        else if (ExperimentalProcedure.BooltaskHardInstruction == true)
        {
            Start();

            switch (instructText)
            {
                case InstructText.InstructHardStage00:
                    textObjectHard01.SetActive(true);
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText01 = true;
                        BoolInstructText02 = true;
                        instructText = InstructText.InstructHardStage02;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        instructText = InstructText.InstructHardStage00;
                    }
                    break;

                case InstructText.InstructHardStage01: //Text inactive: "Instructions for "N-back task (n=1)"
                    if (BoolBeenHereBeforeHard == true)
                    {
                        instructText = InstructText.InstructHardStage00;
                        Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                        //These have been removed
                        //TestsessionFailedTryItAgain.BoolTimerFail1 = false;
                        //TestsessionFailedTryItAgain.BoolTimerFail2 = false;
                        //TestsessionFailedTryItAgain.BoolTimerFail3 = false;

                    }
                    break;

                case InstructText.InstructHardStage02: //InstructHardStage02 : The cross sign + appears  and disappears after three seconds
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObjectHard01.SetActive(true);
                    textObjectHard02.SetActive(true);
                    FixationExample01.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolBeenHereBeforeHard = false;// explicitly placing this a couple of steps down.

                        BoolInstructText02 = false;
                        BoolInstructText03 = true;
                        instructText = InstructText.InstructHardStage03;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObjectHard02.SetActive(false);
                        FixationExample01.SetActive(false);
                        TaskHardAExample.SetActive(true);
                        instructText = InstructText.InstructHardStage00;
                    }
                    break;

                case InstructText.InstructHardStage03: //InstructHardStage03  : After a brief pause it is then replaced by a letter 
                                                   //which is shown for 1 second. Remember the letter.
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObjectHard01.SetActive(true);
                    textObjectHard02.SetActive(true);
                    textObjectHard03.SetActive(true);
                    FixationExample01.SetActive(false);
                    TaskHardAExample.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText03 = false;
                        BoolInstructText04 = true;
                        instructText = InstructText.InstructHardStage04;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObjectHard03.SetActive(false);
                        TaskHardAExample.SetActive(false);
                        instructText = InstructText.InstructHardStage02;
                    }
                    break;

                case InstructText.InstructHardStage04: //InstructHardStage04 : After a brief pause it is replaced again
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObjectHard01.SetActive(true);
                    textObjectHard02.SetActive(true);
                    textObjectHard03.SetActive(true);
                    textObjectHard04.SetActive(true);
                    TaskHardAExample.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText04 = false;
                        BoolInstructText05 = true;

                        instructText = InstructText.InstructHardStage05;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObjectHard04.SetActive(false);
                        TaskHardAExample.SetActive(false);
                        instructText = InstructText.InstructHardStage03;
                    }
                    break;

                case InstructText.InstructHardStage05: //InstructHardStage01 : //InstructHardStage04 : by another letter which is shown for 1 second. 
                                                   //If the next letter is the same press < yes >
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObjectHard01.SetActive(true);
                    textObjectHard02.SetActive(true);
                    textObjectHard03.SetActive(true);
                    textObjectHard04.SetActive(true);
                    textObjectHard05.SetActive(true);
                    TaskHardAExample.SetActive(false);
                    TaskHardBExample.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText05 = false;
                        BoolInstructText06 = true;

                        instructText = InstructText.InstructHardStage06;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObjectHard05.SetActive(false);
                        TaskHardAExample.SetActive(false);
                        TaskHardBExample.SetActive(false);
                        instructText = InstructText.InstructHardStage04;
                    }
                    break;

                case InstructText.InstructHardStage06: //InstructHardStage01: If it is not the same, press <no>. Any other images on the screen are only distractors.
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObjectHard01.SetActive(true);
                    textObjectHard02.SetActive(true);
                    textObjectHard03.SetActive(true);
                    textObjectHard04.SetActive(true);
                    textObjectHard05.SetActive(true);
                    textObjectHard06.SetActive(true);
                    TaskHardAExample.SetActive(false);
                    TaskHardBExample.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        BoolInstructText06 = false;
                        BoolInstructText07 = true;
                        instructText = InstructText.InstructHardStage07;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObjectHard06.SetActive(false);
                        TaskHardBExample.SetActive(true);
                        instructText = InstructText.InstructHardStage05;
                    }
                    break;

                case InstructText.InstructHardStage07: //InstructHardStage01 : Remember: it is important to perform the TaskHard as accurately and completely as possible. 
                                                   //When you have finished reading, press  < yes > for a test run.
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObjectHard01.SetActive(false);
                    textObjectHard02.SetActive(false);
                    textObjectHard03.SetActive(false);
                    textObjectHard04.SetActive(false);
                    textObjectHard05.SetActive(false);
                    textObjectHard06.SetActive(false);
                    TaskHardBExample.SetActive(false);
                    textObjectHard07.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        textObjectHard07.SetActive(false);
                        TaskHardBExample.SetActive(false);

                        BoolInstructText07 = false;
                        BoolInstructText08 = true;
                        instructText = InstructText.InstructHardStage08;

                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        textObjectHard01.SetActive(true);
                        textObjectHard02.SetActive(true);
                        textObjectHard03.SetActive(true);
                        textObjectHard04.SetActive(true);
                        textObjectHard05.SetActive(true);
                        textObjectHard06.SetActive(true);
                        textObjectHard07.SetActive(false);
                        TaskHardBExample.SetActive(false);
                        instructText = InstructText.InstructHardStage06;
                    }
                    break;
                case InstructText.InstructHardStage08:
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    textObjectHard01.SetActive(false);
                    textObjectHard02.SetActive(false);
                    textObjectHard03.SetActive(false);
                    textObjectHard04.SetActive(false);
                    textObjectHard05.SetActive(false);
                    textObjectHard06.SetActive(false);
                    textObjectHard07.SetActive(false);
                    TaskHardBExample.SetActive(false);

                    BoolInstructText08 = false;
                    BoolInstructText09 = true;
                    ReadyHardTrials01 = true;
                    instructText = InstructText.InstructHardStage09;
                    break;
                case InstructText.InstructHardStage09:
                    Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " " + instructText);
                    SetBoolReadyTrials01Back();
                    break;

            }

        }


    }

    public void SetBoolReadyTrials01Back()
    {
        ReadyHardTrials01 = false;
        BoolInstructText09 = false;
        instructText = InstructText.InstructHardStage01;
        Debug.Log("------------------------------------------THIS IS  " + ExperimentalProcedure.expProc + " SetBoolReadyTrials01Back" + instructText);

    }
}