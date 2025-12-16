using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
 

    public float impulseStrength = 100f;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if(rb != null) 
            {
                Debug.Log("Boos Applied");
            rb.AddForce(
                collision.transform.forward * impulseStrength, 
                ForceMode.Impulse);
            }
        }
    }
}
