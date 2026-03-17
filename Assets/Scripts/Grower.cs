using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public Transform treeTransform;
    public Transform appleTransform;
    public float appleDelay = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GrowTree());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTreeGrowing()
    {
        StartCoroutine(GrowTree());
    }

    IEnumerator GrowTree()
    {
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        float t = 0;

        t += Time.deltaTime;

        while (t < 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;

            yield return null;
        }

        yield return new WaitForSeconds(appleDelay);

        t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t;

            yield return null;
        }
    }
}
