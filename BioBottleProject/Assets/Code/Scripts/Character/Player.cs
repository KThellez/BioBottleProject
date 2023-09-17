using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Spawn spawn;
    public void death()
    {
        gameObject.SetActive(false);
        spawn.RespawnPlayer();
        gameObject.SetActive(true);
    }
    
}
