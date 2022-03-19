using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector3 cam_Rotation;
    private BodyData bodyData;
    private CameraData cameraData;

    private Vector3 fromBodyToCameraDistance;

    private GameObject cameraPivot;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        bodyData = transform.parent.GetComponent<BodyData>();
        cameraData = transform.parent.GetComponent<CameraData>();
        cam_Rotation = transform.rotation.eulerAngles;
        
    }

    private void Start()
    {
        cameraPivot = bodyData.head;
        fromBodyToCameraDistance = gameObject.transform.position - cameraPivot.transform.position;
    }

    void Update()
    {
        MoveCamera();

        bodyData.yRotation = gameObject.transform.eulerAngles.y;

        RotateCamera();



    }

    private void MoveCamera()
    {

        switch (bodyData.inputState)
        {

            case BodyData.EInputState.NULL:
            case BodyData.EInputState.WALK:
                bodyData.head.SetActive(true);
                cameraPivot = bodyData.head;
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPivot.transform.position + fromBodyToCameraDistance, 0.15f);
                break;

            case BodyData.EInputState.SPRINT:
                bodyData.head.SetActive(true);
                cameraPivot = bodyData.head;
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPivot.transform.position + fromBodyToCameraDistance, 0.15f);
                break;

            case BodyData.EInputState.CROUCH:
            case BodyData.EInputState.CROUCHSPRINT:
                bodyData.head.SetActive(false);
                cameraPivot = bodyData.body;
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPivot.transform.position + fromBodyToCameraDistance, 0.15f);

                bodyData.physicState = BodyData.EPhysicState.CROUCHING;
                break;

            case BodyData.EInputState.JUMP:
                if (bodyData.inputState == BodyData.EInputState.CROUCH && bodyData.crouchJump || bodyData.inputState == BodyData.EInputState.CROUCHSPRINT && bodyData.crouchJump)
                {
                    bodyData.body.SetActive(true);
                    cameraPivot = bodyData.body;
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPivot.transform.position + fromBodyToCameraDistance, 0.15f);
                }
                else
                {
                    bodyData.head.SetActive(true);
                    cameraPivot = bodyData.head;
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameraPivot.transform.position + fromBodyToCameraDistance, 0.15f);
                }
                break;

            default:

                break;
        }




    }

    private void RotateCamera()
    {
        cam_Rotation.x = Mathf.Clamp(cam_Rotation.x, cameraData.minX, cameraData.maxX);

        switch (cameraData.cameraEffect)
        {
            case CameraData.ECameraEffect.NO_EFFECT:
                transform.rotation = Quaternion.Euler(cam_Rotation.x, cam_Rotation.y, 0);
                break;
            case CameraData.ECameraEffect.DRUNK_CAMERA:
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(cam_Rotation.x, cam_Rotation.y, 0), transform.rotation, cameraData.effectAmount);
                break;
            default:
                break;
        }

    }



    public void OnMouseDelta(InputAction.CallbackContext delta)
    {
        cam_Rotation.x -= delta.ReadValue<Vector2>().y * cameraData.sensitivity;
        cam_Rotation.y += delta.ReadValue<Vector2>().x * cameraData.sensitivity;
    }

}