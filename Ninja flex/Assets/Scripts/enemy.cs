﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public int cuurentHealth;
    public int dead = 1;
    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        cuurentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        cuurentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (cuurentHealth <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        Debug.Log("enemy Died");

        animator.SetBool("dead", true);

        this.enabled = false;

        Destroy(GetComponent<EnemyFollow>());
        Destroy(GetComponent<enemyfar>());
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());       

        dead = 0;

    }


}
