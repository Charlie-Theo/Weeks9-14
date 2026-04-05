using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public List<GameObject> birds;
    GameObject spawnedBird;

    Vector2 spawnPos;

    public float timerMax = 4;
    float timerValue = 0;

    public TextMeshProUGUI birdCounter;

    SpriteRenderer birdSR;
    Vector2 lerpPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        for (int b = 0;  b < birds.Count; b++)
        {
            birdSR = birds[b].GetComponent<SpriteRenderer>();

            if (birdSR.bounds.Contains(mousePos) == true && Mouse.current.leftButton.wasPressedThisFrame)
            {
                lerpPos = mousePos;
                Debug.Log(b);
            }
        }
    }
}
