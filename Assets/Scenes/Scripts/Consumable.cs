using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine.Events; 
using UnityEngine;


//test this with image target, if not working maybe implement the consume() inside the button() 
public class Consumable : MonoBehaviour
{


    public GameObject vbBtnObj; 
    public GameObject food; 

 //set ref to tamagotchi 
    Tamagotchi_script tamagotchi = null; 

    [SerializeField] GameObject[] portions; //array of objects 
    [SerializeField] int index = 0; //to keep track of the current portion 

    public bool isFinished => index == portions.Length; //checks to see if we're finished eating 

    //maybe add in a audio source, so that when the pet(tamagotchi) eats the object
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        vbBtnObj = GameObject.Find("eat"); 

        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onButtonPressed); 
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased); 
        _audioSource = GetComponent<AudioSource>();
        SetVisual(); 
        food = GameObject.Find("Stylized_Burger"); 
        _audioSource.playOnAwake = false; // just in case we forget to set it in inspector! 
        //SetVisual(); call this in onButtonpressed method?  
    }
    //W/O having to open up VR and test it we can use context menu 
    [ContextMenu("consume")] //allows to call it from unity 
    public void consume () {
        if (!isFinished) { 
            index++;
            SetVisual();
            _audioSource.Play();
        }
        else {
            tamagotchi.hunger+=20; //increment hunger variable by 20(one cookie) once finished eating
            //increase weight as well and happiness as well: 

            tamagotchi.weight+=5; //increment weight by 5 
            tamagotchi.happiness++; 
        }
    }
    public void onButtonPressed(VirtualButtonBehaviour vb) {


        SetVisual(); 


        Debug.Log("Button Pressed"); 
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        Debug.Log("Button Released");    
    }

     void SetVisual() {
        //Loop through every portion; active / inactive will be dependent on the index 
        for (int i = 0; i<portions.Length;i++) {
            portions[i].SetActive(i==index);
            
        }
        if (portions.Length < index) {
                //inactive: 
                Debug.Log ("not enough"); 
                
            }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}


/*TODO:
- test with image target []
- Make sure when button pressed it works [] 
- Make sure that the metric (increase in hunger and happiness and weight) correctly displays when fed []
- Make animation so that when it touches the tamagotchi's mouth it starts the script []
- If all of this works, start on the toilet script[]
*/