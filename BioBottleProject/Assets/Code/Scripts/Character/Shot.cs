using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float shotSpeed = 10.0f;
    [SerializeField] private Rigidbody2D shotRb;

    private void Start()
    {
        shotRb = GetComponent<Rigidbody2D>();
        shotRb.velocity = Vector2.right * shotSpeed;
    }

    private void OnCollisionEnter2D()
    {
        gameObject.SetActive(false);
    }
}
