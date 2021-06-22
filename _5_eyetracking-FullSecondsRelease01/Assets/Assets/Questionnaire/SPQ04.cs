//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ04 : MonoBehaviour
{
    public GameObject TogGrSPQ04;


    public Text AnswerSPQ04Please;

    public static int TogSPQ04F_Increm = 0;

    public Toggle TogSPQ04True;
    public static int IntSPQ04True;
    public static bool BoolSPQ04NotEmpty = false;


    void Start()
    {
        IntSPQ04True = 2;
        AnswerSPQ04Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ04True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ04True.onValueChanged.AddListener(delegate {
            TogSPQ04TrueChanged(TogSPQ04True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ04TrueChanged(Toggle change)
    {
        BoolSPQ04NotEmpty = true;
        TogSPQ04F_Increm++;
        //if (TogSPQ04F_Increm % 2 == 0)
        if (TogSPQ04True.isOn)
        {
            IntSPQ04True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ04True-ButtonState=" + TogSPQ04True.isOn +
                " | increm=" + +TogSPQ04F_Increm +
                " | IntSPQ04True=" + IntSPQ04True +
                " | BoolSPQ04NotEmpty=" + BoolSPQ04NotEmpty);
        }
        else
        {
            IntSPQ04True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ04True-ButtonState=" + TogSPQ04True.isOn +
                " | increm=" + +TogSPQ04F_Increm +
                " | INtSPQ04True=" + IntSPQ04True +
                " | BoolSPQ04NotEmpty=" + BoolSPQ04NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ04True-ButtonState=" + TogSPQ04True.isOn +
                " | increm=" + +TogSPQ04F_Increm +
                " | IntSPQ04True=" + IntSPQ04True +
                " | BoolSPQ04NotEmpty=" + BoolSPQ04NotEmpty);
        }
        if (IntSPQ04True == 2)
        {
            AnswerSPQ04Please.text = "Please answer Question 04."
            ;
        }
        else
        {
            AnswerSPQ04Please.text = ""
            ;
        }

    }
}
