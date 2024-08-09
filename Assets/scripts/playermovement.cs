using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance = null;
    AudioManager audioManager;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool doubleJump;
    private float cooldown;
    float lastuse;
    public Animator animator;
    

private void Awake (){
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
//        if (Instance == null)
//        Instance = this;
//        else if (Instance != this)
//        Destroy(gameObject);

//        DontDestroyOnLoad(gameObject);
}
void Start() {

}

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform roofCheck;
    [SerializeField] private LayerMask roofLayer;
    

    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump =false;
        } 
        if (Input.GetButtonDown("Jump") && (IsGrounded() || doubleJump))
        {
            audioManager.PlaySFX(audioManager.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJump = !doubleJump;
        }
        if (Input.GetButtonDown("Jump") && IsRoofed()){
            audioManager.PlaySFX(audioManager.jump);
            rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);
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
        return Physics2D.OverlapCircle(groundCheck.position, 0.6f, groundLayer);
    }
    private bool IsRoofed()
    {
        return Physics2D.OverlapCircle(roofCheck.position, 2f, roofLayer);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        }
    
    }
    /// For the oncollision reset portion of the assignment i utilized official unity turtorials and the documentation. https://youtu.be/QRp4V1JTZnM?si=H2SEeNR6bg32xXmd
    /// Used Brackeys guide to help with 2d movement and animations.
}