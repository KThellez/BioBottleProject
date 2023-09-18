using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    public static GameManager instance;

    private void Start(){
        
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}