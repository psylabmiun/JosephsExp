//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ10 : MonoBehaviour
{
    public GameObject TogGrSPQ10;


    public Text AnswerSPQ10Please;

    public static int TogSPQ10F_Increm = 0;

    public Toggle TogSPQ10True;
    public static int IntSPQ10True;
    public static bool BoolSPQ10NotEmpty = false;


    void Start()
    {
        IntSPQ10True = 2;
        AnswerSPQ10Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ10True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ10True.onValueChanged.AddListener(delegate {
            TogSPQ10TrueChanged(TogSPQ10True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ10TrueChanged(Toggle change)
    {
        BoolSPQ10NotEmpty = true;
        TogSPQ10F_Increm++;
        //if (TogSPQ10F_Increm % 2 == 0)
        if (TogSPQ10True.isOn)
        {
            IntSPQ10True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ10True-ButtonState=" + TogSPQ10True.isOn +
                " | increm=" + +TogSPQ10F_Increm +
                " | IntSPQ10True=" + IntSPQ10True +
                " | BoolSPQ10NotEmpty=" + BoolSPQ10NotEmpty);
        }
        else
        {
            IntSPQ10True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ10True-ButtonState=" + TogSPQ10True.isOn +
                " | increm=" + +TogSPQ10F_Increm +
                " | INtSPQ10True=" + IntSPQ10True +
                " | BoolSPQ10NotEmpty=" + BoolSPQ10NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ10True-ButtonState=" + TogSPQ10True.isOn +
                " | increm=" + +TogSPQ10F_Increm +
                " | IntSPQ10True=" + IntSPQ10True +
                " | BoolSPQ10NotEmpty=" + BoolSPQ10NotEmpty);
        }
        if (IntSPQ10True == 2)
        {
            AnswerSPQ10Please.text = "Please answer Question 10."
            ;
        }
        else
        {
            AnswerSPQ10Please.text = ""
            ;
        }

    }
}
