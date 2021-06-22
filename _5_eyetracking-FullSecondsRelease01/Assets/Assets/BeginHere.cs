using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BeginHere : MonoBehaviour
{
    public ExperimentalProcedure experimentalProcedureScript;

    public string theName;
    public GameObject CodeInputObject;
    //public GameObject PasswordField;
    public GameObject TextDisplay;



    void GetName()
    {
       // theName = PasswordField.GetComponent<Text>().text;
        //TextDisplay.GetComponent<Text>().text = "This is where the participants put in their code to begin the experiment. It has not yet been implemented, so just press 'P' to move on to the next screen, or Return to go straight to the task.";
    }



    void Update()
    {
        if (ExperimentalProcedure.Bool_startGreeting == false)
        {
            CodeInputObject.SetActive(false);
        }
        else
        {
            GetName();
        }


    }
}


