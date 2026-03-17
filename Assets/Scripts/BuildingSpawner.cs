using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject buildingPrefab;
    public GameObject spawnedBuilding;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame == true)
        {
            if (spawnedBuilding != null)
            {
                Destroy(spawnedBuilding);
            }

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            spawnedBuilding = Instantiate(buildingPrefab, mousePos, Quaternion.identity);
            StartCoroutine(SpawnBuilding());
        }
    }

    IEnumerator SpawnBuilding()
    {
        spawnedBuilding.transform.localScale = Vector2.zero;

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            spawnedBuilding.transform.localScale = Vector2.one * t;

            yield return null;
        }
    }
}
