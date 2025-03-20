using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool IsOccupied;
    public Vector2Int Position;
    private float tileScale = 2;

    private void Awake()
    {
        Position = Vector2Int.RoundToInt(new Vector2(transform.position.x, transform.position.z) / tileScale);
    }
}
