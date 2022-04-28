using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flush_script : MonoBehaviour
{
    // 2 second timer for flushing poo
    float cntdnw = 2.0f;
    // Clean poo variable
    int clean = 0;
    // Set reference for tamagotchi and animation
    public Tamagotchi_script tamagotchi = null;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        // Find the Tamagotchi object and set the variables for the reference
        tamagotchi = GameObject.Find("Tamagotchi_placeholder").GetComponent<Tamagotchi_script>();
        // Get flush animation component
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clean == 1)
        {
            // While the flush is playing
            if (cntdnw > 0)
            {
                // The 2 seconds count down
                cntdnw -= Time.deltaTime;
            }
            // When the count down is over
            if (cntdnw <= 0)
            {
                // Make game obj false
                gameObject.SetActive(false);
            }
        }
    }

    public void FlushPoo()
    {
        // Play flush animation
        anim.Play("Poo_flush_animation");
        // Queue count down
        cntdnw = 2.0f;
        clean = 1;
    }
}
