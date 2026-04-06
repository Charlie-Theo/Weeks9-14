using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public List<GameObject> birds;
    GameObject spawnedBird;

    Vector2 spawnPos;

    public float timerMax = 1.5f;
    float timerValue = 0;

    public TextMeshProUGUI birdCounter;
    SpriteRenderer birdSR;

    Vector2 lerpPos1;
    Vector2 lerpPos2;
    public float t;
    public Transform ball;
    public AnimationCurve curve;
    bool isThrowing;
    int currentBird;
    public AudioSource SFX;
    public BallMovement ballScript;

    public UnityEvent tooManyBirds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lerpPos1 = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timerValue += Time.deltaTime;

        if (timerValue > timerMax )
        {
            spawnPos.x = Random.Range(-9, 9);
            spawnPos.y = Random.Range(-4, 4);

            spawnedBird = Instantiate(birdPrefab, spawnPos, Quaternion.identity);
            birds.Add(spawnedBird);

            birdCounter.text = "Number of Birds: " + birds.Count;

            timerValue = 0;
        }

        if (isThrowing == true)
        {
            t += Time.deltaTime;

            if (t > 1)
            {
                t = 0;
                isThrowing = false;

                Destroy(birds[currentBird]);
                birds.RemoveAt(currentBird);
                SFX.Play();

                birdCounter.text = "Number of Birds: " + birds.Count;
            }

            ball.transform.position = Vector2.Lerp(lerpPos1, lerpPos2, curve.Evaluate(t));
        }

        if (birds.Count == 20)
        {
            tooManyBirds.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            for (int b = 0; b < birds.Count; b++)
            {
                birdSR = birds[b].GetComponent<SpriteRenderer>();

                if (birdSR.bounds.Contains(mousePos) == true)
                {
                    currentBird = b;

                    isThrowing = true;
                    lerpPos2 = mousePos;
                    ballScript.BallIsThrown();
                }
            }
        }
    }

    public void ResetBirds()
    {
        for (int a = 0; a < birds.Count; a++)
        {
            Destroy(birds[a]);
        }

        birds.Clear();
    }
}
