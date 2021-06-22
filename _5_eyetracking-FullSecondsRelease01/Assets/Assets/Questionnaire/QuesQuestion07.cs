//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion07 : MonoBehaviour
{

    public GameObject TogGrExclusion7Verify;

    public Text AnswerQ07Please;

    public static int TogExcl07F_Increm = 0;

    public Toggle TogExcl07True;
    public static int IntExcl07True;
    public static bool BoolExcl07NotEmpty = false;


    void Start()
    {
        IntExcl07True = 2;
        AnswerQ07Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogExcl07True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl07True.onValueChanged.AddListener(delegate 
        {
            TogExcl07TrueChanged(TogExcl07True);
        }
        );
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl07TrueChanged(Toggle change)
    {
        BoolExcl07NotEmpty = true;
        TogExcl07F_Increm++;
        //if (TogExcl07F_Increm % 2 == 0)
        if (TogExcl07True.isOn)
        {
            IntExcl07True = 1;
            Debug.Log("------------------------------------------THIS IS TogExcl07True-ButtonState=" + TogExcl07True.isOn +
                " | increm=" + +TogExcl07F_Increm +
                " | IntExcl07True=" + IntExcl07True +
                " | BoolExcl07NotEmpty=" + BoolExcl07NotEmpty);
        }
        else
        {
            IntExcl07True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl07True-ButtonState=" + TogExcl07True.isOn +
                " | increm=" + +TogExcl07F_Increm +
                " | INtExcl07True=" + IntExcl07True +
                " | BoolExcl07NotEmpty=" + BoolExcl07NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl07True-ButtonState=" + TogExcl07True.isOn +
                " | increm=" + +TogExcl07F_Increm +
                " | IntExcl07True=" + IntExcl07True +
                " | BoolExcl07NotEmpty=" + BoolExcl07NotEmpty);
        }
        if (QuesQuestion07.IntExcl07True == 2)
        {
            AnswerQ07Please.text = "Please answer Question 07."
            ;
        }
        else
        {
            AnswerQ07Please.text = " "
            ;
        }

    }
}
