//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion02FalseListener : MonoBehaviour
{
    public QuesQuestion02 quesQuestion02;

    public GameObject TogGrExcl02NeurologicalDisorders;

    public Toggle TogExcl02False;
    public int IntExcl02True = 2;
    public bool BoolExcl02NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogExcl02False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl02False.onValueChanged.AddListener(delegate {
            TogExcl02FalseChanged(TogExcl02False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl02FalseChanged(Toggle change)
    {
        QuesQuestion02.BoolExcl02NotEmpty = true;
        QuesQuestion02.TogExcl02F_Increm++;
        if (TogExcl02False.isOn)
        {
            QuesQuestion02.IntExcl02True = 0;
            Debug.Log("------------------------------------------THIS IS TogExcl02True-ButtonState=" + TogExcl02False.isOn +
                " | increm=" + QuesQuestion02.TogExcl02F_Increm +
                " | IntExcl02True=" + QuesQuestion02.IntExcl02True +
                " | BoolExcl02NotEmpty=" + QuesQuestion02.BoolExcl02NotEmpty);
        }
        else
        {
            QuesQuestion02.IntExcl02True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl02True-ButtonState=" + TogExcl02False.isOn +
                " | increm=" + QuesQuestion02.TogExcl02F_Increm +
                " | INtExcl02True=" + IntExcl02True +
                " | BoolExcl02NotEmpty=" + QuesQuestion02.BoolExcl02NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl02True-ButtonState=" + TogExcl02False.isOn +
                " | increm=" + QuesQuestion02.TogExcl02F_Increm +
                " | IntExcl02True=" + QuesQuestion02.IntExcl02True +
                " | BoolExcl02NotEmpty=" + QuesQuestion02.BoolExcl02NotEmpty);
        }
    }
}
