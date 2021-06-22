//++++++++++++++++++++++++
//ClickDataProt.cs
//++++++++++++++++++++++++
//Main file for the opening screen. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;

public class ClickDataProt : MonoBehaviour
{
    //scripts
    public Page2ButtonController page2ButtonController;
    //-----------------------------------------------------------------------------------------------------------
    //Page1 Consent
    //Objects to activate and deactivate the consent button
    public Button DataProtBtn;
    public GameObject BtnDatPrActv;
    //public GameObject TogDatPrAgree;
    public bool BoolDatPrBtnActv;

    //Objects to log consent and move onto the next page 
    public bool BoolDatPrYesConsent;
    //Screens
    //All introductory screens are handled from here 


    //------------------------------------------------------------------------------------------------------------------
    //Page2 Excl Questions
    public GameObject TextExclTitle;


    //Integers to decide even or odd (= true or false)


    public bool BoolExclContinue;
    public static bool BoolScreen1;
    public static bool BoolScreen2;



    public void Start()
    {
        
        
        //BtnDatPrActv.SetActive(false);
        //TogDatPrAgree.SetActive(true);
        BoolScreen1 = true;
        Button btn = DataProtBtn.GetComponent<Button>();
        btn.onClick.AddListener(SetBoolYesConsent);
    }


    public void SetBoolYesConsent()
    {

        BoolDatPrYesConsent = true;
        BoolScreen1 = false;
        BoolScreen2 = true;
        OutputLog();
    }

    public void OutputLog()
    {

    }


    public void update()
    {
        //Button Page 1
        
/*        if(TogDatPrAgree.isOn)
        {
            BoolDatPrBtnActv = true;
        }


        if (BoolDatPrBtnActv == true)
        {
            BtnDatPrActv.SetActive(true);
        }
        else
        {
            BtnDatPrActv.SetActive(false);
        }*/
        
    }

}




