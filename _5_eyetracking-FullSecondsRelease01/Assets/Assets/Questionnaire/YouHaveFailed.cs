using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouHaveFailed : MonoBehaviour
{

    public ExperimentalProcedure experimentalProcedureScript;


    public GameObject YouFailed;
    void Start()
    {
        YouFailed.SetActive(true);
        if (Input.GetKeyDown(KeyCode.M))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ExperimentalProcedure.Bool_rejectParticipant == true)
        {
            Start();
        }
        else
        {
            YouFailed.SetActive(false);
        }
    }
}
