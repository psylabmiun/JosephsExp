//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion06 : MonoBehaviour
{
    public GameObject TogGrExcl06Vision;


    public Text AnswerQ06Please;

    public static int TogExcl06F_Increm = 0;

    public Toggle TogExcl06True;
    public static int IntExcl06True;
    public static bool BoolExcl06NotEmpty = false;


    void Start()
    {
        IntExcl06True = 2;
        AnswerQ06Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogExcl06True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl06True.onValueChanged.AddListener(delegate {
            TogExcl06TrueChanged(TogExcl06True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl06TrueChanged(Toggle change)
    {
        BoolExcl06NotEmpty = true;
        TogExcl06F_Increm++;
        //if (TogExcl06F_Increm % 2 == 0)
        if (TogExcl06True.isOn)
        {
            IntExcl06True = 1;
            Debug.Log("------------------------------------------THIS IS TogExcl06True-ButtonState=" + TogExcl06True.isOn +
                " | increm=" + +TogExcl06F_Increm +
                " | IntExcl06True=" + IntExcl06True +
                " | BoolExcl06NotEmpty=" + BoolExcl06NotEmpty);
        }
        else
        {
            IntExcl06True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl06True-ButtonState=" + TogExcl06True.isOn +
                " | increm=" + +TogExcl06F_Increm +
                " | INtExcl06True=" + IntExcl06True +
                " | BoolExcl06NotEmpty=" + BoolExcl06NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl06True-ButtonState=" + TogExcl06True.isOn +
                " | increm=" + +TogExcl06F_Increm +
                " | IntExcl06True=" + IntExcl06True +
                " | BoolExcl06NotEmpty=" + BoolExcl06NotEmpty);
        }
        if (QuesQuestion06.IntExcl06True == 2)
        {
            AnswerQ06Please.text = "Please answer Question 06."
            ;
        }
        else
        {
            AnswerQ06Please.text = " "
            ;
        }

    }
}
