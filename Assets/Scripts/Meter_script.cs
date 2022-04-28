using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Meter starts hidden
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
    // Hide and Show Meter
    public void show_meter()
    {
        // Alternate between showing and hiding meter
        if (gameObject.active == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
