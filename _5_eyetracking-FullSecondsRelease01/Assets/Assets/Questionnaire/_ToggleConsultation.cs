using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class _ToggleConsultation : MonoBehaviour
{

    public GameObject ToggleConsultation;

    public static int TogConsultF_Increm = 0;

    public Toggle TogConsultTrue;
    public static int IntConsultTrue;
    public static bool BoolConsultNotEmpty = false;


    void Start()
    {
        IntConsultTrue = 2;

        //Fetch the Toggle GameObject
        TogConsultTrue = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        TogConsultTrue.onValueChanged.AddListener(delegate {
            TogConsultTrueChanged(TogConsultTrue);
        });
        //Initialize the Text to say whether the Toggle is in a positive or negative state
    }

    //Output the new state of the Toggle into Text
    void TogConsultTrueChanged(Toggle change)
    {
        BoolConsultNotEmpty = true;
        TogConsultF_Increm++;
        //if (TogConsultF_Increm % 2 == 0)
        if (TogConsultTrue.isOn)
        {
            IntConsultTrue = 1;
        }
        else
        {
            IntConsultTrue = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
