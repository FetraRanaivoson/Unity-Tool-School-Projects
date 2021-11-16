using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes { MouseX, MouseY }
    public RotationAxes axes = RotationAxes.MouseY;
    
    private float sensivityX = 1.5f;
    private float sensivityY = 1.5f;

    private float rotationX, rotationY;
    private float minX = -360;
    private float maxX = 360;
    private float minY = -60;
    private float maxY = 60;

    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }
    
    void Update()
    {
    }

    void LateUpdate()
    {
        HandleRotation();
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }

    void HandleRotation()
    {
        if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensivityX;
            rotationX = ClampAngle(rotationX, minX, maxX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        
        if (axes == RotationAxes.MouseY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensivityY;
            rotationY = ClampAngle(rotationY, minY, maxY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }
}
