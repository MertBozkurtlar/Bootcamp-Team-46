using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private TileBase selectionTile;
    [SerializeField] private Tilemap groundTilemap;

    private MyInputs controls;
    private Vector2 mousePosition;
    Vector3Int lastGridPosition = Vector3Int.zero;
    private TileBase groundTile;

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

    void Start()
    {
        controls.Combat.MousePosition.performed += ctx => MousePosition(ctx.ReadValue<Vector2>());
        groundTile = groundTilemap.GetTile(lastGridPosition);
    }

    private void MousePosition(Vector2 position)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(position);
        Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3) mousePosition);
        if (gridPosition != lastGridPosition)
        {
            groundTilemap.SetTile(lastGridPosition, groundTile);
            groundTile = groundTilemap.GetTile(gridPosition);
            groundTilemap.SetTile(gridPosition, selectionTile);
            lastGridPosition = gridPosition;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
