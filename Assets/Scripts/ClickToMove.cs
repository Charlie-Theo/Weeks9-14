using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    public LineRenderer lr;
    public List<Vector2> points;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = new List<Vector2>();
        points.Add(transform.position);

        lr.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //add a new point into the line
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            points.Add(newPos);
            UpdateLineRenderer();
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            points.RemoveAt(0);
            UpdateLineRenderer();
        }
        
    }

    void UpdateLineRenderer()
    {
        lr.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }
}
