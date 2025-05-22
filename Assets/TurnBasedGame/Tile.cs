using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool IsOccupied { get { return unit != null; } }
    [HideInInspector] public HashSet<Tile> Neighbours;
    public Unit unit;
    public Vector2Int Position;
    private float tileScale = 2;
    public static List<Tile> tiles = new List<Tile>();

    private void Awake()
    {
        tiles.Add(this);
        Position = Vector2Int.RoundToInt(new Vector2(transform.position.x, transform.position.z) / tileScale);
    }

    private void Start()
    {
        Neighbours = Map.Instance.GetTilesInRange(Position, 1);
    }
}
