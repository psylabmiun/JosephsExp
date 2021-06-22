//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ01Question : MonoBehaviour
{
   
    public GameObject TogGrSPQ01;


    public Text AnswerSPQ01Please;

    public static int TogSPQ01F_Increm = 0;

    public Toggle TogSPQ01True;
    public static int IntSPQ01True;
    public static bool BoolSPQ01NotEmpty = false;


    void Start()
    {
        IntSPQ01True = 2;
        AnswerSPQ01Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ01True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ01True.onValueChanged.AddListener(delegate {
            TogSPQ01TrueChanged(TogSPQ01True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ01TrueChanged(Toggle change)
    {
        BoolSPQ01NotEmpty = true;
        TogSPQ01F_Increm++;
        //if (TogSPQ01F_Increm % 2 == 0)
        if (TogSPQ01True.isOn)
        {
            IntSPQ01True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ01True-ButtonState=" + TogSPQ01True.isOn +
                " | increm=" + +TogSPQ01F_Increm +
                " | IntSPQ01True=" + IntSPQ01True +
                " | BoolSPQ01NotEmpty=" + BoolSPQ01NotEmpty);
        }
        else
        {
            IntSPQ01True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ01True-ButtonState=" + TogSPQ01True.isOn +
                " | increm=" + +TogSPQ01F_Increm +
                " | INtSPQ01True=" + IntSPQ01True +
                " | BoolSPQ01NotEmpty=" + BoolSPQ01NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ01True-ButtonState=" + TogSPQ01True.isOn +
                " | increm=" + +TogSPQ01F_Increm +
                " | IntSPQ01True=" + IntSPQ01True +
                " | BoolSPQ01NotEmpty=" + BoolSPQ01NotEmpty);
        }
        if (IntSPQ01True == 2)
        {
            AnswerSPQ01Please.text = "Please answer Question 01."
            ;
        }
        else
        {
            AnswerSPQ01Please.text = ""
            ;
        }

    }
}
