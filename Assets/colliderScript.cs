using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{

    public mainScript mainScript;
    public AudioSource wrongAudio;
    public AudioSource goodAudio;


    void OnTriggerEnter(Collider collided)
    {
        if (collided.gameObject.tag == mainScript.currValue)
        {
           // Debug.Log("correct item");
            mainScript.correctItem();
            if (goodAudio && goodAudio.isPlaying == false)
            {
                goodAudio.Play();
            }
        }
        else
        {
           // Debug.Log("incorrect item");
            if (wrongAudio && wrongAudio.isPlaying == false)
            {
                wrongAudio.Play();
            }

        }
    }
}
