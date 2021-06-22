using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DataProt : MonoBehaviour
{

    public ExperimentalProcedure experimentalProcedureScript;
    public GameObject DataProttext;
    public GameObject TextDataProtInstructionKeys;
    public GameObject TextDataProtReadUnderstoodAgree;
    public GameObject TextDataProtDoNotAgree;
    public GameObject TextDataProtUserEscape;
    public GameObject TextDataProtUserContinue;

    public static bool BoolDataProtReadUnderstoodAgree;

    public enum AgreeDisagree
    {
        PleaseChoose,
        Agree,
        Disagree,
        DataProtExit

    }
    public static AgreeDisagree agreeDisagree;


    void Start()
    {
        //DataProttext.SetActive(true);
        //TextDataProtInstructionKeys.SetActive(true);
        print("DataProt Start()");
    }
    // Update is called once per frame
    void Update()
    {

        switch (agreeDisagree)
        {
            case AgreeDisagree.PleaseChoose:
                Debug.Log("------------------------------------------THIS IS (dataProt) 'PleaseChoose'" + AgreeDisagree.PleaseChoose);
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    agreeDisagree = AgreeDisagree.Agree;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    agreeDisagree = AgreeDisagree.Disagree;
                }
                break;
            case AgreeDisagree.Disagree:
                Debug.Log("------------------------------------------THIS IS (dataProt) 'PleaseChoose'" + AgreeDisagree.Disagree);
                //Setbools
                BoolDataProtReadUnderstoodAgree = false;
                //Textelements
                TextDataProtInstructionKeys.SetActive(true);
                TextDataProtReadUnderstoodAgree.SetActive(false);
                TextDataProtDoNotAgree.SetActive(true);
                TextDataProtUserEscape.SetActive(true);
                TextDataProtUserContinue.SetActive(false);

                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    Application.Quit();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Debug.Log("------------------------------------------THIS IS (dataProt) 'PleaseChoose'" + AgreeDisagree.Disagree + "Agreeing");
                    agreeDisagree = AgreeDisagree.Agree;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Debug.Log("------------------------------------------THIS IS (dataProt) 'PleaseChoose'" + AgreeDisagree.Disagree + "Disagreeing");
                    agreeDisagree = AgreeDisagree.Disagree;
                }
                break;
            case AgreeDisagree.Agree:
                Debug.Log("------------------------------------------THIS IS (dataProt) 'PleaseChoose'" + AgreeDisagree.Agree);
                TextDataProtReadUnderstoodAgree.SetActive(true);
                TextDataProtDoNotAgree.SetActive(false);
                TextDataProtUserEscape.SetActive(false);
                TextDataProtUserContinue.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    //Bools
                    BoolDataProtReadUnderstoodAgree = true;
                    agreeDisagree = AgreeDisagree.DataProtExit;
                    //log participant agreement to file. 
                    //---T O DO --------------------------------------------------------------------------------------------------------------------------- 

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    print("DataProt No Agreement");
                    agreeDisagree = AgreeDisagree.Disagree;
                }
                break;
            case AgreeDisagree.DataProtExit:
                ExperimentalProcedure.Bool_dataProtection = false;
                ExperimentalProcedure.Bool_questionnaireSPQ = true;
                //Switches
//                ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc._questionnaireSPQ;
                //Text elements
                DataProttext.SetActive(false);
                TextDataProtReadUnderstoodAgree.SetActive(false);
                TextDataProtDoNotAgree.SetActive(false);
                TextDataProtUserEscape.SetActive(false);
                TextDataProtUserContinue.SetActive(false);
                TextDataProtInstructionKeys.SetActive(false);
                break;

        }

        if (ExperimentalProcedure.Bool_dataProtection == false)
        {
            print("DataProt Update() If1");

            DataProttext.SetActive(false);
            TextDataProtReadUnderstoodAgree.SetActive(false);
            TextDataProtDoNotAgree.SetActive(false);
            TextDataProtUserEscape.SetActive(false);
            TextDataProtUserContinue.SetActive(false);
            TextDataProtInstructionKeys.SetActive(false);
            BoolDataProtReadUnderstoodAgree = false;
        }

        else
        {
            print("DataProt Update() else If1");
            Start();
        }
    }
}
