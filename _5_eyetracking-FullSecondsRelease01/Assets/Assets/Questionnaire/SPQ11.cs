//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ11 : MonoBehaviour
{
    public GameObject TogGrSPQ11;


    public Text AnswerSPQ11Please;

    public static int TogSPQ11F_Increm = 0;

    public Toggle TogSPQ11True;
    public static int IntSPQ11True;
    public static bool BoolSPQ11NotEmpty = false;


    void Start()
    {
        IntSPQ11True = 2;
        AnswerSPQ11Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ11True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ11True.onValueChanged.AddListener(delegate {
            TogSPQ11TrueChanged(TogSPQ11True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ11TrueChanged(Toggle change)
    {
        BoolSPQ11NotEmpty = true;
        TogSPQ11F_Increm++;
        //if (TogSPQ11F_Increm % 2 == 0)
        if (TogSPQ11True.isOn)
        {
            IntSPQ11True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ11True-ButtonState=" + TogSPQ11True.isOn +
                " | increm=" + +TogSPQ11F_Increm +
                " | IntSPQ11True=" + IntSPQ11True +
                " | BoolSPQ11NotEmpty=" + BoolSPQ11NotEmpty);
        }
        else
        {
            IntSPQ11True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ11True-ButtonState=" + TogSPQ11True.isOn +
                " | increm=" + +TogSPQ11F_Increm +
                " | INtSPQ11True=" + IntSPQ11True +
                " | BoolSPQ11NotEmpty=" + BoolSPQ11NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ11True-ButtonState=" + TogSPQ11True.isOn +
                " | increm=" + +TogSPQ11F_Increm +
                " | IntSPQ11True=" + IntSPQ11True +
                " | BoolSPQ11NotEmpty=" + BoolSPQ11NotEmpty);
        }
        if (IntSPQ11True == 2)
        {
            AnswerSPQ11Please.text = "Please answer Question 11."
            ;
        }
        else
        {
            AnswerSPQ11Please.text = ""
            ;
        }

    }
}
