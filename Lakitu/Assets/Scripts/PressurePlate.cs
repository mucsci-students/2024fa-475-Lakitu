using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isOn;

    public GameObject door;
    public Vector3 opened;
    public Vector3 closed;

    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        closed = door.transform.position;
        opened = door.transform.position + new Vector3(0f, 5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn){
            door.transform.position = opened;
        }
        else{
            door.transform.position = closed;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6){
            sfxManager.instance.playSound(openSound, transform, 1f);
            isOn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 6){
            sfxManager.instance.playSound(closeSound, transform, 1f);
            isOn = false;
        }
    }
}
