using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class RandomBuildings : MonoBehaviour
{
    public List<DestroyBuilding> villageBuildings;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestoryRandomBuilding()
    {
        int randomNum = Random.Range(0, villageBuildings.Count);
        
        villageBuildings[randomNum].StartDestroy();

    }
}
