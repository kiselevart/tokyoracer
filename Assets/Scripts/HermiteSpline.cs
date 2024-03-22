using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermiteSpline : MonoBehaviour
{
    public Transform[] controlPoints;
    public int resolution = 2000;

    private Vector3[] pathPoints;

    void Start()
    {
        GeneratePath();
    }

    void GeneratePath()
    {
        int numPoints = controlPoints.Length;
        int totalPoints = numPoints * resolution;
        pathPoints = new Vector3[totalPoints];

        for (int i = 0; i < numPoints; i++)
        {
            Vector3 p0 = controlPoints[Mathf.Max(i - 1, 0)].position;
            Vector3 p1 = controlPoints[i].position;
            Vector3 p2 = controlPoints[Mathf.Min(i + 1, numPoints - 1)].position;
            Vector3 p3 = controlPoints[Mathf.Min(i + 2, numPoints - 1)].position;

            for (int j = 0; j < resolution; j++)
            {
                float t = j / (float)(resolution - 1);
                pathPoints[i * resolution + j] = CalculateCatmullRom(p0, p1, p2, p3, t);
            }
        }
    }

    Vector3 CalculateCatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float t2 = t * t;
        float t3 = t2 * t;
        float tension = 0.2f;

        Vector3 m0 = 0.5f * ((p2 - p0) + tension * (p2 - p1));
        Vector3 m1 = 0.5f * ((p3 - p1) + tension * (p3 - p2));

        float h1 = 2 * t3 - 3 * t2 + 1;
        float h2 = -2 * t3 + 3 * t2;
        float h3 = t3 - 2 * t2 + t;
        float h4 = t3 - t2;

        return h1 * p1 + h2 * p2 + h3 * m0 + h4 * m1;
    }

    public Vector3 GetPoint(float t)
    {
        t = Mathf.Clamp01(t);
        int index = Mathf.FloorToInt(t * (pathPoints.Length - 1));
        return pathPoints[index];
    }

    void OnDrawGizmos()
    {
        if (pathPoints == null || pathPoints.Length < 2)
            return;

        Gizmos.color = Color.green;

        for (int i = 0; i < pathPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(pathPoints[i], pathPoints[i + 1]);
        }
    }
}
