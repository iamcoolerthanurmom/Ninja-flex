using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public float minDistance;
    public float maxDistance;


    float nextAttackTime = 0f;
    public int atk;
    public float attackRange = 2f;
    public float attackrate = 2f;

    public Transform Attackpointenemy;
    public LayerMask enemyLayers;


    public Transform that;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minDistance & Vector2.Distance(transform.position, target.position) < maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target.position) > minDistance + 1)
        {
            
        }
        else
        {
            
        }

        
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackrate;
            }
        
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






