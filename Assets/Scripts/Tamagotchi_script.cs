using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamagotchi_script : MonoBehaviour
{
    // Given the Tamagotchi stats that can be changed
    public int happiness = 40;
    public int hunger = 20;
    public float age = 0;
    public int weight = 5;
    public float currentAge = 0;
    public float birthAge = 0;
    public int stage = 0;
    public int currentHealth;
    public int maxHealth = 100;

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
    // Animations
    public Evolution_script Evo_script = null;
    public EggHatching_script Hatch_script = null;
    public Flush_script clean_script = null;
     //create ref to health bar script 
    public healthBar healthbar; 
    public GameObject adult = null;

    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        currentHealth = maxHealth; 
        healthbar.SetMax(maxHealth); 

    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;

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
        }

        //Handle food after it's been active for 2 second
        if (stage >= 2 && burger.activeInHierarchy && age >= currentAge + 2)
        {
            burger.SetActive(false);
            if (hunger == 100)
                happy(-20);
            else
                hungry(20);
            currentAge = age;
        }

        if (stage >= 2 && Mathf.Round((age - birthAge)) % 600 == 0)
        {
            poo.SetActive(true);
            happy(-20);
            hungry(-20);
        }

        if (stage == 3 && (hunger == 0 || happiness == 0))
            end();
        
        if (stage == 3 && adult == grape && Mathf.Round((age - birthAge)) / 60 >= 10)
            happyEnd();

        if (stage == 3 && adult == kiwi && Mathf.Round((age - birthAge)) / 60 >= 15)
            happyEnd();

        if (stage == 3 && adult == pear && Mathf.Round((age - birthAge)) / 60 >= 20)
            happyEnd();

        if (stage == 3 && adult == peach && Mathf.Round((age - birthAge)) / 60 >= 25)
            happyEnd();

        if (stage == 3 && adult == ichigotchi && Mathf.Round((age - birthAge)) / 60 >= 30)
            happyEnd();
    }

    public void createEgg()
    {
        eggButton.SetActive(false);
        int randomNum = Random.Range(0, 4);
        if (randomNum == 0)
            egg = pinkEgg;
        else if (randomNum == 1)
            egg = greenEgg;
        else if (randomNum == 2)
            egg = yellowEgg;
        else
            egg = cyanEgg;
        egg.SetActive(true);
        currentAge = age;
        stage = 1;
    }

    public void hatchEgg()
    {
        Hatch_script = egg.GetComponent<EggHatching_script>();
        Hatch_script.HatchEgg();
    }

    public void evolve()
    {
        Evo_script = baby.GetComponent<Evolution_script>();
        Evo_script.Evolve();
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
        Evo_script.evo = 0;
        Hatch_script.hatch = 0;
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
        if (hunger < 0)
            hunger = 0;
        else if (hunger > 100)
            hunger = 100;
    }

    public void feed()
    {
        burger.SetActive(true);
        currentAge = age;
    }

    public void treat()
    {
        cookie.SetActive(true);
        currentAge = age;
    }

    public void clean()
    {
        clean_script = poo.GetComponent<Flush_script>();
        if (poo.activeInHierarchy)
        {
            clean_script.FlushPoo();
            happy(20);
        }
        else if (stage == 2)
            happy(-10);
    }

    public void dev()
    {
        if (devButtons.activeInHierarchy)
            devButtons.SetActive(false);
        else
            devButtons.SetActive(true);
    }

    public void startOverDev()
    {
        if (stage != 0)
        {
            if (stage == 1)
            {
                egg.SetActive(false);
                egg = null;
            }
            else if (stage == 2)
            {
                baby.SetActive(false);
                poo.SetActive(false);
                burger.SetActive(false);
                cookie.SetActive(false);
                playerButtons.SetActive(false);
                meter.SetActive(false);
            }
            else if (stage == 3)
            {
                adult.SetActive(false);
                adult = null;
                poo.SetActive(false);
                burger.SetActive(false);
                cookie.SetActive(false);
                playerButtons.SetActive(false);
                meter.SetActive(false);
            }
            else
                startOverPlayer();
            eggButton.SetActive(true);
            stage = 0;
            Evo_script.evo = 0;
            Hatch_script.hatch = 0;
        }
    }

    public void foodUpDev()
    {
        hungry(20);
    }

    public void foodDownDev()
    {
        hungry(-20);
    }

    public void healthUpDev()
    {
        happy(20);
    }

    public void healthDownDev()
    {
        happy(-20);
    }

    void takeDamage (int damage) {
        currentHealth -= damage; 
        if (currentHealth <0) {
            currentHealth = 0; 
        }
        healthbar.SetHealth(currentHealth); 
    }
}
