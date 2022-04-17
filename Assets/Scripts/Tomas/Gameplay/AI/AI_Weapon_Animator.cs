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


    /// <summary>
    /// Math.
    /// </summary>
    void Update()
    {
        Vector3 playerDirection = (X.transform.position - target.transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(playerDirection, transform.up);
        yRot = (Quaternion.Euler(Vector3.Scale(Ymask, lookRot.eulerAngles)));
        xRot = (Quaternion.Euler(Vector3.Scale(Xmask, lookRot.eulerAngles)));
        Y.transform.rotation = Quaternion.Slerp(Y.transform.rotation, yRot, 0.025f);
        X.transform.rotation = Quaternion.Slerp(X.transform.rotation, xRot, 0.025f);
        
        
    }
}
