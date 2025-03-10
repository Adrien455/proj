using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MobBehaviour : MonoBehaviour
{
    public Transform target;

    private EnnemyReferences ennemyReferences;
    
    public float attackDistance;

    private float pathUpdateDeadline;
    
    public float detectionRadius;

    private void Awake()
    {
        ennemyReferences = GetComponent<EnnemyReferences>();
        pathUpdateDeadline = 0;
    }

    void Start()
    {
        attackDistance = ennemyReferences.agent.stoppingDistance;
    }
    void Update()
    {
        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= attackDistance;

            if (inRange)
            {
                LookAtTarget();
                Attack();
            }
            else UpdatePath();
        }
    }
    
    void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadline)
        {
            Debug.Log("Updating Path");
            pathUpdateDeadline = Time.time + ennemyReferences.pathUpdateInterval;

            if (Vector3.Distance(transform.position, target.position) <= detectionRadius)
            {
                Debug.Log("Target in Range");
                ennemyReferences.agent.SetDestination(target.position);
            }
            else
            {
                float randomX = Random.Range(-5f, 5f);
                float randomZ = Random.Range(-5f, 5f);
                
                ennemyReferences.agent.SetDestination(new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ));
            }
        }
    }

    void Attack()
    {
        
    } 
}
