using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSpiders : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private Transform[] motionPoints;
    [SerializeField] private float minDistance;

    [SerializeField] private bool isSlayable = true;


    private int step;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        step = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Flip();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Matar al player
        }
    }

    private void Flip()
    {
        if (transform.position.y < motionPoints[step].position.y)
        {
            spriteRenderer.flipY = true;
        }
        else { spriteRenderer.flipY = false; }
    }
}
