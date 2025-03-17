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
    private GameObject[] itemList;

    public string currValue = "FOOD"; //WATER, EQUIP

    public GameObject waterIntro;
    public GameObject equipIntro;
    public GameObject outro;


    // Start is called before the first frame update
    void Start()
    {
        title = canvas.transform.GetChild(0).gameObject;
        item1 = canvas.transform.GetChild(1).gameObject;
        item2 = canvas.transform.GetChild(2).gameObject;
        item3 = canvas.transform.GetChild(3).gameObject;
        item4 = canvas.transform.GetChild(4).gameObject;

        itemList = new[] { item1, item2, item3, item4 };

        Invoke("StartGame", 27); //start once the timeline intro is finished

        Invoke("foodItems", 55); //start once the timeline intro is finished
    }

    void StartGame()
    {
        canvas.SetActive(true);
    }

    void foodItems()
    {
        title.GetComponent<TextMeshProUGUI>().text = "Food";
        item1.SetActive(true);
        item2.SetActive(true);
        item3.SetActive(true);
        item4.SetActive(true);
    }

    void waterItems()
    {
        currValue = "WATER";

        title.GetComponent<TextMeshProUGUI>().text = "Water";

        //change all text to be water
        for (int i = 0; i < itemList.Length; i++)
        {
            itemList[i].GetComponent<TextMeshProUGUI>().text = "\u25A1 Water Bottle";
            itemList[i].GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);
        }

        //play water intro
        if (waterIntro && waterIntro.GetComponent<AudioSource>().isPlaying == false)
        {
            waterIntro.GetComponent<AudioSource>().Play();
        }
    }

    void equipItems()
    {
        currValue = "EQUIP";

        title.GetComponent<TextMeshProUGUI>().text = "Equipment";

        //change all text to be equipment
        for (int i = 0; i < itemList.Length; i++)
        {
            itemList[i].GetComponent<TextMeshProUGUI>().text = "\u25A1 Equipment";
            itemList[i].GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);
        }

        //play equipment intro
        if (equipIntro && equipIntro.GetComponent<AudioSource>().isPlaying == false)
        {
            equipIntro.GetComponent<AudioSource>().Play();
        }
    }

    void gameDone()
    {

        title.GetComponent<TextMeshProUGUI>().text = "Completed!";

        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);
        item4.SetActive(false);

        //play outro
        if (outro && outro.GetComponent<AudioSource>().isPlaying == false)
        {
            outro.GetComponent<AudioSource>().Play();
        }
    }

    public void correctItem()
    {
        int numCorrect = 0;

        //update next text item to be completed
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i].GetComponent<TextMeshProUGUI>().text.Contains("\u25A1"))
            {
                if (currValue == "FOOD")
                {
                    itemList[i].GetComponent<TextMeshProUGUI>().text = "\u00D7 Food Item";
                } 
                else if (currValue == "WATER")
                {
                    itemList[i].GetComponent<TextMeshProUGUI>().text = "\u00D7 Water Bottle";
                }
                else if (currValue == "EQUIP")
                {
                    itemList[i].GetComponent<TextMeshProUGUI>().text = "\u00D7 Equipment";
                }

                itemList[i].GetComponent<TextMeshProUGUI>().color = new Color32(0, 118, 6, 255);
                break;
            }

        }

        //check if they are all completed
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i].GetComponent<TextMeshProUGUI>().text.Contains("\u00D7"))
            {
                numCorrect++;
            }
        }

        if (numCorrect == itemList.Length)
        {
            if (currValue == "FOOD")
            {
                waterItems();
            }
            else if (currValue == "WATER")
            {
                equipItems();
            }
            else if (currValue == "EQUIP")
            {
                gameDone();
            }

        }
    }
}
