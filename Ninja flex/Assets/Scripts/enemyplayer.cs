using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyplayer : MonoBehaviour
{

    public int maxHealth = 100;
    public int cuurentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        cuurentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        cuurentHealth -= damage;

        if (cuurentHealth <= 0)
        {
            Die();
        }

        healthBar.SetHealth(cuurentHealth);
    }

    void Die()
    {
        Debug.Log("enemy Died");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        SceneManager.LoadScene("Main");
    }


}
