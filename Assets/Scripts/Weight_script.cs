using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight_script : MonoBehaviour
{
    // Initialize tamagotchi obj
    Tamagotchi_script tamagotchi = null;
    // Add reference to age text
    TextMesh timeText = null;
    private void Start()
    {
        // Set obj to reference
        timeText = GameObject.Find("Weight_text").GetComponent<TextMesh>();
        tamagotchi = GameObject.Find("Tamagotchi_placeholder").GetComponent<Tamagotchi_script>();
    }
    void Update()
    {
        // Call function to display weight
        DisplayWeight(tamagotchi.weight);
    }
    void DisplayWeight(float weight)
    {
        // Display Tamagotchi's weight
        timeText.text = string.Format("{0}{1:0} lbs", "Weight: ", weight);
    }
}
