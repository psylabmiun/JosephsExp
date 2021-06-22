//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion03FalseListener : MonoBehaviour
{



    public GameObject TogGrExcl03Psychotropic;

    public Toggle TogExcl03False;
    public int IntExcl03True = 2;
    public bool BoolExcl03NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogExcl03False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl03False.onValueChanged.AddListener(delegate {
            TogExcl03FalseChanged(TogExcl03False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl03FalseChanged(Toggle change)
    {
        QuesQuestion03.BoolExcl03NotEmpty = true;
        QuesQuestion03.TogExcl03F_Increm++;
        if (TogExcl03False.isOn)
        {
            QuesQuestion03.IntExcl03True = 0;
            Debug.Log("------------------------------------------THIS IS TogExcl03True-ButtonState=" + TogExcl03False.isOn +
                " | increm=" + QuesQuestion03.TogExcl03F_Increm +
                " | IntExcl03True=" + QuesQuestion03.IntExcl03True +
                " | BoolExcl03NotEmpty=" + QuesQuestion03.BoolExcl03NotEmpty);
        }
        else
        {
            QuesQuestion03.IntExcl03True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl03True-ButtonState=" + TogExcl03False.isOn +
                " | increm=" + QuesQuestion03.TogExcl03F_Increm +
                " | INtExcl03True=" + IntExcl03True +
                " | BoolExcl03NotEmpty=" + QuesQuestion03.BoolExcl03NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl03True-ButtonState=" + TogExcl03False.isOn +
                " | increm=" + QuesQuestion03.TogExcl03F_Increm +
                " | IntExcl03True=" + QuesQuestion03.IntExcl03True +
                " | BoolExcl03NotEmpty=" + QuesQuestion03.BoolExcl03NotEmpty);
        }
    }
}

