using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IApolice : MonoBehaviour
{
    // Agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;

    private float DistancePlayer;

    public Transform TargetPlayer;

    public float chaseRange = 1;

    // Animations de l'ennemi
    private Animation animations;

    private bool isDead = false;
    private Transform car;

    // Start is called before the first frame update
    void Start()
    {
        car = transform.GetChild(0);
        //agent.speed = 10;
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        TargetPlayer = GameObject.Find("Player").transform.GetChild(0);
        DistancePlayer = Vector3.Distance(TargetPlayer.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        DistancePlayer = Vector3.Distance(TargetPlayer.position, transform.position);

        if (!isDead)
        {
            if (DistancePlayer < chaseRange)
            {
                //player is dead
            }
            agent.destination = TargetPlayer.position;
        }
        if (car.GetChild(0).position.y > car.position.y)
            Dead();
        if (car.GetChild(1).position.y > car.position.y)
            Dead();
        if (car.GetChild(2).position.y > car.position.y)
            Dead();
        if (car.GetChild(3).position.y > car.position.y)
            Dead();
    }

    public void Dead()
    {
        //var Counter = GameObject.Find("Counter").GetComponent<Counter>();
        //Counter.inc_kill();
        agent.speed = 0;
        isDead = true;
        Destroy(transform.gameObject, 5);
    }
}
