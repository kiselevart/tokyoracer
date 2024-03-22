using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCurve : MonoBehaviour
{
    public HermiteSpline spline;
    public float speed = 20000f;

    private float t = 0f;

    void Update()
    {
        t += speed * Time.deltaTime / spline.resolution;
        t = Mathf.Clamp01(t);
        Vector3 targetPosition = spline.GetPoint(t);
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

        Vector3 tangent = EstimateTangent();
        transform.rotation = Quaternion.LookRotation(-tangent, Vector3.up);
        if (t >= 1f) { return; }
    }

    private Vector3 EstimateTangent()
    {
        float delta = 0.1f;
        float tPlusDelta = Mathf.Clamp01(t + delta);
        float tMinusDelta = Mathf.Clamp01(t - delta);

        Vector3 posPlusDelta = spline.GetPoint(tPlusDelta);
        Vector3 posMinusDelta = spline.GetPoint(tMinusDelta);

        return (posPlusDelta - posMinusDelta).normalized;
    }
}