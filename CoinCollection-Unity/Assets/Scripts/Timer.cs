/****
* Created by: Runran Li 
* Date Created: June 20, 2022
*
* Last Edited by:
* Last Edited:
*
* Description: A level timer that can be set and controlled
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Timer Singleton
    [Tooltip("Start time in seconds")]
    public float startTime = 10f; //time for level (if level is timed)
    private float currentTime; //current time of timer
    [HideInInspector]
    public bool timerStopped = false; //check if timer is stopped
    static private Timer timer; //Timer instance
    static public Timer LevelTimer { get { return timer; } } //public access to read only timer
                                                             //Check to make sure only Timer instance in the scene
    void CheckTimerIsInScene()
    {
        //Check if instance is null
        if (timer == null)
        {
            timer = this; //set timer to this Timer instance
            Debug.Log(timer);
        }
        else //else if timer is not null a Timer must already exist
        {
            Destroy(this.gameObject); //In this case you need to delete this timer
        }
    }//end CheckTimerIsInScene()
    #endregion



    // Awake is called on instantiation before Start
    void Awake()
    {
        //runs the method to check for the Timer
        CheckTimerIsInScene();
    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime; //set the current time to the startTime specified
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }//end Update()

    //Runs the timer countdown
    private void RunTimer()
    {
        if (timerStopped)
        { // check to see if timer has stoped
            LevelEnd();
        }
        else
        {
            if (currentTime > 0)
            {
                // if still time, update timer countdown
                currentTime -= Time.deltaTime;
            }
            else
            {//if the timer is less than zero
                currentTime = 0; //set time to zero
                timerStopped = true; //stop the timer
            }
            Debug.Log(DisplayTime(currentTime));
        }
    }//end RunTimer();

    //Runs events for the end of the level
    private void LevelEnd()
    {
        Debug.Log("level end");
    }//end LevelEnd()

    //Formats time as string
    private string DisplayTime(float timeToDispaly)
    {
        timeToDispaly += 1; //adds 1 to time, to accuratly refelect time in field
        float minutes = Mathf.FloorToInt(timeToDispaly / 60); //calculate timer mintues
        float seconds = Mathf.FloorToInt(timeToDispaly % 60); //calculate timer seconds
        return string.Format("{0:00}:{1:00}", minutes, seconds); //retrun time as string
    }//end DisplayTime

    public void AddTime()
    {
        if (timerStopped)
        { // check to see if timer has stoped
            LevelEnd();
        }
        else
        {
            if (currentTime > 0)
            {
                // if still time, update timer countdown
                currentTime +=1;
            }
            else
            {//if the timer is less than zero
                currentTime = 0; //set time to zero
                timerStopped = true; //stop the timer
            }
            Debug.Log(DisplayTime(currentTime));
        }
    }
}
