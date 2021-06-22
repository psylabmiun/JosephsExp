//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ01FalseListener : MonoBehaviour
{
    public SPQ01Question sPQ01Question;

    public GameObject TogGrSPQ01;

    public Toggle TogSPQ01False;
    public int IntSPQ01True = 2;
    public bool BoolSPQ01NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ01False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ01False.onValueChanged.AddListener(delegate {
            TogSPQ01FalseChanged(TogSPQ01False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ01FalseChanged(Toggle change)
    {
        SPQ01Question.BoolSPQ01NotEmpty = true;
        SPQ01Question.TogSPQ01F_Increm++;
        if (TogSPQ01False.isOn)
        {
            SPQ01Question.IntSPQ01True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ01True-ButtonState=" + TogSPQ01False.isOn +
                " | increm=" + SPQ01Question.TogSPQ01F_Increm +
                " | IntSPQ01True=" + SPQ01Question.IntSPQ01True +
                " | BoolSPQ01NotEmpty=" + SPQ01Question.BoolSPQ01NotEmpty);
        }
        else
        {
            SPQ01Question.IntSPQ01True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ01True-ButtonState=" + TogSPQ01False.isOn +
                " | increm=" + SPQ01Question.TogSPQ01F_Increm +
                " | INtSPQ01True=" + IntSPQ01True +
                " | BoolSPQ01NotEmpty=" + SPQ01Question.BoolSPQ01NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ01True-ButtonState=" + TogSPQ01False.isOn +
                " | increm=" + SPQ01Question.TogSPQ01F_Increm +
                " | IntSPQ01True=" + SPQ01Question.IntSPQ01True +
                " | BoolSPQ01NotEmpty=" + SPQ01Question.BoolSPQ01NotEmpty);
        }
    }
}
