using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SPQQuestionnaire : MonoBehaviour
{
    //Scripts
    public ExperimentalProcedure experimentalProcedureScript;

        //Shared Objects



    //    public ParticipNumInput participNumInput;

    public enum SPQ
    {
        Exclusion,
        SPQ00,
        SPQ01,
        SPQ02,
        SPQ03,
        SPQ04,
        SPQ05,
        SPQ06,
        SPQ07,
        SPQ08,
        SPQ09,
        SPQ10,
        SPQ11,
        SPQ12,
        SPQ13,
        SPQ14
    }

    public SPQ sPQ;

    public GameObject TextSPQ00;//Title Short Spider Fear Questionnaire -- Please answer True(key "m") or False(key "n")

    public GameObject TextExclusionTitle;
    public GameObject TextExclusion01BrainDamage;
    public GameObject TextExclusion02NeurologicalDisorders;
    public GameObject TextExclusion03Psychotropic;
    public GameObject TextExclusion04AlcoDrugsMeds;
    public GameObject TextExclusion05Depression;
    public GameObject TextExclusion06Verify;


    public GameObject TextExclusion01True;
    public GameObject TextExclusion02True;
    public GameObject TextExclusion03True;
    public GameObject TextExclusion04True;
    public GameObject TextExclusion05True;
    public GameObject TextExclusion06True;
    public GameObject TextExclusion01False;
    public GameObject TextExclusion02False;
    public GameObject TextExclusion03False;
    public GameObject TextExclusion04False;
    public GameObject TextExclusion05False;
    public GameObject TextExclusion06False;

    public GameObject ButtonExclusionGoToPage3;


    public GameObject TextSPQ01;
    public GameObject TextSPQ02;
    public GameObject TextSPQ03;
    public GameObject TextSPQ04;
    public GameObject TextSPQ05;
    public GameObject TextSPQ06;
    public GameObject TextSPQ07;
    public GameObject TextSPQ08;
    public GameObject TextSPQ09;
    public GameObject TextSPQ10;
    public GameObject TextSPQ11;
    public GameObject TextSPQ12;
    public GameObject TextSPQ13;
    public GameObject TextSPQ01True;
    public GameObject TextSPQ02True;
    public GameObject TextSPQ03True;
    public GameObject TextSPQ04True;
    public GameObject TextSPQ05True;
    public GameObject TextSPQ06True;
    public GameObject TextSPQ07True;
    public GameObject TextSPQ08True;
    public GameObject TextSPQ09True;
    public GameObject TextSPQ10True;
    public GameObject TextSPQ11True;
    public GameObject TextSPQ12True;
    public GameObject TextSPQ01False;
    public GameObject TextSPQ02False;
    public GameObject TextSPQ03False;
    public GameObject TextSPQ04False;
    public GameObject TextSPQ05False;
    public GameObject TextSPQ06False;
    public GameObject TextSPQ07False;
    public GameObject TextSPQ08False;
    public GameObject TextSPQ09False;
    public GameObject TextSPQ10False;
    public GameObject TextSPQ11False;
    public GameObject TextSPQ12False;

    public int NextQuestion;

    //Have all questions been answered?
    public bool BoolExcl01Answered;
    public bool BoolExcl02Answered;
    public bool BoolExcl03Answered;
    public bool BoolExcl04Answered;
    public bool BoolExcl05Answered;
    public bool BoolExcl06Answered;

    public bool BoolExclusion01BrainDamage;
    public bool BoolExclusion02NeurologicalDisorders;
    public bool BoolExclusion03Psychotropic;
    public bool BoolExclusion04AlcoDrugsMeds;
    public bool BoolExclusion05Depression;
    public bool BoolExclusion06Verify;

    public bool BoolExclusionContinue;
    public bool TextExclusionQuit;
    
    public bool BoolSPQ01True;
    public bool BoolSPQ02True;
    public bool BoolSPQ03True;
    public bool BoolSPQ04True;
    public bool BoolSPQ05True;
    public bool BoolSPQ06True;
    public bool BoolSPQ07True;
    public bool BoolSPQ08True;//Gamebreaker - if true, no participation allowed. 
    public bool BoolSPQ09True;
    public bool BoolSPQ10True;
    public bool BoolSPQ11True;
    public bool BoolSPQ12True;

    public bool BoolSPQ01Answered;
    public bool BoolSPQ02Answered;
    public bool BoolSPQ03Answered;
    public bool BoolSPQ04Answered;
    public bool BoolSPQ05Answered;
    public bool BoolSPQ06Answered;
    public bool BoolSPQ07Answered;
    public bool BoolSPQ08Answered;
    public bool BoolSPQ09Answered;
    public bool BoolSPQ10Answered;
    public bool BoolSPQ11Answered;
    public bool BoolSPQ12Answered;
    




    private int SPQBoolCount;


    // Start is called before the first frame update
    void Init()
    {

    }

    void QuesScoreCount()
    {
        if (BoolSPQ01True == true) { SPQBoolCount++; }
        if (BoolSPQ02True == true) { SPQBoolCount++; }
        if (BoolSPQ03True == true) { SPQBoolCount++; }
        if (BoolSPQ04True == true) { SPQBoolCount++; }
        if (BoolSPQ05True == true) { SPQBoolCount++; }
        if (BoolSPQ06True == true) { SPQBoolCount++; }
        if (BoolSPQ07True == true) { SPQBoolCount++; }
        if (BoolSPQ08True == true) { SPQBoolCount++; }//Gamebreaker: if true, no participation allowed.
        if (BoolSPQ09True == true) { SPQBoolCount++; }
        if (BoolSPQ10True == true) { SPQBoolCount++; }
        if (BoolSPQ11True == true) { SPQBoolCount++; }
        if (BoolSPQ12True == true) { SPQBoolCount++; }


        if (SPQBoolCount > 8)
        {
            ExperimentalProcedure.Bool_rejectParticipant = true;
            ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc._rejectParticipant;
            ExperimentalProcedure.Bool_requestCode = false;
        }
        else if (SPQBoolCount < 9)
        {
            ExperimentalProcedure.Bool_rejectParticipant = false;
            ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc._requestCode;
            ExperimentalProcedure.Bool_requestCode = true;
        }
    }

    void Update()
    {

        if (ExperimentalProcedure.Bool_questionnaireSPQ == false)
        {



            TextSPQ07.SetActive(false);
            TextSPQ08.SetActive(false);
            TextSPQ09.SetActive(false);
            TextSPQ10.SetActive(false);
            TextSPQ11.SetActive(false);
            TextSPQ12.SetActive(false);
            TextSPQ13.SetActive(false);
            TextSPQ07True.SetActive(false);
            TextSPQ08True.SetActive(false);
            TextSPQ09True.SetActive(false);
            TextSPQ10True.SetActive(false);
            TextSPQ11True.SetActive(false);
            TextSPQ12True.SetActive(false);
            TextSPQ07False.SetActive(false);
            TextSPQ08False.SetActive(false);
            TextSPQ09False.SetActive(false);
            TextSPQ10False.SetActive(false);
            TextSPQ11False.SetActive(false);
            TextSPQ12False.SetActive(false);

        }//sets all text objects false
        else if (ExperimentalProcedure.Bool_questionnaireSPQ == true)
        {
            Init();
            switch (sPQ)
            {
                case SPQ.Exclusion:


                    break;

                case SPQ.SPQ00:
                    //Set Page 2 True 
                    TextSPQ07.SetActive(true);
                    TextSPQ08.SetActive(true);
                    TextSPQ09.SetActive(true);
                    TextSPQ10.SetActive(true);
                    TextSPQ11.SetActive(true);
                    TextSPQ12.SetActive(true);
                    Debug.Log("-----------------------------------------------------------------------------TextSPQ00");
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ01;

                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        TextExclusion02NeurologicalDisorders.SetActive(true);
                        TextExclusion03Psychotropic.SetActive(true);
                        TextExclusion04AlcoDrugsMeds.SetActive(true);
                        TextExclusion05Depression.SetActive(true);
                        TextExclusion06Verify.SetActive(true);
                        TextSPQ07.SetActive(false);
                        TextSPQ08.SetActive(false);
                        TextSPQ09.SetActive(false);
                        TextSPQ10.SetActive(false);
                        TextSPQ11.SetActive(false);
                        TextSPQ12.SetActive(false);
                        TextSPQ13.SetActive(false);
                        TextSPQ07True.SetActive(false);
                        TextSPQ08True.SetActive(false);
                        TextSPQ09True.SetActive(false);
                        TextSPQ10True.SetActive(false);
                        TextSPQ11True.SetActive(false);
                        TextSPQ12True.SetActive(false);
                        TextSPQ07False.SetActive(false);
                        TextSPQ08False.SetActive(false);
                        TextSPQ09False.SetActive(false);
                        TextSPQ10False.SetActive(false);
                        TextSPQ11False.SetActive(false);
                        TextSPQ12False.SetActive(false);

                    }
                    break;

                case SPQ.SPQ13:
                    TextSPQ07.SetActive(false);
                    TextSPQ08.SetActive(false);
                    TextSPQ09.SetActive(false);
                    TextSPQ10.SetActive(false);
                    TextSPQ11.SetActive(false);
                    TextSPQ12.SetActive(false);
                    TextSPQ13.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        TextSPQ13.SetActive(false);
                        sPQ = SPQ.SPQ14;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        TextSPQ07.SetActive(true);
                        TextSPQ08.SetActive(true);
                        TextSPQ09.SetActive(true);
                        TextSPQ10.SetActive(true);
                        TextSPQ11.SetActive(true);
                        TextSPQ12.SetActive(true);
                        TextSPQ13.SetActive(false);
                        sPQ = SPQ.SPQ12;
                    }
                    break;
                case SPQ.SPQ14:
                    QuesScoreCount();
                    break;
                    /*Note: Joseph Given. 
                    Everything below here in this routine is cases 1 - 12 of the switch function NextQuestion consisting of 
                    12 almost identical cases. This could have been more tidily implemented. I recommend a less complex method 
                    of presentation in future scripts if replicating this experiment or reusing these scripts.*/

                case SPQ.SPQ01:
                    Debug.Log("--------------------------------------------------------------------------------TextSPQ01");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ01True = true;

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ01True = false;

                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ02;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ00;
                    }
                    break;

                case SPQ.SPQ02:
                    Debug.Log("TextSPQ02");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ02True = true;

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ02True = false;

                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ03;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ01;
                    }

                    break;

                case SPQ.SPQ03:
                    Debug.Log("TextSPQ03");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ03True = true;

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ03True = false;

                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ04;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ02;

                    }

                    break;

                case SPQ.SPQ04:
                    Debug.Log("TextSPQ04");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ04True = true;

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ04True = false;

                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ05;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ03;
                    }

                    break;

                case SPQ.SPQ05:
                    Debug.Log("TextSPQ05");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ05True = true;

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ05True = false;

                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ06;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ04;
                    }

                    break;

                case SPQ.SPQ06:
                    Debug.Log("TextSPQ06");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ06True = true;

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ06True = false;

                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ07;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ05;
                    }
                    break;

                case SPQ.SPQ07:
                    Debug.Log("TextSPQ07");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ07True = true;

                        TextSPQ07False.SetActive(false);
                        TextSPQ07True.SetActive(true);
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ07True = false;

                        TextSPQ07False.SetActive(true);
                        TextSPQ07True.SetActive(false);
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ08;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ06;
                    }
                    break;

                case SPQ.SPQ08:
                    Debug.Log("TextSPQ08");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ08True = true;

                        TextSPQ08False.SetActive(false);
                        TextSPQ08True.SetActive(true);
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ08True = false;

                        TextSPQ08False.SetActive(true);
                        TextSPQ08True.SetActive(false);
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ09;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ07;
                    }
                    break;

                case SPQ.SPQ09:
                    Debug.Log("TextSPQ09");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ09True = true;

                        TextSPQ09False.SetActive(false);
                        TextSPQ09True.SetActive(true);
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ09True = false;

                        TextSPQ09False.SetActive(true);
                        TextSPQ09True.SetActive(false);
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ10;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ08;
                    }
                    break;

                case SPQ.SPQ10:
                    Debug.Log("TextSPQ10");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ10True = true;

                        TextSPQ10False.SetActive(false);
                        TextSPQ10True.SetActive(true);
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ10True = false;

                        TextSPQ10False.SetActive(true);
                        TextSPQ10True.SetActive(false);
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ11;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ09;
                    }
                    break;

                case SPQ.SPQ11:
                    Debug.Log("TextSPQ11");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ11True = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ11True = false;

                        TextSPQ11False.SetActive(true);
                        TextSPQ11True.SetActive(false);
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ12;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ10;
                    }
                    break;

                case SPQ.SPQ12:
                    Debug.Log("TextSPQ12");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        BoolSPQ12True = true;

                        TextSPQ12False.SetActive(false);
                        TextSPQ12True.SetActive(true);
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        BoolSPQ12True = false;

                        TextSPQ12False.SetActive(true);
                        TextSPQ12True.SetActive(false);
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        sPQ = SPQ.SPQ13;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        sPQ = SPQ.SPQ11;
                    }
                    break;
            }

        }
        if (BoolExcl01Answered == false ||
            BoolExcl02Answered == false ||
            BoolExcl03Answered == false ||
            BoolExcl04Answered == false ||
            BoolExcl05Answered == false ||
            BoolExcl06Answered == false)
        {
            BoolExclusionContinue = false;
            TextExclusionQuit = true;
        }
        else
        {
            BoolExclusionContinue = true;
        }
    }




}