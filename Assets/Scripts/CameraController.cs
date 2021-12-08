using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [Header("Camera Controls")]public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 desiredPosition;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        //============================================SMOOTHED CAMERA FOLLOW======================================//
        //This smooths the camera movement using linear interpolation based off of player position against desired position
        Vector3 targetPos = target.position;
        desiredPosition = targetPos;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition + offset, smoothSpeed);
        // makes the camera use the smoothedPosition Vector
        transform.position = smoothedPosition;
    }
}
