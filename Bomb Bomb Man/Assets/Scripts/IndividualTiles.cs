using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class IndividualTiles : MonoBehaviour, IExplode
{
    [Tooltip("Have this script only on tilemaps that will be destroyed on explosion")]
    Tilemap tilemap;
    Grid grid;
    Vector3Int lPos;
    private void Awake()
    {
        grid = GetComponentInParent<Grid>();
        tilemap = GetComponent<Tilemap>();
    }


    // Will set walltiles to null when explosion happens
    public void OnExplode(Vector2 pos)
    {
        lPos = grid.WorldToCell(pos);
        tilemap.SetTile(lPos + Vector3Int.right, null);
        tilemap.SetTile(lPos + Vector3Int.right + Vector3Int.down, null);
        tilemap.SetTile(lPos + Vector3Int.right + Vector3Int.up, null);
        tilemap.SetTile(lPos + Vector3Int.up, null);
        tilemap.SetTile(lPos + Vector3Int.left + Vector3Int.down, null);
        tilemap.SetTile(lPos + Vector3Int.left, null);
        tilemap.SetTile(lPos + Vector3Int.left + Vector3Int.up, null);
        tilemap.SetTile(lPos + Vector3Int.down, null);
    }


}
