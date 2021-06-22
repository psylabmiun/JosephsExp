//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ10FalseListener : MonoBehaviour
{
    public SPQ10 sPQ10;

    public GameObject TogGrSPQ10;

    public Toggle TogSPQ10False;
    public int IntSPQ10True = 2;
    public bool BoolSPQ10NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ10False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ10False.onValueChanged.AddListener(delegate {
            TogSPQ10FalseChanged(TogSPQ10False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ10FalseChanged(Toggle change)
    {
        SPQ10.BoolSPQ10NotEmpty = true;
        SPQ10.TogSPQ10F_Increm++;
        if (TogSPQ10False.isOn)
        {
            SPQ10.IntSPQ10True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ10True-ButtonState=" + TogSPQ10False.isOn +
                " | increm=" + SPQ10.TogSPQ10F_Increm +
                " | IntSPQ10True=" + SPQ10.IntSPQ10True +
                " | BoolSPQ10NotEmpty=" + SPQ10.BoolSPQ10NotEmpty);
        }
        else
        {
            SPQ10.IntSPQ10True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ10True-ButtonState=" + TogSPQ10False.isOn +
                " | increm=" + SPQ10.TogSPQ10F_Increm +
                " | INtSPQ10True=" + IntSPQ10True +
                " | BoolSPQ10NotEmpty=" + SPQ10.BoolSPQ10NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ10True-ButtonState=" + TogSPQ10False.isOn +
                " | increm=" + SPQ10.TogSPQ10F_Increm +
                " | IntSPQ10True=" + SPQ10.IntSPQ10True +
                " | BoolSPQ10NotEmpty=" + SPQ10.BoolSPQ10NotEmpty);
        }
    }
}
