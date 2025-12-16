using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    public float smoothSpeed = 3f;

    private void LateUpdate()
    {
        if (Player == null) return;

        Vector3 targetPosition = Player.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed + Time.deltaTime
            );
    }
}
