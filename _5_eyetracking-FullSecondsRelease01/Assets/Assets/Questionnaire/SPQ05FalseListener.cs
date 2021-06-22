//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ05FalseListener : MonoBehaviour
{
    public SPQ05 sPQ05;

    public GameObject TogGrSPQ05;

    public Toggle TogSPQ05False;
    public int IntSPQ05True = 2;
    public bool BoolSPQ05NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ05False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ05False.onValueChanged.AddListener(delegate {
            TogSPQ05FalseChanged(TogSPQ05False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ05FalseChanged(Toggle change)
    {
        SPQ05.BoolSPQ05NotEmpty = true;
        SPQ05.TogSPQ05F_Increm++;
        if (TogSPQ05False.isOn)
        {
            SPQ05.IntSPQ05True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ05True-ButtonState=" + TogSPQ05False.isOn +
                " | increm=" + SPQ05.TogSPQ05F_Increm +
                " | IntSPQ05True=" + SPQ05.IntSPQ05True +
                " | BoolSPQ05NotEmpty=" + SPQ05.BoolSPQ05NotEmpty);
        }
        else
        {
            SPQ05.IntSPQ05True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ05True-ButtonState=" + TogSPQ05False.isOn +
                " | increm=" + SPQ05.TogSPQ05F_Increm +
                " | INtSPQ05True=" + IntSPQ05True +
                " | BoolSPQ05NotEmpty=" + SPQ05.BoolSPQ05NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ05True-ButtonState=" + TogSPQ05False.isOn +
                " | increm=" + SPQ05.TogSPQ05F_Increm +
                " | IntSPQ05True=" + SPQ05.IntSPQ05True +
                " | BoolSPQ05NotEmpty=" + SPQ05.BoolSPQ05NotEmpty);
        }
    }
}
