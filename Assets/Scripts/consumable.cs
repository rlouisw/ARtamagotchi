using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumable : MonoBehaviour
{
    public GameObject food; 
    public GameObject vBtnObj; 

    Tamagotchi_script tamagotchi = null; 
    [SerializeField] GameObject[] portions; //array of objects 
    [SerializeField] int index = 0; // keep track of current portion 

    public bool isFinished => index == portions.Length; //If finished eating 
        AudioSource _audioSource; 


     void Start()
    {
        // Find the Tamagotchi object and set the variables for the reference
        tamagotchi = GameObject.Find("Tamagotchi_placeholder").GetComponent<Tamagotchi_script>();
        vBtnObj = GameObject.Find ("eat"); 
        SetVisual(); 
        food = GameObject.Find("Stylized_Burger");
        _audioSource = GetComponent<AudioSource>(); 
         _audioSource.playOnAwake = false; 
    }
     [ContextMenu("consume")] // allows to call it from unity 
     
    public void consume () { 
        if (!isFinished) {
            index++; 
            SetVisual(); 
            _audioSource.Play(); //Muching sound when consuming food ? 
        } else {
            tamagotchi.hunger+=20; //Increment Hunger variable by 20 once done eating
            tamagotchi.weight+= 5; 
            tamagotchi.happiness++; 
        }
    }

    void SetVisual () {
        //Loop through every portion
        for (int i = 0; i<portions.Length;i++) {
            portions[i].SetActive(i==index);
        }
        if (portions.Length < index) {
            Debug.Log("not enough"); 
        }
    }

}
