using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Age_script : MonoBehaviour
{
    // Initialize tamagotchi obj
    Tamagotchi_script tamagotchi = null;
    // Add reference to age text
    TextMesh timeText = null;
    private void Start()
    {
        // Set obj to reference
        timeText = GameObject.Find("Age_text").GetComponent<TextMesh>();
        tamagotchi = GameObject.Find("Tamagotchi_placeholder").GetComponent<Tamagotchi_script>();
    }
    void Update()
    {
        // Call function to display age
         DisplayTime(tamagotchi.age);
    }
    void DisplayTime(float ageToDisplay)
    {
        // Increment time
        ageToDisplay += 1;
        // Every 30 seconds, age will increase
        float ageClock = Mathf.FloorToInt(ageToDisplay / 30);
        // Age Display
        timeText.text = string.Format("Age: {0:0} y/o", ageClock);
    }
}
