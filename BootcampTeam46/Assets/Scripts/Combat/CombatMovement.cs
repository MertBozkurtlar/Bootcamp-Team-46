using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CombatMovement : MonoBehaviour
{
    public enum selectionType {
        selection,
        positive,
        negative
    }

    public selectionType pointerType;

    [SerializeField] private Tilemap pointerTilemap;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    [SerializeField] private TileBase positiveTile;
    [SerializeField] private TileBase negativeTile;
    [SerializeField] private TileBase selectionTile;

    private Vector2 mousePosition;
    Vector3Int lastGridPosition = Vector3Int.zero;
    private TileBase lastTile;
    private TileBase pointerTile;


    private MyInputs controls;
    private Vector3Int playerPosition;
    private bool isInLimits;
    

    //TODO: This is going to be on a setting object normally
    public static int moveLength = 4;

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

        lastTile = pointerTilemap.GetTile(lastGridPosition);
        pointerTile = selectionTile;
    }

    void Update ()
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3) mousePosition);
        
        int gridDeltaHorizontal = gridPosition.x - playerPosition.x;
        int gridDeltaVertical = gridPosition.y - playerPosition.y;

        int totalDifference = Mathf.Abs(gridDeltaHorizontal) + Mathf.Abs(gridDeltaVertical);
        Debug.Log(totalDifference);
        if (totalDifference < moveLength)
        {
            isInLimits = true;
        }
        else
        {
            isInLimits = false;
        }
    }
    private void MousePosition(Vector2 position)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(position);

        mousePosition = Camera.main.ScreenToWorldPoint(position);
        Vector3Int gridPosition = pointerTilemap.WorldToCell((Vector3) mousePosition);
        if (gridPosition != lastGridPosition)
        {
            pointerTilemap.SetTile(lastGridPosition, lastTile);
            lastTile = pointerTilemap.GetTile(gridPosition);
            pointerTilemap.SetTile(gridPosition, pointerTile);
            lastGridPosition = gridPosition;
        }
    }


    private void MouseClick()
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3) mousePosition);
        if(CanMove(gridPosition))
        {
            ColorArea(moveLength, playerPosition, true);
            playerPosition = gridPosition;
            ColorArea(moveLength, playerPosition, false);
            transform.position = (Vector3)gridPosition + new Vector3(0.5f, 0, 0);
        }

    }

    public void ColorArea(int size, Vector3Int position, bool clearArea)
    {
        TileBase tile;
        Vector3Int colorPosition;

        for (int x = -size + 1; x < size; x++)
        {
            for (int y = -(size - Mathf.Abs(x)) + 1; y < (size - Mathf.Abs(x)); y++)
            {
                if (clearArea)
                {
                    pointerTilemap.SetTile(position + new Vector3Int(x, y, 0), null);
                    // pointerTilemap.SetTile(position + new Vector3Int(x, -y, 0), null);
                    // pointerTilemap.SetTile(position + new Vector3Int(-x, y, 0), null);
                    // pointerTilemap.SetTile(position + new Vector3Int(-x, -y, 0), null);
                }
                else
                {
                    colorPosition = position + new Vector3Int(x, y, 0);
                    tile = CanMove(colorPosition) ? positiveTile : negativeTile;
                    pointerTilemap.SetTile(colorPosition, tile);

                    // pointerTilemap.SetTile(position + new Vector3Int(x, -y, 0), positiveTile);
                    // pointerTilemap.SetTile(position + new Vector3Int(-x, y, 0), positiveTile);
                    // pointerTilemap.SetTile(position + new Vector3Int(-x, -y, 0), positiveTile);
                }
            }
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
        return isInLimits;
    }
}
