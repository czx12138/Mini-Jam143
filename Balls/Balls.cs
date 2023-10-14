using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    List<Color> ballsColor = new List<Color>();
    Color bColor;
    private SpriteRenderer spriteRenderer;

    List<Rigidbody2D> ballCollision = new List<Rigidbody2D>();
    

    public void Start()
    {
        ballsColor.Add(Color.red);
        ballsColor.Add(Color.blue);
        ballsColor.Add(Color.yellow);

        int a = Random.Range(0, 3);
        bColor = ballsColor[a];

        GetComponent<SpriteRenderer>().color = bColor;

    }

    public void Update()
    {

    }
}
