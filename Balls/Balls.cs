using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    private List<Color> defaultColors = new List<Color>();
    public Color ballsColor;
    private SpriteRenderer spriteRenderer;

    private Color collisionColor1;
    private Color collisionColor2;

    public List<GameObject> recordBallsColor = new List<GameObject>();
    

    public void Start()
    {
        produceColorBall();

    }
    public void Update()
    {

    }

    private void produceColorBall()
    {
        defaultColors.Add(Color.red);
        defaultColors.Add(Color.blue);
        defaultColors.Add(Color.yellow);

        int a = Random.Range(0, 3);
        ballsColor = defaultColors[a];

        GetComponent<SpriteRenderer>().color = ballsColor;
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        collisionColor1 = collisionInfo.gameObject.GetComponent<SpriteRenderer>().color;

        if (collisionColor1 == ballsColor)
        {

        }
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        collisionColor2 = collisionInfo.gameObject.GetComponent<SpriteRenderer>().color;

        if (collisionColor2 == ballsColor)
        {

        }
    }

}
