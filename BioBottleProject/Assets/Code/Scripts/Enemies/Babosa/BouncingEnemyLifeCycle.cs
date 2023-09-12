using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemyLifeCycle : MonoBehaviour
{
    [SerializeField] Transform pointA, pointB; // Puntos a donde se dirige el enemigo
    [SerializeField] float enemySpeed = 2.0f;
    [SerializeField] GameObject Player;

    private Vector2 targetPosition;
    private bool movingTowardsB = true;
    private bool isAlive = true;
    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
        targetPosition.x = initialPosition.x;
    }

    private void Update()
    {
        // Mantener la posición Y del enemigo fija a su posición inicial
        targetPosition.y = initialPosition.y;
        


        transform.position = Vector2.Lerp(transform.position, targetPosition, enemySpeed * Time.deltaTime); // Desplazamiento del enemigo

        if (isAlive)
        {
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                if (movingTowardsB) { targetPosition = pointA.position; } // Cambiar hacia el punto A
                else { targetPosition = pointB.position; } // Cambiar hacia el punto B

                movingTowardsB = !movingTowardsB; // Cambiar la dirección de movimiento
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Si el enemigo colisionó con el jugador entonces...
            Die(); // Llamar a la función que hace que el enemigo muera
        }
    }

    private void Die()
    {
        isAlive = false; // Se vuelve falso el que esté vivo el enemigo
        gameObject.SetActive(false);
    }
}
