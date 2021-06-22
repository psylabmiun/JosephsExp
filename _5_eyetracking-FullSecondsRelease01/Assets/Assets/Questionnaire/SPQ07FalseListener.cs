//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ07FalseListener : MonoBehaviour
{
    public SPQ07 sPQ07;

    public GameObject TogGrSPQ07;

    public Toggle TogSPQ07False;
    public int IntSPQ07True = 2;
    public bool BoolSPQ07NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ07False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ07False.onValueChanged.AddListener(delegate {
            TogSPQ07FalseChanged(TogSPQ07False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ07FalseChanged(Toggle change)
    {
        SPQ07.BoolSPQ07NotEmpty = true;
        SPQ07.TogSPQ07F_Increm++;
        if (TogSPQ07False.isOn)
        {
            SPQ07.IntSPQ07True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ07True-ButtonState=" + TogSPQ07False.isOn +
                " | increm=" + SPQ07.TogSPQ07F_Increm +
                " | IntSPQ07True=" + SPQ07.IntSPQ07True +
                " | BoolSPQ07NotEmpty=" + SPQ07.BoolSPQ07NotEmpty);
        }
        else
        {
            SPQ07.IntSPQ07True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ07True-ButtonState=" + TogSPQ07False.isOn +
                " | increm=" + SPQ07.TogSPQ07F_Increm +
                " | INtSPQ07True=" + IntSPQ07True +
                " | BoolSPQ07NotEmpty=" + SPQ07.BoolSPQ07NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ07True-ButtonState=" + TogSPQ07False.isOn +
                " | increm=" + SPQ07.TogSPQ07F_Increm +
                " | IntSPQ07True=" + SPQ07.IntSPQ07True +
                " | BoolSPQ07NotEmpty=" + SPQ07.BoolSPQ07NotEmpty);
        }
    }
}
