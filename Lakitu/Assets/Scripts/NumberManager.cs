using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberManager : MonoBehaviour
{
    public GameObject blueNumber;
    public GameObject blueButton;
    public GameObject redNumber;
    public GameObject redButton;
    public GameObject yellowNumber;
    public GameObject yellowButton;
    public GameObject greenNumber;
    public GameObject greenButton;

    public int blueValue;
    public int redValue;
    public int yellowValue;
    public int greenValue;

    public bool isOpen;
    public GameObject door;
    public Vector3 opened;
    public Vector3 closed;

    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip failedSound;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        opened = new Vector3(111.5f, 10f, 43.6f);
        closed = new Vector3(111.5f, 4f, 43.6f);

        // Set initial random values for the numbers
        ResetNumbers();

        // Assign values to the number display objects
        blueNumber.GetComponent<Numbers>().num = blueValue;
        redNumber.GetComponent<Numbers>().num = redValue;
        yellowNumber.GetComponent<Numbers>().num = yellowValue;
        greenNumber.GetComponent<Numbers>().num = greenValue;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "T" key is pressed to reset the numbers
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResetNumbers();
        }
    }

    // Function to reset the number values
    void ResetNumbers()
    {
        blueValue = Random.Range(0, 10);
        redValue = Random.Range(0, 10);
        yellowValue = Random.Range(0, 10);
        greenValue = Random.Range(0, 10);

        // Update the number display objects with new values
        blueNumber.GetComponent<Numbers>().num = blueValue;
        redNumber.GetComponent<Numbers>().num = redValue;
        yellowNumber.GetComponent<Numbers>().num = yellowValue;
        greenNumber.GetComponent<Numbers>().num = greenValue;
    }

    public void submit()
    {
        // Check if the button inputs match the generated values
        isOpen = blueButton.GetComponent<Numbers>().num == blueValue && redButton.GetComponent<Numbers>().num == redValue && yellowButton.GetComponent<Numbers>().num == yellowValue && greenButton.GetComponent<Numbers>().num == greenValue;

        if (isOpen)
        {
            sfxManager.instance.playSound(openSound, transform, 1f);
            door.transform.position = opened;
        }
        else
        {
            sfxManager.instance.playSound(failedSound, transform, 1f);
            door.transform.position = closed;
        }
    }
}
