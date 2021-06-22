
/* 
+++++++++++++++++++
TaskTestsession.cs
+++++++++++++++++++
The "TaskTestSession.cs" Module is one of two main modules 
(the other being "ChangeMaterial.cs") and controls in short the task stimuli as 
well as a large portion of the timing. The module is run eight times, 
on time for each condition. 
I recommend putting fear stimuli and task stimuli one one slide in the future 
and only retaining this module. This would get rid of timing problems.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections.Specialized;
using System;

public class TaskTestSession : MonoBehaviour
{
    public static int IntAinc;
    public static bool BoolTrialIsOn;
    public bool BoolStartStim;
    //External scripts 
    //Calling methods from external scripts 
    public SRanipal_AvatarEyeSample_v2 sRanipal_AvatarEyeSample_v2;
    public ExperimentalProcedure experimentalProcedureScript;
    public MicInput micInputScript;//prepares and provides the mic input 
    public VoiceResponse voiceResponseScript;
    public TestsessionFailedTryItAgain testsessionFailedTryItAgain;
    public TestsessionHardFailedTryItAgain testsessionHardFailedTryItAgain;
    public ChangeMaterial changeMaterialScript;
    public TaskInstructionScript taskInstructionScript; /*public script for the introductory texts to ensure that 
    the test does not begin while the participant is still reading the instructions.*/
