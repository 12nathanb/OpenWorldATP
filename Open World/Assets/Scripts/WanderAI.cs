using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WanderAI : MonoBehaviour {

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    public NavMeshAgent agent;
    private float timer;

    public float Health = 5;
    int minDist = 10;
    int MoveSpeed = 5;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

 
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        if(Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {
             transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        this.transform.SetParent(col.transform);
    }
}
