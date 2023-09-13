using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotsPlayer : MonoBehaviour
{

    [SerializeField] private GameObject shotPlayerPrefab;
    [SerializeField] private List<GameObject> shotLsit;
    [SerializeField] private int poolSize = 12;

    private static GunShotsPlayer instance;

    public static GunShotsPlayer Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        AddShotsToPool(poolSize);
    }

    private void AddShotsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject shot = Instantiate(shotPlayerPrefab);
            shot.SetActive(false);
            shotLsit.Add(shot);
            shot.transform.parent = transform;
        }
    }

    public GameObject RequestShot()
    {
        for(int i = 0;i < shotLsit.Count; i++)
        {
            if (!shotLsit[i].activeSelf)
            {
                shotLsit[i].SetActive(true);
                return shotLsit[i];
            }
        }
        return null;
    }
}
