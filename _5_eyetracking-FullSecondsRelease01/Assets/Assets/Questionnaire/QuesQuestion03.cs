//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion03 : MonoBehaviour
{
    public GameObject TogGrExcl03Psychotropic;

    public Text AnswerQ03Please;

    public static int TogExcl03F_Increm = 0;

    public Toggle TogExcl03True;
    public static int IntExcl03True;
    public static bool BoolExcl03NotEmpty = false;


    void Start()
    {
        IntExcl03True = 2;
        AnswerQ03Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogExcl03True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl03True.onValueChanged.AddListener(delegate {
            TogExcl03TrueChanged(TogExcl03True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl03TrueChanged(Toggle change)
    {
        BoolExcl03NotEmpty = true;
        TogExcl03F_Increm++;
        //if (TogExcl03F_Increm % 2 == 0)
        if (TogExcl03True.isOn)
        {
            IntExcl03True = 1;
            Debug.Log("------------------------------------------THIS IS TogExcl03True-ButtonState=" + TogExcl03True.isOn +
                " | increm=" + +TogExcl03F_Increm +
                " | IntExcl03True=" + IntExcl03True +
                " | BoolExcl03NotEmpty=" + BoolExcl03NotEmpty);
        }
        else
        {
            IntExcl03True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl03True-ButtonState=" + TogExcl03True.isOn +
                " | increm=" + +TogExcl03F_Increm +
                " | INtExcl03True=" + IntExcl03True +
                " | BoolExcl03NotEmpty=" + BoolExcl03NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl03True-ButtonState=" + TogExcl03True.isOn +
                " | increm=" + +TogExcl03F_Increm +
                " | IntExcl03True=" + IntExcl03True +
                " | BoolExcl03NotEmpty=" + BoolExcl03NotEmpty);
        }
        if (QuesQuestion03.IntExcl03True == 2)
        {
            AnswerQ03Please.text = "Please answer Question 03.";
        }
        else
        {
            AnswerQ03Please.text = "";
        }

    }
}
