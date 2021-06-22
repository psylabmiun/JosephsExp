//----------------
//_ChangeScreens.cs
//----------------
//Main file for the questionnaire data. This is a hierarchically superior 
//object which defines which questions and questionnaire objects are currently visible.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class _ChangeScreens : MonoBehaviour
{
    public ClickDataProt ClickDataProt;
    public Page2ButtonController page2ButtonController;
    public Page2ButtonControllerBACK page2ButtonControllerBACK;
    public Page3ButtonController page3ButtonController;
    public Page3ButtonControllerBACK page3ButtonControllerBACK;
    public Page4ButtonController page4ButtonController;
    public Page4ButtonControllerBACK page4ButtonControllerBACK;

    public GameObject CanvasOff;
    public GameObject Screen1;//Data Protection
    public GameObject Screen2;//First part of questionnaire
    public GameObject Screen3;//Second part of questionnaire
    public GameObject Screen4;//Second part of questionnaire 
    public GameObject Screen5;//Concluding Page (further options) 

    public static bool BoolCanvasOff;

    // Start is called before the first frame update

    void InitScreen1()
    {
        Screen1.SetActive(true);
        Screen2.SetActive(false);
        Screen3.SetActive(false);
        Screen4.SetActive(false);
        Screen5.SetActive(false);
/*        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("------------------------------------------Pressing Escape ");
            ClickDataProt.BoolScreen1 = false;
            Screen1.SetActive(false);
            ExperimentalProcedure.expProc = ExperimentalProcedure.ExpProc.taskCalibration;
        }*/
    }
    void InitScreen2()
    {
        Screen1.SetActive(false);
        //------------------------------------------------------------Log consent to file 
        Screen2.SetActive(true);
        Screen3.SetActive(false);
        Screen4.SetActive(false);
        Screen5.SetActive(false);

    }
    void InitScreen3()
    {
        Screen1.SetActive(false);
        Screen2.SetActive(false);
        //------------------------------------------------------------Log consent to file 
        Screen3.SetActive(true);
        Screen4.SetActive(false);
        Screen5.SetActive(false);

    }
    void InitScreen4()
    {
        Screen1.SetActive(false);
        Screen2.SetActive(false);
        Screen3.SetActive(false);
        //------------------------------------------------------------Log consent to file 
        Screen4.SetActive(true);
        Screen5.SetActive(false);

    }
    void InitScreen5()
    {
        Screen1.SetActive(false);
        Screen2.SetActive(false);
        Screen3.SetActive(false);
        //------------------------------------------------------------Log consent to file 
        Screen4.SetActive(false);
        Screen5.SetActive(true);

    }



    // Update is called once per frame
    void Update()
    {
        if (BoolCanvasOff == true)
        {
            CanvasOff.SetActive(false);
        }

        if (ClickDataProt.BoolScreen1 == false &&
            ClickDataProt.BoolScreen2 == false &&
            Page2ButtonController.BoolScreen3 == false &&
            Page3ButtonController.BoolScreen4 == false &&
            Page4ButtonController.BoolScreen5 == false)
        {
            Screen1.SetActive(false);
            Screen2.SetActive(false);
            Screen3.SetActive(false);
            Screen4.SetActive(false);
            Screen5.SetActive(false);
        }
        else if (ClickDataProt.BoolScreen1 == true && ClickDataProt.BoolScreen2 == false)
        {
            InitScreen1();
        }
        else if (ClickDataProt.BoolScreen2 == true && Page2ButtonController.BoolScreen3 == false)
        {
            InitScreen2();
        }
        else if (Page2ButtonController.BoolScreen3 == true && Page3ButtonController.BoolScreen4 == false)
        {
            InitScreen3();
        }
        else if (Page3ButtonController.BoolScreen4 == true && Page4ButtonController.BoolScreen5 == false)
        {
            InitScreen4();
        }
        else if (Page4ButtonController.BoolScreen5 == true)
        {
            InitScreen5();
        }
    }
}
