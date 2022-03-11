using UnityEngine;

public class BodyData : MonoBehaviour
{
    [HideInInspector]
    public float yRotation;

    [Tooltip("Player normal speed.")]
    public float speed;

    [Tooltip("Player crouch speed.")]
    public float crouchSpeed;

    [Tooltip("Player sprint speed.")]
    public float sprintSpeed;

    [Tooltip("Speeds up acceleration.")]
    public float accelerationSpeed;
    
    [Tooltip("How fast will body deaccelerate.")]
    public float deaccelerationSpeed;

    [Tooltip("How fast will body deaccelerate while couching. Can be used for crouch sliding.")]
    public float crouchDeaccelerationSpeed;
    public EDeaccelerationSpeedInAir deaccelerationSpeedInAir;
    
    [Tooltip("Force of jump")]
    public float jumpForce;
    
    [Space]
    
    [Tooltip("Time required to set physics state to falling long.")]
    public float timeToFallAnim;

    [Space]
    public LayerMask ground;
    [Space]
    public LayerMask ceiling;

    [HideInInspector]
    public GameObject body;
    [HideInInspector]
    public GameObject head;

    
    public bool onGround;
    
    public bool belowCeil;
    

    [Space]
    [Header("Functions")]
    public bool crouchSprint;
    public bool crouchJump;
    public bool crouchInAir;
    [Space]
    public EDoubleJump doubleJump;
    public int multiJumpAmount;
    [Space]
    public EAirControl airControl;
    public EPhysicState physicState;
    public EInputState inputState;

    [Space]
    [Header("Debug")]
    public bool showChecks;


    public enum EAirControl
    {
        NONE,
        CROUCH_AIR_CONTROL,
        WALK_AIR_CONTROL,
        SPRINT_AIR_CONTROL
    }

    public enum EPhysicState
    {
        STANDING,
        WALKING,
        RUNNING,
        CROUCHING,
        LAYING,
        FALLING_SHORT,
        FALLING_LONG
    }

    public enum EInputState
    {
        NULL,
        WALK,
        SPRINT,
        CROUCH,
        JUMP,
        CROUCHSPRINT
    }

    

    public enum EDoubleJump
    {
        NONE,
        TIME_LIMITED_DOUBLE_JUMP,
        REGULAR_DOUBLE_JUMP,
        MULTI_JUMP
    }

    public enum EDeaccelerationSpeedInAir
    {
        NORMAL_DEACCELERATION = 1,
        HALF_DEACCELERATION = 2,
        QUARTER_DEACCELERATION = 4,
        NO_DEACCELERATION = 1000
    }
}
