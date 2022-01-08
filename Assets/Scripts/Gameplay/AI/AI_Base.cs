using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Base : MonoBehaviour
{
    [field: SerializeField] protected Transform target { get; set; }

    [SerializeField] protected bool isAlive { get { return CheckHealth(); } }
    [SerializeField] protected bool isVisible { get { return CheckVisibility(); } }
    [SerializeField] protected bool inRange { get { return CheckRange(); } }
    
    [field: SerializeField] protected int health { get; set; }
    [field: SerializeField] protected int range { get; set; }

    [field: SerializeField] protected Action preUpdateAction { get; set; }
    [field: SerializeField] protected Action postUpdateAction { get; set; }
    [field: SerializeField] protected Action visibleAction { get; set; }
    [field: SerializeField] protected Action inRangeAction { get; set; }



    protected NavMeshAgent navmesh;



    protected void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    protected void Update()
    {
        preUpdateAction?.Invoke();

        if (isAlive)
        {
            SetDestination(target);

            if (isVisible)
            {
                visibleAction?.Invoke();

                if (inRange)
                {
                    inRangeAction?.Invoke();
                
                    Attack();
                }
            }
        }
        else
        {
            Death();
        }

        postUpdateAction?.Invoke();
    }


    protected virtual void SetDestination(Transform destination)
    {
        print("setDestination");
        navmesh.destination = destination.position;
    }

    protected virtual bool CheckHealth()
    {
        throw new NotImplementedException();
    }


    protected virtual bool CheckVisibility()
    {
        throw new NotImplementedException();
    }

    protected virtual bool CheckRange()
    {
        throw new NotImplementedException();
    }

    protected virtual void Attack()
    {
        throw new NotImplementedException();
    }

    protected virtual void Death()
    {
        throw new NotImplementedException();
    }



}
