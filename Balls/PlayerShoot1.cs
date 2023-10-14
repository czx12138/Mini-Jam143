using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot1 : MonoBehaviour
{
    public GameObject balls;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        { 
            Instantiate(balls,transform.position, transform.rotation);
        }
    }
}
