using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunWall : MonoBehaviour
{

    public bool isOpen;

    public GameObject wall;

    public Vector3 opened;
    public Vector3 closed;

    public float timePassed;

    [SerializeField] private AudioClip failedSound;
    // Start is called before the first frame update
    void Start()
    {
        opened = new Vector3(126.4f, 10f, -59.96f);
        closed = new Vector3(126.4f, 4f, -59.96f);

        timePassed = 0;
        isOpen = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen){
            wall.transform.position = opened;
            timePassed += Time.deltaTime;
            if(timePassed >= 120f){
                isOpen = false;
                wall.transform.position = closed;
                timePassed = 0f;
                sfxManager.instance.playSound(failedSound, transform, 1f);
            }
        }
    }
}
