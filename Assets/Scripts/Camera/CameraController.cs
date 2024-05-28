using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        // ¬ычисление желаемого положени€ камеры
        Vector3 desiredPosition = target.position + offset;

        // ѕлавно перемещение камеры к желаемому положению
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ”становка положени€ камеры
        transform.position = smoothedPosition;
    }
}
