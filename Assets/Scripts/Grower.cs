using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public Transform treeTransform;
    public Transform appleTransform;
    public float appleDelay = 1;

    Coroutine theGrowingCoroutine;
    Coroutine theTreeCoroutine;
    Coroutine theAppleCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        //StartCoroutine(GrowTree());
        //StartCoroutine(GrowApple());

        StartTreeGrowing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTreeGrowing()
    {
        //StartCoroutine(GrowTree());
        //StartCoroutine(GrowApple());

        StopCoroutine(StartTheGrowing());

        if (theGrowingCoroutine != null)
        {
            StopCoroutine(theGrowingCoroutine);
        }

        if (theTreeCoroutine != null)
        {
            StopCoroutine(theTreeCoroutine);
        }

        if (theAppleCoroutine != null)
        {
            StopCoroutine(theAppleCoroutine);
        }

        theGrowingCoroutine = StartCoroutine(StartTheGrowing());
    }

    IEnumerator StartTheGrowing()
    {
        Debug.Log("Starting...");
        yield return theTreeCoroutine = StartCoroutine(GrowTree());
        Debug.Log("...tree finished, starting apple...");

        yield return new WaitForSeconds(appleDelay);

        yield return theAppleCoroutine = StartCoroutine(GrowApple());
        Debug.Log("...done!!");
    }

    IEnumerator GrowTree()
    {
        Debug.Log("Started the tree");

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
        Debug.Log("Finished the tree");
    }

    IEnumerator GrowApple()
    {
        Debug.Log("Started the apple");

        float t = 0;
        appleTransform.localScale = Vector2.one * t;

        while (t < 1)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t;

            yield return null;
        }
        Debug.Log("Finished the apple");
    }
}
