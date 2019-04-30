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
    int minDist = 5;
    int MoveSpeed = 5;
    public GameObject player;

    bool chase = false;
     private Vector3 smoothVelocity = Vector3.zero;
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
            player.GetComponent<PlayerController>().AddScore(1);
            Destroy(this.gameObject);

        }
        timer += Time.deltaTime;

       

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < minDist )
        {
            transform.LookAt(player.transform);
             transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref smoothVelocity, wanderTimer);
        }
        else
        {
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }

        
    }

    void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            col.gameObject.GetComponent<PlayerController>().TakeHealth(1);
            
        }
       // this.transform.SetParent(col.transform);
    }
}
