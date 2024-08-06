using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class finishline : MonoBehaviour

{

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

              
private void OnTriggerEnter2D(Collider2D collision)
{
        if (collision.gameObject.tag == "Player"){
            //next level
        }
        
 }}
    //Check if we already won. If so, allow a scene restart with keypress "R". Afterwards, make "won false"

