//There are several buttons in this program. Each button has 
//its own controller in a separate script. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;

public class Page3ButtonControllerBACK : MonoBehaviour
{
    public Page2ButtonController page2ButtonController;
    public ClickDataProt clickDataProt;
    public QuesQuestion01 quesQuestion01;
    public QuesQuestion02 quesQuestion02;
    public QuesQuestion03 quesQuestion03;
    public QuesQuestion04 quesQuestion04;
    public QuesQuestion05 quesQuestion05;
    public QuesQuestion06 quesQuestion06;
    public QuesQuestion07 quesQuestion07;


    public Button ButtonPage3GoBack;
    public GameObject ButtonActvPage3GoBackPage1;
    public bool BoolBtnExclActvPage3GoBackPage1 = false;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = ButtonPage3GoBack.GetComponent<Button>();
        btn.onClick.AddListener(SetBoolGoBackToPage2);
    }

    void SetBoolGoBackToPage2()
    {
        ClickDataProt.BoolScreen2 = true;
        Page2ButtonController.BoolScreen3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Code to move to page 3
        /*        if (QuesQuestion01.IntExcl01True = 2 ||
                    QuesQuestion02.IntExcl02True = 2 ||
                    QuesQuestion03.IntExcl03True = 2 ||
                    QuesQuestion04.IntExcl04True = 2 ||
                    QuesQuestion05.IntExcl05True = 2 ||
                    QuesQuestion06.IntExcl06True = 2 ||
                    QuesQuestion07.IntExcl07True = 2
                    )
                {
                    ButtonExclActvPage3.SetActive(true);
                }
                else
                {
                    ButtonExclActvPage3.SetActive(false);
                }*/

    }
}
