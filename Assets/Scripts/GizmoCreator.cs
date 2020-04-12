using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoCreator : MonoBehaviour
{
    enum gizmoAspect { Sphere, WireSphere, Cube, WireCube, Ray };
    
    [SerializeField]
    gizmoAspect shape = gizmoAspect.Cube;

    [Range(0.1f, 10)]
    public float gizmoSize = 0.25f;
    [SerializeField]
    Color gizmoColor = Color.green;

    Vector3 cubeSize;

    private void OnDrawGizmos()
    {
        cubeSize = new Vector3(gizmoSize, gizmoSize, gizmoSize) * 1.5f;

        Gizmos.color = gizmoColor;
        switch (shape)
        {
            case gizmoAspect.Sphere:
                Gizmos.DrawSphere(transform.position, gizmoSize);
                break;

            case gizmoAspect.WireSphere:
                Gizmos.DrawWireSphere(transform.position, gizmoSize);
                break;

            case gizmoAspect.Cube:
                Gizmos.DrawCube(transform.position, cubeSize);
                break;

            case gizmoAspect.WireCube:
                Gizmos.DrawWireCube(transform.position, cubeSize);
                break;

            case gizmoAspect.Ray:
                Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * gizmoSize);
                break;
        }
    }
}
