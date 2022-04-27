using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class IPGrabber : MonoBehaviour
{
    string ipAddress;
    public string ipCountry, ipCity;
    public AppManager appManager;
    void Start()
    {
        StartCoroutine("GrabIP");
        StartCoroutine("IPLocation");
    }

    IEnumerator GrabIP()
    {
        var response = new UnityWebRequest("https://api.ipify.org")
        {
            downloadHandler = new DownloadHandlerBuffer()
        };

        if (response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
        {
            yield break;
        }
        yield return response.SendWebRequest();
        
        yield return ipAddress = response.downloadHandler.text;
        
    }
    IEnumerator IPLocation()
    {
        var response = new UnityWebRequest("https://geo.ipify.org/api/v1?apiKey=at_NA8VUvAWvxolJlStxUoor7FvPTcSJ&ipAddress=" + ipAddress)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return response.SendWebRequest();

        if(response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
        {
            print("error");
            yield break;
        }

        JSONNode IPlocation = JSON.Parse(response.downloadHandler.text);
        yield return ipCity = IPlocation["location"]["city"];
        yield return ipCountry = IPlocation["location"]["country"];

        appManager.StartCoroutine("GetWeather");
    }

    
}
