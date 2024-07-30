using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool doubleJump;
    private float cooldown;
    float lastuse;
    
    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform roofCheck;
    [SerializeField] private LayerMask roofLayer;
    

    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump =false;
        } 
        if (Input.GetButtonDown("Jump") && (IsGrounded() || doubleJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJump = !doubleJump;
        }
        if (Input.GetButtonDown("Jump") && (IsRoofed())){
            rb.velocity = new Vector2(rb.velocity.x, -(jumpingPower));
        }
        

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
      

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private bool IsRoofed()
    {
        return Physics2D.OverlapCircle(roofCheck.position, 0.2f, roofLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Lethal")
        {
        GameManager.Instance.RestartLevel();
        }
    
    }
    /// For the oncollision reset portion of the assignment i utilized official unity turtorials and the documentation. https://youtu.be/QRp4V1JTZnM?si=H2SEeNR6bg32xXmd
    /// Lagging pretty badly for some reason. Will ask for help with this.
}