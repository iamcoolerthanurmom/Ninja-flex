using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyplayer : MonoBehaviour
{

    public int maxHealth = 100;
    int cuurentHealth;


    // Start is called before the first frame update
    void Start()
    {
        cuurentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        cuurentHealth -= damage;

        if (cuurentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy Died");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        SceneManager.LoadScene("Main");


    }


}
