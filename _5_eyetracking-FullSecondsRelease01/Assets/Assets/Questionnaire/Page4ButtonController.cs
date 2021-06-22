//There are several buttons in this program. Each button has 
//its own controller in a separate script. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class Page4ButtonController : MonoBehaviour
{

    public GameObject TextFillAllFieldsP4;
    public ClickDataProt clickDataProt;
    public SPQ08 sPQ08;
    public SPQ09 sPQ09;
    public SPQ10 sPQ10;
    public SPQ11 sPQ11;
    public SPQ12 sPQ12;


    public Button ButtonPage4GoToNextPage;
    public GameObject ButtonExclActvPage4;
    public bool BoolBtnExclActvPage5 = false;
    public static bool BoolScreen5;

    // Start is called before the first frame update
    void SetBoolGoToPage5()
    {
        BoolScreen5 = true;
    }

    void Update()
    {
        if (SPQ08.IntSPQ08True < 2 &&
            SPQ09.IntSPQ09True < 2 &&
            SPQ10.IntSPQ10True < 2 &&
            SPQ11.IntSPQ11True < 2 &&
            SPQ12.IntSPQ12True < 2)
        {
            TextFillAllFieldsP4.SetActive(false);
            Button btn = ButtonPage4GoToNextPage.GetComponent<Button>();
            btn.onClick.AddListener(SetBoolGoToPage5);
        }
        else
        {
            TextFillAllFieldsP4.SetActive(true);
        }

    }

}
