using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Weapon_Animator : MonoBehaviour
{
    public GameObject Y;
    public Vector3 Ymask;
    public GameObject X;
    public Vector3 Xmask;
    public GameObject target;
    public Quaternion yRot;
    public Quaternion xRot;

    void Update()
    {
        Vector3 playerDirection = (target.transform.position - this.transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(playerDirection, Vector3.up);
        yRot = lookRot;
        xRot = lookRot;
        //Y.transform.rotation = Quaternion.Slerp(Y.transform.rotation, yRot, 0.025f);
        X.transform.rotation = Quaternion.Slerp(X.transform.rotation, xRot, 0.025f);
        
        
    }
}
