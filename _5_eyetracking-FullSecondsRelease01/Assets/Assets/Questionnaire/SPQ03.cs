//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ03 : MonoBehaviour
{
    public GameObject TogGrSPQ03;


    public Text AnswerSPQ03Please;

    public static int TogSPQ03F_Increm = 0;

    public Toggle TogSPQ03True;
    public static int IntSPQ03True;
    public static bool BoolSPQ03NotEmpty = false;


    void Start()
    {
        IntSPQ03True = 2;
        AnswerSPQ03Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ03True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ03True.onValueChanged.AddListener(delegate {
            TogSPQ03TrueChanged(TogSPQ03True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ03TrueChanged(Toggle change)
    {
        BoolSPQ03NotEmpty = true;
        TogSPQ03F_Increm++;
        //if (TogSPQ03F_Increm % 2 == 0)
        if (TogSPQ03True.isOn)
        {
            IntSPQ03True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ03True-ButtonState=" + TogSPQ03True.isOn +
                " | increm=" + +TogSPQ03F_Increm +
                " | IntSPQ03True=" + IntSPQ03True +
                " | BoolSPQ03NotEmpty=" + BoolSPQ03NotEmpty);
        }
        else
        {
            IntSPQ03True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ03True-ButtonState=" + TogSPQ03True.isOn +
                " | increm=" + +TogSPQ03F_Increm +
                " | INtSPQ03True=" + IntSPQ03True +
                " | BoolSPQ03NotEmpty=" + BoolSPQ03NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ03True-ButtonState=" + TogSPQ03True.isOn +
                " | increm=" + +TogSPQ03F_Increm +
                " | IntSPQ03True=" + IntSPQ03True +
                " | BoolSPQ03NotEmpty=" + BoolSPQ03NotEmpty);
        }
        if (IntSPQ03True == 2)
        {
            AnswerSPQ03Please.text = "Please answer Question 03."
            ;
        }
        else
        {
            AnswerSPQ03Please.text = ""
            ;
        }

    }
}
