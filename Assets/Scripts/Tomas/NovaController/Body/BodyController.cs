using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BodyController : MonoBehaviour
{
    private BodyData bodyData;
    private Rigidbody rb;

    private Vector3 headToBodyDistance;

    private Vector3 velocity;
    private Vector3 input;
    private float curSpeed;

    private float curSpeedMag;

    private bool crouching;

    private bool sprinitng;

    private bool jumping;

    private float timeToLongFall;

    private bool jumped;

    private bool secondjumped;

    private int multiJump;

    private void Awake()
    {
        bodyData = transform.parent.GetComponent<BodyData>();
        bodyData.body = this.gameObject;
        bodyData.head = transform.GetChild(0).gameObject;

        headToBodyDistance = bodyData.head.transform.position - bodyData.body.transform.position;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        TranslateBody();
        JumpRB();
        MoveRB();

    }

    private void Update()
    {
        curSpeedMag = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;

        ResolveInputState();
        ResolvePhysicsState();


        if (bodyData.belowCeil)
        {
            //keep crouching
        }
        else
        {
            
        }

    }

    #region Transform
    private void TranslateBody()
    {
        transform.rotation = Quaternion.Euler(0, bodyData.yRotation, 0);
        bodyData.head.transform.position = bodyData.body.transform.position + headToBodyDistance;
    }
    #endregion

    #region Physics
    private void MoveRB()
    {

        if (input != Vector3.zero && bodyData.onGround || input != Vector3.zero && bodyData.airControl != BodyData.EAirControl.NONE)
        {
            velocity = new Vector3(input.x * curSpeed, 0, input.y * curSpeed);
            rb.AddRelativeForce(velocity * bodyData.accelerationSpeed, ForceMode.Acceleration);

            Vector2 rbSpeed = Vector2.ClampMagnitude(new Vector2(rb.velocity.x, rb.velocity.z), curSpeed);
            rb.velocity = new Vector3(rbSpeed.x, rb.velocity.y, rbSpeed.y);
        }
        else
        {
            if (bodyData.onGround)
            {
                if (bodyData.inputState == BodyData.EInputState.CROUCH)
                {
                    rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, rb.velocity.y, 0), bodyData.crouchDeaccelerationSpeed);

                }
                else
                {
                    rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, rb.velocity.y, 0), bodyData.deaccelerationSpeed);

                }
            }
            else
            {
                rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, rb.velocity.y, 0), bodyData.deaccelerationSpeed / (int) bodyData.deaccelerationSpeedInAir);
            }
            
        }     


    }

    private void JumpRB()
    {
        if (jumping && bodyData.inputState != BodyData.EInputState.CROUCH || jumping && bodyData.crouchJump && (bodyData.inputState == BodyData.EInputState.CROUCH || bodyData.inputState == BodyData.EInputState.CROUCHSPRINT))
        {

            if (!jumped && bodyData.onGround)
            {
                jumped = true;
                rb.AddRelativeForce(new Vector3(0, bodyData.jumpForce, 0), ForceMode.Impulse);
            }
            else if (bodyData.doubleJump == BodyData.EDoubleJump.TIME_LIMITED_DOUBLE_JUMP && bodyData.physicState == BodyData.EPhysicState.FALLING_SHORT && !secondjumped)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddRelativeForce(new Vector3(0, bodyData.jumpForce, 0), ForceMode.Impulse);
                secondjumped = true;
            }
            else if (bodyData.doubleJump == BodyData.EDoubleJump.REGULAR_DOUBLE_JUMP && !secondjumped)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddRelativeForce(new Vector3(0, bodyData.jumpForce, 0), ForceMode.Impulse);
                secondjumped = true;
            }
            else if (bodyData.doubleJump == BodyData.EDoubleJump.MULTI_JUMP && multiJump < bodyData.multiJumpAmount)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddRelativeForce(new Vector3(0, bodyData.jumpForce, 0), ForceMode.Impulse);
                multiJump++;
            }
            
            jumping = false;

        }
    }
    
    #endregion

    #region Other
    
    private void ResolveInputState()
    {
        if(crouching && sprinitng && bodyData.crouchSprint)
        {
            bodyData.inputState = BodyData.EInputState.CROUCHSPRINT;
            curSpeed = bodyData.speed;
        }
        else if (crouching && bodyData.onGround || crouching && !bodyData.onGround && bodyData.crouchInAir)    //Crouch
        {
            bodyData.inputState = BodyData.EInputState.CROUCH;

            curSpeed = bodyData.crouchSpeed;
        }
        else if (jumping)   //Jump
        {
            bodyData.inputState = BodyData.EInputState.JUMP;
        }
        else if (sprinitng && bodyData.onGround || sprinitng && bodyData.airControl == BodyData.EAirControl.SPRINT_AIR_CONTROL)    //Sprint
        {
            bodyData.inputState = BodyData.EInputState.SPRINT;
            
            curSpeed = bodyData.sprintSpeed;
        }
        else if(input != Vector3.zero)
        {
            bodyData.inputState = BodyData.EInputState.WALK;

            if (bodyData.onGround && bodyData.inputState == BodyData.EInputState.CROUCH || bodyData.airControl == BodyData.EAirControl.CROUCH_AIR_CONTROL && !bodyData.onGround)
            {
                curSpeed = bodyData.crouchSpeed;
            }
            else if (bodyData.onGround || bodyData.airControl == BodyData.EAirControl.WALK_AIR_CONTROL && !bodyData.onGround)
            {
                curSpeed = bodyData.speed;
            }
            
        }
        else
        {
            bodyData.inputState = BodyData.EInputState.NULL;
            curSpeed = 0.0f;
        }
        
    }

    private void ResolvePhysicsState()
    {
        if (bodyData.onGround)
        {
            timeToLongFall = bodyData.timeToFallAnim;
            bodyData.physicState = BodyData.EPhysicState.STANDING;

            if (rb.velocity.magnitude > 1 && rb.velocity.magnitude < bodyData.sprintSpeed && bodyData.inputState != BodyData.EInputState.NULL)
            {
                bodyData.physicState = BodyData.EPhysicState.WALKING;
            }
            else if (rb.velocity.magnitude > bodyData.sprintSpeed)
            {
                bodyData.physicState = BodyData.EPhysicState.RUNNING;
            }
            multiJump = 0;
            jumped = false;
            secondjumped = false;
        }
        else if(timeToLongFall > 0)
        {
            timeToLongFall -= Time.fixedDeltaTime;
            bodyData.physicState = BodyData.EPhysicState.FALLING_SHORT;
        }
        else
        {
            bodyData.physicState = BodyData.EPhysicState.FALLING_LONG;
        }
    }

    #endregion




    #region Input


    public void OnMovement(InputAction.CallbackContext input)
    {
        this.input = input.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            this.jumping = true;
        }
        else if(input.canceled)
        {
            this.jumping = false;
        }
        
    }

    public void OnCrouch(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            this.crouching = true;
        }
        else if (input.canceled)
        {
            this.crouching = false;
        }
    }
    
    public void OnSprint(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            this.sprinitng = true;
        }
        else if (input.canceled)
        {
            this.sprinitng = false;
        }
    }

    #endregion
}
