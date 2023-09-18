using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //[SerializeField] private float shotSpeed = 10.0f;
    [SerializeField] private Rigidbody2D shotRb;
    [SerializeField] private float damage;

    private void Start()
    {
        if (shotRb == null) { shotRb = GetComponent<Rigidbody2D>(); }
        //shotRb.velocity = shotRb.velocity.normalized * shotSpeed;
    }

    private void OnCollisionEnter2D(){
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisiono");
        if (collision.CompareTag("Boss"))
        {
            Debug.Log("GOLPEO AL Boss");
            Debug.Log(collision.GetComponent<Boss>());
            collision.GetComponent<Boss>().TakeDamage(damage);
        }
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("GOLPEO AL ENEMIGO");
            collision.GetComponent<Enemy>().death();
            gameObject.SetActive(false);
        }
    }
}
