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
        startPos = transform.position;
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BallIsThrown()
    {
        StartCoroutine(ThrowBall());
    }

    public IEnumerator ThrowBall()
    {
        ballTransform.localScale = transform.localScale;

        float t = 3;

        while (t > 2)
        {
            t -= Time.deltaTime;
            ballTransform.localScale = Vector2.one * t;

            yield return null;
        }

        transform.position = startPos;
        transform.localScale = startScale;
    }
}
