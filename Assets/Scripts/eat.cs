using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eat : MonoBehaviour
{
    bool guiShow = false; 
    public GameObject Stylized_Burger;
    public int rayLength = 2; 
    public Slider hungerSlider; 
    public int meatgain; 


    void Update () {
        RaycastHit hit; 
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position,fwd,out hit,rayLength)) {
            if (hit.collider.gameObject.tag == "Stylized_Burger")
            {
                guiShow = true; 
                if (Input.GetKeyDown("e"))
                {
                    hungerSlider.value += meatgain; 
                    guiShow = false;
                }
            }

        }
    }

     void OnGUI() {
         if (guiShow == true) {
             GUI.Box(new Rect(Screen.width/2,Screen.height/2,100,25),"Eat"); 
         }       
    }

    
}
