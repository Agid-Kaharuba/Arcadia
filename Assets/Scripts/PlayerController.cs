using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] [Min(0)] private float speed = 1f;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;

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
            GameManager.Instance.EndGame();
        }
    }

    private void HandleMovement()
    {
        Vector2 movementInput = new Vector2(
            Input.GetAxis("Horizontal"), 
            Input.GetAxis("Vertical"));
        Vector2 displacement = movementInput.normalized * speed;
        
        rb.MovePosition(rb.position + displacement);
        
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