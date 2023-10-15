using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot2 : MonoBehaviour
{
    public GameObject balls;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Instantiate(balls, transform.position, transform.rotation);
    }
}
