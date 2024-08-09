using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour

{
    
    public static GameManager instance = null;
    
    
void Awake (){
if (instance == null){
instance = this;
DontDestroyOnLoad(gameObject);
}
else{
        Destroy(gameObject);
    }


}

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1;

    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    
    public void NextLevel()
    {
       SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

 
 }
 
    
    


