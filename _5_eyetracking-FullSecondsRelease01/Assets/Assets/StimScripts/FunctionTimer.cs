/*
+++++++++++++++++++
FunctionTimer
+++++++++++++++++++
//Creates the basis for timers, sourced from CodeMonkey. 

*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTimer
{
    public bool ReadyNow;
    private static List<FunctionTimer> activeTimerList;
    private static GameObject initGameObject;

    private static void InitIfNeeded()
    {
        if (initGameObject == null)
        {
            initGameObject = new GameObject("FunctionTimer_InitGameObject");
            activeTimerList = new List<FunctionTimer>(); 
        }
    }

    public static FunctionTimer Create(Action action, float timer, string timerName = null)
    {
        InitIfNeeded();
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonobehaviourHook));

        FunctionTimer functionTimer = new FunctionTimer(action, timer, timerName, gameObject);

        gameObject.GetComponent<MonobehaviourHook>().onUpdate = functionTimer.Update;

        activeTimerList.Add(functionTimer);

        return functionTimer;
    }

    private static void RemoveTimer(FunctionTimer functionTimer)
    {
        InitIfNeeded();
        activeTimerList.Remove(functionTimer);
    }
    
    public static void StopTimer(string timerName)
    {
        for (int i = 0; i < activeTimerList.Count; i++)
        {
            if (activeTimerList[i].timerName == timerName)
            {
                //Stop this timer
                activeTimerList[i].DestroySelf();
                i--;
            }
        }
    }




    // Dummy Class to have access to Monobehaviour functions
    private class MonobehaviourHook : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null) onUpdate();
        }
    }

    private Action action;
    private float timer;
    private string timerName;
    private GameObject gameObject;
    private bool isDestroyed;

    private FunctionTimer(Action action, float timer, string timerName, GameObject gameObject)
    {
        this.action = action;
        this.timer = timer;
        this.timerName = timerName;
        this.gameObject = gameObject;
        isDestroyed = false;
    }

    public void Update()
    {
        if (!isDestroyed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                //trigger the action
                action();
                DestroySelf();
            }
        }
    }
    private void DestroySelf()
    {
        isDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
        RemoveTimer(this);
    }

}

/* 
------------------- Code Monkey -------------------

Thank you for downloading this package
I hope you find it useful in your projects
If you have any questions let me know
Cheers!

           unitycodemonkey.com
--------------------------------------------------
*/
