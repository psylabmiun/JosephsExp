//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ09FalseListener : MonoBehaviour
{
    public SPQ09 sPQ09;

    public GameObject TogGrSPQ09;

    public Toggle TogSPQ09False;
    public int IntSPQ09True = 2;
    public bool BoolSPQ09NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ09False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ09False.onValueChanged.AddListener(delegate {
            TogSPQ09FalseChanged(TogSPQ09False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ09FalseChanged(Toggle change)
    {
        SPQ09.BoolSPQ09NotEmpty = true;
        SPQ09.TogSPQ09F_Increm++;
        if (TogSPQ09False.isOn)
        {
            SPQ09.IntSPQ09True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ09True-ButtonState=" + TogSPQ09False.isOn +
                " | increm=" + SPQ09.TogSPQ09F_Increm +
                " | IntSPQ09True=" + SPQ09.IntSPQ09True +
                " | BoolSPQ09NotEmpty=" + SPQ09.BoolSPQ09NotEmpty);
        }
        else
        {
            SPQ09.IntSPQ09True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ09True-ButtonState=" + TogSPQ09False.isOn +
                " | increm=" + SPQ09.TogSPQ09F_Increm +
                " | INtSPQ09True=" + IntSPQ09True +
                " | BoolSPQ09NotEmpty=" + SPQ09.BoolSPQ09NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ09True-ButtonState=" + TogSPQ09False.isOn +
                " | increm=" + SPQ09.TogSPQ09F_Increm +
                " | IntSPQ09True=" + SPQ09.IntSPQ09True +
                " | BoolSPQ09NotEmpty=" + SPQ09.BoolSPQ09NotEmpty);
        }
    }
}
