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
    private Vector2 movementInput;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
