using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour{

    [SerializeField] string scene;

    private void OnTriggerEnter2D(Collider2D collision){

        GameManager.instance.ChangeScene(scene);
    }
}