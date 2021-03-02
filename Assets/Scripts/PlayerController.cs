using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] [Min(0)] private float speed = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
    }
    
    private void HandleMovement()
    {
        Vector2 movementInput = new Vector2(
            Input.GetAxis("Horizontal"), 
            Input.GetAxis("Vertical"));
        Vector2 displacement = movementInput.normalized * speed;
        
        rb.MovePosition(rb.position + displacement);
    }
}