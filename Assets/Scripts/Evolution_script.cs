using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution_script : MonoBehaviour
{
    float cntdnw = 5.0f;
    // Hatch queue variable
    public int evo = 0;
    // Set reference for particles, hatching animation, tamagotchi, and particle system
    public Tamagotchi_script tamagotchi = null;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        // Find the Tamagotchi object and set the variables for the reference
        // tamagotchi = GameObject.Find("Tamagotchi_placeholder").GetComponent<Tamagotchi_script>();
        // Make sure the particles are off
        // Get hatch animation component
        anim = gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        if (evo == 1)
        {
            // While the egg is hatching
            if (cntdnw > 0)
            {
                // 10 seconds count down
                cntdnw -= Time.deltaTime;
            }
            // When the couontdown is over
            if (cntdnw <= 0)
            {
                // Do hatching protocol
                gameObject.SetActive(false);
                tamagotchi.poo.SetActive(false);
                tamagotchi.burger.SetActive(false);
                tamagotchi.cookie.SetActive(false);
                if (tamagotchi.happiness == 100)
                {
                    tamagotchi.adult = tamagotchi.ichigotchi;
                    tamagotchi.weight += 20;
                    tamagotchi.happyS = tamagotchi.ichigotchiH;
                    tamagotchi.sadS = tamagotchi.ichigotchiS;
                    tamagotchi.outdoorG = tamagotchi.ichigotchiG;
                }
                else if (tamagotchi.happiness >= 80)
                {
                    tamagotchi.adult = tamagotchi.peach;
                    tamagotchi.weight += 25;
                    tamagotchi.happyS = tamagotchi.peachH;
                    tamagotchi.sadS = tamagotchi.peachS;
                    tamagotchi.outdoorG = tamagotchi.peachG;
                }
                else if (tamagotchi.happiness >= 60)
                {
                    tamagotchi.adult = tamagotchi.pear;
                    tamagotchi.weight += 30;
                    tamagotchi.happyS = tamagotchi.pearH;
                    tamagotchi.sadS = tamagotchi.pearS;
                    tamagotchi.outdoorG = tamagotchi.pearG;
                }
                else if (tamagotchi.happiness >= 40)
                {
                    tamagotchi.adult = tamagotchi.kiwi;
                    tamagotchi.weight += 15;
                    tamagotchi.happyS = tamagotchi.kiwiH;
                    tamagotchi.sadS = tamagotchi.kiwiS;
                    tamagotchi.outdoorG = tamagotchi.kiwiG;
                }
                else
                {
                    tamagotchi.adult = tamagotchi.grape;
                    tamagotchi.weight += 10;
                    tamagotchi.happyS = tamagotchi.grapeH;
                    tamagotchi.sadS = tamagotchi.grapeS;
                    tamagotchi.outdoorG = tamagotchi.grapeG;
                }
                tamagotchi.adult.SetActive(true);
                tamagotchi.currentAge = tamagotchi.age;
                tamagotchi.stage = 3;
            }
        }
    }

    // Hatch Egg into Tamagotchi
    public void Evolve()
    {
        // Play hatching animation
        anim.Play("Evolution_animation");
        // Queue hatch timer
        cntdnw = 5.0f;
        evo = 1;
    }
}
