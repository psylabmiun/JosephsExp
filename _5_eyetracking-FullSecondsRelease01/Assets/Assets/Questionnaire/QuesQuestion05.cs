//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion05 : MonoBehaviour
{

    public GameObject TogGrExcl05Depression;

    public Text AnswerQ05Please;

    public static int TogExcl05F_Increm = 0;

    public Toggle TogExcl05True;
    public static int IntExcl05True;
    public static bool BoolExcl05NotEmpty = false;


    void Start()
    {
        IntExcl05True = 2;
        AnswerQ05Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogExcl05True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl05True.onValueChanged.AddListener(delegate {
            TogExcl05TrueChanged(TogExcl05True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl05TrueChanged(Toggle change)
    {
        BoolExcl05NotEmpty = true;
        TogExcl05F_Increm++;
        //if (TogExcl05F_Increm % 2 == 0)
        if (TogExcl05True.isOn)
        {
            IntExcl05True = 1;
            Debug.Log("------------------------------------------THIS IS TogExcl05True-ButtonState=" + TogExcl05True.isOn +
                " | increm=" + +TogExcl05F_Increm +
                " | IntExcl05True=" + IntExcl05True +
                " | BoolExcl05NotEmpty=" + BoolExcl05NotEmpty);
        }
        else
        {
            IntExcl05True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl05True-ButtonState=" + TogExcl05True.isOn +
                " | increm=" + +TogExcl05F_Increm +
                " | INtExcl05True=" + IntExcl05True +
                " | BoolExcl05NotEmpty=" + BoolExcl05NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl05True-ButtonState=" + TogExcl05True.isOn +
                " | increm=" + +TogExcl05F_Increm +
                " | IntExcl05True=" + IntExcl05True +
                " | BoolExcl05NotEmpty=" + BoolExcl05NotEmpty);
        }
        if (QuesQuestion05.IntExcl05True == 2)
        {
            AnswerQ05Please.text = "Please answer Question 05."
            ;
        }
        else
        {
            AnswerQ05Please.text = " "
            ;
        }

    }
}
