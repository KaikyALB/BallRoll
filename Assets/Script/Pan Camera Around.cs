using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCameraAround : MonoBehaviour
{
    public float flipDuration = 0.5f;

    private bool isFlipping = false;

    public void FlipCamera()
    {
        if (!isFlipping)
            StartCoroutine(FlipCoroutine());
    }
    private System.Collections.IEnumerator FlipCoroutine()
    {
        isFlipping = true;


        Quaternion startRot = transform.rotation;
        Quaternion targetRot = startRot * Quaternion.Euler(0f, 180f, 0f);

        float t = 0f;
        while(t < 1f)
        {
            t += Time.deltaTime / flipDuration;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        transform.rotation = targetRot;
        isFlipping = false;
    }
}
