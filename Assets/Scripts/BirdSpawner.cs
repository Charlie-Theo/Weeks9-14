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
        //setting the start of the lerp to the ball's default position
        lerpPos1 = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //timer for spawning the birds: 1 bird every [timerMax] seconds
        timerValue += Time.deltaTime;

        if (timerValue > timerMax)
        {
            //determines a random spawning position on screen
            spawnPos.x = Random.Range(-9, 9);
            spawnPos.y = Random.Range(-4, 4);

            //spawns a bird and adds it to the array list
            spawnedBird = Instantiate(birdPrefab, spawnPos, Quaternion.identity);
            birds.Add(spawnedBird);

            //updates the top text to display how many current birds there are
            birdCounter.text = "Number of Birds: " + birds.Count;

            timerValue = 0;
        }

        //checks if the ball is currently being thrown (or mouse has been clicked on a bird)
        if (isThrowing == true)
        {
            //sets a timer for the lerp over 1 second
            t += Time.deltaTime;

            if (t > 1)
            {
                //finishing the lerp
                //reset timer
                t = 0;
                //saying that the ball is no longer being thron
                isThrowing = false;

                //destroy the bird that the ball hit
                Destroy(birds[currentBird]);
                birds.RemoveAt(currentBird);
                SFX.Play();

                //updates the counter of the birds
                birdCounter.text = "Number of Birds: " + birds.Count;
            }

            //lerps the ball from the starting positon to the chosen bird
            ball.transform.position = Vector2.Lerp(lerpPos1, lerpPos2, curve.Evaluate(t));
        }

        //checks for loosing condition
        if (birds.Count == 10)
        {
            //if there are too many birds, invokes the unity event to show that the player lost
            tooManyBirds.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            //getting mouse position
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            //checks if the mouse is over a bird
            for (int b = 0; b < birds.Count; b++)
            {
                birdSR = birds[b].GetComponent<SpriteRenderer>();

                if (birdSR.bounds.Contains(mousePos) == true)
                {
                    //if the mouse clicked on a bird:
                    //saves the bird's index to identify it later
                    currentBird = b;

                    //tells the code that the ball is being thrown
                    isThrowing = true;
                    //sets the second point of the lerp to where the mouse is
                    lerpPos2 = mousePos;
                    //calls the function in the ball script to activate the coroutine
                    ballScript.BallIsThrown();
                }
            }
        }
    }

    public void ResetBirds()
    {
        //manual reset of the birds
        for (int a = 0; a < birds.Count; a++)
        {
            //destroys all the birds
            Destroy(birds[a]);
        }

        //clears the list
        birds.Clear();
    }
}
