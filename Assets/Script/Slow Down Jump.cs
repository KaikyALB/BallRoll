using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownJump : MonoBehaviour
{
    public float slowDownStrength = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if(rb != null)
            {
                Vector3 vel = rb.velocity;
                vel.y = Mathf.Lerp(vel.y, 0f, Time.deltaTime * slowDownStrength);
                rb.velocity = vel;
                Debug.Log("Slowww");
            }
        }
        
    }
}
