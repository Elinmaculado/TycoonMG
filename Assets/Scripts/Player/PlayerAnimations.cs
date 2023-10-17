using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GroundDetector groundDetector;

    private float speed;
    private bool isGrounded;
    private Animator animator;
    void Start()
    {
        speed = 0f;
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       CheckGrounded();
       CheckSpeed();
       SetParameter();

    }

    private void SetParameter()
    {
        animator.SetFloat("Speed", speed);
        animator.SetBool("Isgrounded", isGrounded);
    }
    public void CheckSpeed ()
    {
        speed = playerMovement.GetCurrentSpeed();
    }

    public void CheckGrounded()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }
}
