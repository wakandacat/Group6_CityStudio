using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mainScript : MonoBehaviour
{

    public GameObject canvas;
    private GameObject title;
    private GameObject item1;
    private GameObject item2;
    private GameObject item3;
    private GameObject item4;

    private bool started = false;

    public string currValue = "FOOD"; //WATER, EQUIP


    // Start is called before the first frame update
    void Start()
    {
        title = canvas.transform.GetChild(0).gameObject;
        item1 = canvas.transform.GetChild(1).gameObject;
        item2 = canvas.transform.GetChild(2).gameObject;
        item3 = canvas.transform.GetChild(3).gameObject;
        item4 = canvas.transform.GetChild(4).gameObject;

        Invoke("StartGame", 27); //start once the timeline intro is finished

        Invoke("foodItems", 55); //start once the timeline intro is finished
    }

    // Update is called once per frame
    void Update()
    {
        ////ensure the canvas is always shown once we start
        //if (canvas.activeSelf == false && started == true)
        //{
        //    canvas.SetActive(true);
        //    // started = false;
        //}
    }

    void StartGame()
    {
        started = true;
        canvas.SetActive(true);

    }

    void foodItems()
    {
        item1.SetActive(true);
        item2.SetActive(true);
        item3.SetActive(true);
        item4.SetActive(true);
    }
}
