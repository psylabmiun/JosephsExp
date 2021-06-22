//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ08FalseListener : MonoBehaviour
{
    public SPQ08 sPQ08;

    public GameObject TogGrSPQ08;

    public Toggle TogSPQ08False;
    public int IntSPQ08True = 2;
    public bool BoolSPQ08NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ08False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ08False.onValueChanged.AddListener(delegate {
            TogSPQ08FalseChanged(TogSPQ08False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ08FalseChanged(Toggle change)
    {
        SPQ08.BoolSPQ08NotEmpty = true;
        SPQ08.TogSPQ08F_Increm++;
        if (TogSPQ08False.isOn)
        {
            SPQ08.IntSPQ08True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ08True-ButtonState=" + TogSPQ08False.isOn +
                " | increm=" + SPQ08.TogSPQ08F_Increm +
                " | IntSPQ08True=" + SPQ08.IntSPQ08True +
                " | BoolSPQ08NotEmpty=" + SPQ08.BoolSPQ08NotEmpty);
        }
        else
        {
            SPQ08.IntSPQ08True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ08True-ButtonState=" + TogSPQ08False.isOn +
                " | increm=" + SPQ08.TogSPQ08F_Increm +
                " | INtSPQ08True=" + IntSPQ08True +
                " | BoolSPQ08NotEmpty=" + SPQ08.BoolSPQ08NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ08True-ButtonState=" + TogSPQ08False.isOn +
                " | increm=" + SPQ08.TogSPQ08F_Increm +
                " | IntSPQ08True=" + SPQ08.IntSPQ08True +
                " | BoolSPQ08NotEmpty=" + SPQ08.BoolSPQ08NotEmpty);
        }
    }
}
