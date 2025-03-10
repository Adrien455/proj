using UnityEngine;
using UnityEngine.AI;


[DisallowMultipleComponent]
public class EnnemyReferences : MonoBehaviour
{

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animator;

    public float pathUpdateInterval = 0.2f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    
}
