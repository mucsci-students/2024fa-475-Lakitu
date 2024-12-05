using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using TMPro;         

public class SpeedrunTimer : MonoBehaviour
{
    
    public TMP_Text timerText; 
    private float elapsedTime;
    private bool isRunning;

    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;  // Start the timer automatically
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay(elapsedTime);
        }
    }

    public void StopTimer()
    {
        isRunning = false;  // Stops the timer
    }

    public void StartTimer()
    {
        isRunning = true;   // Resumes the timer
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;   // Resets the timer
        UpdateTimerDisplay(elapsedTime);
    }

    private void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
