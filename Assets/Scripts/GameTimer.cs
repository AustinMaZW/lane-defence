using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in Seconds")] //when hover over serialize field, it would show tool tip
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;  //set value of slider to be proportional to time has passed

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime); 
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished(); //calling leveltimerfinished to turn it into true
            triggeredLevelFinished = true; // this is to prevent keep updating these scripts if leveltimerfinished is already true
        }
    }
}
