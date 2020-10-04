using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IndividualTiles : MonoBehaviour, IExplode
{
    public Tilemap tilemap;
    TileBase tile;
    Grid grid;
    Vector3Int lPos;
    Movement player;
    private void Awake()
    {
        grid = GetComponentInParent<Grid>();
        player = FindObjectOfType<Movement>();
        tilemap = GetComponent<Tilemap>();
        
    }

    public void OnExplode(Vector2 pos)
    {
        Debug.Log("Savage!");
        lPos = grid.WorldToCell(pos);
        tile = tilemap.GetTile(lPos + Vector3Int.right);
        if (tile != null)
        {
            DestroyImmediate(tile, true);
        }
    }


}
