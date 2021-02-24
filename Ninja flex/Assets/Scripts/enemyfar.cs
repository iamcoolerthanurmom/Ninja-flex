using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfar : MonoBehaviour
{
    public enemy tenemy;


    public float speed;
    public float stoppingDistance;
    public float retreadDistance;

    private float timebtwshoots;
    public float starttimebtwshoots;

    public GameObject projectile;
    public Transform player;

    public enemy enmy;
    public float maxrange;

    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timebtwshoots = starttimebtwshoots;

        enmy = FindObjectOfType<enemy>();

        
    }


    // Update is called once per frame
    void Update()
    {





       if(Vector2.Distance(transform.position, player.position) < maxrange) 
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreadDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreadDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
            if (timebtwshoots <= 0)
            {
                animator.SetTrigger("Shoot");
                Instantiate(projectile, transform.position, Quaternion.identity);
                timebtwshoots = starttimebtwshoots;
            }
            else
            {
                timebtwshoots -= Time.deltaTime;
            }
        }


        
    
    }

}
