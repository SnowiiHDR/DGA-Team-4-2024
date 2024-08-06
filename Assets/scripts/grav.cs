using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public static float cooldownTime = 3f;
    public static float lastSwitchTime;
    public static gravity Instance; 
    AudioManager audioManager;
    private bool isUpright = true;

 
private void Awake()
{
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
}
      
    void Update()
    {
        ///If the "K" key is pressed, check the time. "lastSwitchTime + cooldownTime" checks that its been cooldownTime since we last used our power.
        if (Input.GetKeyDown(KeyCode.K)){
         if (Time.time > (lastSwitchTime + cooldownTime)){
            gravswap();
            lastSwitchTime = Time.time;
            }

        
    }
    ///Function that reverses gravity.
    void gravswap(){
        audioManager.PlaySFX(audioManager.gravSwap);
        upFlip();
        rb.gravityScale = rb.gravityScale *-1;
        

    void upFlip()
    {        {
            isUpright = !isUpright;
            Vector3 localScale = transform.localScale;
            localScale.y *= -1f;
            transform.localScale = localScale;
        }

}
}
}}
///Videos and links used to conduct ideas.
///https://docs.unity3d.com/ScriptReference/Rigidbody2D-gravityScale.html
///https://youtu.be/7MFGXRv_X5U?si=GVrIpycwlq-8keoJ
///https://medium.com/@victormct/creating-a-cooldown-system-in-unity-d250ca87b487

