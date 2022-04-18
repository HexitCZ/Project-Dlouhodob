using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHeadScript : MonoBehaviour
{
    [SerializeField]
    [Space]
    private Transform target;

    [SerializeField]
    [Space]
    private Transform walker;

    [SerializeField]
    [Space]
    private CannonScript cannon;

    public float speed = 0.8f;

    private float startRotation;

    private Rigidbody walker_rb;

    void Start()
    {
        startRotation = this.transform.rotation.x;
        walker_rb = walker.GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Zjisti zda je pavouk zivy 
    /// </summary>
    /// <returns></returns>
    private bool CheckIsAlive()
    {
        bool isAlive = false;
        try 
        {
            if (walker_rb.isKinematic)
            {
                isAlive = true;
            }
            else
            {
                isAlive = false;
            }
        }
        catch (UnassignedReferenceException)
        {
            isAlive = false;
        }

        return isAlive;
    }

    void Update()
    {
        if (CheckIsAlive())
        {
            PanToPlayer();
        }
    }

    /// <summary>
    /// Otaceni hlavy pavouka za hracem 
    /// Otaceni hlavy pavouka za hracem 
    /// </summary>
    private void PanToPlayer()
    {
        
        Vector3 targetDirection = target.position - transform.position;        
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        
    }
}
