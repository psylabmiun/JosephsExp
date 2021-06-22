//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ02 : MonoBehaviour
{
    public GameObject TogGrSPQ02;


    public Text AnswerSPQ02Please;

    public static int TogSPQ02F_Increm = 0;

    public Toggle TogSPQ02True;
    public static int IntSPQ02True;
    public static bool BoolSPQ02NotEmpty = false;


    void Start()
    {
        IntSPQ02True = 2;
        AnswerSPQ02Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ02True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ02True.onValueChanged.AddListener(delegate {
            TogSPQ02TrueChanged(TogSPQ02True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ02TrueChanged(Toggle change)
    {
        BoolSPQ02NotEmpty = true;
        TogSPQ02F_Increm++;
        //if (TogSPQ02F_Increm % 2 == 0)
        if (TogSPQ02True.isOn)
        {
            IntSPQ02True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ02True-ButtonState=" + TogSPQ02True.isOn +
                " | increm=" + +TogSPQ02F_Increm +
                " | IntSPQ02True=" + IntSPQ02True +
                " | BoolSPQ02NotEmpty=" + BoolSPQ02NotEmpty);
        }
        else
        {
            IntSPQ02True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ02True-ButtonState=" + TogSPQ02True.isOn +
                " | increm=" + +TogSPQ02F_Increm +
                " | INtSPQ02True=" + IntSPQ02True +
                " | BoolSPQ02NotEmpty=" + BoolSPQ02NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ02True-ButtonState=" + TogSPQ02True.isOn +
                " | increm=" + +TogSPQ02F_Increm +
                " | IntSPQ02True=" + IntSPQ02True +
                " | BoolSPQ02NotEmpty=" + BoolSPQ02NotEmpty);
        }
        if (IntSPQ02True == 2)
        {
            AnswerSPQ02Please.text = "Please answer Question 02."
            ;
        }
        else
        {
            AnswerSPQ02Please.text = ""
            ;
        }

    }
}
