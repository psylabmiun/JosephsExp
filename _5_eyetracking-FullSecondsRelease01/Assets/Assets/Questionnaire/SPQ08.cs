//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ08 : MonoBehaviour
{
    public GameObject TogGrSPQ08;


    public Text AnswerSPQ08Please;

    public static int TogSPQ08F_Increm = 0;

    public Toggle TogSPQ08True;
    public static int IntSPQ08True;
    public static bool BoolSPQ08NotEmpty = false;


    void Start()
    {
        IntSPQ08True = 2;
        AnswerSPQ08Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ08True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ08True.onValueChanged.AddListener(delegate {
            TogSPQ08TrueChanged(TogSPQ08True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ08TrueChanged(Toggle change)
    {
        BoolSPQ08NotEmpty = true;
        TogSPQ08F_Increm++;
        //if (TogSPQ08F_Increm % 2 == 0)
        if (TogSPQ08True.isOn)
        {
            IntSPQ08True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ08True-ButtonState=" + TogSPQ08True.isOn +
                " | increm=" + +TogSPQ08F_Increm +
                " | IntSPQ08True=" + IntSPQ08True +
                " | BoolSPQ08NotEmpty=" + BoolSPQ08NotEmpty);
        }
        else
        {
            IntSPQ08True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ08True-ButtonState=" + TogSPQ08True.isOn +
                " | increm=" + +TogSPQ08F_Increm +
                " | INtSPQ08True=" + IntSPQ08True +
                " | BoolSPQ08NotEmpty=" + BoolSPQ08NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ08True-ButtonState=" + TogSPQ08True.isOn +
                " | increm=" + +TogSPQ08F_Increm +
                " | IntSPQ08True=" + IntSPQ08True +
                " | BoolSPQ08NotEmpty=" + BoolSPQ08NotEmpty);
        }
        if (IntSPQ08True == 2)
        {
            AnswerSPQ08Please.text = "Please answer Question 08."
            ;
        }
        else
        {
            AnswerSPQ08Please.text = ""
            ;
        }

    }
}
