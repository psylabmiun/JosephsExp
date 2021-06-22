using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCalibration : MonoBehaviour
{
    string startupPath = System.IO.Directory.GetCurrentDirectory();


    public ExperimentalProcedure experimentalProcedureScript;
    public GameObject TaskCalibrationText;

    void Start()
    {
        TaskCalibrationText.SetActive(true);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ExperimentalProcedure.BooltaskInstruction = true;
            TaskCalibrationText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            ShowExplorer();
        }

    }

    public void ShowExplorer()
    {
        startupPath = startupPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        //System.Diagnostics.Process.Start("explorer.exe", startupPath);
        Application.OpenURL("file://" + startupPath + "/5_eyetracking-FullSecondsNearCompletion_Data/FinalLog/FinalLog.txt");

        // Update is called once per frame
    }

    // Update is called once per frame
    void Update()
    {
        if (ExperimentalProcedure.BooltaskCalibration == false)
        {
            TaskCalibrationText.SetActive(false);
        }
        else if (ExperimentalProcedure.BooltaskCalibration == true)
        {
            Start(); 
        }
    }

}
