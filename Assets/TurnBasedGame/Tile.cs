using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector] public List<Tile> Neighbours;
    public bool IsOccupied;
    public Vector2Int Position;
    private float tileScale = 2;


    private void Awake()
    {
        Position = Vector2Int.RoundToInt(new Vector2(transform.position.x, transform.position.z) / tileScale);
    }

    private void Start()
    {
        Neighbours = FindAnyObjectByType<Map>().GetTilesInRange(Position, 1);
    }
}
