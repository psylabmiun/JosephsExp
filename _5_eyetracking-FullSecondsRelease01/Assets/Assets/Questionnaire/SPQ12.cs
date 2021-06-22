//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ12 : MonoBehaviour
{
    public GameObject TogGrSPQ12;


    public Text AnswerSPQ12Please;

    public static int TogSPQ12F_Increm = 0;

    public Toggle TogSPQ12True;
    public static int IntSPQ12True;
    public static bool BoolSPQ12NotEmpty = false;


    void Start()
    {
        IntSPQ12True = 2;
        AnswerSPQ12Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ12True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ12True.onValueChanged.AddListener(delegate 
        {
            TogSPQ12TrueChanged(TogSPQ12True);
        }
        );
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ12TrueChanged(Toggle change)
    {
        BoolSPQ12NotEmpty = true;
        TogSPQ12F_Increm++;
        //if (TogSPQ12F_Increm % 2 == 0)
        if (TogSPQ12True.isOn)
        {
            IntSPQ12True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ12True-ButtonState=" + TogSPQ12True.isOn +
                " | increm=" + +TogSPQ12F_Increm +
                " | IntSPQ12True=" + IntSPQ12True +
                " | BoolSPQ12NotEmpty=" + BoolSPQ12NotEmpty);
        }
        else
        {
            IntSPQ12True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ12True-ButtonState=" + TogSPQ12True.isOn +
                " | increm=" + +TogSPQ12F_Increm +
                " | INtSPQ12True=" + IntSPQ12True +
                " | BoolSPQ12NotEmpty=" + BoolSPQ12NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ12True-ButtonState=" + TogSPQ12True.isOn +
                " | increm=" + +TogSPQ12F_Increm +
                " | IntSPQ12True=" + IntSPQ12True +
                " | BoolSPQ12NotEmpty=" + BoolSPQ12NotEmpty);
        }
        if (IntSPQ12True == 2)
        {
            AnswerSPQ12Please.text = "Please answer Question 12.";
        }
        else
        {
            AnswerSPQ12Please.text = ""
            ;
        }

    }
}
