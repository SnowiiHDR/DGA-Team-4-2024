using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncepad : MonoBehaviour
{
    private GameObject currentPlatform;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private Rigidbody2D Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatform != null)
        {
            Player.velocity = new Vector2(Player.velocity.x, 24f);
        }
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
               currentPlatform = collision.gameObject; 
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentPlatform = null;
        }
    }
}
