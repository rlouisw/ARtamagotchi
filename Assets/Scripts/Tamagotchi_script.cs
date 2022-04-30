using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    int num1 = 0;
    int num2 = 0;
    //Game Objects
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
    public GameObject weatherStates = null;
    public GameObject babyG = null;
    public GameObject grapeG = null;
    public GameObject kiwiG = null;
    public GameObject pearG = null;
    public GameObject peachG = null;
    public GameObject ichigotchiG = null;
    public GameObject rug = null;
    public GameObject outdoorG = null;
    public GameObject miniGame = null;
    public GameObject rules = null;
    public GameObject results = null;
    public TMP_Text resultsLabel = null;
    
    //Sounds
    public AudioClip babyH = null;
    public AudioClip babyS = null;
    public AudioClip grapeH = null;
    public AudioClip grapeS = null;
    public AudioClip kiwiH = null;
    public AudioClip kiwiS = null;
    public AudioClip pearH = null;
    public AudioClip pearS = null;
    public AudioClip peachH = null;
    public AudioClip peachS = null;
    public AudioClip ichigotchiH = null;
    public AudioClip ichigotchiS = null;
    public AudioClip win = null;
    public AudioClip lose = null;
    public AudioClip happyS = null;
    public AudioClip sadS = null;
    public AudioSource audio = null;
    // Animations
    public Evolution_script Evo_script = null;
    public EggHatching_script Hatch_script = null;
    public Flush_script clean_script = null;
    public GameObject adult = null;
    bool outdoor = false;

    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        currentHealth = maxHealth; 
        outdoor = false;

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

        if (stage >= 2 && age >= 600 && Mathf.Round((age - birthAge)) % 600 == 0)
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
        rug.SetActive(true);
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
    }

    private void happy(int change)
    {
        happiness += change;
        if (happiness < 0)
            happiness = 0;
        else if (happiness > 100)
            happiness = 100;
        if (change < 0)
            audio.clip = sadS;
        else
            audio.clip = happyS;
        audio.PlayDelayed(3.0f);
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

    public void outside()
    {
        if (!outdoor)
        {
            weatherStates.SetActive(true);
            outdoor = true;
            rug.SetActive(false);
            outdoorG.SetActive(true);
        }
        else
        {
            weatherStates.SetActive(false);
            outdoor = false;
            outdoorG.SetActive(false);
            rug.SetActive(true);
        }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void play()
    {
        miniGame.SetActive(true);
        num1 = Random.Range(1, 10);
        num2 = num1;
        while (num1 == num2)
        {
            num2 = Random.Range(1, 10);
        }
    }

    public void higher()
    {
        if (num1 < num2)
            goal(true);
        else
            goal(false);
    }

    public void lower()
    {
        if (num1 > num2)
            goal(true);
        else
            goal(false);
    }

    private void goal(bool winner)
    {
        rules.SetActive(false);
        results.SetActive(true);
        string outcome;
        if (winner)
        {
            outcome = "win";
            audio.clip = win;
        }
        else
        {
            outcome = "lose";
            audio.clip = lose;
        }
        resultsLabel.text = "My number is " + num1.ToString() + ", your number is " + num2.ToString() + ".  You " + outcome + ".  Do you want to play again?";
        audio.Play();
        /*if (winner)
        {
            if (baby != null)
                happy(20);
            else
                happy(-5);
        }
        else
            happy(20);*/
    }

    public void yes()
    {
        results.SetActive(false);
        rules.SetActive(true);
        play();
    }

    public void no()
    {
        results.SetActive(false);
        rules.SetActive(true);
        miniGame.SetActive(false);
    }

}