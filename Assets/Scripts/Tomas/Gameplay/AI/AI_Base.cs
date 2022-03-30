using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Base : MonoBehaviour, IHittable
{
    [field: SerializeField] protected Transform target { get; set; }
    [field: SerializeField] protected bool dynamic { get; set; }
    [field: SerializeField] protected AI_Projectile_Weapon weapon { get; set; }

    public bool isAlive { get { return CheckHealth(); } }
    [SerializeField] protected bool isVisible { get { return CheckVisibility(); } }
    [SerializeField] protected bool inRange { get { return CheckRange(); } }
    
    [field: SerializeField] public float health { get; set; }
    [field: SerializeField] protected int range { get; set; }
    [field: SerializeField] protected int startSpeed { get; set; }
    [field: SerializeField] protected float targetDistance { get; set; }
    [field: SerializeField] protected float maximumDistance { get; set; }
    [field: SerializeField] protected Vector3 targetDirection { get; set; }

    [field: SerializeField] protected Action preUpdateAction { get; set; }
    [field: SerializeField] protected Action postUpdateAction { get; set; }
    [field: SerializeField] protected Action visibleAction { get; set; }
    [field: SerializeField] protected Action inRangeAction { get; set; }



    protected NavMeshAgent navmesh;


    

    protected void Start()
    {
        if (dynamic)
        {
            navmesh = gameObject?.GetComponent<NavMeshAgent>();
            if (navmesh == null)
            {
                navmesh = gameObject.transform.GetChild(0).GetComponent<NavMeshAgent>();
                navmesh.speed = startSpeed;
            }
        }
    }

    protected void Update()
    {
        preUpdateAction?.Invoke();

        if (isAlive)
        {
            targetDistance = Vector3.Distance(target.position, this.transform.position);
            targetDirection = -(this.transform.position - target.position).normalized;
            Debug.DrawRay(this.transform.position, targetDirection, Color.red,0.2f);
            if (dynamic)
            {
                SetDestination(target);
                
                if(targetDistance < maximumDistance)
                {
                    navmesh.speed = Mathf.Lerp(navmesh.speed, 0, navmesh.acceleration / 10);
                }
                else
                {
                    navmesh.speed = Mathf.Lerp(navmesh.speed, startSpeed, navmesh.acceleration / 10);
                }

            }

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
        ///print("setDestination");
        navmesh.destination = destination.position;
        
    }
    public virtual void GetHit()
    {
        Debug.Log(gameObject.name + " HIT");
    }

    protected virtual bool CheckHealth()
    {
        return health > 0;
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

    /// <summary>
    /// Should end up with disabling this gameobject.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    protected virtual void Death()
    {

        throw new NotImplementedException(); 
    }



}
