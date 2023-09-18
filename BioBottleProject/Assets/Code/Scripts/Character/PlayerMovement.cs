using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float jumpForce = 5f;

    private bool isFacingRight = true;
    private bool isJumping;
    private float horizontalMovementInput;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;


    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;

    private Animator playerAnimator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        isJumping = false;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer); //Comprueba si el character esta en el suelo

        horizontalMovementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMovementInput * speed, rb.velocity.y);

        if(horizontalMovementInput == 0 || horizontalMovementInput > 0.5f)
            playerAnimator.SetFloat("Movement", horizontalMovementInput);
        else if(horizontalMovementInput < 0.5f)
            playerAnimator.SetFloat("Movement", -horizontalMovementInput);

        //Comprobación del Salto
        if (isGrounded && Input.GetButtonDown("Jump") )
        {
            rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());

        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            isJumping = true;

            coyoteTimeCounter = 0f;
        }

        if (isJumping == true)
            playerAnimator.SetTrigger("Jump");

        FlipPlayerFacing();

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovementInput * speed, rb.velocity.y);


    }
    private void FlipPlayerFacing()
    {
        if (isFacingRight && horizontalMovementInput < 0f || !isFacingRight && horizontalMovementInput > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
           transform.localScale = localScale;

        }
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
}
