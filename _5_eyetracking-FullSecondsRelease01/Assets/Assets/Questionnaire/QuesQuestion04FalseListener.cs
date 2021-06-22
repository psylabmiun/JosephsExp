//There are several toggles in this program. Each toggle has its 
//own controller in a separate script as well as a false controller for the "false" case.
//It makes sense to do it like this to avoid conflicts involving too many objects of 
//a specific type in a single module. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class QuesQuestion04FalseListener : MonoBehaviour
{

    public GameObject TogGrExcl04AlcoDrugsMeds;

    public Toggle TogExcl04False;
    public int IntExcl04True = 2;
    public bool BoolExcl04NotEmpty = false;


    void Start()
    {
        //Fetch the Toggle GameObject
        TogExcl04False = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogExcl04False.onValueChanged.AddListener(delegate {
            TogExcl04FalseChanged(TogExcl04False);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogExcl04FalseChanged(Toggle change)
    {
        QuesQuestion04.BoolExcl04NotEmpty = true;
        QuesQuestion04.TogExcl04F_Increm++;
        if (TogExcl04False.isOn)
        {
            QuesQuestion04.IntExcl04True = 0;
            Debug.Log("------------------------------------------THIS IS TogExcl04True-ButtonState=" + TogExcl04False.isOn +
                " | increm=" + QuesQuestion04.TogExcl04F_Increm +
                " | IntExcl04True=" + QuesQuestion04.IntExcl04True +
                " | BoolExcl04NotEmpty=" + QuesQuestion04.BoolExcl04NotEmpty);
        }
        else
        {
            QuesQuestion04.IntExcl04True = 2;
            Debug.Log("------------------------------------------THIS IS TogExcl04True-ButtonState=" + TogExcl04False.isOn +
                " | increm=" + QuesQuestion04.TogExcl04F_Increm +
                " | INtExcl04True=" + IntExcl04True +
                " | BoolExcl04NotEmpty=" + QuesQuestion04.BoolExcl04NotEmpty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("------------------------------------------Current TogExcl04True-ButtonState=" + TogExcl04False.isOn +
                " | increm=" + QuesQuestion04.TogExcl04F_Increm +
                " | IntExcl04True=" + QuesQuestion04.IntExcl04True +
                " | BoolExcl04NotEmpty=" + QuesQuestion04.BoolExcl04NotEmpty);
        }
    }
}
