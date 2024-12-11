using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryScreen; 
    public TMP_Text timerText; 
    public SpeedrunTimer timer; 
    public Transform[] resettableObjects; 
    private Vector3[] initialPositions;

    void Start()
    {
        victoryScreen.SetActive(false);
  

        // Store initial positions of resettable objects
        initialPositions = new Vector3[resettableObjects.Length];
        for (int i = 0; i < resettableObjects.Length; i++)
        {
            initialPositions[i] = resettableObjects[i].position;
        }
    }

    public void TriggerVictory()
    {
        timer.StopTimer(); // Call stoptimer method in your Timer script
        timerText.text = "Time: " + timer.GetFormattedTime();
        victoryScreen.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            HideVictoryScreen();
            timer.StartTimer();
        }
    }

    // Function to hide the victory screen
    void HideVictoryScreen()
    {
        victoryScreen.SetActive(false);
    }


}
