using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    #region Variables
    private NavMeshAgent agent;
    public Transform target;
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}


 
    

   
