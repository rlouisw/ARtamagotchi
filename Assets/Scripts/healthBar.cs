using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class healthBar : MonoBehaviour
{
    public Tamagotchi_script tamagotchi_; 
    public Slider slider; 
    public Gradient gradient; 
    public Image fill; 
    public void SetMax(int health) {
        slider.maxValue = health; 
        slider.value = health; 
        fill.color = gradient.Evaluate(1f); //max health at 1, 0 for min health 
    }
    public void SetHealth (int health) 
    {
        slider.value = health; 
        fill.color = gradient.Evaluate(slider.normalizedValue); 
    }
}
