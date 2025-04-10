using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Map : MonoBehaviour
{
    private Tile[] tiles;
    private float tileScale = 2;

    private void Awake()
    {
        tiles = FindObjectsByType<Tile>(FindObjectsSortMode.None);
    }

    public bool TryGetTileOnPosition(Vector3 position, out Tile tileOnPosition)
    {
        Vector2Int postionOnGrid = PositionOnGrid(position);
        foreach (Tile tile in tiles)
        {
            if(tile.Position == postionOnGrid)
            {
                Debug.Log("Tile position " + tile.Position);
                tileOnPosition = tile;
                return true;
            }
        }
        Debug.Log("No tile found");
        tileOnPosition = null;
        return false;
    }

    public HashSet<Tile> GetTilesInRange(Vector3 from, int range)
    {
        Vector2Int postionOnGrid = PositionOnGrid(from);
        return GetTilesInRange(postionOnGrid,range);
    }

    public HashSet<Tile> GetTilesInRange(Vector2Int from, int range)
    {
        HashSet<Tile> tilesInRange = new HashSet<Tile>();
        foreach (Tile tile in tiles)
        {
            Vector2Int distance = tile.Position - from;
            float distanceX = Mathf.Abs(distance.x);
            float distanceY = Mathf.Abs(distance.y);
            if (distanceX + distanceY <= range)
            {
                tilesInRange.Add(tile);
            }
        }
        return tilesInRange;
    }

    private Vector2Int PositionOnGrid(Vector3 worldPosition)
    {
        return Vector2Int.RoundToInt(new Vector2(worldPosition.x, worldPosition.z) / tileScale);
    }
}
