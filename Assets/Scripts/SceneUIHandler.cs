using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUIHandler : MonoBehaviour
{
    public GameObject abstractDataViz; 
    public void toggleObject () {
        abstractDataViz.SetActive(!abstractDataViz.activeSelf);
    }
}
