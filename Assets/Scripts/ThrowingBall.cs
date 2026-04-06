using NUnit;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ThrowingBall : MonoBehaviour
{
    public bool isThrowing;
    Vector2 lerpPos1;
    Vector2 lerpPos2;

    public float t;
    public AnimationCurve curve;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lerpPos1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrowing == true)
        {
            lerpPos2 = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            t += Time.deltaTime;

            if (t > 1)
            {
                t = 0;
                isThrowing = false;
            }

            transform.position = Vector2.Lerp(lerpPos1, lerpPos2, curve.Evaluate(t));
        }
    }
}
