using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunshot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Obtén la posición del mouse en el mundo

            Vector3 direction = (mousePosition - transform.position).normalized; // Calcula la dirección desde el personaje hacia el mouse

            float shotDistance = 2.0f; // Ajusta la distancia desde el personaje al punto de inicio del proyectil

            Vector3 shotStartPosition = transform.position + direction * shotDistance; // Calcula la posición de inicio del proyectil

            GameObject shot = GunShotsPlayer.Instance.RequestShot(); // Solicita una bala del pool

            if (shot != null)
            {

                shot.transform.position = shotStartPosition; // Establece la posición inicial de la bala


                Rigidbody2D shotRb = shot.GetComponent<Rigidbody2D>(); // Configura la dirección del proyectil
                shotRb.velocity = direction * shotRb.velocity.magnitude; // Mantiene la velocidad original
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Ajusta la rotación de la bala para que apunte hacia el mouse
                shot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); //Dispara.

                float shotLifetime = 5.0f; // Temporizador para desactivar la bala después de cierto tiempo si no colisiona
                StartCoroutine(DeactivateBullet(shot, shotLifetime));
            }




            /*
            GameObject shots = GunShotsPlayer.Instance.RequestShot();
            shots.transform.position = transform.position + new Vector3(1,0,0);
            */
        }

    }
    private IEnumerator DeactivateBullet(GameObject bullet, float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        bullet.SetActive(false);
    }
}
