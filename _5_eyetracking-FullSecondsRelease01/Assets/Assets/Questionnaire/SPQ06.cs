//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ06 : MonoBehaviour
{
    public GameObject TogGrSPQ06;


    public Text AnswerSPQ06Please;

    public static int TogSPQ06F_Increm = 0;

    public Toggle TogSPQ06True;
    public static int IntSPQ06True;
    public static bool BoolSPQ06NotEmpty = false;


    void Start()
    {
        IntSPQ06True = 2;
        AnswerSPQ06Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ06True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ06True.onValueChanged.AddListener(delegate {
            TogSPQ06TrueChanged(TogSPQ06True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ06TrueChanged(Toggle change)
    {
        BoolSPQ06NotEmpty = true;
        TogSPQ06F_Increm++;
        //if (TogSPQ06F_Increm % 2 == 0)
        if (TogSPQ06True.isOn)
        {
            IntSPQ06True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ06True-ButtonState=" + TogSPQ06True.isOn +
                " | increm=" + +TogSPQ06F_Increm +
                " | IntSPQ06True=" + IntSPQ06True +
                " | BoolSPQ06NotEmpty=" + BoolSPQ06NotEmpty);
        }
        else
        {
            IntSPQ06True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ06True-ButtonState=" + TogSPQ06True.isOn +
                " | increm=" + +TogSPQ06F_Increm +
                " | INtSPQ06True=" + IntSPQ06True +
                " | BoolSPQ06NotEmpty=" + BoolSPQ06NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ06True-ButtonState=" + TogSPQ06True.isOn +
                " | increm=" + +TogSPQ06F_Increm +
                " | IntSPQ06True=" + IntSPQ06True +
                " | BoolSPQ06NotEmpty=" + BoolSPQ06NotEmpty);
        }
        if (IntSPQ06True == 2)
        {
            AnswerSPQ06Please.text = "Please answer Question 06."
            ;
        }
        else
        {
            AnswerSPQ06Please.text = ""
            ;
        }

    }
}
