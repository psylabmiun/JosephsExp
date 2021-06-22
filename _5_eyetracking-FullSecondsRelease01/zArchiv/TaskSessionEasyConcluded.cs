using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections.Specialized;

public class TaskSessionEasyConcluded : MonoBehaviour
{
    public TaskTestSession taskTestSession;
    public GameObject TextendOfTaskEasy;
    public ExperimentalProcedure experimentalProcedure;
    public int IntFinishHTM;
    // Start is called before the first frame update
    void Start()
    {
        TaskTestSession.BoolTrialIsOn = false;
        TextendOfTaskEasy.SetActive(true);
        IntFinishHTM++;
        IncreaseIntFinishHTM();
        FunctionTimer.Create(IncreaseIntFinishHTM, 0f, "SetTrialSet1BoolBack");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskHardInstruction;
            ExperimentalProcedure.BooltaskHardInstruction = true;
            ExperimentalProcedure.BooltaskHardScoreNotSufficient = false;
            ExperimentalProcedure.BooltaskHardScoreSufficient = false;
            ExperimentalProcedure.BoolendOfTaskEasy = false;
        }
    }


    private void IncreaseIntFinishHTM()
    {
        Debug.Log("------------------------------------------THIS IS TrialSet1/SetBoolBack()" + ExperimentalProcedure.BooltaskPartOne);
        FunctionTimer.StopTimer("SetTrialSet1BoolBack");
        IntFinishHTM++;
    }


    // Update is called once per frame
    void Update()
    {

        if (IntFinishHTM == 2)
        {
            File.AppendAllText(Application.dataPath + "/FinalLog/webform/gradtest/FinalLog1.htm", IntFinishHTM++ 
                + 
@""" name=textarea1</input> </TD> <TD></TD></TR>
<br><br><br>
<input size=50 value= ""Any specific difficulties you had"" name=feedback </input> <br><br>
<b> How would you rate the test overall?</b> <br><br>
<b/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Works great ---&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""interest"" value=""1"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""interest"" value=""2"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""interest"" value=""3"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""interest"" value=""4"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""interest"" value=""5"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--- needs a lot of work 
 <br><br>
<b/><b/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;It was easy to read ----&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""difficulty"" value=""1"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""difficulty"" value=""2"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""difficulty"" value=""3"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""difficulty"" value=""4"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=""radio"" name=""difficulty"" value=""5"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--- There was too much text
<br><br>
Thank you 
<br>
</form >
<a href=""#top"">Now click here to return to the top of page. Check your details and click the ""send"" button.</a>
<br><br><br>


  </body>
</html>");
        }


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
