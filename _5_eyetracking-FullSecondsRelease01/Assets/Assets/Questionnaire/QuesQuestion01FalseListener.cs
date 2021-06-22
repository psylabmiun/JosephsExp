//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion01FalseListener : MonoBehaviour
{
    public QuesQuestion01 quesQuestion01;

    public GameObject TogGrExcl01BrainDamage;

    public Toggle TogExcl01False;
    public int IntExcl01True = 2;
    public bool BoolExcl01NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogExcl01False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl01False.onValueChanged.AddListener(delegate {
            TogExcl01FalseChanged(TogExcl01False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl01FalseChanged(Toggle change)
    {
        QuesQuestion01.BoolExcl01NotEmpty = true;
        QuesQuestion01.TogExcl01F_Increm++;
        if (TogExcl01False.isOn)
        {
            QuesQuestion01.IntExcl01True = 0;
            Debug.Log("------------------------------------------THIS IS TogExcl01True-ButtonState=" + TogExcl01False.isOn +
                " | increm=" + QuesQuestion01.TogExcl01F_Increm +
                " | IntExcl01True=" + QuesQuestion01.IntExcl01True +
                " | BoolExcl01NotEmpty=" + QuesQuestion01.BoolExcl01NotEmpty);
        }
        else
        {
            QuesQuestion01.IntExcl01True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl01True-ButtonState=" + TogExcl01False.isOn +
                " | increm=" + QuesQuestion01.TogExcl01F_Increm +
                " | INtExcl01True=" + IntExcl01True +
                " | BoolExcl01NotEmpty=" + QuesQuestion01.BoolExcl01NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl01True-ButtonState=" + TogExcl01False.isOn +
                " | increm=" + QuesQuestion01.TogExcl01F_Increm +
                " | IntExcl01True=" + QuesQuestion01.IntExcl01True +
                " | BoolExcl01NotEmpty=" + QuesQuestion01.BoolExcl01NotEmpty);
        }
    }
}
