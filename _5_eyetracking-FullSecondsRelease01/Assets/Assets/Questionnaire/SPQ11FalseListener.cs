//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ11FalseListener : MonoBehaviour
{
    public SPQ11 sPQ11;

    public GameObject TogGrSPQ11;

    public Toggle TogSPQ11False;
    public int IntSPQ11True = 2;
    public bool BoolSPQ11NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ11False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ11False.onValueChanged.AddListener(delegate {
            TogSPQ11FalseChanged(TogSPQ11False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ11FalseChanged(Toggle change)
    {
        SPQ11.BoolSPQ11NotEmpty = true;
        SPQ11.TogSPQ11F_Increm++;
        if (TogSPQ11False.isOn)
        {
            SPQ11.IntSPQ11True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ11True-ButtonState=" + TogSPQ11False.isOn +
                " | increm=" + SPQ11.TogSPQ11F_Increm +
                " | IntSPQ11True=" + SPQ11.IntSPQ11True +
                " | BoolSPQ11NotEmpty=" + SPQ11.BoolSPQ11NotEmpty);
        }
        else
        {
            SPQ11.IntSPQ11True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ11True-ButtonState=" + TogSPQ11False.isOn +
                " | increm=" + SPQ11.TogSPQ11F_Increm +
                " | INtSPQ11True=" + IntSPQ11True +
                " | BoolSPQ11NotEmpty=" + SPQ11.BoolSPQ11NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ11True-ButtonState=" + TogSPQ11False.isOn +
                " | increm=" + SPQ11.TogSPQ11F_Increm +
                " | IntSPQ11True=" + SPQ11.IntSPQ11True +
                " | BoolSPQ11NotEmpty=" + SPQ11.BoolSPQ11NotEmpty);
        }
    }
}
