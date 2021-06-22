//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion02 : MonoBehaviour
{
    public GameObject TogGrExcl02NeurologicalDisorders;

    public Text AnswerQ02Please;

    public static int TogExcl02F_Increm = 0;

    public Toggle TogExcl02True;
    public static int IntExcl02True;
    public static bool BoolExcl02NotEmpty = false;


    void Start()
    {
        IntExcl02True = 2;
        AnswerQ02Please = GetComponent<Text>();
        
        //Fetch the Toggle GameObject
        TogExcl02True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl02True.onValueChanged.AddListener(delegate {
            TogExcl02TrueChanged(TogExcl02True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl02TrueChanged(Toggle change)
    {
        BoolExcl02NotEmpty = true;
        TogExcl02F_Increm++;
        //if (TogExcl02F_Increm % 2 == 0)
        if(TogExcl02True.isOn)
        {
            IntExcl02True = 1;
            Debug.Log("------------------------------------------THIS IS TogExcl02True-ButtonState=" + TogExcl02True.isOn +
                " | increm=" + +TogExcl02F_Increm +
                " | IntExcl02True=" + IntExcl02True +
                " | BoolExcl02NotEmpty=" + BoolExcl02NotEmpty);
        }
        else
        {
            IntExcl02True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl02True-ButtonState=" + TogExcl02True.isOn +
                " | increm=" + +TogExcl02F_Increm +
                " | INtExcl02True=" + IntExcl02True +
                " | BoolExcl02NotEmpty=" + BoolExcl02NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl02True-ButtonState=" + TogExcl02True.isOn +
                " | increm=" + +TogExcl02F_Increm +
                " | IntExcl02True=" + IntExcl02True +
                " | BoolExcl02NotEmpty=" + BoolExcl02NotEmpty);
        }
        if (QuesQuestion02.IntExcl02True == 2)
        {
            AnswerQ02Please.text = "Please answer Question 02."
            ;
        }
        else
        {
            AnswerQ02Please.text = " "
            ;
        }

    }
}
