using UnityEngine;

/// <summary>
/// Kod napsan podle tutorialu: https://youtu.be/qqOAzn05fvk, proto jsem ho radsi dal do slozky mimo
/// </summary>

public class H_IK : MonoBehaviour
{
    #region Variables

    [Header("Automatically assigned")]
    
    public int legLength;
    
    public Transform target;
    
    public Transform rotationPoint;
    
    public Transform Root;
    
    [Space]
    [Header("Manually assigned")]
    
    public Transform End;
    
    public int iterationsPerFrame = 10;
    
    public float precision = 0.001f;

    [Range(0, 1)]
    public float returnStrengthNormalized = 1f;


    protected float[] boneLengths;
    protected float length;
    protected Transform[] bones;
    protected Vector3[] joints;
    protected Vector3[] startDirections;
    protected Quaternion[] startRotations;
    protected Quaternion startRotationTarget;
    #endregion



    #region UnityMethods
    void Start()
    {
        Setup();
    }

    void LateUpdate()
    {
        IKStep();
    }
    #endregion



    #region CustomMethods
    void Setup()
    {
        bones = new Transform[legLength + 1];
        joints = new Vector3[legLength + 1];
        boneLengths = new float[legLength];
        startDirections = new Vector3[legLength + 1];
        startRotations = new Quaternion[legLength + 1];

        
        if (target == null)
        {
            target = new GameObject(gameObject.name + " Target").transform;
            SetPositionStart(target, GetPoisitionStart(transform));
        }
        startRotationTarget = GetRotationStart(target);

        Transform current = End.transform;
        length = 0;
        for (int i = bones.Length - 1; i >= 0; i--)
        {
            bones[i] = current;
            startRotations[i] = GetRotationStart(current);

            if (i == bones.Length - 1)
            {
                
                startDirections[i] = GetPoisitionStart(target) - GetPoisitionStart(current);
            }
            else
            {
                
                startDirections[i] = GetPoisitionStart(bones[i + 1]) - GetPoisitionStart(current);
                boneLengths[i] = startDirections[i].magnitude;
                length += boneLengths[i];
            }

            current = current.parent;
        }

    }

    
    private void IKStep()
    {
        if (target == null)
        {

            return;
        }

        if (boneLengths.Length != legLength)
        {

            Setup();
        }

        
        for (int i = 0; i < bones.Length; i++)
        {

            joints[i] = GetPoisitionStart(bones[i]);
        }

        Vector3 targetPos = GetPoisitionStart(target);
        Quaternion targerRot = GetRotationStart(target);
        
        if ((targetPos - GetPoisitionStart(bones[0])).sqrMagnitude >= length * length)
        {
        
            Vector3 dir = (targetPos - joints[0]).normalized;
            
            for (int i = 1; i < joints.Length; i++)
            {

                joints[i] = joints[i - 1] + dir * boneLengths[i - 1];
            }
        }
        else
        {
            for (int i = 0; i < joints.Length - 1; i++)
            {

                joints[i + 1] = Vector3.Lerp(joints[i + 1], joints[i] + startDirections[i], returnStrengthNormalized);
            }

            for (int iter = 0; iter < iterationsPerFrame; iter++)
            {
                
                for (int i = joints.Length - 1; i > 0; i--)
                {
                    if (i == joints.Length - 1)
                        joints[i] = targetPos; 
                    else
                        joints[i] = joints[i + 1] + (joints[i] - joints[i + 1]).normalized * boneLengths[i];
                }

                
                for (int i = 1; i < joints.Length; i++)
                {

                    joints[i] = joints[i - 1] + (joints[i] - joints[i - 1]).normalized * boneLengths[i - 1];
                }

                
                if ((joints[joints.Length - 1] - targetPos).sqrMagnitude < precision * precision)
                {

                    break;
                }
            }
        }
        
        if (rotationPoint != null)
        {
            Vector3 rotationPointPos = GetPoisitionStart(rotationPoint);
            for (int i = 1; i < joints.Length - 1; i++)
            {
                Plane ikPlane = new Plane(joints[i + 1] - joints[i - 1], joints[i - 1]);
                Vector3 closestPoint = ikPlane.ClosestPointOnPlane(rotationPointPos);
                Vector3 closestCurrentPoint = ikPlane.ClosestPointOnPlane(joints[i]);
                float angle = Vector3.SignedAngle(closestCurrentPoint - joints[i - 1], closestPoint - joints[i - 1], ikPlane.normal);
                joints[i] = Quaternion.AngleAxis(angle, ikPlane.normal) * (joints[i] - joints[i - 1]) + joints[i - 1];
            }
        }

        
        for (int i = 0; i < joints.Length; i++)
        {
            Quaternion finalRotation;
            if (i == joints.Length - 1)
            {
                finalRotation = Quaternion.Inverse(targerRot) * startRotationTarget * Quaternion.Inverse(startRotations[i]);
                SetRotationStart(bones[i], finalRotation);
            }
            else
            {
                finalRotation = Quaternion.FromToRotation(startDirections[i], joints[i + 1] - joints[i]) * Quaternion.Inverse(startRotations[i]);
                SetRotationStart(bones[i], finalRotation);
            }
            SetPositionStart(bones[i], joints[i]);
        }
    }

    private Quaternion GetRotationStart(Transform cur)
    {

        if (Root == null)
        {

            return cur.rotation;
        }
        else
        {

            return Quaternion.Inverse(cur.rotation) * Root.rotation;
        }
    }

    private Vector3 GetPoisitionStart(Transform cur)
    {
        if (Root == null)
        {

            return cur.position;
        }
        else
        {

            return Quaternion.Inverse(Root.rotation) * (cur.position - Root.position);
        }
    }

    private void SetPositionStart(Transform cur, Vector3 pos)
    {
        if (Root == null)
        {

            cur.position = pos;
        }
        else
        {

            cur.position = Root.rotation * pos + Root.position;
        }
    }

    

    private void SetRotationStart(Transform cur, Quaternion rot)
    {
        if (Root == null)
        {

            cur.rotation = rot;
        }
        else
        {

            cur.rotation = Root.rotation * rot;
        }
    }

    #endregion
}
