using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Basic Stats")]
    private float Horizontal;
    public float extraSpeed = 9f;
    public float maxSpeed = 5f;
    public float moveForce = 1f;
    public float brakeStrength = 0.5f;

    [SerializeField] public float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    public bool isGrounded;
    void Start()
    {
    rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
       Horizontal = Input.GetAxis("Horizontal"); // Moves Sideways

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        Movement();

        GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime);
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            1.1f,
            groundLayer);
        Vector3 vel = rb.velocity;

        vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
        rb.velocity = vel;
    }
    public void Movement()
    {
        rb.AddForce(
            new Vector3(Horizontal * moveForce, 0f, 0f));
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 vel = rb.velocity;

            vel.z *= brakeStrength;

            rb.velocity = vel;
        }
        /*if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 vel = rb.velocity;

            vel.z *= extraSpeed;

            rb.velocity = vel;
        }*/
    }
    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
