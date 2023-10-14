using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public void Update()
    {
        circularMotion();
    }

    private void circularMotion()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0f, 0f, 0.4f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0f, 0f, -0.4f);
        }
    }
}
