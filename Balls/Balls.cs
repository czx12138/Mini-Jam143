using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    private List<Color> defaultColors = new List<Color>();
    public Color ballsColor;
    private Color upgradeColor;
    private SpriteRenderer spriteRenderer;

    private Color collisionColor1;
    private Color collisionColor2;

    public List<GameObject> recordBalls = new List<GameObject>();
    

    public void Start()
    {
        produceColorBall();
    }
    public void Update()
    {
        if(recordBalls.Count == 2)
        {
            Destroy(recordBalls[0]);
            Destroy(recordBalls[0]);
            GetComponent<SpriteRenderer>().color = upgradeColor;
        }
    }

    private void produceColorBall()
    {
        defaultColors.Add(Color.red);
        defaultColors.Add(Color.blue);
        defaultColors.Add(Color.yellow);

        int a = Random.Range(0, 3);
        ballsColor = defaultColors[a];

        GetComponent<SpriteRenderer>().color = ballsColor;

        GetUpgradeColor();

    }

    private void GetUpgradeColor()
    {
        if (ballsColor == Color.red)
            upgradeColor = new Color(229, 10, 205);
        if (ballsColor == Color.blue)
            upgradeColor = Color.green;
        if (ballsColor == Color.yellow)
            upgradeColor = new Color(255, 165, 0); ;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        collisionColor1 = collisionInfo.gameObject.GetComponent<SpriteRenderer>().color;

        if (collisionColor1 == ballsColor)
            recordBalls.Add(collisionInfo.gameObject);
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        collisionColor2 = collisionInfo.gameObject.GetComponent<SpriteRenderer>().color;

        if (collisionColor2 == ballsColor)
            recordBalls.Remove(collisionInfo.gameObject);
    }

}
