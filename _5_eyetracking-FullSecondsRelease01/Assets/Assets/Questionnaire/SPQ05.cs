//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ05 : MonoBehaviour
{
    public GameObject TogGrSPQ05;


    public Text AnswerSPQ05Please;

    public static int TogSPQ05F_Increm = 0;

    public Toggle TogSPQ05True;
    public static int IntSPQ05True;
    public static bool BoolSPQ05NotEmpty = false;


    void Start()
    {
        IntSPQ05True = 2;
        AnswerSPQ05Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ05True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ05True.onValueChanged.AddListener(delegate {
            TogSPQ05TrueChanged(TogSPQ05True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ05TrueChanged(Toggle change)
    {
        BoolSPQ05NotEmpty = true;
        TogSPQ05F_Increm++;
        //if (TogSPQ05F_Increm % 2 == 0)
        if (TogSPQ05True.isOn)
        {
            IntSPQ05True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ05True-ButtonState=" + TogSPQ05True.isOn +
                " | increm=" + +TogSPQ05F_Increm +
                " | IntSPQ05True=" + IntSPQ05True +
                " | BoolSPQ05NotEmpty=" + BoolSPQ05NotEmpty);
        }
        else
        {
            IntSPQ05True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ05True-ButtonState=" + TogSPQ05True.isOn +
                " | increm=" + +TogSPQ05F_Increm +
                " | INtSPQ05True=" + IntSPQ05True +
                " | BoolSPQ05NotEmpty=" + BoolSPQ05NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ05True-ButtonState=" + TogSPQ05True.isOn +
                " | increm=" + +TogSPQ05F_Increm +
                " | IntSPQ05True=" + IntSPQ05True +
                " | BoolSPQ05NotEmpty=" + BoolSPQ05NotEmpty);
        }
        if (IntSPQ05True == 2)
        {
            AnswerSPQ05Please.text = "Please answer Question 05."
            ;
        }
        else
        {
            AnswerSPQ05Please.text = ""
            ;
        }

    }
}
