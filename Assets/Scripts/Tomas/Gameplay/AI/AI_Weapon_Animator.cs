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
        yRot = Quaternion.Euler(Vector3.Scale(Ymask, (Quaternion.LookRotation((this.transform.position - target.transform.position).normalized, Vector3.up).eulerAngles)));
        xRot = Quaternion.Euler(Vector3.Scale(Xmask, (Quaternion.LookRotation((this.transform.position - target.transform.position).normalized, Vector3.up).eulerAngles)));
        Y.transform.rotation = Quaternion.Slerp(Y.transform.rotation, yRot, 0.025f);
        X.transform.rotation = Quaternion.Slerp(X.transform.rotation, xRot, 0.025f);
        
        
    }
}
