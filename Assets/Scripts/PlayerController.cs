using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] [Min(0)] private float speed = 1f;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] private AudioSource crashAudio;
    [SerializeField] private AudioSource helicopterAudio;
    [SerializeField, Range(0, 1)] private float moveSlowdown = 0.3f;

    private Vector2 velocity;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.Instance.canPlayerControl)
        {
            HandleMovement();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tree"))
        {
            helicopterAudio.Stop();
            crashAudio.Play();
            GameManager.Instance.EndGame();
        }
    }

    private void HandleMovement()
    {
        Vector2 movementInput = new Vector2(
            Input.GetAxis("Horizontal"), 
            Input.GetAxis("Vertical"));
        Vector2 displacement = movementInput.normalized * speed;
        velocity += displacement;

        rb.MovePosition(rb.position + velocity);
        
        // Slow down the helicopter
        velocity = Vector2.Lerp(velocity, Vector2.zero, moveSlowdown);
        
        // Do sprite flipping
        if (mainSpriteRenderer != null)
        {
            if (movementInput.x > 0)
            {
                mainSpriteRenderer.flipX = true;
            }
            else if (movementInput.x < 0)
            {
                mainSpriteRenderer.flipX = false;
            }
        }
    }
}