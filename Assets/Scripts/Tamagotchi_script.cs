using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamagotchi_script : MonoBehaviour
{
    // Given the Tamagotchi stats that can be changed
    public int happiness = 0;
    public int hunger = 67;
    public float age = 0;
    public int weight = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
    }
}
