using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger_script : MonoBehaviour
{
    // Set reference to Tamagotchi
    Tamagotchi_script tamagotchi = null;
    // Set reference to cookies
    GameObject cookie_1 = null;
    GameObject cookie_2 = null;
    GameObject cookie_3 = null;
    GameObject cookie_4 = null;
    GameObject cookie_5 = null;

    // Start is called before the first frame update
    void Start()
    {
        // Attach obj to references
        tamagotchi = GameObject.Find("Tamagotchi_placeholder").GetComponent<Tamagotchi_script>();
        cookie_1 = GameObject.Find("Cookie_1");
        cookie_2 = GameObject.Find("Cookie_2");
        cookie_3 = GameObject.Find("Cookie_3");
        cookie_4 = GameObject.Find("Cookie_4");
        cookie_5 = GameObject.Find("Cookie_5");
    }

    // Update is called once per frame
    void Update()
    {
        // Reveal 1 cookie per 20 hunger
        if (tamagotchi.hunger >= 20)
            cookie_1.SetActive(true);
        else
            cookie_1.SetActive(false);
        if (tamagotchi.hunger >= 40)
            cookie_2.SetActive(true);
        else
            cookie_2.SetActive(false);
        if (tamagotchi.hunger >= 60)
            cookie_3.SetActive(true);
        else
            cookie_3.SetActive(false);
        if (tamagotchi.hunger >= 80)
            cookie_4.SetActive(true);
        else
            cookie_4.SetActive(false);
        if (tamagotchi.hunger == 100)
            cookie_5.SetActive(true);
        else
            cookie_5.SetActive(false);
    }
}
