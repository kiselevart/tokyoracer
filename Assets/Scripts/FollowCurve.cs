using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public BezierPath path;
    public float speed = 5f;
    public bool loop = false;

    private float t = 0f;

    void Update() {
        t += speed * Time.deltaTime / path.resolution;
        
        if (t > 1f) {
            if (loop) {
                t -= 1f;
            }
            else {
                return;
            }
        }

        Vector3 position = path.GetPoint(t);
        Vector3 tangent = path.GetTangent(t);
        transform.rotation = Quaternion.LookRotation(-tangent, Vector3.up);
        transform.position = position;
    }
}