using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//player script: tamagotchi 
// if the hunger drops below a certain threshold: 50 
// it'll take damage by 1 
public class Tamagotchi_script : MonoBehaviour
{
    // Given the Tamagotchi stats that can be changed
    [SerializeField]
    private int _happiness = 0;
    [SerializeField]
    private int _hunger = 67;
    public float age = 0;
    [SerializeField]
    private int _weight = 20;

    public int currentHealth; 
    public int maxHealth = 100;

    // This will update happiness, hunger, age, and weight for the tamagotchi based on
    // elapsed time  
    private bool _serverTime; 

    //create ref to health bar script 
    public healthBar healthbar; 


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("then","04/21/2022 1:39:12");
        currentHealth = maxHealth; 
        healthbar.SetMax(maxHealth); 
        updateStatus(); 
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
       if (hunger<50) {   //if hunger drops below a certain threshold: 50 it'll drop by 1
            takeDamage(1); 
        }
    }

    void takeDamage(int damage) {
        currentHealth-= damage; 
        if (currentHealth < 0) {
            currentHealth = 0; 
        }
        healthbar.SetHealth(currentHealth); 
    }

    string getStringTime() {
        DateTime now = DateTime.Now; 
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    void updateStatus() {
        if (!PlayerPrefs.HasKey("hunger")) {
            hunger = 100; 
            PlayerPrefs.SetInt("hunger",hunger); 
        } else {
            hunger = PlayerPrefs.GetInt("hunger");
        }
        if (!PlayerPrefs.HasKey("happiness")) {
            happiness = 100; 
            PlayerPrefs.SetInt("happiness", happiness); 
        } else {
            happiness = PlayerPrefs.GetInt("happiness"); 
        }
        if (!PlayerPrefs.HasKey("weight")) {
            weight = 100; 
            PlayerPrefs.SetInt("weight",weight); 
        } else {
            weight = PlayerPrefs.GetInt("weight"); 
        }
        if (!PlayerPrefs.HasKey("then")) {
            PlayerPrefs.SetString ("then", getStringTime()); 
        }
        TimeSpan ts = GetTimeSpan(); 
        //For every hour you haven't played it'll take off 2 hunger 
        _hunger -= (int)(ts.TotalHours * 2);
        if (_hunger <0) {
            _hunger =0; 
        }
        _happiness -= (int)((100 - _hunger) * (ts.TotalHours/5)); 
        if (_happiness < 0) {
            _happiness = 0; 
        }
      Debug.Log(GetTimeSpan ().ToString()); 
        if (_serverTime) {
            updateServer(); 
        } else {
            InvokeRepeating("updateDevice",0f,30f); 
        }
    }

    void updateServer() {

    }

    void updateDevice () {
        PlayerPrefs.SetString ("then",getStringTime()); 
    }

    TimeSpan GetTimeSpan() {
        if (_serverTime) {
            return new TimeSpan(); 
        } else {
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }

    public int hunger {
        get {return _hunger;}
        set {_hunger = value;}
    }
    public int happiness {
        get {return _happiness;}
        set {_happiness = value;}
    }
    public int weight {
        get {return _weight;}
        set {_hunger = value;}
    }

}
