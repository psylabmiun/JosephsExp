//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ02FalseListener : MonoBehaviour
{
    public SPQ02 sPQ02;

    public GameObject TogGrSPQ02;

    public Toggle TogSPQ02False;
    public int IntSPQ02True = 2;
    public bool BoolSPQ02NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ02False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ02False.onValueChanged.AddListener(delegate {
            TogSPQ02FalseChanged(TogSPQ02False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ02FalseChanged(Toggle change)
    {
        SPQ02.BoolSPQ02NotEmpty = true;
        SPQ02.TogSPQ02F_Increm++;
        if (TogSPQ02False.isOn)
        {
            SPQ02.IntSPQ02True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ02True-ButtonState=" + TogSPQ02False.isOn +
                " | increm=" + SPQ02.TogSPQ02F_Increm +
                " | IntSPQ02True=" + SPQ02.IntSPQ02True +
                " | BoolSPQ02NotEmpty=" + SPQ02.BoolSPQ02NotEmpty);
        }
        else
        {
            SPQ02.IntSPQ02True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ02True-ButtonState=" + TogSPQ02False.isOn +
                " | increm=" + SPQ02.TogSPQ02F_Increm +
                " | INtSPQ02True=" + IntSPQ02True +
                " | BoolSPQ02NotEmpty=" + SPQ02.BoolSPQ02NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ02True-ButtonState=" + TogSPQ02False.isOn +
                " | increm=" + SPQ02.TogSPQ02F_Increm +
                " | IntSPQ02True=" + SPQ02.IntSPQ02True +
                " | BoolSPQ02NotEmpty=" + SPQ02.BoolSPQ02NotEmpty);
        }
    }
}