public passwordScript _passwordscript;

    //Correct answer total counts    
    public int TotalSingleTapCorrect;// Single tap answer in Task1 trials
    public int TotalDoubleTapCorrect;// Double tap answer in Task2 trials
    public int TotalTotalsCorrect;    // CountSingleTapCorrect + CountDoubleTapCorrect

    //Wrong answer total counts
    public int TotalSingleTapWrong;  // Total of single tap answers in Task2 trials
    public int TotalDoubleTapWrong;  // Total of double tap answers in Task1 trials
    public int TotalTotalsWrong;      // CountSingleTapWrong + CountDoubleTapWrong
    public int TotalTappedOutOfTime;
    public int TotalTappedExcessively;

    //Technically wrong
    public int CurrentUserExcessTaps;       // Total of excess taps (more than two per trial) 
    public int CurrentUserTapsOutOfTime;    // Total of taps after stimulus disappeared


    //Reset bools to false and CurrentTaps to 1 after each trial 
    public int CurrentTaps;     // Current registered total number of taps per trial + 1. 
    private bool BoolSingleTap; // Answer currently registered as single tap if true
    private bool BoolDoubleTap; // Answer currently registered as double tap if true 
    private bool BoolExcessTap; // Answer currently registered as more than two taps. Renders answer wrong if true
    private bool BoolOutOfTime; // Taps after the stimulus vanishes. Renders answer wrong if true
    private bool CurrentTrialBoolSingleTapCorrect;// If true, current single tap answer in Task1 trial is correct.
    private bool CurrentTrialBoolDoubleTapCorrect;// If true, current double tap answer in Task2 trial is correct.
    private bool CurrentTrialBoolSingleTapWrong;// If true, current single tap answer in Task2 trial is wrong.
    private bool CurrentTrialBoolDoubleTapWrong;// If true, current double tap answer in Task1 trial is wrong.
    private bool CurrentTrialBoolExcessTap;// If true, current double tap answer in Task1 trial is wrong.
    private bool CurrentTrialBoolOutofTime;// If true, current double tap answer in Task1 trial is wrong.
    public static bool BoolSyncSlide;

    private bool BoolUseKeys;
    private bool OddBool;
    public static int TaskLeft; //if even the task field is on the left. Begins at 1.  


    static int[][] TaskOrderArray = new int[][]
    {
        new int [] { 0, 7, 4, 5, 6, 4, 6, 7, 5, 7, 5, 6, 7, 5, 4, 4 },//short arrays are practice sessions
        new int [] { 0, 5, 4, 7, 4, 7, 6, 6, 5, 7, 4, 5, 6, 4, 5, 6 },

        new int [] { 0, 4, 7, 7, 6, 4, 7, 5, 4, 5, 6, 4, 7, 5, 6, 5,
                        4, 5, 6, 4, 5, 6, 7, 6, 4, 5, 4, 5, 7, 7, 4,
                        5, 7, 6, 6, 4, 5, 6, 4, 7, 6, 7, 5, 4, 7, 4,
                        5, 6, 5, 7, 7, 6, 4, 5, 4, 7, 5, 5, 7, 6, 5 },
        new int [] { 0, 4, 7, 6, 5, 6, 7, 5, 4, 7, 6, 4, 7, 6, 7, 4,
                        5, 6, 5, 6, 4, 7, 6, 7, 5, 4, 5, 4, 5, 5, 6,
                        4, 7, 6, 6, 4, 6, 7, 7, 5, 4, 4, 7, 6, 7, 6,
                        5, 7, 5, 4, 5, 4, 7, 6, 4, 7, 5, 6, 7, 6, 6 },

        new int [] { 0, 1, 2, 1, 3, 2, 1, 3, 2, 2, 1, 2, 3, 1, 3, 3 },//short arrays are practice sessions
        new int [] { 0, 3, 2, 1, 3, 2, 3, 2, 1, 1, 3, 3, 2, 1, 1, 2 },

        new int [] { 0, 2, 1, 2, 1, 2, 3, 1, 2, 3, 1, 2, 1, 3, 1, 3,
                        1, 2, 3, 2, 3, 1, 1, 2, 3, 2, 1, 2, 3, 3, 1,
                        1, 3, 1, 2, 3, 1, 3, 2, 1, 2, 2, 3, 2, 1, 3,
                        1, 2, 3, 2, 3, 3, 1, 1, 3, 2, 1, 2, 3, 1, 2 },
        new int [] { 0, 2, 1, 1, 3, 3, 2, 1, 2, 3, 2, 1, 3, 1, 2, 3,
                        3, 2, 2, 1, 3, 1, 3, 2, 1, 3, 1, 2, 2, 3, 1,
                        3, 1, 3, 3, 2, 1, 1, 2, 1, 3, 1, 2, 3, 2, 2,
                        1, 3, 1, 3, 1, 2, 3, 1, 2, 3, 2, 2, 3, 2, 1 }
    };


    //public int IntTrialNo;// is updated every round. In practice rounds it runs from one to three. In 


    public static int CurrentCalledTask;

    public GameObject TaskSlide;
    public GameObject SyncSlide;

    //Stimuli and lead in Materials
    public Material[] TaskLeadInRenders;/*Array of introductory stimuli, Task0 (blank) 
    and Fixation (+ cross) deployed as renders to blank planes to focus the viewer and 
    give breaks between stimuli*/

    //Task Stimuli sets for easy task, 1-4
    public Material[] PracticeList1;
    /*    public Material[] PracticeList2;

        public Material[] TaskSetEasy1;
        public Material[] TaskSetEasy2;
    */
    //Task Stimuli depending on level
    public enum TaskLists //Array of Task Stimuli sets, not yet implemented.
    {
        PracticeList1,
        /*        PracticeList2,
                TaskSetEasy1,
                TaskSetEasy2,
                TaskSetEasy3,
                TaskSetHard1,
                TaskSetHard2,
                TaskSetHard3*/
    };
    public TaskLists taskLists;

    //Task Stimuli sets for difficult task 1-4
    /*    public Material[] TaskSetHard1;
        public Material[] TaskSetHard2;
        public Material[] TaskSetHard3;*/

    public static Renderer rend; //

    public int Usekeys;         /*Switch data for enabling key responses.
    If set to 0, keys are unresponsive and deliver no data; if set to 1, keys are active 
    and deliver yes/no data depending on the keys selected. 
    Unresponsiveness to keylogging not implemented here. All instances of Usekeys set to 1 */

    //Loops
    public static int MainIncrement;/*The main increment runs from 1 to 120 in steps of 1 with each stimulus, 
    at each multiple of 15 it triggers the next IncrementForLoop
    */
    public int IncrementForLoop1;
    /*    public int IncrementForLoop2;
        public int IncrementForLoop3;
        public int IncrementForLoop4;
        public int IncrementForLoop5;
        public int IncrementForLoop6;
        public int IncrementForLoop7;
        public int IncrementForLoop8;
    */
    /*  Increment data for the task stimuli (data sets of 30 trials
        15 easy and 15 difficult), set initially to 0 and incremented to 14. At 15 each loop  
        is halted and a second loop of 15 begins for the difficult task. 
     */

    public static int IntTrialNo;

    public static int DisplayIncrement;/*Each time a Blank Task0 stimulus is shown, DisplayIncrement, which begins at 0 
    is incremented once to provide a count for the individual Taskstimuli trials (each of the thirty stimuli 
    contained within each of the Easy/Hard Tasks).*/

    private void Init()
    {

        VoiceResponse.IncrementForSpeech = 0;
        MainIncrement = 0;
        IncrementForLoop1 = 0;//
        /*        IncrementForLoop2 = 0;//
                IncrementForLoop3 = 0;//
                IncrementForLoop4 = 0;//
                IncrementForLoop5 = 0;//
                IncrementForLoop6 = 0;//
                IncrementForLoop7 = 0;//
                IncrementForLoop8 = 0;*/

        FunctionTimer.Create(DisplayInitial, 1f, "JTm");
        DisplayIncrement = 0; //
        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
        "öStart" + IntAinc + "ü" +  "StSnü" + "BkDDü" + "Bkü"
            + "bTSInitü"
            + "üTmü"
            + Time.time);


        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
        "öStart" + IntAinc + "üStSnü" + "BkDDü" + "Bkü" +
            "bTSInitü"
            + "üTmü"
            + Time.time);

        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    public void DisplayInitial()
    {

        // in order to balance out minor sync problems between task and emotional slides, this sync slide is put in front to prevent either 
        //from being onset or offset too soon. It is controlled by BoolSynSclide  
        BoolSyncSlide = false;



        FunctionTimer.StopTimer("JTm");                            //Time Stop Initial Timer
        FunctionTimer.Create(DisplayFixation, 2f, "FixationTimer");
    }

    public void DisplayFixation() //Display fixation cross 
    {
        // in order to balance out minor sync problems between task and emotional slides, this sync slide is put in front to prevent either 
        //from being onset or offset too soon. It is controlled by BoolSynSclide  
        BoolSyncSlide = false;

        rend.sharedMaterial = TaskLeadInRenders[1];
        FunctionTimer.Create(InterimTimer, 2.5f, "InterimTimer");
        IntTrialNo++;
        FunctionTimer.StopTimer("FixationTimer");



    }

    public void InterimTimer()

    {
        rend.sharedMaterial = TaskLeadInRenders[0];
        FunctionTimer.StopTimer("InterimTimer");
        FunctionTimer.Create(SyncslideOn, 0.001f, "BSncOn");
        BoolTrialIsOn = true;
    }



    //------------- ToDo - Loop as of here ---------------
    public void PrepareTaskStim()
    {
        //int intitial settings

        switch (taskLists)// this switch is all that remains of a previous workflow which was crucial to the presentation of the task. It is now only used for logging. 
        {
            case TaskLists.PracticeList1:
                File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaskStim" + IntAinc+ "üPTkSü"
                    + "BkDDü"
                    + "ITNü" + IntTrialNo
                    + "üIcF1ü" + IncrementForLoop1 + "ü"
                    + "üTmü"
                    + Time.time + "ü"
                    + rend.sharedMaterial);

                File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaskStim" + IntAinc + "üPTkSü"
                    + "BkDDü"
                    + "ITNü" + IntTrialNo
                    + "üIcF1ü" + IncrementForLoop1 + "ü"
                    + "üTmü"
                    + Time.time + "ü"
                    + rend.sharedMaterial);
                break;
        }
        DisplayTheFearSignal();

    }

    public void DisplayTheFearSignal()

    {
        ResetBoolsTaskStimStopTimer();
        ChangeMaterial.DisplayFearSignal++;
    }

    public void ResetBoolsTaskStimStopTimer()
    {
        //Calculate final data

        FunctionTimer.StopTimer("TkSmT");


        if (CurrentTrialBoolSingleTapCorrect)
        {
            TotalSingleTapCorrect++;
        }
        if (CurrentTrialBoolDoubleTapCorrect)
        {
            TotalDoubleTapCorrect++;
        }
        if (CurrentTrialBoolSingleTapWrong)
        {
            TotalSingleTapWrong++;
        }
        if (CurrentTrialBoolDoubleTapWrong)
        {
            TotalDoubleTapWrong++;
        }
        if (CurrentTrialBoolExcessTap)
        {
            CurrentUserExcessTaps++;
            TotalTappedExcessively++;
        }
        if (CurrentTrialBoolOutofTime)
        {
            CurrentUserTapsOutOfTime++;
            TotalTappedOutOfTime++;
        }
        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
        "öTaps" + IntAinc + "ü" + "Asmrü"
            + "ITNü" + IntTrialNo
            + "üMncü" + MainIncrement
            + "üTmü"
            + Time.time + "ü"
            + rend.sharedMaterial +
            "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime
            );


        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
        "öTaps" + IntAinc + "ü" + "Asmrü"
            + "ITNü" + IntTrialNo
            + "üMncü" + MainIncrement
            + "üTmü"
            + Time.time + "ü"
            + rend.sharedMaterial +
            "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime);


        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTask(befMainIncr)" + IntAinc + "üBmDü" + "ITNü" + IntTrialNo
            + "üBficrü" + MainIncrement + "ü"
            + "üTmü"
            + Time.time
            + "üCTkü" + CurrentCalledTask
            );

        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTask(befMainIncr)" + IntAinc + "üBmDü" + "ITNü" + IntTrialNo
            + "üBficrü" + MainIncrement 
            + "üTmü"
            + Time.time
            + "üCTkü" + CurrentCalledTask
            );


        MainIncrement++;
        if (IncrementForLoop1 < TaskOrderArray[IntTrialNo - 1].Length + 1)
        {
            IncrementForLoop1++;
        }
        CurrentCalledTask = TaskOrderArray[IntTrialNo - 1][IncrementForLoop1];//    TEST THIS!!! 
                                                                              //IntTrialNo IS THE CURRENT MEMBER WITHIN THE ArrayofArrays 
                                                                              // FOR THE STIMULI AND IncrementForLoop1 THE ACCORDING MEMBER OF THE 
                                                                              //ACTIVE ARRAY, INCREMENTED++ AT CountResult()
                                                                              // -----   T O    D O    ---- NEED TO IMPLEMENT IncrementForLoop1 
                                                                              //AS A SIMILAR ARRAY IN 2 VARIATIONS FOR THE DIFFERENT TASK LENGTHS
        rend.sharedMaterial = PracticeList1[CurrentCalledTask];
        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTask(AftMainIncr)" + IntAinc + IntAinc 
            + "üAicrü" + MainIncrement
        + "üTmü"
        + Time.time
        + "üCTkü" + CurrentCalledTask
        );



        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTask(AftMainIncr)" + IntAinc 
            + "üAicrü" + MainIncrement
        + "üTmü"
        + "üCTkü" + CurrentCalledTask
        );

        if (CurrentCalledTask % 2 == 0) // Is even, because something divided by two without remainder is even, i.e 4/2 = 2, remainder 0
        {
            OddBool = false;
        }
        else if (CurrentCalledTask % 2 == 1) // Is odd, because something divided by two with a remainder of 1 is not even, i.e. 5/2 = 2, remainder 1
        {
            OddBool = true;
        }



        BoolUseKeys = true;
        CurrentTaps = 0;
        CurrentUserExcessTaps = 0;
        CurrentUserTapsOutOfTime = 0;
        //Bool initial settings
        CurrentTrialBoolSingleTapCorrect = false;
        CurrentTrialBoolDoubleTapCorrect = false;
        CurrentTrialBoolSingleTapWrong = false;
        CurrentTrialBoolDoubleTapWrong = false;
        CurrentTrialBoolExcessTap = false;
        CurrentTrialBoolOutofTime = false;
        BoolSingleTap = false;
        BoolDoubleTap = false;
        BoolExcessTap = false;
        BoolOutOfTime = false;
        FunctionTimer.Create(DisplayNeutral, 1.99f, "NTm");
        //-----------------------------------------------------------------------------------------------------------------------------
        //calculate Output data

        //----------------------------------------------------------------------------------------------------------------------------
        DisplayIncrement++;

    }

    public void SyncslideOn()
    {
        if (CurrentCalledTask < TaskOrderArray[IntTrialNo - 1].Length + 1)
        {
            FunctionTimer.StopTimer("BSncOn");
            BoolSyncSlide = false;
            BoolStartStim = true;

        }
    }
    public void SyncslideOff()
    {
        FunctionTimer.StopTimer("BSncOff");
        if (BoolTrialIsOn == true)
        {
        FunctionTimer.Create(SyncslideOn, 1f, "BSncOn");
        BoolSyncSlide = true;
        }
    }

    public void DisplayNeutral()    //Display Blank Task
    {

        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
        "öTASKIntAinc" + IntAinc + "üDNuü" + "Mncü" + MainIncrement
        + "üTmü"
        + Time.time
        + "üCTkü" + CurrentCalledTask
        );


        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
        "öTASKIntAinc" + + IntAinc + "üDNuü" + "Mncü" + MainIncrement
        + "üTmü"
        + Time.time
        + "üCTkü" + CurrentCalledTask
        );



        if (MainIncrement < TaskOrderArray[IntTrialNo - 1].Length - 1)
        {
            //Ends TaskStim. 

            // in order to balance out minor sync problems between task and emotional slides, this sync slide is put in front to prevent either 
            //from being onset or offset too soon. It is controlled by BoolSynSclide  
            FunctionTimer.StopTimer("NTm");
            rend.sharedMaterial = TaskLeadInRenders[0];
            BoolUseKeys = false;

/*            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "ü" + IntAinc + "üDNuü" 
            + "Mncü" + MainIncrement
            + "üTmü"
            + Time.time
            + "üCTkü" + CurrentCalledTask
            );


            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
        "ü" + IntAinc + "üDNuü" 
        + "Mncü" + MainIncrement
            + "üTmü"
            + Time.time
            + "üCTkü" + CurrentCalledTask
            );
*/


        }
        else
        {
            FunctionTimer.StopTimer("NTm");
            CountResult();
            DisplayIncrement = 0;
            rend.sharedMaterial = TaskLeadInRenders[0];

        }
    }
    public void PreSetUpTaskStimTimer()
    {
        FunctionTimer.StopTimer("preSetUpTaskStimTimer"); 
        SetUpTaskStimTimer();
    }


    public void SetUpTaskStimTimer()
    {
        Debug.Log("------------------------------------------THIS IS TaskTestSession/PrepareTaskStim()/SetUpTaskStimTimer");

        //Ends fixation after three seconds. Don't quite understand the timing here, but it seems to work.
        FunctionTimer.Create(PrepareTaskStim, 0.01f, "TkSmT");     //Begins TaskStim. 

        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
        "öTASKIntAinc" + IntAinc + "üAfter create NeutralTimer\t"
        + "Mncü" + MainIncrement
        + "üTmü"
        + Time.time
        + "üCTkü" + CurrentCalledTask
        );

        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
        "öTASKIntAinc" + IntAinc + "üAfter create NeutralTimer\t"
        + "Mncü" + MainIncrement
        + "üTmü"
        + Time.time
        + "üCTkü" + CurrentCalledTask
        );

    }

    public void CountResult()
    {
        ChangeMaterial.DisplayFearSignal++;

        MainIncrement = 0;
        FunctionTimer.StopTimer("FinalTimer");
        FunctionTimer.StopTimer("DebriefTimer");
        rend.sharedMaterial = TaskLeadInRenders[1];


        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
                "öTotalTaps" + IntAinc + "ü" 
            + "Mncü" + MainIncrement + "ü" + IntAinc
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime );

        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
                "öTotalResult" + IntAinc + "üSmrü" + "StpCStrü" + TotalSingleTapCorrect +
            "üSlTpDTrWü" + TotalSingleTapWrong +
            "üDlTpTrCü" + TotalDoubleTapCorrect +
            "üSlTpTrWDü" + TotalDoubleTapWrong +
            "üTXtAlü" + TotalTappedExcessively +
            "üTtnchsffAlü" + TotalTappedOutOfTime);


        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
                "öTotalTaps" + IntAinc + "ü" + "Asmrü"
            + "Mncü" + MainIncrement
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime );

        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
         "öTotalResult" + IntAinc + "üSmrü" + "StpCStrü" + TotalSingleTapCorrect +
            "üSlTpDTrWü" + TotalSingleTapWrong +
            "üDlTpTrCü" + TotalDoubleTapCorrect +
            "üSlTpTrWDü" + TotalDoubleTapWrong +
            "üTXtAlü" + TotalTappedExcessively +
            "üTtnchsffAlü" + TotalTappedOutOfTime);


        if (IntTrialNo < 3)
        {
            FunctionTimer.Create(EndOfTestSession1And2, 1f, "ndTtIv12");
        }
        else if (IntTrialNo > 2 && IntTrialNo < 5)
        {
            FunctionTimer.Create(EndOfTaskSession1And2, 1f, "EndOfTaskIntervalAnd2");
        }
        else if (IntTrialNo > 4 && IntTrialNo < 7)
        {
            FunctionTimer.Create(EndOfTestSession3And4, 1f, "EndOfTestInterval3And4");
        }

        else if (IntTrialNo > 6 && IntTrialNo < 9)
        {
            FunctionTimer.Create(EndOfTaskSession3And4, 1f, "EndOfTaskInterval3And4");
        }
        //---------------------------------------------------------------------------

    }

    void EndOfTestSession1And2()
    {
        FunctionTimer.StopTimer("ndTtIv12");
        FunctionTimer.Create(SetValuesAfterTestSession1And2, 1f, "SetValuesPauseTestS1And2");
    }
    void EndOfTaskSession1And2()
    {
        FunctionTimer.StopTimer("EndOfTaskInterval1And2");
        FunctionTimer.Create(SetValuesAfterTaskSession1And2, 1f, "SetValuesPauseTask1And2");

    }
    void EndOfTestSession3And4()
    {
        FunctionTimer.StopTimer("EndOfTestInterval3And4");
        FunctionTimer.Create(SetValuesAfterTestSession3And4, 1f, "SetValuesPauseTestS3And4");
    }
    void EndOfTaskSession3And4()
    {
        FunctionTimer.StopTimer("EndOfTaskInterval3And4");
        FunctionTimer.Create(SetValuesAfterTaskSession3And4, 1f, "SetValuesPauseTask3And4");
    }

    void SetValuesAfterTestSession1And2()//Decide whether passed or failed
    {
        FunctionTimer.StopTimer("SetValuesPauseTestS1And2");
        if (TotalSingleTapCorrect > 3 && TotalDoubleTapCorrect > 3 && TotalTappedOutOfTime < 8)
        {

            ExperimentalProcedure.BooltaskScoreSufficient = true;
            ExperimentalProcedure.BooltaskScoreNotSufficient = false;
            TestsessionSuccess.BoolTestSession1Passed = true;
            rend.sharedMaterial = TaskLeadInRenders[1];

            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps + "üExTpFTü"
            + CurrentTrialBoolExcessTap + "üWsUOotü" 
            + CurrentTrialBoolOutofTime );


            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps + "üExTpFTü"
            + CurrentTrialBoolExcessTap + "üWsUOotü" 
            + CurrentTrialBoolOutofTime);

        }
        else
        {
            ExperimentalProcedure.BooltaskScoreSufficient = false;
            TestsessionFailedTryItAgain.BoolTestSessionFailedOnce = true;
            ExperimentalProcedure.BooltaskScoreNotSufficient = true;
            rend.sharedMaterial = TaskLeadInRenders[1];


            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps + "üExTpFTü"
            + CurrentTrialBoolExcessTap + "üWsUOotü" 
            + CurrentTrialBoolOutofTime);

            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps + "üExTpFTü"
            + CurrentTrialBoolExcessTap + "üWsUOotü" 
            + CurrentTrialBoolOutofTime );

        }
        TaskLeft++;
    }
    void SetValuesAfterTaskSession1And2()//End of Session. Just count and go straight to next session
    {
        ExperimentalProcedure.BooltaskScoreSufficient = false;
        ExperimentalProcedure.BooltaskScoreNotSufficient = false;
        FunctionTimer.StopTimer("SetValuesPauseTask1And2");
        rend.sharedMaterial = TaskLeadInRenders[1];

        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime);


        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime);

        TaskLeft++;
        if (IntTrialNo == 3)
        {
            ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskPartTwo;
            ExperimentalProcedure.BooltaskPartTwo = true;
        }
        else if (IntTrialNo == 4)
        {
            ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskPartOne;
            ExperimentalProcedure.BoolendOfTaskEasy = true;

        }
    }

    void SetValuesAfterTestSession3And4()//Decide whether passed or failed
    {

        FunctionTimer.StopTimer("SetValuesPauseTestS3And4");
        passwordScript.BoolPlayedOnce = true;
        if (TotalSingleTapCorrect > 3 && TotalDoubleTapCorrect > 3 && TotalTappedOutOfTime < 8)
        {
            ExperimentalProcedure.BooltaskHardScoreSufficient = true;
            TestsessionHardSuccess.BoolTestSessionHard1Passed = true;
            ExperimentalProcedure.BooltaskHardScoreNotSufficient = false;
            rend.sharedMaterial = TaskLeadInRenders[1];

            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime);


            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime);

        }
        else
        {

            ExperimentalProcedure.BooltaskHardScoreSufficient = false;
            TestsessionHardFailedTryItAgain.BooltestSessionHardFailedOnce = true;
            ExperimentalProcedure.BooltaskHardScoreNotSufficient = true;
            rend.sharedMaterial = TaskLeadInRenders[1];


            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time
            + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime);

            File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time
            + "ü" + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime);
        }

        TaskLeft++;
    }
    void SetValuesAfterTaskSession3And4()//End of Session. Just count and go straight to next session
    {
        ExperimentalProcedure.BooltaskScoreSufficient = false;
        ExperimentalProcedure.BooltaskScoreNotSufficient = false;
        FunctionTimer.StopTimer("SetValuesPauseTask3And4");
        rend.sharedMaterial = TaskLeadInRenders[1];

        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time
            + "ü"
            + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime);

        File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
            "öTaps" + IntAinc + "ü" + "Asmrü" + MainIncrement
            + "üTmü"
            + Time.time
            + "ü"
            + rend.sharedMaterial
            + "üLnc1ü" + IncrementForLoop1
            + "üSlTUCü" + CurrentTrialBoolSingleTapCorrect
            + "üSlTUWü" + CurrentTrialBoolSingleTapWrong
            + "üDlTUCü" + CurrentTrialBoolDoubleTapCorrect
            + "üDlTUWü" + CurrentTrialBoolDoubleTapWrong
            + "üHTpü" + CurrentTaps
            + "üExTpFTü" + CurrentTrialBoolExcessTap
            + "üWsUOotü" + CurrentTrialBoolOutofTime);

        TaskLeft++;
        if (IntTrialNo == 7)
        {
            ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskHardPartTwo;
            ExperimentalProcedure.BooltaskHardPartTwo = true;
        }
        else if (IntTrialNo == 8)
        {
            ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.endOfTaskHard;
            ExperimentalProcedure.BoolendOfTaskHard = true;

        }
    }



    void Update()
    {
        if (BoolStartStim == true)

        {
            BoolStartStim = false;
            FunctionTimer.Create(PreSetUpTaskStimTimer, 1.1f, "preSetupTaskStimTimer");
            FunctionTimer.Create(SyncslideOff, 1f, "BSncOff");
        }


        if (TaskLeft % 2 == 1)
        {
            TaskSlide.transform.localPosition = new Vector3(8.25f, 0.22f, 0f);
        }
        else
        {
            TaskSlide.transform.localPosition = new Vector3(-8.25f, 0.22f, 0.0f);
        }

        //-------------------------split this up somehow-----------------------------


        if (TaskInstructionScript.ReadyTrials01 == true ||
            TestsessionFailedTryItAgain.BoolReadySet1 == true ||
            TrialSet2.BoolReadySet2 == true ||
            TaskHardInstructionScript.ReadyHardTrials01 == true ||
            TestsessionHardFailedTryItAgain.BoolHardReadySet1 == true ||
            TrialSet4.BoolReadySet4 == true)
        {
            Init();
        }


        // in order to balance out minor sync problems between task and emotional slides, this sync slide is put in front to prevent either 
        //from being onset or offset too soon. It is controlled by BoolSynSclide  

        if (BoolSyncSlide == true)
        {
            SyncSlide.SetActive(true);

        }
        else if (BoolSyncSlide == false)
        {
            SyncSlide.SetActive(false);

        }




        //-------------------------split this up somehow-----------------------------


        if (BoolSyncSlide == true)
        {
            Usekeys = 1;
        }
        else if (BoolSyncSlide == false)
        {
            Usekeys = 0;
        }

        switch (Usekeys)
        {

            case 1: //enable key responses during breaks
                if (CurrentTaps == 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    CurrentTaps++;
                    BoolSingleTap = true;
                    BoolDoubleTap = false;
                    BoolExcessTap = false;
                    BoolOutOfTime = false;
                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "öTaps0+" + IntAinc + "ü" +
                        "KavLü" + "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü" + rend.sharedMaterial
                        + "üLnc1cs1ü"
                        + "CTkü" + CurrentCalledTask
                        + "üBlSTpcs1ü" + BoolSingleTap
                        + "üBlDTpcs1ü" + BoolDoubleTap
                        + "üCTpcs1ü" + CurrentTaps
                        + "üXtpcs1ü" + BoolExcessTap
                        + "üOotcs1ü" + BoolOutOfTime);

                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "öTaps0+" + IntAinc + "ü" +
                        "KavLü" + "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü" + rend.sharedMaterial
                        + "üLnc1cs1ü"
                        + "CTkü" + CurrentCalledTask
                        + "üBlSTpcs1ü" + BoolSingleTap
                        + "üBlDTpcs1ü" + BoolDoubleTap
                        + "üCTpcs1ü" + CurrentTaps
                        + "üXtpcs1ü" + BoolExcessTap
                        + "üOotcs1ü" + BoolOutOfTime);


                    if (OddBool == true)
                    {
                        CurrentTrialBoolSingleTapCorrect = true;
                        CurrentTrialBoolDoubleTapCorrect = false;
                        CurrentTrialBoolSingleTapWrong = false;
                        CurrentTrialBoolDoubleTapWrong = false;
                        CurrentTrialBoolExcessTap = false;
                        CurrentTrialBoolOutofTime = false;

                    }
                    else if (OddBool == false)
                    {
                        CurrentTrialBoolSingleTapCorrect = false;
                        CurrentTrialBoolDoubleTapCorrect = false;
                        CurrentTrialBoolSingleTapWrong = true;
                        CurrentTrialBoolDoubleTapWrong = false;
                        CurrentTrialBoolExcessTap = false;
                        CurrentTrialBoolOutofTime = false;
                    }
                }

                else if (CurrentTaps == 1 && Input.GetKeyDown(KeyCode.Space))
                {
                    CurrentTaps++;
                    BoolSingleTap = false;
                    BoolDoubleTap = true;
                    BoolExcessTap = false;
                    BoolOutOfTime = false;

                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "üTaps1+" + IntAinc + "ü" +
                        "KavLü" + "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü" + rend.sharedMaterial
                        + "üLnc1cs1ü"
                        + "CTkü" + CurrentCalledTask
                        + "üBlSTpcs1ü" + BoolSingleTap
                        + "üBlDTpcs1ü" + BoolDoubleTap
                        + "üCTpcs1ü" + CurrentTaps
                        + "üXtpcs1ü" + BoolExcessTap
                        + "üOotcs1ü" + BoolOutOfTime);

                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "üTaps1+" + IntAinc + "ü" +
                        "KavLü" + "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü" + rend.sharedMaterial
                        + "üLnc1cs1ü"
                        + "CTkü" + CurrentCalledTask
                        + "üBlSTpcs1ü" + BoolSingleTap
                        + "üBlDTpcs1ü" + BoolDoubleTap
                        + "üCTpcs1ü" + CurrentTaps
                        + "üXtpcs1ü" + BoolExcessTap
                        + "üOotcs1ü" + BoolOutOfTime);


                    if (OddBool == false)
                    {
                        CurrentTrialBoolSingleTapCorrect = false;
                        CurrentTrialBoolDoubleTapCorrect = true;
                        CurrentTrialBoolSingleTapWrong = false;
                        CurrentTrialBoolDoubleTapWrong = false;
                        CurrentTrialBoolExcessTap = false;
                        CurrentTrialBoolOutofTime = false;
                    }

                    else if (OddBool == true)
                    {
                        CurrentTrialBoolSingleTapCorrect = false;
                        CurrentTrialBoolDoubleTapCorrect = false;
                        CurrentTrialBoolSingleTapWrong = false;
                        CurrentTrialBoolDoubleTapWrong = true;
                        CurrentTrialBoolExcessTap = false;
                        CurrentTrialBoolOutofTime = false;
                    }

                }
                else if (CurrentTaps == 2 && Input.GetKeyDown(KeyCode.Space))
                {
                    CurrentTaps++;
                    BoolSingleTap = false;
                    BoolDoubleTap = false;
                    BoolExcessTap = true;
                    BoolOutOfTime = false;

                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "üTaps2+" + IntAinc + "ü" +
                        "KavLü" + "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü" + rend.sharedMaterial
                        + "üLnc1cs1ü"
                        + "CTkü" + CurrentCalledTask
                        + "üBlSTpcs1ü" + BoolSingleTap
                        + "üBlDTpcs1ü" + BoolDoubleTap
                        + "üCTpcs1ü" + CurrentTaps
                        + "üXtpcs1ü" + BoolExcessTap
                        + "üOotcs1ü" + BoolOutOfTime);

                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "üTaps2+" + IntAinc + "ü" +
                        "KavLü" + "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü" + rend.sharedMaterial
                        + "üLnc1cs1ü"
                        + "CTkü" + CurrentCalledTask
                        + "üBlSTpcs1ü" + BoolSingleTap
                        + "üBlDTpcs1ü" + BoolDoubleTap
                        + "üCTpcs1ü" + CurrentTaps
                        + "üXtpcs1ü" + BoolExcessTap
                        + "üOotcs1ü" + BoolOutOfTime);



                    CurrentUserExcessTaps++;
                    CurrentTrialBoolSingleTapCorrect = false;
                    CurrentTrialBoolDoubleTapCorrect = false;
                    CurrentTrialBoolSingleTapWrong = false;
                    CurrentTrialBoolDoubleTapWrong = false;
                    CurrentTrialBoolExcessTap = true;
                    CurrentTrialBoolOutofTime = false;
                }
                break;
            case 0: //disable key responses during stimulus. Not implemented here, 
                if (CurrentTaps == 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    CurrentTaps++;
                    BoolSingleTap = true;
                    BoolDoubleTap = false;
                    BoolExcessTap = false;
                    BoolOutOfTime = true;


                    File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
                        "öTaps0+" + IntAinc + "ü" +
                        "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time
                        + "ü"
                        + rend.sharedMaterial
                        + "üLnc1ü"
                        + "CurrentCalledTask" + CurrentCalledTask
                        + "üBlSTpcs0ü" + BoolSingleTap
                        + "üBlDTpcs0ü" + BoolDoubleTap
                        + "üCTpcs0ü" + CurrentTaps
                        + "üXtpcs0ü" + BoolExcessTap
                        + "üOotcs0ü" + BoolOutOfTime);

                    File.AppendAllText(Application.dataPath + "/LCK/FinLog.txt",
                        "üTaps=0+" + IntAinc + "ü" +
                        "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time
                        + "ü"
                        + rend.sharedMaterial
                        + "üLnc1ü"
                        +"CurrentCalledTask" + CurrentCalledTask
                        + "üBlSTpcs0ü" + BoolSingleTap
                        + "üBlDTpcs0ü" + BoolDoubleTap
                        + "üCTpcs0ü" + CurrentTaps
                        + "üXtpcs0ü" + BoolExcessTap
                        + "üOotcs0ü" + BoolOutOfTime);


                    CurrentTrialBoolSingleTapCorrect = false;
                    CurrentTrialBoolDoubleTapCorrect = false;
                    CurrentTrialBoolSingleTapWrong = true;
                    CurrentTrialBoolDoubleTapWrong = false;
                    CurrentTrialBoolExcessTap = false;
                    CurrentTrialBoolOutofTime = true;
                    //CurrentUserTapsOutOfTime++;
                }
                else if (CurrentTaps == 1 && Input.GetKeyDown(KeyCode.Space))
                {
                    CurrentTaps++;
                    BoolSingleTap = false;
                    BoolDoubleTap = true;
                    BoolExcessTap = false;
                    BoolOutOfTime = true;

                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "üTaps=1+" + IntAinc + "ü" +
                        "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time
                        + "ü" + rend.sharedMaterial
                        + "üLnc1cs0ü" + CurrentCalledTask
                        + "üBlSTpcs0ü" + BoolSingleTap 
                        + "üBlDTpcs0ü" + BoolDoubleTap 
                        + "üCTpcs0ü" + CurrentTaps
                        + "üXtpcs0ü" + BoolExcessTap
                        + "üOotcs0ü" + BoolOutOfTime);

                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "üTaps1+" + IntAinc + "ü" +
                        "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time
                        + "ü" + rend.sharedMaterial
                        + "üLnc1cs0ü" + CurrentCalledTask
                        + "üBlSTpcs0ü" + BoolSingleTap
                        + "üBlDTpcs0ü" + BoolDoubleTap 
                        + "üCTpcs0ü" + CurrentTaps
                        + "üXtpcs0ü" + BoolExcessTap
                        + "üOotcs0ü" + BoolOutOfTime);


                    if (OddBool == false && CurrentTrialBoolOutofTime == false)
                    {
                        CurrentTrialBoolSingleTapCorrect = false;
                        CurrentTrialBoolDoubleTapCorrect = true;
                        CurrentTrialBoolSingleTapWrong = false;
                        CurrentTrialBoolDoubleTapWrong = false;
                        CurrentTrialBoolExcessTap = false;
                        CurrentTrialBoolOutofTime = true;
                    }
                    else if (OddBool == true && CurrentTrialBoolOutofTime == false)
                    {
                        CurrentTrialBoolSingleTapCorrect = false;
                        CurrentTrialBoolDoubleTapCorrect = false;
                        CurrentTrialBoolSingleTapWrong = false;
                        CurrentTrialBoolDoubleTapWrong = true;
                        CurrentTrialBoolExcessTap = false;
                        CurrentTrialBoolOutofTime = true;
                    }
                    else
                    {
                        CurrentTrialBoolSingleTapCorrect = false;
                        CurrentTrialBoolDoubleTapCorrect = false;
                        CurrentTrialBoolSingleTapWrong = false;
                        CurrentTrialBoolDoubleTapWrong = true;
                        CurrentTrialBoolExcessTap = false;
                        CurrentTrialBoolOutofTime = true;
                    }
                    //CurrentUserExcessTaps++;
                    //CurrentUserTapsOutOfTime++;

                }


                else if (CurrentTaps == 2 && Input.GetKeyDown(KeyCode.Space))
                {
                    CurrentTaps++;
                    BoolSingleTap = false;
                    BoolDoubleTap = false;
                    BoolExcessTap = true;
                    BoolOutOfTime = true;


                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "üTaps2+" + IntAinc + "ü" +
                        "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü"
                        + rend.sharedMaterial
                        + "üLnc1cs0ü" + CurrentCalledTask
                        + "üBlSTpcs0ü" + BoolSingleTap
                        + "üBlDTpcs0ü" + BoolDoubleTap
                        + "üCTpcs0ü" + CurrentTaps
                        + "üXtpcs0ü" + BoolExcessTap
                        + "üOotcs0ü" + BoolOutOfTime);


                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "üTaps2+" + IntAinc 
                        + "üMncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü"
                        + rend.sharedMaterial
                        + "üLnc1cs0ü" + CurrentCalledTask
                        + "üBlSTpcs0ü" + BoolSingleTap
                        + "üBlDTpcs0ü" + BoolDoubleTap
                        + "üCTpcs0ü" + CurrentTaps
                        + "üXtpcs0ü" + BoolExcessTap
                        + "üOotcs0ü" + BoolOutOfTime );

                    CurrentTrialBoolSingleTapCorrect = false;
                    CurrentTrialBoolDoubleTapCorrect = false;
                    CurrentTrialBoolSingleTapWrong = false;
                    CurrentTrialBoolDoubleTapWrong = false;
                    CurrentTrialBoolExcessTap = true;
                    CurrentTrialBoolOutofTime = true;
                    //CurrentUserExcessTaps++;
                    //CurrentUserTapsOutOfTime++;
                }

                else if (CurrentTaps > 2 && Input.GetKeyDown(KeyCode.Space))
                {
                    CurrentTaps++;
                    BoolSingleTap = false;
                    BoolDoubleTap = false;
                    BoolExcessTap = true;
                    BoolOutOfTime = true;


                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                         "üTaps>2" + IntAinc + "ü" +
                        "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü"
                        + rend.sharedMaterial
                        + "üLnc1cs0ü" + CurrentCalledTask
                        + "üBlSTpcs0ü" + BoolSingleTap
                        + "üBlDTpcs0ü" + BoolDoubleTap
                        + "üCTpcs0ü" + CurrentTaps +
                        "üXtpcs0ü" + BoolExcessTap +
                        "üOotcs0ü" + BoolOutOfTime);


                    File.AppendAllText(Application.dataPath +
                        "/LCK/FinLog.txt",
                        "üTaps>2" + IntAinc + "ü" +
                        "Mncü" + MainIncrement
                        + "üTmü"
                        + Time.time + "ü"
                        + rend.sharedMaterial
                        + "üLnc1cs0ü" + CurrentCalledTask
                        + "üBlSTpcs0ü" + BoolSingleTap
                        + "üBlDTpcs0ü" + BoolDoubleTap
                        + "üCTpcs0ü" + CurrentTaps +
                        "üXtpcs0ü" + BoolExcessTap +
                        "üOotcs0ü" + BoolOutOfTime);

                    CurrentTrialBoolSingleTapCorrect = false;
                    CurrentTrialBoolDoubleTapCorrect = false;
                    CurrentTrialBoolSingleTapWrong = false;
                    CurrentTrialBoolDoubleTapWrong = false;
                    CurrentTrialBoolExcessTap = true;
                    CurrentTrialBoolOutofTime = true;
                    //CurrentUserExcessTaps++;
                    //CurrentUserTapsOutOfTime++;
                }
                break;
        }


    }


}

