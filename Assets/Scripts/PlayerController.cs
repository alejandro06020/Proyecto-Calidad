using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Movimientos
    public InputAction Movement;
    Rigidbody2D rigidbody2d2;
    [SerializeField] float speed=6.0f;
    Vector2 move;
    //Vida del jugador
    [SerializeField] public int maxLife = 3;
    int actualLife = 3;
    // Variables related to temporary invincibility
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;
    void Start()
    {
        Movement.Enable();
        rigidbody2d2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Movement.ReadValue<Vector2>();
        if(isInvincible){
            damageCooldown -= Time.deltaTime;
            if(damageCooldown<0){
                isInvincible=false;
            }
        }

    }
    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d2.position + move * speed * Time.deltaTime;
        rigidbody2d2.MovePosition(position);
        
    }
    public void changeLife(int amount){
        if(amount<0){
            if(isInvincible){
                return;
            }
            isInvincible=true;
            damageCooldown=timeInvincible;
        }
        actualLife=Math.Clamp(actualLife+amount,0,maxLife);
        UIManage.instance.SetHealthValue(actualLife / (float)maxLife);

    }
    public int getLife(){
        return this.actualLife;
    }
}
