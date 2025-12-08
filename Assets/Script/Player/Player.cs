using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController cc;

    [Header("Basic Stats")]
    private float Horizontal;
    public float speed = 3f;
    void Start()
    {
    rb = GetComponent<Rigidbody>();
    cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal"); // Moves Sideways

        Movement();
    }
    public void Movement()
    {
        Vector3 move = transform.position * Horizontal;
        cc.Move(move * speed * Time.deltaTime);

        
    }
}
