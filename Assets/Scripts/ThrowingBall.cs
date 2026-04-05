using UnityEngine;

public class ThrowingBall : MonoBehaviour
{
    BirdSpawner birdScript;
    Vector2 lerpPos1;
    Vector2 lerpPos2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdScript = GetComponent<BirdSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpPos1 = birdScript.lerpPos;

        if (lerpPos1 != null)
        {
            
        }
    }
}
