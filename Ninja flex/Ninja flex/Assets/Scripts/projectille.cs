using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectille : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    bool attack = false;

    public int atk;
    public LayerMask enemyLayers;
    public Transform Attackpointenemy;
    public float attackRange = 2f;

    public enemy enmy;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }


    void Update()
    {
        enmy = FindObjectOfType<enemy>();


        if (enmy.cuurentHealth > 0)
        {

            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


            if (transform.position.x == target.x && transform.position.y == target.y)
            {

                Attack();
                DestroyProjectile();
            }
        }


    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();

            attack = true;

            Attack();

        }
        else if (other.CompareTag("Ground"))
        {
            DestroyProjectile();
        }
    }

 





    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpointenemy.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemyplayer>().TakeDamage(atk);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (Attackpointenemy == null)
            return;

        Gizmos.DrawWireSphere(Attackpointenemy.position, attackRange);
    }
}
