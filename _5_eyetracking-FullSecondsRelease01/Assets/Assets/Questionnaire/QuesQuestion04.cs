//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion04 : MonoBehaviour
{
    public GameObject TogGrExcl04AlcoDrugsMeds;

    public Text AnswerQ04Please;

    public static int TogExcl04F_Increm = 0;

    public Toggle TogExcl04True;
    public static int IntExcl04True;
    public static bool BoolExcl04NotEmpty = false;


    void Start()
    {
        IntExcl04True = 2;
        AnswerQ04Please = GetComponent<Text>();

        //Fetch the Toggle GameObject
        TogExcl04True = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl04True.onValueChanged.AddListener(delegate {
            TogExcl04TrueChanged(TogExcl04True);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl04TrueChanged(Toggle change)
    {
        BoolExcl04NotEmpty = true;
        TogExcl04F_Increm++;
        //if (TogExcl04F_Increm % 2 == 0)
        if (TogExcl04True.isOn)
        {
            IntExcl04True = 1;
            Debug.Log("------------------------------------------THIS IS TogExcl04True-ButtonState=" + TogExcl04True.isOn +
                " | increm=" + +TogExcl04F_Increm +
                " | IntExcl04True=" + IntExcl04True +
                " | BoolExcl04NotEmpty=" + BoolExcl04NotEmpty);
        }
        else
        {
            IntExcl04True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl04True-ButtonState=" + TogExcl04True.isOn +
                " | increm=" + +TogExcl04F_Increm +
                " | INtExcl04True=" + IntExcl04True +
                " | BoolExcl04NotEmpty=" + BoolExcl04NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl04True-ButtonState=" + TogExcl04True.isOn +
                " | increm=" + +TogExcl04F_Increm +
                " | IntExcl04True=" + IntExcl04True +
                " | BoolExcl04NotEmpty=" + BoolExcl04NotEmpty);
        }
        if (QuesQuestion04.IntExcl04True == 2)
        {
            AnswerQ04Please.text = "Please answer Question 04."
            ;
        }
        else
        {
            AnswerQ04Please.text = " "
            ;
        }

    }
}
