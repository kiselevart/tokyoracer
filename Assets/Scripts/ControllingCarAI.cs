using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllingCarAI : MonoBehaviour
{
    public CarAI carAI;
    [SerializeField] private Transform destinationTransform;

    void Start()
    {
        InitializeCarSettings();
        MoveCarToCustomDestination();
    }

    void InitializeCarSettings()
    {
        carAI.Patrol = false;
        carAI.MaxSteeringAngle = 45;
        carAI.MaxRPM = 150;
        carAI.ShowGizmos = false;
        carAI.move = true;
    }

    void MoveCarToCustomDestination()
    {
        carAI.CustomPath(destinationTransform);
    }
}