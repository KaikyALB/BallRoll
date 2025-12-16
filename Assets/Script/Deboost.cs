using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deboost : MonoBehaviour
{
    public float debuff = 1.2f;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = rb.velocity / debuff;
        }
    }
}
