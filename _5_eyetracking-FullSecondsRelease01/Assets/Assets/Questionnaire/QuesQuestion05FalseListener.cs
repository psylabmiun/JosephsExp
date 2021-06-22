//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion05FalseListener : MonoBehaviour
{


    public GameObject TogGrExcl05Depression;

    public Toggle TogExcl05False;
    public int IntExcl05True = 2;
    public bool BoolExcl05NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogExcl05False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl05False.onValueChanged.AddListener(delegate {
            TogExcl05FalseChanged(TogExcl05False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl05FalseChanged(Toggle change)
    {
        QuesQuestion05.BoolExcl05NotEmpty = true;
        QuesQuestion05.TogExcl05F_Increm++;
        if (TogExcl05False.isOn)
        {
            QuesQuestion05.IntExcl05True = 0;
            Debug.Log("------------------------------------------THIS IS TogExcl05True-ButtonState=" + TogExcl05False.isOn +
                " | increm=" + QuesQuestion05.TogExcl05F_Increm +
                " | IntExcl05True=" + QuesQuestion05.IntExcl05True +
                " | BoolExcl05NotEmpty=" + QuesQuestion05.BoolExcl05NotEmpty);
        }
        else
        {
            QuesQuestion05.IntExcl05True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl05True-ButtonState=" + TogExcl05False.isOn +
                " | increm=" + QuesQuestion05.TogExcl05F_Increm +
                " | INtExcl05True=" + IntExcl05True +
                " | BoolExcl05NotEmpty=" + QuesQuestion05.BoolExcl05NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl05True-ButtonState=" + TogExcl05False.isOn +
                " | increm=" + QuesQuestion05.TogExcl05F_Increm +
                " | IntExcl05True=" + QuesQuestion05.IntExcl05True +
                " | BoolExcl05NotEmpty=" + QuesQuestion05.BoolExcl05NotEmpty);
        }
    }
}
