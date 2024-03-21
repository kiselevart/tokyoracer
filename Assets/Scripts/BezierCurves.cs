using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierPath : MonoBehaviour
{
    public Transform[] controlPoints;
    public int resolution = 10;

    private Vector3[] pathPoints;

    void Start()
    {
        GeneratePath();
    }

    void GeneratePath()
    {
        pathPoints = new Vector3[resolution];
        
        for (int i = 0; i < resolution; i++)
        {
            float t = i / (float)(resolution - 1);
            pathPoints[i] = CalculateBezierPoint(t, controlPoints);
        }
    }

    Vector3 CalculateBezierPoint(float t, Transform[] points)
    {
        int numPoints = points.Length;
        Vector3[] p = new Vector3[numPoints];
        
        for (int i = 0; i < numPoints; i++)
        {
            p[i] = points[i].position;
        }
        
        for (int j = 1; j < numPoints; j++)
        {
            for (int i = 0; i < numPoints - j; i++)
            {
                p[i] = Vector3.Lerp(p[i], p[i + 1], t);
            }
        }
        
        return p[0];
    }

    Vector3 CalculateTangent(float t, Transform[] points)
    {
        int numPoints = points.Length;
        Vector3[] p = new Vector3[numPoints];
        
        for (int i = 0; i < numPoints; i++)
        {
            p[i] = points[i].position;
        }
        
        for (int j = 1; j < numPoints - 1; j++)
        {
            for (int i = 0; i < numPoints - j; i++)
            {
                p[i] = Vector3.Lerp(p[i], p[i + 1], t);
            }
        }
        
        return (p[1] - p[0]).normalized;
    }

    void OnDrawGizmos()
    {
        if (controlPoints.Length < 2)
            return;

        Gizmos.color = Color.green;

        for (int i = 0; i < resolution - 1; i++)
        {
            Gizmos.DrawLine(pathPoints[i], pathPoints[i + 1]);
        }
    }

    public Vector3 GetPoint(float t)
    {
        int i = Mathf.FloorToInt(t * (resolution - 1));
        return pathPoints[i];
    }

    public Vector3 GetTangent(float t)
    {
        int i = Mathf.FloorToInt(t * (resolution - 1));
        return CalculateTangent(t, controlPoints);
    }
}
