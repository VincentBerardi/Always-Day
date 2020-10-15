using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 forward, right;

    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private float jumpForce = 6f;
    [SerializeField]
    public bool isGrounded = true;
    [SerializeField]
    public bool isStunned = false;

    //For lock-on system
    private TestEnemyController lockOnTarget;
    public StunBar stunBar;
    public float stunBarIncrement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Make movement directions relative to isometric camera
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        lockOnTarget = null;
    }

    public void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;

        if (!isStunned)
        {
            transform.position += rightMovement;
            transform.position += upMovement;
        }
    }
    public void Jump()
    {
        if (isGrounded && !isStunned)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void GetStunned()
    {
        if (!isStunned)
        {
            isStunned = true;
            Invoke(nameof(ResetStun), 1.5f);
        }
    }

    private void ResetStun()
    {
        isStunned = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
            isGrounded = true;
    }

    public void LockOnToTarget()
    {
        RaycastHit rayHit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit))
        {
            lockOnTarget = rayHit.collider.GetComponent<TestEnemyController>();
            if (lockOnTarget)
            {
                transform.LookAt(lockOnTarget.transform);
                stunBar.stunBarImg.enabled = true;
                stunBar.StunBarProgress(stunBarIncrement * Time.deltaTime);
            }
        }
        else
        {
            stunBar.stunBarImg.fillAmount = 0.0f;
            stunBar.stunBarImg.enabled = false;
        }
    }
}
