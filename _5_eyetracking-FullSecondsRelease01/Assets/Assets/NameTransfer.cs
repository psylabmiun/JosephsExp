using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferName : MonoBehaviour
{

    public string theName;
    public GameObject Inputfield;
    public GameObject textDisplay;


    public void GetName()
    {
        theName = Inputfield.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome participant " + theName + " to this experiment";        
    }
}
