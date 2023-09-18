using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player")) { RespawnPlayer(collision.gameObject); }
    }
    
    public void RespawnPlayer() { player.transform.position = spawnPoint.position;}
    
}


