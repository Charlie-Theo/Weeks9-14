using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangingSprite : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> sprites;
    public int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeSprite(InputAction.CallbackContext context)
    {
        if (context.started == true)
        {
            index++;
            if (index == sprites.Count)
            {
                index = 0;
            }

            sr.sprite = sprites[index];
        }
    }
}
