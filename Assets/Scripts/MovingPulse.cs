using Unity.VisualScripting;
using UnityEngine;

public class MovingPulse : MonoBehaviour
{
    public float speed = 3;
    public AnimationCurve curve;
    public TrailRenderer tr;

    float t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        Vector2 newPos = transform.position;

        newPos.x += speed * Time.deltaTime;
        newPos.y = curve.Evaluate(t);

        transform.position = newPos;

        if (newPos.x > 11.5)
        {
            tr.enabled = false;
            tr.Clear();

            newPos.x = -10.5f;
            transform.position = newPos;

            tr.Clear();
            tr.enabled = true;
        }
    }
}
