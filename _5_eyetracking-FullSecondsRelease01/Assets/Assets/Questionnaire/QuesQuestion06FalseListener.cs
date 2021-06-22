//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion06FalseListener : MonoBehaviour
{

    public GameObject TogGrExcl06Vision;

    public Toggle TogExcl06False;
    public int IntExcl06True = 2;
    public bool BoolExcl06NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogExcl06False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl06False.onValueChanged.AddListener(delegate {
            TogExcl06FalseChanged(TogExcl06False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl06FalseChanged(Toggle change)
    {
        QuesQuestion06.BoolExcl06NotEmpty = true;
        QuesQuestion06.TogExcl06F_Increm++;
        if (TogExcl06False.isOn)
        {
            QuesQuestion06.IntExcl06True = 0;
            Debug.Log("------------------------------------------THIS IS TogExcl06True-ButtonState=" + TogExcl06False.isOn +
                " | increm=" + QuesQuestion06.TogExcl06F_Increm +
                " | IntExcl06True=" + QuesQuestion06.IntExcl06True +
                " | BoolExcl06NotEmpty=" + QuesQuestion06.BoolExcl06NotEmpty);
        }
        else
        {
            QuesQuestion06.IntExcl06True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl06True-ButtonState=" + TogExcl06False.isOn +
                " | increm=" + QuesQuestion06.TogExcl06F_Increm +
                " | INtExcl06True=" + IntExcl06True +
                " | BoolExcl06NotEmpty=" + QuesQuestion06.BoolExcl06NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl06True-ButtonState=" + TogExcl06False.isOn +
                " | increm=" + QuesQuestion06.TogExcl06F_Increm +
                " | IntExcl06True=" + QuesQuestion06.IntExcl06True +
                " | BoolExcl06NotEmpty=" + QuesQuestion06.BoolExcl06NotEmpty);
        }
    }
}

