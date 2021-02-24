using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyplayer : MonoBehaviour
{

    public int maxHealth = 100;
    public int cuurentHealth;

    public Transform healCheck;
    public int checkRadius;
    public LayerMask whatisheal;
    public int healvalue;

    public HealthBar healthBar;

    public Animator animator;

    public string scene;


    // Start is called before the first frame update
    void Start()
    {
        cuurentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void healing(int healvalue)
    {
        cuurentHealth += healvalue;

        healthBar.SetHealth(cuurentHealth);
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

        SceneManager.LoadScene(scene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);

            animator.SetTrigger("Heal");


            cuurentHealth += 20;
            healthBar.SetHealth(cuurentHealth);

        }
    }


}
