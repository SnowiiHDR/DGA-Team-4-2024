using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour

{
    
    public static GameManager Instance = null;
    public bool won = false;
    public bool CooldownActive;
    
    
    void Awake (){
        if (Instance == null)
        Instance = this;
        else if (Instance != this)
        Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1;

    }
    
    
    public void wongameflag(){
        Time.timeScale=0; 
    }

 
 }
 
    
    


