using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggHatching_script : MonoBehaviour
{
    // 10 second timer for hatching tamagotchi
    float cntdnw = 10.0f;
    // Hatch queue variable
    public int hatch = 0;
    // Set reference for particles, hatching animation, tamagotchi, and particle system
    public GameObject Hatch_p = null;
    public Tamagotchi_script tamagotchi = null;
    public ParticleSystem ps;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        // Find the Tamagotchi object and set the variables for the reference
        // tamagotchi = GameObject.Find("Tamagotchi_placeholder").GetComponent<Tamagotchi_script>();
        // Find hatching particles
        Hatch_p = GameObject.Find("Egg Hatch Particles");
        // Get particle system of hatching particles
        ps = Hatch_p.GetComponent<ParticleSystem>();
        // Make sure the particles are off
        Hatch_p.SetActive(false);
        // Get hatch animation component
        anim = gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        if (hatch == 1)
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
                // Stop particles and turn off game obj
                ps.Stop();
                // Do hatching protocol
                gameObject.SetActive(false);
                tamagotchi.egg = null;
                tamagotchi.baby.SetActive(true);
                tamagotchi.playerButtons.SetActive(true);
                tamagotchi.birthAge = tamagotchi.age;
                tamagotchi.currentAge = tamagotchi.age;
                tamagotchi.stage = 2;
                tamagotchi.happiness = 40;
                tamagotchi.hunger = 20;
                tamagotchi.weight = 5;
                tamagotchi.happyS = tamagotchi.babyH;
                tamagotchi.sadS = tamagotchi.babyS;
            }
        }
    }

    // Hatch Egg into Tamagotchi
    public void HatchEgg()
    {
        // Aet particles to active
        Hatch_p.SetActive(true);
        // Play particles
        ps.Play();
        // Play hatching animation
        anim.Play("Egg_hatching_animation");
        // Queue hatch timer
        cntdnw = 10.0f;
        hatch = 1;
    }
}
