using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CombatMovement : MonoBehaviour
{
    private MyInputs controls;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    private Vector2 mousePosition;

    private void Awake() 
    {
        controls = new MyInputs();
    }

    private void OnEnable() 
    {
        controls.Enable();
    }

    private void OnDisable() 
    {
        controls.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        controls.Combat.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Combat.MousePosition.performed += ctx => MousePosition(ctx.ReadValue<Vector2>());
        controls.Combat.MouseAction.started += (ctx) => MouseClick();
    }

    private void MousePosition(Vector2 position)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(position);
    }

    private void MouseClick()
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3) mousePosition);
        Debug.Log(groundTilemap.GetColor(gridPosition));
        if(CanMove(gridPosition))
        {
            transform.position = (Vector3)gridPosition + new Vector3(0.5f, 0, 0);
        }

    }

    private void Move(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3) direction);
        if(CanMove(gridPosition))
        {
            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector3Int gridPosition)
    {
        
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
            return false;
        return true;
    }
}
