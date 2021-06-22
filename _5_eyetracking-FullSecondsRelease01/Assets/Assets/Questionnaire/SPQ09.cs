//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ09 : MonoBehaviour
{
    public GameObject TogGrSPQ09;


    public Text AnswerSPQ09Please;

    public static int TogSPQ09F_Increm = 0;

    public Toggle TogSPQ09True;
    public static int IntSPQ09True;
    public static bool BoolSPQ09NotEmpty = false;


    void Start()
    {
        IntSPQ09True = 2;
        AnswerSPQ09Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogSPQ09True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ09True.onValueChanged.AddListener(delegate {
            TogSPQ09TrueChanged(TogSPQ09True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ09TrueChanged(Toggle change)
    {
        BoolSPQ09NotEmpty = true;
        TogSPQ09F_Increm++;
        //if (TogSPQ09F_Increm % 2 == 0)
        if (TogSPQ09True.isOn)
        {
            IntSPQ09True = 1;
            Debug.Log("------------------------------------------THIS IS TogSPQ09True-ButtonState=" + TogSPQ09True.isOn +
                " | increm=" + +TogSPQ09F_Increm +
                " | IntSPQ09True=" + IntSPQ09True +
                " | BoolSPQ09NotEmpty=" + BoolSPQ09NotEmpty);
        }
        else
        {
            IntSPQ09True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ09True-ButtonState=" + TogSPQ09True.isOn +
                " | increm=" + +TogSPQ09F_Increm +
                " | INtSPQ09True=" + IntSPQ09True +
                " | BoolSPQ09NotEmpty=" + BoolSPQ09NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ09True-ButtonState=" + TogSPQ09True.isOn +
                " | increm=" + +TogSPQ09F_Increm +
                " | IntSPQ09True=" + IntSPQ09True +
                " | BoolSPQ09NotEmpty=" + BoolSPQ09NotEmpty);
        }
        if (IntSPQ09True == 2)
        {
            AnswerSPQ09Please.text = "Please answer Question 09."
            ;
        }
        else
        {
            AnswerSPQ09Please.text = ""
            ;
        }

    }
}
