using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void death()
    {
        gameObject.SetActive(false);
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(" Enemigo Colisiono");
        if (collision.CompareTag("Player"))
        {
            ;
            collision.GetComponent<Player>().death(); 
        }

    }
}
