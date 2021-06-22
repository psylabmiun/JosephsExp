using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class YouHavePassed : MonoBehaviour
{

    public ExperimentalProcedure experimentalProcedureScript;
    public GameObject YouPassed;

    void Start()
    {
        YouPassed.SetActive(true);

    }
    public void ShowExplorer(string itemPath)
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            itemPath = itemPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
            System.Diagnostics.Process.Start("explorer.exe", @"/");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ExperimentalProcedure.Bool_requestCode == true)
        {
            Start();
        }
        else
        {
            YouPassed.SetActive(false);
        }
    }
}
