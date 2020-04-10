using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoCreator : MonoBehaviour
{
    private enum gizmoAspect {Sphere, WireSphere, Cube, WireCube, Ray};
    
    [SerializeField]
    private gizmoAspect shape;

    [SerializeField]
    [Range(0.1f, 10)]
    private float gizmoSize = 0.25f;
    [SerializeField]
    private Color gizmoColor = Color.green;

    private Vector3 cubeSize;

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
