using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScroll01 : MonoBehaviour
{
    public GameObject textObject01;
    public GameObject textObject02;
    public GameObject textObject03;
    public GameObject textObject04;
    public GameObject textObject05;
    public GameObject textObject06;
    public GameObject textObject07;
    public GameObject FixationExample01;
    public GameObject TaskAExample;
    public GameObject TaskBExample;



    public int ShowText;
    public static bool ReadyTrials01;

    // Start is called before the first frame update
    void Start()
    {
        ShowText = 1;
        ReadyTrials01 = false;
        textObject01.SetActive(true);
        textObject02.SetActive(false);
        textObject03.SetActive(false);
        textObject04.SetActive(false);
        textObject05.SetActive(false);
        textObject06.SetActive(false);
        textObject07.SetActive(false);
        FixationExample01.SetActive(false);
        TaskAExample.SetActive(false);
        TaskBExample.SetActive(false);
    }

    void Update()
    {
        switch (ShowText)
        {
            case 1: //Text inactive: "Instructions for "N-back task (n=1)"
                if (Input.GetKeyDown(KeyCode.S))
                {
                    textObject02.SetActive(true);
                    FixationExample01.SetActive(true);
                    ShowText = 2;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    ShowText = 1;
                }
                break;

            case 2: //ShowText02 : The cross sign + appears  and disappears after three seconds


                if (Input.GetKeyDown(KeyCode.S))
                {
                    textObject03.SetActive(true);
                    FixationExample01.SetActive(false);
                    TaskAExample.SetActive(true);
                    ShowText = 3;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    textObject02.SetActive(false);
                    FixationExample01.SetActive(false);
                    ShowText = 1;
                }
                break;

            case 3: //ShowText03  : After a brief pause it is then replaced by a letter 
                    //which is shown for 1 second. Remember the letter.
                

                if (Input.GetKeyDown(KeyCode.S))
                {
                    textObject04.SetActive(true);
                    TaskAExample.SetActive(false);
                    ShowText = 4;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    textObject03.SetActive(false);
                    TaskAExample.SetActive(false);
                    ShowText = 2;
                }
                break;

            case 4: //ShowText04 : After a brief pause it is replaced again

                if (Input.GetKeyDown(KeyCode.S))
                {
                    textObject05.SetActive(true);
                    TaskAExample.SetActive(true);
                    ShowText = 5;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    textObject04.SetActive(false);
                    TaskAExample.SetActive(false);
                    ShowText = 3;
                }
                break;

            case 5: //ShowText01 : //ShowText04 : by another letter which is shown for 1 second. 
                    //If the next letter is the same press < yes >

                if (Input.GetKeyDown(KeyCode.S))
                {
                    textObject06.SetActive(true);
                    TaskAExample.SetActive(false);
                    TaskBExample.SetActive(true);
                    ShowText = 6;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    textObject05.SetActive(false);
                    TaskAExample.SetActive(true);
                    TaskBExample.SetActive(false);
                    ShowText = 4;
                }
                break;

            case 6: //ShowText01: If it is not the same, press <no>. Any other images on the screen are only distractors.

                if (Input.GetKeyDown(KeyCode.S))
                {
                    textObject01.SetActive(false);
                    textObject02.SetActive(false);
                    textObject03.SetActive(false);
                    textObject04.SetActive(false);
                    textObject05.SetActive(false);
                    textObject06.SetActive(false);
                    TaskBExample.SetActive(false);
                    textObject07.SetActive(true);
                    ShowText = 7;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    textObject06.SetActive(false);
                    TaskBExample.SetActive(true);
                    ShowText = 5;
                }
                break;

            case 7: //ShowText01 : Remember: it is important to perform the task as accurately and completely as possible. 
                    //When you have finished reading, press  < yes > for a test run.
                  

                if (Input.GetKeyDown(KeyCode.S))
                {
                    textObject07.SetActive(false);
                    ShowText = 8;

                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    textObject01.SetActive(true);
                    textObject02.SetActive(true);
                    textObject03.SetActive(true);
                    textObject04.SetActive(true);
                    textObject05.SetActive(true);
                    textObject06.SetActive(true);
                    textObject07.SetActive(false);
                    ShowText = 6;
                }
                break;
            case 8:
                textObject01.SetActive(false);
                textObject02.SetActive(false);
                textObject03.SetActive(false);
                textObject04.SetActive(false);
                textObject05.SetActive(false);
                textObject06.SetActive(false);
                textObject07.SetActive(false);
                ReadyTrials01 = true;   
                ShowText = 9;
                break;
            case 9:
                SetBoolReadyTrials01Back();
                break;
        
        }

    }

    private void SetBoolReadyTrials01Back()
    {
        ReadyTrials01 = false;

    }
}