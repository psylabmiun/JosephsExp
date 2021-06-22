//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ07 : MonoBehaviour
{
    public GameObject TogGrSPQ07;


    public Text AnswerSPQ07Please;

    public static int TogSPQ07F_Increm = 0;

    public Toggle TogSPQ07True;
    public static int IntSPQ07True;
    public static bool BoolSPQ07NotEmpty = false;


    void Start()
    {
        IntSPQ07True = 2;
        AnswerSPQ07Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ07True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ07True.onValueChanged.AddListener(delegate {
            TogSPQ07TrueChanged(TogSPQ07True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ07TrueChanged(Toggle change)
    {
        BoolSPQ07NotEmpty = true;
        TogSPQ07F_Increm++;
        //if (TogSPQ07F_Increm % 2 == 0)
        if (TogSPQ07True.isOn)
        {
            IntSPQ07True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ07True-ButtonState=" + TogSPQ07True.isOn +
                " | increm=" + +TogSPQ07F_Increm +
                " | IntSPQ07True=" + IntSPQ07True +
                " | BoolSPQ07NotEmpty=" + BoolSPQ07NotEmpty);
        }
        else
        {
            IntSPQ07True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ07True-ButtonState=" + TogSPQ07True.isOn +
                " | increm=" + +TogSPQ07F_Increm +
                " | INtSPQ07True=" + IntSPQ07True +
                " | BoolSPQ07NotEmpty=" + BoolSPQ07NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ07True-ButtonState=" + TogSPQ07True.isOn +
                " | increm=" + +TogSPQ07F_Increm +
                " | IntSPQ07True=" + IntSPQ07True +
                " | BoolSPQ07NotEmpty=" + BoolSPQ07NotEmpty);
        }
        if (IntSPQ07True == 2)
        {
            AnswerSPQ07Please.text = "Please answer Question 07."
            ;
        }
        else
        {
            AnswerSPQ07Please.text = ""
            ;
        }

    }
}
