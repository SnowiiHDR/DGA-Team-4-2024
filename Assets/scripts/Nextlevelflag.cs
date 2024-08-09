using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Nextlevelflag : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameManager.instance.NextLevel();
        }
    }
}
