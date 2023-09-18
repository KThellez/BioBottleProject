using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementWorms : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private Transform[] motionPoints;
    [SerializeField] private float minDistance;

    [SerializeField] private bool isSlayable = true;
    [SerializeField] private bool followPlayer = false;
    [SerializeField] private Transform player;

    private int step;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        step = 0;
        followPlayer = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Flip();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("No se encontró al objeto con la etiqueta 'Jugador'");
        }
    }
    private void FixedUpdate()
    {

        if (motionPoints.Length == 0) { return; }

        transform.position = Vector2.MoveTowards(transform.position, motionPoints[step].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, motionPoints[step].position) < minDistance)
        {
            step += 1;
            if (step >= motionPoints.Length)
            {
                step = 0;
            }
            Flip();
        }


    }
    private void Update()
    {
        if (player != null && followPlayer)
        {
            Vector3 direccion = (player.position - transform.position).normalized;
            transform.Translate(direccion * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            followPlayer = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            followPlayer = false;
        }
    }


    private void Flip()
    {
        if (transform.position.x < motionPoints[step].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else { spriteRenderer.flipX = false; }
    }
}
