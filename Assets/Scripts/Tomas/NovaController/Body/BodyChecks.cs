using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyChecks : MonoBehaviour
{
    private BodyData bodyData;
    //private CameraData cameraData;

    private Vector3 groundCheckPos;
    private Vector3 crouchCheckPos;

    private float groundCheckRadius;
    private float crouchCheckRadius;

    public Collider[] ground;
    public Collider[] crouch;

    //Radius of overlapSpheres is determined by spherecolliders radius + 0.5f
    //Position is determined by position of gameobjects +/- 0.1

    private void Awake()
    {
        bodyData = transform.parent.GetComponent<BodyData>();

        
    }

    private void Start()
    {
        groundCheckRadius = bodyData.body.GetComponent<SphereCollider>().radius - 0.1f;
        crouchCheckRadius = bodyData.head.GetComponent<SphereCollider>().radius - 0.1f;
    }


    private void FixedUpdate()
    {
        groundCheckPos = bodyData.body.transform.position;
        crouchCheckPos = bodyData.head.transform.position;

        groundCheckPos.y -= 0.2f;
        crouchCheckPos.y += 0.2f;

        if(Physics.OverlapSphere(groundCheckPos, groundCheckRadius, bodyData.ground).Length > 0)
        {
            bodyData.onGround = true;
        }
        else
        {
            bodyData.onGround = false;
        }

        if (Physics.OverlapSphere(crouchCheckPos, crouchCheckRadius, bodyData.ceiling).Length > 0)
        {
            bodyData.belowCeil = true;
            
        }
        else
        {
            bodyData.belowCeil = false;

        }
    }

    private void OnDrawGizmos()
    {
        if (transform.parent.GetComponent<BodyData>().showChecks)
        {
            Gizmos.DrawSphere(groundCheckPos, groundCheckRadius);
            Gizmos.DrawSphere(crouchCheckPos, crouchCheckRadius);
        }
    }
}
