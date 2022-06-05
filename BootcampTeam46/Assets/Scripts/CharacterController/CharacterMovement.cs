using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float collisionOffset = 0.02f;
    public ContactFilter2D movementFilter;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _renderer;
    private Vector2 movementInput;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
       if(movementInput != Vector2.zero)
       {
            bool success = TryToMove(movementInput);

            if (!success)
            {
                success = TryToMove(new Vector2(movementInput.x, 0));

                if (!success)
                    success = TryToMove(new Vector2(0, movementInput.y));
            }
            _animator.SetBool("isMoving", true);
       }
       else
            _animator.SetBool("isMoving", false);

        if (movementInput.x < 0)
        {
            _renderer.flipX = true;
        }
        else if(movementInput.x > 0)
        {
            _renderer.flipX = false;
        }
           
    }

    private bool TryToMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = _rigidbody2D.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);
            
            if (count == 0)
            {
                _rigidbody2D.MovePosition(_rigidbody2D.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    private void OnMovement(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

}
