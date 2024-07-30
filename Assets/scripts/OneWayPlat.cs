using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class OneWay : MonoBehaviour
{
    
    private GameObject currentPlatform;
    [SerializeField] private BoxCollider2D playerCollider;
    
    void Update()
    {
        //Allows us to drop through the floor as long as we're on a platform that you are allowed ot fall through.
        if ((Input.GetKeyDown(KeyCode.DownArrow)) && currentPlatform != null)
        {
            StartCoroutine(falldown());
        }
    }

// Function that checks if we are touching the One way platform. If so, set it as the platform we're on.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWay"))
        {
               currentPlatform = collision.gameObject;
        }
        else{
            currentPlatform = null;
        }
    }
// Function that checks if we are leaving the One way platform. Set our platform to none.


    //Coroutine that will ignore the collision for a little while so we can fall completely through.
    private IEnumerator falldown()
    {
        BoxCollider2D platform = currentPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platform);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerCollider, platform, false);
    }

    
}

// Based on Bendux video, https://youtu.be/7rCUt6mqqE8?si=9BBgScf7ja470Ow9.
// Used to learn coroutine, but simplified his code.