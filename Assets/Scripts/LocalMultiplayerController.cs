using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class LocalMultiplayerController : MonoBehaviour
{
    public LocalMultiplayerManager manager;
    public PlayerInput playerInput;
    public Vector2 movementInput;
    public float speed = 5;

    public TrailRenderer trailRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trailRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + ": Attacking");
            manager.PlayerAttacking(playerInput);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(PlayerDash());
        }
    }

    public IEnumerator PlayerDash()
    {
        trailRenderer.enabled = true;
        speed = 10;
        float t = 0;

        t += Time.deltaTime;

        while (t < 1)
        {
            t += Time.deltaTime;
            yield return null;
        }

        speed = 5;
        trailRenderer.enabled = false;
    }
}
