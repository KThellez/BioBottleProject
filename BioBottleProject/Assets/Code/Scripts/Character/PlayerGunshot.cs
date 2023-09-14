using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunshot : MonoBehaviour
{
    [SerializeField] private float shotSpeed = 10.0f;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Obt�n la posici�n del mouse en el mundo

            Vector3 direction = (mousePosition - transform.position).normalized; // Calcula la direcci�n desde el personaje hacia el mouse

            float shotDistance = 2.0f; // Ajusta la distancia desde el personaje al punto de inicio del proyectil

            Vector3 shotStartPosition = transform.position + direction * shotDistance; // Calcula la posici�n de inicio del proyectil

            GameObject shot = GunShotsPlayer.Instance.RequestShot(); // Solicita una bala del pool

            if (shot != null)
            {

                shot.transform.position = shotStartPosition; // Establece la posici�n inicial de la bala
                Rigidbody2D shotRb = shot.GetComponent<Rigidbody2D>(); // Configura la direcci�n del proyectil
                //shotRb.velocity = direction * shotRb.velocity.magnitude * shotSpeed; // Mantiene la velocidad original
                
                shotRb.velocity = direction * shotSpeed; 
                
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Ajusta la rotaci�n de la bala para que apunte hacia el mouse
                shot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); //Dispara.

                float shotLifetime = 5.0f; // Temporizador para desactivar la bala despu�s de cierto tiempo si no colisiona
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
