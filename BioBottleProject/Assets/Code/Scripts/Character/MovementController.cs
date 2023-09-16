using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    private bool isJumping;

    private Animator playerAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer); //Comprueba si el character esta en el suelo

        float horizontalMovementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (horizontalMovementInput * speed, rb.velocity.y);

        

        //Comprobaci�n del Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }

        
    }
}
