//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ06FalseListener : MonoBehaviour
{
    public SPQ06 sPQ06;

    public GameObject TogGrSPQ06;

    public Toggle TogSPQ06False;
    public int IntSPQ06True = 2;
    public bool BoolSPQ06NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ06False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ06False.onValueChanged.AddListener(delegate {
            TogSPQ06FalseChanged(TogSPQ06False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ06FalseChanged(Toggle change)
    {
        SPQ06.BoolSPQ06NotEmpty = true;
        SPQ06.TogSPQ06F_Increm++;
        if (TogSPQ06False.isOn)
        {
            SPQ06.IntSPQ06True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ06True-ButtonState=" + TogSPQ06False.isOn +
                " | increm=" + SPQ06.TogSPQ06F_Increm +
                " | IntSPQ06True=" + SPQ06.IntSPQ06True +
                " | BoolSPQ06NotEmpty=" + SPQ06.BoolSPQ06NotEmpty);
        }
        else
        {
            SPQ06.IntSPQ06True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ06True-ButtonState=" + TogSPQ06False.isOn +
                " | increm=" + SPQ06.TogSPQ06F_Increm +
                " | INtSPQ06True=" + IntSPQ06True +
                " | BoolSPQ06NotEmpty=" + SPQ06.BoolSPQ06NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ06True-ButtonState=" + TogSPQ06False.isOn +
                " | increm=" + SPQ06.TogSPQ06F_Increm +
                " | IntSPQ06True=" + SPQ06.IntSPQ06True +
                " | BoolSPQ06NotEmpty=" + SPQ06.BoolSPQ06NotEmpty);
        }
    }
}
