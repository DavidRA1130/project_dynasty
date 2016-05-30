using UnityEngine;
using System;
using System.Collections;

public class CooldownTimer : MonoBehaviour {

    public string TimerName;
    float startTime;
    float restSeconds;
    float roundedRestSeconds;
    float displaySeconds;
    float displayMinutes;
    int countDownSeconds;

    // Use this for starting the timer. The only required functions to start and restart are startTimer(int) and RestartTime(int)
    //they are the only public functions outside getters
    public void startTimer(int startvariable)
    {
        countDownSeconds = startvariable;
    }

    public void RestartTime(int desiredTime)
    {
        resetTime(0);
        Reset();
        startTimer(desiredTime);
    }

    public float getRestSeconds()
    {
        return restSeconds;
    }

    public float getRoundedRestSeconds()
    {
        return roundedRestSeconds;
    }

    void OnTriggerStay(Collider target)
    {
        if (target.tag == "Player" && restSeconds < 0)
        {
            //do stuff
        }
    }

    //hard reset the start time
    public void Reset()
    {
        startTime = Time.time;
    }


    void resetTime(int t)
    {
        restSeconds = t;
    }

    void Awake()
    {
        Reset();
    }

    
    void Start()
    {
        startTimer(5);
    }
    void Update()
    {
        //Make sure that your time is based on when this script was first called,
        //instead of when your game started.
        var guiTime = Time.time - startTime;

        restSeconds = countDownSeconds - (guiTime);

        //Display messages here; do stuff based on your timer
        if (restSeconds == 5)
        {
            //print("One Minute Left");
        }

        if ((int)restSeconds < 0)
        {
            //print("Time is Over");
            restSeconds = 0;
            restSeconds = countDownSeconds;
        }

        //Display the timer in the debug console
        roundedRestSeconds = Mathf.CeilToInt(restSeconds);
        displaySeconds = roundedRestSeconds % 60;
        displayMinutes = roundedRestSeconds / 60;
        //Name is for the sake of identification
        string text = String.Format(TimerName + " {0:00}:{1:00}", displayMinutes, displaySeconds);
        //Debug.Log(text);
    }
}
