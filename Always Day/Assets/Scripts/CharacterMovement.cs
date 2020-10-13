using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;
    Vector3 forward, right;

    public LayerMask groundLayers;
    public float jumpForce = 7;

    public BoxCollider col;
    public Rigidbody rb;

    public bool isGrounded = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)  
            Move();

        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement; 
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
        isGrounded = false; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            isGrounded = true;
    }
}
