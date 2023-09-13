using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunshot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject shots = GunShotsPlayer.Instance.RequestShot();
            shots.transform.position = transform.position;
        }
    }
}
