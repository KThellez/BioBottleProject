using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void death()
    {
        gameObject.SetActive(false);
    }
}
