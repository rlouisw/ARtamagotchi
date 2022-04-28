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
<<<<<<< Updated upstream
    [SerializeField]
    private int _weight = 20;

    public int currentHealth; 
=======
    public int weight = 5;
    public float currentAge = 0;
    public float birthAge = 0;
    public int stage = 0;
    public float currentHealth;
>>>>>>> Stashed changes
    public int maxHealth = 100;
    public int maxHunger = 100; 

<<<<<<< Updated upstream
    // This will update happiness, hunger, age, and weight for the tamagotchi based on
    // elapsed time  
    private bool _serverTime; 

    //create ref to health bar script 
    public healthBar healthbar; 

=======
    public GameObject pinkEgg = null;
    public GameObject greenEgg = null;
    public GameObject yellowEgg = null;
    public GameObject cyanEgg = null;
    public GameObject baby = null;
    public GameObject grape = null;
    public GameObject kiwi = null;
    public GameObject pear = null;
    public GameObject peach = null;
    public GameObject ichigotchi = null;
    public GameObject poo = null;
    public GameObject burger = null;
    public GameObject cookie = null;
    public GameObject death = null;
    public GameObject deathEgg = null;
    public GameObject playerButtons = null;
    public GameObject eggButton = null;
    public GameObject devButtons = null;
    public GameObject meter = null;
    public GameObject startOverP = null;
    public GameObject egg = null;
    private const float coef = 0.2f;

    EggHatching_script Hatch_script = null;
    Flush_script clean_script = null;
     //create ref to health bar script 
    public healthBar healthbar; 
    public Hunger_bar hungerBar; 
    public GameObject adult = null;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("then","04/21/2022 1:39:12");
        currentHealth = maxHealth; 
        healthbar.SetMax(maxHealth); 
<<<<<<< Updated upstream
        updateStatus(); 
=======
        hunger = maxHunger; 
        hungerBar.SetMax(maxHunger); 

>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
<<<<<<< Updated upstream
       if (hunger<50) {   //if hunger drops below a certain threshold: 50 it'll drop by 1
            takeDamage(1); 
=======

        if (hunger <= 0) {
            takeDamage(1); 
        }

        //Hatch Egg
        if (stage == 1 && age >= currentAge + 600)
            hatchEgg();

        if (stage == 1 && Mathf.Round((age - birthAge)) / 60 >= 5)
            evolve();

            //Handle treat after it's been active for 2 second
        if (stage >= 2 && cookie.activeInHierarchy && age >= currentAge + 2)
        {
            cookie.SetActive(false);
            if (happiness == 100)
                happy(-5);
            else
                happy(20);
            currentAge = age;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
        adult.SetActive(true);
        currentAge = age;
        stage = 3;
    }

    public void end()
    {
        adult.SetActive(false);
        adult = null;
        poo.SetActive(false);
        burger.SetActive(false);
        cookie.SetActive(false);
        playerButtons.SetActive(false);
        meter.SetActive(true);
        death.SetActive(true);
        startOverP.SetActive(true);
        stage = 4;
    }

    public void happyEnd()
    {
        end();
        deathEgg.SetActive(true);
    }

    public void startOverPlayer()
    {
        startOverP.SetActive(false);
        meter.SetActive(false);
        death.SetActive(false);
        deathEgg.SetActive(false);
        eggButton.SetActive(true);
        stage = 0;
    }

    private void happy(int change)
    {
        happiness += change;
        if (happiness < 0)
            happiness = 0;
        else if (happiness > 100)
            happiness = 100;
    }

    private void hungry(int change)
    {
        hunger += change;
        if (hunger < 0) {
            hunger = 0;
            end(); 
        }
     
        else if  (hunger > 100) {
            hunger = 100;
            hungerBar.SetHunger(hunger); 
        }
    }

    public void feed()
    {
        burger.SetActive(true);
        currentAge = age;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
=======
    public void healthDownDev()
    {
        happy(-20);
    }

    void takeDamage (int damage) {
        currentHealth = currentHealth- (coef *Time.deltaTime); 
        if (currentHealth <0) {
            currentHealth = 0; 
        }
        healthbar.SetHealth(currentHealth); 
    }


>>>>>>> Stashed changes
}
