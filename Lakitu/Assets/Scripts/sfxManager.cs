using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour
{
    public static sfxManager instance;
    [SerializeField] private AudioSource sFXobject;

    private void Awake(){
        if (instance == null){
            instance = this;
        }
    }

    /*
    void Start(){
        DontDestroyOnLoad(this.gameObject);
    }
    */

    public void playSound(AudioClip aclip, Transform spawnTransform, float volume){
        // spawn in oibject
        AudioSource aSource = Instantiate(sFXobject, spawnTransform.position, Quaternion.identity);
        // assign clip
        aSource.clip = aclip;
        // assign volume
        aSource.volume = volume;
        //play sound
        aSource.Play();
        //get length of clip
        float clipLength = aSource.clip.length;
        //destory clip
        Destroy(aSource.gameObject, clipLength);
    }
}
