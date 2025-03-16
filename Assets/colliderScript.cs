using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{

    public mainScript mainScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // check what collides with the plane
    //void OnCollisionEnter(Collision collided)
    //{
    //    Debug.Log(collided.gameObject.name);
    //    if (collided.gameObject.tag == mainScript.currValue)
    //    {
    //        Debug.Log("correct item");
    //    } 
    //    else
    //    {
    //        Debug.Log("incorrect item");
    //    }
    //}

    void OnTriggerEnter(Collider collided)
    {
        Debug.Log(collided.gameObject.name);
        if (collided.gameObject.tag == mainScript.currValue)
        {
            Debug.Log("correct item");
        }
        else
        {
            Debug.Log("incorrect item");
        }
    }
}
