using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCooldown;

    public float Switchtime =  gravity.lastSwitchTime;
    public float cooldownTime = gravity.cooldownTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gameStart());
    }
    // Update is called once per frame
    
    void Update()
    {
    // Same conditions as the gravity cooldown. Simplifies timing.
       if ((Input.GetKeyDown(KeyCode.K)) && (Time.time > (Switchtime + cooldownTime))){
            StartCoroutine(coundownStart());
            Switchtime = Time.time;
            }
    }

    ///First coroutine! Very useful. Shows the text of the countdown timer while waiting for a second each time.

    private IEnumerator coundownStart()
    {
        textCooldown.gameObject.SetActive(true);
        textCooldown.text = "3";
        yield return new WaitForSeconds(1f);
        textCooldown.text = "2";
        yield return new WaitForSeconds(1f);
        textCooldown.text = "1";
        yield return new WaitForSeconds(1f);
        textCooldown.text = "Ready to Activate!";
    }

    ///Coroutine that works when the game starts to instead count up to your cooldown.
    private IEnumerator gameStart()
    {
        textCooldown.text = "1";
        yield return new WaitForSeconds(1f);
        textCooldown.text = "2";
        yield return new WaitForSeconds(1f);
        textCooldown.text = "3";
        yield return new WaitForSeconds(1f);
        textCooldown.text = "Ready to Activate!";
    }
}