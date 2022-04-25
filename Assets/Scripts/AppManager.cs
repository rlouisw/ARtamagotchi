using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;


public class AppManager : MonoBehaviour
{
    public float appRefresh;
    private float timer;
    public Text currentWeatherText, tempText, currentTimeText;
    public WeatherStates weatherController;
    public IPGrabber ip;
    private void Start()
    {
        timer = appRefresh;
        
    }

    public IEnumerator GetWeather()
    {
        var weatherAPI = new UnityWebRequest("https://api.openweathermap.org/data/2.5/weather?q="+ip.ipCity+","+ip.ipCountry+ "&units=metric&APPID=9fd2343cf9c74a028b1b125c3324084f")
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return weatherAPI.SendWebRequest();

        if(weatherAPI.result == UnityWebRequest.Result.ConnectionError || weatherAPI.result == UnityWebRequest.Result.ProtocolError)
        {
            print("Fail getting data");
            yield break;
        }

        JSONNode weatherInfo = JSON.Parse(weatherAPI.downloadHandler.text);
        
        currentWeatherText.text = "Current weather: " + weatherInfo["weather"][0]["description"];
        tempText.text = "Current temperature: " + Mathf.Floor(weatherInfo["main"][0]) + "°C";
        


        if (weatherInfo["weather"][0]["icon"] == "01d")
        {
            weatherController.ClearDay();
        }
        else if (weatherInfo["weather"][0]["icon"] == "01n")
        {
            weatherController.ClearNight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "02d")
        {
            weatherController.CloudCover();
            weatherController.ClearDay();
        }
        else if (weatherInfo["weather"][0]["icon"] == "02n")
        {
            weatherController.CloudCover();
            weatherController.ClearNight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "03d")
        {
            weatherController.CloudsDay();
        }
        else if (weatherInfo["weather"][0]["icon"] == "03n")
        {
            weatherController.CloudsNight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "10d")
        {
            weatherController.RainDay();
        }
        else if (weatherInfo["weather"][0]["icon"] == "10n")
        {
            weatherController.RainNight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "09n")
        {
            weatherController.CloudCover();
            weatherController.RainNightLight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "09d")
        {
            weatherController.CloudCover();
            weatherController.RainDayLight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "50d")
        {
            
            weatherController.MistDay();
        }
        else if (weatherInfo["weather"][0]["icon"] == "50n")
        {
            weatherController.MistNight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "13d")
        {
            weatherController.SnowDay();
        }
        else if (weatherInfo["weather"][0]["icon"] == "13n")
        {
            weatherController.SnowNight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "02d")
        {
            weatherController.CloudsDayLight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "02n")
        {
            weatherController.CloudsNightLight();
        }
        else if (weatherInfo["weather"][0]["icon"] == "04d")
        {
            weatherController.CloudsDayBroken();
        }
        else if (weatherInfo["weather"][0]["icon"] == "04n")
        {
            weatherController.CloudsNightBroken();
        }
        else if (weatherInfo["weather"][0]["icon"] == "11d")
        {
            weatherController.CloudCover();
            weatherController.RainNight();
        }

        print(weatherInfo["weather"][0]["description"]);
        print(weatherInfo["weather"][0]["icon"]);
        print(weatherInfo["weather"][0]["main"]);


    }

    private void Update()
    {
        currentTimeText.text = "Current time: "+DateTime.Now.ToString(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
        timer -= Time.deltaTime;


        if(timer <= 0)
        {
            StopCoroutine("GetWeather");
            StartCoroutine("GetWeather");
            print("App Refresh");
            
            timer = appRefresh;
        }
    }
}
