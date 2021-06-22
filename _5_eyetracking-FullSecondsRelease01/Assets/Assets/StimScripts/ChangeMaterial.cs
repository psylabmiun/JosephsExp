/*
+++++++++++++++
ChangeMaterial
+++++++++++++++
Works in connection with "TaskTestSession.cs" to display the EmoSlide object and contributes to the timing. 
The script is quite self-explanatory if you read "TaskTestSession.cs" first. 
The timer "StartStimFear" is the trickiest part as is also the case in "TaskTestSession.cs". 
The emotional stimuli are deployed as render objects "projected" onto planes and managed in 
arrays in the unity editor.
I recommend putting fear stimuli and task stimuli one one slide in the future 
and only retaining TaskTestsession.cs. 
Getting rid of this module would get rid of timing problems.
*/

using System.Collections;
using System.IO;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public TaskTestSession taskTestSession;
    public SRanipal_AvatarEyeSample_v2 sRanipal_AvatarEyeSample_v2;

    public static int IncrementFearLoop;
    public static int DisplayFearSignal;//counts 1 to 3 and is set back to 0 in a loop
    /*Array of Emotional stimuli. 8 Folders of 
     5 Flowers and 5 Spiders, deployed as renders on blank planes */

    public GameObject EmoSlide;
    public Material[] matFear;
    public Renderer rendFear;
    public 


    void Start()
    {
        IncrementFearLoop = 2;
        rendFear = GetComponent<Renderer>();
        rendFear.enabled = true;
    }
    
    private void StartStimFear() //Display StimFear
    {

        DisplayIntervalFear();
        IncrementFearLoop++;
    }

    private void DisplayIntervalFear()
    {
        FunctionTimer.StopTimer("IntervalTimerFear");
        rendFear.sharedMaterial = matFear[0];

    }


    void Update()
    {



        if (TaskTestSession.BoolTrialIsOn == true)
        {

            File.AppendAllText(Application.dataPath + "/Lck/FinLog.txt",
            "öEmoIntAinc" + TaskTestSession.IntAinc + "üEmoStimü" + "Mnc" + TaskTestSession.MainIncrement + 
            "üTmü" + Time.time + "ü" + "CurrentEmoTask" + 
            rendFear.sharedMaterial);

            File.AppendAllText(Application.dataPath + "/Lck/FinLog.txt",
            "öEmoIntAinc" + TaskTestSession.IntAinc + "üEmoStimü" + "Mnc" + TaskTestSession.MainIncrement +
            "üTmü" + Time.time + "ü" + "CurrentEmoTask" +
            rendFear.sharedMaterial);
        }
        if (TaskTestSession.TaskLeft % 2 == 1)
        {
            EmoSlide.transform.localPosition = new Vector3(-8.25f, 0.22f, 0.0f);
        }
        else
        {
            EmoSlide.transform.localPosition = new Vector3(8.25f, 0.22f, 0.0f);
        }

        //---------------------------------------------------------------------------------

        if (ExperimentalProcedure.BooltaskTestSession == false)
        {

        }
        else if (ExperimentalProcedure.BooltaskTestSession == true)
        {

            Start();
        }

        if (IncrementFearLoop > 110)
        {
            Finish();
        }

        if (DisplayFearSignal == 3)
        {

            rendFear.sharedMaterial = matFear[IncrementFearLoop];
            FunctionTimer.Create(StartStimFear, 2f, "IntervalTimerFear");

            DisplayFearSignal = 0;
        }
    }
    void Finish()
    {
        
    }

}
