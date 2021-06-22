//There are several toggles in this program. Each toggle has its own controller 
//in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of a 
//specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class SPQ04FalseListener : MonoBehaviour
{
    public SPQ04 sPQ04;

    public GameObject TogGrSPQ04;

    public Toggle TogSPQ04False;
    public int IntSPQ04True = 2;
    public bool BoolSPQ04NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogSPQ04False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogSPQ04False.onValueChanged.AddListener(delegate {
            TogSPQ04FalseChanged(TogSPQ04False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogSPQ04FalseChanged(Toggle change)
    {
        SPQ04.BoolSPQ04NotEmpty = true;
        SPQ04.TogSPQ04F_Increm++;
        if (TogSPQ04False.isOn)
        {
            SPQ04.IntSPQ04True = 0;
            Debug.Log("------------------------------------------THIS IS TogSPQ04True-ButtonState=" + TogSPQ04False.isOn +
                " | increm=" + SPQ04.TogSPQ04F_Increm +
                " | IntSPQ04True=" + SPQ04.IntSPQ04True +
                " | BoolSPQ04NotEmpty=" + SPQ04.BoolSPQ04NotEmpty);
        }
        else
        {
            SPQ04.IntSPQ04True = 2;
            Debug.Log("------------------------------------------THIS IS TogSPQ04True-ButtonState=" + TogSPQ04False.isOn +
                " | increm=" + SPQ04.TogSPQ04F_Increm +
                " | INtSPQ04True=" + IntSPQ04True +
                " | BoolSPQ04NotEmpty=" + SPQ04.BoolSPQ04NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogSPQ04True-ButtonState=" + TogSPQ04False.isOn +
                " | increm=" + SPQ04.TogSPQ04F_Increm +
                " | IntSPQ04True=" + SPQ04.IntSPQ04True +
                " | BoolSPQ04NotEmpty=" + SPQ04.BoolSPQ04NotEmpty);
        }
    }
}
