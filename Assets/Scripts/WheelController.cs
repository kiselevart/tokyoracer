using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeftWheel;
    [SerializeField] WheelCollider frontRightWheel;
    [SerializeField] WheelCollider rearLeftWheel;
    [SerializeField] WheelCollider rearRightWheel;

    public float acceleration = 800f;
    public float brakingForce = 450f;
    public float maxTurnAngle = 20f;

    private float currentAcceleration = 0f;
    private float currentBrakingForce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate() 
    {
        HandleMotor();
        HandleSteering();
        ApplyBraking();
    }

    private void HandleMotor()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical") * -1;
        rearLeftWheel.motorTorque = currentAcceleration;
        rearRightWheel.motorTorque = currentAcceleration;
    }

    private void ApplyBraking()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S) && currentAcceleration < 0)
        {
            currentBrakingForce = brakingForce;
        }
        else
        {
            currentBrakingForce = 0f;
        }

        ApplyBrakeTorque(currentBrakingForce);
    }

    private void ApplyBrakeTorque(float brakeForce)
    {
        frontLeftWheel.brakeTorque = brakeForce;
        frontRightWheel.brakeTorque = brakeForce;
        rearLeftWheel.brakeTorque = brakeForce;
        rearRightWheel.brakeTorque = brakeForce;
    }

    private void HandleSteering()
    {
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeftWheel.steerAngle = currentTurnAngle;
        frontRightWheel.steerAngle = currentTurnAngle;
    }
}

