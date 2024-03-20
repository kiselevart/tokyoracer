using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeftWheel;
    [SerializeField] WheelCollider frontRightWheel;
    [SerializeField] WheelCollider rearLeftWheel;
    [SerializeField] WheelCollider rearRightWheel;

    public float acceleration = 800f;
    public float breakingForce = 450f;
    public float maxTurnAngle = 20f;
    
    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate() {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space)) {
            currentBreakingForce = breakingForce;
        }
        else {
            currentBreakingForce = 0f;
        }

        frontLeftWheel.motorTorque = currentAcceleration;
        frontRightWheel.motorTorque = currentAcceleration;

        frontLeftWheel.brakeTorque = currentBreakingForce;
        frontRightWheel.brakeTorque = currentBreakingForce;
        rearLeftWheel.brakeTorque = currentBreakingForce;
        rearRightWheel.brakeTorque = currentBreakingForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeftWheel.steerAngle = currentTurnAngle;
        frontRightWheel.steerAngle = currentTurnAngle;

    }
}

