//++++++++++++++++++++++++
//Page2ButtonController.cs
//++++++++++++++++++++++++
//There are several buttons in this program. Each button has 
//its own controller in a separate script. 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class Page2ButtonController : MonoBehaviour
{
    public ClickDataProt clickDataProt;
    public QuesQuestion01 quesQuestion01;
    public QuesQuestion02 quesQuestion02;
    public QuesQuestion03 quesQuestion03;
    public QuesQuestion04 quesQuestion04;
    public QuesQuestion05 quesQuestion05;
    public QuesQuestion06 quesQuestion06;
    public QuesQuestion07 quesQuestion07;


    public Button ButtonPage2GoToNextPage;
    public GameObject TextFillAllFieldsP2; 
    public GameObject ButtonExclActvPage2;
    public bool BoolBtnExclActvPage2 = false;
    public static bool BoolScreen3;

    // Start is called before the first frame update
    void SetBoolGoToPage3()
    {
        BoolScreen3 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (QuesQuestion01.IntExcl01True < 2 &&
            QuesQuestion02.IntExcl02True < 2 &&
            QuesQuestion03.IntExcl03True < 2 &&
            QuesQuestion04.IntExcl04True < 2 &&
            QuesQuestion05.IntExcl05True < 2 &&
            QuesQuestion06.IntExcl06True < 2 &&
            QuesQuestion07.IntExcl07True < 2)
        {
            TextFillAllFieldsP2.SetActive(false);
            Button btn = ButtonPage2GoToNextPage.GetComponent<Button>();
            btn.onClick.AddListener(SetBoolGoToPage3);
        }
        else
        {
            TextFillAllFieldsP2.SetActive(true);
        }

    }
}
