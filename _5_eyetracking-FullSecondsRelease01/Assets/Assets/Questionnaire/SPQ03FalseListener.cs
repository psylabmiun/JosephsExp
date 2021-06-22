//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ03FalseListener : MonoBehaviour
{
    public SPQ03 sPQ03;

    public GameObject TogGrSPQ03;

    public Toggle TogSPQ03False;
    public int IntSPQ03True = 2;
    public bool BoolSPQ03NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ03False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ03False.onValueChanged.AddListener(delegate {TogSPQ03FalseChanged(TogSPQ03False);});
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ03FalseChanged(Toggle change)
    {
        SPQ03.BoolSPQ03NotEmpty = true;
        SPQ03.TogSPQ03F_Increm++;
        if (TogSPQ03False.isOn)
        {
            SPQ03.IntSPQ03True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ03True-ButtonState=" + TogSPQ03False.isOn +
                " | increm=" + SPQ03.TogSPQ03F_Increm +
                " | IntSPQ03True=" + SPQ03.IntSPQ03True +
                " | BoolSPQ03NotEmpty=" + SPQ03.BoolSPQ03NotEmpty);
        }
        else
        {
            SPQ03.IntSPQ03True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ03True-ButtonState=" + TogSPQ03False.isOn +
                " | increm=" + SPQ03.TogSPQ03F_Increm +
                " | INtSPQ03True=" + IntSPQ03True +
                " | BoolSPQ03NotEmpty=" + SPQ03.BoolSPQ03NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ03True-ButtonState=" + TogSPQ03False.isOn +
                " | increm=" + SPQ03.TogSPQ03F_Increm +
                " | IntSPQ03True=" + SPQ03.IntSPQ03True +
                " | BoolSPQ03NotEmpty=" + SPQ03.BoolSPQ03NotEmpty);
        }
    }
}
