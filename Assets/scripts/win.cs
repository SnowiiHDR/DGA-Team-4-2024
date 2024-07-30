using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class win : MonoBehaviour

{
public bool won = false;
public TextMeshProUGUI WinText;
    // Start is called before the first frame update

//Nothing needed to be initialized.
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    if (Input.GetKeyDown(KeyCode.R))
                resetonWin();
    }
/// Check if the flag is touching the player. If so, change "won" to true, and make the WinText appear.
public void resetonWin() {
    if (won == true)
        GameManager.Instance.RestartLevel();
        won = false;
;         

}
              
void OnCollisionEnter2D(Collision2D collider)
{
        if (collider.gameObject.tag == "Player")
            won = true;
            WinText.gameObject.SetActive(true); 
            Time.timeScale=0;
 }}
    //Check if we already won. If so, allow a scene restart with keypress "R". Afterwards, make "won false"
