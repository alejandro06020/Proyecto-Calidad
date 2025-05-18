using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnerX : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float timedown = 2.0f;
    float timer;
    bool isCoolDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCoolDown=false;
        timer = timedown;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCoolDown){
            timer-=Time.deltaTime;
            if(timer<0){
                isCoolDown=false;
            }
        }else{
            int posy = UnityEngine.Random.Range(-2,2);
            Instantiate(enemy,new Vector3(this.transform.position.x,posy,0),this.transform.rotation);
            isCoolDown=true;
            timer= timedown;
        }
    }
}
