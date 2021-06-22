//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion07FalseListener : MonoBehaviour
{


    public GameObject TogGrExclusion7Verify;

    public Toggle TogExcl07False;
    public int IntExcl07True = 2;
    public bool BoolExcl07NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogExcl07False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl07False.onValueChanged.AddListener(delegate {
            TogExcl07FalseChanged(TogExcl07False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl07FalseChanged(Toggle change)
    {
        QuesQuestion07.BoolExcl07NotEmpty = true;
        QuesQuestion07.TogExcl07F_Increm++;
        if (TogExcl07False.isOn)
        {
            QuesQuestion07.IntExcl07True = 0;
            Debug.Log("------------------------------------------THIS IS TogExcl07True-ButtonState=" + TogExcl07False.isOn +
                " | increm=" + QuesQuestion07.TogExcl07F_Increm +
                " | IntExcl07True=" + QuesQuestion07.IntExcl07True +
                " | BoolExcl07NotEmpty=" + QuesQuestion07.BoolExcl07NotEmpty);
        }
        else
        {
            QuesQuestion07.IntExcl07True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl07True-ButtonState=" + TogExcl07False.isOn +
                " | increm=" + QuesQuestion07.TogExcl07F_Increm +
                " | INtExcl07True=" + IntExcl07True +
                " | BoolExcl07NotEmpty=" + QuesQuestion07.BoolExcl07NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl07True-ButtonState=" + TogExcl07False.isOn +
                " | increm=" + QuesQuestion07.TogExcl07F_Increm +
                " | IntExcl07True=" + QuesQuestion07.IntExcl07True +
                " | BoolExcl07NotEmpty=" + QuesQuestion07.BoolExcl07NotEmpty);
        }
    }
}
