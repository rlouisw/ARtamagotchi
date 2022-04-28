using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    Collider _collider; 
    void Start()
    {
        _collider = GetComponent<Collider>(); 
        _collider.isTrigger = true; 
        
    }
    void onTriggerEnter(Collider ti) {
        consumable Consumable = ti.GetComponent<consumable>(); 
        if (Consumable != null && !Consumable.isFinished) {
            Consumable.consume(); 
        }
    }
}
