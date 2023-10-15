using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls2 : MonoBehaviour
{
    public ColorList2 colorList;

    #region Color change
    private Color ballsColor1;//level 1 balls color
    private Color ballsColor2;//level 2 balls color
    private Color upgradeColor;

    private Color collisionColor;//Get from collision
    #endregion

    #region level2 Color
    private Color purple = new Color(0.9333333f, 0.08235291f, 0.717019f);
    private Color green = Color.green;
    private Color orange = new Color(0.9622642f, 0.4807624f, 0.02178708f);
    private Color black = Color.black;
    #endregion

    public void Start()
    {
        produceColorBall();
    }
    public void Update()
    {
        if (recordBalls.Count == 2)
        {
            GetUpgradeColor();
            Destroy(recordBalls[0]);
            Destroy(recordBalls[0]);
            GetComponent<SpriteRenderer>().color = upgradeColor;
            ballsColor1 = new Color(0.1f,0.3f,0.2f);
            ballsColor2 = upgradeColor;
            if (upgradeColor == black)
                ballsColor1 = black;
        }
    }

    private void produceColorBall()
    {
        ballsColor1 = colorList.randColor[0];
        colorList.randColor.RemoveAt(0);
        GetComponent<SpriteRenderer>().color = ballsColor1;
    }

    private void GetUpgradeColor()
    {
        if (ballsColor1 == Color.red)
            upgradeColor = purple;
        if (ballsColor1 == Color.blue)
            upgradeColor = green;
        if (ballsColor1 == Color.yellow)
            upgradeColor = orange;
        if (ballsColor2 == orange)
            upgradeColor = black;
        if (ballsColor2 == purple)
            upgradeColor = black;
        if (ballsColor2 == green)
            upgradeColor = black;
    }

    #region Collision
    private List<GameObject> recordBalls = new List<GameObject>();
    private List<Color> secondLevelBalls = new List<Color>();

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        collisionColor = collisionInfo.gameObject.GetComponent<SpriteRenderer>().color;

        if (collisionColor == ballsColor1)
            recordBalls.Add(collisionInfo.gameObject);

        SecondLevelBallCheck1(collisionInfo);
    }

    private void SecondLevelBallCheck1(Collision2D collisionInfo)
    {
        if (ballsColor2 == orange)
        {
            if (collisionColor == green && !secondLevelBalls.Contains(green))
            {
                secondLevelBalls.Add(green);
                recordBalls.Add(collisionInfo.gameObject);
            }

            if (collisionColor == purple && !secondLevelBalls.Contains(purple))
            {
                secondLevelBalls.Add(purple);
                recordBalls.Add(collisionInfo.gameObject);
            }
        }

        if (ballsColor2 == green)
        {
            if (collisionColor == orange && !secondLevelBalls.Contains(orange))
            {
                secondLevelBalls.Add(orange);
                recordBalls.Add(collisionInfo.gameObject);
            }

            if (collisionColor == purple && !secondLevelBalls.Contains(purple))
            {
                secondLevelBalls.Add(purple);
                recordBalls.Add(collisionInfo.gameObject);
            }
        }
        if (ballsColor2 == purple)
        {
            if (collisionColor == green && !secondLevelBalls.Contains(green))
            {
                secondLevelBalls.Add(green);
                recordBalls.Add(collisionInfo.gameObject);
            }

            if (collisionColor == orange && !secondLevelBalls.Contains(orange))
            {
                secondLevelBalls.Add(orange);
                recordBalls.Add(collisionInfo.gameObject);
            }
        }
    }
    private void SecondLevelBallCheck2(Collision2D collisionInfo)
    {
        if (ballsColor2 == orange)
        {
            if (collisionColor == green)
            {
                secondLevelBalls.Remove(green);
                recordBalls.Remove(collisionInfo.gameObject);
            }

            if (collisionColor == purple)
            {
                secondLevelBalls.Remove(purple);
                recordBalls.Remove(collisionInfo.gameObject);
            }
        }

        if (ballsColor2 == green)
        {
            if (collisionColor == orange)
            {
                secondLevelBalls.Remove(orange);
                recordBalls.Remove(collisionInfo.gameObject);
            }

            if (collisionColor == purple)
            {
                secondLevelBalls.Remove(purple);
                recordBalls.Remove(collisionInfo.gameObject);
            }
        }
        if (ballsColor2 == purple)
        {
            if (collisionColor == green)
            {
                secondLevelBalls.Remove(green);
                recordBalls.Remove(collisionInfo.gameObject);
            }

            if (collisionColor == orange)
            {
                secondLevelBalls.Remove(orange);
                recordBalls.Remove(collisionInfo.gameObject);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        collisionColor = collisionInfo.gameObject.GetComponent<SpriteRenderer>().color;

        if (collisionColor == ballsColor1)
            recordBalls.Remove(collisionInfo.gameObject);

        SecondLevelBallCheck2(collisionInfo);
    }
    #endregion
}