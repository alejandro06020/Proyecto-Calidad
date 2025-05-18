using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Me toco: "+other);
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null && controller.getLife() < controller.maxLife){
            controller.changeLife(1);
            Destroy(gameObject);
        }
    }
}
