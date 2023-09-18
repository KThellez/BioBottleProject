using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    [SerializeField] GameObject gameOverScreen;

    private void Start(){
        gameOverScreen.SetActive(false);
    }

    public void Death(){
        gameOverScreen.SetActive(true);
        gameObject.SetActive(false);
    }
    
}
