using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Hunger_bar : MonoBehaviour
{
    public Tamagotchi_script tamagotchi_; 
    public Slider slider; 
    public Gradient gradient; 
    public Image fill; 
    public void SetMax(int hunger) {
        slider.maxValue = hunger; 
        slider.value = hunger; 
        fill.color = gradient.Evaluate(1f); //max hunger at 1, 0 for min hunger 
    }
    public void SetHunger (int hunger) 
    {
        slider.value = hunger; 
        fill.color = gradient.Evaluate(slider.normalizedValue); 
    }
}
