using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    public Transform ballTransform;
    public Vector2 startPos;
    public Vector2 startScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //saves the ball's default position at the bottom of the screen
        startPos = transform.position;
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BallIsThrown()
    {
        //is called when the mouse is clicked on a bird (refer to bird spawner script)
        StartCoroutine(ThrowBall());
    }

    public IEnumerator ThrowBall()
    {
        ballTransform.localScale = transform.localScale;

        float t = 3;

        //decreases the size of the ball via a coroutine to make it feel like its moving farther
        while (t > 2)
        {
            t -= Time.deltaTime;
            ballTransform.localScale = Vector2.one * t;

            yield return null;
        }

        //resets the ball to its default position
        transform.position = startPos;
        transform.localScale = startScale;
    }

    public void ResetBall()
    {
        //manual reset of the ball to its default position (by calling this function)
        transform.position = startPos;
        transform.localScale = startScale;
    }
}
