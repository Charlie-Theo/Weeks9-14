using UnityEngine;

public class Knight : MonoBehaviour
{
    public AudioSource SFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Footstep()
    {
        Debug.Log("Footstep");

        SFX.pitch = Random.Range(0.7f, 1.3f);
        SFX.volume = Random.Range(0.5f, 1);

        SFX.Play();
    }
}
