//There are several buttons in this program. Each button has 
//its own controller in a separate script. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class Page3ButtonController : MonoBehaviour
{

    public ClickDataProt clickDataProt;
    public SPQ01Question sPQ01Question;
    public SPQ02 sPQ02;
    public SPQ03 sPQ03;
    public SPQ04 sPQ04;
    public SPQ05 sPQ05;
    public SPQ06 sPQ06;
    public SPQ07 sPQ07;


    public Button ButtonPage3GoToNextPage;
    public GameObject TextFillAllFieldsP3;
    public GameObject ButtonExclActvPage3;
    public bool BoolBtnExclActvPage3 = false;
    public static bool BoolScreen4;

    // Start is called before the first frame update

    void SetBoolGoToPage4()
    {
        BoolScreen4 = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (SPQ01Question.IntSPQ01True < 2 &&
            SPQ02.IntSPQ02True < 2 &&
            SPQ03.IntSPQ03True < 2 &&
            SPQ04.IntSPQ04True < 2 &&
            SPQ05.IntSPQ05True < 2 &&
            SPQ06.IntSPQ06True < 2 &&
            SPQ07.IntSPQ07True < 2)
        {
            TextFillAllFieldsP3.SetActive(false);
            Button btn = ButtonPage3GoToNextPage.GetComponent<Button>();
            btn.onClick.AddListener(SetBoolGoToPage4);
        }
        else
        {
            TextFillAllFieldsP3.SetActive(true);
        }

    }
}
