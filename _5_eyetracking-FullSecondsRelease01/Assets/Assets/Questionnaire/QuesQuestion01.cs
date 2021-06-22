//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;


public class QuesQuestion01 : MonoBehaviour
{

    public GameObject TogGrExcl01BrainDamage;


    public Text AnswerQ01Please;

    public static int TogExcl01F_Increm = 0;

    public Toggle TogExcl01True;
    public static int IntExcl01True;
    public static bool BoolExcl01NotEmpty = false;


    void Start()
    {
        IntExcl01True = 2;
        AnswerQ01Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogExcl01True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl01True.onValueChanged.AddListener(delegate {
            TogExcl01TrueChanged(TogExcl01True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl01TrueChanged(Toggle change)
    {
        BoolExcl01NotEmpty = true;
        TogExcl01F_Increm++;
        //if (TogExcl01F_Increm % 2 == 0)
        if (TogExcl01True.isOn)
        {
            IntExcl01True = 1;
            Debug.Log("------------------------------------------THIS IS TogExcl01True-ButtonState=" + TogExcl01True.isOn +
                " | increm=" + +TogExcl01F_Increm +
                " | IntExcl01True=" + IntExcl01True +
                " | BoolExcl01NotEmpty=" + BoolExcl01NotEmpty);
        }
        else
        {
            IntExcl01True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl01True-ButtonState=" + TogExcl01True.isOn +
                " | increm=" + +TogExcl01F_Increm +
                " | INtExcl01True=" + IntExcl01True +
                " | BoolExcl01NotEmpty=" + BoolExcl01NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl01True-ButtonState=" + TogExcl01True.isOn +
                " | increm=" + +TogExcl01F_Increm +
                " | IntExcl01True=" + IntExcl01True +
                " | BoolExcl01NotEmpty=" + BoolExcl01NotEmpty);
        }
        if (QuesQuestion01.IntExcl01True == 2)
        {
            AnswerQ01Please.text = "Please answer Question 01."
            ;
        }
        else
        {
            AnswerQ01Please.text = ""
            ;
        }

    }
}
