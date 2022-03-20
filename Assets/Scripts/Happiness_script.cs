using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happiness_script : MonoBehaviour
{
    // Set reference to Tamagotchi
    Tamagotchi_script tamagotchi = null;
    // Set reference to cookies
    GameObject heart_1 = null;
    GameObject heart_2 = null;
    GameObject heart_3 = null;
    GameObject heart_4 = null;
    GameObject heart_5 = null;

    // Start is called before the first frame update
    void Start()
    {
        // Attach obj to references
        tamagotchi = GameObject.Find("Tamagotchi_placeholder").GetComponent<Tamagotchi_script>();
        heart_1 = GameObject.Find("Heart_1");
        heart_2 = GameObject.Find("Heart_2");
        heart_3 = GameObject.Find("Heart_3");
        heart_4 = GameObject.Find("Heart_4");
        heart_5 = GameObject.Find("Heart_5");
    }

    // Update is called once per frame
    void Update()
    {
        // Reveal 1 heart per 20 happiness
        if (tamagotchi.happiness >= 20)
            heart_1.SetActive(true);
        else
            heart_1.SetActive(false);
        if (tamagotchi.happiness >= 40)
            heart_2.SetActive(true);
        else
            heart_2.SetActive(false);
        if (tamagotchi.happiness >= 60)
            heart_3.SetActive(true);
        else
            heart_3.SetActive(false);
        if (tamagotchi.happiness >= 80)
            heart_4.SetActive(true);
        else
            heart_4.SetActive(false);
        if (tamagotchi.happiness >= 100)
            heart_5.SetActive(true);
        else
            heart_5.SetActive(false);
    }
}
