//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ12FalseListener : MonoBehaviour
{
    public SPQ12 sPQ12;

    public GameObject TogGrSPQ12;

    public Toggle TogSPQ12False;
    public int IntSPQ12True = 2;
    public bool BoolSPQ12NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ12False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ12False.onValueChanged.AddListener(delegate 
        {
            TogSPQ12FalseChanged(TogSPQ12False);
        }
        );
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ12FalseChanged(Toggle change)
    {
        SPQ12.BoolSPQ12NotEmpty = true;
        SPQ12.TogSPQ12F_Increm++;
        if (TogSPQ12False.isOn)
        {
            SPQ12.IntSPQ12True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ12True-ButtonState=" + TogSPQ12False.isOn +
                " | increm=" + SPQ12.TogSPQ12F_Increm +
                " | IntSPQ12True=" + SPQ12.IntSPQ12True +
                " | BoolSPQ12NotEmpty=" + SPQ12.BoolSPQ12NotEmpty);
        }
        else
        {
            SPQ12.IntSPQ12True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ12True-ButtonState=" + TogSPQ12False.isOn +
                " | increm=" + SPQ12.TogSPQ12F_Increm +
                " | INtSPQ12True=" + IntSPQ12True +
                " | BoolSPQ12NotEmpty=" + SPQ12.BoolSPQ12NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ12True-ButtonState=" + TogSPQ12False.isOn +
                " | increm=" + SPQ12.TogSPQ12F_Increm +
                " | IntSPQ12True=" + SPQ12.IntSPQ12True +
                " | BoolSPQ12NotEmpty=" + SPQ12.BoolSPQ12NotEmpty);
        }
    }
}
