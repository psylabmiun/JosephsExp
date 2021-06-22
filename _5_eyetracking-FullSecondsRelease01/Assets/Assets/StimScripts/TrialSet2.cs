//+++++++++
//TrialSet2 
//+++++++++
//Message and start for Task 2 EASY
/*Also creates LCK/LCK.txt file which locks the application for further trials once closed. 
This is important to ensure that users do not try to do the test several times which would 
create unknown practice effects. Of course we cannot prevent users from downloading the 
program again, but by making it more difficult it can be assumed that such practice effects 
are largely eliminated by making the restart more difficult. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Threading;
using System.Collections.Specialized;

public class TrialSet2 : MonoBehaviour
{
    public ExperimentalProcedure experimentalProcedure;
    public TaskTestSession taskTestSession;
    public GameObject TextTrialSet2Go;
    public static bool BoolReadySet2;

    // Start is called before the first frame update
    void Init()
    {
        TaskTestSession.BoolTrialIsOn = false;
        TextTrialSet2Go.SetActive(true);
        Debug.Log("------------------------------------------THIS IS TrialSet2/Init()" + "IntTrialNo=" + 
            TaskTestSession.IntTrialNo + "ExperimentalProcedure.BooltaskPartTwo=" + ExperimentalProcedure.BooltaskPartTwo);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TextTrialSet2Go.SetActive(false);
            BoolReadySet2 = true;
            FunctionTimer.Create(SetBoolBack, 0f, "SetTrialSet2BoolBack" + "IntTrialNo=" + 
                TaskTestSession.IntTrialNo + "ExperimentalProcedure.BooltaskPartTwo=" + ExperimentalProcedure.BooltaskPartTwo);
        }
        if (passwordScript.BoolPlayedOnce = true)
        {
            File.AppendAllText(Application.dataPath + "/LCK/LCK.txt",
                "LCK");
        }
    }


    private void SetBoolBack()
    {
        FunctionTimer.StopTimer("SetTrialSet2BoolBack");
        Debug.Log("------------------------------------------THIS IS TrialSet2/SetBoolBack()" + "IntTrialNo=" + 
            TaskTestSession.IntTrialNo + "ExperimentalProcedure.BooltaskPartTwo=" + ExperimentalProcedure.BooltaskPartTwo);
        TextTrialSet2Go.SetActive(false);
        BoolReadySet2 = false;
        ExperimentalProcedure.BooltaskPartTwo = false;
        ExperimentalProcedure.BooltaskPartOne = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (ExperimentalProcedure.BooltaskPartTwo == true)
        {
            Init();
        }
        else
        {
            TextTrialSet2Go.SetActive(false);
            BoolReadySet2 = false;
        }
    }
}
