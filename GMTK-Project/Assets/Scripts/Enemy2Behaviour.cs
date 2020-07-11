using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Behaviour : MonoBehaviour
{
    public GameObject player;
    public float dist;
    public NavMeshAgent agent;

    public float stopDistance = 5;

    public Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Find distance between player and demon
        Vector3 dif = this.transform.position - player.transform.position;
        dist = dif.magnitude; 

        if(dist > 3)
        {
            //Move closer
            Vector3 target = player.transform.position + ((Vector3)Random.insideUnitCircle.normalized * stopDistance); 

            agent.SetDestination(target); 
        }

        //Decide whether to shoot 
        int brain = Random.Range(0, 100);

        if(brain > 70)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
}
