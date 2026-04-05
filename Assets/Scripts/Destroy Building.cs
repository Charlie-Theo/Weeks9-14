using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    public Transform buildingTrans;
    public AnimationCurve curve;
    public ParticleSystem particles;

    public GameObject building;
    public float delay = 2;

    public CinemachineImpulseSource impulseSource;
    public AudioSource SFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDestroy()
    {
        StartCoroutine(StartTheDestruction());
    }

    public IEnumerator StartTheDestruction()
    {
        StartCoroutine(CollapseBuilding());
        yield return new WaitForSeconds(delay);
        StartCoroutine(EraseBuilding());

    }

    public IEnumerator CollapseBuilding()
    {
        particles.Play();
        SFX.Play();
        impulseSource.GenerateImpulse();
        buildingTrans.localScale = Vector2.zero;

        float t = 1;

        t -= Time.deltaTime;

        while (t > 0)
        {
            t -= Time.deltaTime;

            Vector2 newScale = Vector2.one * t;
            newScale.x = 1;
            newScale.y = curve.Evaluate(t);

            buildingTrans.localScale = newScale;

            yield return null;

            newScale = Vector2.zero;
            buildingTrans.localScale = newScale;
        }

        particles.Stop();
    }

    public IEnumerator EraseBuilding()
    {
        yield return null;
        Destroy(building);
    }
}
