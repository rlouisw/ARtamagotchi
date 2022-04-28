using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_script : MonoBehaviour
{
    // 3 second timer for petting tamagotchi
    float cntdnw = 3.0f;
    // Set reference to Tamagotchi
    public Tamagotchi_script tamagotchi = null;

    // Start is called before the first frame update
    void Start()
    {
        // Make the hand invisible on start
        gameObject.SetActive(true);
        // Find the Tamagotchi object and set the variables for the reference
        // tamagotchi = GameObject.Find("Tamagotchi_placeholder").GetComponent<Tamagotchi_script>();
    }

    // Update is called once per frame
    void Update()
    {
        // While the hand is petting for 3 seconds
        if (cntdnw > 0)
        {
            // The hand becomes visible
            gameObject.SetActive(true);
            // The 3 seconds count down
            cntdnw -= Time.deltaTime;
        }
        // When the hand is done petting
        if (cntdnw <= 0)
        {
            // Hand becomes unactive
            gameObject.SetActive(false);
        }
    }

    // Pet the Tamagotchi (increase happiness)
    public void pet()
    {
        // Once pet button is pressed, hand becomes active for 3 seconds
        gameObject.SetActive(true);
        cntdnw = 3.0f;
        // Increment happiness variable for tamagotchi
        tamagotchi.happiness += 20;
    }
}
