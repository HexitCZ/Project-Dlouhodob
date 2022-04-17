using UnityEngine;


public class H_IK : MonoBehaviour
{
    [HideInInspector]
    public int legLength;
    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public Transform rotationPoint;
    [HideInInspector]
    public Transform Root;
    
    public Transform End;

    [HideInInspector]
    public int iterationsPerFrame = 10;
    [HideInInspector]
    public float precision = 0.001f;

    [HideInInspector]
    [Range(0, 1)]
    public float returnStrength = 1f;


    protected float[] boneLengths;
    protected float length;
    protected Transform[] bones;
    protected Vector3[] joints;
    protected Vector3[] startDirections;
    protected Quaternion[] startRotations;
    protected Quaternion startRotationTarget;


    void Start()
    {
        Setup();
    }

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

    void LateUpdate()
    {
        ResolveIK();
    }

    private void ResolveIK()
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

        Vector3 targetPosition = GetPoisitionStart(target);
        Quaternion targetRotation = GetRotationStart(target);

        
        if ((targetPosition - GetPoisitionStart(bones[0])).sqrMagnitude >= length * length)
        {
        
            Vector3 direction = (targetPosition - joints[0]).normalized;
            
            for (int i = 1; i < joints.Length; i++)
            {

                joints[i] = joints[i - 1] + direction * boneLengths[i - 1];
            }
        }
        else
        {
            for (int i = 0; i < joints.Length - 1; i++)
            {

                joints[i + 1] = Vector3.Lerp(joints[i + 1], joints[i] + startDirections[i], returnStrength);
            }

            for (int iteration = 0; iteration < iterationsPerFrame; iteration++)
            {
                
                for (int i = joints.Length - 1; i > 0; i--)
                {
                    if (i == joints.Length - 1)
                        joints[i] = targetPosition; 
                    else
                        joints[i] = joints[i + 1] + (joints[i] - joints[i + 1]).normalized * boneLengths[i];
                }

                
                for (int i = 1; i < joints.Length; i++)
                {

                    joints[i] = joints[i - 1] + (joints[i] - joints[i - 1]).normalized * boneLengths[i - 1];
                }

                
                if ((joints[joints.Length - 1] - targetPosition).sqrMagnitude < precision * precision)
                {

                    break;
                }
            }
        }

        
        if (rotationPoint != null)
        {
            Vector3 polePosition = GetPoisitionStart(rotationPoint);
            for (int i = 1; i < joints.Length - 1; i++)
            {
                Plane ikPlane = new Plane(joints[i + 1] - joints[i - 1], joints[i - 1]);
                Vector3 closestPoint = ikPlane.ClosestPointOnPlane(polePosition);
                Vector3 closestCurrentPoint = ikPlane.ClosestPointOnPlane(joints[i]);
                float angle = Vector3.SignedAngle(closestCurrentPoint - joints[i - 1], closestPoint - joints[i - 1], ikPlane.normal);
                joints[i] = Quaternion.AngleAxis(angle, ikPlane.normal) * (joints[i] - joints[i - 1]) + joints[i - 1];
            }
        }

        
        for (int i = 0; i < joints.Length; i++)
        {
            if (i == joints.Length - 1)
            {

                SetRotationStart(bones[i], Quaternion.Inverse(targetRotation) * startRotationTarget * Quaternion.Inverse(startRotations[i]));
            }
            else
            {

                SetRotationStart(bones[i], Quaternion.FromToRotation(startDirections[i], joints[i + 1] - joints[i]) * Quaternion.Inverse(startRotations[i]));
            }
            SetPositionStart(bones[i], joints[i]);
        }
    }

    private Vector3 GetPoisitionStart(Transform current)
    {
        if (Root == null)
        {

            return current.position;
        }
        else
        {

            return Quaternion.Inverse(Root.rotation) * (current.position - Root.position);
        }
    }

    private void SetPositionStart(Transform current, Vector3 position)
    {
        if (Root == null)
        {

            current.position = position;
        }
        else
        {

            current.position = Root.rotation * position + Root.position;
        }
    }

    private Quaternion GetRotationStart(Transform current)
    {
        
        if (Root == null)
        {

            return current.rotation;
        }
        else
        {

            return Quaternion.Inverse(current.rotation) * Root.rotation;
        }
    }

    private void SetRotationStart(Transform current, Quaternion rotation)
    {
        if (Root == null)
        {

            current.rotation = rotation;
        }
        else
        {

            current.rotation = Root.rotation * rotation;
        }
    }
    
}
